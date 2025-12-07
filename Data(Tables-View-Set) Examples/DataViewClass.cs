using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tables_View_Set__Examples
{
    public class DataViewClass
    {
        private readonly DataView _employeesDV;
        public DataViewClass(DataTablesClass tables)
        {
            _employeesDV = new DataView(tables.EmployeeDT);
        }
        
        public void DisplayFromDataView() {
            Console.WriteLine("DataView of Employees DataTable: \n");
            for (int i = 0; i < _employeesDV.Count; i++)
            {
                Console.WriteLine($"{_employeesDV[i]["ID"]}, {_employeesDV[i]["Name"]}, " +
                $"{_employeesDV[i]["Country"]}, {_employeesDV[i]["Salary"]}, {_employeesDV[i]["Date"]}");
            }
        }
        public void SortFromDataView() 
        {
            Console.WriteLine("Sort Data View of Employees DataTable: \n");
            _employeesDV.Sort = "Salary asc";
            for (int i = 0; i < _employeesDV.Count; i++)
            {
                Console.WriteLine($"{_employeesDV[i]["ID"]}, {_employeesDV[i]["Name"]}, " +
                $"{_employeesDV[i]["Country"]}, {_employeesDV[i]["Salary"]}, {_employeesDV[i]["Date"]}");
            }
        }
        public void FilteredFromDataView(string country) 
        {
            Console.WriteLine("Filter Data View of Employees DataTable: \n");
            _employeesDV.RowFilter = $"Country = '{country}'";
            for (int i = 0; i < _employeesDV.Count; i++)
            {
                Console.WriteLine($"{_employeesDV[i]["ID"]}, {_employeesDV[i]["Name"]}, " +
                $"{_employeesDV[i]["Country"]} ,  {_employeesDV[i]["Salary"]}, {_employeesDV[i]["Date"]}");
            }
        }

    }
}
