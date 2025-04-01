using System.Security.Cryptography;

namespace SecureCredentials
{
    /// <summary>
    /// Contains constant values used for secure credential management used for password hashing.
    /// </summary>
    public class Constant
    {
        /// <summary>
        /// The size of key to derive.
        /// </summary>
        public const int KEYSIZE = 64;
        
        /// <summary>
        /// Salt size
        /// </summary>
        public const int SALTSIZE = 16;
        
        /// <summary>
        /// The number of iterations to derive the key.
        /// </summary>
        public const int ITERATIONS = 3_50_000;

        /// <summary>
        /// Algorithm type to hash the password.
        /// </summary>
        public static readonly HashAlgorithmName HASHALGORITHM = HashAlgorithmName.SHA512;

    }
}
