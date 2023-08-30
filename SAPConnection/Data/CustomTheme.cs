using System.Runtime.Intrinsics.X86;

namespace SAPConnection.Data
{


    public class CustomTheme
    {
        public string ThemeColor { get; set; } = "dark";

        public string backgroundColor { get; set; } = "white";
        public string sidebarColor { get; set; } = "#08182f";
        public string navColor { get; set; } = "#08182f";
        public string btnColor { get; set; } = "#df8f06";
        public string Hovercolor { get; set; } = "#df8f06";


        public void onThemeChange()
        {
            if (ThemeColor == "light")
            {
                backgroundColor = "#white";
                sidebarColor = "#37474f";
                navColor = "#37474f";
                btnColor = "#6ca988";
                Hovercolor = "#0a58ca";
            }
            else if (ThemeColor == "dark")
            {
                backgroundColor = "white";
                sidebarColor = "#08182f";
                navColor = "#08182f";
                btnColor = "#df8f06";
                Hovercolor = "#df8f06";
            }
            else if (ThemeColor == "Theme1")
            {
                backgroundColor = "white";
                sidebarColor = "#b9b47d";
                btnColor = "#809da6";
                navColor = "#b9b47d";
                Hovercolor = "#809da6";
            }
            else if (ThemeColor == "Theme2")
            {
                backgroundColor = "white";
                sidebarColor = "#8b4859";
                btnColor = "#dcb385";
                navColor = "#8b4859";
                Hovercolor = "#dcb385";
            }
            else
            {
                backgroundColor = "white";
                sidebarColor = "#5A5560";
                navColor = "#5A5560";
                btnColor = "#8860D0";
                Hovercolor = "#8860D0";
            }
        }
    }
}


