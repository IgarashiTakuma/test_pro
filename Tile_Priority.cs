using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shallow_Learning_Frame
{
    class Tile_Priority//平均を見るタイル//2019/09/14/15:00
    {
      //  Data_Base DB = new Data_Base();
        
        public void Tile_Point(int com)
        {
            double[,] hand_1st = new double[Data_Base.age*2, 9];
            double[,,] hand_2nd = new double[Data_Base.age*2,9, 8];

            double[] max = new double[Data_Base.age*2];
            double hand_3rd=0;
            double hand2_av=0.0;
            int[] next_hand = new int[Data_Base.age*2];
            double white, blue, red;//blue:味方,red//敵,,white:なし
            double[] weight= new double[3] { 1.0,0.8,0.5};
            int[] cnt1 = new int[Data_Base.age*2];
            int cnt2 = 0;
            int cnt3 = 0;
            int flag = 0;
            double white_pt = 0.1;//白の0点と青の0点だった場合白の0を取りたい
            double cmp;
            if(com==0)
            {
                white = 1.0;
                blue = 0.0;//味方
                red = 0.8;//0.8
               
                weight[1] = 0.5;
                weight[2] = 0.8;
                white_pt = 0.1;
            }
            else 
            {
                white = 1.0;
                blue = 0.0;//味方
                red = 0.8;//0.8
                
                weight[1] = 0.5;
                weight[2] = 0.8;
                white_pt = 0.1;
            }
            //1stに2nd,3rdをおもみを付けて足した//フィールド分析相手マス未考慮
            for(int i = Data_Base.age*com; i<Data_Base.age*(com+1);i++)
            {
                Data_Base.memory_x[i, 0] = Data_Base.age_dx[i];
                Data_Base.memory_y[i, 0] = Data_Base.age_dy[i];
                Data_Base.age_dx[i] = 0;//reset
                Data_Base.age_dy[i] = 0;//reset
                for (int h=0;h<Data_Base.height;h++)
                {
                    for(int w=0;w<Data_Base.width;w++)
                    {
                        if (Data_Base.agent_ID[i] == Data_Base.position[h,w])//i番目のエージェント位置
                        {
                            for(int e_y1=-1;e_y1<=1;e_y1++)//1手目
                            {
                                for(int e_x1 = -1; e_x1 <= 1; e_x1++)
                                {
                                    if (0 <= h + e_y1 && h + e_y1 < Data_Base.height && 0 <= w + e_x1 && w + e_x1 < Data_Base.width && (e_x1 != 0 || e_y1 != 0)
                                        &&(Data_Base.memory_x[i,0]+e_x1!=0|| Data_Base.memory_y[i,0] + e_y1 != 0))
                                    {
                                        if (Data_Base.tiled[h + e_y1, w + e_x1] == Data_Base.team_ID[com])
                                        { hand_1st[i, cnt1[i]] = Data_Base.points[h + e_y1, w + e_x1] * blue; }
                                        else if (Data_Base.tiled[h + e_y1, w + e_x1] == 0)
                                        { hand_1st[i, cnt1[i]] = Data_Base.points[h + e_y1, w + e_x1] * white + white_pt; }
                                        else
                                        { hand_1st[i, cnt1[i]] = Data_Base.points[h + e_y1, w + e_x1] * red; }
                                        for (int e_y2 = -1; e_y2 <= 1; e_y2++)
                                        {
                                            for (int e_x2 = -1; e_x2 <= 1; e_x2++)
                                            {
                                                if (0 <= h + e_y1 + e_y2 && h + e_y1 + e_y2 < Data_Base.height && 0 <= w + e_x1 + e_x2 && w + e_x1 + e_x2 < Data_Base.width
                                                    && (e_y1 + e_y2 != 0 || e_x1 + e_x2 != 0) && (e_x2 != 0 || e_y2 != 0))
                                                {
                                                    if (Data_Base.points[h + e_y1 + e_y2, w + e_x1 + e_x2] < 0)
                                                    { hand_2nd[i, cnt1[i], cnt2] = 0; }
                                                    else if (Data_Base.tiled[h + e_y1 + e_y2, w + e_x1 + e_x2] == Data_Base.team_ID[com])
                                                    { hand_2nd[i, cnt1[i], cnt2] = Data_Base.points[h + e_y1 + e_y2, w + e_x1 + e_x2] * blue; }
                                                    else if (Data_Base.tiled[h + e_y1 + e_y2, w + e_x1 + e_x2] == 0)
                                                    { hand_2nd[i, cnt1[i], cnt2] = Data_Base.points[h + e_y1 + e_y2, w + e_x1 + e_x2] * white + white_pt; }
                                                    else
                                                    { hand_2nd[i, cnt1[i], cnt2] = Data_Base.points[h + e_y1 + e_y2, w + e_x1 + e_x2] * red; }
                                                    for (int e_y3 = -1; e_y3 <= 1; e_y3++)
                                                    {
                                                        for (int e_x3 = -1; e_x3 <= 1; e_x3++)
                                                        {
                                                            if (0 <= h + e_y1 + e_y2 + e_y3 && h + e_y1 + e_y2 + e_y3 < Data_Base.height && 0 <= w + e_x1 + e_x2 + e_x3 && w + e_x1 + e_x2 + e_x3 < Data_Base.width)
                                                            {
                                                                if ((e_y1 + e_y2 + e_y3 != 0 || e_x1 + e_y2 + e_x3 != 0) && (e_y1 + e_y3 != 0 || e_x1 + e_x3 != 0) && (e_y2 + e_y3 != 0 || e_x2 + e_x3 != 0) && (e_x3 != 0 || e_y3 != 0))
                                                                {
                                                                    if (Data_Base.points[h + e_y1 + e_y2 + e_y3, w + e_x1 + e_x2 + e_x3] < 0)
                                                                    {
                                                                        hand_3rd += 0;
                                                                    }
                                                                    else if (Data_Base.tiled[h + e_y1 + e_y2 + e_y3, w + e_x1 + e_x2 + e_x3] == Data_Base.team_ID[com])
                                                                    { hand_3rd += Data_Base.points[h + e_y1 + e_y2 + e_y3, w + e_x1 + e_x2 + e_x3] * blue; }
                                                                    else if (Data_Base.tiled[h + e_y1 + e_y2 + e_y3, w + e_x1 + e_x2 + e_x3] == 0)
                                                                    { hand_3rd += Data_Base.points[h + e_y1 + e_y2 + e_y3, w + e_x1 + e_x2 + e_x3] * white + white_pt; }
                                                                    else
                                                                    { hand_3rd += Data_Base.points[h + e_y1 + e_y2 + e_y3, w + e_x1 + e_x2 + e_x3] * red; }
                                                                    cnt3++;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    hand_2nd[i, cnt1[i], cnt2] += (hand_3rd / cnt3) * weight[2];
                                                    hand_3rd = 0;
                                                    cnt3 = 0;
                                                    cnt2++;
                                                }
                                            }
                                        }
                                        for (int j = 0; j < cnt2 - 1; j++)
                                        {
                                            for (int k = j + 1; k < cnt2; k++)
                                            {
                                                if (hand_2nd[i, cnt1[i], j] < hand_2nd[i, cnt1[i], k])
                                                {
                                                    cmp = hand_2nd[i, cnt1[i], j];
                                                    hand_2nd[i, cnt1[i], j] = hand_2nd[i, cnt1[i], k];
                                                    hand_2nd[i, cnt1[i], k] = cmp;
                                                    
                                                }
                                            }
                                        }

                                        for (int j = 0; j < 3 || j < cnt2; j++)
                                        {
                                            hand2_av += hand_2nd[i, cnt1[i], j];
                                        }
                                        if (cnt2 < 3)
                                        { hand2_av /= (cnt2 - 1); }
                                        else
                                        { hand2_av /= 3.0; }

                                        cnt2 = 0;
                                        hand_1st[i, cnt1[i]] += (hand2_av * weight[1]);
                                        hand2_av = 0.0;

                                        //同じ場所指定しない
                                        for (int j = Data_Base.age * com; j < i; j++)
                                        {
                                            if (w + e_x1 == Data_Base.age_x[j] + Data_Base.age_dx[j] - 1 && h + e_y1 == Data_Base.age_y[j] + Data_Base.age_dy[j] - 1)
                                            { flag = 1; }
                                        }
                                        for(int l=0;l<Data_Base.age*2;l++)//競合しているエージェントの位置を指定しない
                                        {
                                            if(Data_Base.apply[l]==0)
                                            {
                                                if (w + e_x1==Data_Base.age_x[l]-1&& h + e_y1 == Data_Base.age_y[l] - 1)
                                                { flag = 1; }
                                            }
                                        }
                                        if (max[i] <= hand_1st[i, cnt1[i]] && flag == 0)
                                        {

                                            max[i] = hand_1st[i, cnt1[i]];
                                            int a = cnt1[i];
                                        //    if (i == 8) { }
                                            switch (cnt1[i])//next_hand[i]
                                            {
                                                case 0:
                                                    Data_Base.age_dx[i] = -1;
                                                    Data_Base.age_dy[i] = -1;
                                                    break;
                                                case 1:
                                                    Data_Base.age_dx[i] = 0;
                                                    Data_Base.age_dy[i] = -1;
                                                    break;
                                                case 2:
                                                    Data_Base.age_dx[i] = 1;
                                                    Data_Base.age_dy[i] = -1;
                                                    break;
                                                case 3:
                                                    Data_Base.age_dx[i] = -1;
                                                    Data_Base.age_dy[i] = 0;
                                                    break;
                                                case 4:
                                                    Data_Base.age_dx[i] = 0;
                                                    Data_Base.age_dy[i] = 0;
                                                    break;
                                                case 5:
                                                    Data_Base.age_dx[i] = 1;
                                                    Data_Base.age_dy[i] = 0;
                                                    break;
                                                case 6:
                                                    Data_Base.age_dx[i] = -1;
                                                    Data_Base.age_dy[i] = 1;
                                                    break;
                                                case 7:
                                                    Data_Base.age_dx[i] = 0;
                                                    Data_Base.age_dy[i] = 1;
                                                    break;
                                                case 8:
                                                    Data_Base.age_dx[i] = 1;
                                                    Data_Base.age_dy[i] = 1;
                                                    break;
                                            }
                                        }
                                        flag = 0;
                                    }
                                    
                                    
                                        
                                    cnt1[i]++;
                                }

                            }
                
                        }
                    }
                }
              
            }
          
            for (int i =Data_Base.age*com; i < Data_Base.age*(com+1); i++)
            {
                //範囲外
                if(Data_Base.age_y[i] + Data_Base.age_dy[i] - 1 < 0 || Data_Base.height <= Data_Base.age_y[i] + Data_Base.age_dy[i] - 1||
                    Data_Base.age_x[i] + Data_Base.age_dx[i]- 1 < 0 || Data_Base.width <= Data_Base.age_x[i] + Data_Base.age_dx[i] - 1)
                {
                    Data_Base.send_type[i] = "stay";
                }
                    //もし、指定先が相手タイルだったら
                else if (com==0&&Data_Base.tiled[Data_Base.age_y[i] + Data_Base.age_dy[i]-1, Data_Base.age_x[i] + Data_Base.age_dx[i]-1]==Data_Base.team_ID[1])
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
