using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace HW_5._1_Networking
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            RequestsAsync().GetAwaiter().GetResult();
        }

        public static async Task RequestsAsync()
        {
            //GET list users
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://reqres.in/api/users?page=2");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseInJson = response.Content.ReadAsStringAsync();
                }
            }

            //GET single user
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://reqres.in/api/users/2");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseInJson = response.Content.ReadAsStringAsync();
                }
            }

            //GET single user not found
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://reqres.in/api/users/23");
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine("404 Not Found");
                }
            }

            //GET list <resource>
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://reqres.in/api/unknown");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseInJson = response.Content.ReadAsStringAsync();
                }
            }

            //GET single <resource>
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://reqres.in/api/unknown2");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseInJson = response.Content.ReadAsStringAsync();
                }
            }

            //GET single <resource> not found
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://reqres.in/api/unknown/23");

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine("404 Not Found");
                }
            }

            //POST create
            using (var httpClient = new HttpClient())
            {
                var user = new
                {
                    name = "morpheus",
                    job = "leader"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync("https://reqres.in/api/users", httpContent);

                if (result.StatusCode == HttpStatusCode.Created)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            //PUT update
            using (var httpClient = new HttpClient())
            {
                var user = new
                {
                    name = "morpheus",
                    job = "zion resident"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var result = await httpClient.PutAsync("https://reqres.in/api/users/2", httpContent);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            //PATCH update
            using (var httpClient = new HttpClient())
            {
                var user = new
                {
                    name = "morpheus",
                    job = "zion resident"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var result = await httpClient.PatchAsync("https://reqres.in/api/users/2", httpContent);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            //DELETE delete
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync("https://reqres.in/api/users/2");
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    Console.WriteLine("204 No Content");
                }
            }

            //POST register - successful
            using (var httpClient = new HttpClient())
            {
                var payload = new
                {
                    email = "eve.holt@reqres.in",
                    password = "pistol"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync("https://reqres.in/api/register", httpContent);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            //POST register - unsuccessful
            using (var httpClient = new HttpClient())
            {
                var payload = new
                {
                    email = "sydney@fife"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync("https://reqres.in/api/register", httpContent);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("400 Bad Reques");
                }
            }

            //POST login - successful
            using (var httpClient = new HttpClient())
            {
                var payload = new
                {
                    email = "eve.holt@reqres.in",
                    password = "cityslicka"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync("https://reqres.in/api/login", httpContent);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            //POST login - unsuccessful
            using (var httpClient = new HttpClient())
            {
                var payload = new
                {
                    email = "peter@klaven"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync("https://reqres.in/api/login", httpContent);

                if (result.StatusCode == HttpStatusCode.BadRequest)
                {
                    Console.WriteLine("400 Bad Reques");
                }
            }

            //GET delayed response
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://reqres.in/api/users?delay=3");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseInJson = response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}