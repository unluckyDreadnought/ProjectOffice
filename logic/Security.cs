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
        private static Random rand = new Random();

        // Функция для хеширования функцией MD5
        public static string hashMd5(string input, string salt)
        {
            MD5 hashFunc = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input + salt);
            string output = BitConverter.ToString(hashFunc.ComputeHash(inputBytes)).Replace("-", "").ToLower();
            return output;
        }

        // Функция для хеширования функцией SHA512
        public static string HashSha512(string input)
        {
            SHA512 sha5 = SHA512.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            string output = BitConverter.ToString(sha5.ComputeHash(inputBytes)).Replace("-", "").ToLower();
            return output;
        }

        // Функция генерации логина или пароля
        public static string GenerateString(int length, bool includeSpec)
        {
            string login = "";
            while (login.Length < length)
            {
                int r = rand.Next(0, 4);
                switch (r)
                {
                    case 0: login += rand.Next(0, 9).ToString(); break;
                    case 1: login += Symbols.en_alp[rand.Next(0, Symbols.en_alp.Length)].ToString(); break;
                    case 2: login += Symbols.en_alp[rand.Next(0, Symbols.en_alp.Length)].ToString().ToUpper(); break;
                    case 3: if (includeSpec) login += Symbols.spec[rand.Next(0, Symbols.spec.Length)].ToString(); break;
                }
            }
            return login;
        }
    }
}
