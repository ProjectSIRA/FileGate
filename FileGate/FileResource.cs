using Grapevine;
using System;
using System.Threading.Tasks;

namespace FileGate
{
    [RestResource]
    internal class FileResource
    {
        private readonly string _gateCode = Environment.GetEnvironmentVariable("FILEGATE_CODE");

        [RestRoute("Get", "/gate")]
        public async Task Gate(IHttpContext context)
        {
            if (!context.Request.QueryString.HasKeys() || context.Request.QueryString["code"] == null || context.Request.QueryString["code"] != _gateCode || context.Request.QueryString["id"] == null)
            {
                await context.Response.SendResponseAsync(HttpStatusCode.BadRequest);
                return;
            }

            string code = context.Request.QueryString["code"];
            string id = context.Request.QueryString["id"];

            await context.Response.SendResponseAsync(code + " - " + id);
        }
    }
}