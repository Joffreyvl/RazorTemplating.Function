using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System.Text;

namespace ClassLibrary1
{
    public class CustomFileProvider : IFileProvider
    {
        private readonly IEnumerable<string> pathsToIgnore = new[] { "/_ViewImports.cshtml", "/_ViewStart.cshtml" };

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            return NotFoundDirectoryContents.Singleton;
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            if (pathsToIgnore.Contains(subpath))
                return new NotFoundFileInfo(Path.GetFileNameWithoutExtension(subpath));

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("<h1>Hello world, @ViewBag.Name!</h1>"));
            var file = new CustomFileInfo(Path.GetFileNameWithoutExtension(subpath), DateTimeOffset.Now, stream);

            return file;
        }

        public IChangeToken Watch(string filter)
        {
            return NullChangeToken.Singleton;
        }
    }
}