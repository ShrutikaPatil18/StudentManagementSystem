using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly ILogger<StudentsController> _logger;

		public StudentsController(ILogger<StudentsController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "GetStudents")]
		public async Task<IActionResult> Get()
		{
			return null;
		}

		[HttpPost(Name = "CreateStudents")]
		public async Task<IActionResult> CreateStudentsAsync()
		{
			return null;
		}
	}
}
