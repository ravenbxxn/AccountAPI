using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_HRStaff
{
    public int StaffId { get; set; }

    public string? StaffCode { get; set; }

    public int? StaffType { get; set; }

    public int? CitizenType { get; set; }

    public string? Title { get; set; }

    public string? TitleEN { get; set; }

    public string? StaffName { get; set; }

    public string? StaffNameEN { get; set; }

    public string? StaffMiddleName { get; set; }

    public string? StaffLastName { get; set; }

    public string? StaffLastNameEN { get; set; }

    public string? Nationality { get; set; }

    public string? StaffRegisterAddr { get; set; }

    public string? StaffRegisterAddrEN { get; set; }

    public string? StaffCitizenID { get; set; }

    public DateTime? StaffCitizenIDExpireDate { get; set; }

    public string? StaffAddrZipcode { get; set; }

    public int? StaffUnderlingId { get; set; }
}
