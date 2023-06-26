using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FTD2XX_NET;//操作USB
 

namespace USBTransfer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form : System.Windows.Forms.Form
	{

        FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;

        FTDI myFtdiDevice = new FTDI();
      


		private System.Windows.Forms.TextBox tbx_Name_Devices;
		private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Read;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_Status;
        private RichTextBox richTextBox1;
        private ComboBox Channel;
        private Label label3;
        private ComboBox Samples;
        private Label label4;
        private Label label5;
        private Label Resource;
        private Label label6;
        private Label label7;
        private ComboBox Range;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.tbx_Name_Devices = new System.Windows.Forms.TextBox();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Read = new System.Windows.Forms.Button();
            this.tbx_Status = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Channel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Samples = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Resource = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Range = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbx_Name_Devices
            // 
            this.tbx_Name_Devices.Location = new System.Drawing.Point(236, 39);
            this.tbx_Name_Devices.Name = "tbx_Name_Devices";
            this.tbx_Name_Devices.Size = new System.Drawing.Size(121, 21);
            this.tbx_Name_Devices.TabIndex = 1;
            this.tbx_Name_Devices.Text = "USB DAQ-580i";
            this.tbx_Name_Devices.TextChanged += new System.EventHandler(this.tbx_Name_Devices_TextChanged);
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(10, 39);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(90, 21);
            this.btn_Open.TabIndex = 2;
            this.btn_Open.Text = "Open";
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Enabled = false;
            this.btn_Close.Location = new System.Drawing.Point(10, 369);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(90, 21);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "Close";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Read
            // 
            this.btn_Read.Enabled = false;
            this.btn_Read.Location = new System.Drawing.Point(10, 274);
            this.btn_Read.Name = "btn_Read";
            this.btn_Read.Size = new System.Drawing.Size(90, 22);
            this.btn_Read.TabIndex = 5;
            this.btn_Read.Text = "Write_Read";
            this.btn_Read.Click += new System.EventHandler(this.btn_Read_Click);
            // 
            // tbx_Status
            // 
            this.tbx_Status.Location = new System.Drawing.Point(421, 39);
            this.tbx_Status.Name = "tbx_Status";
            this.tbx_Status.Size = new System.Drawing.Size(121, 21);
            this.tbx_Status.TabIndex = 11;
            this.tbx_Status.TextChanged += new System.EventHandler(this.tbx_Status_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(363, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "Status";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.richTextBox1.Location = new System.Drawing.Point(404, 112);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(138, 22);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged_1);
            // 
            // Channel
            // 
            this.Channel.FormattingEnabled = true;
            this.Channel.Items.AddRange(new object[] {
            "A1-A2",
            "A3-A4",
            "A5-A6",
            "A7-A8"});
            this.Channel.Location = new System.Drawing.Point(87, 99);
            this.Channel.Name = "Channel";
            this.Channel.Size = new System.Drawing.Size(121, 20);
            this.Channel.TabIndex = 16;
            this.Channel.Text = "A1-A2";
            this.Channel.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "通道选择";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Samples
            // 
            this.Samples.FormattingEnabled = true;
            this.Samples.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "15",
            "30",
            "60",
            "300",
            "500",
            "600",
            "1000",
            "1200",
            "2000",
            "3000",
            "6000",
            "12000"});
            this.Samples.Location = new System.Drawing.Point(87, 138);
            this.Samples.Name = "Samples";
            this.Samples.Size = new System.Drawing.Size(121, 20);
            this.Samples.TabIndex = 16;
            this.Samples.Text = "600";
            this.Samples.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "样本平均数量";
            this.label4.Click += new System.EventHandler(this.label3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "量程范围";
            this.label5.Click += new System.EventHandler(this.label3_Click);
            // 
            // Resource
            // 
            this.Resource.AutoSize = true;
            this.Resource.Location = new System.Drawing.Point(177, 42);
            this.Resource.Name = "Resource";
            this.Resource.Size = new System.Drawing.Size(53, 12);
            this.Resource.TabIndex = 17;
            this.Resource.Text = "Resource";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(346, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 21);
            this.label6.TabIndex = 12;
            this.label6.Text = "VOLTAGE";
            this.label6.Click += new System.EventHandler(this.label1_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(296, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(230, 41);
            this.label7.TabIndex = 12;
            this.label7.Text = "芯片内置滤波器，根据设置的样本数自动取平均，输出一个值";
            this.label7.Click += new System.EventHandler(this.label1_Click);
            // 
            // Range
            // 
            this.Range.FormattingEnabled = true;
            this.Range.Items.AddRange(new object[] {
            "±2.5V",
            "±1.25V",
            "±0.625V",
            "±312.5mV",
            "±156.25mV",
            "±78.125mV"});
            this.Range.Location = new System.Drawing.Point(87, 174);
            this.Range.Name = "Range";
            this.Range.Size = new System.Drawing.Size(121, 20);
            this.Range.TabIndex = 18;
            this.Range.Text = "±2.5V";
            // 
            // Form
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(569, 412);
            this.Controls.Add(this.Range);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Resource);
            this.Controls.Add(this.Samples);
            this.Controls.Add(this.Channel);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_Status);
            this.Controls.Add(this.btn_Read);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.tbx_Name_Devices);
            this.Name = "Form";
            this.Text = "±2.5V_单通道差分单次采集";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form());
		}

 

		private void btn_Open_Click(object sender, System.EventArgs e)
        {          
            uint Handle;
            uint status;
            string name = "USB DAQ-580i";
           // tbx_Status.Text = "DAQ OPEN";          
           myFtdiDevice.OpenByDescription(name);
           myFtdiDevice.SetTimeouts(10000, 10000);
           tbx_Status.Text=myFtdiDevice.IsOpen.ToString();
           if (tbx_Status.Text == "True") {  tbx_Status.Text="SUCCESS"; }
           else { tbx_Status.Text = "FAILED"; MessageBox.Show("Device open failed, disconnect device from PC then reconnect"); }
       
           this.btn_Read.Enabled = true;
           this.btn_Close.Enabled = true; 
		 
		}


      
		private void btn_Read_Click(object sender, System.EventArgs e)

		{
          
                double dt;  //   时间间隔= 1/采样速度
              
                int numBytesToWrite = 7;//发送命令字节长度
                uint numBytesWritten = 0;

               
                uint cmdLEN;//接收字节长度
                uint cmdGAIN;//根据界面选择的量程参数转换成用于数据转电压幅度运算的参数
                string cmdRANGE; //增益，根据当前设置的测量范围，用于转换电压时进行比例衰减
                string cmdSAMPLES;
                string cmdCHANNEL;
                byte[] cmdBUFFER = new byte[numBytesToWrite]; //指令数组

               cmdCHANNEL = Channel.Text;
               cmdRANGE = Range.Text;
               cmdSAMPLES = Samples.Text;


               USB_DAQ_580i_CMD.commandClass.SINGLE_DIFF_ONECHS(cmdSAMPLES, cmdRANGE, cmdCHANNEL,out cmdBUFFER,out cmdLEN,out cmdGAIN);//根据用户参数配置控制指令

       

                
                myFtdiDevice.Write(cmdBUFFER, numBytesToWrite, ref numBytesWritten); //USB写入指令


                uint numBytesToRead = cmdLEN;
                uint numBytesRead = 0;               
                byte[] data = new byte[cmdLEN]; 
                myFtdiDevice.Read(data, numBytesToRead, ref numBytesRead);// USB读取指定数量的byte

                double[] CH1 = new double[cmdLEN / 3]; //每3个byte（高位，中位，低位）组成一个24位电压值，那么电压数值的个数=接收到的byte / 3
               USB_DAQ_580i_VOLTDISPLAY.voltdisplayClass.ONECHS(data, cmdLEN, cmdGAIN, CH1); //接收到的byte转换成电压输出数组CH1，该dll用于电压转换


                richTextBox1.Text = CH1[0].ToString();//取数组中的任意一个，显示电压
      
           
		}

		private void btn_Close_Click(object sender, System.EventArgs e)
		{
            myFtdiDevice.Close();
            tbx_Status.Text ="CLOSED";
 
		}

	 

	 
		private void btn_WriteDef_Click(object sender, System.EventArgs e)
		{
		 
		}




        private void tbx_Name_Devices_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbx_Write_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_Load(object sender, EventArgs e)
        {

        }

        private void tbx_Status_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbx_Read_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataRepeater1_CurrentItemIndexChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
	}
}
