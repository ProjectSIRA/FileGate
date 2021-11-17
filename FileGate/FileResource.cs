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
            if (!context.Request.QueryString.HasKeys() || context.Request.QueryString["code"] == null)
            {
                await context.Response.SendResponseAsync(HttpStatusCode.BadRequest);
                return;
            }

            _ = _gateCode;
            string code = context.Request.QueryString["code"];
            await context.Response.SendResponseAsync(code);
        }
    }
}