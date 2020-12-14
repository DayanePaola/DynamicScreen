using DynamicScreen.Enums;
using System.Collections.Generic;

namespace DynamicScreen.Dto
{
    public class ConfigurationColumnDto
    {
        public int Id { get; set; }
        public int ConfigurationId { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Method { get; set; }
        public int Index { get; set; }
        public bool ReadOnly { get; set; }
        public string DataType { get; set; }
        public ComponentAllowed Component { get; set; }
        public List<ValueDto> EnableValues { get; set; }
    }
}