using System;
using ARM.Core.Enums;

namespace ARM.Data.Sevice.Resolver
{
    public interface IARMDataModelResolver
    {
        object GetDataModel(eARMMetadata metadata, Guid id);
    }
}