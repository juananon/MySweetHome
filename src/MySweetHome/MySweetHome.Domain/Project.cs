using MySweetHome.Domain.ValueObjects;

namespace MySweetHome.Domain
{
    public class Project
    {
        public Name Name { get; }
        public Address Address { get; }
        public User User { get; }
        public ProjectBasicInformation BasicInformation { get; private set; }

        public Project(string name, string address, User user)
        {
            User = user;
            Address = new Address(address);
            Name = new Name(name);
        }

        public void AddBasicInformation(ProjectBasicInformation basicInformation)
        {
            BasicInformation = basicInformation;
        }
    }
}