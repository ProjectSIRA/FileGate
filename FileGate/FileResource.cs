using Grapevine;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileGate
{
    [RestResource]
    internal class FileResource
    {
        private readonly string _gateCode = Environment.GetEnvironmentVariable("FILEGATE_CODE")!;
        private readonly DirectoryInfo _directory = new(Path.Combine(Directory.GetCurrentDirectory(), "files"));

        [RestRoute("Get", "/gate")]
        public async Task Gate(IHttpContext context)
        {
            if (!context.Request.QueryString.HasKeys() || context.Request.QueryString["code"] == null || context.Request.QueryString["code"] != _gateCode || context.Request.QueryString["id"] == null)
            {
                await context.Response.SendResponseAsync(HttpStatusCode.BadRequest);
                return;
            }

            string code = context.Request.QueryString["code"]!;
            string id = context.Request.QueryString["id"]!;

            if (!_directory.Exists)
                _directory.Create();

            FileInfo? file = _directory.GetFiles().FirstOrDefault(f => f.Name.StartsWith(id));
            if (file is null)
            {
                await context.Response.SendResponseAsync(HttpStatusCode.NotFound);
                return;
            }

            using Stream fileStream = file.OpenRead();
            await context.Response.SendResponseAsync(fileStream, file.Name);
        }
    }
}