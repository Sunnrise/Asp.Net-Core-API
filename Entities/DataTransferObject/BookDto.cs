﻿using System.Text.Json.Serialization;

namespace Entities.DataTransferObject
{
   
    public record BookDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public decimal Price { get; init; }
    }
}
