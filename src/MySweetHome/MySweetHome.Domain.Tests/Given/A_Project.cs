using MySweetHome.Domain.ValueObjects;

namespace MySweetHome.Domain.Tests.Given
{
    public class A_Project
    {
        public static Project _with_standard_info()
        {
            const string address = "Calle Paco";
            const string name = "Mi casita en el campo";
            const string mail = "juan@juan.com";
            const string userName = "testsUser";
            var email = new Email(mail);
            var user = new User(userName, email);
            return new Project(name, address, user);
        }
    }
}