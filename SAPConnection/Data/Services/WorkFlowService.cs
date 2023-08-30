using Blazored.Toast.Services;
using MailKit.Search;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SAPConnection.Data.Services
{
    public class WorkFlowService
    {
        private readonly IDbContextFactory<MyDbContext> _contextFactory;
        public WorkFlowService(IDbContextFactory<MyDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task CreateWorkFlow(WorkflowItem workflowItem)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Workflows.Add(workflowItem);
            await context.SaveChangesAsync();

        }

        public async Task<List<WorkflowItem>> GetSelectedWorkflowsAsync(string key)
        {
            using var context = _contextFactory.CreateDbContext();
            List<WorkflowItem> query = new List<WorkflowItem>();
            if (!string.IsNullOrEmpty(key))
            {
                query = await context.Workflows
                .Where(w => w.Key == key)
                .OrderBy(w => w.Level)
                .ToListAsync();
                //query = await context.Workflows.FromSqlRaw("Select * from Workflows where Key={0}", key).ToListAsync();
            }
            return query;

        }

        public async Task UpdateWorkflowAsync(WorkflowItem wf)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Entry(wf).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteWorkFlowAsync(string? wf_key)
        {
            using var context = _contextFactory.CreateDbContext();
            var wfs = await context.Workflows.Where(w => w.Key == wf_key).ToListAsync();
            foreach (var wf in wfs)
            {
                context.Workflows.Remove(wf);
            }
            await context.SaveChangesAsync();
        }

        public async Task DeleteWorkFlowByIDAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var wfs = await context.Workflows.Where(w => w.Id == id).ToListAsync();
            context.Workflows.Remove(wfs[0]);
            await context.SaveChangesAsync();
        }

        public async Task<List<string>> GetAllWorkflowKeysAsync()
        {

            using var context = _contextFactory.CreateDbContext();

            var query = await context.Workflows.Select(w => w.Key).Distinct().ToListAsync();
            //var query = await context.Workflows.FromSqlRaw("Select * from Workflows").ToListAsync();
            return query;

        }

        public async Task<List<string>> GetAllWorkflowKeysByAppAsync(string appname)
        {

            using var context = _contextFactory.CreateDbContext();

            var query = await context.Workflows.Where(w => w.App == appname).Select(w => w.Key).Distinct().ToListAsync();
            //var query = await context.Workflows.FromSqlRaw("Select * from Workflows").ToListAsync();
            return query;

        }

        public async Task<List<WorkflowApproverDetails>> GetWorkflowApprovers(string workflowKey, string pno)
        {
            using var context = _contextFactory.CreateDbContext();
            var workflow = await context.Workflows
                .Where(w => w.Key == workflowKey)
                .OrderBy(w => w.Level)
                .ToListAsync();
            var user = await context.ApplicationUser.FirstOrDefaultAsync(u => u.Pno == pno);


            var approvers = new List<WorkflowApproverDetails>();
            foreach (var item in workflow)
            {
                string managerId;
                switch (item.ApproverRole)
                {
                    case ApproverRole.Incharge:
                        var shiftId = context.Approvers.Where(a => a.SectionId == user.SectionId && a.DepartmentId == user.DepartmentId).Select(a => a.SapId).First();
                        managerId = context.ShiftIncharge.Where(a => a.ApproversId == shiftId).Select(a => a.ShiftInchargePno).First();
                        break;
                    case ApproverRole.SectionHead:
                        managerId = context.Approvers.Where(a => a.SectionId == user.SectionId && a.DepartmentId == user.DepartmentId).Select(a => a.SectionHeadId).First();
                        break;
                    case ApproverRole.UnitManager:
                        managerId = context.Approvers.Where(a => a.SectionId == user.SectionId && a.DepartmentId == user.DepartmentId).Select(a => a.UnitManagerId).First();
                        break;
                    case ApproverRole.DepartmentHead:
                        managerId = context.Approvers.Where(a => a.SectionId == user.SectionId && a.DepartmentId == user.DepartmentId).Select(a => a.DepartmentHeadId).First();
                        break;
                    case ApproverRole.FunctionalHead:
                        managerId = context.Approvers.Where(a => a.SectionId == user.SectionId && a.DepartmentId == user.DepartmentId).Select(a => a.FunctionalHeadId).First();
                        break;
                    case null:
                        managerId = context.StaticApproversModels.Where(a => a.RoleId == item.StaticApproverRole).Select(a => a.Pno).First();
                        break;
                    default:
                        throw new ArgumentException($"Invalid ApproverRole: {item.ApproverRole}");
                }

                //ApplicationUser applicationUser = await _userManager.Users.Where(u => u.Pno == managerId).FirstOrDefaultAsync();
                //if (applicationUser.Acting && DateTime.Now >= applicationUser.FromDate && DateTime.Now <= applicationUser.ToDate)
                //{
                //    managerId = (int)applicationUser.ActingPno;
                //}

                ApplicationUser applicationUser = new ApplicationUser();

                try
                {
                    applicationUser = await context.ApplicationUser.Where(u => u.Pno == managerId).FirstOrDefaultAsync();
                    if (applicationUser != null)
                    {
                        if (applicationUser.Acting && DateTime.Now >= applicationUser.FromDate && DateTime.Now <= applicationUser.ToDate)
                        {
                            managerId = applicationUser.ActingPno;
                        }
                    }
                    else
                    {
                        approvers.Clear();
                        break;
                    }
                }
                catch (Exception ex)
                {
                }


                var approver = await context.ApplicationUser
                    .Where(u => u.Pno == managerId)
                    .Select(u => new WorkflowApproverDetails
                    {
                        ApproverEmail = u.Email,
                        AssignedTask = item.AssignedTask,
                        Pno = u.Pno,
                        Name = u.Name

                    })
                    .FirstOrDefaultAsync();

                if (approver != null)
                {
                    approvers.Add(approver);
                }
            }


            return approvers;
        }

        public async Task<(string, List<WorkflowApproverDetails>)> GetPOWorkflowApprovers(string workflowKey, ApplicationUser appUser, double? amount)
        {
            string pno = appUser.Pno;
            double picking = -1;
            List<double?> allfixamounts = new List<double?>();
            var context = _contextFactory.CreateDbContext();
            List<WorkflowItem>? wf = new List<WorkflowItem>();
            var workflow = await context.Workflows
                .Where(w => w.Key.Contains(workflowKey))
                .OrderBy(w => w.Level)
                .ToListAsync();

            if (workflow.Count > 0)
            {
                char[] signsToFind = { '=', '<', '>', '!' };
                char endingCharacter = '-';
                foreach (var item in workflow)
                {
                    string? compKey = item.Key;
                    int startIndex = compKey.IndexOfAny(signsToFind);
                    int endIndex = compKey.LastIndexOf(endingCharacter);
                    int occurrenceCount = compKey.Count(c => c == endingCharacter);
                    if (occurrenceCount == 2)
                    {   // In case of PNo, SectionId, DesignationId WorkFlow of PO
                        string fixedId = compKey.Substring(endIndex + 1);
                        if (appUser.Pno == fixedId)
                        {
                            if (startIndex > 0 && endIndex > 0 && endIndex > startIndex)
                            {
                                string StrFixAmount_Sign = compKey.Substring(startIndex, endIndex - startIndex);
                                int prevWF_Count = wf.Count;
                                if (prevWF_Count == 0 || picking == 2.1)
                                {
                                    GetAppropriateWFs(ref StrFixAmount_Sign, ref amount, ref workflowKey, item, ref wf, ref allfixamounts);
                                }
                                if (wf.Count > prevWF_Count)
                                {
                                    picking = 2.1;
                                }
                            }
                        }
                        else if (appUser.SectionId == fixedId)
                        {
                            if (startIndex > 0 && endIndex > 0 && endIndex > startIndex)
                            {
                                string StrFixAmount_Sign = compKey.Substring(startIndex, endIndex - startIndex);
                                int prevWF_Count = wf.Count;
                                if (prevWF_Count == 0 || picking == 2.2)
                                {
                                    GetAppropriateWFs(ref StrFixAmount_Sign, ref amount, ref workflowKey, item, ref wf, ref allfixamounts);
                                }
                                if (wf.Count > prevWF_Count)
                                {
                                    picking = 2.2;
                                }
                            }
                        }
                        else if (appUser.DesignationId == fixedId)
                        {
                            if (startIndex > 0 && endIndex > 0 && endIndex > startIndex)
                            {
                                string StrFixAmount_Sign = compKey.Substring(startIndex, endIndex - startIndex);
                                int prevWF_Count = wf.Count;
                                if (prevWF_Count == 0 || picking == 2.3)
                                {
                                    GetAppropriateWFs(ref StrFixAmount_Sign, ref amount, ref workflowKey, item, ref wf, ref allfixamounts);
                                }
                                if (wf.Count > prevWF_Count)
                                {
                                    picking = 2.3;
                                }
                            }
                        }
                    }
                    // In case of General or Rotating Shift WorkFlow of PO
                    else if (occurrenceCount == 3)
                    {
                        if (startIndex > 0 && endIndex > 0 && endIndex > startIndex)
                        {
                            string StrFixAmount_Sign = compKey.Substring(startIndex, (endIndex - startIndex) - 2);
                            int prevWF_Count = wf.Count;
                            if (prevWF_Count == 0 || picking == 3)
                            {
                                GetAppropriateWFs(ref StrFixAmount_Sign, ref amount, ref workflowKey, item, ref wf, ref allfixamounts);
                            }
                            if (wf.Count > prevWF_Count)
                            {
                                picking = 3;
                            }
                        }
                    }
                    // In case of General WorkFlow of PO
                    else if (occurrenceCount == 1 && startIndex > 0)
                    {
                        string StrFixAmount_Sign = compKey.Substring(startIndex);
                        int prevWF_Count = wf.Count;
                        if (prevWF_Count == 0 || picking == 1)
                        {
                            GetAppropriateWFs(ref StrFixAmount_Sign, ref amount, ref workflowKey, item, ref wf, ref allfixamounts);
                        }
                        if (wf.Count > prevWF_Count)
                        {
                            picking = 1;
                        }
                    }
                }
                //workflow = wf;

                //Filtering workflows Picking those wfs whose amount is nearer to wf amount
                workflow.Clear();

                var distinct_fix_amounts = allfixamounts.Distinct().ToList();
                List<double?> subtracted_amounts = new List<double?>();
                double? temp;
                foreach (var v in distinct_fix_amounts)
                {
                    temp = Math.Abs(Int32.Parse((v - amount).ToString()));
                    subtracted_amounts.Add(temp);
                }
                var min_value = subtracted_amounts.Min();
                int min_index = subtracted_amounts.IndexOf(min_value);
                var checkamount = distinct_fix_amounts[min_index];
                int k = 0;
                foreach (var w in wf)
                {
                    if (checkamount == allfixamounts[k])
                    {
                        workflow.Add(w);
                    }
                    k++;
                }

            }

            var user = await context.ApplicationUser.FirstOrDefaultAsync(u => u.Pno == pno);


            var approvers = new List<WorkflowApproverDetails>();
            foreach (var item in workflow)
            {
                string managerId;
                switch (item.ApproverRole)
                {
                    case ApproverRole.SectionHead:
                        managerId = context.Approvers.Where(a => a.SectionId == user.SectionId && a.DepartmentId == user.DepartmentId).Select(a => a.SectionHeadId).First();
                        break;
                    case ApproverRole.UnitManager:
                        managerId = context.Approvers.Where(a => a.SectionId == user.SectionId && a.DepartmentId == user.DepartmentId).Select(a => a.UnitManagerId).First();
                        break;
                    case ApproverRole.DepartmentHead:
                        managerId = context.Approvers.Where(a => a.SectionId == user.SectionId && a.DepartmentId == user.DepartmentId).Select(a => a.DepartmentHeadId).First();
                        break;
                    case ApproverRole.FunctionalHead:
                        managerId = context.Approvers.Where(a => a.SectionId == user.SectionId && a.DepartmentId == user.DepartmentId).Select(a => a.FunctionalHeadId).First();
                        break;
                    case null:
                        managerId = context.StaticApproversModels.Where(a => a.RoleId == item.StaticApproverRole).Select(a => a.Pno).First();
                        break;
                    default:
                        throw new ArgumentException($"Invalid ApproverRole: {item.ApproverRole}");
                }
                ApplicationUser applicationUser = new ApplicationUser();

                try
                {
                    applicationUser = await context.ApplicationUser.Where(u => u.Pno == managerId).FirstOrDefaultAsync();
                    if (applicationUser != null)
                    {
                        if (applicationUser.Acting && DateTime.Now >= applicationUser.FromDate && DateTime.Now <= applicationUser.ToDate)
                        {
                            managerId = applicationUser.ActingPno;
                        }
                    }
                    else
                    {
                        workflowKey = "user not found";
                        approvers.Clear();
                        break;
                    }
                }
                catch (Exception ex)
                { }


                var approver = await context.ApplicationUser
                    .Where(u => u.Pno == managerId)
                    .Select(u => new WorkflowApproverDetails
                    {
                        ApproverEmail = u.Email,
                        AssignedTask = item.AssignedTask,
                        Pno = u.Pno,
                        Name = u.Name

                    })
                    .FirstOrDefaultAsync();

                if (approver != null)
                {
                    approvers.Add(approver);
                }
            }

            return (workflowKey, approvers);
        }

        private void GetAppropriateWFs(ref string StrFixAmount_Sign, ref double? amount, ref string workflowKey, WorkflowItem item, ref List<WorkflowItem> wf, ref List<double?> allfixamounts)
        {
            //List<WorkflowItem>? wf = new List<WorkflowItem>();

            string sign = "";
            double fixAmount = 0;
            int fixAmountIndex = 0;
            //Separating Sign and Amount
            sign = StrFixAmount_Sign[0].ToString() + StrFixAmount_Sign[1].ToString();
            switch (sign)
            {
                case "<=":
                case ">=":
                case "!=":
                    fixAmountIndex = 2;
                    break;
                default:
                    sign = sign[0].ToString();
                    fixAmountIndex = 1;
                    break;
            }
            fixAmount = Double.Parse(StrFixAmount_Sign.Substring(fixAmountIndex));
            // Matching values
            if (sign == "=")
            {
                if (amount == fixAmount)
                {
                    workflowKey = item.Key;
                    allfixamounts.Add(fixAmount);
                    wf.Add(item);
                }
            }
            else if (sign == "<")
            {
                if (amount < fixAmount)
                {
                    workflowKey = item.Key;
                    allfixamounts.Add(fixAmount);
                    wf.Add(item);
                }
            }
            else if (sign == ">")
            {
                if (amount > fixAmount)
                {
                    workflowKey = item.Key;
                    allfixamounts.Add(fixAmount);
                    wf.Add(item);
                }
            }
            else if (sign == "<=")
            {
                if (amount <= fixAmount)
                {
                    workflowKey = item.Key;
                    allfixamounts.Add(fixAmount);
                    wf.Add(item);
                }
            }
            else if (sign == ">=")
            {
                if (amount >= fixAmount)
                {
                    workflowKey = item.Key;
                    allfixamounts.Add(fixAmount);
                    wf.Add(item);
                }
            }
            else if (sign == "!=")
            {
                if (amount != fixAmount)
                {
                    workflowKey = item.Key;
                    allfixamounts.Add(fixAmount);
                    wf.Add(item);
                }
            }
        }
        public async Task<ApplicationUser> GetApplicationUserByPno(string pno)
        {
            using var context = _contextFactory.CreateDbContext();
            ApplicationUser applicationUser = new ApplicationUser();
            try
            {
                applicationUser = await context.ApplicationUser.Where(u => u.Pno == pno).FirstOrDefaultAsync();
            }
            catch (Exception ex) { }
            return applicationUser;
        }
    }

}
