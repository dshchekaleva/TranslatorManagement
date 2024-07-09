using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TranslationManagement.Api.Controlers;
using TranslationManagement.Api.DTOs.Models;
using TranslationManagement.Api.DTOs.Requests;
using TranslationManagement.Api.DTOs.Responses;
using TranslationManagement.Application.Jobs.UseCases;

namespace TranslationManagement.Api.Controllers
{
    [ApiController]
    [Route("api/jobs/[action]")]
    public class TranslationJobController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TranslationJobController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            try
            {
                var result = await _mediator.Send(new GetJobs());
                return Ok(result.Select(x=>_mapper.Map<JobModel>(x)));
            }
            catch (Exception ex)
            {
                return Problem("Could not get jobs");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobAsync(CreateJobRequest job)
        {
            try
            {
                var result = await _mediator.Send(_mapper.Map<CreateJob>(job));
                return Ok(new JobCreatedResponse { Success = result });
            }
            catch (Exception)
            {
                return Problem("Could not create job");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobWithFileAsync(IFormFile file, string customer)
        {
            try
            {
                var result = await _mediator.Send(new CreateJobWithFile { File = file, Customer = customer });
                return Ok(new JobCreatedResponse { Success = result });
            }
            catch (Exception)
            {
                return Problem("Could not create job");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateJobStatus(int jobId, int translatorId, string newStatus = "")
        {
            try
            {
                var result = await _mediator.Send(new UpdateJobStatus { JobId = jobId, TranslatorId = translatorId, NewStatus = newStatus });
                return Ok(new UpdateStatusResponse { Result = result });
            }
            catch (Exception ex)
            {
                return Problem("Could not update job");
            }
        }
    }





   





}