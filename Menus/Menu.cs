using System;
using System.Collections.Generic;
using BsaHw1.Services;

namespace BsaHw1.Menus
{
  public interface IMenu
  {
    void Show();
    bool Handle(int option);
  }

  public class Menu : IMenu
  {
    private IList<MenuItem> _menuItems;
    private IBlogService _service;

    public Menu(IBlogService service)
    {
      this._service = service;
      Initialize();
    }

    private void Initialize()
    {
      _menuItems = new List<MenuItem> {
        new MenuItem("First query", ShowPostComments),
        new MenuItem("Second query", ShowCommentsLess50Length),
        new MenuItem("Third query", ShowCompletedToDos),
        new MenuItem("Forth query", ShowSortedUsersWithSortedToDos),
        new MenuItem("Fifth query", ShowUserStatistics),
        new MenuItem("Sixth query", ShowPostStatistics)
      };
    }

    public void Show()
    {
      for (var i = 0; i < _menuItems?.Count; ++i)
      {
        Console.WriteLine($"{i + 1}. {_menuItems[i].Title}");
      }
      Console.Write("> ");
    }

    public bool Handle(int option)
    {
      if (_menuItems.Count < option || option < 1)
      {
        return false;
      }

      return _menuItems[option - 1].Action.Invoke();
    }

    private int ReadNumber()
    {
      string input = Console.ReadLine();
      int numb;
      if (!int.TryParse(input, out numb))
      {
        throw new ArgumentException("Invalid user id");
      }

      return numb;
    }

    private bool ShowPostComments()
    {
      Console.Write("Enter user id: ");
      int userId = ReadNumber();

      var data = _service.GetCommentsCount(userId);
      if (data == null)
        return false;

      Console.WriteLine("User posts with comments count:");
      foreach (var item in data)
      {
        Console.WriteLine($"{item.Item1.Id} | {item.Item1.Title} | Total comments: {item.Item2}");
      }

      Console.ReadKey(false);
      return true;
    }

    private bool ShowCommentsLess50Length()
    {
      Console.Write("Enter user id: ");
      int userId = ReadNumber();

      var data = _service.GetCommentsLessThan50Length(userId);
      if (data == null)
        return false;

      Console.WriteLine("Comments less than 50:");
      foreach (var item in data)
      {
        Console.WriteLine($"{item}");
      }

      Console.ReadKey(false);
      return true;
    }

    private bool ShowCompletedToDos()
    {
      Console.Write("Enter user id: ");
      int userId = ReadNumber();

      var data = _service.GetCompletedToDos(userId);
      if (data == null)
        return false;

      Console.WriteLine("User Completed ToDos:");
      foreach (var item in data)
      {
        Console.WriteLine($"{item.Item1} | {item.Item2}");
      }

      Console.ReadKey(false);
      return true;
    }

    private bool ShowSortedUsersWithSortedToDos()
    {
      var data = _service.GetUsersSorted();

      Console.WriteLine("Users and theirs todos:");
      foreach (var item in data)
      {
        Console.WriteLine($"> {item.Id} | {item.Name} | {item.Email}");
        foreach (var todo in item.ToDos)
        {
          Console.WriteLine($">>>> {todo.Id} | {todo.Name}");
        }
        Console.WriteLine();
      }

      Console.ReadKey(false);
      return true;
    }

    private bool ShowUserStatistics()
    {
      Console.Write("Enter user id: ");
      int userId = ReadNumber();

      var data = _service.GetUserStats(userId);
      if (data == null)
        return false;

      Console.WriteLine($"Id: {data.Id}");
      Console.WriteLine($"Name: {data.Name}");
      Console.WriteLine($"Email: {data.Email}");
      Console.WriteLine($"Last Post: {data.LastPost.Id} | {data.LastPost.Title}");
      Console.WriteLine($"Last Post Comments: {data.LastPostCommentsCount}");
      Console.WriteLine($"Incompleted Tasks: {data.IncompletedTasksCount}");
      Console.WriteLine($"Post With Most Comments With Length 80: {data.TheMostCommentsPost.Id} | {data.TheMostCommentsPost.Title}");
      Console.WriteLine($"The Most Liked Post: {data.PopularPost.Id} | {data.PopularPost.Title}");

      Console.ReadKey(false);
      return true;
    }

    private bool ShowPostStatistics()
    {
      Console.Write("Enter post id: ");
      int postId = ReadNumber();

      var data = _service.GetPostStats(postId);
      if (data == null)
        return false;

      Console.WriteLine($"Id: {data.Id}");
      Console.WriteLine($"Title: {data.Title}");
      Console.WriteLine($"The Longest Comment: {data.TheLongestComment.Id} | {data.TheLongestComment.Body}");
      Console.WriteLine($"The Most Liked Comment: {data.PopularComment.Id} | {data.PopularComment.Body}");
      Console.WriteLine($"Comments With 0 Likes Or Length < 80: {data.ShortOrNotPopularComments}");

      Console.ReadKey(false);
      return true;
    }
  }
}