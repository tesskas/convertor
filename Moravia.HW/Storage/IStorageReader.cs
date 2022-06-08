using Moravia.HW.File;

namespace Moravia.HW.Storage
{
    public interface IStorageReader
    {
        public void Read(string path, IFile file);
    }
}
