using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObject
{
    public record BookDtoForInsertion: BookDtoForManipulation
    {
        [Required(ErrorMessage = "The CategoryId is required")]
        public int CategoryId { get; init; }
    }

}
