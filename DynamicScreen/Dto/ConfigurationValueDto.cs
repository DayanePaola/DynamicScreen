namespace DynamicScreen.Dto
{
    public class ConfigurationValueDto
    {
        public int Id { get; set; }
        public int ConfigurationColumnId { get; set; }
        public int ConfigurationRowId { get; set; }
        public string Value { get; set; }
        public ConfigurationColumnDto Column { get; set; }
    }
}