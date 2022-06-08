
using Newtonsoft.Json.Linq;
using System.IO;

namespace Moravia.HW.File
{
    public interface IFile {

        public JObject ObjectContent { get; }

        public void ReadFile(Stream stream);
        public void WriteFile(Stream stream);

    }
}
