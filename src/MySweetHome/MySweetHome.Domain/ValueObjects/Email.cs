using System;
using System.Text.RegularExpressions;

namespace MySweetHome.Domain.ValueObjects
{
    public class Email
    {
        private readonly string _email;

        public Email(string email)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(email);
            if (!match.Success)
            {
                throw new Exception("Email is not valid");
            }
            _email = email;
        }
        
        public override string ToString() => $"{_email}";

    }
}