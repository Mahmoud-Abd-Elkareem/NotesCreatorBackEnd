using AutoMapper;
using LuftBorn.Application.Common;
using LuftBorn.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftBorn.Application.Notes.Query
{
    public class NotesDto : IMapFrom<Note>
    {
        public Guid Id { get; init; }
        public string NameAr { get; init; }
        public string NameEn { get; init; }
        public string DescriptionAr { get; init; }
        public string DescriptionEn { get; init; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NotesDto>()
                .ForMember(a => a.NameAr, obj => obj.MapFrom(x => x.Name.DescriptionAr))
                .ForMember(a => a.NameEn, obj => obj.MapFrom(x => x.Name.DescriptionEn))
                .ForMember(a => a.DescriptionAr, obj => obj.MapFrom(x => x.Description.DescriptionAr))
                .ForMember(a => a.DescriptionEn, obj => obj.MapFrom(x => x.Description.DescriptionEn));

        }
    }
}
