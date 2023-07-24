using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
namespace Blobinputbinding
{
    public class Blobinput
    {
        [FunctionName("Blobinputbinding")]
        public void Run([QueueTrigger("myqueue-items", Connection = "AzureWebJobsStorage")] string myQueueItem,
            [Blob("dev/{queuetrigger}", FileAccess.Read, Connection = "AzureWebJobsStorage")] Stream s, ILogger log)
        {
            StreamReader reader = new StreamReader(s);
            log.LogInformation($"C# Queue trigger with blob binding triggered successfully name: {myQueueItem} \n size:{s.Length} \n content:{reader.ReadToEnd()}");
        }
    }
}