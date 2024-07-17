﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class RefreshTokenBadRequestException: BadRequestException
    {
        public RefreshTokenBadRequestException() : base($"Invalid Client Request. The tokenDto has invalid values.")
        {
        }
    }
}
