using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.Biz
{
    public class Actor // 命名はあいまいにしてはならない
    {
        // ctor と入力することで簡単に記述できる
        public Actor()
        {
            Console.WriteLine("An actor is born.");            
        }

        // this()をつけると引数なしコンストラクタが最初に呼ばれる
        // （コンストラクタ共通の処理をまとめることができる）
        public Actor(string actorName) : this()
        {
            ActorName = actorName;
        }

        private string actorName;

        public string ActorName
        {
            get { return actorName; }
            set { actorName = value; }
        }


        // propfull と入力することで簡単に記述できる
        private string jobTitle; // privateはキャメルケース

        public string JobTitle // publicはパスカルケース
        {
            get { return jobTitle; }
            set { jobTitle = value; }
        }

        public int ActorAge { get; set; }
        public string ActorDescription { get; set; } = "Regular actor";

        private Agency currentAgency;

        public Agency CurrentAgency
        {
            get
            {
                if (currentAgency == null)
                {
                    currentAgency = new Agency();
                }
                return currentAgency; 
            }
            set { currentAgency = value; }
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

        /// <summary>
        /// Books actor and not date specified.
        /// </summary>
        public string BookActor()
        {
            string details = "Booking can change if actor starts trouble.";

            return "Actor " + ActorName + " is booked. " + details;
        }

        /// <summary>
        /// Books actor on specific date.
        /// </summary>
        /// <param name="theDate"></param>        
        public string BookActor(string theDate)
        {
            string details = "Booking can change if actor starts trouble.";

            return "Actor " + ActorName + " is booked on " + theDate + ". " + details;
        }

        public string GetAgency()
        {
            //var currentAgency = new Agency();
            return CurrentAgency.Name;
        }
    }
}
