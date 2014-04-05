using ARM.Data.Interfaces.Student;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Student
{
    public class StudentContext : BaseContext<Models.Student>,IStudentContext
    {
         
    }
}