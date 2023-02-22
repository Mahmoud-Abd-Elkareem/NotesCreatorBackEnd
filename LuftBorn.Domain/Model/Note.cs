using LuftBorn.Domain.Abstractions;
using LuftBorn.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftBorn.Domain.Model
{
    public class Note : AuditableEntity<Guid>
    {
        public DescriptionLocalized Name { get; set; }
        public DescriptionLocalized Description { get; set; }
        private Note()
        {
            Id = Guid.NewGuid();
        }

        private Note(string nameAr , string nameEn, string descriptionAr , string descriptionEn) : base()
        {
            Name = new DescriptionLocalized(nameAr, nameEn);
            Description = new DescriptionLocalized(descriptionAr , descriptionEn);
        }

        public static Note AddNote(string nameAr, string nameEn, string descriptionAr, string descriptionEn)
        {
            var note = new Note(nameAr , nameEn , descriptionAr , descriptionEn);
            return note;
        }

        public  void UpdateNote(string nameAr, string nameEn, string descriptionAr, string descriptionEn)
        {
            Name = new DescriptionLocalized(nameAr, nameEn);
            Description=new DescriptionLocalized(descriptionAr , descriptionEn);    
        }


    }
}
