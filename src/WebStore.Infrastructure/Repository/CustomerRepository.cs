using System.Data;
using System.Linq.Expressions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebStore.Domain.Entities;
using WebStore.Domain.Interfaces;

namespace WebStore.Infra.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private static string dbSchema = "dbo";

        private IConfiguration _configuration;
        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection GetConnection()
        {
            var conn = new SqlConnection(GetConnectionString());
            return conn;
        }

        private string? GetConnectionString()
        {
            return this._configuration.GetConnectionString("DefaultConnection");
        }

        public static class StoredProcedures
        {
            public static string AddCustomer = $"{dbSchema}.spAddCustomer";
            public static string DeleteCustomer = $"{dbSchema}.spDeleteCustomer";
            public static string UpdateCustomer = $"{dbSchema}.spUpdateCustomer";
            public static string GetAllCustomer = $"{dbSchema}.spGetAllCustomer";
        }
        
        public virtual async Task CreateAsync(Customer customer)
        {
            try
            {
                await using SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand(StoredProcedures.AddCustomer, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", customer.Id);
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(Customer customer)
        {
            try
            {
                await using SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand(StoredProcedures.UpdateCustomer, con);  
                cmd.CommandType = CommandType.StoredProcedure;  
  
                cmd.Parameters.AddWithValue("@Id", customer.Id.ToString());  
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);  
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);  
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Address", customer.Address);  
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            Customer customer = null;

            await using SqlConnection con = GetConnection();
            string sqlQuery = $"SELECT * FROM Customer WHERE Id='{id}' ";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);  
            con.Open();  
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();  
  
            while (rdr.Read())  
            {  
                customer = new Customer(Guid.Parse(rdr["Id"].ToString()), rdr["FirstName"].ToString(), rdr["LastName"].ToString(), rdr["Email"].ToString(), rdr["Address"].ToString());
            }

            return customer;
        }
        public async Task<List<Customer>> GetAllAsync()
        {
            Customer customer = null;
            List<Customer> lstCustomer = new List<Customer>();
            await using SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(StoredProcedures.GetAllCustomer, con);  
            cmd.CommandType = CommandType.StoredProcedure;  
            con.Open();  
            SqlDataReader rdr = await cmd.ExecuteReaderAsync();  
  
            while (rdr.Read())  
            {  
                customer = new Customer(Guid.Parse(rdr["Id"].ToString()), rdr["FirstName"].ToString(), rdr["LastName"].ToString(), rdr["Email"].ToString(), rdr["Address"].ToString());
  
                lstCustomer.Add(customer);  
            }  
            con.Close();
            return lstCustomer;  
        }

        public async Task RemoveAsync(Guid id)
        {
            try
            {
                await using SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand(StoredProcedures.DeleteCustomer, con);  
                cmd.CommandType = CommandType.StoredProcedure;  
                cmd.Parameters.AddWithValue("@Id", id);  
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<IEnumerable<Customer>> Search(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}