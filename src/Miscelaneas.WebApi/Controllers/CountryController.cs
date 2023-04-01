using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Commands;
using UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Models;

namespace UpDEV.Marketplace.Application.WebApi.Miscelaneas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator? mediator;
        private readonly IValidator<CountryDto>? validator;

        public CountryController(IMediator mediator, IValidator<CountryDto> validator)
        {
            ArgumentNullException.ThrowIfNull(validator, "Not instance validator.");
            ArgumentNullException.ThrowIfNull(mediator, "Not instance mediator.");

            this.mediator = mediator;
            this.validator = validator;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? currentPage = 1, int? perPage = 10, string? name = null)
        {
            var command = new CountrySearchQueryCommand
            {
                CurrentPage = currentPage,
                Name = name, 
                PerPage = perPage
            };

            var response = await mediator!.Send(command).ConfigureAwait(false);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CountryDto country, CancellationToken cancellationToken)
        {
            var result = await this.validator!.ValidateAsync(country, option => option.IncludeRuleSets("CountryCreate"), cancellationToken).ConfigureAwait(false);
            if (!result.IsValid)
            {
                var responseBadRequest = new BadRequestDto<CountryDto>(country, result.Errors, result.RuleSetsExecuted, result.IsValid);

                return BadRequest(responseBadRequest!);
            }

            var response = await mediator!.Send(new CountryRegisterCommand(country)).ConfigureAwait(false);

            return Ok(response);
        }


        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
