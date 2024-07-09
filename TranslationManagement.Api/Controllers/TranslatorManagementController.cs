using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TranslationManagement.Api.DTOs.Models;
using TranslationManagement.Api.DTOs.Requests;
using TranslationManagement.Api.DTOs.Responses;
using TranslationManagement.Application.Translators.UseCases;

namespace TranslationManagement.Api.Controlers
{
    [ApiController]
    [Route("api/TranslatorsManagement/[action]")]
    public class TranslatorManagementController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TranslatorManagementController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTranslators()
        {
            try
            {
                var result = await _mediator.Send(new GetTranslators());
                return Ok(result.Select(x => _mapper.Map<TranslatorModel>(x)));
            }
            catch (Exception ex)
            {
                return Problem("Could not get translators");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTranslatorsByName(string name)
        {
            try
            {
                var result = await _mediator.Send(new GetTranslatorsByName { Name = name });
                return Ok(result.Select(x => _mapper.Map<TranslatorModel>(x)));
            }
            catch (Exception ex)
            {
                return Problem("Could not get translators");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTranslator(AddTranslatorRequest translator)
        {
            try
            {
                var result = await _mediator.Send(_mapper.Map<AddTranslator>(translator));
                return Ok(new AddTranslatorResponse { Result = result});
            }
            catch (Exception ex)
            {
                return Problem("Could not add translator");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTranslatorStatus(int Translator, string newStatus = "")
        {
            try
            {
                var result = await _mediator.Send(new UpdateTranslatorStatus { Translator = Translator, NewStatus = newStatus });
                return Ok(new UpdateStatusResponse { Result = result });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem("Could not update translator");
            }
        }
    }
}