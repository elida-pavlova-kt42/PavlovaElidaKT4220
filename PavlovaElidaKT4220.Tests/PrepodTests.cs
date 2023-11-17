using PavlovaElidaKT4220.Models;
namespace PavlovaElidaKT4220.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var MailTest = new Prepod
            {
                Mail = "kafvt@mail.ru"
            };

            var result = MailTest.IsValidMail();

            Assert.False(result);
        }
    }
}