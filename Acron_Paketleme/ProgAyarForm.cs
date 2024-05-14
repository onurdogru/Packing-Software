// Decompiled with JetBrains decompiler
// Type: EsdTurnikesi.AyarForm
// Assembly: EsdTurnikesi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C8099926-BBEB-495E-ADF6-36B4F5F75BE8
// Assembly location: C:\Users\serkan.baki\Desktop\esd-rar\ESD\Release\EsdTurnikesi.exe

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Text;


namespace Acron_Paketleme
{
    public class ProgAyarForm : Form
    {
        public FormMain MainFrm;
        private IContainer components;
        private Button btnKaydet;
        private GroupBox groupBox3;
        private Label label220;
        private ComboBox printerName;
        private Button btnOkuIni;
        private Label label62;
        private Button btnIDsec;
        private Button btnKaydetIni;
        public TextBox txtINIdosya;
        private TextBox projectName;
        private Label label29;
        private GroupBox groupBox6;
        private CheckBox sifreChange;
        private Label label90;
        private TextBox txtAdminSifre;
        private TextBox txtKaliteSifre;
        private Label label91;
        private TextBox txtTimerAdmin;
        private Label label92;
        private Label label93;
        private GroupBox groupBox7;
        private ColorDialog colorDialog1;

        
        private TextBox printerPos;
        private Label label1;
        private GroupBox groupBox1;
        private Label label4;
        private Label label5;
        private Button tAddBtn;
        private Button gAddBtn;
        public TextBox tName;
        private TextBox gName;
        private Label label3;
        private Button gSec;
        public TextBox gFilePath;
        private Label label6;
        private Button tSec;
        public TextBox tFilePath;
        private GroupBox groupBox2;
        private CheckBox ictStation;
        private CheckBox partiNo;
        private Label label2;


        public ProgAyarForm()
        {
            this.InitializeComponent();
        }

        public class INIKaydet
        {
            [DllImport("kernel32")]
            private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

            [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

            public INIKaydet(string dosyaYolu)
            {
                DOSYAYOLU = dosyaYolu;
            }
            private string DOSYAYOLU = String.Empty;
            public string Varsayilan { get; set; }
            public string Oku(string bolum, string ayaradi)
            {
                Varsayilan = Varsayilan ?? string.Empty;
                StringBuilder StrBuild = new StringBuilder(256);
                GetPrivateProfileString(bolum, ayaradi, Varsayilan, StrBuild, 255, DOSYAYOLU);
                return StrBuild.ToString();
            }
            public long Yaz(string bolum, string ayaradi, string deger)
            {
                return WritePrivateProfileString(bolum, ayaradi, deger, DOSYAYOLU);
            }
        }

        private void AyarForm_Load(object sender, EventArgs e)
        {
            this.txtINIdosya.Text = Prog_Ayarlar.Default.iniDosyaYolu;
            this.gFilePath.Text = Prog_Ayarlar.Default.gDosyaYolu;
            this.tFilePath.Text = Prog_Ayarlar.Default.tDosyaYolu;
            this.projectName.Text = Prog_Ayarlar.Default.projectName;
            this.printerName.Text = Prog_Ayarlar.Default.printerName;
            this.printerPos.Text = Prog_Ayarlar.Default.printerPos;
            this.txtAdminSifre.Text = Prog_Ayarlar.Default.adminSifre.ToString();
            this.txtKaliteSifre.Text = Prog_Ayarlar.Default.kaliteSifre.ToString();
            this.txtTimerAdmin.Text = Prog_Ayarlar.Default.timerAdmin.ToString();
            this.ictStation.Checked = Prog_Ayarlar.Default.ictStation;
            this.partiNo.Checked = Prog_Ayarlar.Default.partiNo;

            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                printerName.Items.Add(printer);
            }
        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            try
            {
                Prog_Ayarlar.Default.iniDosyaYolu = this.txtINIdosya.Text;
                Prog_Ayarlar.Default.gDosyaYolu = this.gFilePath.Text;
                Prog_Ayarlar.Default.tDosyaYolu = this.tFilePath.Text;
                Prog_Ayarlar.Default.projectName = this.projectName.Text;
                Prog_Ayarlar.Default.printerName = this.printerName.Text;
                Prog_Ayarlar.Default.printerPos = this.printerPos.Text;
                Prog_Ayarlar.Default.adminSifre = this.txtAdminSifre.Text;
                Prog_Ayarlar.Default.kaliteSifre = this.txtKaliteSifre.Text;
                Prog_Ayarlar.Default.timerAdmin = Convert.ToInt32(this.txtTimerAdmin.Text);
                Prog_Ayarlar.Default.ictStation = this.ictStation.Checked;
                Prog_Ayarlar.Default.partiNo = this.partiNo.Checked;

                Prog_Ayarlar.Default.Save();

                CustomMessageBox.ShowMessage("Bütün Ayarlar Başarıyla Kaydedildi.", Prog_Ayarlar.Default.projectName, MessageBoxButtons.OK, CustomMessageBoxIcon.Information, Color.Yellow);
                this.Close();

                Application.Restart();
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowMessage("Ayarlar Kayıt Hatası: " + ex.ToString(), Prog_Ayarlar.Default.projectName, MessageBoxButtons.OK, CustomMessageBoxIcon.Error, Color.Red);
            }
        }

        private void btnKaydetIni_Click_1(object sender, EventArgs e)
        {
            if (txtINIdosya.Text != "")
            {
                INIKaydet ini = new INIKaydet(txtINIdosya.Text);  // @"\Ayarlar.ini"
                ini.Yaz("timerAdmin", "Metin Kutusu", Convert.ToString(txtTimerAdmin.Text));
                ini.Yaz("projectName", "Metin Kutusu", Convert.ToString(projectName.Text));
                ini.Yaz("printerName", "Metin Kutusu", Convert.ToString(printerName.Text));
                ini.Yaz("printerPos", "Metin Kutusu", Convert.ToString(printerPos.Text));
                ini.Yaz("gFilePath", "Metin Kutusu", Convert.ToString(gFilePath.Text));
                ini.Yaz("tFilePath", "Metin Kutusu", Convert.ToString(tFilePath.Text));
                ini.Yaz("ictStation", "Metin Kutusu", Convert.ToString(ictStation.Checked));
                ini.Yaz("partiNo", "Metin Kutusu", Convert.ToString(partiNo.Checked));

                CustomMessageBox.ShowMessage("Bütün Ayarlar Dosyaya Başarıyla Kaydedildi.", Prog_Ayarlar.Default.projectName, MessageBoxButtons.OK, CustomMessageBoxIcon.Information, Color.Yellow);
            }
            else
            {
                CustomMessageBox.ShowMessage("Dosya Yolu Boş Kalamaz", Prog_Ayarlar.Default.projectName, MessageBoxButtons.OK, CustomMessageBoxIcon.Error, Color.Red);
            }
        }

        private void btnOkuIni_Click_1(object sender, EventArgs e)
        {
            if (txtINIdosya.Text != "")
            {
                try
                {
                    if (File.Exists(txtINIdosya.Text))
                    {
                        INIKaydet ini = new INIKaydet(txtINIdosya.Text);

                        txtTimerAdmin.Text = ini.Oku("timerAdmin", "Metin Kutusu");
                        projectName.Text = ini.Oku("projectName", "Metin Kutusu");
                        printerName.Text = ini.Oku("printerName", "Metin Kutusu");
                        printerPos.Text = ini.Oku("printerPos", "Metin Kutusu");
                        gFilePath.Text = ini.Oku("gFilePath", "Metin Kutusu");
                        tFilePath.Text = ini.Oku("tFilePath", "Metin Kutusu");
                        if (ini.Oku("ictStation", "Metin Kutusu") == "True")
                            ictStation.Checked = true;
                        else if (ini.Oku("ictStation", "Metin Kutusu") == "False")
                            ictStation.Checked = false;
                        if (ini.Oku("partiNo", "Metin Kutusu") == "True")
                            partiNo.Checked = true;
                        else if (ini.Oku("partiNo", "Metin Kutusu") == "False")
                            partiNo.Checked = false;

                        CustomMessageBox.ShowMessage("Bütün Ayarlar Dosyadan Başarıyla Okundu.", Prog_Ayarlar.Default.projectName, MessageBoxButtons.OK, CustomMessageBoxIcon.Information, Color.Yellow);
                    }
                }
                catch (Exception hata)
                {
                    CustomMessageBox.ShowMessage("ini Dosyası Hasarlı" + hata, Prog_Ayarlar.Default.projectName, MessageBoxButtons.OK, CustomMessageBoxIcon.Error, Color.Red);
                }
            }
            else
            {
                CustomMessageBox.ShowMessage("Dosya Yolu Boş Kalamaz", Prog_Ayarlar.Default.projectName, MessageBoxButtons.OK, CustomMessageBoxIcon.Error, Color.Red);
            }
        }

        private void gSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "|*.ini";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.gFilePath.Text = openFileDialog.FileName;
        }

        private void tSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "|*.ini";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.tFilePath.Text = openFileDialog.FileName;
        }


        private void gAddBtn_Click(object sender, EventArgs e)
        {
            operatorSave(gName.Text, gFilePath.Text);
        }

        private void tAddBtn_Click(object sender, EventArgs e)
        {
            operatorSave(tName.Text, tFilePath.Text);
        }

        private void operatorSave(string programName, string adress)
        {
            try
            {
                if (adress != "")  //Yolu değiştir
                {
                    List<string> lines = new List<string>();
                    lines = File.ReadAllLines(adress).ToList();
                    lines.Add(programName);
                    File.WriteAllLines(adress, lines);
                    CustomMessageBox.ShowMessage("Operator İsmi Başarılı Bir Şekilde Eklendi.!", this.MainFrm.customMessageBoxTitle, MessageBoxButtons.OK, CustomMessageBoxIcon.Pass, Color.Green);
                }
                else
                {
                    CustomMessageBox.ShowMessage("Dosya Yolu Boş Kalamaz!", this.MainFrm.customMessageBoxTitle, MessageBoxButtons.OK, CustomMessageBoxIcon.Error, Color.Red);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowMessage("programSave: ", this.MainFrm.customMessageBoxTitle, MessageBoxButtons.OK, CustomMessageBoxIcon.Error, Color.Red);
            }
        }

        private void btnIDsec_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "|*.ini";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.txtINIdosya.Text = openFileDialog.FileName;
        }

        private void sifreChange_CheckedChanged(object sender, EventArgs e)
        {
            if (this.sifreChange.Checked)
            {
                this.txtAdminSifre.Enabled = true;
                this.txtKaliteSifre.Enabled = true;
                this.txtAdminSifre.PasswordChar = char.MinValue;
                this.txtKaliteSifre.PasswordChar = char.MinValue;
            }
            else
            {
                this.txtAdminSifre.Enabled = false;
                this.txtKaliteSifre.Enabled = false;
                this.txtAdminSifre.PasswordChar = '*';
                this.txtKaliteSifre.PasswordChar = '*';
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgAyarForm));
            this.btnKaydet = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label220 = new System.Windows.Forms.Label();
            this.btnOkuIni = new System.Windows.Forms.Button();
            this.btnIDsec = new System.Windows.Forms.Button();
            this.btnKaydetIni = new System.Windows.Forms.Button();
            this.txtINIdosya = new System.Windows.Forms.TextBox();
            this.projectName = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.printerName = new System.Windows.Forms.ComboBox();
            this.label62 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.sifreChange = new System.Windows.Forms.CheckBox();
            this.label90 = new System.Windows.Forms.Label();
            this.txtAdminSifre = new System.Windows.Forms.TextBox();
            this.txtKaliteSifre = new System.Windows.Forms.TextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.txtTimerAdmin = new System.Windows.Forms.TextBox();
            this.label92 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.printerPos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tSec = new System.Windows.Forms.Button();
            this.tFilePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gSec = new System.Windows.Forms.Button();
            this.gFilePath = new System.Windows.Forms.TextBox();
            this.tAddBtn = new System.Windows.Forms.Button();
            this.gAddBtn = new System.Windows.Forms.Button();
            this.tName = new System.Windows.Forms.TextBox();
            this.gName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ictStation = new System.Windows.Forms.CheckBox();
            this.partiNo = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.Aqua;
            this.btnKaydet.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.ForeColor = System.Drawing.Color.Black;
            this.btnKaydet.Location = new System.Drawing.Point(355, 248);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(203, 172);
            this.btnKaydet.TabIndex = 595;
            this.btnKaydet.Text = "Ayarları Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label220);
            this.groupBox3.Controls.Add(this.btnOkuIni);
            this.groupBox3.Controls.Add(this.btnIDsec);
            this.groupBox3.Controls.Add(this.btnKaydetIni);
            this.groupBox3.Controls.Add(this.txtINIdosya);
            this.groupBox3.Controls.Add(this.projectName);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Location = new System.Drawing.Point(3, 113);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(346, 136);
            this.groupBox3.TabIndex = 594;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Proje Ayarları:";
            // 
            // label220
            // 
            this.label220.AutoSize = true;
            this.label220.Location = new System.Drawing.Point(8, 65);
            this.label220.Name = "label220";
            this.label220.Size = new System.Drawing.Size(116, 17);
            this.label220.TabIndex = 585;
            this.label220.Text = "Ayarlar Dosya Yolu:";
            // 
            // btnOkuIni
            // 
            this.btnOkuIni.BackColor = System.Drawing.Color.Aqua;
            this.btnOkuIni.Location = new System.Drawing.Point(214, 98);
            this.btnOkuIni.Name = "btnOkuIni";
            this.btnOkuIni.Size = new System.Drawing.Size(80, 30);
            this.btnOkuIni.TabIndex = 584;
            this.btnOkuIni.Text = "Oku";
            this.btnOkuIni.UseVisualStyleBackColor = false;
            this.btnOkuIni.Click += new System.EventHandler(this.btnOkuIni_Click_1);
            // 
            // btnIDsec
            // 
            this.btnIDsec.BackColor = System.Drawing.Color.Aqua;
            this.btnIDsec.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIDsec.Location = new System.Drawing.Point(296, 63);
            this.btnIDsec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIDsec.Name = "btnIDsec";
            this.btnIDsec.Size = new System.Drawing.Size(43, 24);
            this.btnIDsec.TabIndex = 587;
            this.btnIDsec.Text = "Seç";
            this.btnIDsec.UseVisualStyleBackColor = false;
            this.btnIDsec.Click += new System.EventHandler(this.btnIDsec_Click_1);
            // 
            // btnKaydetIni
            // 
            this.btnKaydetIni.BackColor = System.Drawing.Color.Aqua;
            this.btnKaydetIni.Location = new System.Drawing.Point(128, 98);
            this.btnKaydetIni.Name = "btnKaydetIni";
            this.btnKaydetIni.Size = new System.Drawing.Size(80, 30);
            this.btnKaydetIni.TabIndex = 583;
            this.btnKaydetIni.Text = "Kaydet";
            this.btnKaydetIni.UseVisualStyleBackColor = false;
            this.btnKaydetIni.Click += new System.EventHandler(this.btnKaydetIni_Click_1);
            // 
            // txtINIdosya
            // 
            this.txtINIdosya.Location = new System.Drawing.Point(128, 65);
            this.txtINIdosya.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtINIdosya.Name = "txtINIdosya";
            this.txtINIdosya.Size = new System.Drawing.Size(166, 24);
            this.txtINIdosya.TabIndex = 586;
            // 
            // projectName
            // 
            this.projectName.Location = new System.Drawing.Point(128, 22);
            this.projectName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(166, 24);
            this.projectName.TabIndex = 62;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(8, 26);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(62, 17);
            this.label29.TabIndex = 61;
            this.label29.Text = "Proje Adı:";
            // 
            // printerName
            // 
            this.printerName.FormattingEnabled = true;
            this.printerName.Location = new System.Drawing.Point(118, 23);
            this.printerName.Name = "printerName";
            this.printerName.Size = new System.Drawing.Size(166, 23);
            this.printerName.TabIndex = 586;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(20, 26);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(64, 17);
            this.label62.TabIndex = 585;
            this.label62.Text = "Yazıcı Adı:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.sifreChange);
            this.groupBox6.Controls.Add(this.label90);
            this.groupBox6.Controls.Add(this.txtAdminSifre);
            this.groupBox6.Controls.Add(this.txtKaliteSifre);
            this.groupBox6.Controls.Add(this.label91);
            this.groupBox6.Controls.Add(this.txtTimerAdmin);
            this.groupBox6.Controls.Add(this.label92);
            this.groupBox6.Controls.Add(this.label93);
            this.groupBox6.Location = new System.Drawing.Point(355, 1);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(203, 155);
            this.groupBox6.TabIndex = 593;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Şifre Ayarları:";
            // 
            // sifreChange
            // 
            this.sifreChange.AutoSize = true;
            this.sifreChange.Location = new System.Drawing.Point(9, 21);
            this.sifreChange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sifreChange.Name = "sifreChange";
            this.sifreChange.Size = new System.Drawing.Size(99, 21);
            this.sifreChange.TabIndex = 3;
            this.sifreChange.Text = "Şifre Değiştir";
            this.sifreChange.UseVisualStyleBackColor = true;
            this.sifreChange.CheckedChanged += new System.EventHandler(this.sifreChange_CheckedChanged);
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(-1, 55);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(70, 17);
            this.label90.TabIndex = 1;
            this.label90.Text = "Adm. Şifre:";
            // 
            // txtAdminSifre
            // 
            this.txtAdminSifre.Enabled = false;
            this.txtAdminSifre.Location = new System.Drawing.Point(84, 48);
            this.txtAdminSifre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAdminSifre.Name = "txtAdminSifre";
            this.txtAdminSifre.PasswordChar = '*';
            this.txtAdminSifre.Size = new System.Drawing.Size(85, 24);
            this.txtAdminSifre.TabIndex = 0;
            // 
            // txtKaliteSifre
            // 
            this.txtKaliteSifre.Enabled = false;
            this.txtKaliteSifre.Location = new System.Drawing.Point(84, 82);
            this.txtKaliteSifre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKaliteSifre.Name = "txtKaliteSifre";
            this.txtKaliteSifre.PasswordChar = '*';
            this.txtKaliteSifre.Size = new System.Drawing.Size(85, 24);
            this.txtKaliteSifre.TabIndex = 0;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(-3, 85);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(72, 17);
            this.label91.TabIndex = 1;
            this.label91.Text = "Kalite Şifre:";
            // 
            // txtTimerAdmin
            // 
            this.txtTimerAdmin.Location = new System.Drawing.Point(84, 115);
            this.txtTimerAdmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimerAdmin.Name = "txtTimerAdmin";
            this.txtTimerAdmin.Size = new System.Drawing.Size(84, 24);
            this.txtTimerAdmin.TabIndex = 25;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(-1, 118);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(61, 17);
            this.label92.TabIndex = 23;
            this.label92.Text = "T. Admin:";
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(174, 118);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(25, 17);
            this.label93.TabIndex = 24;
            this.label93.Text = "mS";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.printerName);
            this.groupBox7.Controls.Add(this.printerPos);
            this.groupBox7.Controls.Add(this.label62);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Location = new System.Drawing.Point(3, 1);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(346, 106);
            this.groupBox7.TabIndex = 592;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Yazıcı Ayarları";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(293, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 103;
            this.label2.Text = "Sol,Üst";
            // 
            // printerPos
            // 
            this.printerPos.Location = new System.Drawing.Point(118, 64);
            this.printerPos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.printerPos.Name = "printerPos";
            this.printerPos.Size = new System.Drawing.Size(166, 24);
            this.printerPos.TabIndex = 102;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(20, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 101;
            this.label1.Text = "Yazıcı Pozisyon:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tSec);
            this.groupBox1.Controls.Add(this.tFilePath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.gSec);
            this.groupBox1.Controls.Add(this.gFilePath);
            this.groupBox1.Controls.Add(this.tAddBtn);
            this.groupBox1.Controls.Add(this.gAddBtn);
            this.groupBox1.Controls.Add(this.tName);
            this.groupBox1.Controls.Add(this.gName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(3, 255);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 165);
            this.groupBox1.TabIndex = 596;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operator Ayarları";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 595;
            this.label6.Text = "T Dosya Yolu:";
            // 
            // tSec
            // 
            this.tSec.BackColor = System.Drawing.Color.Aqua;
            this.tSec.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tSec.Location = new System.Drawing.Point(296, 56);
            this.tSec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tSec.Name = "tSec";
            this.tSec.Size = new System.Drawing.Size(43, 24);
            this.tSec.TabIndex = 597;
            this.tSec.Text = "Seç";
            this.tSec.UseVisualStyleBackColor = false;
            this.tSec.Click += new System.EventHandler(this.tSec_Click);
            // 
            // tFilePath
            // 
            this.tFilePath.Location = new System.Drawing.Point(128, 58);
            this.tFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tFilePath.Name = "tFilePath";
            this.tFilePath.Size = new System.Drawing.Size(166, 24);
            this.tFilePath.TabIndex = 596;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 592;
            this.label3.Text = "G Dosya Yolu:";
            // 
            // gSec
            // 
            this.gSec.BackColor = System.Drawing.Color.Aqua;
            this.gSec.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gSec.Location = new System.Drawing.Point(296, 20);
            this.gSec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gSec.Name = "gSec";
            this.gSec.Size = new System.Drawing.Size(43, 24);
            this.gSec.TabIndex = 594;
            this.gSec.Text = "Seç";
            this.gSec.UseVisualStyleBackColor = false;
            this.gSec.Click += new System.EventHandler(this.gSec_Click);
            // 
            // gFilePath
            // 
            this.gFilePath.Location = new System.Drawing.Point(128, 22);
            this.gFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gFilePath.Name = "gFilePath";
            this.gFilePath.Size = new System.Drawing.Size(166, 24);
            this.gFilePath.TabIndex = 593;
            // 
            // tAddBtn
            // 
            this.tAddBtn.BackColor = System.Drawing.Color.Aqua;
            this.tAddBtn.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tAddBtn.Location = new System.Drawing.Point(296, 135);
            this.tAddBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tAddBtn.Name = "tAddBtn";
            this.tAddBtn.Size = new System.Drawing.Size(43, 24);
            this.tAddBtn.TabIndex = 591;
            this.tAddBtn.Text = "Ekle";
            this.tAddBtn.UseVisualStyleBackColor = false;
            this.tAddBtn.Click += new System.EventHandler(this.tAddBtn_Click);
            // 
            // gAddBtn
            // 
            this.gAddBtn.BackColor = System.Drawing.Color.Aqua;
            this.gAddBtn.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gAddBtn.Location = new System.Drawing.Point(296, 94);
            this.gAddBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gAddBtn.Name = "gAddBtn";
            this.gAddBtn.Size = new System.Drawing.Size(43, 24);
            this.gAddBtn.TabIndex = 590;
            this.gAddBtn.Text = "Ekle";
            this.gAddBtn.UseVisualStyleBackColor = false;
            this.gAddBtn.Click += new System.EventHandler(this.gAddBtn_Click);
            // 
            // tName
            // 
            this.tName.Location = new System.Drawing.Point(128, 132);
            this.tName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(166, 24);
            this.tName.TabIndex = 589;
            // 
            // gName
            // 
            this.gName.Location = new System.Drawing.Point(128, 94);
            this.gName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gName.Name = "gName";
            this.gName.Size = new System.Drawing.Size(166, 24);
            this.gName.TabIndex = 587;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 585;
            this.label4.Text = "G.ADI:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(75, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 101;
            this.label5.Text = "T.ADI:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.partiNo);
            this.groupBox2.Controls.Add(this.ictStation);
            this.groupBox2.Location = new System.Drawing.Point(357, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(203, 79);
            this.groupBox2.TabIndex = 597;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Senaryo Ayarları:";
            // 
            // ictStation
            // 
            this.ictStation.AutoSize = true;
            this.ictStation.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ictStation.Location = new System.Drawing.Point(9, 21);
            this.ictStation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ictStation.Name = "ictStation";
            this.ictStation.Size = new System.Drawing.Size(175, 27);
            this.ictStation.TabIndex = 3;
            this.ictStation.Text = "ICT İstasyonu Aktif";
            this.ictStation.UseVisualStyleBackColor = true;
            this.ictStation.CheckedChanged += new System.EventHandler(this.ictStation_CheckedChanged);
            // 
            // partiNo
            // 
            this.partiNo.AutoSize = true;
            this.partiNo.Checked = true;
            this.partiNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.partiNo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.partiNo.Location = new System.Drawing.Point(9, 47);
            this.partiNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.partiNo.Name = "partiNo";
            this.partiNo.Size = new System.Drawing.Size(169, 27);
            this.partiNo.TabIndex = 4;
            this.partiNo.Text = "Parti No Otomatik";
            this.partiNo.UseVisualStyleBackColor = true;
            // 
            // ProgAyarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(563, 419);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox7);
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ProgAyarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.AyarForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void ictStation_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
