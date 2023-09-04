using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace S3BucketTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BucketController : ControllerBase
    {
        private static readonly string awsSecretAccessKey = "";
        private static readonly string awsAccessKeyId = "";
        private static readonly string bucket = "lcatestbucket";
        //private static readonly string folder = "";

        [HttpGet]
        public async Task<ActionResult<int>> Get()
        {
            var client = new AmazonS3Client();

            ListObjectsRequest request = new ListObjectsRequest();
            request.BucketName = bucket;
            //request.Prefix = folder;
            ListObjectsResponse response = await client.ListObjectsAsync(request);

            int counter = 0;

            foreach (S3Object o in response.S3Objects)
            {
                counter++;
            }

            return 10;
        }
    }
}
