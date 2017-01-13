using System;
using System.Collections.Generic;
using System.Linq;

namespace PPAP
{
    class PPAP02
    {
        public void StartPPAP()
        {
            const string pen = "ペン";
            const string pai = "パイ";
            const string axtu = "アッ";
            const string natsu = "ナッ";
            const string po = "ポー";

            var words = new[] { pen, pai, axtu, natsu, po };
            var successPPAP = new[] { pen, pai, natsu, po, axtu, po, pen };   // 正答
            var queuePPAP = new Queue<string>();
            var rnd = new Random();
            var countPPAP = 0;

            var countPen = 0;
            var countPineapple = 0;
            var countApple = 0;
            var countPineapplePen = 0;
            var countApplePen = 0;

            var sequence = "";

            while (true)
            {
                var word = words[rnd.Next(0, words.Length)];
                Console.Write(word);

                queuePPAP.Enqueue(word);
                countPPAP++;

                if (queuePPAP.Count > successPPAP.Length)
                {
                    //最新5件を保存する
                    queuePPAP.Dequeue();
                }

                switch (word)
                {
                    case pen:
                        // ペンの出現数
                        countPen++;
                        if (sequence == axtu + po)
                        {
                            // アッポーペン
                            countApplePen++;
                        }
                        else if (sequence == pai + natsu + po)
                        {
                            //パイナッポーペン
                            countPineapplePen++;
                        }
                        sequence = "";
                        break;
                    case po:
                        // ポー
                        sequence += po;
                        if(sequence == axtu + po)
                        {
                            // アッポー
                            countApple++;
                        }else if(sequence == pai + natsu + po)
                        {
                            //パイナッポー
                            countPineapple++;
                        }else
                        {
                            sequence = "";
                        }
                        break;
                    case axtu:
                        sequence = axtu;
                        break;
                    case pai:
                        sequence = pai;
                        break;
                    case natsu:
                        if(sequence == pai)
                        {
                            sequence += natsu;
                        }else
                        {
                            sequence = "";
                        }
                        break;
                    default:
                        break;
                }

                if (queuePPAP.ToArray().SequenceEqual(successPPAP))
                {
                    break;
                }
            }
            Console.WriteLine(@"

I have {0} ペン.
I have {1} アッポー.
Ah
{2} アッポーペン！

I have {0} ペン.
I have {3} パイナッポー.
Ah
{4} パイナッポーペン！

アッポーペン～ パイナッポーペン～", countPen, countApple, countApplePen, countPineapple, countPineapplePen);
            Console.WriteLine("\nペンパイナッポーアッポーペン！（I have {0} words）", countPPAP);
            Console.ReadKey();
        }
    }
}
