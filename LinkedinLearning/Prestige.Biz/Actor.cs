using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.Biz
{
    public class Actor // 命名はあいまいにしてはならない
    {
        // propfull と入力することで簡単に記述できる
        private string jobTitle; // privateはキャメルケース

        public string JobTitle // publicはパスカルケース
        {
            get { return jobTitle; }
            set { jobTitle = value; }
        }


        /// <summary>
        /// Will return title ※XML doc コメントであればIDEのインテリセンスが効く
        /// </summary>
        /// <returns></returns>
        public string GetOccupation()
        {
            jobTitle = "Actor";
            return jobTitle;
        }
    }
}
