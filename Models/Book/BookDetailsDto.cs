using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Models
{
  public class BookDetailsDto
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }
  }
}