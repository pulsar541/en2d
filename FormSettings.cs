/*
 * Created by SharpDevelop.
 * User: Евгений
 * Date: 13.01.2007
 * Time: 22:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace en2d
{
	/// <summary>
	/// Description of FormSettings.
	/// </summary>
	public partial class FormSettings
	{
		public FormSettings()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void FormSettingsLoad(object sender, System.EventArgs e)
		{
			
		}
				
		void Button1Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}
		

		
		void CheckBox3CheckedChanged(object sender, System.EventArgs e)
		{
			this.checkBox4.Checked = !this.checkBox3.Checked;
		}
		
		void CheckBox4CheckedChanged(object sender, System.EventArgs e)
		{
			this.checkBox3.Checked = !this.checkBox4.Checked;
		}
		
		void CheckBox2CheckedChanged(object sender, System.EventArgs e)
		{
			this.checkBox5.Checked = !this.checkBox2.Checked; 
		}
		
		void CheckBox6CheckedChanged(object sender, System.EventArgs e)
		{
			
			this.checkBox3.Enabled =			
			this.checkBox4.Enabled =			
				this.checkBox6.Checked;
			
			
		}
		
		void CheckBox7CheckedChanged(object sender, System.EventArgs e)
		{
			this.checkBox2.Enabled =			
			this.checkBox5.Enabled =			
				this.checkBox7.Checked;
		}
		
		void TrackBar1Scroll(object sender, System.EventArgs e)
		{
			this.textBox1.Text = this.trackBar1.Value.ToString();
		}
		
		void CheckBoxRotLineCheckedChanged(object sender, System.EventArgs e)
		{
			this.checkBoxBadLine.Checked = !this.checkBoxRotLine.Checked;
		}
		
		void CheckBoxBadLineCheckedChanged(object sender, System.EventArgs e)
		{
			this.checkBoxRotLine.Checked = !this.checkBoxBadLine.Checked;
		}
	}
}
