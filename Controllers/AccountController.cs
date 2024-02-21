using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApi.Models;
using MyWebApi.Models.Account;
using MyWebApi.Repository;

namespace MyWebApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AccountController : Controller
  {
    private readonly IAccountRepository _accountRepository;

    public AccountController(IAccountRepository accountRepository)
    {
      _accountRepository = accountRepository;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] SignUpDTO signUpDTO)
    {
      var result = await _accountRepository.SignUp(signUpDTO);
      if (result.Succeeded)
      {
        return Ok();
      }
      return BadRequest(result.Errors.Select(x => x.Description));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
      var result = await _accountRepository.Login(loginDto);
      if (string.IsNullOrEmpty(result))
      {
        return Unauthorized();
      }
      return Ok(result);
    }

  }
}