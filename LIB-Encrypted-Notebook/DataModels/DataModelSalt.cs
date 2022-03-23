using System.ComponentModel.DataAnnotations;

namespace LIB_Encrypted_Notebook.DataModels
{
    public class DataModelSalt
    {
        [Key]
        public int Salt_ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Salt_Value { get; set; }
    }
}