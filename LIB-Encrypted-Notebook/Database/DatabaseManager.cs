
using LIB_Encrypted_Notebook.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LIB_Encrypted_Notebook.Database
{
    public class DatabaseManager : DbContext
    {
        //link to the table
        public DbSet<DataModelNotebook> notebook { get; set; }
        public DbSet<DataModelSalt> salt { get; set; }
        public DbSet<DataModelSetting> setting { get; set; }
        public DbSet<DataModelUser> user { get; set; }

        //DataCache ConnectionString
        private string IpAdresse { get; set; }
        private string Database { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }

        public DatabaseManager(string IpAddress, string Database, string Username, string Password)
        {
            this.IpAdresse = IpAddress;
            this.Database = Database;
            this.Username = Username;
            this.Password = Password;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //connection string
            optionsBuilder.UseMySQL($"Server={IpAdresse};Database={Database};Uid={Username};Pwd={Password}");
        }
    }
}
