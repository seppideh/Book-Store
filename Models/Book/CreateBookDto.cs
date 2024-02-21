using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MyWebApi.Validations;

namespace MyWebApi.Models
{
  public class CreateBookDto
  {
    [Required(ErrorMessage = "لطفا عنوان کتاب را وارد کنيد")]
    [MaxLength(50)]
    [BanKeyword]
    public string Title { get; set; }

    [MaxLength(200, ErrorMessage = "طول توضيحات بيشتر از 30 کارکتر نمي تواند باشد")]
    public string Description { get; set; }

    [Range(1000, 5000000,ErrorMessage = "لطفا مبلغي بين 1000 تا پنج ميليون تومان وارد کنيد")]
    public int Amount { get; set; }
  }
}

// DataAnnotations
// [Url]
// [EmailAddress]
// [Phone]
// [CreditCard]
// [Compare]