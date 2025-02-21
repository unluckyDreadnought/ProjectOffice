using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;

namespace ProjectOffice.logic
{
    // Класс для функций, реализующих некоторые меры защиты информации
    public static class Security
    {
        // Функция для хеширования функцией MD5
        public static string hashMd5(string input, string salt)
        {
            MD5 hashFunc = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input + salt);
            string output = BitConverter.ToString(hashFunc.ComputeHash(inputBytes)).Replace("-", "").ToLower();
            return output;
        }
        
        public static string HashSha512(string input)
        {
            SHA512 sha5 = SHA512.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            string output = BitConverter.ToString(sha5.ComputeHash(inputBytes)).Replace("-", "").ToLower();
            return output;
        }
    }
}
