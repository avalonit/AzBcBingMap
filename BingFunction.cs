using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


namespace com.businesscentral
{
    public static class BingFunction
    {
        [FunctionName("BingFunction")]
        public static async Task<HttpResponseMessage> Run(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
           HttpRequestMessage req,
           ILogger log,
           ExecutionContext context)
        {
            // Load configuration
            var config = new ConfigurationBuilder()
                .SetBasePath(context.FunctionAppDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            // Business Central is queried
            var bcConfig = new ConnectorConfig(config);

            // Outcoming whatsapp message is composed
            var composer = new BingMapComposer();
            var replyText = composer.Compose(bcConfig);

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(replyText);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;

        }



    }
}
