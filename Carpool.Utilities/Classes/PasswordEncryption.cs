using System;
using System.Security.Cryptography;
using System.Text;

namespace Carpool.Utilities.Classes
{
	public class PasswordEncryption
	{
		public PasswordEncryption()
		{
		}

        public static string EncryptPassword(string plainText)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static Boolean CheckPassword(string password, string encodedPassword)
        {
            string hashOfInput = EncryptPassword(password);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, encodedPassword) == 0;
        }
    }
}

