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

            // Optional Result Fields
            public List<JoinClause>? Joins { get; set; }

        }

        public class Parameter
        {
            [Required]
            public string Field { get; set; }

            [Required]
            public string Value { get; set; }

            public string UseOperator { get; set; } = "="; // ค่าเริ่มต้นเป็น '='
        }

        public class ResultField
        {
            [Required]
            public string SourceField { get; set; }

            public string? Alias { get; set; }

            public string? Type { get; set; } // รองรับการกำหนดประเภทข้อมูล เช่น "double", "int"
        }

        public class JoinClause
        {
            public string JoinType { get; set; } = "LEFT JOIN"; // Default เป็น LEFT JOIN

            [Required]
            public string Table { get; set; } // ตารางที่ต้องการ JOIN

            [Required]
            public string Alias { get; set; } // Alias ของตาราง (จำเป็นในกรณี JOIN ซ้ำกัน)

            [Required]
            public List<JoinCondition> Conditions { get; set; } = new();

            // เพิ่ม NullConditions ในการจัดการฟิลด์ที่ต้องการใช้ IS NULL
            public List<string>? NullConditions { get; set; }
        }

        public class JoinCondition
        {
            [Required]
            public string LeftField { get; set; } // ฟิลด์จากตารางหลัก

            [Required]
            public string RightField { get; set; } // ฟิลด์จากตารางที่ JOIN

            public string? Alias { get; set; }
        }

    }
}
