using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows;

namespace Hnefatafl_Heave_Ladz
{
    //0 - empty
    //1 - forbidden
    //2 - king 
    //3 - loyalist
    //4 - rebel


    public partial class Form1 : Form
    {
        bool traitor = true, chosen = false;
        bool king_moved = false; //zmienna zalezna od ruchu krola
        int lastx, lasty;
        int width = 1000, height = 1000;

        public Form1()
        {
            InitializeComponent();
        }
        Byte[,] Pola = new byte[11, 11];
        Button[,] arrButton = new Button[11, 11];
        bool start = true;


        private void Form1_Activated(object sender, EventArgs e)
        {
            if(start == true)
            { 

            for (int y = 0; y < 11; y++)
            {
                for (int x = 0; x < 11; x++)
                {


                    switch (x)
                    {
                        case 0:
                            if (y > 2 && y < 8) { Pola[x, y] = 4; } else { if (y == 0 || y == 10) { Pola[x, y] = 1; } }
                            break;



                        case 1:
                            if (x == 5) { Pola[x, y] = 4; } else { Pola[x, y] = 0; }
                            break;

                        case 9:
                            if (x == 5) { Pola[x, y] = 4; } else { Pola[x, y] = 0; }
                            break;

                        case 5:
                            if (y == 1 || y == 9) { Pola[x, y] = 4; } else { if (y == 5) { Pola[x, y] = 2; } else { if (y > 2 && y < 5) { Pola[x, y] = 3; } else { if (y > 5 && y < 8) { Pola[x, y] = 3; } } } }
                            break;
                        case 10:
                            if (y > 2 && y < 8) { Pola[x, y] = 4; } else { if (y == 0 || y == 10) { Pola[x, y] = 1; } }
                            break;



                    }
                    switch (y)
                    {

                        case 0:
                            if (x > 2 && x < 8) { Pola[x, y] = 4; } else { }
                            break;

                        case 1:
                            if (x == 5) { Pola[x, y] = 4; } else { Pola[x, y] = 0; }
                            break;

                        case 4:

                            if (x == 4 || x == 6) { Pola[x, y] = 3; }
                            break;


                        case 5:
                            if (x == 1 || x == 9) { Pola[x, y] = 4; } else { if (x > 2 && x < 5) { Pola[x, y] = 3; } else { if (x > 5 && x < 8) { Pola[x, y] = 3; } } }
                            break;

                        case 6:
                            if (x == 4 || x == 6) { Pola[x, y] = 3; }
                            break;

                        case 9:
                            if (x == 5) { Pola[x, y] = 4; } else { Pola[x, y] = 0; }
                            break;

                        case 10:
                            if (x > 2 && x < 8) { Pola[x, y] = 4; } else { }
                            break;

                    }


                }


            }
                start = false;
        }

        }


        public bool allow;

        public void winnin(bool escape) {
            if (escape == true) { MessageBox.Show("Król uciekł");  }
            else { MessageBox.Show("Schwytano Króla"); }


            Application.Exit();
        }
        public void Capturez(int x, int y)
        {

            //Buntownicy

                if (king_moved == false && traitor == true ) { if (Pola[5, 6] == 4 && Pola[5, 4] == 4 && Pola[4, 5] == 4 && Pola[6, 5] == 4) { winnin(false); } }

        


            if (Pola[x, y] == 4&& traitor == true && x < 9)
                {

                    if (Pola[x + 1, y] == 3)
                    {

                        if (Pola[x + 2, y] == 4 || Pola[x + 2, y] == 1)
                        {
                            Pola[x + 1, y] = 0;
                        }

                    }



                }
                if (Pola[x, y] == 4&& traitor == true&&x>1)
                {

                    if (Pola[x - 1, y] == 3)
                    {

                        if (Pola[x - 2, y] == 4 || Pola[x - 2, y] == 1)
                        {
                            Pola[x - 1, y] = 0;
                        }

                    }



                }




                if (Pola[x, y] == 4&& traitor == true && y < 9)
                {

                    if (Pola[x, y + 1] == 3)
                    {

                        if (Pola[x, y + 2] == 4 || Pola[x, y + 2] == 1)
                        {
                            Pola[x, y + 1] = 0;
                        }

                    }



                }
                if (Pola[x, y] == 4&& traitor == true && y>1)
                {

                    if (Pola[x, y - 1] == 3)
                    {

                        if (Pola[x, y - 2] == 4 || Pola[x, y - 2] == 1)
                        {
                            Pola[x, y - 1] = 0;
                        }

                    }

                }


                //Król


                if (Pola[4, 5] != 2 && Pola[6, 5] != 2 && Pola[5, 4] != 2 && Pola[5, 6] != 2&&Pola[5,5]!=2&& traitor == true)
                {
                if (Pola[x, y] == 4&&x<9)
                {

                    if (Pola[x + 1, y] == 2)
                    {

                        if (Pola[x + 2, y] == 4 || Pola[x + 2, y] == 1)
                        {
                            winnin(false);
                        }

                    }



                }
                if (Pola[x, y] == 4 && x >1)
                {

                    if (Pola[x - 1, y] == 2)
                    {

                        if (Pola[x - 2, y] == 4 || Pola[x - 2, y] == 1)
                        {
                            winnin(false);
                        }

                    }



                }

                if (Pola[x, y] == 4 && y < 9)
                {

                    if (Pola[x , y + 1] == 2)
                    {

                        if (Pola[x , y + 2] == 4 || Pola[x, y + 2] == 1)
                        {
                            winnin(false);
                        }

                    }



                }
                if (Pola[x, y] == 4 && y >1)
                {

                    if (Pola[x, y - 1] == 2)
                    {

                        if (Pola[x, y - 2] == 4 || Pola[x, y - 2] == 1)
                        {
                            winnin(false);
                        }

                    }



                }

            }
            //Lojaliści


  
                if (Pola[x, y] == 3|| Pola[x, y] == 2)
                {
                    if ( x < 9&& traitor == false)
                    {
                        if (Pola[x + 1, y] == 4)
                        {

                            if (Pola[x + 2, y] == 3 || Pola[x + 2, y] == 1 )
                            {
                                Pola[x + 1, y] = 0;
                            }
                            else { if (Pola[x + 2, y] == 2 && king_moved == true) { Pola[x +1, y] = 0; } }

                        }

                    }

                

            }

         
            
                if (Pola[x, y] == 3 || Pola[x, y] == 2)
                {
                    if (traitor == false&&x > 1)
                    {
                        if (Pola[x - 1, y] == 4)
                        {

                            if (Pola[x - 2, y] == 3 || Pola[x - 2, y] == 1)
                            {
                                Pola[x - 1, y] = 0;
                            }
                            else { if (Pola[x - 2, y] == 2&&king_moved==true) { Pola[x - 1, y] = 0; } }



                        

                    }

                }
            }


           

                if (Pola[x, y] == 3 || Pola[x, y] == 2)
                {
                    if (y < 9&&traitor == false)
                    {
                        if (Pola[x, y + 1] == 4)
                        {

                            if (Pola[x, y + 2] == 3 || Pola[x, y + 2] == 1)
                            {
                                Pola[x, y + 1] = 0;
                            }
                            else { if (Pola[x, y+2] == 2 && king_moved == true) { Pola[x, y+1] = 0; } }

                        }
                    }
                }      


               


            

                if (Pola[x, y] == 3 || Pola[x, y] == 2)
                {
                    if ( y > 1&& traitor == false)
                    {
                        if (Pola[x, y - 1] == 4)
                        {

                            if (Pola[x, y - 2] == 3 || Pola[x, y - 2] == 1)
                            {
                                Pola[x, y - 1] = 0;
                            }
                            else { if (Pola[x , y-2] == 2 && king_moved == true) { Pola[x , y-1] = 0; } }

                        }

                    }
                
                

            }
           





            
                    //obok pola tronu
                    if (traitor == true && Pola[5, 6] == 2) { if (Pola[5, 7] == 4 && Pola[6, 6] == 4 && Pola[4, 6] == 4) { winnin(false); } }
                    if (traitor == true && Pola[5, 4] == 2) { if (Pola[5,3] == 4 && Pola[6,4] == 4 && Pola[4,4] == 4) { winnin(false); } }
                    if (traitor == true && Pola[4, 5] == 2) { if (Pola[3,5] == 4 && Pola[ 4,6] == 4 && Pola[4, 4] == 4) { winnin(false); } }
                    if (traitor == true && Pola[6, 5] == 2) { if (Pola[5,7] == 4 && Pola[6, 6] == 4 && Pola[4,6] == 4) { winnin(false); } }

                    


            

        }


        void Traitorous() {

            if (traitor==true) { traitor = false; }
            else { traitor = true; }
           
        }



        public void Validate(int x,int y) {



            //prawo
            if (x > lastx&&y==lasty)
            {
                for (int x2 =x; x2 > lastx; x2--)
                {

                    if (Pola[x2, y] != 0 && x != 5 && y != 5) {  allow = false; break; } else { allow = true;  }

                }
                if (allow == true) { Pola[x,y] = Pola[lastx, lasty]; Pola[lastx, lasty] = 0;   if (king_moved == false && Pola[x, y] == 2) { king_moved = true; Pola[5, 5] = 1; }  }
                chosen = false;
            }
                       

            //lewo
            if (x < lastx && y == lasty)
            {
                for (int x2=x; x2 < lastx; x2++)
                {

                    if (Pola[x2,y] != 0 && x != 5 && y != 5) {  allow = false; break; } else { allow = true;  }

                }
                if (allow == true) { Pola[x,y] = Pola[lastx, lasty]; Pola[lastx, lasty] = 0;   if (king_moved == false && Pola[x, y] == 2) { king_moved = true; Pola[5, 5] = 1; }  }
                chosen = false;
            }
                    //dół



                    if (y > lasty && x == lastx)
            {
                for (int y2 = y; y2 > lasty; y2--)
                {

                    if (Pola[x, y2] != 0&&x!=5&&y!=5) { allow = false; break; } else { allow = true;  }

                }
                
                if (allow == true) { Pola[x,y] = Pola[lastx, lasty]; Pola[lastx, lasty] = 0;  if (king_moved == false && Pola[x, y] == 2) { king_moved = true; Pola[5, 5] = 1; }  }
                chosen = false; 
            }



            //góra

            if (y < lasty && x == lastx)
            {
                for (int y2 = y;y2 < lasty; y2++)
                {

                    if (Pola[x,y2] != 0 && x != 5 && y != 5) {  allow = false; break; } else { allow = true;  }

                }
                if (allow == true){ Pola[x,y] = Pola[lastx, lasty];Pola[lastx, lasty] = 0;  if (king_moved == false && Pola[x, y] == 2) { king_moved = true; Pola[5, 5] = 1; }  }
                chosen = false;
            }


        }
        public void Validate_king(int x, int y)
        {

            if (x > lastx && y == lasty)
            {
                for (int x2 = x - 1; x2 > lastx; x2--)
                {

                    if (Pola[x2, y] != 0) { allow = false; break; } else { allow = true; }

                }
                if (allow == true) { Pola[x, y] = Pola[lastx, lasty]; Pola[lastx, lasty] = 0; if (king_moved == false && Pola[x, y] == 2) { king_moved = true; Pola[5, 5] = 1; }winnin(true); }
                chosen = false;
            }

            //lewo
            if (x < lastx && y == lasty)
            {
                for (int x2 = x + 1; x2 < lastx; x2++)
                {

                    if (Pola[x2, y] != 0) { allow = false; break; } else { allow = true; }

                }
                if (allow == true) { Pola[x, y] = Pola[lastx, lasty]; Pola[lastx, lasty] = 0; if (king_moved == false && Pola[x, y] == 2) { king_moved = true; Pola[5, 5] = 1; } winnin(true); }
                chosen = false;
            }
            //dół



            if (y > lasty && x == lastx)
            {
                for (int y2 = y - 1; y2 > lasty; y2--)
                {

                    if (Pola[x, y2] != 0) { allow = false; break; } else { allow = true; }

                }

                if (allow == true) { Pola[x, y] = Pola[lastx, lasty]; Pola[lastx, lasty] = 0; if (king_moved == false && Pola[x, y] == 2) { king_moved = true; Pola[5, 5] = 1; } winnin(true); }
                chosen = false;
            }



            //góra

            if (y < lasty && x == lastx)
            {
                for (int y2 = y + 1; y2 < lasty; y2++)
                {

                    if (Pola[x, y2] != 0) { allow = false; break; } else { allow = true; }

                }
                if (allow == true)
                {
                    Pola[x, y] = Pola[lastx, lasty]; Pola[lastx, lasty] = 0; if (king_moved == false && Pola[x, y] == 2) { king_moved = true; Pola[5, 5] = 1; }
                    winnin(true);
                    chosen = false;
                }



            }
        }
        public void Movement(int x,int y) {



            if (chosen == true) {
                switch (Pola[x, y]) {

                    case 0:
                        Validate(x, y);
                        allow = false;
                        Capturez(x, y);
                        Traitorous();
                        Refresh();
                        break;

                    case 1:

                        if (Pola[lastx, lasty] == 2)
                        {
                            if (x != 5 && y != 5)

                            {
                                switch (x)
                                {

                                    case 0:
                                        if (y == 0) { Validate_king(x,y); }
                                        if (y == 10) { Validate_king(x, y); }
                                        break;
                                    case 10:
                                        if (y == 0) { Validate_king(x, y); }
                                        if (y == 10) { Validate_king(x, y); }
                                        break;


                                    default:
                                        chosen = false;
                                        break;

                                }


                        }
                        }
                        else { chosen = false; }
                            if (allow == true) { winnin(true); }
                        
                        break;

                    default:
                        chosen = false;
                        break;

                }
     
            }
            else {
                switch (traitor) {

                    case true:
                        if (Pola[x, y] == 4) { chosen = true; lastx = x; lasty = y; } 
                        break;

                    case false:
                        if (Pola[x, y] == 3 || Pola[x, y] == 2) { chosen = true; lastx = x; lasty = y;}
                        break;



                }

            }




        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void A11_Click(object sender, EventArgs e)
        {
            int x = 0, y = 10;
            Movement(x, y);

        }

        private void A1_Click(object sender, EventArgs e)
        {

            int x = 0, y = 0;
            Movement(x, y);

        }

        private void k11_Click(object sender, EventArgs e)
        {
            int x = 10, y = 10;
            Movement(x, y);

        }

        private void k1_Click(object sender, EventArgs e)
        {
            int x = 10, y = 0;
            Movement(x, y);

        }

        private void button63_Click(object sender, EventArgs e)
        {
            int x = 5, y = 5;
            Movement(x, y);
        }

        private void button14_Click(object sender, EventArgs e)
        {

            int x = 0, y = 1;
            Movement(x, y);


        }

        private void button21_Click(object sender, EventArgs e)
        {
            int x = 3, y = 3;
            Movement(x, y);

        }

        private void button101_Click(object sender, EventArgs e)
        {
            int x = 10, y = 8;
            Movement(x, y);

        }

        private void B1_Click(object sender, EventArgs e)
        {
            int x = 1, y = 0;
            Movement(x, y);
        }

        private void I11_Click(object sender, EventArgs e)
        {
            int x = 8, y = 10;
            Movement(x, y);

        }



        private void A4_Click(object sender, EventArgs e)
        {

            int x = 0, y = 3;
            Movement(x, y);


        }

        private void A5_Click(object sender, EventArgs e)
        {

            int x =0 , y = 4;
            Movement(x, y);


        }

        private void A6_Click(object sender, EventArgs e)
        {

            int x = 0, y = 5;
            Movement(x, y);

        }

        private void A7_Click(object sender, EventArgs e)
        {

            int x = 0 , y = 6;
            Movement(x, y);

        }

        private void A8_Click(object sender, EventArgs e)
        {

            int x = 0, y = 7;
            Movement(x, y);

        }

        private void A9_Click(object sender, EventArgs e)
        {

            int x = 0, y = 8;
            Movement(x, y);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void A4_DragLeave(object sender, EventArgs e)
        {
            int x = 0, y = 9;
            Movement(x, y);

        }

        private void A3_DragDrop(object sender, DragEventArgs e)
        {
            int x = 0, y = 9;
            Movement(x, y);

        }



        private void A4_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int x = 0, y = 2;
            Movement(x, y);
        }

        private void B2_Click(object sender, EventArgs e)
        {
            int x = 1, y = 1;
            Movement(x, y);
        }

        private void B3_Click(object sender, EventArgs e)
        {
            int x = 1, y = 2;
            Movement(x, y);
        }

        private void B4_Click(object sender, EventArgs e)
        {
            int x = 1, y = 3;
            Movement(x, y);
        }

        private void B5_Click(object sender, EventArgs e)
        {
            int x = 1, y =  4;
            Movement(x, y);
        }

        private void B6_Click(object sender, EventArgs e)
        {
            int x = 1, y = 5;
            Movement(x, y);
        }

        private void B7_Click(object sender, EventArgs e)
        {
            int x = 1, y = 6;
            Movement(x, y);
        }

        private void B8_Click(object sender, EventArgs e)
        {
            int x = 1, y = 7;
            Movement(x, y);
        }

        private void B9_Click(object sender, EventArgs e)
        {
            int x = 1, y = 8;
            Movement(x, y);
        }

        private void B10_Click(object sender, EventArgs e)
        {
            int x = 1, y = 9;
            Movement(x, y);
        }

        private void B11_Click(object sender, EventArgs e)
        {
            int x = 1, y = 10;
            Movement(x, y);
        }

        private void C1_Click(object sender, EventArgs e)
        {
            int x = 2, y = 0;
            Movement(x, y);
        }

        private void C2_Click(object sender, EventArgs e)
        {
            int x = 2, y = 1;
            Movement(x, y);

        }

        private void C3_Click(object sender, EventArgs e)
        {
            int x = 2, y = 2;
            Movement(x, y);

        }

        private void C4_Click(object sender, EventArgs e)
        {
            int x = 2, y = 3;
            Movement(x, y);

        }

        private void C5_Click(object sender, EventArgs e)
        {
            int x = 2, y = 4;
            Movement(x, y);

        }

        private void C6_Click(object sender, EventArgs e)
        {
            int x = 2, y = 5;
            Movement(x, y);

        }

        private void C7_Click(object sender, EventArgs e)
        {
            int x = 2, y = 6;
            Movement(x, y);

        }

        private void C8_Click(object sender, EventArgs e)
        {
            int x = 2, y = 7;
            Movement(x, y);

        }

        private void C9_Click(object sender, EventArgs e)
        {
            int x = 2, y = 8;
            Movement(x, y);

        }

        private void C10_Click(object sender, EventArgs e)
        {
            int x = 2, y = 9;
            Movement(x, y);

        }

        private void C11_Click(object sender, EventArgs e)
        {
            int x = 2, y = 10;
            Movement(x, y);

        }

        private void D1_Click(object sender, EventArgs e)
        {
            int x = 3, y = 0;
            Movement(x, y);

        }

        private void D2_Click(object sender, EventArgs e)
        {
            int x = 3, y = 1;
            Movement(x, y);

        }

        private void D3_Click(object sender, EventArgs e)
        {
            int x = 3, y = 2;
            Movement(x, y);

        }

        private void D5_Click(object sender, EventArgs e)
        {
            int x = 3, y = 4;
            Movement(x, y);

        }

        private void D6_Click(object sender, EventArgs e)
        {
            int x = 3, y = 5;
            Movement(x, y);

        }

        private void D7_Click(object sender, EventArgs e)
        {
            int x = 3, y = 6;
            Movement(x, y);

        }

        private void D8_Click(object sender, EventArgs e)
        {
            int x = 3, y = 7;
            Movement(x, y);

        }

        private void D9_Click(object sender, EventArgs e)
        {
            int x = 3, y = 8;
            Movement(x, y);

        }

        private void D10_Click(object sender, EventArgs e)
        {
            int x = 3, y = 9;
            Movement(x, y);

        }

        private void D11_Click(object sender, EventArgs e)
        {
            int x = 3, y = 10;
            Movement(x, y);

        }

        private void E1_Click(object sender, EventArgs e)
        {
            int x = 4, y = 0;
            Movement(x, y);

        }

        private void E2_Click(object sender, EventArgs e)
        {
            int x = 4, y = 1;
            Movement(x, y);

        }

        private void E3_Click(object sender, EventArgs e)
        {
            int x = 4, y = 2;
            Movement(x, y);

        }

        private void E4_Click(object sender, EventArgs e)
        {
            int x = 4, y = 3;
            Movement(x, y);

        }

        private void E5_Click(object sender, EventArgs e)
        {
            int x = 4, y = 4;
            Movement(x, y);

        }

        private void E6_Click(object sender, EventArgs e)
        {
            int x = 4, y = 5;
            Movement(x, y);

        }

        private void E7_Click(object sender, EventArgs e)
        {
            int x = 4, y = 6;
            Movement(x, y);

        }

        private void E8_Click(object sender, EventArgs e)
        {
            int x = 4, y = 7;
            Movement(x, y);

        }

        private void E9_Click(object sender, EventArgs e)
        {
            int x = 4, y = 8;
            Movement(x, y);

        }

        private void E10_Click(object sender, EventArgs e)
        {
            int x = 4, y = 9;
            Movement(x, y);

        }

        private void E11_Click(object sender, EventArgs e)
        {
            int x = 4, y = 10;
            Movement(x, y);

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            int x = 0, y = 3;
            Movement(x, y);

        }

        private void F1_Click(object sender, EventArgs e)
        {
            int x = 5, y = 0;
            Movement(x, y);
        }

        private void F2_Click(object sender, EventArgs e)
        {
            int x = 5, y = 1;
            Movement(x, y);
        }

        private void F3_Click(object sender, EventArgs e)
        {
            int x = 5, y = 2;
            Movement(x, y);
        }

        private void F4_Click(object sender, EventArgs e)
        {
            int x = 5, y = 3;
            Movement(x, y);
        }

        private void F5_Click(object sender, EventArgs e)
        {
            int x = 5, y = 4;
            Movement(x, y);
        }

        private void F7_Click(object sender, EventArgs e)
        {
            int x = 5, y = 6;
            Movement(x, y);
        }

        private void F8_Click(object sender, EventArgs e)
        {
            int x = 5, y = 7;
            Movement(x, y);
        }

        private void F9_Click(object sender, EventArgs e)
        {
            int x = 5, y = 8;
            Movement(x, y);
        }

        private void F10_Click(object sender, EventArgs e)
        {
            int x = 5, y = 9;
            Movement(x, y);
        }

        private void F11_Click(object sender, EventArgs e)
        {
            int x = 5, y = 10;
            Movement(x, y);
        }

        private void G1_Click(object sender, EventArgs e)
        {
            int x = 6, y = 0;
            Movement(x, y);
        }

        private void G2_Click(object sender, EventArgs e)
        {
            int x = 6, y = 1;
            Movement(x, y);
        }

        private void G3_Click(object sender, EventArgs e)
        {
            int x = 6, y = 2;
            Movement(x, y);
        }

        private void G4_Click(object sender, EventArgs e)
        {
            int x = 6, y = 3;
            Movement(x, y);
        }

        private void G5_Click(object sender, EventArgs e)
        {
            int x = 6, y = 4;
            Movement(x, y);
        }

        private void G6_Click(object sender, EventArgs e)
        {
            int x = 6, y = 5;
            Movement(x, y);
        }

        private void G7_Click(object sender, EventArgs e)
        {
            int x = 6, y = 6;
            Movement(x, y);
        }

        private void G8_Click(object sender, EventArgs e)
        {
            int x = 6, y = 7;
            Movement(x, y);
        }

        private void G9_Click(object sender, EventArgs e)
        {
            int x = 6, y = 8;
            Movement(x, y);
        }

        private void G10_Click(object sender, EventArgs e)
        {
            int x = 6, y = 9;
            Movement(x, y);
        }

        private void G11_Click(object sender, EventArgs e)
        {
            int x = 6, y = 10;
            Movement(x, y);
        }

        private void H1_Click(object sender, EventArgs e)
        {
            int x = 7, y = 0;
            Movement(x, y);
        }

        private void H2_Click(object sender, EventArgs e)
        {
            int x = 7, y = 1;
            Movement(x, y);
        }

        private void H3_Click(object sender, EventArgs e)
        {
            int x = 7, y = 2;
            Movement(x, y);
        }

        private void H4_Click(object sender, EventArgs e)
        {
            int x = 7, y = 3;
            Movement(x, y);
        }

        private void H5_Click(object sender, EventArgs e)
        {
            int x = 7, y = 4;
            Movement(x, y);
        }

        private void H6_Click(object sender, EventArgs e)
        {
            int x = 7, y = 5;
            Movement(x, y);
        }

        private void H7_Click(object sender, EventArgs e)
        {
            int x = 7, y = 6;
            Movement(x, y);
        }

        private void H8_Click(object sender, EventArgs e)
        {
            int x = 7, y = 7;
            Movement(x, y);
        }

        private void H9_Click(object sender, EventArgs e)
        {
            int x = 7, y = 8;
            Movement(x, y);
        }

        private void H10_Click(object sender, EventArgs e)
        {
            int x = 7, y = 9;
            Movement(x, y);
        }

        private void H11_Click(object sender, EventArgs e)
        {
            int x = 7, y = 10;
            Movement(x, y);
        }

        private void I1_Click(object sender, EventArgs e)
        {
            int x = 8, y = 0;
            Movement(x, y);
        }

        private void I2_Click(object sender, EventArgs e)
        {
            int x = 8, y = 1;
            Movement(x, y);

        }

        private void I3_Click(object sender, EventArgs e)
        {
            int x = 8, y = 2;
            Movement(x, y);

        }

        private void I4_Click(object sender, EventArgs e)
        {
            int x = 8, y = 3;
            Movement(x, y);

        }

        private void I5_Click(object sender, EventArgs e)
        {
            int x = 8, y = 4;
            Movement(x, y);

        }

        private void I6_Click(object sender, EventArgs e)
        {
            int x = 8, y = 5;
            Movement(x, y);

        }

        private void I7_Click(object sender, EventArgs e)
        {
            int x = 8, y = 6;
            Movement(x, y);

        }

        private void I8_Click(object sender, EventArgs e)
        {
            int x = 8, y = 7;
            Movement(x, y);

        }

        private void I9_Click(object sender, EventArgs e)
        {
            int x = 8, y = 8;
            Movement(x, y);

        }

        private void I10_Click(object sender, EventArgs e)
        {
            int x = 8, y = 9;
            Movement(x, y);

        }

        private void J1_Click(object sender, EventArgs e)
        {
            int x = 9, y = 0;
            Movement(x, y);

        }

        private void J2_Click(object sender, EventArgs e)
        {
            int x = 9, y = 1;
            Movement(x, y);

        }

        private void J3_Click(object sender, EventArgs e)
        {
            int x = 9, y = 2;
            Movement(x, y);

        }

        private void J4_Click(object sender, EventArgs e)
        {
            int x = 9, y = 3;
            Movement(x, y);

        }

        private void J5_Click(object sender, EventArgs e)
        {
            int x = 9, y = 4;
            Movement(x, y);

        }

        private void J6_Click(object sender, EventArgs e)
        {
            int x = 9, y = 5;
            Movement(x, y);

        }

        private void J7_Click(object sender, EventArgs e)
        {
            int x = 9, y = 6;
            Movement(x, y);

        }

        private void J8_Click(object sender, EventArgs e)
        {
            int x = 9, y = 7;
            Movement(x, y);

        }

        private void J9_Click(object sender, EventArgs e)
        {
            int x = 9, y = 8;
            Movement(x, y);

        }

        private void J10_Click(object sender, EventArgs e)
        {
            int x = 9, y = 9;
            Movement(x, y);

        }

        private void J11_Click(object sender, EventArgs e)
        {
            int x = 9, y = 10;
            Movement(x, y);

        }

        private void K2_Click(object sender, EventArgs e)
        {
            int x = 10, y = 1;
            Movement(x, y);

        }

        private void K3_Click(object sender, EventArgs e)
        {
            int x = 10, y = 2;
            Movement(x, y);

        }

        private void K4_Click(object sender, EventArgs e)
        {
            int x = 10, y = 3;
            Movement(x, y);

        }

        private void K5_Click(object sender, EventArgs e)
        {
            int x = 10, y = 4;
            Movement(x, y);

        }

        private void K6_Click(object sender, EventArgs e)
        {
            int x = 10, y = 5;
            Movement(x, y);

        }

        private void K7_Click(object sender, EventArgs e)
        {
            int x = 10, y = 6;
            Movement(x, y);

        }

        private void K8_Click(object sender, EventArgs e)
        {
            int x = 10, y = 7;
            Movement(x, y);

        }

        private void K10_Click(object sender, EventArgs e)
        {
            int x = 10, y = 9;
            Movement(x, y);

        }

        private void A10_Click(object sender, EventArgs e)
        {

            int x = 0, y = 9;
            Movement(x, y);

        }






        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            

                Graphics g = e.Graphics;
            Pen MahPen = new Pen(Color.AliceBlue);
            Brush MahBrush = new SolidBrush(Color.AliceBlue);

            g.Clear(Color.Black);

            for (int y = 0; y < 11; y++)
            {
                for (int x = 0; x < 11; x++)
                {




                    Rectangle r = new Rectangle(((width - 10) / 15) * x + 10, ((height - 10) / 16) * y + 15, width / 20, height / 20);

                    switch (x)
                    {
                        case 0:          
                        if(y==0||y==10){ MahPen = new Pen(Color.WhiteSmoke); MahBrush = new SolidBrush(Color.WhiteSmoke); }
                           else { MahPen = new Pen(Color.DarkOrange); MahBrush = new SolidBrush(Color.DarkOrange); }
                            break;


                        case 5:
                            if (y == 5) { MahPen = new Pen(Color.WhiteSmoke); MahBrush = new SolidBrush(Color.WhiteSmoke); }
                            else { MahPen = new Pen(Color.DarkOrange); MahBrush = new SolidBrush(Color.DarkOrange); }

                            break;

                        case 10:
                            if (y == 0 || y == 10) { MahPen = new Pen(Color.WhiteSmoke); MahBrush = new SolidBrush(Color.WhiteSmoke); }
                            else { MahPen = new Pen(Color.DarkOrange); MahBrush = new SolidBrush(Color.DarkOrange); }

                            break;

                        

                        default:
                             MahPen = new Pen(Color.DarkOrange); MahBrush = new SolidBrush(Color.DarkOrange); 
                            break;
                    }

                g.DrawRectangle(MahPen, r);

                g.FillRectangle(MahBrush, r);

                    switch (Pola[x, y])
                    {





                        case 2:

                            MahBrush = new SolidBrush(Color.DarkRed);
                            MahPen = new Pen(Color.DarkRed);
                            Rectangle rectk = new Rectangle(((width - 10) / 15) * x + 20, ((height - 10) / 16) * y + 25, width / 30 - 5, height / 30 - 5);
                            g.DrawEllipse(MahPen, rectk);
                            g.FillEllipse(MahBrush, rectk);
                            break;



                        case 3:

                            MahBrush = new SolidBrush(Color.IndianRed);
                            MahPen = new Pen(Color.IndianRed);
                            Rectangle rect2 = new Rectangle(((width - 10) / 15) * x + 20, ((height - 10) / 16) * y + 25, width / 30 - 5, height / 30 - 5);
                            g.DrawEllipse(MahPen, rect2);
                            g.FillEllipse(MahBrush, rect2);
                            break;



                        case 4:
                            MahBrush = new SolidBrush(Color.BlueViolet);
                            MahPen = new Pen(Color.BlueViolet);
                            Rectangle rect = new Rectangle(((width - 10) / 15) * x + 20, ((height - 10) / 16) * y + 25, width / 30 - 5, height / 30-5);
                            g.DrawEllipse(MahPen, rect);
                            g.FillEllipse(MahBrush, rect);
                            break;
                    }




                }
            }


        }






    }
}
