using System.Data.Entity;
using ARM.Data.Interfaces.University;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.University
{
    public class UniversityContext : BaseContext<Models.University>,IUniversityContext
    {

    }
}