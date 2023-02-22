using LuftBorn.Domain.Model;
using LuftBorn.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LuftBorn.Application.Notes.Command.AddNoteCommand
{
    public record AddNoteCommand(string nameAr, string nameEn , string DescriptionAr , string DescriptionEn) : IRequest<Result<string>>;
    public class AddNoteCommandHandler : IRequestHandler<AddNoteCommand, Result<string>>
    {
        private readonly IRepository<Note> _noterepo;
        public AddNoteCommandHandler(IRepository<Note> noterepo)
        {
            _noterepo = noterepo;
        }
        public async Task<Result<string>> Handle(AddNoteCommand request, CancellationToken cancellationToken)
        {
            var noteObj = Note.AddNote(request.nameAr, request.nameEn, request.DescriptionAr, request.DescriptionEn);
            if (await _noterepo.InsertAsync(noteObj) is true)
            {
                return Result<string>.Success("Done Successfully");
            }
            else
            {
                return Result<string>.Failure(new string[] {"Operation Failed"});
            }
        }
    }
}
