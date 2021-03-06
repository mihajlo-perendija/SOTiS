﻿using Backend.CQRS.Queries;
using Backend.CQRS.QueriesResults;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Backend.CQRS.Processors
{
    public interface IQueryProcessor
    {
        public abstract Task<IQueryResult> Execute(IQuery command, IHttpContextAccessor context);
    }
}
