/*
{
"id": "1",
"country": "Trinidad and Tobago",
"city": "Aishafurt",
"street": "58481 Marvin Ville",
"zip": "08648-9944",
"userId": 1
}
*/

using System;

namespace BsaHw1.Models
{
  public class Address
  {
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Zip { get; set; }
    public int UserId { get; set; }
  }
}