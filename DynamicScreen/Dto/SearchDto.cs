using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicScreen.Dto
{
    public class SearchDto
    {
        public List<BaseSearchDto> SearchItems { get; set; }
        public string LabelIdName { get; set; }
        public string LabelDescriptionName { get; set; }
    }
}
