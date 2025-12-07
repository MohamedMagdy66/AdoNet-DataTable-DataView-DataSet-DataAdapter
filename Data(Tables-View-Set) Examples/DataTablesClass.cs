using System;
using System.Data;

namespace Data_Tables_View_Set__Examples
{
    public class DataTablesClass
    {
        public DataTable EmployeeDT { get; } = new DataTable("EmployeesDataTable");
        public DataTable DepartmentDT { get; } = new DataTable("DepartmentsDataTable");

        public DataTablesClass()
        {
            // Initialize Employees table 
            InitEmployeesTable();

            // Initialize Departments table 
            InitDepartmentsTable();
        }

        private void InitEmployeesTable()
        {
            // Avoid double initialization
            if (EmployeeDT.Columns.Count > 0) return;

            // Create Employee columns
            EmployeeDT.Columns.Add("ID", typeof(int));
            EmployeeDT.Columns.Add("Name", typeof(string));
            EmployeeDT.Columns.Add("Country", typeof(string));
            EmployeeDT.Columns.Add("Salary", typeof(double));
            EmployeeDT.Columns.Add("Date", typeof(DateTime));

            // Make Employee Id column as Primary Key
            DataColumn[] primaryKeyColumns = new DataColumn[1];
            primaryKeyColumns[0] = EmployeeDT.Columns["ID"];
            EmployeeDT.PrimaryKey = primaryKeyColumns;

            // Add Employee rows
            EmployeeDT.Rows.Add(1, "John Doe", "USA", 60000, DateTime.Parse("2022-01-15"));
            EmployeeDT.Rows.Add(2, "Jane Smith", "UK", 75000, DateTime.Parse("2021-03-22"));
            EmployeeDT.Rows.Add(3, "Sam Brown", "EGY", 50000, DateTime.Parse("2020-07-30"));
            EmployeeDT.Rows.Add(4, "Lisa White", "UAE", 80000, DateTime.Parse("2019-11-12"));
            EmployeeDT.Rows.Add(5, "Tom Green", "USA", 72000, DateTime.Parse("2023-05-05"));
        }

        private void InitDepartmentsTable()
        {
            if (DepartmentDT.Columns.Count > 0) return;

            // Create DepartmentDT columns
            DepartmentDT.Columns.Add("DeptID", typeof(int));
            DepartmentDT.Columns.Add("DeptName", typeof(string));

            // Make DeptID column as Primary Key
            DataColumn[] deptPkColumns = new DataColumn[1];
            deptPkColumns[0] = DepartmentDT.Columns["DeptID"];
            DepartmentDT.PrimaryKey = deptPkColumns;

            // Add DepartmentDT rows
            DepartmentDT.Rows.Add(1, "Marketing");
            DepartmentDT.Rows.Add(2, "IT");
            DepartmentDT.Rows.Add(3, "HR");
        }

        // ================= DISPLAY =================

        public void DisplayEmployeeDataTble()
        {
            Console.WriteLine("Employees List");
            Console.WriteLine("=================\n");

            foreach (DataRow row in EmployeeDT.Rows)
            {
                Console.WriteLine(
                    $"ID: {row["ID"]}\t Name: {row["Name"]}\t " +
                    $"Country: {row["Country"]}\t Salary: {row["Salary"]}\t Date: {row["Date"]}"
                );
            }
        }

        public void DisplayDepartmentDataTble()
        {
            Console.WriteLine("Departments List");
            Console.WriteLine("=================\n");

            foreach (DataRow row in DepartmentDT.Rows)
            {
                Console.WriteLine($"ID: {row["DeptID"]}\t Name: {row["DeptName"]}");
            }
        }

        // ================= AGGREGATIONS =================

        public void DisplayEmployeeAggregations()
        {
            Console.WriteLine("Employee Aggregations");
            Console.WriteLine("===================\n");

            int employeeCount = EmployeeDT.Rows.Count;
            double totalSalary = Convert.ToDouble(EmployeeDT.Compute("SUM(Salary)", string.Empty));
            double averageSalary = Convert.ToDouble(EmployeeDT.Compute("AVG(Salary)", string.Empty));
            double maxSalary = Convert.ToDouble(EmployeeDT.Compute("MAX(Salary)", string.Empty));
            double minSalary = Convert.ToDouble(EmployeeDT.Compute("MIN(Salary)", string.Empty));

            Console.WriteLine($"Employees Count: {employeeCount}");
            Console.WriteLine($"Total Salary: {totalSalary}");
            Console.WriteLine($"Average Salary: {averageSalary}");
            Console.WriteLine($"Max Salary: {maxSalary}");
            Console.WriteLine($"Min Salary: {minSalary}");
        }

        public void DisplayEmployeeAggregationFilteredByCountryName(string country)
        {
            Console.WriteLine($"Filter by countryName '{country}' on aggregation");
            Console.WriteLine("=================================================\n");

            string filter = $"Country = '{country}'";

            int employeeCount = EmployeeDT.Select(filter).Length;
            double totalSalary = Convert.ToDouble(EmployeeDT.Compute("SUM(Salary)", filter));
            double averageSalary = Convert.ToDouble(EmployeeDT.Compute("AVG(Salary)", filter));
            double maxSalary = Convert.ToDouble(EmployeeDT.Compute("MAX(Salary)", filter));
            double minSalary = Convert.ToDouble(EmployeeDT.Compute("MIN(Salary)", filter));

            Console.WriteLine($"Employees Count: {employeeCount}");
            Console.WriteLine($"Total Salary: {totalSalary}");
            Console.WriteLine($"Average Salary: {averageSalary}");
            Console.WriteLine($"Max Salary: {maxSalary}");
            Console.WriteLine($"Min Salary: {minSalary}");
        }

        public void DisplayEmployeeAggregationFilteredByCountriesName(string country1, string country2)
        {
            Console.WriteLine($"Filtered by {country1} or {country2} on Aggregations");
            Console.WriteLine("======================================================\n");

            string filter = $"Country = '{country1}' OR Country = '{country2}'";

            int employeeCount = EmployeeDT.Select(filter).Length;
            double totalSalary = Convert.ToDouble(EmployeeDT.Compute("SUM(Salary)", filter));
            double averageSalary = Convert.ToDouble(EmployeeDT.Compute("AVG(Salary)", filter));
            double maxSalary = Convert.ToDouble(EmployeeDT.Compute("MAX(Salary)", filter));
            double minSalary = Convert.ToDouble(EmployeeDT.Compute("MIN(Salary)", filter));

            Console.WriteLine($"Employees Count: {employeeCount}");
            Console.WriteLine($"Total Salary: {totalSalary}");
            Console.WriteLine($"Average Salary: {averageSalary}");
            Console.WriteLine($"Max Salary: {maxSalary}");
            Console.WriteLine($"Min Salary: {minSalary}");
        }

        // ================= FILTERING =================

        public void DisplayEmployeeFilterationByCountry(string country)
        {
            Console.WriteLine($"Filter Employee by countryName: {country}");
            Console.WriteLine("========================================\n");

            DataRow[] resultRows = EmployeeDT.Select($"Country = '{country}'");
            int resultCount = 0;

            foreach (DataRow row in resultRows)
            {
                Console.WriteLine(
                    $"ID: {row["ID"]}, Name: {row["Name"]}, " +
                    $"Country: {row["Country"]}, Salary: {row["Salary"]}, Date: {row["Date"]}"
                );
                resultCount++;
            }

            Console.WriteLine($"\nTotal Employees Found: {resultCount}");
        }

        public void DisplayEmployeeFilterationByCountries(string country1, string country2)
        {
            Console.WriteLine($"Filter Employee by countries Name: {country1} or {country2}");
            Console.WriteLine("==========================================================\n");

            DataRow[] resultRows = EmployeeDT.Select(
                $"Country = '{country1}' OR Country = '{country2}'"
            );
            int resultCount = 0;

            foreach (DataRow row in resultRows)
            {
                Console.WriteLine(
                    $"ID: {row["ID"]}, Name: {row["Name"]}, " +
                    $"Country: {row["Country"]}, Salary: {row["Salary"]}, Date: {row["Date"]}"
                );
                resultCount++;
            }

            Console.WriteLine($"\nTotal Employees Found: {resultCount}");
        }

        // ================= SORTING =================

        public void DescendingIDSorting()
        {
            Console.WriteLine("Sorting Employee by ID in Descending Order:");
            Console.WriteLine("=========================================\n");

            EmployeeDT.DefaultView.Sort = "ID DESC";
            DataView view = EmployeeDT.DefaultView;

            foreach (DataRowView row in view)
            {
                Console.WriteLine(
                    $"ID: {row["ID"]}, Name: {row["Name"]}, " +
                    $"Country: {row["Country"]}, Salary: {row["Salary"]}, Date: {row["Date"]}"
                );
            }
        }

        public void NameAscendingSort()
        {
            Console.WriteLine("Sorting Employee by Name in Ascending Order:");
            Console.WriteLine("==========================================\n");

            EmployeeDT.DefaultView.Sort = "Name ASC";
            DataView view = EmployeeDT.DefaultView;

            foreach (DataRowView row in view)
            {
                Console.WriteLine(
                    $"ID: {row["ID"]}, Name: {row["Name"]}, " +
                    $"Country: {row["Country"]}, Salary: {row["Salary"]}, Date: {row["Date"]}"
                );
            }
        }

        public void SalaryDescendingSort()
        {
            Console.WriteLine("Sorting Employee by Salary in Descending Order:");
            Console.WriteLine("=============================================\n");

            EmployeeDT.DefaultView.Sort = "Salary DESC";
            DataView view = EmployeeDT.DefaultView;

            foreach (DataRowView row in view)
            {
                Console.WriteLine(
                    $"ID: {row["ID"]}, Name: {row["Name"]}, " +
                    $"Country: {row["Country"]}, Salary: {row["Salary"]}, Date: {row["Date"]}"
                );
            }
        }

        // ================= DELETE / UPDATE / CLEAR =================

        public void DeleteRow(int rowID)
        {
            DataRow[] result = EmployeeDT.Select($"ID = {rowID}");

            foreach (DataRow row in result)
            {
                EmployeeDT.Rows.Remove(row);
            }

            Console.WriteLine($"After deleting row with ID = {rowID}:");

            foreach (DataRow row in EmployeeDT.Rows)
            {
                Console.WriteLine(
                    $"ID: {row["ID"]}, Name: {row["Name"]}, " +
                    $"Country: {row["Country"]}, Salary: {row["Salary"]}, Date: {row["Date"]}"
                );
            }
        }

        public void UpdateRow(int rowID, string name, double salary, string country)
        {
            DataRow[] resultUpdate = EmployeeDT.Select($"ID = {rowID}");

            foreach (DataRow row in resultUpdate)
            {
                row["Name"] = name;
                row["Salary"] = salary;
                row["Country"] = country;
            }

            Console.WriteLine($"After updating row with ID = {rowID}:");

            foreach (DataRow row in EmployeeDT.Rows)
            {
                Console.WriteLine(
                    $"ID: {row["ID"]}, Name: {row["Name"]}, " +
                    $"Country: {row["Country"]}, Salary: {row["Salary"]}, Date: {row["Date"]}"
                );
            }
        }

        public void ClearDataTable()
        {
            EmployeeDT.Clear();
            if (EmployeeDT.Rows.Count == 0)
            {
                Console.WriteLine("Employee DataTable is Empty Now");
            }
        }
    }
}
