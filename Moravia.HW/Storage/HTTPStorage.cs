using Moravia.HW.File;
using System.Net;

namespace Moravia.HW.Storage
{
    public class HTTPStorage : IStorageReader
    {
        public void Read(string path, IFile file)
        {
            var request = WebRequest.Create(path);
            var response = request.GetResponse();
            file.ReadFile(response.GetResponseStream());
        }
    }
}
