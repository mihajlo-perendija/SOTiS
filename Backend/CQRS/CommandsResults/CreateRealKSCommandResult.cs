﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.CQRS.CommandsResults
{
    public class CreateRealKSCommandResult : ICommandResult
    {
        public int Id { get; set; }
    }
}
