using System;
using System.Linq;
using System.Threading.Tasks;
using BsaHw1.Connectors;
using BsaHw1.Models;
using BsaHw1.Services;
using Newtonsoft.Json;

namespace BsaHw1
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        AsyncMain(args).Wait();
      } catch(Exception e) {
        Console.WriteLine($"Error: {e.InnerException?.InnerException?.Message}");
      }
    }

    static async Task AsyncMain(string[] args)
    {
      Console.WriteLine("Go");
      var connector = new BlogConnector();
      var service = new BlogService(connector);

      var users = service.GetUsersSorted();

      foreach (var user in users)
      {
          Console.WriteLine(JsonConvert.SerializeObject(user));
          foreach (var todo in user.ToDos)
          {
              Console.WriteLine($">>> {JsonConvert.SerializeObject(todo)}");
          }
          Console.WriteLine();
      }

      Console.WriteLine("Done.");
    }
  }
}


