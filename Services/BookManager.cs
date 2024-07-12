﻿using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        public BookManager(IRepositoryManager manager, ILoggerService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        public Book CreateOneBook(Book book)
        {
            
            _manager.Book.CreateOneBook(book);
            _manager.Save();
            return book;
        }

        public void DeleteOneBook(int id, bool trackChanges)
        {//check entity
            var book = _manager.Book.GetOneBookById(id, trackChanges);
            if (book == null)
            {
                string msg = $"Book with id :{id} could not found..";
                _logger.LogInfo(msg);
                throw new Exception(msg);
            }
            _manager.Book.DeleteOneBook(book);
            _manager.Save();
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            return _manager.Book.GetAllBooks(trackChanges);
        }

        public Book GetOneBookById(int id, bool trackChanges)
        {
           return _manager.Book.GetOneBookById(id, trackChanges);
        }

        public void UpdateOneBook(int id, Book book, bool trackChanges)
        {
            //Check entity
            var entity = _manager.Book.GetOneBookById(id, true);
            if (entity == null)
            {
                string msg = $"Book with id :{id} could not found..";
                _logger.LogInfo(msg);
                throw new Exception(msg);
            }
            //Check param
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            entity.Title = book.Title;
            entity.Price = book.Price;
            _manager.Book.UpdateOneBook(entity);
            _manager.Save();



        }
    }
}
