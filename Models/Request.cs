using System;
using System.Collections.Generic;

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

    public bool IsRequestDenied { get; set; } = false;

    public List<Agreement> Agreements { get; set; }

  }
}