using System.Collections.Generic;

namespace DynamicScreen.Dto
{
    public class ConfigurationColumnDto
    {
        public int Index { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public List<ValueDto> EnableValues { get; set; }
    }
}