using CleanArchitecture.Application.Buyer.Commands.CreateBuyer;
//using CleanArchitecture.Application.Buyer.Queries.GetBuyerWithPagination;
using CleanArchitecture.Application.Buyer.Queries.GetDemandAllQuery;
using CleanArchitecture.Application.Buyer.Queries.GetUserDemandAllQuery;
using CleanArchitecture.Application.Buyer.Queries.GetUserDemandQuery;

//using CleanArchitecture.Application.Buyers.Commands.DeleteBuyer;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Informations.Commands.CreateInformation;
using CleanArchitecture.Application.Informations.Queries.GetLoggerQueryId;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationsController : ApiControllerBase
    {
        private readonly IHttpClientFactory? _httpClientFactory;
        public InformationsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create(CreateInformationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(typeof(IList<InformationVm>), (int)HttpStatusCode.OK)]

        public async Task<IList<InformationVm>> Get()
        {
            return await Mediator.Send(new GetInfoSe());
        }
            //[HttpGet]
            //[ProducesResponseType(StatusCodes.Status204NoContent)]
            //[ProducesResponseType(StatusCodes.Status400BadRequest)]
            //[ProducesDefaultResponseType]

            //[AllowAnonymous]
            //public async Task<ActionResult<PaginatedList<DemandBriefDto>>> GetLoggerQueryIdPaginationQuery([FromQuery] GetLoggerQueryIdPaginationQuery query)
            //{

            //    return await Mediator.Send(query);
            //}


        }
}

