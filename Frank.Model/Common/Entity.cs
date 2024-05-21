using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Model
{
    public abstract class BaseEntity
    {
    }
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
