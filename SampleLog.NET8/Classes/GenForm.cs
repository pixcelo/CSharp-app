using SampleLog.NET8.Forms;

namespace SampleLog.NET8.Classes
{
    /// <summary>
    /// Formクラスのジェネリッククラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenForm<T> where T : Form
    {
        public string Key { get; set; }
        public T Value { get; set; }

        public void Run()
        {
            // 制約で定義した基底クラスのメソッドを呼び出す
            this.Value.ShowDialog();
        }
    }

    /// <summary>
    /// ジェネリッククラスを使用するクライアントクラス
    /// </summary>
    public class  ClientA
    {
        public static void Use()
        {
            var form = new GenForm<Form>(); // OK
            var form2 = new GenForm<SubForm>(); // OK
            //var form3 = new GenForm<string>(); // コンパイルエラー
        }
    }

}
