using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ConsoleDotNetFramework.Basis
{
    public class SwitchTips
    {
        public void Run()
        {
            //C#7~ 
            object objValue = 3;

            switch (objValue)
            {
                case int n when n > 4:
                    Console.WriteLine("A");
                    break;

                case int n when n <= 4:
                    Console.WriteLine("B");
                    break;
            }

            // switchによる型の判定
            //var baseClass = new BaseClass();
            var baseClass = new InheritClass(); // 継承したクラスでも親クラスと同じ型と判定される
            //baseClass = null;
            int intValue = 3;

            switch (baseClass)
            {
                case InheritClass myInheritClass when intValue % 3 == 0:
                    Console.WriteLine(nameof(myInheritClass));
                    break;

                case InheritClass myInheritClass:                    
                    Console.WriteLine(nameof(myInheritClass));
                    break;

                //case BaseClass myBaseClass:
                //    // 型がBaseClass
                //    Console.WriteLine(nameof(myBaseClass));
                //    break;

                case null: // switch分でnullの場合の処理を記述できる
                    break;
            }

        }

        class BaseClass { }
        class InheritClass : BaseClass { }
    }
}
