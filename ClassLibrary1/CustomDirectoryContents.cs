using Microsoft.Extensions.FileProviders;
using System.Collections;

namespace ClassLibrary1
{
    public class CustomDirectoryContents : IDirectoryContents
    {

        public bool Exists => true;


        public IEnumerator<IFileInfo> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}