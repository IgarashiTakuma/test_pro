using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shallow_Learning_Frame
{
    class Tile_Straight_Way//2019/09/14/15:00
    {
        public void Tile_Point(int com)
        {
            double[] evaluation=new double[5];

            //double[] max = new double[Data_Base.age * 2];
            double max = 0;
            double hand;
            int[] next_hand = new int[Data_Base.age * 2];
            double white, blue, red;//blue:味方,red//敵,,white:なし
            double[] weight = new double[5] { 1.0, 0.5, 0.2,0.3,0.2};
            int[] cnt1 = new int[Data_Base.age * 2];
            int[] ex = new int[5];
            int[] ey = new int[5];
            
            int flag = 0;
            double white_pt = 0.1;//白の0点と青の0点だった場合白の0を取りたい
            double cmp;
            if (com == 0)
            {
                white = 1.0;
                blue = 0.0001;//味方
                red = 0.8;//0.8
                weight[0] = 1;
                weight[1] = 0.5;
                weight[2] = 0.3;
                white_pt = 0.1;
            }
            else
            {
                white = 1.0;
                blue = 0.0;//味方
                red = 0.8;//0.8

                weight[1] = 0;
                weight[2] = 0;
                white_pt = 0.1;
            }
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
                                for ( ex[0] = -1; ex[0] <= 1; ex[0]++)
                                {
                                    if (0 <= h + ey[0] && h + ey[0] < Data_Base.height && 0 <= w + ex[0] && w + ex[0] < Data_Base.width && (ex[0] != 0 || ey[0] != 0)&&(Data_Base.memory_x[i, 0] + ex[0] != 0 || Data_Base.memory_y[i, 0] + ey[0] != 0))
                                    {
                                        if (Data_Base.tiled[h + ey[0], w + ex[0]] == Data_Base.team_ID[com])
                                        { evaluation[0] = Data_Base.points[h + ey[0], w + ex[0]] * blue; }
                                        else if (Data_Base.tiled[h + ey[0], w + ex[0]] == 0)
                                        { evaluation[0] = Data_Base.points[h + ey[0], w + ex[0]] * white + white_pt; }
                                        else
                                        { evaluation [0]= Data_Base.points[h + ey[0], w + ex[0]] * red; }
                                        for ( ey[1] = -1; ey[1] <= 1; ey[1]++)
                                        {
                                            for ( ex[1] = -1; ex[1] <= 1; ex[1]++)
                                            {
                                                if (0 <= h + ey[0] + ey[1] && h + ey[0] + ey[1] < Data_Base.height && 0 <= w + ex[0] + ex[1] && w + ex[0] + ex[1] < Data_Base.width
                                                    && (ey[0] + ey[1] != 0 || ex[0] + ex[1] != 0) && (ex[1] != 0 || ey[1] != 0))
                                                {
                                                    if (Data_Base.tiled[h + ey[0] + ey[1], w + ex[0] + ex[1]] == Data_Base.team_ID[com])
                                                    { evaluation[1] = Data_Base.points[h + ey[0] + ey[1], w + ex[0] + ex[1]] * blue; }
                                                    else if (Data_Base.tiled[h + ey[0] + ey[1], w + ex[0] + ex[1]] == 0)
                                                    { evaluation[1] = Data_Base.points[h + ey[0] + ey[1], w + ex[0] + ex[1]] * white + white_pt; }
                                                    else
                                                    { evaluation[1] = Data_Base.points[h + ey[0] + ey[1], w + ex[0] + ex[1]] * red; }
                                                    for (ey[2] = -1; ey[2] <= 1; ey[2]++)
                                                    {
                                                        for (ex[2] = -1; ex[2] <= 1; ex[2]++)
                                                        {
                                                            if (0 <= h + ey[0] + ey[1] + ey[2] && h + ey[0] + ey[1] + ey[2] < Data_Base.height && 0 <= w + ex[0] + ex[1] + ex[2] && w + ex[0] + ex[1] + ex[2] < Data_Base.width)
                                                            {
                                                                if ((ey[0] + ey[1] + ey[2] != 0 || ex[0] + ey[1] + ex[2] != 0) && (ey[0] + ey[2] != 0 || ex[0] + ex[2] != 0) && (ey[1] + ey[2] != 0 || ex[1] + ex[2] != 0) && (ex[2] != 0 || ey[2] != 0))
                                                                {
                                                                    if (Data_Base.tiled[h + ey[0] + ey[1]+ey[2], w + ex[0] + ex[1]+ex[2]] == Data_Base.team_ID[com])
                                                                    { evaluation[2] = Data_Base.points[h + ey[0] + ey[1]+ey[2], w + ex[0] + ex[1]+ex[2]] * blue; }
                                                                    else if (Data_Base.tiled[h + ey[0] + ey[1]+ey[2], w + ex[0] + ex[1]+ex[2]] == 0)
                                                                    { evaluation[2] = Data_Base.points[h + ey[0] + ey[1]+ey[2], w + ex[0] + ex[1]+ex[2]] * white + white_pt; }
                                                                    else
                                                                    { evaluation[2] = Data_Base.points[h + ey[0] + ey[1]+ey[2], w + ex[0] + ex[1]+ex[2]] * red; }
                                                                    //同じ場所指定しない
                                                                    for (int j = Data_Base.age * com; j < i; j++)
                                                                    {
                                                                        if (w + ex[0] == Data_Base.age_x[j] + Data_Base.age_dx[j] - 1 && h + ey[0] == Data_Base.age_y[j] + Data_Base.age_dy[j] - 1)
                                                                        { flag = 1; }   
                                                                    }
                                                                    for (int l = 0; l < Data_Base.age * 2; l++)//競合しているエージェントの位置を指定しない
                                                                    {
                                                                        if (Data_Base.apply[l] == 0)
                                                                        {
                                                                            if (w + ex[0] == Data_Base.age_x[l] - 1 && h + ey[0] == Data_Base.age_y[l] - 1)
                                                                            { flag = 1; }
                                                                        }
                                                                    }
                                                                    hand = 0;
                                                                    for(int l=0;l<3;l++)
                                                                    {
                                                                        hand += evaluation[l] * weight[l];
                                                                    }
                                                                    if (max <=hand  && flag == 0)
                                                                    {
                                                                        max = hand;
                                                                        Data_Base.age_dx[i] =  ex[0];
                                                                        Data_Base.age_dy[i] =  ey[0];
                                                                    }
                                                                    flag = 0;
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
