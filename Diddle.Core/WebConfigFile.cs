namespace Diddle.Core
{
    public static class WebConfigFile
    {
        public static string Content =>
@"<?xml version=""1.0"" encoding=""UTF-8""?>

<configuration>
   
    <!-- The following section is to force use of Fiddler for all applications, including those running in service accounts -->
    <system.net>
      <defaultProxy enabled=""true"" useDefaultCredentials=""true"">
        <proxy bypassonlocal=""False"" proxyaddress=""http://127.0.0.1:8888"" usesystemdefault=""False""/>
      </defaultProxy>
    </system.net>

</configuration>
";
    }
}