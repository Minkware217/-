using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [Serializable]
        class Leaderboard {
            public string name; public int score;
            public Leaderboard(string name, int score) {
                this.name = name;
                this.score = score;
            }
        }
        Leaderboard[,] Llist = new Leaderboard[5, 5];

        [Serializable]
        class Pointd {
            public double x; public double y; public double f;
            public Pointd(double x, double y, double f) {

                this.x = x; this.y = y; this.f = f;
            }
            public Pointd(double x, double y)
            {

                this.x = x; this.y = y;
            }
        }
        [Serializable]
        class BlockF
        {
            public Pointd position;
            public int num;
            public BlockF(Pointd position, int num) {
                this.position = position;
                this.num = num;

            }

        }
        [Serializable]
        class NameCard
        { public NameCard(string Name, string Phone, int age)
            { this.Name = Name; this.Phone = Phone; this.Age = age; }
            public string Name;
            public string Phone;
            public int Age;

        }
        [Serializable]
        class ClearedStage
        {
            public ClearedStage(bool h)
            { this.h = h; }
            public bool h;


        }

        List<BlockF> Blocks;
        List<Leaderboard> boradR;
        List<ClearedStage> cleared;
        private void CFileCreate() {
            Stream cs = new FileStream("Csave.dat", FileMode.Create);
            BinaryFormatter cserializer = new BinaryFormatter();
            List<ClearedStage> cl = new List<ClearedStage>();
            cl.Add(new ClearedStage(true));
            cl.Add(new ClearedStage(false));
            cl.Add(new ClearedStage(false));
            cl.Add(new ClearedStage(false));
            cl.Add(new ClearedStage(false));
            cserializer.Serialize(cs, cl);
            cs.Close();

        }
        int stagemax = 1;
        private void CFileLoad()
        {
            Stream crs = new FileStream("Csave.dat", FileMode.Open);
            BinaryFormatter cdeserializer = new BinaryFormatter();
            List<ClearedStage> ff = new List<ClearedStage>();
            ff = (List<ClearedStage>)cdeserializer.Deserialize(crs);
            crs.Close();
            int k = 0;
            foreach (ClearedStage n in ff) {
                if (n.h == true) { k++; }
            }
            stagemax = k;
        }
        private void CFileSave() {
            Stream cs = new FileStream("Csave.dat", FileMode.Create);
            BinaryFormatter cserializer = new BinaryFormatter();
            List<ClearedStage> cl = new List<ClearedStage>();
            for (int i = 0; i <5; i++) {
                if (i < stagemax)
                {
                    cl.Add(new ClearedStage(true));
                }
                else
                { cl.Add(new ClearedStage(false)); }

            }
            cserializer.Serialize(cs, cl);
            cs.Close();
        }

        private void FileCreate() {
            Stream ws = new FileStream("save.dat", FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();
           
            List<BlockF> map1 = new List<BlockF>();
            //stage1
            map1.Add(new BlockF(new Pointd(10, 30), 1));
            map1.Add(new BlockF(new Pointd(10, 70), 1));
            map1.Add(new BlockF(new Pointd(10, 110), 1));
            map1.Add(new BlockF(new Pointd(110, 30), 1));
            map1.Add(new BlockF(new Pointd(110, 70), 1));
            map1.Add(new BlockF(new Pointd(110, 110), 1));
            map1.Add(new BlockF(new Pointd(210, 30), 1));
            map1.Add(new BlockF(new Pointd(210, 70), 1));
            map1.Add(new BlockF(new Pointd(210, 110), 1));
            map1.Add(new BlockF(new Pointd(310, 30), 1));
            map1.Add(new BlockF(new Pointd(310, 70), 1));
            map1.Add(new BlockF(new Pointd(310, 110), 1));
            map1.Add(new BlockF(new Pointd(410, 30), 1));
            map1.Add(new BlockF(new Pointd(410, 70), 1));
            map1.Add(new BlockF(new Pointd(410, 110), 1));

            map1.Add(new BlockF(new Pointd(-22, -22), 0));

            //stage2
            
            map1.Add(new BlockF(new Pointd(10, 110), 1));
            map1.Add(new BlockF(new Pointd(90, 90), 1));
            map1.Add(new BlockF(new Pointd(110, 70), 1));
            map1.Add(new BlockF(new Pointd(190, 50), 1));
            map1.Add(new BlockF(new Pointd(270, 30), 1));
            map1.Add(new BlockF(new Pointd(350, 10), 1));
            map1.Add(new BlockF(new Pointd(430, 30), 1));
            map1.Add(new BlockF(new Pointd(430, 50), 1));
            map1.Add(new BlockF(new Pointd(430, 70), 1));
            map1.Add(new BlockF(new Pointd(430, 30), 1));


            map1.Add(new BlockF(new Pointd(-22, -22), 0));

            //stage3
            map1.Add(new BlockF(new Pointd(237, 20), 1));
            map1.Add(new BlockF(new Pointd(237, 40), 1)) ;
            map1.Add(new BlockF(new Pointd(237, 60), 1));
            map1.Add(new BlockF(new Pointd(237, 80), 1));
            map1.Add(new BlockF(new Pointd(237, 100), 1));
            map1.Add(new BlockF(new Pointd(237, 120), 1));
            map1.Add(new BlockF(new Pointd(237, 140), 1));
            map1.Add(new BlockF(new Pointd(237, 160), 1));
            map1.Add(new BlockF(new Pointd(237, 180), 1));
            map1.Add(new BlockF(new Pointd(237, 200), 1));
            map1.Add(new BlockF(new Pointd(237, 220), 1));
            map1.Add(new BlockF(new Pointd(237, 240), 1));
          

            map1.Add(new BlockF(new Pointd(-22, -22), 0));

            //stage4
            //stage5




            Blocks = map1;
            foreach (BlockF n in Blocks)
            { label12.Text += "" + n.position.x + "," + n.position.y; }

            serializer.Serialize(ws, map1);
            
            ws.Close();
            //추가 수정 (맵맥스)  

            //

            Stream ms = new FileStream("Lsave.dat", FileMode.Create);
            BinaryFormatter zserializer = new BinaryFormatter();
            List<Leaderboard> borad = new List<Leaderboard>();
            for (int i = 0; i < 5; i++) {
                borad.Add(new Leaderboard("***", 0));
                borad.Add(new Leaderboard("***", 0));
                borad.Add(new Leaderboard("***", 0));
                borad.Add(new Leaderboard("***", 0));
                borad.Add(new Leaderboard("***", 0));
            }
            boradR = borad;
            Llist = new Leaderboard[5, 5];
            int xi = 0;
            int yi = 0;
            foreach (Leaderboard record in boradR)
            {
                Llist[xi, yi] = record;

                if (yi == 4)
                {
                    yi = 0;
                    xi++;
                }
                else { yi++; }
            }
            label12.Text += Llist[2, 2].name;
            zserializer.Serialize(ms, borad);
            ms.Close();
            
        }
        private void Fileload() {
            
            Stream rs = new FileStream("save.dat", FileMode.Open);
            Stream rs2 = new FileStream("Lsave.dat", FileMode.Open);
            BinaryFormatter deserializer = new BinaryFormatter();
            BinaryFormatter zdeserializer = new BinaryFormatter();

            List<Leaderboard> borad = new List<Leaderboard>();
                borad = (List<Leaderboard>)zdeserializer.Deserialize(rs2);
                boradR = borad;
                Llist = new Leaderboard[5, 5];
                int xi = 0;
                int yi = 0;
                foreach (Leaderboard record in boradR)
                {
                    Llist[xi, yi] = record;

                    if (yi == 4)
                    {
                        yi = 0;
                        xi++;
                    }
                    else { yi++; }
                }
            rs2.Close();
            // 추가 수정 (맵맥스)
           
            //
            label12.Text += Llist[2,2].name;
            
            List<BlockF> map2;


                map2 = (List<BlockF>)deserializer.Deserialize(rs);
           
            rs.Close();
                Blocks = map2;
            foreach (BlockF n in map2)
            {
                label12.Text += n.position.x+"";
            }
              
              //  foreach (BlockF n in Blocks)
               // { label12.Text += "" + n.position.x + "," + n.position.y; }


            
           // label12.Text = "비었음";



        }
        private void Filesave()
        {
            Stream ws = new FileStream("save.dat", FileMode.Create);
            Stream ms = new FileStream("Lsave.dat", FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(ws, Blocks);
            
            serializer.Serialize(ms, boradR);
            ws.Close();
            ms.Close();

        }
        private void recordrevise(string name, int stage, int score) {
            int k = 0;
            for (int i = 0; i < 5; i++) {
                if ((Llist[stage, i].score <= score)&&k==0)
                {

                     for (int j = 0; j < 4 - i; j++){
                     Llist[stage, 4-j].name = Llist[stage, 3-j].name;
                        Llist[stage, 4 - j].score = Llist[stage, 3 - j].score;

                    }
                    k = 1;
                    Llist[stage, i].name = name;
                    Llist[stage, i].score = score;
                   
                }
                
            }
        }
        bool gamemode = false;
        int Stagenum = 1;int endscore=15; int maxblockstack = 0;
        List<Label> blocksLabel = new List<Label>();
        private void gameitn() {

            //게임초기화(시작) 
            vic = false;
            shoted = 0;
            endscore = 0;
            label17.Visible = false;
            label17.Text = "press R to replay press E to endgame";
            gamemode = true;
            label16.Text = "0";
            label19.Visible = false;
            int StageSearch = 1;
            angleofball = 30;
            ballnum = 1;
            ballspeed = 5;
            label8.Width = 74;
            

            //panel3속블록 위치 제거(버그 방지)
            foreach (Label n in blocksLabel)
            {
                n.Location = new Point(-22, -22);
                n.Visible = false;

            }
            blocksLabel = new List<Label>();

            blocksLabel.Clear();

            //서브 공 제거
            foreach (sball n in serveball)
            {
                n.ball.Location = new Point(-22, -22);
                n.ball.Visible = false;
            }
            serveball = new List<sball>();
            serveball.Clear();
            //아이템 제거
            foreach (baritem n in itempile)
            {
                n.item.Location = new Point(-22, -22);
                n.item.Visible = false;

            }
            itempile = new List<baritem>();
            itempile.Clear();
            // 아이템 효과 제거
            timer4.Enabled = false;
            timer5.Enabled = false;
            label24.Visible = false;
            label25.Visible = false;
            timerforitem1 = 20;
             timerforitem2 = 20;
            
            
             
            //블록 생성
            try
            {
                foreach (BlockF b in Blocks)
                {

                    if (Stagenum == StageSearch)
                    {
                        if (b.num == 0)
                        {
                            break;
                        }
                        Label la = new Label();
                        la.Text = "";
                        la.Location = new Point((int)b.position.x, (int)b.position.y);
                        la.BackColor = Color.Red;
                        la.AutoSize = false;
                        la.Size = new Size(80, 20);
                        la.Visible = true;
                        la.ImageList = imageList1;
                        la.ImageKey = "block.png";
                        blocksLabel.Add(la);





                    }
                    if (b.num == 0)
                    {
                        StageSearch++;

                    }

                }
            }
            catch (NullReferenceException) { }
            foreach (Label b in blocksLabel)
            { 
                panel3.Controls.Add(b);
                b.BringToFront();
                label16.BringToFront();

            }
            blockstack = blocksLabel.Count();
            timer1.Dispose();
            timer2.Dispose();
            timer3.Dispose();

            ///생성 종료
            maxblockstack = blockstack;
            ///키 생성
            timer1.Start();
            timer1.Enabled = true;
            /// 공 움직임
            timer2.Start();
            timer2.Enabled = true;
            //타이머
            timer3.Start();
            timer3.Enabled = false;


        }


        private void button1_Click(object sender, EventArgs e)
        {
            gameitn();
            panel3.Visible = true;
            //panel3.Dock = DockStyle.Fill;
           
           

            }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("save.dat")) { 
            FileCreate();
        }
            else
            Fileload();

            if (!File.Exists("Csave.dat"))
            {
                CFileCreate();
            }
            else
            { CFileLoad(); }


            this.Width = 519;
            this.Height = 385;
            this.Location = new Point(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width / 2-this.Width/2, System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height / 2-this.Height/2);

          //  label16.BackColor = Color.Transparent;
          //  label16.Parent = this.panel3;



            
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel1.Visible = true;
            panel1.Dock =  DockStyle.Fill;
            timer1.Enabled = true;
            
        }




        double getAngle(double x1, double y1, double x2, double y2)
        {
            double Angle = Math.Atan((y2 - y1) / (x2 - x1)) * 180 / Math.PI;
            if (x1 <= x2)
            {
                Angle = -180 + Angle;
                // atan 취급 쥐의 0~180 도는 구할 수 있지만, y1 > y2 인 경우.. 즉
                // 3사분면 4사분면은 360 - (180~360) 를 해줘서 [0,180] 
                // 값으로 보정해준다.
            }

            return Angle;
        }
        //보드 기록
        int LStagenum;
        private void button5_Click(object sender, EventArgs e)
        {  
            LStagenum = Stagenum-1;
               recordrevise(textBox1.Text, LStagenum, endscore);
            int jf = LStagenum + 1;
            label13.Text = "stage:" +jf;
            label3.Text = "1위:"+Llist[LStagenum,0].name+" "+ Llist[LStagenum, 0].score;
            label4.Text = "2위:" + Llist[LStagenum, 1].name + " " + Llist[LStagenum, 1].score;
            label5.Text = "3위:" + Llist[LStagenum, 2].name + " " + Llist[LStagenum, 2].score;
            label6.Text = "4위:" + Llist[LStagenum, 3].name + " " + Llist[LStagenum, 3].score;
            label7.Text = "5위:" + Llist[LStagenum, 4].name + " " + Llist[LStagenum, 4].score;
            boradR = new List<Leaderboard>();
            boradR.Clear();
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++)
                    boradR.Add(Llist[i,j]);
            }
            
            Filesave();
        }
        //갓 저장한 기록 보기
        private void button12_Click(object sender, EventArgs e)
        {
            prepanelnum = 4;
            panel2.Visible = true;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (LStagenum != 0)
            {
                LStagenum--;
                int jf = LStagenum + 1;
                label13.Text = "stage:" + jf;
                label3.Text = "1위:" + Llist[LStagenum, 0].name + " " + Llist[LStagenum, 0].score;
                label4.Text = "2위:" + Llist[LStagenum, 1].name + " " + Llist[LStagenum, 1].score;
                label5.Text = "3위:" + Llist[LStagenum, 2].name + " " + Llist[LStagenum, 2].score;
                label6.Text = "4위:" + Llist[LStagenum, 3].name + " " + Llist[LStagenum, 3].score;
                label7.Text = "5위:" + Llist[LStagenum, 4].name + " " + Llist[LStagenum, 4].score;

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (LStagenum != 4)
            {
                LStagenum++;
                int jf = LStagenum + 1;
                label13.Text = "stage:" + jf;
                label3.Text = "1위:" + Llist[LStagenum, 0].name + " " + Llist[LStagenum, 0].score;
                label4.Text = "2위:" + Llist[LStagenum, 1].name + " " + Llist[LStagenum, 1].score;
                label5.Text = "3위:" + Llist[LStagenum, 2].name + " " + Llist[LStagenum, 2].score;
                label6.Text = "4위:" + Llist[LStagenum, 3].name + " " + Llist[LStagenum, 3].score;
                label7.Text = "5위:" + Llist[LStagenum, 4].name + " " + Llist[LStagenum, 4].score;

            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (prepanelnum == 1)
            {
                panel1.Visible = true;
            }
            if (prepanelnum == 4) {
                panel4.Visible = true;
            }
                 
        }
        int prepanelnum;
        private void button3_Click(object sender, EventArgs e)
        {
            prepanelnum = 1;
            LStagenum = 0;
            int jf = LStagenum + 1;
            label13.Text = "stage:" + jf;
            label3.Text = "1위:" + Llist[LStagenum, 0].name + " " + Llist[LStagenum, 0].score;
            label4.Text = "2위:" + Llist[LStagenum, 1].name + " " + Llist[LStagenum, 1].score;
            label5.Text = "3위:" + Llist[LStagenum, 2].name + " " + Llist[LStagenum, 2].score;
            label6.Text = "4위:" + Llist[LStagenum, 3].name + " " + Llist[LStagenum, 3].score;
            label7.Text = "5위:" + Llist[LStagenum, 4].name + " " + Llist[LStagenum, 4].score;
            panel2.Visible = true;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'a')
            {
                if (movement[0] == 0) { movement[0] = 1; }
                else if (movement[0] != 1) { movement[1] = 1; }
            }
            if (e.KeyChar == 'd')
            {
                if (movement[0] == 0) { movement[0] = 2; }
                else if (movement[0] != 2) { movement[1] = 2; }
            }
            if (e.KeyChar == 'f'&&gamemode == true) { timer3.Enabled = true; label14.Location = new Point(label14.Location.X, label14.Location.Y + 2); shoted = 1; }
            if ((e.KeyChar == 'r')&&(gamemode==false)&&(!vic)) { gameitn(); }
            if ((e.KeyChar == 'r') && (vic) && (gamemode == false)) {
                //승리
                if(Stagenum==stagemax) { stagemax++; CFileSave(); }
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                // 페이지 넘김
                label10.Text = "점수:" + endscore;
                panel4.Visible = true;
            }
            if ((e.KeyChar == 'e') && (gamemode == false) && (!vic)) {
                //게임 종료후(패배) 
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                //페이지 넘김
                label10.Text = "점수:" + endscore;
                panel4.Visible = true;

            }
            if ((e.KeyChar == 'n') && (gamemode == false) && (vic))
            {
                //게임 종료후(승리) 
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                //다음 게임
                //label10.Text = "점수:" + endscore;
                if (Stagenum != 5)
                {
                    if (Stagenum == stagemax) { stagemax++; CFileSave(); }
                    Stagenum++;
                    gameitn();
                   // panel3.Visible = true;
                }

            }

        }

        //바의 움직임
        int[] movement = { 0, 0 };
        int shoted = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
                switch (movement[i])
                {
                    case 0:
                        break;
                    case 1:
                      label8.Location=new Point(label8.Location.X-2, label8.Location.Y); 
                        break;
                    case 2:
                        label8.Location = new Point(label8.Location.X + 2, label8.Location.Y);
                        break;
                   }
            if (shoted == 0) { label14.Location = new Point(label8.Location.X+label8.Width / 2 + 5, +label8.Location.Y-20 ); }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                if (movement[1] == 1) { movement[1] = 0; }
                if (movement[0] == 1) { movement[0] = movement[1]; movement[1] = 0; }
            }
            if (e.KeyCode == Keys.D)
            {
                if (movement[1] == 2) { movement[1] = 0; }
                if (movement[0] == 2) { movement[0] = movement[1]; movement[1] = 0; }
            }
        }
        private double DegreeToRadian(double angle){ return Math.PI * angle / 180.0; }
        double angleofball=30; int ballnum = 1;
        int Cdeley = 0; bool vic; int blockstack; int ballspeed = 5;
        private void timer2_Tick(object sender, EventArgs e)
        {
            blockstack = blocksLabel.Count();

            //충격 딜레이
            if (Cdeley < 3) {
                Cdeley++;
            }


            double kk = DegreeToRadian(angleofball);
            double rx = Math.Cos(kk) * ballspeed;
            double ry = Math.Sin(kk) * ballspeed;
            if (!(label14.Location.X < 0 && label14.Location.Y < 0))
                label14.Location = new Point(label14.Location.X + (int)rx, label14.Location.Y - (int)ry );
            rx = label14.Location.X; 
             ry = label14.Location.Y;
            //foreach (Label n in blocksLabel)
            // 메인 볼 벽돌 충돌
            for (int i=0;i<blocksLabel.Count;i++)
            {
                double buffangle=angleofball;
                double nx = blocksLabel.ElementAt(i).Location.X; 
                double ny = blocksLabel.ElementAt(i).Location.Y;
                if ((nx < rx+label14.Width ) && (rx< nx+blocksLabel.ElementAt(i).Width))
                {
                    if ((ry +label14.Height< ny + 2) && (ry +label14.Height > ny - 2)|| (ry < ny + 2+blocksLabel.ElementAt(i).Height) && (ry > ny - 2+ blocksLabel.ElementAt(i).Height))
                    {    
                        if(Cdeley>=3)
                        itemcreate(blocksLabel.ElementAt(i));
                        buffangle = 360-buffangle;
                        //i = blocksLabel.Count + 1;
                        blocksLabel.ElementAt(i).Visible = false;
                        blocksLabel.ElementAt(i).Location = new Point(-22, -22);
                        // blocksLabel.RemoveAt(i);
                        Cdeley = 0;// blockstack--; 
                        //endscore += 100;
                    }


                }
                //if ((ry + label14.Height > ny)&&(ry<ny + blocksLabel.ElementAt(i).Height))
                if(((ry>ny)&&(ry<ny+blocksLabel.ElementAt(i).Height))|| ((ry+label14.Height > ny) && (ry+label14.Height < ny + blocksLabel.ElementAt(i).Height)))
                {
                    if (((rx< nx) && (rx+ label14.Width > nx - 3)) || (rx+label14.Width>blocksLabel.ElementAt(i).Width+ blocksLabel.ElementAt(i).Location.X) && (rx  < blocksLabel.ElementAt(i).Width + nx+3))
                    {
                        if (Cdeley >= 3)
                            itemcreate(blocksLabel.ElementAt(i));
                        buffangle = 180 - buffangle;
                        // i = blocksLabel.Count + 1;
                        blocksLabel.ElementAt(i).Visible = false;
                        blocksLabel.ElementAt(i).Location = new Point(-22, -22);
                        //blocksLabel.RemoveAt(i);
                        Cdeley = 0; //blockstack--; 
                        //endscore += 100;
                    }
                }

                if (buffangle < 0)
                {
                    buffangle += 360;
                }
                if (buffangle > 360)
                {
                    buffangle -= 360;
                }
                angleofball = buffangle;


            }
            // 서브 볼 움직임 및 판별
            //리스트 갱신 필요
            /*foreach (sball dn in serveball)
            {   
                
                serveballmove(dn);
                if (dn.ball.Location.Y + 5 > panel3.Height)
                {
                    //서브 공 탈락
                    dn.ball.Location = new Point(-22, -22);
                    dn.ball.Visible = false;
                   / for (int i = 0; i < serveball.Count; i++)
                    {
                        if (serveball.ElementAt(i).Equals(dn)){ serveball.RemoveAt(i); }
                    }/
                    
                    ballnum--;

                }
            }*/
            for (int i = 0; i < serveball.Count(); i++)
            {
                serveballmove(serveball.ElementAt(i));
                if (serveball.ElementAt(i).ball.Visible == false)
                {
                    serveball.RemoveAt(i);i--;
                }
                
            }

            //아이템 움직임 
            itemmove(itempile);


            ///
            //바 충돌 윗면
            //
            //label15.Text = "검사";
            if ((label8.Location.X<label14.Location.X+ label14.Width) && (label14.Location.X< label8.Location.X+label8.Width )&&(label14.Location.Y+label14.Width>label8.Location.Y-2) && (label14.Location.Y + label14.Width < label8.Location.Y + 2))
            {
                double buffangle = angleofball;
                buffangle = 360 - buffangle;
                if (buffangle < 0)
                {
                    buffangle += 360;
                }
                if (buffangle > 360)
                {
                    buffangle -= 360;
                }
                //label14.Location = new Point(label14.Location.X, label14.Location.Y - 4);
                angleofball = buffangle;
                
            }
            //벽면 충돌
            if (label14.Location.Y < 1) {
                double buffangle = angleofball;
                buffangle = 360 - buffangle;
                if (buffangle < 0)
                {
                    buffangle += 360;
                }
                if (buffangle > 360)
                {
                    buffangle -= 360;
                }
                label14.Location = new Point(label14.Location.X, label14.Location.Y + 2);
                angleofball = buffangle;

            }
            if ((label14.Location.X < 1) || (label14.Location.X + label14.Width > panel3.Width))
            {
                double buffangle = angleofball;
                buffangle = 180 - buffangle;

                if (buffangle < 0)
                {
                    buffangle += 360;
                }
                if (buffangle > 360)
                {
                    buffangle -= 360;
                }
                if (label14.Location.X < 1)
                { label14.Location = new Point(label14.Location.X + 2, label14.Location.Y); }
                else { label14.Location = new Point(label14.Location.X - 2, label14.Location.Y); 
            }
            angleofball = buffangle;
            }
            if (label14.Location.Y + 5 > panel3.Height) {
                //메인 공 탈락
                ballnum--;

            }
            if (ballnum == 0) {
                //겜오버
                label19.Text = "defeat";
                label19.Visible = true;
                gamemode = false;
                label17.Visible = true;
                timer2.Enabled = false;
            }
            //투명화된 블록 제거
            for (int i = 0; i < blocksLabel.Count(); i++)
            {
                if (blocksLabel.ElementAt(i).Visible == false)
                {
                    blocksLabel.RemoveAt(i); i--;
                }
            }
            //투명화된 서브볼 제거
            for (int i = 0; i < serveball.Count(); i++)
            {
                if (serveball.ElementAt(i).ball.Visible == false)
                {
                    serveball.RemoveAt(i); i--;
                }
            }
            //투명화된 아이템 제거
            for (int i = 0; i < itempile.Count(); i++)
            {
                if (itempile.ElementAt(i).item.Visible == false)
                {
                    itempile.RemoveAt(i); i--;
                }
            }


            //승리

            blockstack = blocksLabel.Count();
            if (blockstack == 0) { vic = true; }
            if (vic) {
                
                label19.Text = "victory";
                label17.Text = "press R to record n to next stage";
                label17.Visible = true;
                label19.Visible = true;
                gamemode = false;
                timer2.Enabled = false;

            }
            //ui
            label20.Text = Convert.ToString(blockstack);
            label12.Text = "X:"+label14.Location.X + "Y:" + label14.Location.Y;
            label15.Text = Convert.ToString(blocksLabel.Count());
            label22.Text= "아이템 수"+Convert.ToString(itempile.Count());
            label23.Text="서브공수 "+Convert.ToString(serveball.Count());
            label24.Location = new Point(label8.Location.X + label8.Width / 2+10, label8.Location.Y - 30);
            label25.Location = new Point(label8.Location.X + label8.Width / 2 + 10, label8.Location.Y - 50);
            label24.BackColor = Color.Transparent;
            label24.Parent = this.panel3;


        }
        //서브 볼()

        class sball {
            public double k;
            public Label ball;
           public sball() {
                k = 30;
                ball = new Label();
                ball.AutoSize = false;
                ball.Text = " ";
                //ball.Location = new Point(label8.Location.X + 20, label8.Location.Y + 3);

                ball.Width =15;
                ball.Height = 15;
                ball.BackColor = Color.Blue;
                ball.Visible = true;
                //panel3.Controls.Add(ball);
            }

        }

        
        List<sball> serveball = new List<sball>();
         void serveballmove(sball ball) {
            //충격 딜레이
          
            

            double kk = DegreeToRadian(ball.k);
            double rx = Math.Cos(kk) * ballspeed;
            double ry = Math.Sin(kk) * ballspeed;
            if (!(ball.ball.Location.X < 0 && ball.ball.Location.Y < 0))
            ball.ball.Location = new Point(ball.ball.Location.X + (int)rx, ball.ball.Location.Y - (int)ry);
            rx = ball.ball.Location.X;
            ry = ball.ball.Location.Y;
            //foreach (Label n in blocksLabel)
            // 서브 볼 벽돌 충돌
            for (int i = 0; i < blocksLabel.Count; i++)
            {
                double buffangle = ball.k;
                double nx = blocksLabel.ElementAt(i).Location.X;
                double ny = blocksLabel.ElementAt(i).Location.Y;
                if ((nx < rx + ball.ball.Width) && (rx < nx + blocksLabel.ElementAt(i).Width))
                {
                    if ((ry + ball.ball.Height < ny + 2) && (ry + ball.ball.Height > ny - 2) || (ry < ny + 2 + blocksLabel.ElementAt(i).Height) && (ry > ny - 2 + blocksLabel.ElementAt(i).Height))
                    {
                        itemcreate(blocksLabel.ElementAt(i));
                        buffangle = 360 - buffangle;
                        //i = blocksLabel.Count + 1;
                        blocksLabel.ElementAt(i).Visible = false;
                        blocksLabel.ElementAt(i).Location = new Point(-22, -22);
                        //endscore += 100;
                        // blocksLabel.RemoveAt(i);
                        //  blockstack--; 
                    }


                }

              //  if ((ry + ball.ball.Height > ny) && (ry < ny + blocksLabel.ElementAt(i).Height))
                    if (((ry > ny) && (ry < ny + blocksLabel.ElementAt(i).Height)) || ((ry + label14.Height > ny) && (ry + label14.Height < ny + blocksLabel.ElementAt(i).Height)))
                    {
                    //if ((rx + ball.ball.Width < nx + 2) && (rx + ball.ball.Width > nx - 2) || (nx + blocksLabel.ElementAt(i).Width - 2 < rx) && (nx + blocksLabel.ElementAt(i).Width + 2 > rx))
                    if (((rx < nx) && (rx + label14.Width > nx - 3)) || (rx + label14.Width > blocksLabel.ElementAt(i).Width + blocksLabel.ElementAt(i).Location.X) && (rx < blocksLabel.ElementAt(i).Width + nx + 3))
                    {
                        buffangle = 180 - buffangle;
                        itemcreate(blocksLabel.ElementAt(i));
                        // i = blocksLabel.Count + 1;
                        blocksLabel.ElementAt(i).Visible = false;
                        blocksLabel.ElementAt(i).Location = new Point(-22, -22);
                        //blocksLabel.RemoveAt(i);
                        // blockstack--; 
                        //endscore += 100;
                    }
                }

                if (buffangle < 0)
                {
                    buffangle += 360;
                }
                if (buffangle > 360)
                {
                    buffangle -= 360;
                }
                ball.k = buffangle;


            }
            // 서브 볼



            ///
            //바 충돌 윗면
            //
            //label15.Text = "검사";
            if ((label8.Location.X < ball.ball.Location.X + ball.ball.Width) && (ball.ball.Location.X < label8.Location.X + label8.Width) && (ball.ball.Location.Y + ball.ball.Width > label8.Location.Y - 2) && (ball.ball.Location.Y + ball.ball.Width < label8.Location.Y + 2))
            {
                double buffangle = ball.k;
                buffangle = 360 - buffangle;
                if (buffangle < 0)
                {
                    buffangle += 360;
                }
                if (buffangle > 360)
                {
                    buffangle -= 360;
                }
                
                ball.k = buffangle;

            }
            //벽면 충돌
            if (ball.ball.Location.Y < 1)
            {
                double buffangle = ball.k;
                buffangle = 360 - buffangle;
                if (buffangle < 0)
                {
                    buffangle += 360;
                }
                if (buffangle > 360)
                {
                    buffangle -= 360;
                }
                ball.ball.Location = new Point(ball.ball.Location.X, ball.ball.Location.Y + 2);
                ball.k = buffangle;

            }
            if ((ball.ball.Location.X < 1) || (ball.ball.Location.X + ball.ball.Width > panel3.Width))
            {
                double buffangle = ball.k;
                buffangle = 180 - buffangle;

                if (buffangle < 0)
                {
                    buffangle += 360;
                }
                if (buffangle > 360)
                {
                    buffangle -= 360;
                }
                if (ball.ball.Location.X < 1)
                { ball.ball.Location = new Point(ball.ball.Location.X + 2, ball.ball.Location.Y); }
                else
                {
                    ball.ball.Location = new Point(ball.ball.Location.X - 2, ball.ball.Location.Y);
                }
                ball.k = buffangle;
            }
            if (ball.ball.Location.Y + 5 > panel3.Height)
            {
                //서브 공 탈락
                ball.ball.Location = new Point(-22, -22);
                ball.ball.Visible = false;
                //ballnum--;

            }
            
            
        }

       










        //item
        class baritem {
           public Label item;
            public int itemnum;
           public baritem(int itemnum) {
                this.itemnum = itemnum;
                item = new Label();
                item.AutoSize = false;
                item.Location = new Point(300, 300);
                item.Width = 45;
                item.Height = 15;
               
                
                switch (itemnum) {
                    case 1:
                        item.BackColor = Color.Brown;
                        item.Text = "B";
                        break;
                    case 2:
                        item.BackColor = Color.Gold;
                        item.Text = "S";
                        break;
                    case 3:
                        item.BackColor = Color.HotPink;
                        item.Text = "D";
                        break;    
                }
                item.TextAlign = ContentAlignment.MiddleCenter;
                
                item.Visible = true;
            }
        }

        List<baritem> itempile = new List<baritem>();
        private void itemcreate(Label lap) {
            //1: 길어지는 바
            //2: 서브 공이 생성
            //3: 느려지는 공
            //Random t = new Random();
            // int q = t.Next(0, 30);
            int q = 0;
            if (q == 0)
            {
                Random r = new Random();
                int f = r.Next(1, 4);
                if (f != 0)
                { baritem ffd = new baritem(f);
                    ffd.item.Location = new Point(lap.Location.X + lap.Width/2 , lap.Location.Y + lap.Height);
                    itempile.Add(ffd);
                    
                    panel3.Controls.Add(itempile.Last().item);
                    itempile.Last().item.BringToFront();

                }
            }
        }
        //아이템 움직임
        int timerforitem1 = 20;
        int timerforitem2 = 20;
        void itemmove(List<baritem> it) {
            for (int i = 0; i < it.Count; i++)
            {     if(!(it.ElementAt(i).item.Location.X<0&&it.ElementAt(i).item.Location.Y<0))
                it.ElementAt(i).item.Location = new Point(it.ElementAt(i).item.Location.X, it.ElementAt(i).item.Location.Y + 2);
                //if ((it.ElementAt(i).item.Location.X < label8.Location.X + label8.Width) && (label8.Location.X < it.ElementAt(i).item.Location.X + it.ElementAt(i).item.Width) && (it.ElementAt(i).item.Height + it.ElementAt(i).item.Location.Y < label8.Location.Y) && (it.ElementAt(i).item.Height + it.ElementAt(i).item.Location.Y > label8.Location.Y + label8.Height))
                if ((label8.Location.X < it.ElementAt(i).item.Location.X + it.ElementAt(i).item.Width) && (it.ElementAt(i).item.Location.X < label8.Location.X + label8.Width) && (it.ElementAt(i).item.Location.Y + it.ElementAt(i).item.Width > label8.Location.Y - 2) && (it.ElementAt(i).item.Location.Y + it.ElementAt(i).item.Width < label8.Location.Y + 2))
                {
                    //효과
                    if (it.ElementAt(i).itemnum == 1) { label8.Width = 110; timerforitem1 = 0;label24.Visible = true;label24.Text = "long bar!"; timer4.Enabled = true; }
                    if (it.ElementAt(i).itemnum == 2) { ballnum++; sball ww = new sball(); ww.ball.Location = new Point(label8.Location.X + 20, label8.Location.Y - 16); panel3.Controls.Add(ww.ball); serveball.Add(ww); serveball.Last().ball.BringToFront(); }
                    if (it.ElementAt(i).itemnum == 3) { ballspeed = 3; timerforitem2 = 0; label25.Visible = true;label25.Text = "slooow"; timer5.Enabled = true; } 





                                it.ElementAt(i).item.Location=new Point(-22, -22);
                    it.ElementAt(i).item.Visible = false;

                }
                if (it.ElementAt(i).item.Location.Y > panel3.Height)
                {
                    it.ElementAt(i).item.Location = new Point(-22, -22);
                    it.ElementAt(i).item.Visible = false;
                   
                }
            }
           /* for (int i = 0; i < it.Count; i++)
            {   if(it.ElementAt(i).item.Visible==false)
                it.RemoveAt(i); i--;
            }*/



        } 


        private void timer3_Tick(object sender, EventArgs e)
        {
            if (gamemode==false) {
                /* foreach (Label n in blocksLabel)
                 {
                     if (n.Visible == false)
                     {
                         endscore += 100;
                     }

                 }*/
                endscore=(maxblockstack - blocksLabel.Count())*100;
                endscore -= Convert.ToInt32(label16.Text);    
                timer3.Enabled = false;

            }

            int sec=Convert.ToInt32(label16.Text);
            sec++;
            label16.Text = Convert.ToString(sec);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Stagenum = (int)numericUpDown1.Value;
            gameitn();
            panel3.Visible = true;

        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            numericUpDown1.Maximum = stagemax;
        }

        private void button11_Click(object sender, EventArgs e)
        { 
            Stagenum = 1;
            panel1.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {if (Stagenum != 5)
            {
                Stagenum++;
                gameitn();
                panel3.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Stagenum = 1;
            panel1.Visible = true;
        }

        private void panel1_VisibleChanged(object sender, EventArgs e)
        {if (panel1.Visible == true)
            {
               // panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;

                panel1.Dock = DockStyle.Fill;
            }

        }

        private void panel2_VisibleChanged(object sender, EventArgs e)
        {
            if (panel2.Visible == true)
            {
                 panel1.Visible = false;
                //panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;

                panel2.Dock = DockStyle.Fill;
            }
        }

        private void panel5_VisibleChanged(object sender, EventArgs e)
        {
            if (panel5.Visible == true)
            {
                 panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                //panel5.Visible = false;

                panel5.Dock = DockStyle.Fill;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_VisibleChanged(object sender, EventArgs e)
        {
            if (panel4.Visible == true)
            {
                textBox1.Enabled = true;
                 panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                //panel4.Visible = false;
                panel5.Visible = false;

                panel4.Dock = DockStyle.Fill;
            }
            if (panel4.Visible == false) { textBox1.Enabled = false; }

        }

        private void panel3_VisibleChanged(object sender, EventArgs e)
        {
            if (panel3.Visible == true)
            {
                panel1.Visible = false;
                panel2.Visible = false;
                //panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;

                panel3.Dock = DockStyle.Fill;
            }

        }
        //길어지는 바
        private void timer4_Tick(object sender, EventArgs e)
        {
            timerforitem1++;
            if (timerforitem1 == 20)
            { label8.Width = 74; label24.Visible = false; timer4.Enabled = false; }

            if (timerforitem1 == 19)
                label24.Text = "disable!";

            if ((timerforitem1 >= 14) && (timerforitem1 <= 18))
            {
                label24.Visible = true;
                label24.Text = Convert.ToString(20 - timerforitem1);
            }
            if (timerforitem1 == 2) { label24.Visible = false; }
        }
        //느려지는 공
        private void timer5_Tick(object sender, EventArgs e)
        {

            timerforitem2++;
            if (timerforitem2 == 20)
            { ballspeed = 5; label25.Visible = false; timer5.Enabled = false; }

            if (timerforitem2 == 19)
                label25.Text = "disable!";

            if ((timerforitem2 >= 14) && (timerforitem2 <= 18))
            {
                label25.Visible = true;
                label25.Text = Convert.ToString(20 - timerforitem2);
            }
            if (timerforitem2 == 2) { label25.Visible = false; }
        }
    }
}
