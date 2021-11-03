using System;

namespace MySweetHome.Domain.ValueObjects
{
    public class Name
    {
        private readonly string _name;

        public Name(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("The Name can not be null or empty");
            }
            _name = name;
        }
        
        public override string ToString() => $"{_name}";

    }
}