using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{

    // This attribute can be put on fields in the EF model. Then when passed to DataTable.RenderTable, the DataTable will only show fields that have this attribute.
    [AttributeUsage(AttributeTargets.Property)]
    public class TabulateAttribute : Attribute
    {
    }
}
