namespace DynamicScreen.Data.Models
{
    public class ConfigurationValueModel : Entity
    {
        public int ConfigurationColumnId { get; set; }
        public int ConfigurationRowId { get; set; }
        public string Value { get; set; }

        public virtual ConfigurationColumnModel ConfigurationColumn { get; set; }
        public virtual ConfigurationRowModel ConfigurationRow { get; set; }
    }
}