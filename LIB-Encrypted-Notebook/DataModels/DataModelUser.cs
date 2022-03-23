namespace LIB_Encrypted_Notebook.DataModels
{
    public class DataModelUser
    {
        public int User_ID { get; set; }
        public string User_Name { get; set; }
        public string User_Password { get; set; }
        public List<DataModelNotebook> User_Notebooks { get; set; }
    }
}
