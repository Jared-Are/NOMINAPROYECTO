﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina
{
    public interface IUserRepository
    {
        Task<string> AuthenticateUserAsync(string username, string password);
    }
}
