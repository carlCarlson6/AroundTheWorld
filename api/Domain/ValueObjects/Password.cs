using System.Text.RegularExpressions;
using System;
using Domain.Exceptions;
using System.Security.Cryptography;

namespace Domain.ValueObjects
{
    public class Password
    {
        private readonly Regex validationRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");
        public String Value { get => encrypted.Value; }
        private readonly EncryptedPassword encrypted;
        
        public Password(String value)
        {
            this.ValidateFormat(value);
            this.encrypted = this.Encrypt(value);
        }

        public Password(EncryptedPassword encryptedPassword) => this.encrypted = encryptedPassword;

        private void ValidateFormat(String passwordString)
        {
            if(String.IsNullOrEmpty(passwordString) || String.IsNullOrWhiteSpace(passwordString))
            {
                throw new EmptyNullWhiteSpaceStringException(nameof(Password));
            }
            if(!this.validationRegex.IsMatch(passwordString))
            {
                throw new NotValidPasswordException();
            }
        }

        private EncryptedPassword Encrypt(String passwordString)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var keyDerevationFn = new Rfc2898DeriveBytes(passwordString, salt, 100000);
            byte[] hash = keyDerevationFn.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return new EncryptedPassword(Convert.ToBase64String(hashBytes));
        }

        public Boolean Verify(String inputPassword)
        {
            byte[] hashedPasswordBytes = Convert.FromBase64String(this.Value);
            byte[] salt = new byte[16];
            Array.Copy(hashedPasswordBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(inputPassword, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i=0; i < 20; i++)
            {
                if (hashedPasswordBytes[i+16] != hash[i])
                {
                    throw new PasswordDoesNotMatchException();
                }
            }

            return true;
        }

    }
}
