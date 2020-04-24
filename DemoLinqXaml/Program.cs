namespace DemoLinqXaml
{
    class Program
    {
        static void Main(string[] args)
        {
            string masterKey = "pr0t.4.t#ic";
            DemoXml.WriteXmlFile(masterKey);
            DemoXml.LoadXmlFile(masterKey);
        }
    }    
}
