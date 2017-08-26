using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CaptainCharisma.Models
{
    public class Project
    {

        public static List<GitHubRepo> GetProject()
        {
            var client = new RestClient("https://api.github.com/");
            var request = new RestRequest("search/repositories?q=user:guyanderson&sort=stars&order=desc", Method.GET);
            client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.AccountSid, EnvironmentVariables.AuthToken);
            request.AddHeader("User-Agent", EnvironmentVariables.AccountSid);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            List<GitHubRepo> repoList = new List<GitHubRepo> { };
            for (var i = 0; i < 3; i++)
            {
                GitHubRepo repo = JsonConvert.DeserializeObject<GitHubRepo>(jsonResponse["items"][i].ToString());
                {
                    repoList.Add(repo);
                }
            }
            return repoList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
