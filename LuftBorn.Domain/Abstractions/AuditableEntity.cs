namespace LuftBorn.Domain.Abstractions
{
    public abstract class AuditableEntity<TKey> : Entity<TKey>
    {
        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }
        internal void SetUpdate()
        {
            LastModified = DateTime.Now;
        }
    }
}
