using System.Security.Cryptography;

namespace KeyGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 32;
            string newKey = GenerateKey(length);

            Console.WriteLine($"Generated API key ({length} characters): {newKey}");
        }

        /// <summary>
        /// Generates a secure API key with the specified length.
        /// </summary>
        /// <param name="length">The desired length of the API key.</param>
        /// <returns>A secure API key as a string.</returns>
        public static string GenerateKey(int length)
        {
            // Create an array to store the random bytes
            var newKeyBytes = new byte[length];

            // Fill the array with random bytes using RandomNumberGenerator
            RandomNumberGenerator.Fill(newKeyBytes);

            // Define a string of URL-safe characters for the API key
            const string urlSafeChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";

            // Create a character array to store the API key characters
            var newKey = new char[length];

            // Convert each random byte to a URL-safe character and store it in the apiKey array
            for (int i = 0; i < length; i++)
            {
                newKey[i] = urlSafeChars[newKeyBytes[i] % urlSafeChars.Length];
            }

            // Return the API key as a string
            return new string(newKey);
        }
    }
}
