using LuftBorn.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftBorn.Domain.ValueObjects
{
    public class DescriptionLocalized : ValueObject
    {
        public string DescriptionAr { get; }
        public string DescriptionEn { get; }
        public string Description => GetLocalizedPropertyValue(nameof(Description));

        public static implicit operator string(DescriptionLocalized name) => name.Description;

        public DescriptionLocalized() { }
        public DescriptionLocalized(string descriptionAr, string descriptionEn)
        {
            DescriptionAr = descriptionAr;
            DescriptionEn = descriptionEn;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DescriptionAr;
            yield return DescriptionEn;
        }
    }
}
