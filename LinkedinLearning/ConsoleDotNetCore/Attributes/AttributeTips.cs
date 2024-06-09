using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.Attributes
{
    /// <summary>
    /// 属性の確認用クラス
    /// </summary>
    public class AttributeTips
    {
        public void Run()
        {
            Message();
            Console.WriteLine($"{nameof(AttributeTips)} の処理を実行");
        }

        /// <summary>
        /// 属性でデバッグ時のみ処理する
        /// </summary>
        [Conditional("DEBUG")]
        public void Message()
        {
            Console.WriteLine("デバッグ時のみ実行");
        }

        /// <summary>
        /// 属性でデバッグ時、またはテスト実行時のみ処理する
        /// </summary>
        [Conditional("DEBUG")]
        [Conditional("TEST")]
        public void Message2()
        {
            Console.WriteLine("デバッグ時またはテスト時のみ実行");
        }

        /// <summary>
        /// メソッド呼び出しの元の情報を取得する（ロギング/デバッグ用途）
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="file"></param>
        /// <param name="member"></param>
        /// <param name="line"></param>
        /// <param name="arg"></param>
        public void ShowCaller(
            string msg,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = "",
            [CallerLineNumber] int line = 0,
            [CallerArgumentExpression("msg")] string arg = "")
        {
            Console.WriteLine($"From: {file}/{member} {line}行目 Arg: {arg}");
        }

        /// <summary>
        /// [NotNullIfNotNull]は、引数がnullでない場合にnullを返すことを保証する
        /// 戻り値がnull以外の場合に
        /// nullを返すとコンパイラが警告を出してくれる => バグに気づける
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [return: NotNullIfNotNull("str")]
        public string ReturnString(string str)
        {
            if (str != null)
            {
                return null;
            }

            return str;
        }

        /// <summary>
        /// カスタム属性の利用
        /// </summary>
        [MeasureExecutionTime]
        public void LongRunningMethod()
        {
            // 長時間かかる処理のシミュレーション
            Thread.Sleep(2000);
        }

        public void InvokeWithAttribute(object obj, string methodName)
        {
            var method = obj.GetType().GetMethod(methodName);
            var attributes = method.GetCustomAttributes(typeof(MeasureExecutionTimeAttribute), true);

            foreach (MeasureExecutionTimeAttribute attribute in attributes)
            {
                attribute.OnMethodExecuting();
                method.Invoke(obj, null);
                attribute.OnMethodExecuted();
            }
        }
    }
}
