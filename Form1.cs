using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shallow_Learning_Frame
{
    public partial class Form1 : Form
    {
        Data_Base DB = new Data_Base();
        Reseave_Data RD = new Reseave_Data();
        Sending_Data SD = new Sending_Data();
        Tile_Priority TP = new Tile_Priority();
        Territory_Priority AT = new Territory_Priority();
        Tile_Straight_Way TS = new Tile_Straight_Way();
        Input_UC[] IUC = new Input_UC[8];
        public Form1()//画面最大化、初期化
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; RD.Init_Setting();
            sending_button.Enabled = false;
            next_button.Enabled = false;
            
        }
        //初期データ処理
        private void reseace_button_Click(object sender, EventArgs e)
        {
            RD.Init_Setting();//普遍のデータ受け取り
            RD.Regular_Setting();//フィールド状況、ターン数受け取り
            for (int i = 0; i < Data_Base.age*2; i ++)
            { Data_Base.apply[i] = 1; }
                Init_buttons();//フィールドボタン生成
            Init_UCs();//egent個の行動情報入力スペース確保
            Tiled_Colors();//タイルの色

            UC_Button_Blind(0);//0:味方の入力確保(入力不可スペースのブラインド)

            Choosing_Algorithm();
            Cheak_Ans(0);//チェック入れ

            /*分析→セレクト→演算*/
            reseace_button.Enabled = false;
            next_button.Enabled = true;

         //  Thread.Sleep(10000);
          // next_button_Click(sender, e);

        }
        private void Cheak_Ans(int com)
        {
            for (int i = 0; i < Data_Base.age; i++)
            {
                if (Data_Base.age_dx[i+Data_Base.age*com] == -1 && Data_Base.age_dy[i+Data_Base.age * com] == -1)
                { IUC[i].UL.Checked = true; }
                else if (Data_Base.age_dx[i+Data_Base.age * com] == 0 && Data_Base.age_dy[i+Data_Base.age * com] == -1)
                { IUC[i].Upper.Checked = true; }
                else if (Data_Base.age_dx[i+Data_Base.age * com] == 1 && Data_Base.age_dy[i+Data_Base.age * com] == -1)
                { IUC[i].UR.Checked = true; }
                else if (Data_Base.age_dx[i+Data_Base.age * com] == -1 && Data_Base.age_dy[i+Data_Base.age * com] == 0)
                { IUC[i].Left.Checked = true; }
                else if (Data_Base.age_dx[i + Data_Base.age * com] == 0 && Data_Base.age_dy[i + Data_Base.age * com] == 0)
                { IUC[i].Center.Checked = true; }
                else if (Data_Base.age_dx[i+Data_Base.age * com] == 1 && Data_Base.age_dy[i + Data_Base.age * com] == 0)
                { IUC[i].Right.Checked = true; }
                else if (Data_Base.age_dx[i + Data_Base.age * com] == -1 && Data_Base.age_dy[i + Data_Base.age * com] == 1)
                { IUC[i].BL.Checked = true; }
                else if (Data_Base.age_dx[i + Data_Base.age * com] == 0 && Data_Base.age_dy[i + Data_Base.age * com] == 1)
                { IUC[i].Buttom.Checked = true; }
                else if (Data_Base.age_dx[i + Data_Base.age * com] == 1 && Data_Base.age_dy[i + Data_Base.age * com] == 1)
                { IUC[i].BR.Checked = true; }
                if (Data_Base.send_type[i + Data_Base.age * com] == "move")
                { IUC[i].RB_move.Checked = true; }
                else if (Data_Base.send_type[i + Data_Base.age * com] == "remove")
                { IUC[i].RB_remove.Checked = true; }
                else if (Data_Base.send_type[i + Data_Base.age * com] == "stay")
                { IUC[i].RB_stay.Checked = true; }
            }
        }
        //IUCのブラインド(Data_Base.age_x[],age_y[])によって行う
        private void UC_Button_Blind(int com)
        {
            for (int i = 0; i < Data_Base.age; i++)
            {
                IUC[i].UL.Enabled = true;
                IUC[i].Upper.Enabled = true;
                IUC[i].UR.Enabled = true;
                IUC[i].Left.Enabled = true;
                IUC[i].Center.Enabled = true;
                IUC[i].Right.Enabled = true;
                IUC[i].BL.Enabled = true;
                IUC[i].Buttom.Enabled = true;
                IUC[i].BR.Enabled = true;
                if (Data_Base.age_y[i + Data_Base.age * com] == 1)
                {
                    IUC[i].UL.Enabled = false;
                    IUC[i].Upper.Enabled = false;
                    IUC[i].UR.Enabled = false;
                }
                if (Data_Base.age_y[i + Data_Base.age * com] == Data_Base.height)
                {
                    IUC[i].BL.Enabled = false;
                    IUC[i].Buttom.Enabled = false;
                    IUC[i].BR.Enabled = false;
                }
                if (Data_Base.age_x[i + Data_Base.age * com] == 1)
                {
                    IUC[i].UL.Enabled = false;
                    IUC[i].Left.Enabled = false;
                    IUC[i].BL.Enabled = false;
                }
                if (Data_Base.age_x[i + Data_Base.age * com] == Data_Base.width)
                {
                    IUC[i].UR.Enabled = false;
                    IUC[i].Right.Enabled = false;
                    IUC[i].BR.Enabled = false;
                }

            }
        }

        //IUCをエージェント個用意//
        private void Init_UCs()
        {

            //Input_UC[] IUC = new Input_UC[Data_Base.age];

            for (int i = 0; i < Data_Base.age; i++)
            {
                IUC[i] = new Input_UC();    //  必須
                this.Controls.Add(IUC[i]);

                if (i < 4)
                { IUC[i].Location = new Point(1000, tableLayoutPanel1.Bottom + IUC[i].Bottom * i); }
                else
                { IUC[i].Location = new Point(1180, tableLayoutPanel1.Bottom + IUC[i].Bottom * (i - 4)); }

                IUC[i].GB_dir.Text = "agent_ID：" + Data_Base.agent_ID[i];
            }
        }

        //フィールドヴィジュアル用ボタン生成//
        private void Init_buttons()
        {
            int i, j;

            //ボタンコントロール配列の作成
            this.massButtons = new System.Windows.Forms.Button[Data_Base.height + 1, Data_Base.width + 1];
            //ボタンコントロールのインスタンス作成し、プロパティを設定する
            this.SuspendLayout();
            //buttonを配列で生成(初期状態)
            for (i = 0; i < Data_Base.height; i++)
            {
                for (j = 0; j < Data_Base.width; j++)
                {
                    //インスタンス作成
                    this.massButtons[i, j] = new System.Windows.Forms.Button();
                    //プロパティ設定
                    this.massButtons[i, j].Name = (Data_Base.height * (i) + j).ToString();
                    this.massButtons[i, j].Text = Data_Base.points[i, j].ToString();
                    this.massButtons[i, j].Size = new Size((1000 / Data_Base.width), (700 / Data_Base.height));
                    this.massButtons[i, j].Location = new Point(j * (1000 / Data_Base.width), i * (700 / Data_Base.height) + tableLayoutPanel1.Bottom);
                    this.massButtons[i, j].Font = new Font("Arial",10);
                }
            }
            this.Controls.AddRange(this.massButtons.Cast<Control>().ToArray());

        }

        //エージェントの色
        private void Tiled_Colors()
        {
            //フィールドの色
            for (int i = 0; i < Data_Base.height; i++)
            {
                for (int j = 0; j < Data_Base.width; j++)
                {
                    massButtons[i, j].BackColor = Color.White;
                    massButtons[i, j].BackgroundImage = null;
                    if (Data_Base.tiled[i, j] == Data_Base.team_ID[0])
                    {

                        massButtons[i, j].BackColor = Color.Aqua;
                    }
                    if (Data_Base.tiled[i, j] == Data_Base.team_ID[1])
                    {
                        
                        massButtons[i, j].BackColor = Color.Pink;
                    }
                   
                }
            }
            //エージェントの色
            for (int i = 0; i < Data_Base.height; i++)
            {
                for (int j = 0; j < Data_Base.width; j++)
                {
                    for (int k = 0; k < Data_Base.age * 2; k++)
                    {
                        if (Data_Base.position[i, j] == Data_Base.agent_ID[k])
                        {
                            if (k < Data_Base.age)
                            {
                                massButtons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                                switch (k)
                                {
                                    case 0:
                                        massButtons[i, j].BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\takum\Desktop\ソフトウェア開発\pro_pic/ao1.png");
                                        break;
                                    case 1:
                                        massButtons[i, j].BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\takum\Desktop\ソフトウェア開発\pro_pic/ao2.png");
                                        break;
                                    case 2:
                                        massButtons[i, j].BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\takum\Desktop\ソフトウェア開発\pro_pic/ao3.png");
                                        break;
                                    case 3:
                                        massButtons[i, j].BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\takum\Desktop\ソフトウェア開発\pro_pic/ao4.png");
                                        break;
                                    case 4:
                                        massButtons[i, j].BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\takum\Desktop\ソフトウェア開発\pro_pic/ao5.png");
                                        break;
                                    case 5:
                                        massButtons[i, j].BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\takum\Desktop\ソフトウェア開発\pro_pic/ao6.png");
                                        break;
                                    case 6:
                                        massButtons[i, j].BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\takum\Desktop\ソフトウェア開発\pro_pic/ao7.png");
                                        break;
                                    case 7:
                                        massButtons[i, j].BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\takum\Desktop\ソフトウェア開発\pro_pic/ao8.png");
                                        break;

                                }

                            }

                            else
                            {
                                massButtons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                                switch (k - Data_Base.age)
                                {
                                    case 0:
                                        massButtons[i, j].BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\takum\Desktop\ソフトウェア開発\pro_pic/aka1.png");
                                        break;
                                    case 1:
                                        massButtons[i, j].BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\takum\Desktop\ソフトウェア開発\pro_pic/aka2.png");
                                        break;
                                    case 2:
                                        massButtons[i, j].BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\takum\Desktop\ソフトウェア開発\pro_pic/aka3.png");
                                        break;
                                    case 3:
                                        massButtons[i, j].BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\takum\Desktop\ソフトウェア開発\pro_pic/aka4.png");
                                        break;
                                    case 4:
                                        massButtons[i, j].BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\takum\Desktop\ソフトウェア開発\pro_pic/aka5.png");
                                        break;
                                    case 5:
                                        massButtons[i, j].BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\takum\Desktop\ソフトウェア開発\pro_pic/aka6.png");
                                        break;
                                    case 6:
                                        massButtons[i, j].BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\takum\Desktop\ソフトウェア開発\pro_pic/aka7.png");
                                        break;
                                    case 7:
                                        massButtons[i, j].BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\takum\Desktop\ソフトウェア開発\pro_pic/aka8.png");
                                        break;
                                }




                            }
                        }
                    }
                }
            }

        }

        //ここで味方の動きが確定
        private void next_button_Click(object sender, EventArgs e)
        {
            Inform_Dicided(0);

            for (int i = 0; i < Data_Base.age; i++)
            {
                IUC[i].GB_dir.Text = "agent_ID：" + Data_Base.agent_ID[i + Data_Base.age];

            }
            
            next_button.Enabled = false;
            sending_button.Enabled = true;
            Check_Relese();
            UC_Button_Blind(1);
            //AT.Aria_Argo(2);
            TP.Tile_Point(1);
            Cheak_Ans(1);
         //  Thread.Sleep(1000);
          //  sending_button_Click(sender, e);
        }
        //チェック場所で動き確定Data_Baseのdx,dyに
        private void Inform_Dicided(int com)
        {
            for (int i = 0; i < Data_Base.age; i++)
            {
                ///どの方向にチェックがあるか///
                if (IUC[i].UL.Checked == true)
                {
                    Data_Base.age_dx[i + Data_Base.age * com] = -1;
                    Data_Base.age_dy[i + Data_Base.age * com] = -1;
                }
                else if (IUC[i].Upper.Checked == true)
                {
                    Data_Base.age_dx[i + Data_Base.age * com] = 0;
                    Data_Base.age_dy[i + Data_Base.age * com] = -1;
                }
                else if (IUC[i].UR.Checked == true)
                {
                    Data_Base.age_dx[i + Data_Base.age * com] = 1;
                    Data_Base.age_dy[i + Data_Base.age * com] = -1;
                }
                else if (IUC[i].Left.Checked == true)
                {
                    Data_Base.age_dx[i + Data_Base.age * com] = -1;
                    Data_Base.age_dy[i + Data_Base.age * com] = 0;
                }
                else if (IUC[i].Center.Checked == true)
                {
                    Data_Base.age_dx[i + Data_Base.age * com] = 0;
                    Data_Base.age_dy[i + Data_Base.age * com] = 0;
                }
                else if (IUC[i].Right.Checked == true)
                {
                    Data_Base.age_dx[i + Data_Base.age * com] = 1;
                    Data_Base.age_dy[i + Data_Base.age * com] = 0;
                }
                else if (IUC[i].BL.Checked == true)
                {
                    Data_Base.age_dx[i + Data_Base.age * com] = -1;
                    Data_Base.age_dy[i + Data_Base.age * com] = 1;
                }
                else if (IUC[i].Buttom.Checked == true)
                {
                    Data_Base.age_dx[i + Data_Base.age * com] = 0;
                    Data_Base.age_dy[i + Data_Base.age * com] = 1;
                }
                else if (IUC[i].BR.Checked == true)
                {
                    Data_Base.age_dx[i + Data_Base.age * com] = 1;
                    Data_Base.age_dy[i + Data_Base.age * com] = 1;
                }
                else { }//プログラムのバグの場合適当に指定描くかどうか

                if (IUC[i].RB_move.Checked == true)
                {
                    Data_Base.send_type[i + Data_Base.age * com] = "move";
                }
                else if (IUC[i].RB_remove.Checked == true)
                {
                    Data_Base.send_type[i + Data_Base.age * com] = "remove";
                }
                if (IUC[i].RB_stay.Checked == true)
                {
                    Data_Base.send_type[i + Data_Base.age * com] = "stay";
                }

            }

        }
        //1ターン確定//
        private void sending_button_Click(object sender, EventArgs e)
        {
            Inform_Dicided(1);
            Judge_n_Moving();
            Data_Reflect();
            Tiled_Colors();
            sending_button.Enabled = false;
            next_button.Enabled = true;
            for (int i = 0; i < Data_Base.age; i++)
            {
                IUC[i].GB_dir.Text = "agent_ID：" + Data_Base.agent_ID[i];
            }
            Check_Relese();
            UC_Button_Blind(0);
            Choosing_Algorithm();
            Cheak_Ans(0);
            Point_Calculation();
            Point_Visual();
            if (Data_Base.current_turn == Data_Base.game_turn)
            { next_button.Enabled = false; }
            else { Data_Base.current_turn++; }

            remain_turn_label.Text = "(現在のターン)" + Data_Base.current_turn + "/" + Data_Base.game_turn + "(総ターン)";
         //  Thread.Sleep(1000);
          // if(Data_Base.current_turn<=Data_Base.game_turn)
          //  { next_button_Click(sender, e); }
        }

        //全エージェントが動けるかどうか動けない場合Data_Reflectで行動不可になる//本番はサーバがする仕事apply値を出力
        private void Judge_n_Moving()
        {
            for (int i = 0; i < Data_Base.age * 2; i++)
            { Data_Base.apply[i] = 1; }
            for (int i = 0; i < Data_Base.age * 2; i++)//自分の今いる位置を取り除けない
            {
                if (Data_Base.send_type[i] == "remove" && Data_Base.age_dx[i] == 0 && Data_Base.age_dy[i] == 0)
                { Data_Base.apply[i] = 0; }
            }
            for (int i = 0; i < Data_Base.age * 2 - 1; i++)//消去先、移動先被る(2エージェントはだめ)
            {
                for (int j = i + 1; j < Data_Base.age * 2; j++)
                {
                    if (Data_Base.age_x[i] + Data_Base.age_dx[i] == Data_Base.age_x[j] + Data_Base.age_dx[j] &&
                        Data_Base.age_y[i] + Data_Base.age_dy[i] == Data_Base.age_y[j] + Data_Base.age_dy[j])//指定先かぶる
                    {
                        if (Data_Base.send_type[i] == Data_Base.send_type[j])//同じ場所移動or削除
                        {
                            Data_Base.apply[i] = 0;
                            Data_Base.apply[j] = 0;
                        }

                    }
                    if(Data_Base.send_type[i]=="remove")//iは動かない
                    {
                        if (Data_Base.age_x[i]  == Data_Base.age_x[j] + Data_Base.age_dx[j] &&
                        Data_Base.age_y[i] == Data_Base.age_y[j] + Data_Base.age_dy[j])
                        {
                            Data_Base.apply[j] = 0;
                        }
                    }
                    if (Data_Base.send_type[j] == "remove")//iは動かない
                    {
                        if (Data_Base.age_x[i] + Data_Base.age_dx[i] == Data_Base.age_x[j]  &&
                        Data_Base.age_y[i] + Data_Base.age_dy[i] == Data_Base.age_y[j] )
                        {
                            Data_Base.apply[i] = 0;
                        }
                    }
                }
            
            }
            //相手マスに移動不可
            for (int i = 0; i < Data_Base.age; i++)
            {
                
                if (Data_Base.tiled[Data_Base.age_y[i] + Data_Base.age_dy[i] - 1,Data_Base.age_x[i] + Data_Base.age_dx[i]-1] == Data_Base.team_ID[1] && Data_Base.send_type[i] == "move")
                {
                    Data_Base.apply[i] = -1;
                }
                
            }
            for (int i = Data_Base.age; i < Data_Base.age*2; i++)
            {
                if (Data_Base.tiled[Data_Base.age_y[i] + Data_Base.age_dy[i] - 1,Data_Base.age_x[i] + Data_Base.age_dx[i]-1] == Data_Base.team_ID[0] && Data_Base.send_type[i] == "move")
                {
                    Data_Base.apply[i] = -1;
                }
            }
            remain_turn_label.Text ="1"+ Data_Base.apply[3] +":2"+ Data_Base.apply[4]+"23" + Data_Base.apply[5];
        }

        //typeとdx,dyとJudge_n_Movingのapplyにより決定//
        private void Data_Reflect()
        {
            for (int i = 0; i < Data_Base.age * 2; i++)
            {
                if (Data_Base.apply[i] == 1)
                {
                    if (Data_Base.send_type[i] == "remove")
                    {

                        Data_Base.tiled[Data_Base.age_y[i] - 1 + Data_Base.age_dy[i], Data_Base.age_x[i] - 1 + Data_Base.age_dx[i]] = 0;
                    }
                }
            }
            for (int i = 0; i < Data_Base.age * 2; i++)
            {
                if (Data_Base.apply[i] == 1)
                {
                    if (Data_Base.send_type[i] == "move")
                    {
                        Data_Base.age_x[i] += Data_Base.age_dx[i];
                        Data_Base.age_y[i] += Data_Base.age_dy[i];

                        if (i < Data_Base.age)
                        {
                            Data_Base.tiled[Data_Base.age_y[i] - 1, Data_Base.age_x[i] - 1] = Data_Base.team_ID[0];
                        }
                        else
                        {
                            Data_Base.tiled[Data_Base.age_y[i] - 1, Data_Base.age_x[i] - 1] = Data_Base.team_ID[1];
                        }
                    }
                }
            }
            for (int i = 0; i < Data_Base.height; i++)
            {
                for (int j = 0; j < Data_Base.width; j++)
                {
                    Data_Base.position[i, j] = 0;
                }
            }
            for (int i = 0; i < Data_Base.age * 2; i++)
            {
                Data_Base.position[Data_Base.age_y[i] - 1, Data_Base.age_x[i] - 1] = Data_Base.agent_ID[i];
                if(i<Data_Base.age)
                { Data_Base.tiled[Data_Base.age_y[i] - 1, Data_Base.age_x[i] - 1] = Data_Base.team_ID[0]; }
                else
                { Data_Base.tiled[Data_Base.age_y[i] - 1, Data_Base.age_x[i] - 1] = Data_Base.team_ID[1]; }
               
            }

        }

        //IUCのチェックをすべて外す//
        private void Check_Relese()
        {
            for (int i = 0; i < Data_Base.age; i++)
            {
                IUC[i].Upper.Checked = false;
                IUC[i].UR.Checked = false;
                IUC[i].UL.Checked = false;
                IUC[i].Right.Checked = false;
                IUC[i].Center.Checked = false;
                IUC[i].Left.Checked = false;
                IUC[i].BR.Checked = false;
                IUC[i].Buttom.Checked = false;
                IUC[i].BL.Checked = false;
                IUC[i].RB_move.Checked = true;
            }
        }

        //点数表示//
        private void Point_Visual()
        {
            blue_points.Text = "合計:" + (Data_Base.tile_point[0] + Data_Base.area_point[0]) + "タイル:" + Data_Base.tile_point[0] + "領域:" + Data_Base.area_point[0];
            red_points.Text = "合計:" + (Data_Base.tile_point[1] + Data_Base.area_point[1]) + "タイル:" + Data_Base.tile_point[1] + "領域:" + Data_Base.area_point[1];
        }
        //点数計算
        private void Point_Calculation()
        {
            int[] tile = new int[2];
            int[] area = new int[2];
            int block=0;
            int[,] test = new int[Data_Base.height, Data_Base.width];
            int cnt;

            for (int com = 0; com < 2; com++)
            {
                //tile計算//
                for (int i = 0; i < Data_Base.height; i++)
                {
                    for (int j = 0; j < Data_Base.width; j++)
                    {
                        if (Data_Base.tiled[i, j] == Data_Base.team_ID[com])
                        {
                            tile[com] += Data_Base.points[i, j];
                        }
                        
                    }
                }
                Data_Base.tile_point[com] = tile[com];
               
                //領域計算
                for (int i = 0; i < Data_Base.height; i++)
                {
                    for (int j = 0; j < Data_Base.width; j++)
                    {
                        test[i, j] = Data_Base.tiled[i, j];
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

                    if (test[0, i] != Data_Base.team_ID[com])
                        test[0, i] = block;
                    if (test[Data_Base.height - 1, i] != Data_Base.team_ID[com])
                        test[Data_Base.height - 1, i] = block;

                }
                for (int i = 0; i < Data_Base.height; i++)
                {
                    if (test[i, 0] != Data_Base.team_ID[com])
                        test[i, 0] = block;
                    if (test[i, Data_Base.width - 1] != Data_Base.team_ID[com])
                        test[i, Data_Base.width - 1] = block;
                }
                cnt = 1;

                while (0 != cnt)
                {
                    cnt = 0;
                    for (int i = 0; i < Data_Base.height; i++)
                    {
                        for (int j = 0; j < Data_Base.width; j++)
                        {
                            if (test[i, j] == block)
                            {
                                for (int e_y1 = -1; e_y1 <= 1; e_y1++)//1手目
                                {
                                    for (int e_x1 = -1; e_x1 <= 1; e_x1++)
                                    {
                                        if (e_x1 * e_y1 == 0)//十字方向
                                        {
                                            if (0 <= i + e_y1 && i + e_y1 < Data_Base.height && 0 <= j + e_x1 && j + e_x1 < Data_Base.width)//境界外を見ない
                                            {
                                                if (Data_Base.tiled[i + e_y1, j + e_x1] != Data_Base.team_ID[com] && test[i + e_y1, j + e_x1] != block)
                                                {
                                                    test[i + e_y1, j + e_x1] = block;
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
                        if (test[i, j] != block && test[i, j] != Data_Base.team_ID[com])
                        {
                            if (Data_Base.points[i, j] < 0)
                            {
                                area[com] -= Data_Base.points[i, j];
                            }
                            else
                                area[com] += Data_Base.points[i, j];

                        }
                    }
                }
                Data_Base.area_point[com] = area[com];
            }
 }

        private void Choosing_Algorithm()
        {
            /*
            int cnt = 0;
            for(int i=0;i<2;i++)
            {
                if (Data_Base.memory_x[0, i] == 0 && Data_Base.memory_y[0, i] == 0)
                { cnt++;
                    
               }
            }
            //AT.Aria_Argo(2);
            AT.Aria_Argo(cnt);
            //remain_turn_label.Text = cnt.ToString();*/


            // TP.Tile_Point(0);
            TS.Tile_Point(0);


        }

    }
}
