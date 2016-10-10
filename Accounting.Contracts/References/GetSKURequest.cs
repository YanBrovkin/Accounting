using System.Collections.Generic;
using ServiceStack.ServiceInterface.ServiceModel;
using Accounting.Contracts.DTO;
using ServiceStack.ServiceHost;

namespace Accounting.Contracts.References
{
    [Route("/sku/{id}", "GET")]
    public class GetSKURequest
    {
        public long Id { get; set; }
    }

    public class GetSKUResponse
    {
        public ResponseStatus ResponseStatus { get; set; }
        public List<SKU> Results { get; set; }
    }

    public class GetSKUSpecification
    {
        public long Id { get; set; }
    }
}
