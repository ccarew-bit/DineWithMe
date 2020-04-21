

using System.Text.Json.Serialization;

namespace DineWithMe.Models
{
  public class User
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public string PhoneNumber { get; set; }
    [JsonIgnore]
    public string HashedPassword { get; set; }
  }
}