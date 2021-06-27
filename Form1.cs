using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.IO;
using System.IO.Ports;

using Microsoft.Office.Interop.Excel;
using excel = Microsoft.Office.Interop.Excel;

namespace zedGraphDeneme1
{
    
    public partial class Form1 : Form
    {
        //grafik zımbırtıları
        GraphPane yükseklik = new GraphPane();
        GraphPane basinc = new GraphPane();
        GraphPane sicaklik = new GraphPane();
        GraphPane x = new GraphPane();
        GraphPane y = new GraphPane();
        GraphPane z = new GraphPane();
        GraphPane a = new GraphPane();
        GraphPane b = new GraphPane();
        GraphPane c = new GraphPane();


        PointPairList pointYükseklik = new PointPairList();
        PointPairList pointBasinc = new PointPairList();
        PointPairList pointSicaklik = new PointPairList();
        PointPairList pointX = new PointPairList();
        PointPairList pointY = new PointPairList();
        PointPairList pointZ = new PointPairList();
        PointPairList pointA = new PointPairList();
        PointPairList pointB = new PointPairList();
        PointPairList pointC = new PointPairList();

        LineItem curveYükseklik;
        LineItem curveBasinc;
        LineItem curveSicaklik;
        LineItem curveX;
        LineItem curveY;
        LineItem curveZ;
        LineItem curveA;
        LineItem curveB;
        LineItem curveC;
        
        double zaman;
        public Form1()
        {
            InitializeComponent();
        }

        //excel elemanları
        
        excel.Application uygulama;
        excel.Workbook kitap;
        excel.Worksheet sayfa;
        object Missing = System.Reflection.Missing.Value;
        excel.Range range;
        //int column = 1;
        int row = 2;

        private void Form1_Load(object sender, EventArgs e)
        {
            uygulama = new excel.Application();
            kitap = uygulama.Workbooks.Add(Missing);
            sayfa = (excel.Worksheet)uygulama.Worksheets.get_Item(1);
            range = sayfa.UsedRange;
            sayfa = (excel.Worksheet)uygulama.ActiveSheet;
            uygulama.Visible = true;

            excel.Range bölge = (excel.Range)sayfa.Cells[1, 1];
            bölge.Value2 = "sicaklik";

            excel.Range bölge1 = (excel.Range)sayfa.Cells[1, 2];
            bölge1.Value2 = "basinc";

            excel.Range bölge2 = (excel.Range)sayfa.Cells[1, 3];
            bölge2.Value2 = "hiz";

            excel.Range bölge3 = (excel.Range)sayfa.Cells[1, 4];
            bölge3.Value2 = "yükseklik";

            excel.Range bölge4 = (excel.Range)sayfa.Cells[1, 5];
            bölge4.Value2 = "x";

            excel.Range bölge5 = (excel.Range)sayfa.Cells[1, 6];
            bölge5.Value2 = "y";


            dataGridView1.Columns.Add("sicaklik", "sicaklik");
            dataGridView1.Columns.Add("basinc", "basinc");
            dataGridView1.Columns.Add("hiz", "hiz");
            dataGridView1.Columns.Add("yükseklik", "yükseklik");
            dataGridView1.Columns.Add("x", "x");
            dataGridView1.Columns.Add("y", "y");
            

            Control.CheckForIllegalCrossThreadCalls = false;
            comboBox1.Items.Add(300);
            comboBox1.Items.Add(1200);
            comboBox1.Items.Add(2400);
            comboBox1.Items.Add(9600);
            comboBox1.Items.Add(19200);
            comboBox1.Items.Add(57600);

            portlar.Items.Add("COM1");
            portlar.Items.Add("COM2");
            portlar.Items.Add("COM3");
            portlar.Items.Add("COM4");
            portlar.Items.Add("COM5");
            portlar.Items.Add("COM6");
            
            grafik();
        }
        private void grafik()
        {
            yükseklik = zedGraphControl1.GraphPane;
            yükseklik.Title.Text = "yükseklik - zaman grafiği";
            yükseklik.XAxis.Title.Text = "t(s)";
            yükseklik.YAxis.Title.Text = "H(m)";
            yükseklik.YAxis.Scale.Min = 0;
            curveYükseklik = yükseklik.AddCurve(null, pointYükseklik, Color.Red, SymbolType.None);
            curveYükseklik.Line.Width = 1;
            // yükseklik için

            basinc = zedGraphControl2.GraphPane;
            basinc.Title.Text = "basınç - zaman grafiği";
            basinc.XAxis.Title.Text = "t(s)";
            basinc.YAxis.Title.Text = "P(Pa)";
            basinc.YAxis.Scale.Min = 0;
            curveBasinc = basinc.AddCurve(null, pointBasinc, Color.Red, SymbolType.None);
            curveBasinc.Line.Width = 1;
            //basınç

            sicaklik = zedGraphControl3.GraphPane;
            sicaklik.Title.Text = "sıcaklık - zaman grafiği";
            sicaklik.XAxis.Title.Text = "t(s)";
            sicaklik.YAxis.Title.Text = "T(C)";
            sicaklik.YAxis.Scale.Min = 0;
            curveSicaklik = sicaklik.AddCurve(null, pointSicaklik, Color.Red, SymbolType.None);
            curveSicaklik.Line.Width = 1;
            //sıcaklık

            x = zedGraphControl4.GraphPane;
            x.Title.Text = "X - zaman grafiği";
            x.XAxis.Title.Text = "t(s)";
            x.YAxis.Title.Text = "x";
            x.YAxis.Scale.Min = 0;
            curveX = x.AddCurve(null, pointX, Color.Red, SymbolType.None);
            curveX.Line.Width = 1;
            //x

            y = zedGraphControl5.GraphPane;
            y.Title.Text = "y - zaman grafiği";
            y.XAxis.Title.Text = "t(s)";
            y.YAxis.Title.Text = "y";
            y.YAxis.Scale.Min = 0;
            curveY = y.AddCurve(null, pointY, Color.Red, SymbolType.None);
            curveY.Line.Width = 1;
            //y

            z = zedGraphControl6.GraphPane;
            z.Title.Text = "z - zaman grafiği";
            z.XAxis.Title.Text = "t(s)";
            z.YAxis.Title.Text = "z";
            z.YAxis.Scale.Min = 0;
            curveZ = z.AddCurve(null, pointZ, Color.Red, SymbolType.None);
            curveZ.Line.Width = 1;
            //z

            a = zedGraphControl7.GraphPane;
            a.Title.Text = "a - zaman grafiği";
            a.XAxis.Title.Text = "t(s)";
            a.YAxis.Title.Text = "a";
            a.YAxis.Scale.Min = 0;
            curveA = a.AddCurve(null, pointA, Color.Red, SymbolType.None);
            curveA.Line.Width = 1;
            //a

            b = zedGraphControl9.GraphPane;
            b.Title.Text = "b - zaman grafiği";
            b.XAxis.Title.Text = "t(s)";
            b.YAxis.Title.Text = "b";
            b.YAxis.Scale.Min = 0;
            curveB = b.AddCurve(null, pointB, Color.Red, SymbolType.None);
            curveB.Line.Width = 1;
            //b

            c = zedGraphControl12.GraphPane;
            c.Title.Text = "c - zaman grafiği";
            c.XAxis.Title.Text = "t(s)";
            c.YAxis.Title.Text = "c";
            c.YAxis.Scale.Min = 0;
            curveC = c.AddCurve(null, pointC, Color.Red, SymbolType.None);
            curveC.Line.Width = 1;
            //c

        }
        

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            

            string[] data = serialPort1.ReadLine().Split(';');

            
            zaman += 0.05;
            pointYükseklik.Add(new PointPair(zaman, Convert.ToDouble(data[1].ToString())));
            pointX.Add(new PointPair(zaman, Convert.ToDouble(data[2].ToString())));
            pointY.Add(new PointPair(zaman, Convert.ToDouble(data[3].ToString())));
            pointZ.Add(new PointPair(zaman, Convert.ToDouble(data[4].ToString())));
            pointSicaklik.Add(new PointPair(zaman, Convert.ToDouble(data[5].ToString())));
            pointBasinc.Add(new PointPair(zaman, Convert.ToDouble(data[6].ToString())));
            pointA.Add(new PointPair(zaman, Convert.ToDouble(data[6].ToString())));
            pointB.Add(new PointPair(zaman, Convert.ToDouble(data[3].ToString())));
            pointC.Add(new PointPair(zaman, Convert.ToDouble(data[1].ToString())));

            

            yükseklik.XAxis.Scale.Max = zaman;
            x.XAxis.Scale.Max = zaman;
            y.XAxis.Scale.Max = zaman;
            z.XAxis.Scale.Max = zaman;
            sicaklik.XAxis.Scale.Max = zaman;
            basinc.XAxis.Scale.Max = zaman;
            a.XAxis.Scale.Max = zaman;
            b.XAxis.Scale.Max = zaman;
            c.XAxis.Scale.Max = zaman;

            yükseklik.AxisChange();
            x.AxisChange();
            y.AxisChange();
            z.AxisChange();
            sicaklik.AxisChange();
            basinc.AxisChange();
            a.AxisChange();
            b.AxisChange();
            c.AxisChange();

            zedGraphControl1.Refresh();
            zedGraphControl2.Refresh();
            zedGraphControl3.Refresh();
            zedGraphControl4.Refresh();
            zedGraphControl5.Refresh();
            zedGraphControl6.Refresh();
            zedGraphControl12.Refresh();
            zedGraphControl9.Refresh();
            zedGraphControl7.Refresh();

            excel.Range bölge = (excel.Range)sayfa.Cells[row, 1];
            bölge.Value2 = data[1];
            

            bölge = (excel.Range)sayfa.Cells[row, 2];
            bölge.Value2 = data[2];
           

            bölge = (excel.Range)sayfa.Cells[row, 3];
            bölge.Value2 = data[3];
            

            bölge = (excel.Range)sayfa.Cells[row, 4];
            bölge.Value2 = data[4];
            
            bölge = (excel.Range)sayfa.Cells[row, 5];
            bölge.Value2 = data[5];
            

            bölge = (excel.Range)sayfa.Cells[row, 6];
            bölge.Value2 = data[6];
            

            row++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" && portlar.Text == "")
            {
                MessageBox.Show("port ve baudrate seç");
            }
            else
            {
                serialPort1.PortName = portlar.SelectedItem.ToString();
                serialPort1.BaudRate = int.Parse(comboBox1.SelectedItem.ToString());
                serialPort1.Open();
                serialPort1.DataBits = 8;
                serialPort1.StopBits = System.IO.Ports.StopBits.One;
                serialPort1.Parity = Parity.None;
                serialPort1.Handshake = Handshake.None;
            }
        }

        private void button2_Click(object sender, EventArgs e)//bağlantı kes
        {
            serialPort1.Close();
        }

        private void button3_Click(object sender, EventArgs e)//grafik1
        {
            grafik1.BringToFront();
            grafik1.Focus();
        }

        private void button4_Click_1(object sender, EventArgs e)//grafik2
        {
            grafik2.BringToFront();
            grafik2.Focus();
        }

        private void button5_Click(object sender, EventArgs e)//telemetri verilerini çek
        {
            panel1.BringToFront();
            panel1.Focus();
        }

        private void button6_Click(object sender, EventArgs e)//grafik temizle
        {
            curveYükseklik.Clear();
            curveBasinc.Clear();
            curveSicaklik.Clear();
            curveA.Clear();
            curveB.Clear();
            curveC.Clear();
            curveX.Clear();
            curveY.Clear();
            curveZ.Clear();

            zedGraphControl1.Refresh();
            zedGraphControl2.Refresh();
            zedGraphControl3.Refresh();
            zedGraphControl4.Refresh();
            zedGraphControl5.Refresh();
            zedGraphControl6.Refresh();
            zedGraphControl12.Refresh();
            zedGraphControl9.Refresh();
            zedGraphControl7.Refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string[] veriler2;
            
            veriler2 = new string[6];
            
            string satir = textBox1.Text;
            for(int i = 1; i < 7; i++) 
            {
                excel.Range bölge = (excel.Range)sayfa.Cells[satir, i];
                veriler2[i - 1] = Convert.ToString(bölge.Value2);
                
            }

            dataGridView1.Rows[0].Cells[0].Value =veriler2[0];
            dataGridView1.Rows[0].Cells[1].Value = veriler2[1];
            dataGridView1.Rows[0].Cells[2].Value = veriler2[2];
            dataGridView1.Rows[0].Cells[3].Value = veriler2[3];
            dataGridView1.Rows[0].Cells[4].Value = veriler2[4];
            dataGridView1.Rows[0].Cells[5].Value = veriler2[5];



        }
    }
}

