using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace DemoLinqXaml
{
    public class Load
    {
        public static void LoadXmlPurchaseOrder1()
        {
            // Load the XML file from our project directory containing the purchase orders
            var filename = "PurchaseOrder.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var purchaseOrderFilepath = Path.Combine(currentDirectory, filename);

            XElement purchaseOrder = XElement.Load(purchaseOrderFilepath);

            IEnumerable<string> partNos = from item in purchaseOrder.Descendants("Item")
                                          select (string)item.Attribute("PartNumber");
            foreach (var element in partNos)
            {
                Console.WriteLine(element);
            }
            Console.Read();
        }

        public static void LoadXmlPurchaseOrder2()
        {
            // Load the XML file from our project directory containing the purchase orders
            var filename = "PurchaseOrder.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var purchaseOrderFilepath = Path.Combine(currentDirectory, filename);

            XElement purchaseOrder = XElement.Load(purchaseOrderFilepath);

            IEnumerable<string> partNos = purchaseOrder.Descendants("Item").Select(x => (string)x.Attribute("PartNumber"));
            foreach (var element in partNos)
            {
                Console.WriteLine(element);
            }
            Console.Read();
        }

        public static void LoadXmlPricesByPartNos1()
        {
            // Load the XML file from our project directory containing the purchase orders
            var filename = "PurchaseOrder.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var purchaseOrderFilepath = Path.Combine(currentDirectory, filename);

            XElement purchaseOrder = XElement.Load(purchaseOrderFilepath);

            IEnumerable<XElement> pricesByPartNos = from item in purchaseOrder.Descendants("Item")
                                                    where (int)item.Element("Quantity") * (decimal)item.Element("USPrice") > 100
                                                    orderby (string)item.Element("PartNumber")
                                                    select item;
            foreach (var element in pricesByPartNos)
            {
                Console.WriteLine(element);
            }
            Console.Read();
        }


        public static void LoadXmlPricesByPartNos2()
        {
            // Load the XML file from our project directory containing the purchase orders
            var filename = "PurchaseOrder.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var purchaseOrderFilepath = Path.Combine(currentDirectory, filename);

            XElement purchaseOrder = XElement.Load(purchaseOrderFilepath);

            IEnumerable<XElement> pricesByPartNos = purchaseOrder.Descendants("Item")
                                        .Where(item => (int)item.Element("Quantity") * (decimal)item.Element("USPrice") > 100)
                                        .OrderBy(order => order.Element("PartNumber"));

            foreach (var element in pricesByPartNos)
            {
                Console.WriteLine(element);
            }
            Console.Read();
        }
}
}
