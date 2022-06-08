using Moravia.HW.File;
using System.IO;

namespace Moravia.HW.Storage
{
    public class FileStorage : IStorageWriter, IStorageReader
    {
        public void Read(string path, IFile file)
        {
            using (var fs = new FileStream(path, FileMode.Open))
            {
                file.ReadFile(fs);
            }
        }

        public void Write(string path, IFile file)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                file.WriteFile(fs);
            }
        }
    }
}
