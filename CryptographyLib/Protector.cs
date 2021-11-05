using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Xml.Linq;
using static System.Convert;

namespace Packt.Shared
{
    public static class Protector
    {
        // salt size must be at least 8 bytes,we will use 16 bytes
        private static readonly byte[] salt = Encoding.Unicode.GetBytes("7BANANAS");

        public static string PublicKey;

        private static Dictionary<string, User> Users = new Dictionary<string, User>();
        public static User Register(
            string userName,string password)
        {
            // generate a random salt
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            var saltText = Convert.ToBase64String(saltBytes);

            // generate the salted and hashed password
            var saltedhashedPassword = SaltAndHashPassword(password, saltText);

            var user = new User
            {
                Name = userName,
                Salt = saltText,
                SaltedHashedPassword = saltedhashedPassword
            };
            Users.Add(user.Name,user);
            return user;
        }
        public static bool CheckPassword(
            string userName,string password)
        {
            if (!Users.ContainsKey(userName))
            {
                return false;
            }
            var user = Users[userName];

            // re-generate the salted and hashed password
            var saltedhashedPassword = SaltAndHashPassword(password, user.Salt);
            return (saltedhashedPassword == user.SaltedHashedPassword);
        }

        private static string SaltAndHashPassword(
            string password,string salt)
        {
            var sha = SHA256.Create();
            var saltedPassword = password + salt;
            return Convert.ToBase64String(sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
        }

        // iterations must be at least 1000, we will use 2000
        private static readonly int iterations = 200;
        public static string Encrypt(
            string plainText,string password)
        {
            byte[] encryptedBytes;
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);
            var aes = Aes.Create();
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32); // set a 256-bit key
            aes.IV = pbkdf2.GetBytes(16); // set a 128-bit key
            using (var ms = new MemoryStream())
            {
                using(var cs=new CryptoStream(
                    ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(plainBytes, 0, plainBytes.Length);
                }
                encryptedBytes = ms.ToArray();
            }
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(
            string cryptoText,string password)
        {
            byte[] plainBytes;
            byte[] cryptoBytes = Convert.FromBase64String(cryptoText);
            var aes = Aes.Create();
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);
            using(var ms=new MemoryStream())
            {
                using(var cs=new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cryptoBytes, 0, cryptoBytes.Length);
                }
                plainBytes = ms.ToArray();
            }

            return Encoding.Unicode.GetString(plainBytes);
        }

        public static string ToXmlStringExt(this RSA rsa, bool includePrivateParameters)
        {
            var p = rsa.ExportParameters(includePrivateParameters);
            XElement xml;
            if (includePrivateParameters)
            {
                xml = new XElement("RSAKeyValue",
                    new XElement("Modulus", ToBase64String(p.Modulus)),
                    new XElement("Exponent", ToBase64String(p.Exponent)),
                    new XElement("P", ToBase64String(p.P)),
                    new XElement("Q", ToBase64String(p.Q)),
                    new XElement("DP", ToBase64String(p.DP)),
                    new XElement("DQ", ToBase64String(p.DQ)),
                    new XElement("InverseQ", ToBase64String(p.InverseQ))
                    );
            }
            else
            {
                xml = new XElement("RSAKeyValue", new XElement("Modulus", ToBase64String(p.Modulus)),
                    new XElement("Exponent", ToBase64String(p.Exponent)));
            }
            return xml?.ToString();
        }

        public static void FromXmlStringExt(this RSA rsa, string parametersAsXml)
        {
            var xml = XDocument.Parse(parametersAsXml);
            var root = xml.Element("RSAKeyValue");
            var p = new RSAParameters
            {
                Modulus = FromBase64String(root.Element("Modulus").Value),
                Exponent = FromBase64String(root.Element("Exponent").Value)
            };
            if (root.Element("P") != null)
            {
                p.P = FromBase64String(root.Element("P").Value);
                p.Q = FromBase64String(root.Element("Q").Value);
                p.DP = FromBase64String(root.Element("DP").Value);
                p.DQ = FromBase64String(root.Element("DQ").Value);
                p.InverseQ = FromBase64String(root.Element("InverseQ").Value);
            }
            rsa.ImportParameters(p);
        }
    }
}
