using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using PT.Security.Symmetric;

namespace DemoLinqXaml
{
    public class DemoXml
    {
        /// <summary>
        /// Create an xml file wich store application settings
        /// </summary>
        public static void WriteXmlFile(string masterKey)
        {
            #region Set Properties
            string DBUserId =                   TripleDESSecurity.Encrypt("Sa",masterKey);
            string DBPassword =                 TripleDESSecurity.Encrypt("2017SaSql",masterKey);
            string DBInstance =                 TripleDESSecurity.Encrypt(@"DT-SOFTWARE03\\SQLEXPRESS",masterKey);
            string DBInitialCatalog =           TripleDESSecurity.Encrypt("PT.BioTraze.Cliente",masterKey);
            string DbIntegratedSecurity =       TripleDESSecurity.Encrypt("false",masterKey);
            string ReportServerUrl =            TripleDESSecurity.Encrypt("http://192.168.1.72/ReportServer",masterKey);
            string ReportPath =                 TripleDESSecurity.Encrypt("/biotraze/reportes/",masterKey);
            string ReportUser =                 TripleDESSecurity.Encrypt("reportes",masterKey);
            string ReportPassword =             TripleDESSecurity.Encrypt("*R3p0rt3s",masterKey);
            string ReportDomain =               TripleDESSecurity.Encrypt("192.168.1.72",masterKey);
            string SettingsLocation =           TripleDESSecurity.Encrypt("Direccion General de Seguridad Publica y Transito",masterKey);
            string SettingsElementsPerPage =    TripleDESSecurity.Encrypt("8",masterKey);
            string DeviceFingerPrint =          TripleDESSecurity.Encrypt("CrossMatch",masterKey);
            string DeviceCamera =               TripleDESSecurity.Encrypt("Canon",masterKey);
            string DeviceESign =                TripleDESSecurity.Encrypt("ePadlink",masterKey);
            string DeviceESignBool =            TripleDESSecurity.Encrypt("false",masterKey);
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

            Console.WriteLine("Documento creado");
            //LoadXmlFile(masterKey);
        }

        public static void LoadXmlFile(string masterKey)
        {
            #region file path
            var filename = "Protactic.Cliente.Config";
            var currentDirectory = Directory.GetCurrentDirectory();
            var filepath = Path.Combine(currentDirectory, filename);
            #endregion

            #region Load Settings
            XElement xml = XElement.Load(filepath);
            string DBUserId = xml.Descendants("DBUserId").Select(x => (string)x).FirstOrDefault();
            string DBPassword = xml.Descendants("DBPassword").Select(x => (string)x).FirstOrDefault();
            string DBInstance = xml.Descendants("DBInstance").Select(x => (string)x).FirstOrDefault();
            string DBInitialCatalog = xml.Descendants("DBInitialCatalog").Select(x => (string)x).FirstOrDefault();
            string DbIntegratedSecurity = xml.Descendants("DbIntegratedSecurity").Select(x => (string)x).FirstOrDefault();
            string ReportServerUrl = xml.Descendants("ReportServerUrl").Select(x => (string)x).FirstOrDefault();
            string ReportPath = xml.Descendants("ReportPath").Select(x => (string)x).FirstOrDefault();
            string ReportUser = xml.Descendants("ReportUser").Select(x => (string)x).FirstOrDefault();
            string ReportPassword = xml.Descendants("ReportPassword").Select(x => (string)x).FirstOrDefault();
            string ReportDomain = xml.Descendants("ReportDomain").Select(x => (string)x).FirstOrDefault();
            string SettingsLocation = xml.Descendants("SettingsLocation").Select(x => (string)x).FirstOrDefault();
            string SettingsElementsPerPage = xml.Descendants("SettingsElementsPerPage").Select(x => (string)x).FirstOrDefault();
            string DeviceFingerPrint = xml.Descendants("DeviceFingerPrint").Select(x => (string)x).FirstOrDefault();
            string DeviceCamera = xml.Descendants("DeviceCamera").Select(x => (string)x).FirstOrDefault();
            string DeviceESign = xml.Descendants("DeviceESign").Select(x => (string)x).FirstOrDefault();
            string DeviceESignBool = xml.Descendants("DeviceESignBool").Select(x => (string)x).FirstOrDefault();

            Console.WriteLine(TripleDESSecurity.Decrypt(DBUserId, masterKey));
            Console.WriteLine(TripleDESSecurity.Decrypt(DBPassword, masterKey));
            Console.WriteLine(TripleDESSecurity.Decrypt(DBInstance, masterKey));
            Console.WriteLine(TripleDESSecurity.Decrypt(DBInitialCatalog, masterKey));
            Console.WriteLine(TripleDESSecurity.Decrypt(DbIntegratedSecurity, masterKey));
            Console.WriteLine(TripleDESSecurity.Decrypt(ReportServerUrl, masterKey));
            Console.WriteLine(TripleDESSecurity.Decrypt(ReportPath, masterKey));
            Console.WriteLine(TripleDESSecurity.Decrypt(ReportUser, masterKey));
            Console.WriteLine(TripleDESSecurity.Decrypt(ReportPassword, masterKey));
            Console.WriteLine(TripleDESSecurity.Decrypt(ReportDomain, masterKey));
            Console.WriteLine(TripleDESSecurity.Decrypt(SettingsLocation, masterKey));
            Console.WriteLine(TripleDESSecurity.Decrypt(SettingsElementsPerPage, masterKey));
            Console.WriteLine(TripleDESSecurity.Decrypt(DeviceFingerPrint, masterKey));
            Console.WriteLine(TripleDESSecurity.Decrypt(DeviceCamera, masterKey));
            Console.WriteLine(TripleDESSecurity.Decrypt(DeviceESign, masterKey));
            Console.WriteLine(TripleDESSecurity.Decrypt(DeviceESignBool, masterKey));
            Console.Read();
            #endregion
        }
    }
}
