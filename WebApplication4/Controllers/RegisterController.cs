using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Org.BouncyCastle.Security;
using WebApplication4.DTO;
using WebApplication4.Entities;

namespace WebApplication4.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegisterController : ControllerBase
	{
		private readonly DotnetCrudContext _DBContext;
		// "public Register" must same with "public class Register : ControllerBase". If not same it will show errors.
		public RegisterController(DotnetCrudContext dbContext)
		{
			_DBContext = dbContext;
		}

		// get all register user.
		[HttpGet("GetUsers")]
		public async Task<ActionResult<List<RegisterDTO>>> GetAllUsers()
		{
			var users = await _DBContext.Registers.ToListAsync();
			if (users.Count == null)
			{
				return NotFound();
			} else
			{
				return Ok(users);
			}
		}

		// get user by id API.
		[HttpGet("{id}")]
		// "<Register>" is from your entities file names such as models "Register.cs". in here we only use the file name, no need include the file type.
		public async Task<ActionResult<RegisterDTO>> GetUserById(int id)
		{
			// "_DBContext is from private readonly at line 13 in this file.
			// ".Register" is call the models file.
			var user = await _DBContext.Registers.FindAsync(id);
			if (user is null)
			{
				return NotFound("User not found!");
			} else
			{
				return Ok(user);
			}
		}

		// create new user api.
		[HttpPost]
		public async Task<ActionResult<RegisterDTO>> RegisterUser(RegisterDTO Register)
		{
			var user = new Register()
			{
				Username = Register.Username,
				Email = Register.Email,
				Password = Register.Password
			};
			_DBContext.Registers.Add(user);
			await _DBContext.SaveChangesAsync();
			return Ok(user);
		}
	}
}