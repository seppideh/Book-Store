using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApi.Models;
using MyWebApi.Repository;

namespace MyWebApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Authorize]
  public class BooksController : ControllerBase
  {
    private readonly IBookRepository _booksRepository;
    private readonly ILogger<BooksController> _logger;

    public BooksController(
      IBookRepository BooksRepository,
      ILogger<BooksController> logger)
    {
      _booksRepository = BooksRepository;
      _logger = logger;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllBooks()
    {
      var books = await _booksRepository.GetAllBooks();
      return Ok(books);
    }


    // route:/api/Books/{id}-->restful-->[HttpGet("{id}")]
    // route:/api/Books/detail?id={id}-->query string parameter-->[HttpGet("detail")]
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetBookDetailsById(int id)
    {
      var book = await _booksRepository.GetBookDetailsById(id);
      if (book == null)
      {
        return NotFound();
      }
      return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookDto model)
    {
      var id = await _booksRepository.CreateBook(model);
      return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDto model, int id)
    {
      var result = await _booksRepository.UpdateBook(id, model);
      if (!result)
      {
        return BadRequest("This book is not exist");
      }
      return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveBook(int id)
    {
      var result = await _booksRepository.RemoveBook(id);
      if (!result)
      {
        return BadRequest("This book is not exist");
      }
      return Ok(result);
    }

  }
}
