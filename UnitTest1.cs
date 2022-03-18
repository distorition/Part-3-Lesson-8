using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework.Internal.Execution;
using Part_3_Lesson_4;
using Part_3_Lesson_4.Controllers;
using Part_3_Lesson_4.Controllers.Interfaces;
using Part_3_Lesson_4.Repositories;
using Stripe;
using System;
using Xunit;


namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestAuthetication()
        {
            var user = new Mock<IUserServices>();
            var check = new Mock<InterfaceForCheaking>();
            check.Setup(x => x.IsUserNameAlreadyExist(It.IsAny<string>())).Returns(false);
            //user.Setup(x => x.Authentication(It.IsAny<string>(), It.IsAny<string>())).Returns(new REsponseToken());
            
            UserAtribute rules = new UserAtribute(check.Object);
           
            var result = rules.RuleFor(x=>x.FirstName);

            Assert.NotNull(result);
        }


        [Theory]
        [InlineData("ss")]
        public void Checkingname(string name)
        {
            Mock<InterfaceForCheaking> Mock = new Mock<InterfaceForCheaking>();
            Mock.Setup(x => x.IsUserNameAlreadyExist(It.IsAny<string>())).Returns(true);
            UserAtribute rules = new UserAtribute(Mock.Object);

            var result = rules.RuleFor(x => x.FirstName);

            Assert.NotNull(result);
        }
        

    }
}
