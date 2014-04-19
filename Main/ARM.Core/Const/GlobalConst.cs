using System;

namespace ARM.Core.Const
{
    public static class GlobalConst
    {
        private const string GuidDefaultStr = "00000000-0000-0000-0000-000000000001";

        public static readonly Guid IdDefault = Guid.Parse(GuidDefaultStr);
    }
}