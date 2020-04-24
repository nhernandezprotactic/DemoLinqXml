using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace DemoLinqXaml
{
    public class Write
    {
        /// <summary>
        /// Create an xml file wich store application settings
        /// </summary>
        public static void WriteXmlFile()
        {
            #region Set Properties
            string DBUserId = "Sa";
            string DBPassword = "2017SaSql";
            string DBInstance = @"DT-SOFTWARE03\\SQLEXPRESS";
            string DBInitialCatalog = "PT.BioTraze.Cliente";
            bool DbIntegratedSecurity = false;
            string ReportServerUrl = "http://192.168.1.72/ReportServer";
            string ReportPath = "/biotraze/reportes/";
            string ReportUser = "reportes";
            string ReportPassword = "*R3p0rt3s";
            string ReportDomain = "192.168.1.72";
            string SettingsLocation = "Dirección General de Seguridad Pública y Tránsito";
            string SettingsElementsPerPage = "8";
            string DeviceFingerPrint = "CrossMatch";
            string DeviceCamera = "Canon";
            string DeviceESign = "ePadlink";
            bool DeviceESignBool = false;
            #endregion

            #region Write XML document
            XDocument doc = new XDocument(
                     new XElement("body",
                        new XElement("DBUserId", DBUserId),
                        new XElement("DBPassword", DBPassword),
                        new XElement("DBInstance", DBInstance),
                        new XElement("DBInitialCatalog", DBInitialCatalog),
                        new XElement("DbIntegratedSecurity", DbIntegratedSecurity),
                        new XElement("ReportServerUrl", ReportServerUrl),
                        new XElement("ReportPath", ReportPath),
                        new XElement("ReportUser", ReportUser),
                        new XElement("ReportPassword", ReportPassword),
                        new XElement("ReportDomain", ReportDomain),
                        new XElement("SettingsLocation", SettingsLocation),
                        new XElement("SettingsElementsPerPage", SettingsElementsPerPage),
                        new XElement("DeviceFingerPrint", DeviceFingerPrint),
                        new XElement("DeviceCamera", DeviceCamera),
                        new XElement("DeviceESign", DeviceESign),
                        new XElement("DeviceESignBool", DeviceESignBool))); 
            #endregion


            #region Build file path
            var filename = "Protactic.Cliente.Config";
            var currentDirectory = Directory.GetCurrentDirectory();
            var filepath = Path.Combine(currentDirectory, filename);
            #endregion

            #region Save Document
            doc.Save(filepath); 
            #endregion
        }

        public static void LoadXmlFile()
        {
            #region file path
            var filename = "Protactic.Cliente.Config";
            var currentDirectory = Directory.GetCurrentDirectory();
            var filepath = Path.Combine(currentDirectory, filename);
            #endregion

            #region Load Settings
            XElement xml = XElement.Load(filepath);
            string EXAMPLE = xml.Descendants("DBUserId").Select(x => (string)x).FirstOrDefault();
            Console.WriteLine(EXAMPLE);
            Console.Read();
            #endregion
        }
    }
}
