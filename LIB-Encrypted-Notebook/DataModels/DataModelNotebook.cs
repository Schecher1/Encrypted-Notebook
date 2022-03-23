namespace LIB_Encrypted_Notebook.DataModels
{
    public class DataModelNotebook
    {
        public int Notebook_ID { get; set; }
        public string Notebook_Name { get; set; }
        public string Notebook_Value { get; set; }
        public DataModelSalt Notebook_Salt { get; set; }
    }
}