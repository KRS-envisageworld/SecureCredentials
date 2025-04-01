using System;
using System.Security.Cryptography;

namespace SecureCredentials
{
    /// <summary>
    /// Provides methods for securely hashing and verifying passwords using a cryptographic algorithm.
    /// This class utilizes PBKDF2 with a random salt to enhance security against brute-force attacks.
    /// </summary>
    public sealed class PasswordHasher
    {
        private int _keySize;
        private int _iterations;
        private HashAlgorithmName HashAlgorithmName = Constant.HASHALGORITHM;

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordHasher"/> class with specified key size and iteration count.
        /// </summary>
        /// <param name="keySize">The size of the key to derive, in bytes.</param>
        /// <param name="iterations">The number of iterations to use for the hashing algorithm.</param>
        public PasswordHasher(int keySize, int iterations)
        {
            _keySize = keySize;
            _iterations = iterations;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordHasher"/> class with default key size and iteration count.
        /// </summary>
        public PasswordHasher()
        {
            _keySize = Constant.KEYSIZE;
            _iterations = Constant.ITERATIONS;
        }

        /// <summary>
        /// Takes a plain text password and generates a secure hash along with a random salt.
        /// </summary>
        /// <param name="password">Plain text which needs to be hashed</param>
        /// <param name="salt">Private key to hash the plain text</param>
        /// <returns></returns>
        public string HashPassword(string password, out byte[] salt)
        {
            salt = [];

            if (string.IsNullOrEmpty(password))
                return string.Empty;

            salt = RandomNumberGenerator.GetBytes(_keySize);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, HashAlgorithmName, _keySize);

            return $"{Convert.ToHexString(hash)}";
        }

        /// <summary>
        /// Compares a plain text password against a stored hash using the original salt to confirm authenticity.
        /// </summary>
        /// <param name="password">Plain text which needs to verify</param>
        /// <param name="hash">Hash value to compare</param>
        /// <param name="salt">Private key to hash the Plain text</param>
        /// <returns></returns>
        public bool VerifyHashPassword(string password, string hash, byte[] salt)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hash) || salt.Length == 0)
                return false;

            byte[] hashToVerify = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, HashAlgorithmName, _keySize);

            return CryptographicOperations.FixedTimeEquals(hashToVerify, Convert.FromHexString(hash));
        }
    }
}
