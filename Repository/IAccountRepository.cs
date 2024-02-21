using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyWebApi.Models;
using MyWebApi.Models.Account;

namespace MyWebApi.Repository
{
  public interface IAccountRepository
  {
    Task<IdentityResult> SignUp(SignUpDTO signUpDTO);
    Task<string> Login(LoginDto loginDto);
  }
}