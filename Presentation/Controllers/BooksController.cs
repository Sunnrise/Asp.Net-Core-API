﻿using Entities.DataTransferObject;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _manager.BookService.GetAllBooks(false);
            return Ok(books);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var book = _manager
            .BookService
            .GetOneBookById(id, false);

            
            return Ok(book);
        }


        [HttpPost]
        public IActionResult CreateOneBook([FromBody] BookDtoForInsertion bookDto)
        {
            if (bookDto is null)
                return BadRequest(); // 400 

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState); // 422

            var book= _manager.BookService.CreateOneBook(bookDto);


            return StatusCode(201, book);//CreatedAtRoute
        }


        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id,
            [FromBody] BookDtoForUpdate bookDto)
        {
            if (bookDto is null)
                return BadRequest(); // 400
                                     // check book?

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState); // 422


            _manager.BookService.UpdateOneBook(id, bookDto, false);

            return NoContent();//204
        }




        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        { 
            _manager.BookService.DeleteOneBook(id, false);
            return NoContent();
        }


        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<BookDto> bookPatch)
        {
            // check entity
            var bookDto = _manager
                .BookService
                .GetOneBookById(id, true);

            bookPatch.ApplyTo(bookDto);

            _manager.BookService.UpdateOneBook(
                id,
                new BookDtoForUpdate() { 
                    Id=bookDto.Id,
                    Price=bookDto.Price,
                    Title=bookDto.Title
                },
                true);
            return NoContent(); // 204
        }
    }
}
