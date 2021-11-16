using System;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime DateCreated { get; set; }
        string Name { get; set; }
    }

    public abstract class BaseEntity<T> : IEntity<T>
    {
        [Key]
        public T Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Required, StringLength(255)]
        public string Name { get; set; }
    }
}
