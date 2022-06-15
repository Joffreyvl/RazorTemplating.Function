using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace ClassLibrary1
{
    public class CustomFileProvider : IFileProvider
    {

        private IFileInfo file;

        public CustomFileProvider()
        {

        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            return new CustomDirectoryContents();
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            if (subpath.Contains("helloworld"))
            {
                var fileStream = File.OpenRead("helloworld.cshtml");
                file = new CustomFileInfo("helloworld.cshtml", DateTimeOffset.Now, fileStream);
                return file;
            }

            return new NotFoundFileInfo(subpath);
        }

        public IChangeToken Watch(string filter)
        {
            return NullChangeToken.Singleton;
        }
    }
}