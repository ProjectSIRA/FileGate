using Grapevine;
using System.Threading.Tasks;

namespace FileGate
{
    [RestResource]
    internal class FileResource
    {
        private readonly string _gateCode = "";

        [RestRoute("Get", "/gate")]
        public async Task Gate(IHttpContext context)
        {
            _ = _gateCode;
            await context.Response.SendResponseAsync("Success");
        }
    }
}