using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public record BookDtoForUpdate(int Id, string Title, decimal Price);
    // //this is a record type, it is immutable}
    //{//or like this 
    //    //public int Id { get; init; }
    //    //public string Title { get; init; }
    //    //public decimal Price { get; init; }
    ////We have to use init instead of set because we want to set the value only once
    //}
}
