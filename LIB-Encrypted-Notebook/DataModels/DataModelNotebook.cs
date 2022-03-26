using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIB_Encrypted_Notebook.DataModels
{
    public class DataModelNotebook
    {
        [Key]
        public int Notebook_ID { get; set; }

        [Required]
        [MaxLength(128)]
        public string Notebook_Name { get; set; }

        [Column(TypeName = "LONGTEXT")]
        public string? Notebook_Value { get; set; }

        [Required]
        public int Notebook_Owner_ID { get; set; }
    }
}