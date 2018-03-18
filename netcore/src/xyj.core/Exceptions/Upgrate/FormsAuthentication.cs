namespace xyj.core.Exceptions.Upgrate
{
    public class FormsAuthentication
    {
        public static string HashPasswordForStoringInConfigFile(string src, string type= "SHA1")
        {
            throw  new NotSupportedExceptionInCoreException();
            //  var sha1 = System.Security.Cryptography.SHA1.Create();
            
            // var hash = sha1.ComputeHash(myByteArray);
            // return hash.ToString();
        }
    }
}