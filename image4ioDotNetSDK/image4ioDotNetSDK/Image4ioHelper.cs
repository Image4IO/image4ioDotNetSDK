using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Text;

namespace image4ioDotNetSDK
{
    public static class Image4ioHelper
    {
        public static string SignedUrlToken(string signKey, DateTime Expire, string IPAddress, string Protocol, string Parameters)
        {
            TimeSpan t = Expire - new DateTime(1970, 1, 1);
            var str = ((long)t.TotalSeconds).ToString() + "," + Protocol + "," + IPAddress + "," + Parameters;

            if (string.IsNullOrEmpty(signKey) || str.Length < 3)
                throw new ArgumentException("Missing or wrong argument");
            else
                return BlowfishEncrypt(str, signKey);
        }

        static private string BlowfishEncrypt(string strValue, string key)
        {

            try
            {
                Encoding encoding = Encoding.UTF8;
                BlowfishEngine engine = new BlowfishEngine();
                PaddedBufferedBlockCipher cipher = new PaddedBufferedBlockCipher(engine);

                cipher.Init(true, new KeyParameter(encoding.GetBytes(key)));

                byte[] inn = encoding.GetBytes(strValue);
                byte[] outt = new byte[cipher.GetOutputSize(inn.Length)];

                int len1 = cipher.ProcessBytes(inn, 0, inn.Length, outt, 0);

                cipher.DoFinal(outt, len1);

                return BitConverter.ToString(outt).Replace("-", "");
            }
            catch (Exception)
            {
                return "";
            }
        }

    }
}
