using Xunit;
using Cyber_dz.Cipher;

namespace Cyber_dz.tests
{
    public class Kuznechik_test
    {
        byte[] input = { 0x88, 0x99, 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF, 0x00, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11 };
        [Fact]
        public void Add_ShouldReturnEncryptedString_WhenGivenTestByteArray()
        {
            Assert.Equal("7F679D90BEBC24305A468D42B9D4EDCD", Kuznechik.KuznechikEncrypt(input));
        }
    }
}
