using ARM.Data.Interfaces.Class;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Class
{
    /// <summary>
    /// Контекст бази даних для класів
    /// </summary>
    public class ClassContext : BaseContext<Models.Class>, IClassContext
    {
    }
}