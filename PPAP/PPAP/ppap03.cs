using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAP
{
    class ppap03
    {
        public void startPPAP()
        {
            var pen = "ペン";
            var pai = "パイ";
            var axtu = "アッ";
            var natsu = "ナッ";
            var po = "ポー";

            var pop = "ポプ";
            var team = "テピ";
            var epic = "ピック";

            var words = new[] { pen, pai, axtu, natsu, po, pop, team, epic };

            var successPPAP = new[] { pen, pai, natsu, po, axtu, po, pen };   // 正答
            var successPopTeamEpic = new[] { pop, team, epic }; //ポプテピピック

            var queuePPAP = new Queue<string>();
            var queuePopTeamEpic = new Queue<string>();
            var rnd = new Random();
            var countPPAP = 0;

            while (true)
            {
                var word = words[rnd.Next(0, words.Length)];
                
                Console.Write(word);

                queuePPAP.Enqueue(word);
                queuePopTeamEpic.Enqueue(word);
                countPPAP++;

                if (queuePPAP.Count > successPPAP.Length)
                {
                    //最新7件を保存する
                    queuePPAP.Dequeue();
                }
                if (queuePPAP.ToArray().SequenceEqual(successPPAP))
                {
                    Console.WriteLine("\n\nペンパイナッポーアッポーペン！（I have {0} words）", countPPAP);
                    break;
                }
                if (queuePopTeamEpic.Count > successPopTeamEpic.Length)
                {
                    //最新3件を保存する
                    queuePopTeamEpic.Dequeue();
                }
                if (queuePopTeamEpic.ToArray().SequenceEqual(successPopTeamEpic))
                {
                    Console.WriteLine("\n\nエイサァァ～イハラマスコ～イ（ぜったい {0}回 流行る）", countPPAP);
                    break;
                }

            }
            Console.ReadKey();
        }
    }
}
