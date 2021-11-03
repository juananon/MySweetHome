using System.Collections;
using System.Collections.Generic;
using MySweetHome.Domain.ValueObjects;

namespace MySweetHome.Domain
{
    public class User
    {
        private readonly Name _name;
        private readonly Email _email;
        public User(string name, Email email)
        {
            _email = email;
            _name = new UserName(name);
        }

        public override string ToString() => $"{_name}";

        public string GetEmail() => _email.ToString();

    }
}