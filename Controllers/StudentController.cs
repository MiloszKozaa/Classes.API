
using Classes.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Classes.Features.Student.Queries.GetStudentsFiltered;
using static Classes.Features.Student.Queries.GetStudent;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Classes.Data;
using Classes.Features.Student.Commands;
using Classes.Dtos;
using Classes.Features.Student.Commands.ExternalProfiles;

namespace Classes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {

        private readonly IMediator _mediator;

        public StudentController(
        IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<List<StudentDTO>> GetAll([FromQuery] GetStudentFilteredQuery query, CancellationToken cancellationToken) =>
            await _mediator.Send(query, cancellationToken);   

        [HttpGet("{Id}")]
        public async Task<StudentDTO> Get([FromRoute] GetStudentQuery query, CancellationToken cancellationToken) =>
            await _mediator.Send(query, cancellationToken);  

        [HttpPost("")]
        public async Task<StudentDTO> Create([FromBody] CreateStudentCommand.CreateStudent command, CancellationToken cancellationToken) =>
            await _mediator.Send(command, cancellationToken);   

        [HttpPatch("{Id}")]
        public async Task<StudentDTO> Update([FromBody] UpdateStudentCommand.UpdateStudent command, CancellationToken cancellationToken) =>
            await _mediator.Send(command, cancellationToken);  

        [HttpDelete("{Id}")]
        public async Task Remove([FromRoute] DeleteStudentCommand.DeleteStudent command, CancellationToken cancellationToken) =>
            await _mediator.Send(command, cancellationToken); 

        [HttpPost("{Id}/ExternalProfile")]
        public async Task<StudentDTO> CreateExternalProfile([FromBody] CreateExternalProfileCommand.CreateExternalProfile command, CancellationToken cancellationToken) =>
            await _mediator.Send(command, cancellationToken);  
            
        [HttpDelete("{Id}/ExternalProfile/{ExternalProfileId}")]
        public async Task<StudentDTO> RemoveExternalProfile([FromRoute] DeleteExternalProfileCommand.DeleteExternalProfile command, CancellationToken cancellationToken) =>
            await _mediator.Send(command, cancellationToken);  
    }
}   