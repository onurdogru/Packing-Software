namespace Acron_Paketleme
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.timerAdmin = new System.Windows.Forms.Timer(this.components);
            this.btnAyar = new System.Windows.Forms.Button();
            this.projectNameTxt = new System.Windows.Forms.TextBox();
            this.rtbConsoleOther = new System.Windows.Forms.RichTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.tbBarcodeLast = new System.Windows.Forms.TextBox();
            this.tbBarcodeCurrent = new System.Windows.Forms.TextBox();
            this.lblBarcodeLast = new System.Windows.Forms.Label();
            this.lblBarcodeCurrent = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPacketEnd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCardCounter = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sonucCard = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.packetNumber = new System.Windows.Forms.TextBox();
            this.modelName = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.oparatorName1 = new System.Windows.Forms.ComboBox();
            this.oparatorName2 = new System.Windows.Forms.ComboBox();
            this.partiNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // timerAdmin
            // 
            this.timerAdmin.Tick += new System.EventHandler(this.timerAdmin_Tick);
            // 
            // btnAyar
            // 
            this.btnAyar.BackColor = System.Drawing.Color.Red;
            this.btnAyar.Font = new System.Drawing.Font("Tahoma", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAyar.Location = new System.Drawing.Point(7, 629);
            this.btnAyar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAyar.Name = "btnAyar";
            this.btnAyar.Size = new System.Drawing.Size(217, 69);
            this.btnAyar.TabIndex = 47;
            this.btnAyar.Text = "AYARLAR";
            this.btnAyar.UseVisualStyleBackColor = false;
            this.btnAyar.Click += new System.EventHandler(this.btnAyar_Click);
            // 
            // projectNameTxt
            // 
            this.projectNameTxt.BackColor = System.Drawing.Color.DarkGray;
            this.projectNameTxt.Enabled = false;
            this.projectNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.projectNameTxt.Location = new System.Drawing.Point(6, 93);
            this.projectNameTxt.Name = "projectNameTxt";
            this.projectNameTxt.Size = new System.Drawing.Size(1240, 40);
            this.projectNameTxt.TabIndex = 58;
            this.projectNameTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rtbConsoleOther
            // 
            this.rtbConsoleOther.BackColor = System.Drawing.SystemColors.Info;
            this.rtbConsoleOther.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbConsoleOther.ForeColor = System.Drawing.Color.White;
            this.rtbConsoleOther.Location = new System.Drawing.Point(1257, 7);
            this.rtbConsoleOther.Margin = new System.Windows.Forms.Padding(0);
            this.rtbConsoleOther.Name = "rtbConsoleOther";
            this.rtbConsoleOther.Size = new System.Drawing.Size(127, 688);
            this.rtbConsoleOther.TabIndex = 83;
            this.rtbConsoleOther.TabStop = false;
            this.rtbConsoleOther.Text = "";
            this.rtbConsoleOther.TextChanged += new System.EventHandler(this.rtbConsoleOther_TextChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Acron_Paketleme.Properties.Resources.alpNEXT_Logo;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(7, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1240, 82);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 57;
            this.pictureBox2.TabStop = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.DarkGray;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label27.Location = new System.Drawing.Point(8, 214);
            this.label27.Margin = new System.Windows.Forms.Padding(0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(93, 25);
            this.label27.TabIndex = 106;
            this.label27.Text = "Barkod:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label28.Location = new System.Drawing.Point(9, 160);
            this.label28.Margin = new System.Windows.Forms.Padding(0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(68, 25);
            this.label28.TabIndex = 105;
            this.label28.Text = "Giriş:";
            // 
            // tbBarcodeLast
            // 
            this.tbBarcodeLast.BackColor = System.Drawing.Color.White;
            this.tbBarcodeLast.Enabled = false;
            this.tbBarcodeLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbBarcodeLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbBarcodeLast.Location = new System.Drawing.Point(101, 199);
            this.tbBarcodeLast.Margin = new System.Windows.Forms.Padding(0);
            this.tbBarcodeLast.Name = "tbBarcodeLast";
            this.tbBarcodeLast.Size = new System.Drawing.Size(1146, 40);
            this.tbBarcodeLast.TabIndex = 104;
            // 
            // tbBarcodeCurrent
            // 
            this.tbBarcodeCurrent.BackColor = System.Drawing.Color.White;
            this.tbBarcodeCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbBarcodeCurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbBarcodeCurrent.Location = new System.Drawing.Point(100, 142);
            this.tbBarcodeCurrent.Margin = new System.Windows.Forms.Padding(0);
            this.tbBarcodeCurrent.Name = "tbBarcodeCurrent";
            this.tbBarcodeCurrent.Size = new System.Drawing.Size(1147, 40);
            this.tbBarcodeCurrent.TabIndex = 103;
            this.tbBarcodeCurrent.TextChanged += new System.EventHandler(this.tbBarcodeCurrent_TextChanged);
            // 
            // lblBarcodeLast
            // 
            this.lblBarcodeLast.AutoSize = true;
            this.lblBarcodeLast.BackColor = System.Drawing.Color.DarkGray;
            this.lblBarcodeLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBarcodeLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblBarcodeLast.Location = new System.Drawing.Point(8, 189);
            this.lblBarcodeLast.Margin = new System.Windows.Forms.Padding(0);
            this.lblBarcodeLast.Name = "lblBarcodeLast";
            this.lblBarcodeLast.Size = new System.Drawing.Size(60, 25);
            this.lblBarcodeLast.TabIndex = 101;
            this.lblBarcodeLast.Text = "Son ";
            // 
            // lblBarcodeCurrent
            // 
            this.lblBarcodeCurrent.AutoSize = true;
            this.lblBarcodeCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBarcodeCurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblBarcodeCurrent.Location = new System.Drawing.Point(5, 135);
            this.lblBarcodeCurrent.Margin = new System.Windows.Forms.Padding(0);
            this.lblBarcodeCurrent.Name = "lblBarcodeCurrent";
            this.lblBarcodeCurrent.Size = new System.Drawing.Size(86, 25);
            this.lblBarcodeCurrent.TabIndex = 102;
            this.lblBarcodeCurrent.Text = "Barkod";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(1181, -1);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(66, 82);
            this.btnExit.TabIndex = 107;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPacketEnd
            // 
            this.btnPacketEnd.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPacketEnd.ForeColor = System.Drawing.Color.Black;
            this.btnPacketEnd.Location = new System.Drawing.Point(797, 244);
            this.btnPacketEnd.Name = "btnPacketEnd";
            this.btnPacketEnd.Size = new System.Drawing.Size(449, 46);
            this.btnPacketEnd.TabIndex = 114;
            this.btnPacketEnd.Text = "Paketi Sonlandır";
            this.btnPacketEnd.UseVisualStyleBackColor = true;
            this.btnPacketEnd.Click += new System.EventHandler(this.btnPacketEnd_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(7, 337);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1240, 285);
            this.panel1.TabIndex = 724;
            // 
            // lblCardCounter
            // 
            this.lblCardCounter.AutoSize = true;
            this.lblCardCounter.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCardCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblCardCounter.Location = new System.Drawing.Point(1174, 293);
            this.lblCardCounter.Margin = new System.Windows.Forms.Padding(0);
            this.lblCardCounter.Name = "lblCardCounter";
            this.lblCardCounter.Size = new System.Drawing.Size(72, 33);
            this.lblCardCounter.TabIndex = 726;
            this.lblCardCounter.Text = "BOŞ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label4.Location = new System.Drawing.Point(791, 293);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(374, 33);
            this.label4.TabIndex = 725;
            this.label4.Text = "PAKETTEKİ KART SAYISI :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label1.Location = new System.Drawing.Point(937, 626);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 29);
            this.label1.TabIndex = 731;
            this.label1.Text = "G.ADI : ";
            // 
            // sonucCard
            // 
            this.sonucCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sonucCard.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sonucCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.sonucCard.Location = new System.Drawing.Point(10, 0);
            this.sonucCard.Margin = new System.Windows.Forms.Padding(0);
            this.sonucCard.Name = "sonucCard";
            this.sonucCard.Size = new System.Drawing.Size(660, 49);
            this.sonucCard.TabIndex = 733;
            this.sonucCard.Text = "Paketleme İstasyonuna Kart Eklemeye Başlayabilirsiniz";
            this.sonucCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.558074F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 98.44193F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Controls.Add(this.sonucCard, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(231, 639);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(706, 49);
            this.tableLayoutPanel1.TabIndex = 733;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label5.Location = new System.Drawing.Point(937, 666);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 29);
            this.label5.TabIndex = 734;
            this.label5.Text = "T.ADI : ";
            // 
            // packetNumber
            // 
            this.packetNumber.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.packetNumber.Location = new System.Drawing.Point(246, 293);
            this.packetNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.packetNumber.Name = "packetNumber";
            this.packetNumber.Size = new System.Drawing.Size(65, 36);
            this.packetNumber.TabIndex = 739;
            this.packetNumber.TextChanged += new System.EventHandler(this.packetNumber_TextChanged);
            // 
            // modelName
            // 
            this.modelName.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.modelName.FormattingEnabled = true;
            this.modelName.Items.AddRange(new object[] {
            "0167000186-MIND 180-180-F/145-210-G06-B06",
            "0167000187-MIND 180-180-F/180-180-F-G06-B06",
            "0167000188-MIND 3ZONE 180-145_210-G06-B06",
            "0167000189-MIND 180-145/145-180-G06-B06",
            "0167000191-MIND BASE MODEL-G06-B06",
            "0167000192-MIND 180-180/145-210-G06-B06",
            "0167000193-MIND 180-145/210 3 ZONE-G06-B06",
            "0167000194-MIND 145-210/180-180-G06-B06",
            "0167000196-MIND 145-210/180/280 3ZONE DUO-G06-B06",
            "0167000197-MIND 180-180/145-210-I-G06-B06",
            "0167000204-MIND 3ZONES_320_DUO-G06-B06",
            "0167000205-MIND 3ZONES_320_DUO-G06-B06",
            "0167260344-MIND 180-180/145-210-G06-B07",
            "0167260361-MIND Alternatif 180-180-F/145-210-G06-B08",
            "0167260362-MIND Alternatif 180-180-F/180-180-F/-G06-B08",
            "0167260364-MIND Alternatif 180-145/210-G06-B08",
            "0167260365-MIND Alternatif 145-180/180-145-G06-B08",
            "0167260366-MIND Alternatif 145-210/180-180F/-G06-B08",
            "0167260368-MIND Alternatif 145-210/210 DUO-G06-B08",
            "0167260370-MIND Alternatif 180-180F/320 DUO-G06-B08",
            "0167260371-MIND Alternatif 180-145/320 DUO- G06-B08",
            "0167260326-REGAIN 180-180/145-210-G06-B07",
            "0167260011-ARTOUCH2 AK-G06-B02 ",
            "0167260012-ARTOUCH2 AK WITH TIMER SIMPLE-G06-B02",
            "0167260013-ARTOUCH2 AK NO TIMER SIMPLE-G06-B02",
            "0167260014-ARTOUCH2 AK NO TIMER SIMPLE KL-G06-B02",
            "0167100153-RUBY MAINBOARD TIP2-G03-B01",
            "0167732014-ROB ANAKART G06-B04(YAZILIMLI)",
            "0167732020-ROB ANAKART G06-B04(YAZILIMLI)",
            "0267480288-FRODO MAIN BOARD G03-D01"});
            this.modelName.Location = new System.Drawing.Point(246, 248);
            this.modelName.Name = "modelName";
            this.modelName.Size = new System.Drawing.Size(531, 37);
            this.modelName.TabIndex = 738;
            this.modelName.SelectedIndexChanged += new System.EventHandler(this.modelName_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(81, 293);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(155, 33);
            this.label22.TabIndex = 737;
            this.label22.Text = "Koli Adeti:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 33);
            this.label6.TabIndex = 736;
            this.label6.Text = "Card-Model No:";
            // 
            // oparatorName1
            // 
            this.oparatorName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.oparatorName1.FormattingEnabled = true;
            this.oparatorName1.Location = new System.Drawing.Point(1032, 624);
            this.oparatorName1.Name = "oparatorName1";
            this.oparatorName1.Size = new System.Drawing.Size(215, 37);
            this.oparatorName1.TabIndex = 740;
            // 
            // oparatorName2
            // 
            this.oparatorName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.oparatorName2.FormattingEnabled = true;
            this.oparatorName2.Location = new System.Drawing.Point(1032, 664);
            this.oparatorName2.Name = "oparatorName2";
            this.oparatorName2.Size = new System.Drawing.Size(215, 37);
            this.oparatorName2.TabIndex = 741;
            // 
            // partiNo
            // 
            this.partiNo.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.partiNo.Location = new System.Drawing.Point(555, 293);
            this.partiNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.partiNo.Name = "partiNo";
            this.partiNo.Size = new System.Drawing.Size(222, 36);
            this.partiNo.TabIndex = 742;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(416, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 33);
            this.label2.TabIndex = 743;
            this.label2.Text = "Parti No:";
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(7, 7);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(23, 10);
            this.mediaPlayer.TabIndex = 744;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1388, 703);
            this.Controls.Add(this.mediaPlayer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.partiNo);
            this.Controls.Add(this.oparatorName2);
            this.Controls.Add(this.oparatorName1);
            this.Controls.Add(this.packetNumber);
            this.Controls.Add(this.modelName);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCardCounter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPacketEnd);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.tbBarcodeLast);
            this.Controls.Add(this.tbBarcodeCurrent);
            this.Controls.Add(this.lblBarcodeLast);
            this.Controls.Add(this.lblBarcodeCurrent);
            this.Controls.Add(this.rtbConsoleOther);
            this.Controls.Add(this.projectNameTxt);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnAyar);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ACRON PAKETLEME";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerAdmin;
        private System.Windows.Forms.Button btnAyar;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.TextBox projectNameTxt;
        private System.Windows.Forms.RichTextBox rtbConsoleOther;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        public System.Windows.Forms.TextBox tbBarcodeLast;
        public System.Windows.Forms.TextBox tbBarcodeCurrent;
        private System.Windows.Forms.Label lblBarcodeLast;
        private System.Windows.Forms.Label lblBarcodeCurrent;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPacketEnd;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCardCounter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sonucCard;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox packetNumber;
        private System.Windows.Forms.ComboBox modelName;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox oparatorName1;
        private System.Windows.Forms.ComboBox oparatorName2;
        private System.Windows.Forms.TextBox partiNo;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
    }
}

