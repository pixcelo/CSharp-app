using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.Common
{
    /// <summary>
    /// シングルトンなクラス例
    /// </summary>
    public class Policy
    {
        private static Policy _instance;

        private Policy() { }

        public static Policy Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Policy();
                }
                return _instance;
            }
        }
    }
}
