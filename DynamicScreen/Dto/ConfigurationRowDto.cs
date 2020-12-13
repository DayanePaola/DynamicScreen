using System.Collections.Generic;

namespace DynamicScreen.Dto
{
    public class ConfigurationRowDto
    {
        public int Id { get; set; }
        public int ConfigurationId { get; set; }
        public int Index { get; set; }
        public List<ConfigurationValueDto> ConfigurationValue { get; set; }
    }
}