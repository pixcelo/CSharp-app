using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.DesignPattern
{
    public class FactroyMethod
    {
        public void Run()
        {
            var notificationServiceProvider = new NotificationServiceProvider();
            var shippingService = new ShippingService(notificationServiceProvider);
            shippingService.ShipItem();
        }

        interface IUserNotifer
        {
            void NotifyUser(int id);
        }

        /// <summary>
        /// Eメールで通知する
        /// </summary>
        class EmailUserNotifier : IUserNotifer
        {
            public void NotifyUser(int id)
            {
                Console.WriteLine($"Notidied User {id} By Email.");
            }
        }

        /// <summary>
        /// テストの通知クラス
        /// </summary>
        class TestUserNotifier : IUserNotifer
        {
            public void NotifyUser(int id)
            {
                Console.WriteLine($"Notidied User {id} Test.");
            }
        }

        class NotificationServiceProvider()
        {
            public IUserNotifer GetUserNotifer()
            {
#if DEBUG
                return new TestUserNotifier();
#else
                return new EmailUserNotifier();
#endif
            }
        }

        class ShippingService
        {
            NotificationServiceProvider _serviceProvider;

            public ShippingService(NotificationServiceProvider serviceProvider)
            {
                _serviceProvider = serviceProvider; 
            }

            public void ShipItem()
            {
                // code to ship the item
                _serviceProvider.GetUserNotifer().NotifyUser(1);
            }

        }

    }
}
