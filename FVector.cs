using System;

namespace en2d
{
	/// <summary>
	/// Summary description for FVector.
	/// </summary>
	public  class FVector
	{
		
		public float x0,y0,z0,  // откуда смотрит вектор
					 x1,y1,z1;  // куда смотрит вектор

		public float r;
		public float R;

		public static float gravity = 0.5f;
		
		public FVector()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public void calc_kas(float oldx,    
							 float oldy,   
							// double oldz,
							 float x,    
							 float y//,    
							// double z
			)  
		{ 

			x0=x;
			y0=y;
		//	z0=z;
			 
			x1=x+(x-oldx);
			y1=y+(y-oldy);
			//z1=z+(z-oldz);

		}


		
		public void  calc_prit_and_R(double massa, double xa,double ya )
		{
			y1+=gravity;
		}
		
		public void  calc_veter(double massa, double xa,double ya )
		{
			x1+=gravity;
		}
		
		public static void ResultofAddVect(FVector FRES,FVector A,FVector  B)
		{

			FRES.x0=A.x0;
			FRES.y0=A.y0;
			//FRES.z0=A.z0;
 			FRES.x1=A.x1+B.x1-FRES.x0;
			FRES.y1=A.y1+B.y1-FRES.y0;
			//FRES.z1=A.z1+B.z1-FRES.z0;
		}
	}
}

/*
 
// класс вектора силы
class FVECTOR
{

public:
 // координаты 
 double x0,y0,z0,  // откуда смотрит вектор
	    x1,y1,z1;  // куда смотрит вектор

 double r;
 double R;

 FVECTOR()
 {
 }


 void calc_kas(double oldx,    double oldy,    double oldz,
	           double x,    double y,    double z)  
 { 

	x0=x;
    y0=y;
    z0=z;
	 
	x1=x+(x-oldx);
    y1=y+(y-oldy);
    z1=z+(z-oldz);

}


 double calc_prit_and_R(double xa,double ya,double za,
	            double xb,double yb,double zb,
				double mass,double r)
 {
	R = rasst(xa,ya,za,xb,yb,zb);
	this->r=r;


		x0=xa;
		y0=ya;
		z0=za;

		double temp=mass/(R*R*R);

	//	if(R<r || temp>R) temp=0;

		x1=x0- (xa-xb) * temp;
		y1=y0- (ya-yb) * temp;
		z1=z0- (za-zb) * temp;

	return R;
 }

};



void ResultofAddVect(FVECTOR *FRES,FVECTOR A, FVECTOR B)
{

	FRES->x0=A.x0;
	FRES->y0=A.y0;
	FRES->z0=A.z0;
 	FRES->x1=A.x1+B.x1-FRES->x0;
	FRES->y1=A.y1+B.y1-FRES->y0;
	FRES->z1=A.z1+B.z1-FRES->z0;
}
 
 */
