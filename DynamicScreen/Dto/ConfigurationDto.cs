using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Dto
{
    public class ConfigurationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool Enable { get; set; }
        public int Index { get; set; }
    }
}
