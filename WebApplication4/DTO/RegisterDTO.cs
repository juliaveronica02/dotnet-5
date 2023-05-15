﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication4.DTO
{
	public class RegisterDTO
	{
		// dto -> data transfer objects used by controllers to expose a limited set of entity data via the api, and for model binding data from HTTP requests to controller action methods.
		[Required]
		public string? Username { get; set; }
		[Required]
		public string? Email { get; set; }
		[Required]
		public string? Password { get; set; }
	}
}
