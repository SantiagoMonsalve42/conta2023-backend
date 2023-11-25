using System.Data;

namespace DTO.common
{
    public class SpParamGeneric
    {
        public string Name { get; set; }
        public SqlDbType Type { get; set; }
        public int Size { get; set; }
        public dynamic Value { get; set; }
    }
    public class SpGenericResult
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
    
}
