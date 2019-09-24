using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shallow_Learning_Frame
{
    class Data_Base
    {
        //①初期設定で一度のみ書き換えられるデータ//
        public static int height;                   //フィールド高さ
        public static int width;                    //フィールド幅
        public static int game_turn;                //ゲームのターン数入力場所確保する。
        public static int age;                      //1チームあたりのエージェント数、2チームのエージェント数はage*2で使用する
        public static int[] team_ID = new int[2];   //[0]:味方、[1]:敵
        public static int[] agent_ID=new int[16];   //agentのIDを格納[0~age-1]が味方、[age~age*2-1]が敵のID

        //②Data_Reseaveで毎ターン受け取るデータ//
        public static int[,] tiled = new int[20, 20];           //タイルの色
        public static int[,] points=new int[20,20];             //各タイルのポイント
        public static int[,] position = new int[20, 20];        //agent_ID[i],X[i],Y[i]の情報から一つの配列にまとめる。
        public static int[] apply=new int [16];                 //相手、自分の行動が反映されたかどうか//（行動の適応状況，-1：無効，0：競合，1：有効） 
        public static string[] rseave_type = new string [16];   //前のターンの各エージェント行動タイプ申し込み
        public static int current_turn;                          //現在のターンjsonではturnだが,全体のターンと区別するため
        public static int[] age_x = new int[16];                //各エージェントのx座標
        public static int[] age_y = new int[16];                //各エージェントのx座標

        //③評価関数で変更、Data_Sendingで送信するデータ//要素数本番は8、相手入力含め16
        public static string[] send_type = new string [16];   //2~6,自分チームのエージェント行動タイプ
        public static int[] age_dx = new int[16];             //エージェントのx変位
        public static int[] age_dy = new int[16];             //エージェントのy変位 

        //④フィールド分析で使用する変数//
        public static int[,] field_max = new int[20, 20];

        public static int[] tile_point = new int[2];//タイルポイント格納[0]:味方[1]:敵
        public static int[] area_point = new int[2];//領域ポイント格納[0]:味方[1]:敵

        //サーバとの通信よう
        public static string port_number;
        public static string host_name;

        //領域優先のメモリ
        public static int[,] memory_x = new int[16, 2];//[ege番号,2手目、3手目]を格納する
        public static int[,] memory_y = new int[16, 2];//[ege番号,2手目、3手目]2手目、3手目を格納する

        public static int[,] tiled_copy = new int[20, 20];

        public static string open_field="E1";//F2エラー
    }
}
