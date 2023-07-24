using System;
using System.IO;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace queueex1
{
    public class Bindout
    {
        [FunctionName("bindout")]
        public void Run([QueueTrigger("myqueueitems", Connection = "AzureWebJobsStorage")] string myQueueName,
            [Blob("dev/A.txt", FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream s, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed when the {myQueueName} message given");
            s.Write(Encoding.ASCII.GetBytes(myQueueName));
        }
    }
}
