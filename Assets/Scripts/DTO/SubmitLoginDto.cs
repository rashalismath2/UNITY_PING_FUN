
using System;

namespace Assets.Scripts.DTO
{
	[Serializable()]
	public class SubmitLoginDto
	{
		public string Email;
		public string Password;
		public SubmitLoginDto(string email,string password)
		{
			Email = email;
			Password = password;
		}
	}
}
