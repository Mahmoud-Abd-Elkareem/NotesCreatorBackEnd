using AutoMapper;
using AutoMapper.QueryableExtensions;
using Booking.Application.Common.Mappings;
using LuftBorn.Application.Common;
using LuftBorn.Domain.Model;
using LuftBorn.Infrastructure.Interfaces;
using MediatR;

namespace LuftBorn.Application.Notes.Query.GetAllNotesQuery
{
    public record GetAllNotesQuery(int pageIndex = 0, int pageSize = 10) : IRequest<Result<PaginatedList<NotesDto>>>;
    public class GetAllNotesQueryHandelar : IRequestHandler<GetAllNotesQuery, Result<PaginatedList<NotesDto>>>
    {
        private readonly IRepository<Note> _noterepo;
        private readonly IMapper _mapper;
        public GetAllNotesQueryHandelar(IRepository<Note> noterepo, IMapper mapper)
        {
            _noterepo = noterepo;
            _mapper = mapper;
        }
        public async Task<Result<PaginatedList<NotesDto>>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
        {
            var noteList = _noterepo.GetAllAsync().Result;
            var paginatedList = await noteList.OrderBy(c => c.Name.DescriptionAr)
                .ProjectTo<NotesDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.pageIndex, request.pageSize);
            return Result<PaginatedList<NotesDto>>.Success(paginatedList);
        }

    }
}
