using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;


namespace Entities.DataTransferObject
{
    public record LinkParameters
    {
        

        public BookParameters BookParameters { get; init; }
        public HttpContext HttpContext { get; init; }
    }
}
