using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shallow_Learning_Frame
{
    class Territory_Priority//タイルポイント少し重め///相手用
    {
        public void Aria_Argo(int mode)
        {
           // double[,,] next_hand = new double[Data_Base.age, 3, 3];//dx+1,dy+1
            int[,] field = new int[Data_Base.height, Data_Base.width];
            double ryouiki_weight = 100;//1以上


        //    double[,] hand_1st = new double[Data_Base.age, 9];
         //   double[,,] hand_2nd = new double[Data_Base.age, 9, 8];

            double[,,,] next_hand= new double[Data_Base.age*2, 9, 9, 9];//age,1手目,2手目,3手目
            int[] x=new int [3];
            int[] y = new int[3];
            int cnt1=0;
            int cnt2=0;
            int cnt3=0;
            int flag = 0;
            double omoiyariyosan = 0.1;
            double max = 0;
            int shift=0;
            //1stに2nd,3rdをおもみを付けて足した//フィールド分析相手マス未考慮
            if (mode == 2)
            {
                for (int i = Data_Base.age; i < Data_Base.age*2; i++)
                {
                    Data_Base.age_dx[i] = 0;//reset
                    Data_Base.age_dy[i] = 0;//reset
                    for (int h = 0; h < Data_Base.height; h++)
                    {
                        for (int w = 0; w < Data_Base.width; w++)
                        {
                            if (Data_Base.agent_ID[i] == Data_Base.position[h, w])//i番目のエージェント位置
                            {
                                for (y[0] = -1; y[0] <= 1; y[0]++)//1手目
                                {
                                    for (x[0] = -1; x[0] <= 1; x[0]++)
                                    {
                                        //移動可能の方向のみ//
                                        if (0 <= h + y[0] && h + y[0] < Data_Base.height && 0 <= w + x[0] && w + x[0] < Data_Base.width && (x[0] != 0 || y[0] != 0)
                                            && Data_Base.tiled[h + y[0], w + x[0]] != Data_Base.team_ID[0])//青を踏まない
                                        {
                                            for (y[1] = -1; y[1] <= 1; y[1]++)
                                            {
                                                for (x[1] = -1; x[1] <= 1; x[1]++)
                                                {
                                                    //移動可能方向のみ//
                                                    if (0 <= h + y[0] + y[1] && h + y[0] + y[1] < Data_Base.height && 0 <= w + x[0] + x[1] && w + x[0] + x[1] < Data_Base.width
                                                        && (y[0] + y[1] != 0 || x[0] + x[1] != 0) && (x[1] != 0 || y[1] != 0)
                                                       && Data_Base.tiled[h + y[0] + y[1], w + x[0] + x[1]] != Data_Base.team_ID[0])


                                                        for (y[2] = -1; y[2] <= 1; y[2]++)
                                                        {
                                                            for (x[2] = -1; x[2] <= 1; x[2]++)
                                                            {
                                                                if (i == 2 && x[0] == 1 && y[0] == -1 && x[1] == 1 && y[1] == 1 && x[2] == -1 && y[2] == 1) { }
                                                                if (i == 2 && x[0] == 1 && y[0] == -1 && x[1] == -1 && y[1] == 0 && x[2] == 1 && y[2] == 0) { }
                                                                //移動可能方向のみ//
                                                                if (0 <= h + y[0] + y[1] + y[2] && h + y[0] + y[1] + y[2] < Data_Base.height && 0 <= w + x[0] + x[1] + x[2] && w + x[0] + x[1] + x[2] < Data_Base.width
                                                                        && (y[0] + y[1] + y[2] != 0 || x[0] + y[1] + x[2] != 0) && (y[1] + y[2] != 0 || x[1] + x[2] != 0) && (x[2] != 0 || y[2] != 0) && (y[0] + y[2] != 0 || x[0] + x[2] != 0)
                                                                       && Data_Base.tiled[h + y[0] + y[1] + y[2], w + x[0] + x[1] + x[2]] != Data_Base.team_ID[0])
                                                                {
                                                                    //  if (i == 2 && x[0] == 1 && y[0] == -1&& x[1] == 1 && y[1] == 1 && x[2] == -1 && y[2] == 1) { }//こいつは100.1
                                                                    if (i == 2 && x[0] == 1 && y[0] == -1 && x[1] == -1 && y[1] == 0 && x[2] == 1 && y[2] == 0) { }//こいつは0のはずなのに最大を取る
                                                                    next_hand[i, cnt1, cnt2, cnt3] = (((Area_Point(x, y, i) - Data_Base.area_point[1]) * ryouiki_weight) + (Tile_Point(x, y, i)) + omoiyariyosan);
                                                                 //   double a = next_hand[i, cnt1, cnt2, cnt3];
                                                                  //  double b = Area_Point(x, y, i);
                                                                   // double c = Tile_Point(x, y, i);
                                                                   // double d = Data_Base.area_point[0];
                                                                    if (max <= next_hand[i, cnt1, cnt2, cnt3])
                                                                    {
                                                                        max = next_hand[i, cnt1, cnt2, cnt3];
                                                                        for (int k = 0; k < 3; k++)
                                                                        {
                                                                            if (k == 0)
                                                                            {
                                                                                Data_Base.age_dx[i] = x[k];
                                                                                Data_Base.age_dy[i] = x[k];
                                                                            }
                                                                            else
                                                                            {
                                                                                Data_Base.memory_x[i, k - 1] = x[k];
                                                                                Data_Base.memory_y[i, k - 1] = x[k];
                                                                            }
                                                                        }
                                                                        if (Data_Base.age_dx[2] == 1 && Data_Base.age_dy[2] == -1) { }//&&Data_Base.memory_x[2,0]==-1&& Data_Base.memory_y[2, 0] ==0&& Data_Base.memory_x[2, 1] == 1 && Data_Base.memory_y[2, 1] == 0)
                                                                        


                                                                    }



                                                                }
                                                                cnt3++;
                                                            }
                                                        }
                                                    cnt3 = 0;

                                                }
                                                cnt2++;
                                            }
                                        }
                                        cnt2 = 0;


                                    }
                                    cnt1++;
                                }

                            }
                            cnt1 = 0;
                            /*
                            for (int j = 0; j < i; j++)
                            {
                                if (w + x[0] == Data_Base.age_x[j] + Data_Base.age_dx[j] - 1 && h + y[0] == Data_Base.age_y[j] + Data_Base.age_dy[j] - 1)
                                { flag = 1; }
                            }
                            for (int j = 0; j < 9; j++)
                            {//1
                                for (int k = 0; k < 9; k++)//2
                                {
                                    for (int l = 0; l < 9; l++)//3
                                    {
                                        for (int m = 0; m < i; m++)
                                        {
                                            int x1, y1;
                                            if (j % 3 == 0)
                                                x1 = -1;
                                            else if (j % 3 == 1)
                                                x1 = 0;
                                            else
                                                x1 = 1;
                                            if (0 <= j && j < 3)
                                                y1 = -1;
                                            else if (3 <= j && j < 6)
                                                y1 = 0;
                                            else
                                                y1 = 1;

                                            double b = next_hand[2, 2, 3, 5];
                                            if (w + x1 == Data_Base.age_x[m] + Data_Base.age_dx[m] - 1 && h + y1 == Data_Base.age_y[m] + Data_Base.age_dy[m] - 1)
                                            { flag = 1; }
                                            { }
                                        }
                                        if (max <= next_hand[i, j, k, l] && flag == 0)
                                        {
                                            max = next_hand[i, j, k, l];
                                            switch (j)
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

                                            for (int n = 0; n < 2; n++)
                                            {
                                                if (n == 0)
                                                { shift = k; }
                                                if (n == 1)
                                                { shift = l; }

                                                switch (shift)//next_hand[i]
                                                {

                                                    case 0:
                                                        Data_Base.memory_x[i, n] = -1;
                                                        Data_Base.memory_x[i, n] = -1;
                                                        break;
                                                    case 1:
                                                        Data_Base.memory_x[i, n] = 0;
                                                        Data_Base.memory_x[i, n] = -1;
                                                        break;
                                                    case 2:
                                                        Data_Base.memory_x[i, n] = 1;
                                                        Data_Base.memory_x[i, n] = -1;
                                                        break;
                                                    case 3:
                                                        Data_Base.memory_x[i, n] = -1;
                                                        Data_Base.memory_x[i, n] = 0;
                                                        break;
                                                    case 4:
                                                        Data_Base.memory_x[i, n] = 0;
                                                        Data_Base.memory_x[i, n] = 0;
                                                        break;
                                                    case 5:
                                                        Data_Base.memory_x[i, n] = 1;
                                                        Data_Base.memory_x[i, n] = 0;
                                                        break;
                                                    case 6:
                                                        Data_Base.memory_x[i, n] = -1;
                                                        Data_Base.memory_x[i, n] = 1;
                                                        break;
                                                    case 7:
                                                        Data_Base.memory_x[i, n] = 0;
                                                        Data_Base.memory_x[i, n] = 1;
                                                        break;
                                                    case 8:
                                                        Data_Base.memory_x[i, n] = 1;
                                                        Data_Base.memory_x[i, n] = 1;
                                                        break;
                                                }
                                            }

                                        }
                                        flag = 0;
                                    }
                                }
                            }
                            max = 0;*/
                        }
                    }
                    max = 0;
                }
                //同じ場所指定しない

                
            
                
                        
            }
            if(mode==1)
            {
                for (int i = Data_Base.age; i < Data_Base.age*2; i++)
                {
                    Data_Base.age_dx[i] = Data_Base.memory_x[i, 0];
                    Data_Base.age_dy[i] = Data_Base.memory_y[i, 0];
                    
                    Data_Base.memory_x[i, 0] = 0;
                    Data_Base.memory_y[i, 0] = 0;
                }
            }
            if(mode==0)
            {
                for(int i=Data_Base.age;i<Data_Base.age*2;i++)
                {
                    Data_Base.age_dx[i] = Data_Base.memory_x[i,0];
                    Data_Base.age_dy[i] = Data_Base.memory_y[i, 0];
                    Data_Base.memory_x[i,0] = Data_Base.memory_x[i, 1];
                    Data_Base.memory_y[i,0] = Data_Base.memory_y[i, 1];
                    Data_Base.memory_x[i, 1]=0;
                    Data_Base.memory_y[i, 1] = 0;
                }
               
            }
            //type決め
            for (int i = Data_Base.age; i < Data_Base.age*2; i++)
            {
                if (Data_Base.age_y[i] + Data_Base.age_dy[i] - 1 < 0 || Data_Base.height <= Data_Base.age_y[i] + Data_Base.age_dy[i] - 1 ||
                    Data_Base.age_x[i] + Data_Base.age_dx[i] - 1 < 0 || Data_Base.width <= Data_Base.age_x[i] + Data_Base.age_dx[i] - 1)
                {
                    Data_Base.send_type[i] = "stay";
                }
                //もし、指定先が相手タイルだったら
                else if (Data_Base.tiled[Data_Base.age_y[i] + Data_Base.age_dy[i] - 1, Data_Base.age_x[i] + Data_Base.age_dx[i] - 1] == Data_Base.team_ID[1])
                {
                    Data_Base.send_type[i] = "remove";
                }
                else { Data_Base.send_type[i] = "move"; }

            }


        }
        //相手のひっくり返す考えない
        private int Tile_Point(int[] x, int[] y,int age)
        {
            int tile = 0;
            int[,] field = new int[Data_Base.height, Data_Base.width];
            if(Data_Base.tiled[Data_Base.age_y[age] + y[0] - 1, Data_Base.age_x[age] + x[0] - 1] !=Data_Base.team_ID[1])
            { tile += Data_Base.points[Data_Base.age_y[age] + y[0] - 1, Data_Base.age_x[age] + x[0] - 1]; }
            if(Data_Base.tiled[Data_Base.age_y[age] + y[0] + y[1] - 1, Data_Base.age_x[age] + x[0] + x[1] - 1] != Data_Base.team_ID[1])
                tile += Data_Base.points[Data_Base.age_y[age] + y[0] + y[1] - 1, Data_Base.age_x[age] + x[0] + x[1] - 1];
            if (Data_Base.tiled[Data_Base.age_y[age] + y[0] + y[1] + y[2] - 1, Data_Base.age_x[age] + x[0] + x[1] + x[2] - 1] != Data_Base.team_ID[1])
                tile += Data_Base.points[Data_Base.age_y[age] + y[0] + y[1] + y[2] - 1, Data_Base.age_x[age] + x[0] + x[1] + x[2] - 1];
            if(tile<0)
            {
                tile = 0;
            }

            return tile;
           
        }
       
        private int Area_Point(int[] x, int[] y, int age)
        {

            int area = 0;
            int block = 0;
            int[,] field = new int[Data_Base.height, Data_Base.width];
            int cnt;
            int a1, a2, b1, b2, c1, c2;
            a1 = Data_Base.age_y[age] + y[0] - 1;
            a2 = Data_Base.age_x[age] + x[0] - 1;
            b1 = Data_Base.age_y[age] + y[0] + y[1] - 1;
            b2 = Data_Base.age_x[age] + x[0] + x[1] - 1;
            c1 = Data_Base.age_y[age] + y[0] + y[1] + y[2] - 1;
            c2 = Data_Base.age_x[age] + x[0] + x[1] + x[2] - 1;




            for (int i = 0; i < Data_Base.height; i++)
            {

                for (int j = 0; j < Data_Base.width; j++)
                {

                    field[i, j] = Data_Base.tiled[i, j];
                }
            }
            for (int i = 1; block == 0; i++)
            {
                if (Data_Base.team_ID[0] != i && Data_Base.team_ID[1] != i)
                {
                    block = i;
                }
            }
            for (int i = 0; i < Data_Base.width; i++)
            {
                if (field[0, i] != Data_Base.team_ID[1] && (a1 != 0 || a2 != i) && (b1 != 0 || b2 != i) && (c1 != 0 || c2 != i))
                    field[0, i] = block;
                if (field[Data_Base.height - 1, i] != Data_Base.team_ID[1] && (a1 != Data_Base.height - 1 || a2 != i) && (b1 != Data_Base.height - 1 || b2 != i) && (c1 != Data_Base.height - 1 || c2 != i))
                    field[Data_Base.height - 1, i] = block;

            }
            for (int i = 0; i < Data_Base.height; i++)
            {
                if (field[i, 0] != Data_Base.team_ID[1] && (a1 != i || a2 != 0) && (b1 != i || b2 != 0) && (c1 != i || c2 != 0))
                    field[i, 0] = block;
                if (field[i, Data_Base.width - 1] != Data_Base.team_ID[0] && (a1 != i || a2 != Data_Base.width - 1) && (b1 != i || b2 != Data_Base.width - 1) && (c1 != i || c2 != Data_Base.width - 1))
                    field[i, Data_Base.width - 1] = block;
            }
            cnt = 1;

            while (0 != cnt)
            {
                cnt = 0;
                for (int i = 0; i < Data_Base.height; i++)
                {
                    for (int j = 0; j < Data_Base.width; j++)
                    {
                        if (field[i, j] == block)
                        {
                            for (int e_y1 = -1; e_y1 <= 1; e_y1++)//1手目
                            {
                                for (int e_x1 = -1; e_x1 <= 1; e_x1++)
                                {
                                    if (e_x1 * e_y1 == 0)//十字方向
                                    {
                                        if (0 <= i + e_y1 && i + e_y1 < Data_Base.height && 0 <= j + e_x1 && j + e_x1 < Data_Base.width)//境界外を見ない
                                        {
                                            if (Data_Base.tiled[i + e_y1, j + e_x1] != Data_Base.team_ID[1] && field[i + e_y1, j + e_x1] != block && (a1 != i + e_y1 || a2 != j + e_x1) && (b1 != i + e_y1 || b2 != j + e_x1) && (c1 != i + e_y1 || c2 != j + e_x1))
                                            {
                                                field[i + e_y1, j + e_x1] = block;
                                                cnt++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < Data_Base.height; i++)
            {
                for (int j = 0; j < Data_Base.width; j++)
                {
                    //  massButtons[i, j].Text = test[i, j].ToString();
                    if (field[i, j] != block && field[i, j] != Data_Base.team_ID[1] && (a1 != i || a2 != j) && (b1 != i || b2 != j) && (c1 != i || c2 != j))
                    {
                        if (Data_Base.points[i, j] < 0)
                        {
                            area -= Data_Base.points[i, j];
                        }
                        else
                            area += Data_Base.points[i, j];

                    }
                 
                }
            }

            return area;
        }

    }
    
}
