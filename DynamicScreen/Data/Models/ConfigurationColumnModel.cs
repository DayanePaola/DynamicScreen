using System.Collections.Generic;

namespace DynamicScreen.Data.Models
{
    public class ConfigurationColumnModel : Entity
    {
        public int ConfigurationId { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Method { get; set; }
        public int Index { get; set; }
        public bool ReadOnly { get; set; }
        public string DataType { get; set; }
        public string Component { get; set; }

        public virtual ConfigurationModel Configuration { get; set; }
        public virtual ICollection<ConfigurationValueModel> ConfigurationValue { get; set; }
        public virtual ICollection<ConfigurationColumnFillModel> ConfigurationColumnSource { get; set; }
        public virtual ICollection<ConfigurationColumnFillModel> ConfigurationColumnDestination { get; set; }
    }
}
