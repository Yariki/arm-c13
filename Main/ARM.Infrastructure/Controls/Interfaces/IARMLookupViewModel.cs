using System;
using System.Collections.Generic;
using ARM.Core.Enums;
using ARM.Core.Interfaces;

namespace ARM.Infrastructure.Controls.Interfaces
{
    public interface IARMLookupViewModel : IARMViewModel
    {
        IEnumerable<object> Source { get; }

        eARMMetadata Metadata { get; }

        Type EntityType { get; }

        object SelectedItem { get; set; }

        void Initialize(eARMMetadata metadata);
    }
}