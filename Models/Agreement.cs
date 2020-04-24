namespace DineWithMe.Models
{
  public class Agreement
  {
    public int Id { get; set; }

    public int RequestorId { get; set; }

    public User Requestor { get; set; }

    public int FriendId { get; set; }

    public User Friend { get; set; }
    public int RestaurantId { get; set; }

    public Restaurant Restaurant { get; set; }

  }
}