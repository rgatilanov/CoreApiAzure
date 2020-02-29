using Microsoft.EntityFrameworkCore;


namespace CoreApiAzure.Models
{
    public class MyDatabaseContext: DbContext
    {
        public readonly string _connectionString = null;
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options)
           : base(options)
        {

        }



        //public MyDatabaseContext(string connectionString) 
        //{
        //    _connectionString = connectionString;
        //}

    }
}
