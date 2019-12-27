using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFNgWebApp.Models
{
    public class EmployeeDataAccessLayer
    {

        FBIDeltaContext _db = new FBIDeltaContext();
        public IEnumerable<TblEmployee> GetAllEmployees()
        {
            try
            {
                return _db.TblEmployee.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new employee record   
        public int AddEmployee(TblEmployee employee)
        {
            try
            {
                _db.TblEmployee.Add(employee);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar employee  
        public int UpdateEmployee(TblEmployee employee)
        {
            try
            {
                _db.Entry(employee).State = EntityState.Modified;
                _db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular employee  
        public TblEmployee GetEmployeeData(int id)
        {
            try
            {
                TblEmployee employee = _db.TblEmployee.Find(id);
                return employee;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular employee  
        public int DeleteEmployee(int id)
        {
            try
            {
                TblEmployee emp = _db.TblEmployee.Find(id);
                _db.TblEmployee.Remove(emp);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Get the list of Cities  
        public List<TblCities> GetCities()
        {
            List<TblCities> lstCity = new List<TblCities>();
            lstCity = (from CityList in _db.TblCities select CityList).ToList();

            return lstCity;
        }

    }
}
