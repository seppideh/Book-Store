using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Validations
{
  public class BanKeywordAttribute : ValidationAttribute
  {
    public List<string> BanKeywords { get; set; }

    public BanKeywordAttribute()
    {
      BanKeywords = new List<string>()
      {
        "shit"
      };
    }

    public override string FormatErrorMessage(string name)
    {
      return "لطفا از کلمات ممنوعه در عنوان استفاده نکنيد";
    }

    public override bool IsValid(object value)
    {
      var title = (string)value;
      if (BanKeywords.Contains(title.ToLower())) return false;
      return true;
    }


  }
}