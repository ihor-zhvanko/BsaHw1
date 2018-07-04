using System;
using System.Linq;
using System.Threading.Tasks;
using BsaHw1.Connectors;
using BsaHw1.Models;
using BsaHw1.Services;
using BsaHw1.Menus;
using Newtonsoft.Json;

namespace BsaHw1
{
  class Program
  {
    static void Main(string[] args)
    {
      var connector = new BlogConnector();
      var service = new BlogService(connector);
      var menu = new Menu(service);
      while (true)
      {
        menu.Show();
        var input = Console.ReadLine();
        int option;
        if (!int.TryParse(input, out option))
        {
          Console.WriteLine("Try again . . .");
          Console.ReadKey();
          continue;
        }

        var wasHandled = menu.Handle(option);

        if (!wasHandled)
        {
          Console.WriteLine("Invalid input or something went wrong. Shutting down . . .");
          Console.ReadKey();
          break;
        }
        Console.Clear();
      }
    }
  }
}


