using LuftBorn.Domain.Model;
using LuftBorn.Infrastructure.Interfaces;
using MediatR;

namespace LuftBorn.Application.Notes.Command.UpdateNoteCommand
{
    public record UpdateNoteCommand(Guid id, string nameAr, string nameEn, string DescriptionAr, string DescriptionEn) : IRequest<Result<string>>;

    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Result<string>>
    {
        private readonly IRepository<Note> _noterepo;
        public UpdateNoteCommandHandler(IRepository<Note> noterepo)
        {
            _noterepo = noterepo;
        }
        public async Task<Result<string>> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = _noterepo.GetByIdAsync(request.id).Result;
            if (note == null) return Result<string>.Failure(new string[] { "Operation Failed" });
            note.UpdateNote(request.nameAr, request.nameEn, request.DescriptionAr, request.DescriptionEn);
            if (await _noterepo.UpdateAsync(note) is true)
            {
                return Result<string>.Success("Done Successfully");
            }
            else
            {
                return Result<string>.Failure(new string[] { "Operation Failed" });
            }
        }
    }
}
