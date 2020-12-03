using System.Collections.Generic;

namespace DynamicScreen.Data.Models
{
    public class ConfigurationModel : Entity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public bool Enable { get; set; }
        public int Index { get; set; }

        public virtual ICollection<ConfigurationColumnModel> ConfigurationColumn { get; set; }
        public virtual ICollection<ConfigurationRowModel> ConfigurationRow { get; set; }
    }
}