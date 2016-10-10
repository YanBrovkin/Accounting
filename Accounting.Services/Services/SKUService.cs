using Accounting.Contracts;
using Accounting.Contracts.DTO;
using Accounting.Contracts.References;
using ServiceStack.ServiceInterface;
using System.Collections.Generic;

namespace Accounting.Services.Services
{
    public class SKUService: Service
    {
        private readonly IRead<GetSKUSpecification, List<SKU>> skuReader;
        public SKUService(IRead<GetSKUSpecification, List<SKU>> skuReader)
        {
            this.skuReader = skuReader;
        }
        public GetSKUResponse Get(GetSKURequest request)
        {
            var foundSKUs = skuReader.Get(new GetSKUSpecification { Id = request.Id });

            return new GetSKUResponse { Results = foundSKUs };
        }
    }
}
