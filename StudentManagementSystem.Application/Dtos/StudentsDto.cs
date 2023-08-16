using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Application.Dtos
{
	public class StudentsDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Standard { get; set; }
		public string Division { get; set; }
		public string City { get; set; }
	}
}
