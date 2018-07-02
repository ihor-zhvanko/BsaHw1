using System;
using System.Linq;
using System.Threading.Tasks;
using BsaHw1.Connectors;
using Newtonsoft.Json;

namespace BsaHw1
{
  class Program
  {
    static void Main(string[] args)
    {
      AsyncMain(args).Wait();
    }

    static async Task AsyncMain(string[] args)
    {
      Console.WriteLine("Go");
      var connector = new BlogConnector();

      var usersTask = connector.GetUsers();
      var postsTask = connector.GetPosts();
      var commentsTask = connector.GetComments();
      var todosTask = connector.GetToDos();
      var addressesTask = connector.GetAddresses();

      var users = await usersTask;
      var posts = await postsTask;
      var comments = await commentsTask;
      var todos = await todosTask;
      var addresses = await addressesTask;

      Console.WriteLine(JsonConvert.SerializeObject(users.First()));
      Console.WriteLine(JsonConvert.SerializeObject(posts.First()));
      Console.WriteLine(JsonConvert.SerializeObject(comments.First()));
      Console.WriteLine(JsonConvert.SerializeObject(todos.First()));
      Console.WriteLine(JsonConvert.SerializeObject(addresses.First()));

      //   var postComment = from p in posts
      //                     join c in comments on p.Id equals c.PostId into comms
      //                     select (Post: p, Comments: comms);

      //   var dataStructure = from u in users
      //                       join pc in postComment on u.Id equals pc.Post.UserId into pots
      //                       select (User: u, Posts: pots);



      //   foreach (var item in dataStructure)
      //   {
      //     Console.WriteLine($"{item.User.Id} | {item.Posts.FirstOrDefault()} | {((dynamic)item.Posts.FirstOrDefault())?.Comments.FirstOrDefault()}");
      //   }
    }
  }
}


