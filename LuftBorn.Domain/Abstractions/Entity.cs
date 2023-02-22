using System.Globalization;
using System.Reflection;

namespace LuftBorn.Domain.Abstractions
{
    public abstract class Entity<TKey>
    {
        TKey _Id;

        public virtual TKey Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }

        public virtual string GetLocalizedPropertyValue(string propertyName)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            var twoLetterCulture = currentCulture.Name;

            var culturePropertyName = propertyName + twoLetterCulture;

            return (string)GetType().GetProperty(culturePropertyName, BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance)?.GetValue(this, null);
        }

    }
}
