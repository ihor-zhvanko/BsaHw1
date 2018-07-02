using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BsaHw1.Models;
using Newtonsoft.Json;

namespace BsaHw1.Connectors
{
  public class BlogConnector
  {
    private const string BASE_URL = "https://5b128555d50a5c0014ef1204.mockapi.io/";

    public async Task<IList<User>> GetUsers()
    {
      return await Get<IList<User>>("users");
    }

    public async Task<IList<Post>> GetPosts()
    {
      return await Get<IList<Post>>("posts");
    }

    public async Task<IList<Comment>> GetComments()
    {
      return await Get<IList<Comment>>("comments");
    }

    public async Task<IList<ToDo>> GetToDos()
    {
      return await Get<IList<ToDo>>("todos");
    }

    public async Task<IList<Address>> GetAddresses()
    {
      return await Get<IList<Address>>("address");
    }

    private async Task<T> Get<T>(string url)
    {
      var client = new HttpClient();
      client.BaseAddress = new Uri(BASE_URL);
      var data = await client.GetStringAsync(url);

      return JsonConvert.DeserializeObject<T>(data);
    }
  }
}
