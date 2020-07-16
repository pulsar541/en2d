/*
 * Created by SharpDevelop.
 * User: ???????
 * Date: 07.01.2007
 * Time: 1:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;

namespace en2d
{
	/// <summary>
	/// Description of MyLine.
	/// </summary>
	public class MyLine
	{
		public PointF a;
		public PointF b;
		
		public PointF med;
		
		PointF KK = new PointF();
		public float Length ;
		
		Pen p = new Pen(Color.Gray,4);
	
			public bool Rotable = false;
			public bool Bad = false;		
			public bool Lift = false;		
		
		PointF[] pnt = new PointF[4] ;
		float ang=0;
		
	
		public float Angle = 0f;
		
		public MyLine(float x1, float y1, float x2, float y2)
		{
			PointF tmpp;
		
			a = new PointF(x1,y1);
			b = new PointF(x2,y2);

			
			if(b.X<a.X)
			{	tmpp = a;	
				a = b; 
				b = tmpp;
			
			}
			
			med.X = (a.X+b.X)*0.5f;
			med.Y = (a.Y+b.Y)*0.5f;		
			
			KK =  KKK();
			Length = (float)Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y)*(a.Y - b.Y));
			
			
		//	Rotate (Angle);
		}
		
		public void SetRotable()
		{
			Rotable = true;
			p = new Pen(Color.Blue,4);
		}
		
		public void SetBad()
		{
			Bad = true;
			p = new Pen(Color.Red,4);
		}		
		
		public void SetLift()
		{
			Lift = true;
			p = new Pen(Color.Gold,4);
		}			
	
		
		public void Rotate (float angle)
		{
			a.X = med.X - (float)Math.Cos (angle)*Length*0.5f;
			a.Y = med.Y - (float)Math.Sin (angle)*Length*0.5f;
			
			b.X = med.X + med.X - a.X;
			b.Y = med.Y + med.Y - a.Y;
			
			if(b.X<a.X)
			{	PointF  tmpp = a;	a = b; b = tmpp;
	
			}		
			
		}
					
		public PointF  KKK()
		{
			
			PointF rezz = new PointF();	
			float minX = Math.Min (a.X,b.X);
			float minY = Math.Min (a.Y,b.Y);
			
			float NewAx = a.X - minX;
			float NewAy = a.Y - minY;
			float NewBx = b.X - minX;
			float NewBy = b.Y - minY;			

			rezz.X = (NewAy + NewBy)/(NewAx + NewBx) ;
			rezz.Y = 1/rezz.X;			
			
			float max = Math.Max(rezz.X,rezz.Y);
			
			rezz.X /= max;
			rezz.Y /= max;	
				
			if (a.Y > b.Y) rezz.X=-rezz.X;
			
			if (a.Y == b.Y) {rezz.X=0; rezz.Y=1;}
			if (a.X == b.X) {rezz.X=1; rezz.Y=0;}							
			return rezz; 
		
		}
		
	
		public void Show (Graphics linegr)
		{	
			if(Rotable)
			{
				if(Angle<0) Angle+=0.001f;
				else Angle-=0.001f;
				
				Rotate (Angle);
			//	ang += 10/this.Length;
			//	if(ang>360)ang=0;	
			//	Rotate(ang);
			}
			
			
		//	if(f==1) linegr.DrawLine(Pens.Red,a,b);
		//	else
		
		
			linegr.DrawLine(p,a,b);
					
			
		//	PX =100;
		//	PY = 0;
			
			//linegr.DrawLine(Pens.Gray,a.X,a.Y,a.X*5,a.Y*5);
			//linegr.DrawLine(Pens.Gray,b.X,b.Y,b.X*5,b.Y*5);	
		}
		
		public void ShowShadow (Graphics linegr,bool flag, PointF[] light)		
		{
			Brush br;
			
			for(int i=0; i<light.Length; i++)
			{
				
				//float mtx = (med.X-light[i].X);
				//float mty = (med.Y-light[i].Y);	
				
				//float kk = (float)Math.Sqrt(mtx*mtx +mty*mty );	
				
				float tmp2x = (b.X-light[i].X)*0.3f;
				float tmp2y = (b.Y-light[i].Y)*0.3f;
				float tmp3x = (a.X-light[i].X)*0.3f;
				float tmp3y = (a.Y-light[i].Y)*0.3f;
				
			

				
				

			/*		
				tmp2x /= kk;
				tmp2y /= kk;
				tmp3x /= kk;
				tmp3y /= kk;
				*/
				int ck=220-Convert.ToInt32(flag)*50;
				float dk = 0.2f;
				
				for(float k=0.0f; ck>=0 && k<500; k+=dk,ck-=6)
				{
			
				pnt[0].X = a.X+tmp3x * k;
				pnt[0].Y = a.Y+tmp3y * k;			
				
				pnt[1].X =  b.X+tmp2x * k;
				pnt[1].Y = 	b.Y+tmp2y * k;
				
				if(flag) 
					k = 500f;
				
				pnt[2].X =b.X+tmp2x * (k+dk);
				pnt[2].Y =b.Y+tmp2y * (k+dk);
			    pnt[3].X =a.X+tmp3x * (k+dk);
			    pnt[3].Y =a.Y+tmp3y * (k+dk);
			
		    br = new SolidBrush(Color.FromArgb(ck/light.Length,0,0,0));
	
				
			//    br = new SolidBrush(Color.LightGray);
			    
			    
				linegr.FillPolygon(br,pnt);
				}
			}
			
			
			//linegr.DrawString(KK.Y.ToString(),new Font("arial",10),Brushes.Black,0.5f*(a.X+b.X)-5f,0.5f*(a.Y+b.Y)+5f);
			//linegr.DrawString(KK.X.ToString(),new Font("arial",10),Brushes.Black,0.5f*(a.X+b.X)-5f,0.5f*(a.Y+b.Y)-15f);			
			
		}
	}
}
