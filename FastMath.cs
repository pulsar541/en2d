/*
 * Created by SharpDevelop.
 * User: Евгений
 * Date: 12.01.2007
 * Time: 19:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace en2d
{
	/// <summary>
	/// Description of FastMath.
	/// </summary>
	public  class FastMath
	{
		/*public FastMath()
		{
		}
		*/
		public  double FSIN(double x)
		{
		 double xx=x*x;//2
		 double xxx=xx*x;//3
		 double xxxxxx=xxx*xxx; //6
	 
		 return x-0.166666667f*xxx
			     +0.008333333f*xxx*xx
				 -0.000198413f*xxxxxx*x
				 +0.000002756f*xxxxxx*xxx
				 -0.000000025f*xxxxxx*xxx*xx;
			

		
		}
		
		
		
		public  double FCOS(double x)
		{	

		 double xx=x*x;
		 double xxxx=xx*xx;
		 double xxxxxxxx=xxxx*xxxx;

		 return   1.00000000f
			     -0.500000000f*xx
				 +0.041666667f*xxxx
				 -0.001388889f*xxxx*xx
				 +0.000024802f*xxxxxxxx
				 -0.000000276f*xxxxxxxx*xx
				 +0.000000002f*xxxxxxxx*xxxx;	
		
		}

	}
}
