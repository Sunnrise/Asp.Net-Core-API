using AutoMapper;
using Entities.DataTransferObject;
using Entities.Exceptions;
using Entities.Models;
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
        private readonly IMapper _mapper;
        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public BookDto CreateOneBook(BookDtoForInsertion bookDto)
        {
            var enttity = _mapper.Map<Book>(bookDto);
            _manager.Book.CreateOneBook(enttity);
            _manager.Save();
            return _mapper.Map<BookDto>(enttity);
        }

        public void DeleteOneBook(int id, bool trackChanges)
        {//check entity
            var book = _manager.Book.GetOneBookById(id, trackChanges);
            if (book == null)
                throw new BookNotFoundException(id); //404
            _manager.Book.DeleteOneBook(book);
            _manager.Save();
        }

        public IEnumerable<BookDto> GetAllBooks(bool trackChanges)
        {
            var books= _manager.Book.GetAllBooks(trackChanges);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public BookDto GetOneBookById(int id, bool trackChanges)
        {
            var book= _manager.Book.GetOneBookById(id, trackChanges);
            if (book is null)
                throw new BookNotFoundException(id); //404
            return _mapper.Map<BookDto>(book);
        }

        public void UpdateOneBook(int id,
            BookDtoForUpdate bookDto,
            bool trackChanges)
        {
            //Check entity
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if (entity == null)
                throw new BookNotFoundException(id); //404


            //entity.Title = book.Title;
            //entity.Price = book.Price;
            ////mapping
            entity = _mapper.Map<Book>(bookDto);

            _manager.Book.UpdateOneBook(entity);
            _manager.Save();



        }

        (BookDtoForUpdate bookDtoForUpdate, Book book) IBookService.GetOneBookForPatch(int id, bool trackChanges)
        {
            var book = _manager.Book.GetOneBookById(id, trackChanges);
            if (book == null)
                throw new BookNotFoundException(id); //404

            var bookDtoForUpdate = _mapper.Map<BookDtoForUpdate>(book);
            return (bookDtoForUpdate, book);
        }

        void IBookService.SaveChangesForPatch(BookDtoForUpdate bookDtoForUpdate, Book book)
        {
           _mapper.Map(bookDtoForUpdate, book);
            _manager.Save();
        }
    }
}
