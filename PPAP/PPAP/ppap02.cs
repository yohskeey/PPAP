using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAP
{
    class ppap02
    {
        public void startPPAP()
        {
            var pen = "ペン";
            var pai = "パイ";
            var axtu = "アッ";
            var natsu = "ナッ";
            var po = "ポー";
            var successPPAP = new[] { pen, pai, natsu, po, axtu, po, pen };   // 正答
            var queuePPAP = new Queue<string>();
            var rnd = new Random();
            var countPPAP = 0;

            while (true)
            {
                var have = pen;
                var rNum = rnd.Next(0, 5);
                switch (rNum)
                {
                    case 0:
                        have = pai;
                        break;
                    case 1:
                        have = axtu;
                        break;
                    case 2:
                        have = natsu;
                        break;
                    case 3:
                        have = po;
                        break;
                }
                Console.Write(have);

                queuePPAP.Enqueue(have);
                countPPAP++;

                if (queuePPAP.Count > 7)
                {
                    //最新5件を保存する
                    queuePPAP.Dequeue();
                }

                if (queuePPAP.ToArray().SequenceEqual(successPPAP))
                {
                    break;
                }
            }
            Console.WriteLine("\nペンパイナッポーアッポーペン！（I have {0} words）", countPPAP);
            Console.ReadKey();
        }
    }
}
