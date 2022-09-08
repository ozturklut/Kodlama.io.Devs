using System;
namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos
{
	public class CreateProgrammingTechnologyDto
	{
		public int Id { get; set; }

		public int ProgrammingLanguageId { get; set; }

		public string Name { get; set; } = string.Empty;
	}
}

