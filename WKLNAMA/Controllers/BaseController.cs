﻿using Business.BusinessLogic;
using Business.Services;
using Data.DomainModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WKLNAMA.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WKLNAMA.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase where TEntity : class
    {
        protected IBaseRepository<TEntity> _baseRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private ApiResponse apiResponse = new ApiResponse();
        public BaseController(IBaseRepository<TEntity> baseRepository, IHttpContextAccessor httpContextAccessor)
        {
            _baseRepository = baseRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public virtual async Task<ActionResult> GetAll()
        {
            try
            {
                var data = await _baseRepository.GetAll();
                apiResponse.Success = true;
                apiResponse.Message = HttpStatusCode.OK.ToString();
                apiResponse.HttpStatusCode = HttpStatusCode.OK;
                apiResponse.Data = data;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                apiResponse.HttpStatusCode = HttpStatusCode.InternalServerError;
                apiResponse.Data = null;
            }


            return Ok(apiResponse);
        }
        [HttpPost]
        public async virtual Task<ActionResult> Post(TEntity _viewModel)
        {
            try
            {
                _baseRepository.Insert(_viewModel);
                await _baseRepository.SaveAsync();
                apiResponse.Success = true;
                apiResponse.Message = HttpStatusCode.Created.ToString();
                apiResponse.HttpStatusCode = HttpStatusCode.Created;
                apiResponse.Data = _viewModel;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                apiResponse.HttpStatusCode = HttpStatusCode.InternalServerError;
                apiResponse.Data = null;
            }
            return Ok(apiResponse);
        }

        [HttpGet("Find")]
        public async virtual Task<ActionResult> GetById(object id)
        {
            try
            {
                var data = await _baseRepository.GetById(id);
                apiResponse.Success = true;
                apiResponse.Message = HttpStatusCode.OK.ToString();
                apiResponse.HttpStatusCode = HttpStatusCode.OK;
                apiResponse.Data = data;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                apiResponse.HttpStatusCode = HttpStatusCode.InternalServerError;
                apiResponse.Data = null;
            }
            return Ok(apiResponse);
        }

        [HttpDelete]
        public async virtual Task<ActionResult> Delete(object id)
        {
            try
            {
                await _baseRepository.Delete(Convert.ToInt32(id.ToString()));
                await _baseRepository.SaveAsync();

                apiResponse.Success = true;
                apiResponse.Message = "Recored Deleted";
                apiResponse.HttpStatusCode = HttpStatusCode.OK;
                apiResponse.Data = id.ToString();
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                apiResponse.HttpStatusCode = HttpStatusCode.InternalServerError;
                apiResponse.Data = null;
            }
            return Ok(apiResponse);
        }

        [HttpPut]
        public async virtual Task<ActionResult> Update(TEntity _object)
        {
            try
            {

                _baseRepository.Update(_object);
                await _baseRepository.SaveAsync();
                apiResponse.Success = true;
                apiResponse.Message = "Recored Updated";
                apiResponse.HttpStatusCode = HttpStatusCode.OK;
                apiResponse.Data = _object;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                apiResponse.HttpStatusCode = HttpStatusCode.InternalServerError;
                apiResponse.Data = null;
            }
            return Ok(apiResponse);
        }

    }
}
