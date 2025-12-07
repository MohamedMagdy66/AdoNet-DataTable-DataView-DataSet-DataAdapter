using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tables_View_Set__Examples
{
    public class DataSetsClass
    {
        public DataSet dataset1 { get; } = new DataSet("CompanyDataSet");
        
        public DataSetsClass(DataTablesClass tables)
        {
            dataset1.Tables.Add(tables.EmployeeDT);
            dataset1.Tables.Add(tables.DepartmentDT);
        }
    
        public void PrintEmployees() 
        {
            Console.WriteLine("Employees from DataSet:\n");
            
            foreach (DataRow row in dataset1.Tables["EmployeesDataTable"].Rows)
            {
                Console.WriteLine($"ID: {row["ID"]}|\t Name: {row["Name"]}|\t " +
                    $"Country: {row["Country"]}|\t Salary: {row["Salary"]}|\t Date: {row["Date"]}");
            }
        }
        public void PrintDepartments() 
        {
            Console.WriteLine("Departments from DataSet:\n");
            foreach (DataRow row in dataset1.Tables["DepartmentsDataTable"].Rows)
            {
                Console.WriteLine($"DeptID: {row["DeptID"]}| DeptName: {row["DeptName"]}");
            }
        }


    }
}
