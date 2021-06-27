
namespace zedGraphDeneme1
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.portlar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl5 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl4 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl6 = new ZedGraph.ZedGraphControl();
            this.grafik1 = new System.Windows.Forms.Panel();
            this.grafik2 = new System.Windows.Forms.Panel();
            this.zedGraphControl7 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl9 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl12 = new ZedGraph.ZedGraphControl();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.grafik1.SuspendLayout();
            this.grafik2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(26, 36);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(438, 319);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(36, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 3;
            // 
            // portlar
            // 
            this.portlar.FormattingEnabled = true;
            this.portlar.Location = new System.Drawing.Point(36, 56);
            this.portlar.Name = "portlar";
            this.portlar.Size = new System.Drawing.Size(121, 24);
            this.portlar.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "br";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 31);
            this.button1.TabIndex = 9;
            this.button1.Text = "bağlan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(36, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 31);
            this.button2.TabIndex = 10;
            this.button2.Text = "bağlantıyı kes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Location = new System.Drawing.Point(488, 36);
            this.zedGraphControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(438, 319);
            this.zedGraphControl2.TabIndex = 12;
            // 
            // zedGraphControl3
            // 
            this.zedGraphControl3.Location = new System.Drawing.Point(488, 373);
            this.zedGraphControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl3.Name = "zedGraphControl3";
            this.zedGraphControl3.ScrollGrace = 0D;
            this.zedGraphControl3.ScrollMaxX = 0D;
            this.zedGraphControl3.ScrollMaxY = 0D;
            this.zedGraphControl3.ScrollMaxY2 = 0D;
            this.zedGraphControl3.ScrollMinX = 0D;
            this.zedGraphControl3.ScrollMinY = 0D;
            this.zedGraphControl3.ScrollMinY2 = 0D;
            this.zedGraphControl3.Size = new System.Drawing.Size(438, 316);
            this.zedGraphControl3.TabIndex = 13;
            // 
            // zedGraphControl5
            // 
            this.zedGraphControl5.Location = new System.Drawing.Point(26, 373);
            this.zedGraphControl5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl5.Name = "zedGraphControl5";
            this.zedGraphControl5.ScrollGrace = 0D;
            this.zedGraphControl5.ScrollMaxX = 0D;
            this.zedGraphControl5.ScrollMaxY = 0D;
            this.zedGraphControl5.ScrollMaxY2 = 0D;
            this.zedGraphControl5.ScrollMinX = 0D;
            this.zedGraphControl5.ScrollMinY = 0D;
            this.zedGraphControl5.ScrollMinY2 = 0D;
            this.zedGraphControl5.Size = new System.Drawing.Size(438, 316);
            this.zedGraphControl5.TabIndex = 14;
            // 
            // zedGraphControl4
            // 
            this.zedGraphControl4.Location = new System.Drawing.Point(948, 373);
            this.zedGraphControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl4.Name = "zedGraphControl4";
            this.zedGraphControl4.ScrollGrace = 0D;
            this.zedGraphControl4.ScrollMaxX = 0D;
            this.zedGraphControl4.ScrollMaxY = 0D;
            this.zedGraphControl4.ScrollMaxY2 = 0D;
            this.zedGraphControl4.ScrollMinX = 0D;
            this.zedGraphControl4.ScrollMinY = 0D;
            this.zedGraphControl4.ScrollMinY2 = 0D;
            this.zedGraphControl4.Size = new System.Drawing.Size(438, 316);
            this.zedGraphControl4.TabIndex = 15;
            // 
            // zedGraphControl6
            // 
            this.zedGraphControl6.Location = new System.Drawing.Point(948, 36);
            this.zedGraphControl6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl6.Name = "zedGraphControl6";
            this.zedGraphControl6.ScrollGrace = 0D;
            this.zedGraphControl6.ScrollMaxX = 0D;
            this.zedGraphControl6.ScrollMaxY = 0D;
            this.zedGraphControl6.ScrollMaxY2 = 0D;
            this.zedGraphControl6.ScrollMinX = 0D;
            this.zedGraphControl6.ScrollMinY = 0D;
            this.zedGraphControl6.ScrollMinY2 = 0D;
            this.zedGraphControl6.Size = new System.Drawing.Size(438, 319);
            this.zedGraphControl6.TabIndex = 16;
            // 
            // grafik1
            // 
            this.grafik1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grafik1.Controls.Add(this.zedGraphControl1);
            this.grafik1.Controls.Add(this.zedGraphControl4);
            this.grafik1.Controls.Add(this.zedGraphControl6);
            this.grafik1.Controls.Add(this.zedGraphControl3);
            this.grafik1.Controls.Add(this.zedGraphControl5);
            this.grafik1.Controls.Add(this.zedGraphControl2);
            this.grafik1.Location = new System.Drawing.Point(18, 49);
            this.grafik1.Name = "grafik1";
            this.grafik1.Size = new System.Drawing.Size(1400, 700);
            this.grafik1.TabIndex = 17;
            // 
            // grafik2
            // 
            this.grafik2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grafik2.Controls.Add(this.zedGraphControl7);
            this.grafik2.Controls.Add(this.zedGraphControl9);
            this.grafik2.Controls.Add(this.zedGraphControl12);
            this.grafik2.Location = new System.Drawing.Point(18, 49);
            this.grafik2.Name = "grafik2";
            this.grafik2.Size = new System.Drawing.Size(1403, 700);
            this.grafik2.TabIndex = 18;
            // 
            // zedGraphControl7
            // 
            this.zedGraphControl7.Location = new System.Drawing.Point(26, 36);
            this.zedGraphControl7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl7.Name = "zedGraphControl7";
            this.zedGraphControl7.ScrollGrace = 0D;
            this.zedGraphControl7.ScrollMaxX = 0D;
            this.zedGraphControl7.ScrollMaxY = 0D;
            this.zedGraphControl7.ScrollMaxY2 = 0D;
            this.zedGraphControl7.ScrollMinX = 0D;
            this.zedGraphControl7.ScrollMinY = 0D;
            this.zedGraphControl7.ScrollMinY2 = 0D;
            this.zedGraphControl7.Size = new System.Drawing.Size(438, 319);
            this.zedGraphControl7.TabIndex = 0;
            // 
            // zedGraphControl9
            // 
            this.zedGraphControl9.Location = new System.Drawing.Point(948, 36);
            this.zedGraphControl9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl9.Name = "zedGraphControl9";
            this.zedGraphControl9.ScrollGrace = 0D;
            this.zedGraphControl9.ScrollMaxX = 0D;
            this.zedGraphControl9.ScrollMaxY = 0D;
            this.zedGraphControl9.ScrollMaxY2 = 0D;
            this.zedGraphControl9.ScrollMinX = 0D;
            this.zedGraphControl9.ScrollMinY = 0D;
            this.zedGraphControl9.ScrollMinY2 = 0D;
            this.zedGraphControl9.Size = new System.Drawing.Size(438, 319);
            this.zedGraphControl9.TabIndex = 16;
            // 
            // zedGraphControl12
            // 
            this.zedGraphControl12.Location = new System.Drawing.Point(488, 36);
            this.zedGraphControl12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl12.Name = "zedGraphControl12";
            this.zedGraphControl12.ScrollGrace = 0D;
            this.zedGraphControl12.ScrollMaxX = 0D;
            this.zedGraphControl12.ScrollMaxY = 0D;
            this.zedGraphControl12.ScrollMaxY2 = 0D;
            this.zedGraphControl12.ScrollMinX = 0D;
            this.zedGraphControl12.ScrollMinY = 0D;
            this.zedGraphControl12.ScrollMinY2 = 0D;
            this.zedGraphControl12.Size = new System.Drawing.Size(438, 319);
            this.zedGraphControl12.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(18, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 31);
            this.button3.TabIndex = 18;
            this.button3.Text = "grafik1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(134, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 31);
            this.button4.TabIndex = 19;
            this.button4.Text = "grafik2";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(248, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 31);
            this.button5.TabIndex = 20;
            this.button5.Text = "telemtri tablosu";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.portlar);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(1466, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 239);
            this.panel2.TabIndex = 21;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(36, 191);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(121, 31);
            this.button6.TabIndex = 11;
            this.button6.Text = "grafik temizle";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1421, 704);
            this.panel1.TabIndex = 22;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(32, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1187, 233);
            this.dataGridView1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(438, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 23;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(535, 16);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(127, 23);
            this.button7.TabIndex = 24;
            this.button7.Text = "telemetri verisi al";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1753, 1005);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.grafik1);
            this.Controls.Add(this.grafik2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grafik1.ResumeLayout(false);
            this.grafik2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox portlar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private ZedGraph.ZedGraphControl zedGraphControl3;
        private ZedGraph.ZedGraphControl zedGraphControl5;
        private ZedGraph.ZedGraphControl zedGraphControl4;
        private ZedGraph.ZedGraphControl zedGraphControl6;
        private System.Windows.Forms.Panel grafik1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel grafik2;
        private ZedGraph.ZedGraphControl zedGraphControl7;
        private ZedGraph.ZedGraphControl zedGraphControl9;
        private ZedGraph.ZedGraphControl zedGraphControl12;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

