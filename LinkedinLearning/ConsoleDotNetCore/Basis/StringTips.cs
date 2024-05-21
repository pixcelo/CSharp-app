using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.Basis
{
    /// <summary>
    /// 文字列のパース・検索
    /// </summary>
    public static class StringTips
    {
        /// <summary>
        /// 文字列を正規化する
        /// </summary>        
        public static string NormalizeString(string input)
        {
            return input.ToLower().Trim().Replace(",", "");
        }

        /// <summary>
        /// 文字列がすべて大文字かを判定する
        /// </summary>
        public static bool IsUppercase(string s)
        {
            return s.All(char.IsUpper);
        }

        /// <summary>
        /// 文字列がすべて小文字かを判定する
        /// </summary>
        public static bool IsLowercase(string s)
        {
            return s.All(char.IsLower);
        }

        /// <summary>
        /// 文字列が、大文字、小文字、数字のいずれかを
        /// 少なくとも1つ含む複雑なパスワードかどうかを判定
        /// </summary>       
        public static bool IsPasswordComplex(string s)
        {
            return s.Any(char.IsUpper) && s.Any(char.IsLower)
                && s.Any(char.IsDigit);
        }

        /// <summary>
        /// 文字が偶数インデックスに存在するかを判定する
        /// </summary>
        /// <param name="s"></param>
        /// <param name="item"></param>        
        public static bool IsAtEvenIndex(string s, char item)
        {
            if (string.IsNullOrEmpty(s)) return false;

            for (int i = 0; i < s.Length / 2 + 1; i=i+2)
            {
                if (s[i] == item) return true;
            }

            return false;
        }
    }
}
