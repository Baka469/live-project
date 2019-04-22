using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
namespace 欢乐大抽奖
{
    class Filter
    {
        class QQxiaoxi
        {
            public string nian;
            public string yue;
            public string ri;
            public string xiaoshi;
            public string fenzhong;
            public string miao;


            public string shijian;
            public string id;
            public string qqhaoma;
            public string zhengwen;
            public bool flag = false;
        }

        class ListDictionary
        {
            public Dictionary<string, int> list = new Dictionary<string, int>();

        }
        


        void filter()
        {
            string t = "#我要换组#、#我要红包#、#我爱软工实践#";
            ListDictionary lDic = new ListDictionary();
            List<QQxiaoxi> qqList = new List<QQxiaoxi>();
            QQxiaoxi xiaoxi = new QQxiaoxi();

            StreamReader file = new StreamReader(@"QQrecord-2022.txt");//
            string line;
            bool panduan(string s, string m)
            {
                Match matches = Regex.Match(s, m);

                return matches.Success;
            }

            while ((line = file.ReadLine()) != null)
            {
                Regex reg = new Regex(@"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}\s.*");
                Match match = reg.Match(line);
                string value = match.Groups[0].Value;
                if (value != "")
                {
                    qqList.Add(xiaoxi);
                    MatchCollection matches1 = Regex.Matches(line, @"\d{4}-\d{2}-\d{2}");
                    MatchCollection matches2 = Regex.Matches(line, @"\d{2}:\d{2}:\d{2}");

                    MatchCollection matches4 = Regex.Matches(line, @"\(.*\)");
                    MatchCollection matches5 = Regex.Matches(line, "(.*[^@]助教)");

                    foreach (Match item in matches1)//time
                    {
                        string[] sArray = Regex.Split(item.Groups[0].Value, "-");
                        xiaoxi.nian = sArray[0];
                        xiaoxi.yue = sArray[1];
                        xiaoxi.ri = sArray[2];
                    }
                    foreach (Match item in matches2)
                    {

                        xiaoxi.shijian += item.Groups[0].Value;
                        string[] sArray = Regex.Split(item.Groups[0].Value, ":");
                        xiaoxi.xiaoshi = sArray[0];
                        xiaoxi.fenzhong = sArray[1];
                        xiaoxi.miao = sArray[2];
                    }

                    foreach (Match item in matches4)//number
                    {
                        string old;
                        string newstring;
                        old = item.Groups[0].Value;
                        newstring = old.Substring(1, old.Length - 2);
                        xiaoxi.qqhaoma = newstring;
                    }


                }
                else if (panduan(line, t) == true)//message
                {
                    xiaoxi.flag = true;
                    line = line.Replace(t, "");
                    xiaoxi.zhengwen += line;
                }
                else
                {
                    xiaoxi.zhengwen += line;
                }


            }

            int bYear = 0, bMonth = 0, bDay = 0, bHour = 0, bMin = 0, bSecond = 0;
            int eYear = 0, eMonth = 0, eDay = 0, eHour = 0, eMin = 0, eSecond = 0;
            List<string> addList = new List<string>();
            foreach (var qqNumList in qqList)
            {
                if (int.Parse(qqNumList.nian) >= bYear && int.Parse(qqNumList.nian) <= eYear)
                {
                    if (int.Parse(qqNumList.yue))
            }
            }

            //删除发言少的同学
            foreach (var qqNumList in qqList)
            {
                if (qqNumList.flag == true)
                {
                    if (lDic.list.Count() == 0)
                    {
                        lDic.list.Add(qqNumList.qqhaoma, 1);
                    }
                    else
                    {
                        if (lDic.list.Keys.Contains(qqNumList.qqhaoma))
                        {
                            string temp = qqNumList.qqhaoma;
                            int num = lDic.list[temp];
                            num++;
                            lDic.list.Remove(qqNumList.qqhaoma);
                            lDic.list.Add(qqNumList.qqhaoma, num);
                        }
                        else
                        {
                            lDic.list.Add(qqNumList.qqhaoma, 1);
                        }
                    }

                }
            }

            List<string> delList = new List<string>();

            foreach (string key in lDic.list.Keys)
            {
                if (lDic.list[key] < 4)
                {
                    delList.Add(key);
                }
            }

            foreach (string key in delList)
            {
                lDic.list.Remove(key);
            }

            //删除助教QQ
            List<string> zhuJiao = new List<string>();
            foreach (string zhuJiaoNumber in zhuJiao)
            {
                lDic.list.Remove(zhuJiaoNumber);
            }

            file.Close();

        }
    }
    
}
