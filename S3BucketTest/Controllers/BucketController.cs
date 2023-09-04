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
        private static readonly string awsSecretAccessKey = "QCwp+9c197jq0JLJQiB2nQcjie5fxnMttroV0HLA";
        private static readonly string awsAccessKeyId = "AKIA3RXTBGWJ4YXIWFNT";
        private static readonly string bucket = "lcatestbucket";
        //private static readonly string folder = "";

        [HttpGet]
        public async Task<ActionResult<int>> Get()
        {
            var client = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, RegionEndpoint.USEast2);

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
