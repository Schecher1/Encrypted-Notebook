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
        private string DatabaseName { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }

        public DatabaseManager(string IpAddress, string DatabaseName, string Username, string Password)
        {
            this.IpAdresse = IpAddress;
            this.DatabaseName = DatabaseName;
            this.Username = Username;
            this.Password = Password;
        }

        public void SaveNotebook(string newNotes)
        {
            throw new NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //connection string
            optionsBuilder.UseMySQL($"Server={IpAdresse};Database={DatabaseName};Uid={Username};Pwd={Password}");
        }

        public void DeleteUser()
        {
            throw new NotImplementedException();
        }

        public List<DataModelNotebook> GetAllNotebooks()
        {
            throw new NotImplementedException();
        }

        public bool DbConnect()
        {
            throw new NotImplementedException();
        }

        public bool LoginUser(string text, string password)
        {
            throw new NotImplementedException();
        }

        public int CheckIfServerIsConfigured()
        {
            throw new NotImplementedException();
        }

        public string ReadNotesFromNotebook()
        {
            throw new NotImplementedException();
        }

        public void CreateNotebook(string text)
        {
            throw new NotImplementedException();
        }

        public void DeleteNotebook(string v)
        {
            throw new NotImplementedException();
        }

        public int CheckIfUserExist(string v)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(string text, string password)
        {
            throw new NotImplementedException();
        }
    }
}
