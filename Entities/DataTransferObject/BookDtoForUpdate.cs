using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public record BookDtoForUpdate : BookDtoForManipulation
    {
        [Required(ErrorMessage = "id is a required field")]
        public int Id { get; init; }
    }
}
