using ARM.Data.Interfaces.Faculty;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Faculty
{
    /// <summary>
    /// Контекст бази даних для факультетів
    /// </summary>
    public class FacultyContext : BaseContext<Models.Faculty>, IFacultyContext
    {
    }
}