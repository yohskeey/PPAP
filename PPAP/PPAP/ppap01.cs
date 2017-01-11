using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAP
{
    class ppap01
    {
        public void startPPAP()
        {
            var pen = "ペン";
            var pineapple = "パイナッポー";
            var apple = "アッポー";
            var successPPAP = new[] { pen, pineapple, apple, pen };   // 正答
            var queuePPAP = new Queue<string>();
            var rnd = new Random();
            var countPPAP = 0;

            while (true)
            {
                var i_have_a = pen;
                var rNum = rnd.Next(0, 3);
                switch (rNum)
                {
                    case 0:
                        i_have_a = pineapple;
                        break;
                    case 1:
                        i_have_a = apple;
                        break;
                }
                Console.Write(i_have_a);

                queuePPAP.Enqueue(i_have_a);
                countPPAP++;

                if (queuePPAP.Count > 4)
                {
                    //最新4件を保存する
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
