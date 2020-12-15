using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Dto
{
    public class SearchDto
    {
        public List<ValueDto> SearchItems { get; set; }
        public string LabelIdName { get; set; }
        public string LabelDescriptionName { get; set; }
        public ValueDto SelectItem { get; set; }
        public string ColumnSourceName { get; set; }
        public string ColumnDestinationName { get; set; }
    }
}
