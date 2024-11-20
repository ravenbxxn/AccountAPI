using System.ComponentModel.DataAnnotations;

namespace APIPrototype.Models
{
    public class Mas_HRStaff
    {
        [Key]
        public int StaffId { get; set; }

        [StringLength(50)]
        public string? StaffCode { get; set; }

        public int? StaffType { get; set; }

        public int? CitizenType { get; set; }

        [StringLength(50)]
        public string? Title { get; set; }

        [StringLength(10)]
        public string? TitleEN { get; set; }

        [StringLength(50)]
        public string? StaffName { get; set; }

        [StringLength(50)]
        public string? StaffNameEN { get; set; }

        [StringLength(50)]
        public string? StaffMiddleName { get; set; }

        [StringLength(50)]
        public string? StaffLastName { get; set; }

        [StringLength(50)]
        public string? StaffLastNameEN { get; set; }

        [StringLength(10)]
        public string? Nationality { get; set; }


        public string? StaffRegisterAddr { get; set; }

        public string? StaffRegisterAddrEN { get; set; }

        [StringLength(50)]
        public string? StaffCitizenID { get; set; }

        public DateTime? StaffCitizenIDExpireDate { get; set; }

        [StringLength(50)]
        public string? StaffAddrZipcode { get; set; }

        public int? StaffUnderlingId { get; set; }
    }
}
