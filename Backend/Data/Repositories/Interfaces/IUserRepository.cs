﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<object> GetUserByUsername(string username);

    }
}