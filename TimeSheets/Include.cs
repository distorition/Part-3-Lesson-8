using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_3_Lesson_4.TimeSheets
{
    public class Include
    {
        public List<Sheet> Sheets { get; set; } = new List<Sheet>();
        public void IncludeSheets(IEnumerable<Sheet> sheets)
        {
            Sheets.AddRange(sheets);

        }
    }
}
