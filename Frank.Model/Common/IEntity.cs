using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Model
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
