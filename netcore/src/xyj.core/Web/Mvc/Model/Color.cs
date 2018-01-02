namespace xyj.core.Web.Mvc.Model
{
    public  enum Color
    {
        Blue,
        Green,
        LightBlue,
        Orange,
        Red
    }
    public static class ColorExtensions
{
        public static string GetCss(this Color color, string frontString = "")
        {
            var css = frontString;
            switch (color)
            {
                case Color.Blue: css += "primary"; break;
                case Color.Green: css += "success"; break;
                case Color.LightBlue: css += "info"; break;
                case Color.Orange: css += "warning"; break;
                case Color.Red: css += "danger"; break;
            }
            return css;
        }
}
}
