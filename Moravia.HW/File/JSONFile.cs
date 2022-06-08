
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Moravia.HW.File
{
    public class JSONFile : AbstractFile
    {
        public JSONFile() : base()
        {
        }

        public JSONFile(JObject obj) : base(obj)
        {
            _objectContent = obj;
        }

        public JSONFile(string content) : base(content)
        {
        }

        protected override JObject ParseToJObject(string textContent)
        {
            return JObject.Parse(textContent);
        }

        public override string ToString()
        {
            return _objectContent.ToString();
        }

        public string ToString(Formatting formatting)
        {
            return ObjectContent.ToString(formatting);
        }
    }
}
