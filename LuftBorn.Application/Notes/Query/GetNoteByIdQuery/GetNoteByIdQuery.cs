using AutoMapper;
using LuftBorn.Domain.Model;
using LuftBorn.Infrastructure.Interfaces;
using MediatR;

namespace LuftBorn.Application.Notes.Query.GetNoteByIdQuery
{
    public record GetNoteByIdQuery(Guid id) : IRequest<Result<NotesDto>>;
    public class GetNoteByIdQueryHandelar : IRequestHandler<GetNoteByIdQuery, Result<NotesDto>>
    {
        private readonly IRepository<Note> _noterepo;
        private readonly IMapper _mapper;
        public GetNoteByIdQueryHandelar(IRepository<Note> noterepo, IMapper mapper)
        {
            _noterepo = noterepo;
            _mapper = mapper;
        }

        public async Task<Result<NotesDto>> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
        {
            var noteObj = _noterepo.GetByIdAsync(request.id).Result;
            if (noteObj == null) return Result<NotesDto>.Failure(new string[] { "Operation Failed" });

            return Result<NotesDto>.Success(_mapper.Map<NotesDto>(noteObj));
        }
    }
}
