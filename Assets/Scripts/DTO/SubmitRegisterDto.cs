
using System;

namespace Assets.Scripts.DTO
{
	[Serializable()]
	public class SubmitRegisterDto
	{
		public string Email;
		public string Username;
		public string Password;
		public SubmitRegisterDto(string email,string userName,string password)
		{
			Email = email;
			Username = userName;
			Password = password;
		}
	}
}
