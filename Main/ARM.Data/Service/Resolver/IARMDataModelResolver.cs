using System;
using System.Collections.Generic;
using ARM.Core.Enums;

namespace ARM.Data.Sevice.Resolver
{
    public interface IARMDataModelResolver
    {
        object GetDataModel(eARMMetadata metadata, Guid id, bool isIdEmpty);
        IEnumerable<object> GetAllByMetadata(eARMMetadata metadata);
    }
}