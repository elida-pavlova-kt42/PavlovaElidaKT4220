using PavlovaElidaKT4220.Models;
namespace PavlovaElidaKT4220.Tests
{
    public class prepodTests
    {
        [Fact]
        public void Test1()
        {
            var MailTest = new Prepod
            {
                Mail = "test@mail.ru"
            };

            var result = MailTest.IsValidMail();

            Assert.False(result);

        }
    }
}