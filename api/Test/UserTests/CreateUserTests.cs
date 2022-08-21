using Xunit;

namespace Test.UserTests
{
    public class CreateUserTests
    {
        [Fact]
        public void CreateUserOKTest()
        {
        }

        [Fact]
        public void CreateUserKOUserAlreadyExistTest()
        {
        }

        [Fact]
        public void CreateUserKOEmptyNameTest()
        {
        }

        [Fact]
        public void CreateUserKOEmptyEmailTest()
        {
        }

        [Fact]
        public void CreateUserKOEInvalidEmailTest()
        {
        }

        [Fact]
        public void CreateUserKOEmptyPasswordTest()
        {
        }

        [Fact]
        public void CreateUserKOInvalidPasswordTest()
        {
        }
    }
}