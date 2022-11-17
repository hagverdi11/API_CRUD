using DomainLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Book;
using ServiceLayer.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace API_Intro.Controllers
{
   
    public class BookController : AppController
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
          _bookService= bookService;
        }
        [HttpPost]
        public async Task <IActionResult> Create([FromBody] BookCreateDbo book)
        {
            await _bookService.CreateAsync(book);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _bookService.GetAllAsync()); 
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([Required] int id)
        {
            try
            {
                await _bookService.DeleteAsync(id);
                return Ok();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

        }

    }
}
