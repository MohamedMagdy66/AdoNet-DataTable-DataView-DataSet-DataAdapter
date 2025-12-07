using Data_Tables_View_Set__Examples;

//--------------------------------- Data Table --------------------------------------------------
Console.WriteLine("========== DataTable Demo ==========\n");

// Create object from DataTableClass
DataTablesClass DataTableClass1 = new DataTablesClass();

// Get all employes
DataTableClass1.DisplayEmployeeDataTble();
Console.WriteLine("\n");

// Get all Departments
DataTableClass1.DisplayDepartmentDataTble();
Console.WriteLine("\n");

//====== Aggregation methods on Employees ======
DataTableClass1.DisplayEmployeeAggregations();
Console.WriteLine("\n");

// Filter Using Aggregation
DataTableClass1.DisplayEmployeeFilterationByCountry("USA");
Console.WriteLine("\n");

DataTableClass1.DisplayEmployeeAggregationFilteredByCountryName("USA");
Console.WriteLine("\n");


DataTableClass1.DisplayEmployeeFilterationByCountries("USA", "UK");
Console.WriteLine("\n");

DataTableClass1.DisplayEmployeeAggregationFilteredByCountriesName("USA","UK");
Console.WriteLine("\n");

//====== Sorting Employees ======

//ID DESC Sorting
DataTableClass1.DescendingIDSorting();
Console.WriteLine("\n");

//Name ASC Sorting
DataTableClass1.NameAscendingSort();
Console.WriteLine("\n");

//Salary DESC Sorting
DataTableClass1.SalaryDescendingSort();
Console.WriteLine("\n");

//====== Deleting, Updating, Clearing Rows in Employees Data Table ======
//Delete Row in Data Table
DataTableClass1.DeleteRow(3);
Console.WriteLine("\n");

//Update Row in Data Table
DataTableClass1.UpdateRow(2, "Updated Name",9999, "Updated Country");
Console.WriteLine("\n");

////Clear Data Table
//DataTableClass1.ClearDataTable();
//Console.WriteLine("\n");

//--------------------------------- End Of Data Table --------------------------------------------------

//---------------------------------Data View --------------------------------------------------
Console.WriteLine("\n========== DataView Demo ==========\n");

//Create DataView
DataViewClass dataViewClass1 = new DataViewClass(DataTableClass1);

//Display from DataView
dataViewClass1.DisplayFromDataView();
Console.WriteLine("\n");

//Sort from DataView
dataViewClass1.SortFromDataView();
Console.WriteLine("\n");

//Filtered from DataView
dataViewClass1.FilteredFromDataView("USA");
Console.WriteLine("\n");

//--------------------------------- End Of Data View --------------------------------------------------

//--------------------------------- Data Set --------------------------------------------------
Console.WriteLine("\n========== DataSet Demo ==========\n");

//------Create object from DataSet-------
DataSetsClass datasetClass1 = new DataSetsClass(DataTableClass1);


Console.WriteLine("printing employees from the dataset");
Console.WriteLine("=================================\n");
datasetClass1.PrintEmployees();
Console.WriteLine("\n");

Console.WriteLine("printing Departments from the dataset");
Console.WriteLine("=================================\n");
datasetClass1.PrintDepartments();
Console.WriteLine("\n");
//--------------------------------- End of Data Set --------------------------------------------------

//--------------------------------- Data Adapter --------------------------------------------------

string ConnectionString = "Server=.;Database=ContactsDataBase;User Id=mego;Password=Sa123456;Encrypt=True;TrustServerCertificate=True;";

ContactsDataAdapterClass contactsHandler = new ContactsDataAdapterClass(ConnectionString);

contactsHandler.LoadContacts();
contactsHandler.PrintContacts();

//--------------------------------- End of Data Adapter --------------------------------------------------