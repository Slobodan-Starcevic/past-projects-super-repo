using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
	public static class SECURITY
	{
		private const int SALT_LENGTH = 24;


		public static string GeneratePassword(string password)
		{
			using (var sha256 = SHA256.Create())
			{
				// convert the password string to a byte array
				var passwordBytes = Encoding.UTF8.GetBytes(password);

				// compute the hash of the password
				var hashBytes = sha256.ComputeHash(passwordBytes);

				// convert the hash byte array to a string
				var hashedPassword = Convert.ToBase64String(hashBytes);

				return hashedPassword;
			}
		}

			public static string  GenerateSalt()
			{
			Random random = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			var salt = new string(Enumerable.Repeat(chars, SALT_LENGTH).Select(s => s[random.Next(s.Length)]).ToArray());
			return salt;
			}

			public static string GeneratePassword(string password, string salt)
			{
				GenerateSalt();

				password += salt;

				using (var sha256 = SHA256.Create())
				{
					password += salt;

					// convert the password string to a byte array
					var passwordBytes = Encoding.UTF8.GetBytes(password);

					// compute the hash of the password
					var hashBytes = sha256.ComputeHash(passwordBytes);

					// convert the hash byte array to a string
					var hashedPassword = Convert.ToBase64String(hashBytes);

					return password = hashedPassword;
				}
			}
		}
	}

