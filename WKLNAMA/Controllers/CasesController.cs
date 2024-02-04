﻿using Business.BusinessLogic;
using Business.Services;
using Business.ViewModels;
using Data.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjWakalatnama.DataLayer.Models;
using System.Net;
using WKLNAMA.Models;

namespace WKLNAMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : BaseController<CourtCases>
    {
        private readonly ICasesRepository casesRepository;

        private ApiResponse apiResponse = new ApiResponse();
        public CasesController(ICasesRepository casesRepository, IHttpContextAccessor httpContextAccessor, IDocumentService documentService) : base(casesRepository, httpContextAccessor)
        {
            this.casesRepository = casesRepository;
        }
        [HttpPost("CreateCase")]
        public async Task<ActionResult> Post([FromForm]CourtCaseVM courtCase)
        {
            try
            {
                await casesRepository.CreateCase(courtCase);
                apiResponse.Message = HttpStatusCode.Created.ToString();
                apiResponse.HttpStatusCode = HttpStatusCode.Created;
                apiResponse.Success = true;
                //apiResponse.Data = result;
            }
            catch (Exception ex)
            {
                apiResponse.Message = ex.Message;
                apiResponse.HttpStatusCode = HttpStatusCode.InternalServerError;
                apiResponse.Success = false;
                apiResponse.Data = null;
            }

            //return Ok(Task.FromResult(_viewModel));
            return Ok(apiResponse);
        }
    }
}
