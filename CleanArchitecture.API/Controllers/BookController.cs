using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using CleanArchitecture.API.Attributes;
using CleanArchitecture.Application.Mediators.CQRS.Book.Commands;
using CleanArchitecture.Application.Mediators.CQRS.Book.Queries;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;

// ReSharper disable NotAccessedField.Local

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IMediator _mediator;

        public BookController(ILogger<BookController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        // GET: api/<BookController>
        [HttpGet]
        [ResponseType(typeof(List<ViewBookDto>), StatusCodes.Status200OK)]
        [ResponseType(StatusCodes.Status204NoContent)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var request = new GetBooksQuery();
                var response = await _mediator.Send(request, cancellationToken);

                if (response.IsSuccess)
                {
                    //On Response Success

                    if (!response.Value!.ViewBooksDto.Any())
                    {
                        return NoContent();
                    }
                    
                    return Ok(response.Value.ViewBooksDto);
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

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        [ResponseType(typeof(ViewBookDto), StatusCodes.Status200OK)]
        [ResponseType(StatusCodes.Status404NotFound)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var request = new GetBookQuery(id);

                var response = await _mediator.Send(request, cancellationToken);

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.ProblemDetails);
                }
                else
                {
                    //On Response Success

                    if (response.Value is { ViewBookDto: null })
                    {
                        return NotFound();
                    }

                    return Ok(response.Value!.ViewBookDto);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<BookController>
        //[Authorize]
        [HttpPost]
        [ResponseType(StatusCodes.Status201Created)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateBookDto newBook, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new CreateBookCommand(newBook);
                
                var response = await _mediator.Send(command, cancellationToken);

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.ProblemDetails);
                }
                else
                {
                    //On Response Success
                    return CreatedAtAction(nameof(Get),new {id=response.Value!.ViewBookDto.Id},response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        // PUT api/<BookController>/5
        //[Authorize]
        [HttpPut("{id}")]
        [ResponseType(StatusCodes.Status204NoContent)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateBookDto updatedBook, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new UpdateBookCommand(id,1, updatedBook);
                
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

        // DELETE api/<BookController>/5
        //[Authorize]
        [HttpDelete("{id}")]
        [ResponseType(StatusCodes.Status204NoContent)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                //using Mediator to send request and mediator will handle it by handler and return the response
                var command = new DeleteBookCommand(id);

                var response = await _mediator.Send(command, cancellationToken);

                if (!response.IsSuccess)
                {
                    //On Response Failed
                    return BadRequest(response.ProblemDetails);
                }
                else
                {
                    //On Response Success
                    return  NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
