using Microsoft.AspNetCore.OData.Query;
using Microsoft.OData.Edm;
using MongoSample.Domain.Infrasructure.Contracts;

namespace MongoSample.UI.Controllers
{
    public class CustomEnableQueryAttribute : EnableQueryAttribute
    {
        public override IQueryable ApplyQuery(IQueryable queryable, ODataQueryOptions queryOptions)
        {
            IIndexManager indexManager = queryOptions
                .Request.HttpContext.RequestServices.GetRequiredService<IIndexManager>();
            if (queryOptions.Filter != null)
            {
                string filter = queryOptions.Filter.RawValue;
                var model = queryOptions.Context.Model;
                string typeName = queryOptions.Context.ElementClrType.Name;
                if (model.SchemaElements.Any(o => o.Name == typeName))
                {
                    var type = (EdmEntityType)model.SchemaElements.First(o => o.Name == typeName);
                    var props = type.DeclaredProperties.Select(o => o.Name).ToList();
                    var indexes = props.Where(o => filter.Contains(o)).ToArray();
                    indexManager.SendIndexInfo(indexes);
                    
                }
            }
            return base.ApplyQuery(queryable, queryOptions);
        }
    }
}
