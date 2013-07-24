using System;
using System.Security.Cryptography;

namespace XWT.Security
{
    public sealed class SaltedHash
    {
        public string Salt { get { return _salt; } }
        public string Hash { get { return _hash; } }

        public static SaltedHash Create(string password)
        {
            string salt = _createSalt();
            string hash = _calculateHash(salt, password);
            return new SaltedHash(salt, hash);
        }

        public static SaltedHash Create(string salt, string hash)
        {
            return new SaltedHash(salt, hash);
        }

        public bool Verify(string password)
        {
            string h = _calculateHash(_salt, password);
            return _hash.Equals(h);
        }

        private SaltedHash(string s, string h)
        {
            _salt = s;
            _hash = h;
        }

        private static string _createSalt()
        {
            byte[] r = _createRandomBytes(saltLength);
            return Convert.ToBase64String(r);
        }

        private static byte[] _createRandomBytes(int len)
        {
            byte[] r = new byte[len];
            new RNGCryptoServiceProvider().GetBytes(r);
            return r;
        }

        private static string _calculateHash(string salt, string password)
        {
            byte[] data = _toByteArray(salt + password);
            byte[] hash = _calculateHash(data);
            return Convert.ToBase64String(hash);
        }

        private static byte[] _calculateHash(byte[] data)
        {
            return new SHA1CryptoServiceProvider().ComputeHash(data);
        }

        private static byte[] _toByteArray(string s)
        {
            return System.Text.Encoding.UTF8.GetBytes(s);
        }

        private readonly string _salt;
        private readonly string _hash;
        private const int saltLength = 6;
    }

}
