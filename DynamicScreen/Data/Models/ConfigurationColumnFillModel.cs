namespace DynamicScreen.Data.Models
{
    public class ConfigurationColumnFillModel : Entity
    {
        public int ConfigurationColumnSourceId { get; set; }
        public int ConfigurationColumnDestinationId { get; set; }

        public virtual ConfigurationColumnModel ConfigurationColumnSource { get; set; }
        public virtual ConfigurationColumnModel ConfigurationColumnDestination { get; set; }
    }
}
