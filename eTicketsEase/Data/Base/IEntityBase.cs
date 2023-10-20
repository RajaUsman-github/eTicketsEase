using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsEase.Data.Base
{
    public interface IEntityBase
    {
         int Id { get; set; }
    }
}
