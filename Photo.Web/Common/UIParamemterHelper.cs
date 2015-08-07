using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Photo.Web
{
    public abstract class UIParamemterHelper
    {
        public abstract object GetValue(string key);

        /// <summary>
        /// 从QueryString或Form中获取一个Int值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public int GetInt(string key, int defaultValue)
        {
            object value = GetValue(key);
            if (CommonHelpr.IsNull(value)) return defaultValue;
            int result = defaultValue;
            int.TryParse(value.ToString(), out result);
            return result;
        }
        /// <summary>
        /// 从QueryString或Form中获取一个可空的Int值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Nullable<int> GetInt(string key)
        {
            object value = GetValue(key);
            if (CommonHelpr.IsNull(value)) return null;
            int temp = 0;
            Nullable<int> result = null;
            if (int.TryParse(value.ToString(), out temp)) result = temp;
            return result;
        }

        /// <summary>
        /// 从QueryString或Form中获取一个可空的Decimal值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Nullable<decimal> GetDecimal(string key)
        {
            object value = GetValue(key);
            if (CommonHelpr.IsNull(value)) return null;
            Nullable<decimal> result = null;
            decimal d = 0M;
            if (decimal.TryParse(value.ToString(), out d))
            {
                result = d;
            }
            return result;
        }

        /// <summary>
        /// 从QueryString或Form中获取一个Decimal值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public decimal GetDecimal(string key, decimal defaultValue)
        {
            object value = GetValue(key);
            decimal result = defaultValue;
            if (CommonHelpr.IsNull(value)) return result;
            decimal.TryParse(value.ToString(), out result);
            return result;
        }

        /// <summary>
        /// 从QueryString或Form中获取一个DateTime值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public DateTime GetTime(string key, DateTime defaultValue)
        {
            object value = GetValue(key);
            if (CommonHelpr.IsNull(value)) return defaultValue;
            DateTime result = defaultValue;
            DateTime.TryParse(value.ToString(), out result);
            return result;
        }

        /// <summary>
        /// 从QueryString或Form中获取一个可空DateTime值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Nullable<DateTime> GetTime(string key)
        {
            object value = GetValue(key);
            if (CommonHelpr.IsNull(value)) return null;
            Nullable<DateTime> result = null;
            DateTime time = DateTime.Now;
            if (DateTime.TryParse(value.ToString(), out time))
            {
                result = time;
            }
            return result;
        }

        /// <summary>
        /// 从QueryString或Form中获取一个泛型集合
        /// </summary>
        /// <typeparam name="T">要获取到的集合中对象类型</typeparam>
        /// <param name="key"></param>
        /// <param name="splitChar">分隔符</param>
        /// <returns></returns>
        public List<T> GetItems<T>(string key, char splitChar)
        {
            object objValue = GetValue(key);
            if (CommonHelpr.IsNull(objValue)) return null;
            string strValue = objValue.ToString();
            if (string.IsNullOrEmpty(strValue)) return null;
            string[] strArr = strValue.Split(splitChar);
            List<T> list = new List<T>();
            Type type = typeof(T);
            foreach (string str in strArr)
            {
                try
                {
                    T t = (T)System.Convert.ChangeType(str, type);
                    list.Add(t);
                }
                catch { }
            }
            return list;
        }
    }
}