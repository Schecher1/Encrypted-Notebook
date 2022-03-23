using System.ComponentModel.DataAnnotations;

namespace LIB_Encrypted_Notebook.DataModels
{
    public class DataModelNotebook
    {
        [Key]
        public int Notebook_ID { get; set; }

        [Required]
        public string Notebook_Name { get; set; }


        public string Notebook_Value { get; set; }

        [Required]
        public DataModelSalt Notebook_Salt { get; set; }
    }
}