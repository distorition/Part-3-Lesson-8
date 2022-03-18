using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_3_Lesson_4.TimeSheets
{
    public class CreateSheet:Sheet
    {
     
        public static CreateSheet Create(Guid SheetId,DateTime date, int amount)
        {
            return new CreateSheet()
            {
                Id = SheetId,
                Amount = amount

            };
        }

        public static CreateSheet CreateFromRequest(CreateSheet create)
        {
            return new CreateSheet()
            {
                Id = create.Id,
                Amount = create.Amount
            };
        }
    
    }
}
