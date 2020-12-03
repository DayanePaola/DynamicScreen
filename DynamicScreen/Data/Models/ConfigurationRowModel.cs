using System.Collections.Generic;

namespace DynamicScreen.Data.Models
{
    public class ConfigurationRowModel : Entity
    {
        public int ConfigurationId { get; set; }
        public int Index { get; set; }

        public virtual ConfigurationModel Configuration { get; set; }
        public virtual ICollection<ConfigurationValueModel> ConfigurationValue { get; set; }
    }
}