using System.ComponentModel.DataAnnotations;

namespace LIB_Encrypted_Notebook.DataModels
{
    public class DataModelUser
    {
        [Key]
        public int User_ID { get; set; }

        [Required]
        public string User_Name { get; set; }

        [Required]
        public string User_Password { get; set; }

        public List<DataModelNotebook> User_Notebooks { get; set; }
    }
}
