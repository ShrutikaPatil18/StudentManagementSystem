using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using StudentManagementSystem.API.Constants;
using StudentManagementSystem.Application.Dtos;
using StudentManagementSystem.IntegrationTests.Helpers;

namespace StudentManagementSystem.IntegrationTests.Controllers
{
	public class StudentsControllerTests : IClassFixture<CustomWebApplicationFactory>
	{
		private readonly IMapper _mapper;
		private readonly Fixture _fixture;
		private readonly HttpClient _httpClient;
		private readonly CustomWebApplicationFactory _factory;

		public StudentsControllerTests(CustomWebApplicationFactory factory)
		{
			_factory = factory;
			_httpClient = _factory.CreateClient();
			_fixture = new Fixture();

		}

		[Fact]
		public async Task CreateStudentAsync_WhithValidData_ShouldReturnCreatedStudent()
		{
			//Arrange
			DbUtilities.InitializeDb(_factory);
			var student = DbUtilities.GenerateSeedingStudent(1)[0];
			var createStudentDto = _mapper.Map<CreateStudentDto>(student);

			// Act
			var response = await _httpClient.PostAsJsonAsync(ApiRoutes.StudentBaseUrl, createStudentDto);
			var createdStudent = await response.Content.ReadFromJsonAsync<StudentsDto>();
			var createdStudentDto = _mapper.Map<CreateStudentDto>(createdStudent);

			// Assert
			response.StatusCode.Should().Be(HttpStatusCode.Created);
			createStudentDto.Should().BeEquivalentTo(createdStudentDto);
		}

		[Fact]
		public async Task CreateStudentAsync_WhithInValidData_ShouldReturnBadRequest()
		{
			//Arrange
			var studentDto = _fixture.Create<CreateStudentDto>();
			studentDto.Name=String.Empty;

			// Act
			var response = await _httpClient.PostAsJsonAsync(ApiRoutes.StudentBaseUrl, studentDto);

			// Assert
			response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

		}
	}
}

