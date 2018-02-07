using System.IO;
using System.Text;

namespace Diddle.Core
{
    public static class FiddlerIISProxy
    {
        public const string IISRootWebConfig = "C:\\inetpub\\wwwroot\\Web.config";
        
        public static void On()
        {
            if (File.Exists(IISRootWebConfig))
            {
                File.Delete(IISRootWebConfig);
            }

            File.WriteAllText(IISRootWebConfig, WebConfigFile.Content, Encoding.UTF8);
        }

        public static void Off()
        {
            if (File.Exists(IISRootWebConfig))
            {
                File.Delete(IISRootWebConfig);
            }
        }

        public static bool Status()
        {
            return File.Exists(IISRootWebConfig);
        }
    }
}