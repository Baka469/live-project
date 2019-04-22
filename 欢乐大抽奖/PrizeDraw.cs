using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 欢乐大抽奖
{
    class PrizeDraw
    {
        //抽奖，返回各个奖品名和对应的中奖名单
        public static Dictionary<string, ArrayList> prizeDrawAll(Dictionary<string, int> awards, Dictionary<string, int> list)
        {
            Dictionary<string, ArrayList> winningInfo = new Dictionary<string, ArrayList>();
            //每次抽取一人随机地获取某一件奖品,直到奖池为空
            string selectaward = "";
            while (awards.Count != 0 && list.Count != 0)
            {
                //选中一个奖品
                foreach (var award in awards)
                {
                    selectaward = award.Key;
                    break;
                }
                //如果仅有一件，此奖品已分配完，从奖池中移除
                if (awards[selectaward] == 1)
                {
                    awards.Remove(selectaward);
                }
                //否则奖品数减少1
                else
                {
                    awards[selectaward]--;
                }

                //加权随机选取一个幸运儿
                string luckyDog = prizeDraw(list);
                //获得一件奖品后将不再参与抽奖
                list.Remove(luckyDog);

                if (winningInfo.ContainsKey(selectaward))
                {
                    winningInfo[selectaward].Add(luckyDog);
                }
                else
                {
                    ArrayList temp = new ArrayList();
                    temp.Add(luckyDog);
                    winningInfo.Add(selectaward, temp);
                }
            }
            return winningInfo;
        }

        //抽奖,抽取一人中得某件奖品
        public static string prizeDraw(Dictionary<string, int> list)
        {
            Random random = new Random();

            int sum = 0;
            foreach (int a in list.Values)
            {
                sum += a;
            }
            int rand = random.Next(1, sum);
            int total = 0;
            string s = "";
            foreach (var item in list)
            {
                total += item.Value;
                if (total >= rand)
                {
                    s = item.Key;
                    break;
                }
            }
            return s;
        }
    }
}
