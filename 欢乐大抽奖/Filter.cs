﻿using System;
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

            public string date;
            public string time;
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



        public static Dictionary<string, int> filter(string t, int filterFlag, string filterWord, string bDate, string bTime, string eDate, string eTime)
        {
            //string t = "#我要换组#、#我要红包#、#我爱软工实践#";
            ListDictionary lDic = new ListDictionary();
            List<QQxiaoxi> qqList = new List<QQxiaoxi>();
           

            StreamReader file = new StreamReader(@"QQrecord-2022.txt");
            string line;
            bool panduan(string s, string m)
            {
                //Match matches = Regex.Match(s, m);

                return s.Contains(m);
            }
            QQxiaoxi xiaoxi=new QQxiaoxi();
            while ((line = file.ReadLine()) != null)
            {
                Regex reg = new Regex(@"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}\s.*");
                Match match = reg.Match(line);
                string value = match.Groups[0].Value;
                
                if (value != "")
                {
                    xiaoxi = new QQxiaoxi();
                    qqList.Add(xiaoxi);
                    
                    MatchCollection matches1 = Regex.Matches(line, @"\d{4}-\d{2}-\d{2}");
                    MatchCollection matches2 = Regex.Matches(line, @"\d{2}:\d{2}:\d{2}");

                    MatchCollection matches4 = Regex.Matches(line, @"\(.*\)");
                    MatchCollection matches5 = Regex.Matches(line, "(.*[^@]助教)");

                    foreach (Match item in matches1)//time
                    {
                        /* 
                        string[] sArray =Regex.Split(item.Groups[0].Value,"-");
                        xiaoxi.nian = sArray[0];
                        xiaoxi.yue = sArray[1];
                        xiaoxi.ri = sArray[2];
                        */

                        xiaoxi.date = item.Groups[0].Value;
                    }
                    foreach (Match item in matches2)
                    {

                        xiaoxi.time = item.Groups[0].Value;
                        /*
                        string[] sArray = Regex.Split(item.Groups[0].Value, ":");
                        xiaoxi.xiaoshi = sArray[0];
                        xiaoxi.fenzhong = sArray[1];
                        xiaoxi.miao = sArray[2];
                            */
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

            //判断时间是否有超过规定日期
            //string bDate = "2020-01-01", bTime = "18:21:02";//UI类传进来的开始时间和日期
            //string eDate = "2020-08-08", eTime = "21:00:00";//UI类传进来的结束时间和日期
            DateTime bDT1 = DateTime.Parse(bDate +" "+ bTime);
            DateTime eDT1 = DateTime.Parse(eDate + " " + eTime);
            List<string> addList = new List<string>();
            foreach (var qqNumList in qqList)
            {
                if (qqNumList.flag == true)
                {
                    DateTime sDate = DateTime.Parse(qqNumList.date + " " + qqNumList.time);
                   

                    if (!(DateTime.Compare(bDT1, sDate) > 0 || DateTime.Compare(eDT1, sDate) < 0))
                    {
                        addList.Add(qqNumList.qqhaoma);
                    }
                    /*
                    else if (DateTime.Compare(bDT1, sDate) == 0 || DateTime.Compare(eDT1, sDate) == 0)
                    {
                        if (DateTime.Compare(bDT1, sDate) == 0)
                        {
                            if (DateTime.Compare(bDT2, sTime) < 0)
                            {
                                addList.Add(qqNumList.qqhaoma);
                            }
                            else if (DateTime.Compare(eDT2, sTime) < 0)
                            {
                                addList.Add(qqNumList.qqhaoma);
                            }
                        }
                    }
                    */
                }
            }

            //统计每位同学的发言次数
            foreach (var qqNumList in addList)
            {
                if (lDic.list.Count() == 0)
                {
                    lDic.list.Add(qqNumList, 1);
                }
                else
                {
                    if(qqNumList!=null)
                    {
                        if (lDic.list.Keys.Contains(qqNumList))
                        {
                            string temp = qqNumList;
                            int num = lDic.list[temp];
                            num++;
                            lDic.list.Remove(qqNumList);
                            lDic.list.Add(qqNumList, num);
                        }
                        else
                        {
                            lDic.list.Add(qqNumList, 1);
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
            return lDic.list;
        }
    }

}
