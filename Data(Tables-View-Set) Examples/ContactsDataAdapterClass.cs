using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Tables_View_Set__Examples
{
    public class ContactsDataAdapterClass
    {
        private readonly string _connectionString;
        public DataSet ContactsDataSet { get; private set; } = new DataSet();

        public ContactsDataAdapterClass(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void LoadContacts()
        {
            string selectQuery = "SELECT * FROM Contacts";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection))
            {
                connection.Open();
                dataAdapter.Fill(ContactsDataSet, "ContactsTable");
            }
        }

        public void PrintContacts()
        {
            DataTable contactTable = ContactsDataSet.Tables["ContactsTable"];

            foreach (DataRow row in contactTable.Rows)
            {
                Console.WriteLine($"ID: {row["ContactID"]}, Name: {row["FirstName"]} {row["LastName"]}, " +
                    $"Email: {row["Email"]}, Phone: {row["Phone"]}, Address: {row["Address"]}");
            }
        }
    }
}
