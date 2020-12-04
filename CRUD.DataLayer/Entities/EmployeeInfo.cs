namespace CRUD.DataLayer.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EmployeeInfo")]
    public partial class EmployeeInfo
    {
        [Key]
        public int EmployeeNo { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string MobileNo { get; set; }

        [StringLength(50)]
        public string PostelCode { get; set; }

        [StringLength(50)]
        public string EmailId { get; set; }
        public int? TipoEmployeeId { get; set; }
        public  TipoEmployee TipoEmployee { get; set; }
    }
}
