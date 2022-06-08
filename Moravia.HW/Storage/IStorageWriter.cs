using Moravia.HW.File;

namespace Moravia.HW.Storage
{
    public interface IStorageWriter
    {
        public void Write(string path, IFile file);
    }
}
