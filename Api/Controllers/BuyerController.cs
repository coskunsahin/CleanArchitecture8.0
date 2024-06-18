//using CleanArchitecture.Application.Buyer.Queries.GetBuyerWithPagination;
//using CleanArchitecture.Application.Buyers.Commands.DeleteBuyer;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Buyer.Commands.CreateBuyer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using CleanArchitecture.Application.Buyer.Queries.GetInformationWithDemands;
using CleanArchitecture.Application.Buyer.Queries.GetUserDemandQuery;
using CleanArchitecture.Application.Buyer.Commands.UpdateBuyer;
using CleanArchitecture.Application.Buyer.Commands.DeleteBuyer;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ApiControllerBase
    {

        
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBuyerCommand command)
        {
            

            return await Mediator.Send(command);


        } 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {

            await Mediator.Send(new DeleteBuyerCommand(id));

            return NoContent();
        }

        [HttpGet]
        public async Task<IList<DemandVm>> Get()
        {
            return await Mediator.Send(new GetUserDemandQuery());
        }
        [HttpPut("{DenandId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update(int DenandId, UpdateDemandCommand command)
        {
            if (DenandId != command.DenandId)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
    }
}

