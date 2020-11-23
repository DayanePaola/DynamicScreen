using System.Collections.Generic;

namespace DynamicScreen.Data.Models
{
    public class ConfigurationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool Enable { get; set; }

        public virtual ICollection<ConfigurationColumnModel> ConfigurationColumn { get; set; }
        public virtual ICollection<ConfigurationRowModel> ConfigurationRow { get; set; }
    }
}