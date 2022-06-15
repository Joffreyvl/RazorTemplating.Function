using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace ClassLibrary1
{
    public class CustomFileProvider : IFileProvider
    {

        private IFileInfo file;

        public CustomFileProvider()
        {
            var fileStream = File.OpenRead("helloworld.cshtml");
            file = new CustomFileInfo("helloworld.cshtml", DateTimeOffset.Now, fileStream);
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            return new CustomDirectoryContents();
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            return file;
        }

        public IChangeToken Watch(string filter)
        {
            return NullChangeToken.Singleton;
        }
    }
}