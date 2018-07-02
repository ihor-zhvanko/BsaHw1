using System;
using Newtonsoft.Json;

namespace BsaHw1.Models
{
  public class User
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Title { get; set; }
    [JsonProperty("avatar")]
    public string AvatarUrl { get; set; }
    public string Email { get; set; }
  }
}