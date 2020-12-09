using DynamicScreen.Enums;
using System.Collections.Generic;

namespace DynamicScreen.Dto
{
    public class ComponentItemDto
    {
        public int Index { get; set; }
        public string Group { get; set; }
        public ComponentAllowed Components { get; set; }
        public List<ConfigurationColumnDto> ConfigurationColumns { get; set; }
    }
}