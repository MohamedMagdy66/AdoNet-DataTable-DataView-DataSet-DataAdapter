# AdoNet-DataTable-DataView-DataSet-DataAdapter
# ADO.NET DataTable / DataView / DataSet / DataAdapter Demo

This repository contains a small C# .NET console application that demonstrates how to work with core ADO.NET components:

- `DataTable`
- `DataView`
- `DataSet`
- `SqlDataAdapter`

The project focuses on learning and practicing **in-memory data handling** and **ADO.NET fundamentals** using a clean, object-oriented structure.

---

## 🎯 Project Goals

- Understand how `DataTable`, `DataView`, `DataSet`, and `DataAdapter` work together.
- Practice in-memory CRUD operations (Create, Read, Update, Delete) using `DataTable`.
- Use `DataView` for **sorting** and **filtering** without changing the original data.
- Use `DataSet` to group multiple tables together (like a mini in-memory database).
- Connect to a real SQL Server database using `SqlDataAdapter`.
- Apply **OOP principles** and **separation of concerns** by splitting logic into multiple classes.

---

## 🧩 Technologies & Namespaces

- **Language:** C#
- **Runtime:** .NET (Console App)
- **Data Access:** ADO.NET
- **Database:** SQL Server (for the `Contacts` example)
- **Main namespace:** `System.Data`
- **Key namespaces used:**
  - `System.Data`
  - `System.Data.SqlClient` (or `Microsoft.Data.SqlClient` depending on your setup)

> All ADO.NET classes used in this project (`DataTable`, `DataView`, `DataSet`, `SqlDataAdapter`) belong to the `System.Data` family.

---

## 🗂 Project Structure

```text
.
├── Program.cs
├── DataTablesClass.cs
├── DataViewClass.cs
├── DataSetsClass.cs
└── ContactsDataAdapterClass.cs
```
<hr>


## Program.cs

  The main entry point of the application.
  It runs a sequence of demos:
  ```text
  - DataTable demo (display, aggregation, filtering, sorting, update, delete).
  - DataView demo (display, sort, filter).
  - DataSet demo (printing employees and departments).
  - DataAdapter demo (loading and printing contacts from SQL Server).
```
## 🧱 Class Responsibilities

**1️⃣ DataTablesClass**

  Responsible for:
  
  ```text
        - Creating and initializing two DataTable instances:
            * EmployeeDT (EmployeesDataTable).
            * DepartmentDT (DepartmentsDataTable).
            
        - Defining primary keys.
        - Seeding sample data.
        - Providing methods to:
      
        -  Display methods:
            * DisplayEmployeeDataTble()
            * DisplayDepartmentDataTble()
      
        - Aggregation methods(Using DataTable.Compute):
            * DisplayEmployeeAggregations() --> [SUM, AVG, MAX, MIN for all employees]
            * DisplayEmployeeAggregationFilteredByCountryName(string country)
            * DisplayEmployeeAggregationFilteredByCountriesName(string country1, string country2)
      
        - Filtering methods(Using DataTable.Select):
            * DisplayEmployeeFilterationByCountry(string country)
            * DisplayEmployeeFilterationByCountries(string country1, string country2)
      
        - Sorting methods(Using DefaultView.Sort):
            * DescendingIDSorting()
            * NameAscendingSort()
            * SalaryDescendingSort()
      
        - Row operations:
            *  DeleteRow(int rowID) → delete employee by ID
            *  UpdateRow(int rowID, string name, double salary, string country) → update employee data
            *  ClearDataTable() → clear all employee rows
  ```
  **2️⃣ DataViewClass**

  Responsible for working with a DataView based on the employees DataTable.
  
  ```text
  - Methods:
    * DisplayFromDataView().
    * Display all rows from the DataView.
    * SortFromDataView().
    * Sort by Salary ASC using DataView.Sort.
    * FilteredFromDataView(string country).
    * Filter employees by country using RowFilter.
  ```
  
  **3️⃣ DataSetsClass**
  
  Responsible for connecting to a real SQL Server database and loading data using SqlDataAdapter:
  
  ```text
  - Methods:
    * PrintEmployees().
    * Reads from dataset1.Tables["EmployeesDataTable"].
    * PrintDepartments().
    * Reads from dataset1.Tables["DepartmentsDataTable"].
  ```
  **4️⃣ ContactsDataAdapterClass**
  
  Responsible for grouping multiple DataTable objects into a single DataSet:
  
  ```text
  - Methods:
    * LoadContacts().
    * Uses SqlConnection and SqlDataAdapter.
    * Executes SELECT * FROM Contacts.
    * Fills a DataSet named ContactsDataSet.
    * PrintContacts().
    * Reads from ContactsDataSet.Tables["ContactsTable"].
    * Prints contact details (ID, Name, Email, Phone, Address)
  ``` 
