using Entities.DataTransferObject;
using Entities.LinkModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBookLinks
    {
        public LinkResponse TryGenerateLinks(IEnumerable<BookDto> bookDto,
            string fields, HttpContext httpContext);
       
    }
}
