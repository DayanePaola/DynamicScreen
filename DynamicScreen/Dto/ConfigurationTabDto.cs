using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Dto
{
    public class ConfigurationTabDto
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public ICollection<ConfigurationRowDto> ConfigurationRow { get; set; }
        public ICollection<ConfigurationColumnDto> ConfigurationColumn { get; set; }
        public int RowId { get; set; }
    }
}
