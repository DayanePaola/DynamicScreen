namespace DynamicScreen.Data.Models
{
    public class ConfigurationColumnFillModel
    {
        public int Id { get; set; }
        public int ConfigurationColumnSourceId { get; set; }
        public int ConfigurationColumnDestinationId { get; set; }
        public int DestinationIndex { get; set; }

        public virtual ConfigurationColumnModel ConfigurationColumnSource { get; set; }
        public virtual ConfigurationColumnModel ConfigurationColumnDestination { get; set; }
    }
}
