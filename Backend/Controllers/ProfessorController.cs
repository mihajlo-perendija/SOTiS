﻿using Backend.CQRS.Commands;
using Backend.CQRS.Processors;
using Backend.CQRS.Queries;
using Backend.CQRS.QueriesResults;
using Backend.Utils.CustomAttributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly ICommandProcessor _commandProcessor;
        private readonly IQueryProcessor _queryProcessor;
        private readonly IHttpContextAccessor _httpContext;

        public ProfessorController(ICommandProcessor commandProcessor, IQueryProcessor queryProcessor, IHttpContextAccessor context)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
            _httpContext = context;
        }

        [Authorize]
        [HttpPost("{professor_id}/tests")]
        public async Task<IActionResult> MakeTest(String professor_id, MakeTestCommand makeTestCommand)
        {
            makeTestCommand.ProfessorId = int.Parse(professor_id);
            var response = await _commandProcessor.Execute(makeTestCommand, _httpContext);
            return Ok(response);
        }

        [HttpGet("{professor_id}/tests")]
        public async Task<IActionResult> GetAllProfessorsTests(String professor_id)
        {
            return Ok();
        }

        [HttpGet("{professor_id}/tests/{test_id}")]
        public async Task<IActionResult> GetOneProfessorsTest(String professor_id, String test_id)
        {
            System.Diagnostics.Debug.WriteLine("Professor id: " + professor_id);
            System.Diagnostics.Debug.WriteLine("Testt id: " + test_id);

            return Ok();
        }

        [HttpDelete("{professor_id}/tests/{test_id}")]
        public async Task<IActionResult> DeleteOneProfessorsTest(String professor_id, String test_id)
        {
            System.Diagnostics.Debug.WriteLine("Professor id: " + professor_id);
            System.Diagnostics.Debug.WriteLine("Testt id: " + test_id);

            return Ok();
        }

        [HttpGet("{professor_id}/tests/{test_id}/qti")]
        public async Task<ContentResult> GetTestQti(String professor_id, String test_id)
        {
            GetTestQtiQuery knowledgeSpaceGetAllQuery = new GetTestQtiQuery();
            knowledgeSpaceGetAllQuery.TestId = int.Parse(test_id);
            GetTestQtiQueryResult response = (GetTestQtiQueryResult)await _queryProcessor.Execute(knowledgeSpaceGetAllQuery, _httpContext);

            return new ContentResult
            {
                ContentType = "application/xml",
                Content = response.File,
                StatusCode = 200
            };
        }

        [Authorize]
        [HttpPost("{professor_id}/knowledge_space")]
        public async Task<IActionResult> CreateKnowledgeSpace(String professor_id, CreateKnowledgeSpaceCommand createKnowledgeSpace)
        {
            createKnowledgeSpace.ProfessorId = int.Parse(professor_id);
            var response = await _commandProcessor.Execute(createKnowledgeSpace, _httpContext);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("{professor_id}/knowledge_space/real/{flag}")]
        public async Task<IActionResult> GetAllKnowledgeSpaceOfProfessor(String professor_id, String flag)
        {
            KnowledgeSpaceGetAllQuery knowledgeSpaceGetAllQuery = new KnowledgeSpaceGetAllQuery();
            knowledgeSpaceGetAllQuery.ProfessorId = int.Parse(professor_id);
            knowledgeSpaceGetAllQuery.Real = flag.Equals("1");

            var response = await _queryProcessor.Execute(knowledgeSpaceGetAllQuery, _httpContext);
            return Ok(response);
        }


        [Authorize]
        [HttpGet("{professor_id}/knowledge_space/{knowledge_space_id}")]
        public async Task<IActionResult> GetOneKnowledgeSpace(String professor_id,String knowledge_space_id)
        {
            KnowledgeSpaceGetOneQuery knowledgeSpaceGetOneQuery = new KnowledgeSpaceGetOneQuery();
            knowledgeSpaceGetOneQuery.KnowledgeSpaceId = int.Parse(knowledge_space_id);
            var response = await _queryProcessor.Execute(knowledgeSpaceGetOneQuery, _httpContext);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("{professor_id}/knowledge_space/{knowledge_space_id}/real")]
        public async Task<IActionResult> createRealKnowledgeSpace(String professor_id, String knowledge_space_id)
        {
            CreateRealKSCommand createRealKSCommand = new CreateRealKSCommand();
            createRealKSCommand.KnowledgeSpaceId = int.Parse(knowledge_space_id);
            var response = await _commandProcessor.Execute(createRealKSCommand, _httpContext);
            return Ok(response);
        }
    }

}
