using LuftBorn.Application;
using LuftBorn.Application.Common;
using LuftBorn.Application.Notes.Command.AddNoteCommand;
using LuftBorn.Application.Notes.Command.DeleteNoteCommand;
using LuftBorn.Application.Notes.Command.UpdateNoteCommand;
using LuftBorn.Application.Notes.Query;
using LuftBorn.Application.Notes.Query.GetAllNotesQuery;
using LuftBorn.Application.Notes.Query.GetNoteByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LuftBorn.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Result<PaginatedList<NotesDto>>), (int)HttpStatusCode.OK)]
        public async Task<Result<PaginatedList<NotesDto>>> GetAll([FromQuery] GetAllNotesQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<NotesDto>), (int)HttpStatusCode.OK)]
        public async Task<Result<NotesDto>> GetById(Guid id)
        {
            return await _mediator.Send(new GetNoteByIdQuery(id));

        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<Result<string>> Create(AddNoteCommand command)
        {

            return await _mediator.Send(command);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<Result<string>> Update(UpdateNoteCommand command)
        {

            return await _mediator.Send(command);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<Result<string>> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteNoteCommand(id));
        }
    }
}
