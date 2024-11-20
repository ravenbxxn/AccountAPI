using System.ComponentModel.DataAnnotations;

namespace APIPrototype.Models
{
    public class View_Model
    {
        public class ViewRequest
        {
            [Required]
            public string ViewName { get; set; }

            // แก้ไขให้ฟิลด์นี้เป็น Optional
            public List<Parameter>? Parameters { get; set; }

            // แก้ไขให้ฟิลด์นี้เป็น Optional
            public List<ResultField>? Results { get; set; }
        }

        public class Parameter
        {
            [Required]
            public string Field { get; set; }

            [Required]
            public string Value { get; set; }
        }

        public class ResultField
        {
            [Required]
            public string SourceField { get; set; }

            public string? Alias { get; set; }
        }

    }
}
