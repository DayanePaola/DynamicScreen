using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Dto
{
    public class ConfigurationTabDto
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public List<ComponentItemDto> ComponentItems { get; set; }
        public List<ConfigurationRowDto> ConfigurationRows { get; set; }
    }
}
