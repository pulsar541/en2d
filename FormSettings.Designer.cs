/*
 * Created by SharpDevelop.
 * User: Евгений
 * Date: 13.01.2007
 * Time: 22:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace en2d
{
	partial class FormSettings : System.Windows.Forms.Form
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.checkBoxRotLine = new System.Windows.Forms.CheckBox();
			this.checkBoxBadLine = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(12, 12);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(112, 24);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Текстура стены";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(34, 113);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(160, 44);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "Простые";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox2CheckedChanged);
			// 
			// checkBox3
			// 
			this.checkBox3.Checked = true;
			this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox3.Location = new System.Drawing.Point(29, 53);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(87, 24);
			this.checkBox3.TabIndex = 2;
			this.checkBox3.Text = "Простые";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckedChanged += new System.EventHandler(this.CheckBox3CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 195);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 19);
			this.label1.TabIndex = 3;
			this.label1.Text = "Уровень гравитации";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(133, 195);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(61, 21);
			this.textBox1.TabIndex = 4;
			this.textBox1.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
			// 
			// checkBox4
			// 
			this.checkBox4.Location = new System.Drawing.Point(29, 73);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(96, 24);
			this.checkBox4.TabIndex = 2;
			this.checkBox4.Text = "С затуханием";
			this.checkBox4.UseVisualStyleBackColor = true;
			this.checkBox4.CheckedChanged += new System.EventHandler(this.CheckBox4CheckedChanged);
			// 
			// checkBox5
			// 
			this.checkBox5.Checked = true;
			this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox5.Location = new System.Drawing.Point(34, 144);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(179, 23);
			this.checkBox5.TabIndex = 1;
			this.checkBox5.Text = "С затуханием";
			this.checkBox5.UseVisualStyleBackColor = true;
			this.checkBox5.CheckedChanged += new System.EventHandler(this.CheckBox5CheckedChanged);
			// 
			// checkBox6
			// 
			this.checkBox6.Checked = true;
			this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox6.Location = new System.Drawing.Point(12, 34);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(104, 24);
			this.checkBox6.TabIndex = 5;
			this.checkBox6.Text = "Тени от линий";
			this.checkBox6.UseVisualStyleBackColor = true;
			this.checkBox6.CheckedChanged += new System.EventHandler(this.CheckBox6CheckedChanged);
			// 
			// checkBox7
			// 
			this.checkBox7.Checked = true;
			this.checkBox7.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox7.Location = new System.Drawing.Point(12, 103);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new System.Drawing.Size(112, 24);
			this.checkBox7.TabIndex = 5;
			this.checkBox7.Text = "Тени от шаров";
			this.checkBox7.UseVisualStyleBackColor = true;
			this.checkBox7.CheckedChanged += new System.EventHandler(this.CheckBox7CheckedChanged);
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(149, 7);
			this.trackBar1.Maximum = 100;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBar1.Size = new System.Drawing.Size(45, 182);
			this.trackBar1.TabIndex = 6;
			this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.trackBar1.Value = 100;
			this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1Scroll);
			// 
			// checkBoxRotLine
			// 
			this.checkBoxRotLine.Location = new System.Drawing.Point(17, 253);
			this.checkBoxRotLine.Name = "checkBoxRotLine";
			this.checkBoxRotLine.Size = new System.Drawing.Size(134, 24);
			this.checkBoxRotLine.TabIndex = 7;
			this.checkBoxRotLine.Text = "линия с поворотом";
			this.checkBoxRotLine.UseVisualStyleBackColor = true;
			this.checkBoxRotLine.CheckedChanged += new System.EventHandler(this.CheckBoxRotLineCheckedChanged);
			// 
			// checkBoxBadLine
			// 
			this.checkBoxBadLine.Location = new System.Drawing.Point(17, 273);
			this.checkBoxBadLine.Name = "checkBoxBadLine";
			this.checkBoxBadLine.Size = new System.Drawing.Size(150, 24);
			this.checkBoxBadLine.TabIndex = 8;
			this.checkBoxBadLine.Text = "не закрепленная линия";
			this.checkBoxBadLine.UseVisualStyleBackColor = true;
			this.checkBoxBadLine.CheckedChanged += new System.EventHandler(this.CheckBoxBadLineCheckedChanged);
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(205, 304);
			this.ControlBox = false;
			this.Controls.Add(this.checkBoxBadLine);
			this.Controls.Add(this.checkBoxRotLine);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.checkBox7);
			this.Controls.Add(this.checkBox6);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.checkBox4);
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.checkBox5);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Name = "FormSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormSettings";
			this.Load += new System.EventHandler(this.FormSettingsLoad);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.CheckBox checkBoxBadLine;
		public System.Windows.Forms.CheckBox checkBoxRotLine;
		private System.Windows.Forms.TrackBar trackBar1;
		public System.Windows.Forms.CheckBox checkBox7;
		public System.Windows.Forms.CheckBox checkBox6;
		public System.Windows.Forms.CheckBox checkBox5;
		public System.Windows.Forms.CheckBox checkBox4;
		public System.Windows.Forms.TextBox textBox1;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.CheckBox checkBox3;
		public System.Windows.Forms.CheckBox checkBox2;
		public System.Windows.Forms.CheckBox checkBox1;
		
		void TextBox1TextChanged(object sender, System.EventArgs e)
		{
			
		}
		
		void CheckBox5CheckedChanged(object sender, System.EventArgs e)
		{
			this.checkBox2.Checked = !this.checkBox5.Checked; 
		}
	}
}
