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
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private ComboBox SampleRated;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label Resource;
        private Label label6;
        private bool flag;
        private System.Windows.Forms.Button STOP;
        private Timer timer1;
        private ComboBox Range;
        private ComboBox Channel;
        private IContainer components;

		public Form()
		{
			InitializeComponent();
		}




        public uint cmdLEN;//接收字节长度
        public uint cmdGAIN;//根据界面选择的量程参数转换成用于数据转电压幅度运算的参数
 
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.tbx_Name_Devices = new System.Windows.Forms.TextBox();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Read = new System.Windows.Forms.Button();
            this.tbx_Status = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SampleRated = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Resource = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.STOP = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Range = new System.Windows.Forms.ComboBox();
            this.Channel = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbx_Name_Devices
            // 
            this.tbx_Name_Devices.Location = new System.Drawing.Point(204, 39);
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
            this.btn_Close.Location = new System.Drawing.Point(10, 358);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(90, 21);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "Close";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Read
            // 
            this.btn_Read.Enabled = false;
            this.btn_Read.Location = new System.Drawing.Point(10, 282);
            this.btn_Read.Name = "btn_Read";
            this.btn_Read.Size = new System.Drawing.Size(90, 22);
            this.btn_Read.TabIndex = 5;
            this.btn_Read.Text = "Read";
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
            this.richTextBox1.Location = new System.Drawing.Point(648, 38);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(138, 22);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged_1);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.AxisX.LogarithmBase = 6D;
            chartArea1.CursorX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(223, 112);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(563, 267);
            this.chart1.TabIndex = 15;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // SampleRated
            // 
            this.SampleRated.FormattingEnabled = true;
            this.SampleRated.Items.AddRange(new object[] {
            "30000",
            "15000",
            "7500",
            "3750",
            "2000",
            "1000",
            "500",
            "100",
            "60",
            "50",
            "30",
            "25",
            "15",
            "10",
            "5",
            "2.5"});
            this.SampleRated.Location = new System.Drawing.Point(88, 109);
            this.SampleRated.Name = "SampleRated";
            this.SampleRated.Size = new System.Drawing.Size(121, 20);
            this.SampleRated.TabIndex = 16;
            this.SampleRated.Text = "30000";
            this.SampleRated.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "采样速度Hz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "通道选择";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "量程范围";
            this.label5.Click += new System.EventHandler(this.label3_Click);
            // 
            // Resource
            // 
            this.Resource.AutoSize = true;
            this.Resource.Location = new System.Drawing.Point(133, 42);
            this.Resource.Name = "Resource";
            this.Resource.Size = new System.Drawing.Size(53, 12);
            this.Resource.TabIndex = 17;
            this.Resource.Text = "Resource";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(590, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 21);
            this.label6.TabIndex = 12;
            this.label6.Text = "VOLTAGE";
            this.label6.Click += new System.EventHandler(this.label1_Click);
            // 
            // STOP
            // 
            this.STOP.Enabled = false;
            this.STOP.Location = new System.Drawing.Point(10, 319);
            this.STOP.Name = "STOP";
            this.STOP.Size = new System.Drawing.Size(90, 23);
            this.STOP.TabIndex = 18;
            this.STOP.Text = "Stop";
            this.STOP.UseVisualStyleBackColor = true;
            this.STOP.Click += new System.EventHandler(this.STOP_Click_1);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.Range.Location = new System.Drawing.Point(88, 198);
            this.Range.Name = "Range";
            this.Range.Size = new System.Drawing.Size(121, 20);
            this.Range.TabIndex = 19;
            this.Range.Text = "±2.5V";
            // 
            // Channel
            // 
            this.Channel.FormattingEnabled = true;
            this.Channel.Items.AddRange(new object[] {
            "A1-A2",
            "A3-A4",
            "A5-A6",
            "A7-A8"});
            this.Channel.Location = new System.Drawing.Point(88, 155);
            this.Channel.Name = "Channel";
            this.Channel.Size = new System.Drawing.Size(121, 20);
            this.Channel.TabIndex = 20;
            this.Channel.Text = "A1-A2";
            // 
            // Form
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(798, 412);
            this.Controls.Add(this.Channel);
            this.Controls.Add(this.Range);
            this.Controls.Add(this.STOP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Resource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SampleRated);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_Status);
            this.Controls.Add(this.btn_Read);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.tbx_Name_Devices);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form";
            this.Text = "±2.5V_单通道差分连续采集";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
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
      
          
           string name = "USB DAQ-580i";         
           myFtdiDevice.OpenByDescription(name);//调用采集卡USB DLL，打开采集卡通信端口
           myFtdiDevice.SetTimeouts(10000, 10000); //调用采集卡USB DLL，设置发送和接收超时10秒
           tbx_Status.Text=myFtdiDevice.IsOpen.ToString();//调用采集卡USB DLL，查询USB是否启动，返回false未启动，返回true启动
           if (tbx_Status.Text == "True")
           {
               tbx_Status.Text = "SUCCESS"; 
               this.btn_Read.Enabled = true;
               this.btn_Close.Enabled = true;
               this.STOP.Enabled = true;
           }
           else { tbx_Status.Text = "FAILED"; MessageBox.Show("Device open failed, disconnect device from PC then reconnect"); }       
          
		 
		}



 


		private void btn_Read_Click(object sender, System.EventArgs e)


		{
    
            flag = true;

            double cmdDT;  //   时间间隔= 1/采样速度

            int numBytesToWrite = 7;//发送命令字节长度
            uint numBytesWritten = 0;
    
            string cmdRANGE; //增益，根据当前设置的测量范围，用于转换电压时进行比例衰减
            string cmdSAMPLES;
            string cmdCHANNEL;
            byte[] cmdBUFFER = new byte[numBytesToWrite]; //指令数组

            cmdCHANNEL = Channel.Text;
            cmdRANGE = Range.Text;
            cmdSAMPLES = SampleRated.Text;

            USB_DAQ_580i_CMD.commandClass.CONTINUE_DIFF_ONECHS(cmdSAMPLES, cmdRANGE, cmdCHANNEL, out cmdBUFFER, out cmdLEN, out cmdGAIN, out cmdDT);//根据用户参数配置控制指令
            myFtdiDevice.Write(cmdBUFFER, numBytesToWrite, ref numBytesWritten); //USB写入指令
            timer1.Enabled = true;//定时读取
            
		}


        private void timer1_Tick(object sender, EventArgs e)
        {
        
            uint numBytesToRead = cmdLEN;
            uint numBytesRead = 0;
            
            byte[] data = new byte[numBytesToRead];
            myFtdiDevice.Read(data, numBytesToRead, ref numBytesRead);// USB读取指定数量的byte

            double[] CH1 = new double[cmdLEN/3]; //每3个byte（高位，中位，低位）组成一个24位电压值，那么电压数值的个数=接收到的byte / 3
            USB_DAQ_580i_VOLTDISPLAY.voltdisplayClass.ONECHS(data, cmdLEN, cmdGAIN, CH1); //接收到的byte转换成电压输出数组CH1，该dll用于电压转换

            uint loop = cmdLEN / 3;

            chart1.Series[0].Points.Clear();//清空chart
            uint i = 0;
            for (i = 0; i < loop; i++)
            {

                chart1.Series[0].Points.AddY(CH1[i]);

            }
            richTextBox1.Text = CH1[0].ToString();//取数组中的任意一个，显示电压       
  
        }
    

        private void STOP_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            flag = false;
            int numBytesToWrite = 7;//发送命令字节长度
            byte[] Buffer = { 170, 0, 0, 0, 0, 0, 187 };//采集卡中断输出指令，连续模式下需要发中断指令终止采集卡输出
            uint numBytesWritten = 0;
            myFtdiDevice.Write(Buffer, numBytesToWrite, ref numBytesWritten); //USB写入指令
           
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

      



      
	}
}
