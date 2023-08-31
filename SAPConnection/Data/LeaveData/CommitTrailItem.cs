using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SAPConnection.Data.LeaveData
{
    public class CommitTrailItem
    {
        [Key]
        public int CommitId { get; set; }
        public int LeaveId { get; set; }
        public string? CommitMessage { get; set; }
        public DateTime TimeStamp { get; set; }
        public string CommitOwnerId { get; set; }
        public string CommitOwnerName { get; set; }
        public string ActionPerformed { get; set; }

    }



}

