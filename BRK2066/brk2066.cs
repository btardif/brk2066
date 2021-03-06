using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace BRK2066
{
    public static class brk2066
    {
        [FunctionName("brk2066")]
        public static async Task<HttpResponseMessage>Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            // parse query parameter
            string name = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                .Value;

            string happy = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "happy", true) == 0)
                .Value;

            if (name == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body");
            }
            else if( happy == null)
            {
                return req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
            }
            else
            {
                return req.CreateResponse(HttpStatusCode.OK, name + "was this happy: " + happy);
            }
 
        }
    }
}
