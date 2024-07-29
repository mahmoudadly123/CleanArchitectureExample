using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using CleanArchitecture.API.Attributes;
using CleanArchitecture.Application.Mediators.CQRS.Order.Commands;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Order;
using CleanArchitecture.Application.Mediators.CQRS.Order.Queries;

// ReSharper disable NotAccessedField.Local

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;

        public OrderController(ILogger<OrderController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        // GET: api/<OrderController>
        [HttpGet]
        [ResponseType(typeof(List<ViewOrderDto>), StatusCodes.Status200OK)]
        [ResponseType(StatusCodes.Status204NoContent)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var request = new GetOrdersQuery();
                var response = await _mediator.Send(request, cancellationToken);

                if (response.IsSuccess)
                {
                    //On Response Success

                    if (!response.Value!.ViewOrdersDto.Any())
                    {
                        return NoContent();
                    }

                    return Ok(response.Value.ViewOrdersDto);
                }
                else
                {
                    //On Response Failed
                    return BadRequest(response.ProblemDetails);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        [ResponseType(typeof(ViewOrderDto), StatusCodes.Status200OK)]
        [ResponseType(StatusCodes.Status404NotFound)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var request = new GetOrderQuery(id);

                var response = await _mediator.Send(request, cancellationToken);

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.ProblemDetails);
                }
                else
                {
                    //On Response Success

                    if (response.Value is { ViewOrderDto: null })
                    {
                        return NotFound();
                    }

                    return Ok(response.Value!.ViewOrderDto);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<OrderController>
        [HttpPost]
        [ResponseType(StatusCodes.Status201Created)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateOrderDto newOrder, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new CreateOrderCommand(newOrder);
                
                var response = await _mediator.Send(command, cancellationToken);

                var viewOrderDto = response.Value!.ViewOrderDto;

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.ProblemDetails);
                }
                else
                {
                    //On Response Success
                    //return CreatedAtAction(nameof(Get),new {id=response.Value!.ViewOrderDto.Id},response);
                    return Created($"Order URI = {viewOrderDto.Id}", viewOrderDto);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        [ResponseType(StatusCodes.Status204NoContent)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateOrderDto updatedOrder, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new UpdateOrderCommand(id, 1, updatedOrder);

                var response = await _mediator.Send(command, cancellationToken);

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.ProblemDetails);
                }
                else
                {
                    //On Response Success
                    return NoContent();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        [ResponseType(StatusCodes.Status204NoContent)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new DeleteOrderCommand(id);

                var response = await _mediator.Send(command, cancellationToken);

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.ProblemDetails);
                }
                else
                {
                    //On Response Success
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
