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

using System.Net;
using System.Net.Sockets;

using Microsoft.Office.Interop.Excel;
using excel = Microsoft.Office.Interop.Excel;



namespace zedGraphDeneme1
{
    
    public partial class Form1 : Form
    {

        string takimNo;
        string paketNo;
        string zaman0;
        string gps1;
        string gps2;
        string gps3;
        string statü;
        string video;
        //grafik zımbırtıları
        GraphPane yükseklik = new GraphPane();
        GraphPane basinc = new GraphPane();
        GraphPane sicaklik = new GraphPane();
        GraphPane inisHizi = new GraphPane();
        GraphPane pilGerilimi = new GraphPane();
        GraphPane pitch = new GraphPane();
        GraphPane roll = new GraphPane();
        GraphPane yaw = new GraphPane();
        GraphPane Dönüs = new GraphPane();


        PointPairList pointYükseklik = new PointPairList();
        PointPairList pointBasinc = new PointPairList();
        PointPairList pointSicaklik = new PointPairList();
        PointPairList pointInisHizi = new PointPairList();
        PointPairList pointPilGerilimi = new PointPairList();
        PointPairList pointPitch = new PointPairList();
        PointPairList pointRoll = new PointPairList();
        PointPairList pointYaw = new PointPairList();
        PointPairList pointDönüs = new PointPairList();

        LineItem curveYükseklik;
        LineItem curveBasinc;
        LineItem curveSicaklik;
        LineItem curveInisHizi;
        LineItem curvePilGerilimi;
        LineItem curvePitch;
        LineItem curveRoll;
        LineItem curveYaw;
        LineItem curveDönüs;
        
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

        //internet bağlantılar
        

        private void Form1_Load(object sender, EventArgs e)
        {

            

            uygulama = new excel.Application();
            kitap = uygulama.Workbooks.Add(Missing);
            sayfa = (excel.Worksheet)uygulama.Worksheets.get_Item(1);
            range = sayfa.UsedRange;
            sayfa = (excel.Worksheet)uygulama.ActiveSheet;
            uygulama.Visible = true;

            excel.Range bölge = (excel.Range)sayfa.Cells[1, 1];
            bölge.Value2 = "takımNo";

            excel.Range bölge1 = (excel.Range)sayfa.Cells[1, 2];
            bölge1.Value2 = "paketNo";

            excel.Range bölge2 = (excel.Range)sayfa.Cells[1, 3];
            bölge2.Value2 = "göndermeZamanı";

            excel.Range bölge3 = (excel.Range)sayfa.Cells[1, 4];
            bölge3.Value2 = "basınç";

            excel.Range bölge4 = (excel.Range)sayfa.Cells[1, 5];
            bölge4.Value2 = "yükseklik";

            excel.Range bölge5 = (excel.Range)sayfa.Cells[1, 6];
            bölge5.Value2 = "inisHizi";

            excel.Range bölge6 = (excel.Range)sayfa.Cells[1, 7];
            bölge6.Value2 = "sicaklik";

            excel.Range bölge7 = (excel.Range)sayfa.Cells[1, 8];
            bölge7.Value2 = "pilGerilimi";

            excel.Range bölge8 = (excel.Range)sayfa.Cells[1, 9];
            bölge8.Value2 = "GPS(latitude)";

            excel.Range bölge9 = (excel.Range)sayfa.Cells[1, 10];
            bölge9.Value2 = "GPS(longtitude)";

            excel.Range bölge10 = (excel.Range)sayfa.Cells[1, 11];
            bölge10.Value2 = "GPS(altitude)";

            excel.Range bölge11 = (excel.Range)sayfa.Cells[1, 12];
            bölge11.Value2 = "uyduStatüsü";

            excel.Range bölge12 = (excel.Range)sayfa.Cells[1, 13];
            bölge12.Value2 = "pitch";

            excel.Range bölge13 = (excel.Range)sayfa.Cells[1, 14];
            bölge13.Value2 = "roll";

            excel.Range bölge14 = (excel.Range)sayfa.Cells[1, 15];
            bölge14.Value2 = "yaw";

            excel.Range bölge15 = (excel.Range)sayfa.Cells[1, 16];
            bölge15.Value2 = "donüsSayisi";

            excel.Range bölge16 = (excel.Range)sayfa.Cells[1, 17];
            bölge16.Value2 = "videoAktarim";


            dataGridView1.Columns.Add("takimNo", "takimNo");
            dataGridView1.Columns.Add("paketNo", "paketNo");
            dataGridView1.Columns.Add("göndermeZamani", "göndermeZamani");
            dataGridView1.Columns.Add("basinc", "basinc");
            dataGridView1.Columns.Add("yükseklik", "yükseklik");
            dataGridView1.Columns.Add("hiz", "hiz");
            dataGridView1.Columns.Add("sicaklik", "sicaklik");
            dataGridView1.Columns.Add("pilGerilimi", "pilGerilimi");
            dataGridView1.Columns.Add("GPS(latitude)", "GPS(latitude)");
            dataGridView1.Columns.Add("GPS(longtitude)", "GPS(longtitude)");
            dataGridView1.Columns.Add("GPS(altitude)", "GPS(altitude)");
            dataGridView1.Columns.Add("uyduStatüsü", "uyduStatüsü");
            dataGridView1.Columns.Add("pitch", "pitch");
            dataGridView1.Columns.Add("roll", "roll");
            dataGridView1.Columns.Add("yaw", "yaw");
            dataGridView1.Columns.Add("donüsSayisi", "donusSayisi");
            dataGridView1.Columns.Add("video", "video");


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

            basinc = zedGraphControl1.GraphPane;
            basinc.Title.Text = "basınç - zaman grafiği";
            basinc.XAxis.Title.Text = "t(s)";
            basinc.YAxis.Title.Text = "Pascal";
            basinc.YAxis.Scale.Min = 0;
            curveBasinc = basinc.AddCurve(null, pointBasinc, Color.Red, SymbolType.None);
            curveBasinc.Line.Width = 1;
            //basınç

            yükseklik = zedGraphControl2.GraphPane;
            yükseklik.Title.Text = "yükseklik - zaman grafiği";
            yükseklik.XAxis.Title.Text = "t(s)";
            yükseklik.YAxis.Title.Text = "Yükseklik";
            yükseklik.YAxis.Scale.Min = 0;
            curveYükseklik = yükseklik.AddCurve(null, pointYükseklik, Color.Red, SymbolType.None);
            curveYükseklik.Line.Width = 1;
            // yükseklik için

            pilGerilimi = zedGraphControl3.GraphPane;
            pilGerilimi.Title.Text = "gerilim - zaman grafiği";
            pilGerilimi.XAxis.Title.Text = "t(s)";
            pilGerilimi.YAxis.Title.Text = "Voltaj";
            pilGerilimi.YAxis.Scale.Min = 0;
            curvePilGerilimi = pilGerilimi.AddCurve(null, pointPilGerilimi, Color.Red, SymbolType.None);
            curvePilGerilimi.Line.Width = 1;
            //gerilim için

            Dönüs = zedGraphControl4.GraphPane;
            Dönüs.Title.Text = "dönüs - zaman grafiği";
            Dönüs.XAxis.Title.Text = "t(s)";
            Dönüs.YAxis.Title.Text = "Dönüs Sayisi";
            Dönüs.YAxis.Scale.Min = 0;
            curveDönüs = Dönüs.AddCurve(null, pointDönüs, Color.Red, SymbolType.None);
            curveDönüs.Line.Width = 1;
            // dönüş için

            sicaklik = zedGraphControl5.GraphPane;
            sicaklik.Title.Text = "sıcaklık - zaman grafiği";
            sicaklik.XAxis.Title.Text = "t(s)";
            sicaklik.YAxis.Title.Text = "Celcius";
            sicaklik.YAxis.Scale.Min = 0;
            curveSicaklik = sicaklik.AddCurve(null, pointSicaklik, Color.Red, SymbolType.None);
            curveSicaklik.Line.Width = 1;
            //sıcaklık

   
            inisHizi = zedGraphControl6.GraphPane;
            inisHizi.Title.Text = "hiz - zaman grafiği";
            inisHizi.XAxis.Title.Text = "t(s)";
            inisHizi.YAxis.Title.Text = "Metre";
            inisHizi.YAxis.Scale.Min = 0;
            curveInisHizi = inisHizi.AddCurve(null, pointInisHizi, Color.Red, SymbolType.None);
            curveInisHizi.Line.Width = 1;
            //hiz

            pitch = zedGraphControl7.GraphPane;
            pitch.Title.Text = "pitch - zaman grafiği";
            pitch.XAxis.Title.Text = "t(s)";
            pitch.YAxis.Title.Text = "açı";
            pitch.YAxis.Scale.Min = 0;
            curvePitch = pitch.AddCurve(null, pointPitch, Color.Red, SymbolType.None);
            curvePitch.Line.Width = 1;
            //pitch

            yaw = zedGraphControl9.GraphPane;
            yaw.Title.Text = "yaw - zaman grafiği";
            yaw.XAxis.Title.Text = "t(s)";
            yaw.YAxis.Title.Text = "açı";
            yaw.YAxis.Scale.Min = 0;
            curveYaw = yaw.AddCurve(null, pointYaw, Color.Red, SymbolType.None);
            curveYaw.Line.Width = 1;
            //yaw

            roll = zedGraphControl12.GraphPane;
            roll.Title.Text = "roll - zaman grafiği";
            roll.XAxis.Title.Text = "t(s)";
            roll.YAxis.Title.Text = "açı";
            roll.YAxis.Scale.Min = 0;
            curveRoll = roll.AddCurve(null, pointRoll, Color.Red, SymbolType.None);
            curveRoll.Line.Width = 1;
            //roll

        }
        

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            

            string[] data = serialPort1.ReadLine().Split(',');

            
            zaman += 0.05;
            takimNo = data[0];
            paketNo = data[1];
            textBox4.Text = paketNo;
            zaman0 = data[2];
            textBox7.Text = zaman0;
            pointBasinc.Add(new PointPair(zaman, Convert.ToDouble(data[3].ToString())));
            pointYükseklik.Add(new PointPair(zaman, Convert.ToDouble(data[4].ToString())));
            pointInisHizi.Add(new PointPair(zaman, Convert.ToDouble(data[5].ToString())));
            pointSicaklik.Add(new PointPair(zaman, Convert.ToDouble(data[6].ToString())));
            pointPilGerilimi.Add(new PointPair(zaman, Convert.ToDouble(data[7].ToString())));
            gps1 = data[8];
            textBox2.Text = gps1;

            gps2 = data[9];
            textBox3.Text = gps2;

            gps3 = data[10];
            textBox5.Text = gps3;
            statü = data[11];
            textBox6.Text = statü;
            pointPitch.Add(new PointPair(zaman, Convert.ToDouble(data[12].ToString())));
            pointYaw.Add(new PointPair(zaman, Convert.ToDouble(data[13].ToString())));
            pointRoll.Add(new PointPair(zaman, Convert.ToDouble(data[14].ToString())));
            pointDönüs.Add(new PointPair(zaman, Convert.ToDouble(data[15].ToString())));
            video = data[16];
           
         

            

            yükseklik.XAxis.Scale.Max = zaman;
            basinc.XAxis.Scale.Max = zaman;
            inisHizi.XAxis.Scale.Max = zaman;
            sicaklik.XAxis.Scale.Max = zaman;
            pilGerilimi.XAxis.Scale.Max = zaman;
            pitch.XAxis.Scale.Max = zaman;
            yaw.XAxis.Scale.Max = zaman;
            roll.XAxis.Scale.Max = zaman;
            Dönüs.XAxis.Scale.Max = zaman;

            yükseklik.AxisChange();
            inisHizi.AxisChange();
            roll.AxisChange();
            yaw.AxisChange();
            sicaklik.AxisChange();
            basinc.AxisChange();
            pitch.AxisChange();
            Dönüs.AxisChange();
            pilGerilimi.AxisChange();

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
            bölge.Value2 = data[0];
            

            bölge = (excel.Range)sayfa.Cells[row, 2];
            bölge.Value2 = data[1];
           

            bölge = (excel.Range)sayfa.Cells[row, 3];
            bölge.Value2 = data[2];
            
            bölge = (excel.Range)sayfa.Cells[row, 4];
            bölge.Value2 = data[3];
            
            bölge = (excel.Range)sayfa.Cells[row, 5];
            bölge.Value2 = data[4];
            
            bölge = (excel.Range)sayfa.Cells[row, 6];
            bölge.Value2 = data[5];

            bölge = (excel.Range)sayfa.Cells[row, 7];
            bölge.Value2 = data[6];

            bölge = (excel.Range)sayfa.Cells[row, 8];
            bölge.Value2 = data[7];

            bölge = (excel.Range)sayfa.Cells[row, 9];
            bölge.Value2 = data[8];

            bölge = (excel.Range)sayfa.Cells[row, 10];
            bölge.Value2 = data[9];

            bölge = (excel.Range)sayfa.Cells[row, 11];
            bölge.Value2 = data[10];

            bölge = (excel.Range)sayfa.Cells[row, 12];
            bölge.Value2 = data[11];

            bölge = (excel.Range)sayfa.Cells[row, 13];
            bölge.Value2 = data[12];

            bölge = (excel.Range)sayfa.Cells[row, 14];
            bölge.Value2 = data[13];

            bölge = (excel.Range)sayfa.Cells[row, 15];
            bölge.Value2 = data[14];

            bölge = (excel.Range)sayfa.Cells[row, 16];
            bölge.Value2 = data[15];

            bölge = (excel.Range)sayfa.Cells[row, 17];
            bölge.Value2 = data[16];



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
            curveInisHizi.Clear();
            curvePilGerilimi.Clear();
            curvePitch.Clear();
            curveRoll.Clear();
            curveYaw.Clear();
            curveDönüs.Clear();

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
            
            veriler2 = new string[17];
            
            string satir = textBox1.Text;
            for(int i = 1; i < 18; i++) 
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
            dataGridView1.Rows[0].Cells[6].Value = veriler2[6];
            dataGridView1.Rows[0].Cells[7].Value = veriler2[7];
            dataGridView1.Rows[0].Cells[8].Value = veriler2[8];
            dataGridView1.Rows[0].Cells[9].Value = veriler2[9];
            dataGridView1.Rows[0].Cells[10].Value = veriler2[10];
            dataGridView1.Rows[0].Cells[11].Value = veriler2[11];
            dataGridView1.Rows[0].Cells[12].Value = veriler2[12];
            dataGridView1.Rows[0].Cells[13].Value = veriler2[13];
            dataGridView1.Rows[0].Cells[14].Value = veriler2[14];
            dataGridView1.Rows[0].Cells[15].Value = veriler2[15];
            dataGridView1.Rows[0].Cells[16].Value = veriler2[16];

        }
        //bool kent = true;
        private void Button9_Click(object sender, EventArgs e)
        {

            StartServer();
            
        }



        private void StartServer()
        {
            IPAddress ipAddress;
            IPEndPoint localEndPoint;
            Socket listener;
            ipAddress = IPAddress.Parse("192.168.0.10");
            localEndPoint = new IPEndPoint(ipAddress, 5000);



            // Create a Socket that will use Tcp protocol      
            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            // A Socket must be associated with an endpoint using the Bind method  

            //bağlantı ıvır zıvırları

            listener.Bind(localEndPoint);
            listener.Listen(2);
            Console.WriteLine("Waiting for a connection...");
            Socket handler = listener.Accept();
            Console.WriteLine("Waiting for a connection...");
            while (true)
            {

                // Specify how many requests a Socket can listen before it gives Server busy response.  
                // We will listen 10 requests at a time  

                // Incoming data from the client.    
                string data0 = null;
                byte[] bytes = new byte[200000];

                Console.WriteLine("Waiting for a connection...");
                //bytes = new byte[2000000];
                int bytesRec = handler.Receive(bytes);
                data0 += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (data0.IndexOf("<EOF>") > -1)
                {
                    Console.WriteLine("if içinde");
                }


                Console.WriteLine("Text received : {0}", data0);
                string[] data = data0.Split(',');


                zaman += 0.05;
                takimNo = data[0];
                paketNo = data[1];
                textBox4.Text = paketNo;
                zaman0 = data[2];
                textBox7.Text = zaman0;
                pointBasinc.Add(new PointPair(zaman, Convert.ToDouble(data[3].ToString())));
                pointYükseklik.Add(new PointPair(zaman, Convert.ToDouble(data[4].ToString())));
                pointInisHizi.Add(new PointPair(zaman, Convert.ToDouble(data[5].ToString())));
                pointSicaklik.Add(new PointPair(zaman, Convert.ToDouble(data[6].ToString())));
                pointPilGerilimi.Add(new PointPair(zaman, Convert.ToDouble(data[7].ToString())));
                gps1 = data[8];
                textBox2.Text = gps1;

                gps2 = data[9];
                textBox3.Text = gps2;

                gps3 = data[10];
                textBox5.Text = gps3;
                statü = data[11];
                textBox6.Text = statü;
                pointPitch.Add(new PointPair(zaman, Convert.ToDouble(data[12].ToString())));
                pointYaw.Add(new PointPair(zaman, Convert.ToDouble(data[13].ToString())));
                pointRoll.Add(new PointPair(zaman, Convert.ToDouble(data[14].ToString())));
                pointDönüs.Add(new PointPair(zaman, Convert.ToDouble(data[15].ToString())));
                video = data[16];





                yükseklik.XAxis.Scale.Max = zaman;
                basinc.XAxis.Scale.Max = zaman;
                inisHizi.XAxis.Scale.Max = zaman;
                sicaklik.XAxis.Scale.Max = zaman;
                pilGerilimi.XAxis.Scale.Max = zaman;
                pitch.XAxis.Scale.Max = zaman;
                yaw.XAxis.Scale.Max = zaman;
                roll.XAxis.Scale.Max = zaman;
                Dönüs.XAxis.Scale.Max = zaman;

                yükseklik.AxisChange();
                inisHizi.AxisChange();
                roll.AxisChange();
                yaw.AxisChange();
                sicaklik.AxisChange();
                basinc.AxisChange();
                pitch.AxisChange();
                Dönüs.AxisChange();
                pilGerilimi.AxisChange();

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
                bölge.Value2 = data[0];


                bölge = (excel.Range)sayfa.Cells[row, 2];
                bölge.Value2 = data[1];


                bölge = (excel.Range)sayfa.Cells[row, 3];
                bölge.Value2 = data[2];

                bölge = (excel.Range)sayfa.Cells[row, 4];
                bölge.Value2 = data[3];

                bölge = (excel.Range)sayfa.Cells[row, 5];
                bölge.Value2 = data[4];

                bölge = (excel.Range)sayfa.Cells[row, 6];
                bölge.Value2 = data[5];

                bölge = (excel.Range)sayfa.Cells[row, 7];
                bölge.Value2 = data[6];

                bölge = (excel.Range)sayfa.Cells[row, 8];
                bölge.Value2 = data[7];

                bölge = (excel.Range)sayfa.Cells[row, 9];
                bölge.Value2 = data[8];

                bölge = (excel.Range)sayfa.Cells[row, 10];
                bölge.Value2 = data[9];

                bölge = (excel.Range)sayfa.Cells[row, 11];
                bölge.Value2 = data[10];

                bölge = (excel.Range)sayfa.Cells[row, 12];
                bölge.Value2 = data[11];

                bölge = (excel.Range)sayfa.Cells[row, 13];
                bölge.Value2 = data[12];

                bölge = (excel.Range)sayfa.Cells[row, 14];
                bölge.Value2 = data[13];

                bölge = (excel.Range)sayfa.Cells[row, 15];
                bölge.Value2 = data[14];

                bölge = (excel.Range)sayfa.Cells[row, 16];
                bölge.Value2 = data[15];

                bölge = (excel.Range)sayfa.Cells[row, 17];
                bölge.Value2 = data[16];



                row++;
                byte[] msg = Encoding.ASCII.GetBytes(data0);
                handler.Send(msg);
                //handler.Shutdown(SocketShutdown.Both);
                //handler.Close();


                Console.WriteLine("\n Press any key to continue...");
            }

        }
    }
}

