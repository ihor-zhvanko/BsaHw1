using System;
using Newtonsoft.Json;

namespace BsaHw1.Models
{
  public class ToDo
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; }
    public bool IsComplete { get; set; }
    public int UserId { get; set; }
  }
}


/*

{
"id": "1",
"createdAt": "2018-05-27T08:52:12.130Z",
"name": "Handmade Metal Towels",
"isComplete": false,
"userId": 5
}

*/
