using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.Common
{
    public static class NotificationService
    {
        /// <summary>
        /// Notifies Talent
        /// </summary>
        /// <param name="talentName"></param>
        /// <returns></returns>
        public static string NotifyTalent(string talentName)
        {
            var message = "Notifying talent: " + talentName;
            Console.WriteLine(message);
            return message;
        }
    }
}
