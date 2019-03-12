using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.Service.Models;
using WA.Service.Results;
using WA.Service.Validators;

/// <summary>
/// NOTE: This tests are fully functional, but the idea is to use the service layer validator class to test.
/// using CredentialModel class and call from the model object method available to test such as IsValidExpireTime().
/// </summary>
namespace WA1.Tests.Validators
{
    [TestClass]
    public class UserCredValidatorTests : BaseTest
    {
        [TestMethod]
        public void ExpireGreaterThanAcceptedValueShouldFail()
        {
            var dto = new CredentialModel();
            //idea is to use validator class from service layer to test 
            //as such
            // returns ValidationResult dto.IsValidExpireTime();
            // Assert.IsTrue(result != null)
        }

        public void IsUsernameEmptyShouldFail()
        {
            var dto = new CredentialModel();
            //idea is to use validator class from service layer to test 
            //as such
            // result = dto.IsValidUsername();
            // Assert.IsTrue(result != null)
        }
    }
}
