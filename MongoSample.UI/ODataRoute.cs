using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using MongoSample.Domain.Models;

namespace MongoSample.UI
{
    public class ODataRoute
    {
        public static readonly string RoutePrefix = "odata";
        public static IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EnableLowerCamelCase();
            odataBuilder.EntitySet<PersonDto>("peopel");
            return odataBuilder.GetEdmModel();
        }
    }
}
