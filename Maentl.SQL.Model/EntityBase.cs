using System.ComponentModel.DataAnnotations;

namespace Maentl.SQL.Model
{
    public abstract class EntityBase<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
