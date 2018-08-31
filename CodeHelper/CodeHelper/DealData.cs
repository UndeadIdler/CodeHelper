using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper
{
    public static class DealData
    {
        //得到原始的列名，类型，长度，FParameter使用
        public static string[] GetOriginalNameAndType(string s)
        {
            string[] results = new string[3];
            //string result = results[1];
            string[] result = s.Split('\t');
            results[0] = result[0];
            results[1] = result[1];
            if (result.Length == 2)
            {
                results[2] = string.Empty;
            }
            else
            {
                results[2] = result[2];
            }
            return results;
        }

        //得到大写，小写，FParameter和FAllParameter使用
        public static string[] GetNames(string name)
        {
            string[] Names = new string[2];
            if (name.Length > 1)
            {
                string first = name.Remove(1);
                string rest = name.Substring(1, name.Length - 1);
                Names[0] = first.ToLower() + rest;
                Names[1] = first.ToUpper() + rest;
            }
            else
            {
                Names[0] = name.ToLower();
                Names[1] = name.ToUpper();
            }
            return Names;
        }

        public static string GetUpper(string name)
        {
            string Name = "";
            if (name.Length > 1)
            {
                string first = name.Remove(1);
                string rest = name.Substring(1, name.Length - 1);
                Name = first.ToUpper() + rest;
            }
            else
            {
                Name = name.ToUpper();
            }
            return Name;
        }

        public static string Get_Lower(string name)
        {
            string Name = "";
            if (name.Length > 1)
            {
                string first = name.Remove(1);
                string rest = name.Substring(1, name.Length - 1);
                Name = "_" + first.ToLower() + rest;
            }
            else
            {
                Name = "_" + name.ToLower();
            }
            return Name;
        }

        public static string GetLower(string name)
        {
            string Name = "";
            if (name.Length > 1)
            {
                string first = name.Remove(1);
                string rest = name.Substring(1, name.Length - 1);
                Name = first.ToLower() + rest;
            }
            else
            {
                Name = name.ToLower();
            }
            return Name;
        }

        public static string GetType(string type)
        {
            string Ftype = "";
            if (type == "bit")
            {
                Ftype = "bool";
            }
            else if (type.Contains("int"))
            {
                Ftype = "int";
            }
            else if (type.Contains("numeric") || type.Contains("decimal"))
            {
                Ftype = "decimal";
            }
            else if (type.Contains("datetime"))
            {
                Ftype = "DateTime";
            }
            else if (type.Contains("float"))
            {
                Ftype = "double";
            }
            else if (type.Contains("char") || type.Contains("text"))
            {
                Ftype = "string";
            }
            return Ftype;
        }

        public static int GetLength(string type, string length)
        {
            int i = 0;
            if (type == "string")
            {
                if (length != string.Empty && length != "-1")
                {
                    i = int.Parse(length);
                }
            }
            return i;
        }

        public static bool GetIsNull(string IsNull)
        {
            bool isNull = true;
            if (IsNull == "NO")
            {
                isNull = false;
            }
            return isNull;
        }
        //处理原来的类型，FParameter和FAllParameter使用
        public static string DealType(string type)
        {
            string Ftype = "";
            if (type == "bit")
            {
                Ftype = "bool";
            }
            else if (type.Contains("int") || type.Contains("numeric") || type.Contains("decimal"))
            {
                Ftype = "int";
            }
            else if (type.Contains("datetime"))
            {
                Ftype = "DateTime";
            }
            else if (type.Contains("float"))
            {
                Ftype = "double";
            }
            else if (type.Contains("char") || type.Contains("text"))
            {
                Ftype = "string";
            }
            return Ftype;
        }

        //得到DAL中的最终长度，FParameter使用
        public static int DealParameterLength(string type, string length)
        {
            int i = 0;
            if (type == "int")
            {
                i = 32;
            }
            else if (type == "string")
            {
                if (length != string.Empty && length != "-1")
                {
                    i = int.Parse(length);
                }
            }
            else if (type == "double")
            {
                i = 64;
            }
            else if (type == "bool")
            {
                i = 4;
            }
            return i;
        }

        //处理存储过程里的参数长度
        public static string ProcLength(string type, string length)
        {
            string s = string.Empty;
            if (type == "string")
            {
                if (length == string.Empty || length == "-1")
                {
                    s = "MAX";
                }
                else
                {
                    s = length;
                }
            }
            return s;
        }

        //得到FParameter
        public static string[] GetFinalParemeter(string[] s)
        {
            string name = s[0];
            string type = s[1];
            string length = s[2];
            string[] FParameters = new string[7];
            //原列名
            FParameters[0] = s[0];
            //原类型
            FParameters[1] = s[1];
            //大写的列名
            FParameters[2] = GetNames(name)[1];
            //小写的列名
            FParameters[3] = GetNames(name)[0];
            //类型
            FParameters[4] = DealType(type);
            //DAL中的长度
            FParameters[5] = DealParameterLength(FParameters[4], length).ToString();
            //Proc中的长度
            FParameters[6] = ProcLength(FParameters[4], length).ToString();

            //string[] FParameters = new string[4];
            ////小写
            //FParameters[0] = GetNames(name)[0];
            ////大写
            //FParameters[1] = GetNames(name)[1];
            ////类型
            //FParameters[2] = DealType(type);
            ////长度
            //FParameters[3] = DealParameterLength(FParameters[2], length).ToString();
            return FParameters;
        }

        //得到FAllParameter
        public static string[] GetAllParemeter(string[] s)
        {
            string name = s[0];
            string type = s[1];
            string[] AllParameters = new string[3];
            //原名
            AllParameters[0] = name;
            //大写
            AllParameters[1] = GetNames(name)[1];
            //类型
            AllParameters[2] = DealType(type);
            return AllParameters;
        }

        //得到真正的FParameter
        public static void SetFParameter()
        {
            Singleton<Condition>.Instance.FinalParameters.Clear();
            //for (int i = 0; i < Singleton<Condition>.Instance.OriginalParameters.Count; i++)
            //{
            //    string[] P = GetOriginalNameAndType(Singleton<Condition>.Instance.OriginalParameters[i].ToString());
            //    string[] FP = GetFinalParemeter(P);
            //    Singleton<Condition>.Instance.FinalParameters.Add(FP);
            //}
        }
    }
}
