using ARM.Data.Interfaces.Session;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Session
{
    /// <summary>
    /// Контекст бази даних для сесій
    /// </summary>
    public class SessionContext : BaseContext<Models.Session>, ISessionContext
    {
    }
}