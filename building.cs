using System;
using System.Drawing;
using System.Threading;
using System.Media;


namespace en2d
{
	/// <summary>
	/// Summary description for building.
	/// </summary>
	public class Building
	{
		public FVector FSh = new FVector();
		public FVector FMove = new FVector();
		
		public Thread thread1; 
		
		public PointF pos = new PointF();
		public float x
		{
			set { pos.X = value; }
			get { return pos.X; }
		}
		
		public float y
		{
			set { pos.Y = value; }
			get {  return pos.Y; }			
		}
		
	
		public bool fix = false;
		public float oldx,oldy;
		public float radius;

		public float dx,dy;
		
		public float old_dx,old_dy;		
		
		public bool blue = true;
		public bool empty = true;
		public bool visible = true;
		public bool enable = true;
		public bool moveble = false;

		public int massa = 1;
	
		public int life = 100;
		
		float oldrad ;
		
		public bool inprocess ;		
		public Brush br;
		int iter=0;

		int ared,
			agreen,
			ablue;
			
			bool cc =false;
		public int coltype =0;
		
		public bool exclusive = false; 
			
		bool hidden = true;
		public 	int extype = 0;
		
		Random r;
	
		int NUM;
		
		public PointF[] tochka = new PointF[36];
		
		public int[] nt1 = new int [44];
		public int[] nt2 = new int [44];
		
		SoundPlayer snd4 = new SoundPlayer(@"sound\rss.wav");	
		SoundPlayer snd3 = new SoundPlayer(@"sound\32.wav");	
		
		FastMath fm = new FastMath();
		
		public Building(float x, float y, int NUM)
		{
			this.NUM = NUM;		
			inprocess = true;
			
			r = new Random((int)(x+y));

			if(r.Next(1000)<100)
				 this.exclusive = true;
			else this.exclusive = false;
			
			oldx=this.x = x;
			oldy=this.y = y;

			oldrad = this.radius = 10+r.Next(15);
			
				
			for(int k=0;k<36;k++)
				{	
				tochka[k].X = this.x + (float)Math.Cos(k*10)* this.radius;
				tochka[k].Y = this.y + (float)Math.Sin(k*10)* this.radius;
				}

		
			dx = dy = 0;
			
			
			coltype = r.Next (18);
			exclusive = true;
			
			switch (r.Next(20))
			{
				case 1:	 extype = 1;coltype = 21;	break; 
			 	case 2:	
 			 	case 3:  extype = 0;	break; 
			 	case 4:  extype = 2;break;		
				case 5:	extype = 3;;break;		
			 	case 6:	extype = 4;	break;		
 			 	case 7:	extype = 5;	break;				 	
			 	
			 		
			 	default: 	
							coltype = r.Next (18);
							exclusive = false;
							break;
			}
			
			
		
			
			switch(coltype)
			{
				case 0: br = new SolidBrush(Color.Red); break;
				case 1: br = new SolidBrush(Color.Orange); break;
				case 2: br = new SolidBrush(Color.Yellow); break;
				case 3: br = new SolidBrush(Color.Green); break;
				case 4: br = new SolidBrush(Color.Chocolate); break;			
				case 5: br = new SolidBrush(Color.Blue); break;
				case 6: br = new SolidBrush(Color.Violet); break;								
	
				case 7: br = new SolidBrush(Color.CornflowerBlue); break;			
				case 8: br = new SolidBrush(Color.DarkBlue); break;				
				case 9: br = new SolidBrush(Color.DarkMagenta); break;					
				case 10: br = new SolidBrush(Color.LightGray); break;
				case 11: br = new SolidBrush(Color.GreenYellow); break;				
				case 12: br = new SolidBrush(Color.DeepSkyBlue); break;
				case 13: br = new SolidBrush(Color.LightGreen); break;					
				case 14: br = new SolidBrush(Color.DarkSalmon); break;
				case 15: br = new SolidBrush(Color.Fuchsia); break;
				case 16: br = new SolidBrush(Color.Crimson); break;				
				case 17: br = new SolidBrush(Color.DimGray); break;		
				case 18: br = new SolidBrush(Color.Coral); break;					
				case 19: br = new SolidBrush(Color.BlueViolet); break;					
				default : br = new SolidBrush(Color.Black); break;	
				
			}
			
		//	this.ared = r.Next(255);
		//	this.agreen = r.Next(255);
		//	this.ablue = r.Next(255) ;	
			
		//	if(ared > agreen) ared = agreen;
			
		//	if(ared > ablue) ared = ablue;			
			
		//	thread1 = new Thread(new ThreadStart(Proc1));
		//	thread1.Start();
	
		}
				
		int soot(int a)
		{
			if(a<18) return a+18;
			else return a-18;
		}
		
		
		public  void Proc1() 
		{

			while(true)
			{
						
			//	if(y>=500-radius ) 
			//	y = 500-radius;
			//	else 
		//		y ++; 
		//		Thread.Sleep(10);
			}
		}

		public void Calc()
		{

				FSh.calc_kas(oldx,oldy,x,y);
				FSh.calc_prit_and_R(massa,x,y);
		//		FSh.calc_veter(massa,x,y);				
				FMove = FSh;
		  
				
				old_dx = dx;
				old_dy = dy;	
				
				dx = 0;
				dy = 0;	
				
				dx = (FMove.x1 - FMove.x0);
				dy = (FMove.y1 - FMove.y0);	
			
				
		
				
			if(!visible && enable)
			{
				this.radius+=10;
				if(this.exclusive)
				this.radius+=10;					
			}
			
			if(life==0) 
			{	ared = 255;
				agreen = 0;
				ablue = 0;
				
			
			}
			
		//	if(life<0)
		//		visible = false;
			
			if(Math.Abs(dx)+Math.Abs(dy)>0.5) hidden = false;
			else  hidden = true;
		}

		public void Move()
		{
			if(!moveble)
			{
				if(inprocess && NUM>1)
				{
				oldx=x;
				oldy=y;
		
				x+=dx;
				y+=dy;	
		
				}
			}
		}
	
		public void ShowShadow1(Graphics buildgr,bool flag, PointF[] light,float addx,float addy)
		{	
			
			if(!visible) 
				return;
			if(NUM<2)
				return;
		
		
			for(int k=0;k<36;k++)
				{	
				tochka[k].X =  this.x + (float)Math.Cos(k*10)* this.radius;
				tochka[k].Y = this.y +   (float)Math.Sin(k*10)* this.radius;
				}

			
					PointF[] pnt = new PointF[4];
	
					Brush tbr;
					

			
					for(int i=0;i<light.Length;i++)
					{
						float tmp2x = (tochka[nt2[i]].X-light[i].X);
						float tmp2y = (tochka[nt2[i]].Y-light[i].Y);
						
						float tmp3x = (tochka[nt1[i]].X-light[i].X);
						float tmp3y = (tochka[nt1[i]].Y-light[i].Y);
					
						int ck=50;
						for(float k=0.0f;k<1.005f && ck>=0; k+=0.03f,ck-=2)
						{
							
							pnt[0].X = tochka[nt1[i]].X+tmp3x * k + addx;
							pnt[0].Y = tochka[nt1[i]].Y+tmp3y * k + addy;
							
							pnt[1].X =  tochka[nt2[i]].X+tmp2x * k + addx;
							pnt[1].Y = 	tochka[nt2[i]].Y+tmp2y * k + addy;
			
							if (flag)  
								k=500f;
							
							pnt[2].X =tochka[nt2[i]].X+tmp2x * (k+0.03f)+ addx;
							pnt[2].Y =tochka[nt2[i]].Y+tmp2y * (k+0.03f)+ addy;
						    pnt[3].X =tochka[nt1[i]].X+tmp3x * (k+0.03f)+ addx;
						    pnt[3].Y =tochka[nt1[i]].Y+tmp3y * (k+0.03f)+ addy;
						
			
						    
						    tbr = new SolidBrush(Color.FromArgb(ck,0,0,0));
							
							buildgr.FillPolygon(tbr,pnt);
						}
					}
					
		}
		
		
		public void ShowShadow2(Graphics buildgr, float PX, float PY)
		{		
		/*	if(!visible) 
				return;
			if(NUM==0) 
				return;
		
			for(int k=0;k<36;k++)
				{	
				 tochka[k].X = this.x + (float)Math.Cos(k*10)* this.radius;
				 tochka[k].Y = this.y + (float)Math.Sin(k*10)* this.radius;
				}

			
					PointF[] pnt =new PointF[5];
	
					Brush tbr;
																	
					pnt[0].X = tochka[nt1].X;
					pnt[0].Y = tochka[nt1].Y;			
					
					pnt[1].X =  tochka[nt2].X;
					pnt[1].Y = 	tochka[nt2].Y;	
					
					pnt[2].X =tochka[nt2].X+(tochka[nt2].X-PX)*1.001f;
					pnt[2].Y =tochka[nt2].Y+(tochka[nt2].Y-PY)*1.001f;
					
					pnt[3].X =x+(x-PX)*1.4f;
					pnt[3].Y =y+(y-PY)*1.4f;					
									
					
					pnt[4].X =tochka[nt1].X+(tochka[nt1].X-PX)*1.001f;
					pnt[4].Y =tochka[nt1].Y+(tochka[nt1].Y-PY)*1.001f;					
					
					
					tbr = new SolidBrush(Color.FromArgb(50,0,0,0));
		
					buildgr.FillClosedCurve(tbr,pnt);
*/
		}
		
		
		public void Show(Graphics buildgr,float addx,float addy)
		{
			if(visible)
			{	
		
				
				
				if(NUM<2)
				{	
					
					for(int i = 0,k=40; i < 255; i +=10,k-=2)
					{
						
					Brush tbr = new SolidBrush(Color.FromArgb(i,255,255,255));
					buildgr.FillEllipse(tbr,
					(float)(x-k),
					(float)(y-k),
					(float)(2*k),
					(float)(2*k));	
					}
				}
			else
			{
			
			
					buildgr.FillEllipse(br,
					(float)(x-radius),
					(float)(y-radius),
					(float)(radius*2),
					(float)(radius*2));	
		
			
				buildgr.FillEllipse(Brushes.White,
					(float)(x-radius*0.6),
					(float)(y-radius*0.6),
					(float)(radius*0.2),
					(float)(radius*0.2));
				
			
					
				
				}
		
			cc=!cc;
			
			}
			else if(enable)
			{
			//	buildgr.FillRectangle(Brushes.DimGray,0,0,1024,768);	
				buildgr.FillEllipse(Brushes.WhiteSmoke,
					(int)(x-radius),
					(int)(y-radius),
					(int)(radius*2),
					(int)(radius*2));


					enable = false;
			}
		}
		}
}
