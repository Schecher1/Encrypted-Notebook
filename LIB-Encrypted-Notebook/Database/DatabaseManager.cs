using LIB_Encrypted_Notebook.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LIB_Encrypted_Notebook.Database
{
    public class DatabaseManager : DbContext
    {
        //link to the table
        public DbSet<DataModelNotebook> Notebook { get; set; }
        public DbSet<DataModelSalt> Salt { get; set; }
        public DbSet<DataModelSetting> Setting { get; set; }
        public DbSet<DataModelUser> User { get; set; }

        //DataCache ConnectionString
        private string IpAdresse { get; set; }
        private string DatabaseName { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }

        //Set Connection String Vars
        public DatabaseManager(string IpAddress, string DatabaseName, string Username, string Password)
        {
            this.IpAdresse = IpAddress;
            this.DatabaseName = DatabaseName;
            this.Username = Username;
            this.Password = Password;
        }

        //idk how to describe it, it works
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //connection string
            optionsBuilder.UseMySQL($"Server={IpAdresse};Database={DatabaseName};Uid={Username};Pwd={Password}");
        }


        public bool IsDbConnected()
        {
            throw new NotImplementedException();
        }

        public int CheckIfServerIsConfigured()
        {
            throw new NotImplementedException();
        }
    }
}
