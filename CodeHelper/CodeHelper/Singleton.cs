using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper
{
    public class Singleton<T> where T : new()
    {
        /// <summary>
        /// 返回类的实例
        /// </summary>
        public static T Instance
        {
            get { return SingletonCreator.instance; }
        }

        class SingletonCreator
        {
            internal static T instance = new T();
        }
    }
}
