using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shallow_Learning_Frame
{
    class Five_Hund_Points//平均を見るタイル//2019/09/14/15:00
    {
        //  Data_Base DB = new Data_Base();

        public void Five_Points(int com)
        {
            double[] evaluation = new double[5];

            //double[] max = new double[Data_Base.age * 2];
            double max = 0;
            double hand;
            int[] next_hand = new int[Data_Base.age * 2];
            double white=1, blue=0.01, red=0.8;//blue:味方,red//敵,,white:なし
            double[] weight = new double[5] { 1.0, 0.5, 0.2, 0.3, 0.2 };
            int hand_cnt = 0;
            int[] cnt1 = new int[Data_Base.age * 2];
            int[] ex = new int[5];
            int[] ey = new int[5];
         //   int[] judge_cnt = new int[5];
            //この中でターン数、エージェントの状況を見て重みを変える。

            int flag = 0;
            double white_pt = 0.1;//白の0点と青の0点だった場合白の0を取りたい
           
            //1stに2nd,3rdをおもみを付けて足した//フィールド分析相手マス未考慮
            for (int i = Data_Base.age * com; i < Data_Base.age * (com + 1); i++)
            {
                Data_Base.memory_x[i, 0] = Data_Base.age_dx[i];
                Data_Base.memory_y[i, 0] = Data_Base.age_dy[i];
                Data_Base.age_dx[i] = 0;//reset
                Data_Base.age_dy[i] = 0;//reset
                for (int h = 0; h < Data_Base.height; h++)
                {
                    for (int w = 0; w < Data_Base.width; w++)
                    {
                        if (Data_Base.agent_ID[i] == Data_Base.position[h, w])//i番目のエージェント位置
                        {
                            for (ey[0] = -1; ey[0] <= 1; ey[0]++)//1手目
                            {
                                for (ex[0] = -1; ex[0] <= 1; ex[0]++)
                                {
                                    if (0 <= h + ey[0] && h + ey[0] < Data_Base.height && 0 <= w + ex[0] && w + ex[0] < Data_Base.width && (ex[0] != 0 || ey[0] != 0) && (Data_Base.memory_x[i, 0] + ex[0] != 0 || Data_Base.memory_y[i, 0] + ey[0] != 0))
                                    {
                                        for (ey[1] = -1; ey[1] <= 1; ey[1]++)//2手目
                                        {
                                            for (ex[1] = -1; ex[1] <= 1; ex[1]++)
                                            {
                                                if (0 <= h + ey[0] + ey[1] && h + ey[0] + ey[1] < Data_Base.height && 0 <= w + ex[0] + ex[1] && w + ex[0] + ex[1] < Data_Base.width
                                                    && (ey[0] + ey[1] != 0 || ex[0] + ex[1] != 0) && (ex[1] != 0 || ey[1] != 0))
                                                {
                                                    for (ey[2] = -1; ey[2] <= 1; ey[2]++)//3手目
                                                    {
                                                        for (ex[2] = -1; ex[2] <= 1; ex[2]++)//3手目
                                                        {
                                                            if (0 <= h + ey[0] + ey[1] + ey[2] && h + ey[0] + ey[1] + ey[2] < Data_Base.height && 0 <= w + ex[0] + ex[1] + ex[2] && w + ex[0] + ex[1] + ex[2] < Data_Base.width 
                                                                && (ey[0] + ey[1] + ey[2] != 0 || ex[0] + ey[1] + ex[2] != 0) && (ey[0] + ey[2] != 0 || ex[0] + ex[2] != 0) && (ey[1] + ey[2] != 0 || ex[1] + ex[2] != 0) && (ex[2] != 0 || ey[2] != 0))
                                                            {
                                                                for (ey[3] = -1; ey[3] <= 1; ey[3]++)//4手目
                                                                {
                                                                    for (ex[3] = -1; ex[3] <= 1; ex[3]++)
                                                                    {
                                                                        if (0 <= h + ey[0] + ey[1] + ey[2] + ey[3] && h + ey[0] + ey[1] + ey[2]+ey[3] < Data_Base.height && 0 <= w + ex[0] + ex[1] + ex[2] + ex[3] && w + ex[0] + ex[1] + ex[2] +ex[3] < Data_Base. width
                                                                             && (ex[3] != 0 || ey[3] != 0) && (ey[2] + ey[3]  != 0 || ex[2] + ey[3] != 0) && (ey[1] + ey[2] + ey[3] != 0 || ex[1] + ex[2] + ey[3] != 0) && (ey[0] + ey[1] + ey[2] + ey[3] != 0 || ex[0] + ex[1] + ex[2] + ey[3] != 0) )
 {
                                                                            for (ey[4] = -1; ey[4] <= 1; ey[4]++)//5手目
                                                                            {
                                                                                for (ex[4] = -1; ex[4] <= 1; ex[4]++)
                                                                                {
                                                                                    if (0 <= h + ey[0] + ey[1] + ey[2] + ey[3] + ey[4] && h + ey[0] + ey[1] + ey[2] + ey[3] + ey[4] < Data_Base.height && 0 <= w + ex[0] + ex[1] + ex[2] + ex[3] + ex[4] && w + ex[0] + ex[1] + ex[2] + ex[3] + ex[4] < Data_Base.width
                                                                                     && (ex[4] != 0 || ey[4] != 0) && (ey[3] + ey[4] != 0 || ex[3] + ey[4] != 0) && (ey[2] + ey[3] + ey[4] != 0 || ex[2] + ex[3] + ey[4] != 0) && (ey[1] + ey[2] + ey[3] + ey[4] != 0 || ex[1] + ex[2] + ex[3] + ey[4] != 0) && (ey[0] + ey[1] + ey[2] + ey[3] + ey[4] != 0 || ex[0]+ ex[1] + ex[2] + ex[3] + ey[4] != 0))
                                                                                    {
                                                                                        

                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                }
                                            }
                                        }

                                    }
                                }

                            }

                        }
                    }
                }
                max = 0;
            }



            for (int i = Data_Base.age * com; i < Data_Base.age * (com + 1); i++)
            {
                //範囲外
                if (Data_Base.age_y[i] + Data_Base.age_dy[i] - 1 < 0 || Data_Base.height <= Data_Base.age_y[i] + Data_Base.age_dy[i] - 1 ||
                    Data_Base.age_x[i] + Data_Base.age_dx[i] - 1 < 0 || Data_Base.width <= Data_Base.age_x[i] + Data_Base.age_dx[i] - 1)
                {
                    Data_Base.send_type[i] = "stay";
                }
                //もし、指定先が相手タイルだったら
                else if (com == 0 && Data_Base.tiled[Data_Base.age_y[i] + Data_Base.age_dy[i] - 1, Data_Base.age_x[i] + Data_Base.age_dx[i] - 1] == Data_Base.team_ID[1])
                {
                    Data_Base.send_type[i] = "remove";
                }
                else if (com == 1 && Data_Base.tiled[Data_Base.age_y[i] + Data_Base.age_dy[i] - 1, Data_Base.age_x[i] + Data_Base.age_dx[i] - 1] == Data_Base.team_ID[0])
                {
                    Data_Base.send_type[i] = "remove";
                }
                else { Data_Base.send_type[i] = "move"; }

            }



        }
    }
}
