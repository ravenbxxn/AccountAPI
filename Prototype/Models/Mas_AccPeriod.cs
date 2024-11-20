using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPrototype.Models
{
    public class Mas_AccPeriod
    {
        [Key]
        public int PeriodID { get; set; }

        public DateTime PeriodEndDate { get; set; }
    }
}
