﻿using AutoMapper;
using Entities.DataTransferObject;
using Entities.Models;

namespace WebApiBtk.Utilities.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate,Book>().ReverseMap();
            CreateMap<Book, BookDto>();
            CreateMap<BookDtoForInsertion, Book>();

        }
    }
}
