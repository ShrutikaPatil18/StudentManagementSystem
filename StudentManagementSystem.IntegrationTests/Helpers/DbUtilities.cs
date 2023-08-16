using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.IntegrationTests.Helpers
{
	public class DbUtilities
	{
		private static List<Students> seedStudents = GenerateSeedingStudent(10);

		public static List<Students> GetSeedingStudents()
		{
			return seedStudents;
		}

		public static void InitializeDb(CustomWebApplicationFactory factory)
		{

		}

		public static List<Students> GenerateSeedingStudent(int count)
		{
			var students = new Faker<Students>().Generate(count);

			return students;
		}
	}
}
