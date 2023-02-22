using LuftBorn.Domain.Model;
using LuftBorn.Infrastructure.Interfaces;
using MediatR;

namespace LuftBorn.Application.Notes.Command.DeleteNoteCommand
{
    public record DeleteNoteCommand(Guid id) : IRequest<Result<string>>;
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Result<string>>
    {
        private readonly IRepository<Note> _noterepo;
        public DeleteNoteCommandHandler(IRepository<Note> noterepo)
        {
            _noterepo = noterepo;
        }
        public async Task<Result<string>> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            if (await _noterepo.DeleteAsync(request.id) is true)
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
