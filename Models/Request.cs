using System;

namespace DineWithMe.Models
{
  public class Request
  {
    public int Id { get; set; }
    public string Description { get; set; }

    public int RequestorId { get; set; }

    public User Requestor { get; set; }

    public int FriendId { get; set; }

    public User Friend { get; set; }

    public DateTime Time { get; set; }

    public bool IsRequestAccepted { get; set; } = false;

  }
}