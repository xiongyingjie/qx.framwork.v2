namespace xyj.core.Utility
{
    public static class StringUtility
    {
        public static string ToCamelCase( string src, char flag = '_',bool toSmall=true)
        {
            var apiModel = "";
            for (var index = 0; index < src.Length; index++)
            {
                var elem = src[index];
                var nextElem = index < src.Length - 1 ? src[index + 1] : ' ';
                var nextNextElem = index < src.Length - 2 ? src[index + 2] : ' ';
                if (nextElem == flag)
                {
                    apiModel += elem + nextNextElem.ToString().ToUpper();
                    index += 2;
                }
                else if (index == 0)
                {
                    apiModel += toSmall? elem.ToString().ToLower(): elem.ToString().ToUpper();//和big的区别是此处小写
                }
                else
                {
                    apiModel += elem;
                }
            }
            return apiModel;
        }
    }
}
