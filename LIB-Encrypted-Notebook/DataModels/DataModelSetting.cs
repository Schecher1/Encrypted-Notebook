using System.ComponentModel.DataAnnotations;

namespace LIB_Encrypted_Notebook.DataModels
{
    public class DataModelSetting
    {
        [Key]
        public int Setting_ID { get; set; }

        [Required]
        public string Setting_Name { get; set; }

        [Required]
        public string Setting_Value { get; set; }
    }
}
