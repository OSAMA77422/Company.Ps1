using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Ps1.BIL.Repositry;
using Company.Ps1.DAL.Data.DBContexts;
using Company.Ps1.DAL.Model;

namespace Company.Ps1.BIL.Repositeries
{
    public class DepartmentRepo : IDepartment1
    {
        private readonly CompanyBDContext _dbContext;
        public DepartmentRepo()
        { 
            _dbContext = new CompanyBDContext();
        }
        public int add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }

        public int delete(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }

        public Department? Get(int id)
        {
           return _dbContext.Departments.Find(id);
        }

        public IEnumerable<Department> getall()
        {
            return _dbContext.Departments.ToList();
        }

        public int update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }
    }
}
