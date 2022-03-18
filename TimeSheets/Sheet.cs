using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_3_Lesson_4
{
    public class Sheet
	{
		public Guid Id { get; set; }
		public DateTime ApproveDate { get; private set; }
		public bool IsApproved { get; private set; }
		public int Amount { get; set; }

		public void Approve()
		{
			IsApproved = true;
			ApproveDate = DateTime.Now;
		}
	}
}
