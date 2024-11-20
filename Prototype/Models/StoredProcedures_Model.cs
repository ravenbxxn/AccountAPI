namespace APIPrototype.Models
{
    public class StoredProcedures_Model
    {
        public class ProcedureParameter
        {
            public string Param { get; set; }
            public object Value { get; set; }
        }

        public class ProcedureRequest
        {
            public string Name { get; set; }
            public List<ProcedureParameter> Parameters { get; set; }
        }
    }
}
