using System;
using System.Diagnostics.CodeAnalysis;
using MySweetHome.Domain.ValueObjects;
using Xunit;

namespace MySweetHome.Domain.Tests
{
    [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
    public class UnitTest1
    {
        [Fact]
        public void project_should_be_created_correctly()
        {
            const string address = "Calle Paco";
            const string name = "Mi casita en el campo";
            const string mail = "juan@juan.com";
            const string userName = "testsUser";
            var email = new Email(mail);
            var user = new User(userName, email);
            var project = new Project(name, address, user);
            
            Assert.NotNull(project);
            Assert.Same(name, project.Name.ToString());
            Assert.Same(address, project.Address.ToString());
            Assert.Same(mail, project.User.GetEmail());
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void when_a_name_is_indicated_wrongly_should_raise_an_exception(string name)
        {
            const string address = "Calle Paco";
            var email = new Email("juan@juan.com");
            var user = new User("testsUser", email);
            void ProjectCreation() => new Project(name, address, user);
            
            Assert.Throws<Exception>(ProjectCreation);
        }

        [Fact]
        public void when_a_project_information_is_fullfilled_should_calculate_a_basic_budget()
        {
            var project = Given.A_Project._with_standard_info();
            var projectBasicInformation = new ProjectBasicInformation(100, 1, Quality.Low);
            project.AddBasicInformation(projectBasicInformation);
            var calculatedPrice = project.BasicInformation.CalculatePrice();
            
            Assert.Equal(0, calculatedPrice);
        }

        [Theory]
        [InlineData(24)]
        public void when_a_project_surface_is_not_enough_big_should_raise_an_exception(decimal surface)
        {
            void BasicInformationCreation () => new ProjectBasicInformation(surface, 1, Quality.Low);

            var exception = Assert.Throws<Exception>(BasicInformationCreation);
            Assert.Equal("We cannot analyze projects with 25 meters or lower.", exception.Message);
        }
        
        [Theory]
        [InlineData(0)]
        public void when_a_project_floors_is_not_enough_should_raise_an_exception(int floors)
        {
            void BasicInformationCreation () => new ProjectBasicInformation(30, floors, Quality.Low);

            var exception = Assert.Throws<Exception>(BasicInformationCreation);
            Assert.Equal("We cannot analyze projects no floors.", exception.Message);
        }
    }
}