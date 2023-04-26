
using static System.Formats.Asn1.AsnWriter;
using System.Text;
using System.Security.Cryptography;
using OutDoor_Models.Services;

namespace OutDoor_Services.UtilServices
{
    public class CryptographyService : ICryptographyService
    {
        public string Encrypt(string strToBeEncripted)
        {
            //encrypt data
            var data = Encoding.Unicode.GetBytes(strToBeEncripted);
            byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
            //return as base64 string
            return Convert.ToBase64String(encrypted);
        }
        public string Decrypt(string cipher)
        {

            //parse base64 string
            byte[] data = Convert.FromBase64String(cipher);

            //decrypt data
            byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(decrypted);
        }
    }
}
