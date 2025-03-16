using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Ps1.DAL.Model;

namespace Company.Ps1.BIL.Repositry
{
    public interface IDepartment1
    {
       IEnumerable<Department> getall();
       Department? Get(int id);

       int add(Department department);
       int update(Department department);
       int delete(Department department);
    }
}
