
using Common.Utilities;

namespace Constants
{
    public partial class Variable
    {
        //Scaffold-DbContext "Server=.; Database=contabilidad;User Id=sa; Password=123456;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ModelData -DataAnnotations -Context SpDbContext
        //Scaffold-DbContext "Server=.;Database=contabilidad2023;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -DataAnnotations -Context SpDbContext
        public static String STRINGCONNECTION { get { return (HelperConfiguration.GetParam("AppConfig:StringConnection") ?? ""); } }
    }
}