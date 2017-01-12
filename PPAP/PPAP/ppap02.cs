using System;
using System.Collections.Generic;
using System.Linq;

namespace PPAP
{
    class PPAP02
    {
        public void StartPPAP()
        {
            var pen = "ペン";
            var pai = "パイ";
            var axtu = "アッ";
            var natsu = "ナッ";
            var po = "ポー";

            var words = new[] { pen, pai, axtu, natsu, po };
            var successPPAP = new[] { pen, pai, natsu, po, axtu, po, pen };   // 正答
            var queuePPAP = new Queue<string>();
            var rnd = new Random();
            var countPPAP = 0;

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
