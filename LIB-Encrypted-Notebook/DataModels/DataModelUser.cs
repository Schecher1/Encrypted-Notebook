using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIB_Encrypted_Notebook.DataModels
{
    public class DataModelUser
    {
        [Key]
        public int User_ID { get; set; }

        [Required]
        [MaxLength(128)]
        public string User_Name { get; set; }

        [Required]
        [MaxLength(128)]
        public string User_Password { get; set; }
    }
}
