using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BsaHw1.Models
{
  /*public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public int UserId { get; set; }
    public int Likes { get; set; }
    public IList<Comment> Comments { get; set; } */

  public class PostStats : Post
  {
    public PostStats(Post post) {
      Id = post.Id;
      CreatedAt = post.CreatedAt;
      Title = post.Title;
      Body = post.Body;
      UserId = post.UserId;
      Likes = post.Likes;
    }
    public Comment TheLongestComment {get;set;}
    public Comment PopularComment {get;set;}
    public int ShortOrNotPopularComment {get;set;}
  }
}