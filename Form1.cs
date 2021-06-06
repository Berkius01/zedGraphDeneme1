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

namespace zedGraphDeneme1
{
    public partial class Form1 : Form
    {
        GraphPane yükseklik = new GraphPane();
        GraphPane basinc = new GraphPane();
        GraphPane sicaklik = new GraphPane();
        GraphPane x = new GraphPane();
        GraphPane y = new GraphPane();
        GraphPane z = new GraphPane();


        PointPairList pointYükseklik = new PointPairList();
        PointPairList pointBasinc = new PointPairList();
        PointPairList pointSicaklik = new PointPairList();
        PointPairList pointX = new PointPairList();
        PointPairList pointY = new PointPairList();
        PointPairList pointZ = new PointPairList();

        LineItem curveYükseklik;
        LineItem curveBasinc;
        LineItem curveSicaklik;
        LineItem curveX;
        LineItem curveY;
        LineItem curveZ;

        double zaman;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

            yükseklik.XAxis.Scale.Max = zaman;
            x.XAxis.Scale.Max = zaman;
            y.XAxis.Scale.Max = zaman;
            z.XAxis.Scale.Max = zaman;
            sicaklik.XAxis.Scale.Max = zaman;
            basinc.XAxis.Scale.Max = zaman;

            yükseklik.AxisChange();
            x.AxisChange();
            y.AxisChange();
            z.AxisChange();
            sicaklik.AxisChange();
            basinc.AxisChange();

            zedGraphControl1.Refresh();
            zedGraphControl2.Refresh();
            zedGraphControl3.Refresh();
            zedGraphControl4.Refresh();
            zedGraphControl5.Refresh();
            zedGraphControl6.Refresh();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" && portlar.Text == "")
            {
                MessageBox.Show("port ve baudrate seç");
            }
            else {
                serialPort1.PortName = portlar.SelectedItem.ToString();
                serialPort1.BaudRate = int.Parse(comboBox1.SelectedItem.ToString());
                serialPort1.Open();
                serialPort1.DataBits = 8;
                serialPort1.StopBits = System.IO.Ports.StopBits.One;
                serialPort1.Parity = Parity.None;
                serialPort1.Handshake = Handshake.None;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
        }
    }
}
