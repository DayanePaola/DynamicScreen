using System.Collections.Generic;

namespace DynamicScreen.Dto
{
    public class ConfigurationRowDto
    {
        public int Index { get; set; }
        public int IdRow { get; set; }
        public List<ConfigurationValueDto> ConfigurationValues { get; set; }
    }
}