using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public abstract record BookDtoForManipulation
    {
        [Required(ErrorMessage ="title is a required field")]
        [MinLength(3, ErrorMessage ="title must consist of at least 2 characters")]
        [MaxLength(50, ErrorMessage = "title must consist of at least 2 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "price is a required field")]
        [Range(5, 5000)]
        public decimal Price { get; set; }
    }
}
