using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 50;

        //Auto-implemented properties
        public int PageNumber { get; set; } = 1;

        //Full-property
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}
