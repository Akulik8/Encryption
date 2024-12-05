using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    internal class Crypt
    {
        public static string CaesarEncrypt(string text, int shift, out int operationsCount)
        {
            operationsCount =0;
            const int englishAlphabetLength = 26;
            const int russianAlphabetLength = 32; 

            StringBuilder result = new StringBuilder();
            operationsCount +=3;

            foreach (char ch in text)
            {
                operationsCount++;

                if (char.IsLetter(ch))
                {
                    bool isRussian = (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я');
                    bool isEnglish = (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z');

                    int alphabetLength = isRussian ? russianAlphabetLength : englishAlphabetLength;
                    int shiftMod = shift % alphabetLength;
                    char shiftedChar = (char)(ch + shiftMod);
                    operationsCount += 24;

                    if (isRussian)
                    {
                        operationsCount++; 

                        if ((char.IsLower(ch) && shiftedChar > 'я') || (char.IsUpper(ch) && shiftedChar > 'Я'))
                        {
                            shiftedChar = (char)(ch - (russianAlphabetLength - shiftMod));
                            operationsCount += 3; 
                        }
                        operationsCount += 7;
                    }
                    else if (isEnglish)
                    {
                        operationsCount+=2;

                        if ((char.IsLower(ch) && shiftedChar > 'z') || (char.IsUpper(ch) && shiftedChar > 'Z'))
                        {
                            shiftedChar = (char)(ch - (englishAlphabetLength - shiftMod));
                            operationsCount += 3;
                        }
                        operationsCount += 7;
                    }

                    result.Append(shiftedChar);
                    operationsCount++; 
                }
                else
                {
                    result.Append(ch);
                    operationsCount += 2;
                }
            }
            operationsCount++;
            return result.ToString();
        }


        public static string CaesarDecrypt(string text, int shift, out int operationsCount)
        {
            operationsCount = 0;
            const int englishAlphabetLength = 26;
            const int russianAlphabetLength = 32;

            StringBuilder result = new StringBuilder();
            operationsCount +=3;

            foreach (char ch in text)
            {
                operationsCount++;
                if (char.IsLetter(ch))
                {
                    bool isRussian = (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я');
                    bool isEnglish = (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z');

                    int alphabetLength = isRussian ? russianAlphabetLength : englishAlphabetLength;
                    int shiftMod = shift % alphabetLength;

                    char shiftedChar = (char)(ch - shiftMod);
                    operationsCount += 24;

                    if (isRussian)
                    {
                        operationsCount++;

                        if ((char.IsLower(ch) && shiftedChar < 'а') || (char.IsUpper(ch) && shiftedChar < 'А'))
                        {
                            shiftedChar = (char)(ch + (russianAlphabetLength - shiftMod));
                            operationsCount += 3;
                        }
                        operationsCount += 7;
                    }
                    else if (isEnglish)
                    {
                        operationsCount+=2;

                        if ((char.IsLower(ch) && shiftedChar < 'a') || (char.IsUpper(ch) && shiftedChar < 'A'))
                        {
                            shiftedChar = (char)(ch + (englishAlphabetLength - shiftMod));
                            operationsCount = 3;
                        }
                        operationsCount += 7;
                    }

                    result.Append(shiftedChar);
                    operationsCount++; 
                }
                else
                {
                    result.Append(ch);
                    operationsCount++;
                }
            }
            operationsCount++;
            return result.ToString();
        }


        public static string AESEncrypt(string plainText, string password)
        {
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);
            using (var aes = new AesManaged())
            {
                byte[] key = new Rfc2898DeriveBytes(password, salt, 10000).GetBytes(32);
                aes.Key = key;
                aes.GenerateIV();

                byte[] encrypted;

                using (var encryptor = aes.CreateEncryptor())
                {
                    using (var ms = new System.IO.MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                            cs.Write(plainBytes, 0, plainBytes.Length);
                        }
                        encrypted = ms.ToArray();
                    }
                }

                byte[] result = new byte[salt.Length + aes.IV.Length + encrypted.Length];
                Buffer.BlockCopy(salt, 0, result, 0, salt.Length);
                Buffer.BlockCopy(aes.IV, 0, result, salt.Length, aes.IV.Length);
                Buffer.BlockCopy(encrypted, 0, result, salt.Length + aes.IV.Length, encrypted.Length);

                return Convert.ToBase64String(result);
            }
        }

        public static string AESDecrypt(string encryptedText, string password)
        {
            byte[] encrypted = Convert.FromBase64String(encryptedText);

            byte[] salt = new byte[16];
            Buffer.BlockCopy(encrypted, 0, salt, 0, salt.Length);

            byte[] iv = new byte[16];
            Buffer.BlockCopy(encrypted, salt.Length, iv, 0, iv.Length);

            byte[] data = new byte[encrypted.Length - salt.Length - iv.Length];
            Buffer.BlockCopy(encrypted, salt.Length + iv.Length, data, 0, data.Length);
            using (var aes = new AesManaged())
            {
                byte[] key = new Rfc2898DeriveBytes(password, salt, 10000).GetBytes(32);
                aes.Key = key;
                aes.IV = iv;
                using (var decryptor = aes.CreateDecryptor())
                {
                    using (var ms = new System.IO.MemoryStream(data))
                    {
                        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (var sr = new System.IO.StreamReader(cs))
                            {
                                string decryptedText = sr.ReadToEnd();
                                return decryptedText;
                            }
                        }
                    }
                }
            }
        }


        // Определение алфавитов
        public static string russianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public static string englishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        // Заменяемые алфавиты для шифрования
        public static string substitutedRussianAlphabet = "ЯЮЭЬЫЪЩШЧЦХФУТСРПОНМЛКЙИЗЖЁЕДГВБАяюэьыъщшчцхфутсрпонмлкйизжёедгвба";
        public static string substitutedEnglishAlphabet = "ZYXWVUTSRQPONMLKJIHGFEDCBAzyxwvutsrqponmlkjihgfeddcba";

        public static string SubstitutionEncrypt(string text, out int operationsCount)
        {

            StringBuilder encryptedText = new StringBuilder();
            operationsCount = 5;
            foreach (char letter in text)
            {
                operationsCount++;
                if (russianAlphabet.Contains(letter))
                {
                    int index = russianAlphabet.IndexOf(letter);
                    encryptedText.Append(substitutedRussianAlphabet[index]);
                    operationsCount += 4;
                }
                else if (englishAlphabet.Contains(letter))
                {
                    int index = englishAlphabet.IndexOf(letter);
                    encryptedText.Append(substitutedEnglishAlphabet[index]);
                    operationsCount += 5;
                }
                else
                {
                    encryptedText.Append(letter);
                    operationsCount += 3;
                }
            }
            operationsCount++;
            return encryptedText.ToString();
        }

        public static string SubstitutionDecrypt(string text, out int operationsCount)
        {
            StringBuilder decryptedText = new StringBuilder();
            operationsCount = 5;
            foreach (char letter in text)
            {
                operationsCount++;
                if (substitutedRussianAlphabet.Contains(letter))
                {
                    int index = substitutedRussianAlphabet.IndexOf(letter);
                    decryptedText.Append(russianAlphabet[index]);
                    operationsCount += 4;
                }
                else if (substitutedEnglishAlphabet.Contains(letter))
                {
                    int index = substitutedEnglishAlphabet.IndexOf(letter);
                    decryptedText.Append(englishAlphabet[index]);
                    operationsCount += 5;
                }
                else
                {
                    decryptedText.Append(letter);
                    operationsCount += 3;
                }
            }
            operationsCount++;
            return decryptedText.ToString();
        }

    }
}
