/*
 * Created by SharpDevelop.
 * User: Евгений
 * Date: 13.01.2007
 * Time: 19:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Media;
using System.Text;

namespace en2d
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm
	{
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
			
		FormSettings frm = new FormSettings();
		
		Image image1 = Image.FromFile(@"pic\weaponB.bmp");
		Image image2 = Image.FromFile(@"pic\weaponR.bmp");
		Image image3 = Image.FromFile(@"pic\weaponL.bmp");	
		Image image4 = Image.FromFile(@"pic\weaponT.bmp");	
		Image image5 = Image.FromFile(@"pic\b_area.bmp");
		Image im_stena = Image.FromFile(@"pic\stena.bmp");
		SoundPlayer snd1 = new SoundPlayer(@"sound\1.wav");
		SoundPlayer snd2 = new SoundPlayer(@"sound\2.wav");
		Random r = new Random();
		int RMX = 525;
		int LMX=0;
		int WinH =570; 
		float BMY=570;
		int TMY=0;	
		public Building[] bui;
		MyLine[] line = new MyLine[100];
		PointF[] light =new PointF[2];	
		int NUMLINES = 0;
		int numnextI = 0;
		float tmpX1;
		float tmpY1;
		static int TOTALCOUNT =3;		
		static int N = TOTALCOUNT;			
		bool AAA = true;
		bool GISH = false;
		bool ZH = false;
		bool PP = false;		
		int PX,PY;
		bool LB = false;
		bool RB = false;
		bool MB = false;		
		float BIGRAD = 200;	
		float DIF = 0.01f;
		int tmptt = 0;
		int tmp2tt = 100;	
		float GRAVITY = 0.9F;		
		int MONEY = 0;
		bool moneyUP = false;	
		int COL = 0;
		bool GameOver = false;
		bool PROCESS = false;
		float xmax = 0;
		float ymax = 0;
		float xmin = 0;			
		Point[] pnt = new Point[N];
		float[,] Cashe = new float[700,600];
		float goal_bmy = 500;	
		bool DD = false;
		bool nextBallMode = true;	
		float POWER = 0.0f;
		bool  powup = true;
		

		float Dist(Building bui1, Building bui2)
		{
               
			return (float)Math.Sqrt(
				Math.Abs(bui1.x - bui2.x) * Math.Abs(bui1.x - bui2.x)
				+ Math.Abs(bui1.y - bui2.y) * Math.Abs(bui1.y - bui2.y)
				); 
		}
		
		
		
		float Dist(Building bui1, PointF p)
		{
	            
			return (float)Math.Sqrt(
				Math.Abs(bui1.x - p.X) * Math.Abs(bui1.x - p.X)
				+ Math.Abs(bui1.y - p.Y) * Math.Abs(bui1.y - p.Y)
				); 
		}	

		float Dist(Building bui1, float x, float y)
		{
	            
			return (float)Math.Sqrt(
				Math.Abs(bui1.x - x) * Math.Abs(bui1.x - x)
				+ Math.Abs(bui1.y - y) * Math.Abs(bui1.y - y)
				); 
		}	
		
		float distance(PointF a,PointF  b,PointF c)
		{																																																																												
			float dx = a.X - b.X;
			float dy = a.Y - b.Y;
			float D = dx * (c.Y - a.Y) - dy * (c.X - a.X);
			return (float)(D / Math.Sqrt(dx * dx + dy * dy));
		}

		bool CircleIntersects(float x, float y, float R, float L, 
		                      PointF A,PointF  B,PointF Z)
		{
		// единичный вектор отрезка AB
		  float Xv = (B.X - A.X) / L;
		  float Yv = (B.Y - A.Y) / L;
		  float Xd = (A.X - x);
		  float Yd = (A.Y - y);
		  float b = 2 * (Xd * Xv + Yd * Yv);
		  float c = Xd * Xd + Yd * Yd - R * R;
		  float c4 = c + c; c4 += c4;
		  float D = b * b - c4;
		  if (D < 0) return false; // нет корней, нет пересечений
		
		  D = (float)Math.Sqrt((float)D);
		  float l1 = ( - b + D) * 0.5f;
		  float l2 = ( - b - D) * 0.5f;
		  bool intersects1 = ((l1 >= 0.0) && (l1 <= L));
		  bool intersects2 = ((l2 >= 0.0) && (l2 <= L));
		  bool intersects = intersects1 || intersects2;
		  if (intersects && Z.X!=0 && Z.Y!=0)
		  {
		    if (intersects1 && intersects2) 
		    {
		      l1 = (l1 + l2) * 0.5f;
		      Z.X = A.X + Xv * l1;
		      Z.Y = A.Y + Yv * l1;
		    }
		    else if (intersects1)
		    {
		      Z.Y = A.X + Xv * l1;
		      Z.Y = A.Y + Yv * l1;
		    }
		    else 
		    {
		      Z.X = A.X + Xv * l2;
		      Z.Y = A.Y + Yv * l2;
		    }
		  }
		  return intersects;
		}

			float XMed=0;
			float YMed=0;

		int soot(int a)
		{
			if(a<N/2) return a+N/2;
			else return a-N/2;
		}
		
		void  Proch(Building b1, Building b2)
		{
			for(int c=0;Dist(b1,b2)-(b1.radius+b2.radius)<0 && c<1000;c++)
			{ 
				b1.x+= 0.2f*(b1.x - b2.x)/(b1.radius+b2.radius);
				b1.y+= 0.2f*(b1.y - b2.y)/(b1.radius+b2.radius);
				b2.x+= 0.2f*(b2.x - b1.x)/(b1.radius+b2.radius);	
				b2.y+= 0.2f*(b2.y - b1.y)/(b1.radius+b2.radius);	
			}
		}
		
		void  Proch(Building b1, PointF p)
		{
		
			for(int c=0;Dist(b1,p)-(b1.radius)<=0 && c<1000;c++)
			{ 
				b1.x+= 0.1f* ( Math.Abs(FVector.gravity)+0.0001f) *(b1.x - p.X)/(b1.radius);
				b1.y+= 0.1f* ( Math.Abs(FVector.gravity)+0.0001f) *(b1.y - p.Y)/(b1.radius);
				
			}
	
		}
				
		void  Proch(Building b, MyLine line)
		{
			//	for(int o=0;o<10;o++)
			
				{
				if(Dist(b,line.a)<b.radius)  Proch(b,line.a);
				if(Dist(b,line.b)<b.radius)  Proch(b,line.b);			
				
				float dd1 = distance (line.a,
					                line.b,
							        new PointF(b.x,b.y));			
				float dd2 = distance (line.a,
					                 line.b,
							         new PointF(b.oldx,b.oldy));				
				float ddmed = distance (line.a,
					                 line.b,
					                 new PointF((b.oldx+b.x)*0.5f,(b.oldy+b.x)*0.5f));
				
				if(CircleIntersects((b.oldx+b.x)*0.5f,(b.oldy+b.y)*0.5f,b.radius, line.Length,
				                    line.a,line.b,new PointF(0,0)))
				{	
					if(Math.Sign(dd1)!= Math.Sign(dd2))
					{
						b.x-=b.dx/2;
						b.y-=b.dy/2;	
									
					}
					
	
				}	
			b.fix = false; 
				for( ;CircleIntersects(b.x,b.y,b.radius, line.Length,
				                              line.a,line.b,new PointF(0,0)) ;
						                       )
							
						{
							
							float dd = distance (line.a,
							                line.b,
							                new PointF(b.x,b.y));
						
							b.x+=0.1f * line.KKK().X * Math.Sign(dd) * (Math.Abs(FVector.gravity)+0.0001f);
							b.y-=0.1f * line.KKK().Y * Math.Sign(dd) * (Math.Abs(FVector.gravity)+0.0001f);

							
						

							b.fix = true; 
						//if(Math.Abs(b.dy) >  Math.Abs(b.dx))	
						
					
							if(line.Rotable)
							line.Angle += (b.x - line.med.X) * Math.Sign(dd) *  0.00001f;					
						
							if(line.Bad)
							{line.a.Y +=  0.1f;
							 line.b.Y +=  0.1f;	
							}
						}
					
			
				}
		}		
		


		public void Obrab()
		{	
			
			
						
			
			if (GameOver) return;
			//if(!PROCESS) TMY=BMY/2;
			//else  TMY=0;

			light[0].X = bui[0].x;
			light[0].Y = bui[0].y;
			
			light[1].X = bui[2].x;
			light[1].Y = bui[2].y;
			
			if(powup) POWER +=0.1f;
			
				
		
			
	//		else 	  POWER -=0.1f;
			
			if(POWER>10)  POWER =0;
			
			
			XMed=0;
			YMed=0;	
		
			int kkk=0;
			for(int i=0;i<N;i++)
			{
				if(bui[i].visible)
				{
				XMed+=bui[i].x;
				YMed+=bui[i].y;
				kkk++;
				}
				
			
			}	
			
		
			
				
		
			for(int i=0;i<N;i++)		
			{		

				
				
				for(int j=0;j<light.Length;j++)	
				{	float tmpdist =0;
					float tmpdist2 =1000;				
					float curdist=0;	
					for(int k=0;k<36;k++)
					{
						
						curdist = distance (light[j],
					             new PointF(bui[i].x,bui[i].y),  
					             new PointF(bui[i].tochka[k].X,bui[i].tochka[k].Y));
						        
						if(tmpdist<curdist)
						{	tmpdist = curdist;
							bui[i].nt1[j] = k;
						}
						
						if(tmpdist2>curdist)
						{	tmpdist2 = curdist;
							bui[i].nt2[j] = k;
						}				
						
						
					}
				}
			}
			   
		
			//
			
			//DIF+=0.0001f;
			
			//if(BMY>500-12) 
			// BMY=500+12	;
						
			
		//	goal_bmy -=DIF;
		//	BMY -= DIF;
			
			
				
			if(BMY < goal_bmy ) BMY+=DIF*100;
			
			XMed/=kkk;
			YMed/=kkk;
				/*
			
			Building tmpbmed = new Building(XMed,YMed);
			Building  tmpbbig = new Building(RMX*0.5F,BMY*0.5F);
		
			if(Dist(tmpbmed,tmpbbig)-(tmpbmed.radius + tmpbbig.radius )<0)
			{MONEY +=2;moneyUP = true;
			BIGRAD -= 0.1;}
			else {MONEY --;moneyUP = false; }
			*/
			
	
			/*
			if(!AAA && ZH)
			{
				for(int i=0;i<N;i++)			
				{
					
					if(!bui[i].moveble && bui[i].visible   && bui[soot(i)].visible )
					{
						bui[i].y+= (bui[i].y - bui[soot(i)].y )/((bui[i].radius+bui[soot(i)].radius));
						bui[i].x+= (bui[i].x - bui[soot(i)].x )/((bui[i].radius+bui[soot(i)].radius));

						bui[soot(i)].y+= (bui[soot(i)].y - bui[i].y )/((bui[soot(i)].radius+bui[i].radius));
						bui[soot(i)].x+= (bui[soot(i)].x - bui[i].x )/((bui[soot(i)].radius+bui[i].radius));

					
						
	

					}
					
				}

			}
	*/
	
		
			if(BMY<480) PROCESS = true;
				
			if(PROCESS)
				if(YMed <=10) 
			{
				GameOver = true;
			}
			
		
	
			if(!AAA )//&& i<N-1 && i>0 && bui[i].visible && bui[i+1].visible)
			for(int k=0;k<TOTALCOUNT;k++)
			
				{

			 	 //комок
		/*	
				for(int i=0;i<N;i++)	
				for(int j=0;j<N;j++)	
				{					
					if(bui[i].visible && bui[j].visible)	
					if(Dist(bui[i],bui[j])-(bui[i].radius+bui[j].radius)>0)
						{
							if(!bui[i].moveble )
							{
								bui[i].y-= (bui[i].y - bui[j].y)/((bui[i].radius+bui[j].radius)*15);
								bui[i].x-= (bui[i].x - bui[j].x)/((bui[i].radius+bui[j].radius)*15);
							}
							
							if(!bui[j].moveble)
							{
								bui[j].y-= (bui[j].y - bui[i].y)/((bui[j].radius+bui[i].radius)*15);
								bui[j].x-= (bui[j].x - bui[i].x)/((bui[j].radius+bui[i].radius)*15);			
							}
						}
				}	
				*/
				
				
			 	 //трос
			 
				for(int i=2;i<N-1;i++)	
				{

					
					
					if(bui[i].visible && bui[i+1].visible)
						
					for(int c=0;Dist(bui[i],bui[i+1])-(bui[i].radius+bui[i+1].radius)>0 && c<100;c++)
				//		if(Dist(bui[i],bui[i+1])-(bui[i].radius+bui[i+1].radius)>0)
					{
						if(!bui[i].moveble )
							{
							//	DrugKDrugu(bui[i],bui[i+1]);
									
								bui[i].y-= (bui[i].y - bui[i+1].y)/((bui[i].radius+bui[i+1].radius)*15);
								bui[i].x-= (bui[i].x - bui[i+1].x)/((bui[i].radius+bui[i+1].radius)*15);
							}
							
							if(!bui[i+1].moveble )
							{
							//	DrugKDrugu(bui[i+1],bui[i]);
								bui[i+1].y-= (bui[i+1].y - bui[i].y)/((bui[i+1].radius+bui[i].radius)*15);
								bui[i+1].x-= (bui[i+1].x - bui[i].x)/((bui[i+1].radius+bui[i].radius)*15);			
							}
						}		
					
	
				}
			//*/
				
				//÷òîá ñöåïëÿëèñü â êîëüöî 
				if(GISH)
					if(bui[0].visible &&  bui[N-1].visible)
					for(int c=0; Dist(bui[N-1],bui[0])-(bui[N-1].radius+bui[0].radius)>0 && c<1000;c++)
					
					{
							bui[N-1].y-= (bui[N-1].y - bui[0].y)/((bui[N-1].radius+bui[0].radius)*15);
							bui[N-1].x-= (bui[N-1].x - bui[0].x)/((bui[N-1].radius+bui[0].radius)*15);
			
							bui[0].y-= (bui[0].y - bui[N-1].y)/((bui[0].radius+bui[N-1].radius)*15);
							bui[0].x-= (bui[0].x - bui[N-1].x)/((bui[0].radius+bui[N-1].radius)*15);			
					}
					
					
				//палка
				
					if(ZH && bui[0].visible &&  bui[N-1].visible)
					{

										

							bui[0].x = 2 * bui[N/2].x - bui[N-1].x;	
							bui[0].y = 2 * bui[N/2].y - bui[N-1].y;		
						
							bui[N-1].x = 2 * bui[N/2].x - bui[0].x;	
							bui[N-1].y = 2 * bui[N/2].y - bui[0].y;														
							

					}
				
					
				
				}
	
			
			
			if(tmptt-- < 0)
			  for(int i=0;i<TOTALCOUNT;i++)
				if(!bui[i].moveble && (  Math.Abs(bui[i].old_dx  - bui[i].dx) >2
				   || Math.Abs(bui[i].old_dy  - bui[i].dy) >2) )
					{//snd3.Play();
				      tmptt = 5;
					}

							
			
	#region m
			
		for(int k=0;k<5;k++)
			{
		
				for(int i=0;i<TOTALCOUNT;i++)
				{
					for(int f=0;f<NUMLINES;f++)
					Proch(bui[i],line[f]);
				//	if(bui[i].moveble) continue;
	
				  if(bui[i].enable)
					for(int j=0;j<i;j++)
					{
					//	if(bui[j].moveble) continue;
 
						if(i!=j)
						if(bui[j].enable )
						{
							//÷òîá íå âõîäèëè äðóã â äðóãà (äëÿ òâåðäîñòè)							
						
							this.Proch( bui[i],bui[j]);
				
						}
					}//end for j 
				  
					
					//÷òîá áûë ïîë è ñòåíû
					if(bui[i].visible)
					{
						if(bui[i].y>BMY-bui[i].radius)
						{	//bui[i].y -= bui[i].radius*0.4f;
	
					//	}
						
					//	while(bui[i].y>BMY-bui[i].radius )
					//	{
						bui[i].y = BMY-bui[i].radius;
						}
						
						
	

					/*
						if(bui[i].y<TMY-bui[i].radius ) 
						{
						//	bui[i].y += 100;
							
							bui[i].y =TMY -bui[i].radius; 	
							
						}
*/
						if(bui[i].x<LMX + bui[i].radius ) 
						{
							bui[i].x = LMX + bui[i].radius;
						//	bui[i].dx=-bui[i].dx;
						//	bui[i].Move();	
							Invalidate();
						}
						if(bui[i].x>RMX - bui[i].radius ) 
						{	
							bui[i].x = RMX - bui[i].radius;	
						//	bui[i].dx=-bui[i].dx;
						//	bui[i].Move();
							Invalidate();
						}
					
					}
				}	//end for i
			}
			
		/*	if(BIGRAD == 190) 
			{this.Close();
				MessageBox.Show("ghg");
				
			}*/
		
		#endregion

	}
	   
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void CreateB(int oldCount, int newCount)
		{
			bui = new Building[newCount];
			pnt = new Point[newCount];
			
			for(int i=0;i<newCount;i++)	
				bui[i] = new Building(r.Next(RMX),r.Next(200),i);
		}
		
		
		
		
		
		bool[] key = new bool[256];
		
		bool ku = false;
		
		void MainFormKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
	
			key[e.KeyValue] = true;
			
			if (!ku)
			{
				
				if(this.key[(int)Keys.Up])
				{	bui[2].y-=15;
		ku = true;
				}
			}
			

		}
		
		void MainFormKeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			ku = false;
			key[e.KeyValue] = false;
			
	
		}
			
		void MainFormPaint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics gr = e.Graphics;
		
			
			float addx = 0;
			float addy = 0;			
			
			
			if(this.frm.checkBox1.Checked)
			{e.Graphics.DrawImage(im_stena, 0 ,0);
				

			}
			
					
		
			if(this.frm.checkBox7.Checked)
			{
				if(this.frm.checkBox2.Checked)
				for(int i=0;i<TOTALCOUNT;i++)
					bui[i].ShowShadow1(gr,true,light,addx,addy);	
				
				if(this.frm.checkBox5.Checked)
				for(int i=0;i<TOTALCOUNT;i++)
					bui[i].ShowShadow1(gr,false,light,addx,addy);	
			}
			
			
			if(this.frm.checkBox6.Checked)
			{
				if(this.frm.checkBox3.Checked)
				for(int i=0;i<NUMLINES;i++)
					line[i].ShowShadow(gr,true,light);	
				
			
				if(this.frm.checkBox4.Checked)
				for(int i=0;i<NUMLINES;i++)
					line[i].ShowShadow(gr,false,light);		
			}
			
			
				
			for(int i=0;i<TOTALCOUNT;i++)
			{
				bui[i].Show(gr,0,0);
				pnt[i].X = (int)bui[i].x;
				pnt[i].Y = (int)bui[i].y;
		
			}	
			
			for(int i=0;i<NUMLINES-1;i++)
				line[i].Show(gr);
			
		
			if(NUMLINES>0)
			line[NUMLINES-1].Show(gr);	
			
			
		//	gr.FillRectangle(Brushes.Yellow,0,0,100,10);
		//	gr.FillRectangle(Brushes.Red,0,0,POWER*10,10);

			if(LB)
			{gr.DrawLine(Pens.Green,tmpX1,tmpY1,PX,PY);
			}

			gr.DrawLine(Pens.Green,LMX,0,LMX,(float)BMY);
			gr.DrawLine(Pens.Green,RMX,0,RMX,(float)BMY);
		//	gr.DrawString(MONEY.ToString() + " $",new Font("Verdana",18),Brushes.Gold,30,70);


		}
		
		void MainFormLoad(object sender, System.EventArgs e)
		{
			//BGForm f = new BGForm();
			//f.Show();
			
			CreateB(0,TOTALCOUNT);
			ResizeRedraw = true;
			DoubleBuffered = true;
			FVector.gravity = GRAVITY;
			r = new Random();
			//this.TopMost = true;
				frm.TopMost = true;		
			frm.Show();
		
			
		}
		
		
		void MainFormMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(bui[numnextI].inprocess ==false)
			{bui[numnextI].x = e.X ;			 
			}
		
			
			for(int i=0;i<TOTALCOUNT;i++)
			{
				if(bui[i].moveble)
				{
					bui[i].oldx = bui[i].x;
					bui[i].oldy = bui[i].y;
				    bui[i].x = e.X; 
				    bui[i].y = e.Y;	
					bui[i].Calc();
				}
			}
			
			PX = e.X;
			PY = e.Y;						
		//	if(this.label1.Text == "Right down")
		//		RMX = e.X;

		}
		
		void MainFormMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Middle )
				{  powup = true;
						
					for(int i=0;i<TOTALCOUNT;i++)
					{Building tb = new Building(e.X,e.Y,i);
						if(Dist(tb,bui[i])< bui[i].radius && bui[i].visible && bui[i].enable)
						{
							bui[i].moveble = true;
							break;
						}
					}
			}
				
				snd1.Play();
				if(e.Button == MouseButtons.Left )
				{  powup = true;
						
					LB = true;

				//	int    imax = -1;
	
					tmpX1 = e.X;
					tmpY1 = e.Y;	
				}
				
			
			
				if(e.Button == MouseButtons.Right )
				{	RB = true;
					NUMLINES --;
					if(NUMLINES<0) NUMLINES=0;
				}
				

		}
		
		void MainFormMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
				for(int i=0;i<TOTALCOUNT;i++)
				bui[i].moveble = false;	
			
					
			if(!bui[numnextI].inprocess)
					{	bui[numnextI].inprocess = true;
						bui[numnextI].dx = 0 ;
						bui[numnextI].dy = POWER*4f ;					
						bui[numnextI].Move();
						tmp2tt  = 0;	
					}
			powup = false;
			
			
			
			if(e.Button == MouseButtons.Left)  
			{	LB = false;
				line[NUMLINES] = new MyLine(tmpX1,tmpY1,e.X,e.Y);
				
				
				if(this.frm.checkBoxRotLine.Checked)
					line[NUMLINES].SetRotable();
				
				if(this.frm.checkBoxBadLine.Checked)
					line[NUMLINES].SetBad();				
				
					
				
				NUMLINES++;				
			}
			
			
			if(e.Button == MouseButtons.Right) 
			{RB = false;
			tmpX1 = PX = e.X;
			tmpY1 = PY = e.Y;	
			}

		}
		

		void fffxm()
		{
			for(int i=0;i<NUMLINES;i++)
			{
				line[i].a.X --;
				line[i].b.X --;
			}
		}
		
		void fffxp()
		{
			for(int i=0;i<NUMLINES;i++)
			{
				line[i].a.X ++;
				line[i].b.X ++;
			}
		}	
		
		void fffym()
		{
			for(int i=0;i<NUMLINES;i++)
			{
				line[i].a.Y --;
				line[i].b.Y --;
			}
		}
		
		void fffyp()
		{
			for(int i=0;i<NUMLINES;i++)
			{
				line[i].a.Y ++;
				line[i].b.Y ++;
			}
		}	
			
		void Timer1Tick(object sender, System.EventArgs e)
		{
			for(int i=0;i<TOTALCOUNT;i++)
			{
				if(!bui[i].moveble)
				{
					bui[i].Calc();					
					bui[i].Move();

				}				
			}
				
			Obrab();
			
			
		
			
			if(this.key[(int)Keys.Left])	
				bui[2].x-=0.3f;
			
			if(this.key[(int)Keys.Right])	
				bui[2].x+=0.3f;		
			
			try
			{FVector.gravity = (float)Convert.ToDouble(this.frm.textBox1.Text)*0.01f;
			}
			catch(Exception)
			{}
				
			Invalidate();

		}

		
		void CheckBox1CheckedChanged(object sender, System.EventArgs e)
		{

				
		}
		
		void CheckBox2CheckedChanged(object sender, System.EventArgs e)
		{
			
		}
		
		void Button1Click(object sender, System.EventArgs e)
		{
			
		
		}
	}
}
