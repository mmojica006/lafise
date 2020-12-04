using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataLayer.Entities
{
    [Table("TipoEmployee")]
    public class TipoEmployee
    {
        [ForeignKey("EmployeeInfo")]
        public int TipoEmployeeId { get; set; }
        [StringLength(500)]
        public string Descripcion { get; set; }

        public  EmployeeInfo EmployeeInfo { get; set; }
    }
}
