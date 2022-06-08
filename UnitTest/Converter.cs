using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moravia.HW.File;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace UnitTest
{
    [TestClass]
    public class Converter
    {
        string json = "{\"document\":{\"title\":\"Title\",\"text\":\"Hello world...\"}}";
        string xml = "<document><title>Title</title><text>Hello world...</text></document>";

        [TestMethod]
        public void CreateXML()
        {
            string xmlContent = xml;
            XMLFile document = new XMLFile(xmlContent);
            string newContent = document.ToString(SaveOptions.DisableFormatting);
            Assert.AreEqual(xmlContent, newContent, "Loading xml file is successful");
        }

        [TestMethod]
        public void CreateJSON()
        {
            string jsonContent = json;
            JSONFile document = new JSONFile(jsonContent);
            string newContent = document.ToString(Formatting.None);
            Assert.AreEqual(jsonContent, newContent, "Loading json file is successful");
        }

        [TestMethod]
        public void XMLtoJSON()
        {
            string xmlContent = xml;
            string expected = json;
            IFile document = new XMLFile(xmlContent);
            JSONFile jsonFile = new JSONFile(document.ObjectContent);
            string jsonContent = jsonFile.ToString(Formatting.None);
            Assert.AreEqual(expected, jsonContent,"Conversion xml to json file is successful");
        }

        [TestMethod]
        public void JSONtoXML()
        {
            string jsonContent = json;
            string expected = xml;
            IFile document = new JSONFile(jsonContent);
            XMLFile xmlFile = new XMLFile(document.ObjectContent);
            string xmlContent = xmlFile.ToString(SaveOptions.DisableFormatting);
            Assert.AreEqual(expected, xmlContent, "Conversion json to xml file is successful");
        }
    }
}
