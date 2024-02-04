﻿using Business.BusinessLogic;
using Business.Services;
using Business.ViewModels;
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
    public class UsersController : BaseController<UserProfile>
    {
        private readonly IUserRepository userRepository;
        private ApiResponse apiResponse = new ApiResponse();

        public UsersController(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor) : base(userRepository, httpContextAccessor)
        {
            this.userRepository = userRepository;

        }       
        [HttpPost("GetLawyerList")]
        public async Task<ActionResult> GetLawyerList(int? cityId)
        {
            try
            {
                var result = await userRepository.GetLawyerList(cityId);
                apiResponse.Message = HttpStatusCode.OK.ToString();
                apiResponse.HttpStatusCode = HttpStatusCode.OK;
                apiResponse.Success = true;
                apiResponse.Data = result;
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
        [HttpPost("GetLawyerDetails")]
        public async Task<ActionResult> GetLawyerDetails(int? lawyerId)
        {
            try
            {
                var result = await userRepository.GetLawyerProfile(lawyerId);
                apiResponse.Message = HttpStatusCode.OK.ToString();
                apiResponse.HttpStatusCode = HttpStatusCode.OK;
                apiResponse.Success = true;
                apiResponse.Data = result;
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
