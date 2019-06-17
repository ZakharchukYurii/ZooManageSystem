using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZMS.BLL.Abstracts;
using ZMS.DAL.Context;
using ZMS.Exceptions;
using ZMS.Models;

namespace ZMS.DAL.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly DataContext _dataBase;

        public EmployeeRepository(DataContext dataContext)
        {
            _dataBase = dataContext;
        }

        public void Create(Employee item)
        {
            _dataBase.Employees.Add(item);
        }

        public void Delete(int id)
        {
            var employee = _dataBase.Employees.Find(id);

            if (employee != null)
            {
                _dataBase.Employees.Remove(employee);
            }
        }

        public IEnumerable<Employee> Find(Func<Employee, bool> predicate)
        {
            var result = _dataBase.Employees.Where(predicate).ToList();

            if (result.Count < 1)
                throw new NullDataException();

            return result;
        }

        public Employee Get(int id)
        {
            var result = _dataBase.Employees.Find(id);

            if (result == null)
                throw new NullDataException();

            return result;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _dataBase.Employees.ToList();
        }

        public void Update(Employee item)
        {
            _dataBase.Entry(item).State = EntityState.Modified;
        }
    }
}
