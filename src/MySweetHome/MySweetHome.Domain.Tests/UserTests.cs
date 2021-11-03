using System;
using MySweetHome.Domain.ValueObjects;
using Xunit;

namespace MySweetHome.Domain.Tests
{
    public class UserTests
    {
        [Theory]
        [InlineData("juan@juan.com", "testsUser")]
        public void when_an_user_is_created_should_have_a_correct_assigned_email(string mail, string userName)
        {
            var email = new Email(mail);
            var user = new User(userName, email);
            
            Assert.Same(mail, user.GetEmail());
            Assert.NotEmpty(user.ToString());
        }
        
        [Theory]
        [InlineData(" ")]
        [InlineData("")]
        public void when_an_user_is_being_creted_with_an_invalid_data_should_raise_an_exception(string userName)
        {
            var mail = "juan@juan.com";
            var email = new Email(mail);
            void UserCreation () => new User(userName, email);

            Assert.Throws<Exception>(UserCreation);
        }
        
        [Theory]
        [InlineData("juan")]
        [InlineData("juan@juan")]
        [InlineData("juan@juan.c")]
        public void when_an_user_email_is_being_created_with_an_invalid_data_should_raise_an_exception(string mail)
        {
            void MailCreation () => new Email(mail);

            Assert.Throws<Exception>(MailCreation);
        }
    }
}