using System;
using System.Collections.Generic;

namespace WebApplication4.Entities;

public partial class Register
{
	// represent the application data that is stored in the database.
	public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;
	public string Password { get; set; } = null!;

	public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
