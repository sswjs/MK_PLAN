using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace WindowsFormsApp_MK
{
    public partial class Form1 : Form
    {
        SQLiteConnection conn = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SQLiteConnection conn = null;
            //获取数据文件的路径
            string dbPath = "Data Source =" + Environment.CurrentDirectory + "/0001.db";
            //创建数据库实例，指定文件位置
            conn = new SQLiteConnection(dbPath);
            //打开数据库，若文件不存在会自动创建  
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //选择所有数据
            SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select * from REAL", conn);
            DataTable dt = new DataTable();
            mAdapter.Fill(dt);
            //绑定数据到DataGridView
            dataGridView1.DataSource = dt;
            //关闭数据库
            conn.Close();
            this.chart1.Series[0].Name = "轨迹图";
         
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                //将数据列显示
                dataGridView1.Columns[i].Visible = false;

            }
            dataGridView1.Columns["_id"].HeaderText = "序号";
            dataGridView1.Columns["_id"].Visible = true;
            dataGridView1.Columns["C_ID"].HeaderText = "孔号";
            dataGridView1.Columns["C_ID"].Visible = true;
            dataGridView1.Columns["DP"].HeaderText = "孔深";
            dataGridView1.Columns["DP"].Visible = true;
            dataGridView1.Columns["DP"].DefaultCellStyle.Format = "0.00"; //"flotamount"为列名
            dataGridView1.Columns["INC"].HeaderText = "倾角";
            dataGridView1.Columns["INC"].Visible = true;
            dataGridView1.Columns["INC"].DefaultCellStyle.Format = "0.00"; //"flotamount"为列名
            dataGridView1.Columns["M_AZ"].HeaderText = "磁方位";
            dataGridView1.Columns["M_AZ"].Visible = true;
            dataGridView1.Columns["M_AZ"].DefaultCellStyle.Format = "0.00"; //"flotamount"为列名
            dataGridView1.Columns["H_DISP"].HeaderText = "水平位移";
            dataGridView1.Columns["H_DISP"].Visible = true;
            dataGridView1.Columns["H_DISP"].DefaultCellStyle.Format = "0.00"; //"flotamount"为列名
            dataGridView1.Columns["LR_DISP"].HeaderText = "左右位移";
            dataGridView1.Columns["LR_DISP"].Visible = true;
            dataGridView1.Columns["LR_DISP"].DefaultCellStyle.Format = "0.00"; //"flotamount"为列名
            dataGridView1.Columns["UD_DISP"].HeaderText = "上下位移";
            dataGridView1.Columns["UD_DISP"].Visible = true;
            dataGridView1.Columns["UD_DISP"].DefaultCellStyle.Format = "0.00"; //"flotamount"为列名
            dataGridView1.EnableHeadersVisualStyles = false;//这样就可以使用当前的主题的样式了，这句话十分关键！
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;


            //  this.chart1.Series[0].Name = "学生成绩统计";
            //  string[] x = new string[] { "0", "1", "2", "3" };
            // double[] y = new double[] { xiaohong_grade, xiaoli_grade, xiaoming_grade, xiaoli_grade };
            //  //用DataBindXY()函数替换AddXY()
            //  chart1.Series[0].Points.DataBindXY(x, y);

            //遍历所有的行
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //将数据绑定到图
                this.chart1.Series[0].Points.AddXY( dt.Rows[i][9], dt.Rows[i][5]);

            }

        }
    }
}
