using System;

namespace BsaHw1.Menus
{
  public class MenuItem
  {
    public MenuItem(string title, Func<bool> action)
    {
      Title = title;
      Action = action;
    }

    public string Title { get; }
    public Func<bool> Action { get; }
  }
}