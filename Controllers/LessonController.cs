using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using Classes.Features.Lesson.Commands;
using Classes.Features.Lesson.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Classes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LessonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LessonController(IMediator mediator)
        {
            _mediator = mediator;
        }
            
        [Authorize]        
        [HttpGet("")]
        public async Task<List<LessonDTO>> GetAll([FromQuery] GetLessonsFiltered.GetLessonsFilteredQuery query, CancellationToken cancellationToken) =>
            await _mediator.Send(query, cancellationToken);  
            
        [Authorize]
        [HttpPost("")]
        public async Task<LessonDTO> Create([FromBody] CreateLessonCommand.CreateLessonn query, CancellationToken cancellationToken) =>
            await _mediator.Send(query, cancellationToken); 
            
        [Authorize]
        [HttpGet("{Id}")]
        public async Task<LessonDTO> GetById([FromRoute] GetLesson.GetLessonQuery query, CancellationToken cancellationToken) =>
            await _mediator.Send(query, cancellationToken); 
            
        [Authorize]
        [HttpPatch("{Id}")]
        public async Task<LessonDTO> Update([FromBody] UpdateLessonCommand.UpdateLessonn query, CancellationToken cancellationToken) =>
            await _mediator.Send(query, cancellationToken);
            
        [Authorize]
        [HttpDelete("{Id}")]
        public async Task Delete([FromRoute] DeleteLessonCommand.DeleteLesson query, CancellationToken cancellationToken) =>
            await _mediator.Send(query, cancellationToken); 
    }
}