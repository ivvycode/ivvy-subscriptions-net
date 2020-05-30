using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Parameters;

namespace Ivvy.Subscriptions
{
    /// <summary>
    /// This class contains some utility functions.
    /// </summary>
    public sealed class Utils
    {
        /// <summary>
        /// Makes a http GET request and returns the response.
        /// <param name="url">The url to request.</param>
        /// <param name="numRetries">The number of retries on error.</param>
        /// </summary>
        public static async Task<string> MakeGetRequest(string url, int numRetries = 4)
        {
            for (var retries = 1; retries <= numRetries; retries++)
            {
                try
                {
                    var req = HttpWebRequest.Create(url) as HttpWebRequest;
                    var res = await req.GetResponseAsync() as HttpWebResponse;
                    var reader = new StreamReader(res.GetResponseStream());
                    var response = await reader.ReadToEndAsync();
                    reader.Close();
                    res.Close();
                    reader.Dispose();
                    res.Dispose();
                    return response.Trim();
                }
                catch (Exception ex)
                {
                    if (retries == numRetries)
                    {
                        throw ex;
                    }
                    await Task.Delay(1000);
                }
            }
            throw new Exception($"Failed to make GET request to {url}");
        }
    }
}