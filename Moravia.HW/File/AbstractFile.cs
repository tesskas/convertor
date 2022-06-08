using Newtonsoft.Json.Linq;
using System.IO;

namespace Moravia.HW.File
{
    public abstract class AbstractFile : IFile
    {
        protected JObject _objectContent;

        public JObject ObjectContent { get { return _objectContent; } }

        public AbstractFile()
        {
        }
        public AbstractFile(JObject obj)
        {
            _objectContent = obj;
        }

        public AbstractFile(string content)
        {
            _objectContent = ParseToJObject(content);
        }

        protected abstract JObject ParseToJObject(string textContent);
        public void ReadFile(Stream stream)
        {
            string content = "";
            using (var reader = new StreamReader(stream))
            {
                content = reader.ReadToEnd();
            }
            _objectContent = ParseToJObject(content);
        }
        public void WriteFile(Stream stream)
        {
            using (var sw = new StreamWriter(stream))
            {
                sw.Write(ToString());
            }
        }
    }
}
