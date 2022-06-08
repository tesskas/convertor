
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace Moravia.HW.File
{
    public class XMLFile : AbstractFile
    {
        XDocument xDoc;

        public XMLFile() : base()
        {

        }
        public XMLFile(JObject obj) : base(obj)
        {
            xDoc = JsonConvert.DeserializeXNode(obj.ToString());
        }

        public XMLFile(string content) : base(content)
        {
        }

        protected override JObject ParseToJObject(string textContent)
        {
            xDoc = XDocument.Parse(textContent);
            string json = JsonConvert.SerializeXNode(xDoc);
            return JObject.Parse(json);
        }

        public override string ToString()
        {
            return xDoc.ToString();
        }

        public string ToString(SaveOptions options)
        {
            return xDoc.ToString(options);
        }
    }
}
