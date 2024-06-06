using ConsoleDotNetCore.DesignPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace ConsoleDotNetCore.Basis
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        /// <summary>
        /// 名前のみを受け取るコンストラクタ
        /// </summary>
        /// <param name="name"></param>
        public Person(string name) : this(name, 0) { }
        
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Person() : this("Unknown", 0) { }
    }
}
