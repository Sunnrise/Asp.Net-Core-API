using AutoMapper;
using Entities.DataTransferObject;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
        private readonly IDataShaper<BookDto> _dataShaper;
        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper, IDataShaper<BookDto> dataShaper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<BookDto> CreateOneBookAsync(BookDtoForInsertion bookDto)
        {
            var enttity =  _mapper.Map<Book>(bookDto);
            _manager.Book.CreateOneBook(enttity);
            _manager.SaveAsync();
            return _mapper.Map<BookDto>(enttity);
        }

        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
            var entity = await GetOneBookAndCheckExistAsync(id, trackChanges);
            _manager.Book.DeleteOneBook(entity);
            await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<ExpandoObject> books, MetaData metaData)>
            GetAllBooksAsync(BookParameters bookParameters,
            bool trackChanges)
        {
            if(!bookParameters.ValidPriceRange)
                throw new PriceOutOfRangeBadRequestException();

            var booksWithMetaData = await _manager
                .Book
                .GetAllBooksAsync(bookParameters, trackChanges);

            var booksDto = _mapper.Map<IEnumerable<BookDto>>(booksWithMetaData);
            var shapedData = _dataShaper.ShapeData(booksDto, bookParameters.Fields);

            return (books: shapedData,metaData: booksWithMetaData.MetaData);
        }

        public async Task<BookDto> GetOneBookByIdAsync(int id, bool trackChanges)
        {
            var book= await GetOneBookAndCheckExistAsync(id, trackChanges);
            
            return _mapper.Map<BookDto>(book);
        }

        public async Task UpdateOneBookAsync(int id,
            BookDtoForUpdate bookDto,
            bool trackChanges)
        {
            //Check entity
            var entity = await GetOneBookAndCheckExistAsync(id, trackChanges);
            if (entity == null)
                throw new BookNotFoundException(id); //404


            //entity.Title = book.Title;
            //entity.Price = book.Price;
            ////mapping
            entity = _mapper.Map<Book>(bookDto);

            _manager.Book.UpdateOneBook(entity);
            await _manager.SaveAsync();



        }

        public async Task<(BookDtoForUpdate bookDtoForUpdate, Book book)>
            GetOneBookForPatchAsync(int id, bool trackChanges)
        {
            var book = await GetOneBookAndCheckExistAsync(id, trackChanges);
            var bookDtoForUpdate = _mapper.Map<BookDtoForUpdate>(book);
            return (bookDtoForUpdate, book);
        }

        public async Task SaveChangesForPatchAsync(BookDtoForUpdate bookDtoForUpdate, Book book)
        {
           _mapper.Map(bookDtoForUpdate, book);
            await _manager.SaveAsync();
        }

        private async Task<Book>GetOneBookAndCheckExistAsync(int id ,bool trackChanges)
        {
            //check entity
            var entity = await _manager.Book.GetOneBookByIdAsync(id, trackChanges);
            if (entity == null)
                throw new BookNotFoundException(id); //404
            return entity;
        }

        
    }
}
