using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Acron_Paketleme.Printer; 
using System.Printing;
using System.Net;
using System.Net.Mail;
using System.Globalization;
using System.Data.SqlClient;

namespace Acron_Paketleme
{
    public partial class FormMain : Form
    {
        public ProgAyarForm ProgAyarFrm;
        public Sifre SifreFrm;
        private IntPtr ShellHwnd;

        /********************************************SQL**********************************************/
        SqlConnection SQLConnection;

        //İstasyon Türü - Var ise Kart İsmi - Yapan Firma - Lokasyon

        const string POTA_ALPLAS_ISTANBUL = "1";
        const string POTA_ALPLAS_BOLU = "1";
        const string POTA_BRC_ISTANBUL = "5";
        const string POTA_BRC_BOLU = "18";
        const string POTA_VEKTOR_ALPPLAS_ISTANBUL = "27";

        const string ICT_BRC_ISTANBUL = "15";
        const string ICT_BRC_BOLU_1 = "19";
        const string ICT_BRC_BOLU_2 = "22";
        const string ICT_BRC_BOLU_3 = "32";

        const string FCT_MIND_BRC_BOLU = "17";
        const string FCT_MIND_IBER_BOLU = "20";
        const string FCT_MIND_ALPPLAS_BOLU_1 = "23";
        const string FCT_MIND_ALPPLAS_BOLU_2 = "24";
        const string FCT_MIND_ALPPLAS_BOLU_3 = "25";
        const string FCT_ARTOUCH_ALPPLAS_BOLU = "26";
        const string FCT_VEKTOR_ALPPLAS_ISTANBUL = "28";
        const string FCT_ROBINMB_ALPPLAS_ISTANBUL = "30";
        const string FCT_ROBINTB_ALPPLAS_ISTANBUL = "31";
        const string ALPPLAS_STATION_FRODO_G03 = "40";

        const string PAKETLEME_BRC_ISTANBUL = "16";
        const string PAKETLEME_BRC_BOLU = "21";
        const string PAKETLEME_VEKTOR_ALPPLAS_ISTANBUL = "29";
        const string PAKETLEME_ALPPLAS_BOLU = "33";

        const string URUN_DURUM_HAZIR = "7";

        const string pngString = "4620,4620,33,,hW01,hW0F8,hV03FC,hU01FFE,hU07IF,hT03JF8,hS01KFC,hS07LF,hR03MF8,hR0NFC,hQ01NFE,hQ03OF,hQ07OFC78,hQ07RF,hQ0SFC,hQ0OF9IFE,hQ0NFE1IFE,hQ0NF01JF,hQ0MFC03JF,hQ0LFE003JF,hP01LFI03JF,hP01KFCI03JF,hP01JFEJ03JF,hP01JF8J03JF,hP01IFCK07IFE,hP01FFEL07IFE,hP01FF8L07IFE,hP03FF8L07IFE,hP03FFCL07IFE,hP03FFEL07IFE,hP03IF8K07IFC,hP03IFCK0JFC,hP03IFEK0JFC,hP07JFK0JFC,hP07JF8J0JFC,hP07JFEJ0JFC,hP07KFJ0JF8,hP07KF8001JF8,hP07KFC001JF8,hP07LF001JF8,hP03LF801JF8,hP03LFC01JF8,hP01LFE01JF8,hQ0MF83JF,hQ03LFC3JF,hQ01LFE3JF,hR0MF3JF,hR07QF,hR01PFE,hS0LFDIFE,hS07KF07FFC,hS03JFE01FF8,hT0JF8001,hT07FFE,hT03FF8,hT01FE,hU0F8,hU02,,::::::::::::::K0EO078K03FCO0F,J07FCM0JFC03KFL01IF8J0FEK07E,J0FFEL03JFE03KFEK07JFJ0FFK07E,I01FFEL0KFE03LF8I01KF8I0FF8J07E,I01IFK01KFE03LFCI03KFEI0FF8J07E,I01IFK03KFE03LFEI07LFI0FFCJ07E,I03F3F8J07FE001E03FI07FFI0FFE03FFI0FFCJ07E,I03F1F8J0FF8K03FJ0FFI0FFI07F800FFEJ07E,I03F1F8J0FEL03FJ07F801FEI03FC00FFEJ07E,I07E1F8I01FCL03FJ03F803FCI01FC00IFJ07E,I07E0FCI01FCL03FJ01FC03F8J0FE00IFJ07E,I07E0FCI03F8L03FJ01FC03FK0FE00IF8I07E,I07E0FCI03F8L03FK0FC07FK07E00FDFCI07E,I0FC0FEI03FM03FK0FC07EK07F00FDFCI07E,I0FC07EI03FM03FK0FC07EK07F00FCFEI07E,I0FC07EI07FM03FK0FC07EK03F00FC7EI07E,001FC07EI07FM03FK0FC0FEK03F00FC7FI07E,001F803FI07EM03FK0FC0FEK03F00FC3FI07E,001F803FI07EM03FK0FC0FCK03F00FC3F8007E,001F803FI07EM03FJ01FC0FCK03F80FC1F8007E,003F003FI07EM03FJ01FC0FCK03F80FC1FC007E,003F001F8007EM03FJ03F80FCK03F80FC0FC007E,003F001F8007EM03FJ07F80FCK03F80FC0FE007E,007F001F8007EM03FJ0FF00FCK03F80FC07E007E,007E001FC007EM03FI07FF00FCK03F80FC07F007E,007EI0FC007EM03LFE00FCK03F80FC03F007E,007EI0FC007EM03LFC00FCK03F80FC03F807E,00FCI0FC007EM03LFI0FCK03F80FC01F807E,00FCI07E007EM03KFCI0FCK03F80FC01FC07E,00LFE007EM03KFJ0FCK03F80FC00FC07E,01LFE007EM03F007FJ0FCK03F80FC00FE07E,01MF007EM03F003F8I0FCK03F80FC007E07E,01MF007EM03F003F8I0FCK03F80FC007F07E,01MF007EM03F001FCI0FCK03F00FC003F87E,03MF007EM03F001FEI0FEK03F00FC003F87E,03FJ03F807EM03FI0FEI0FEK03F00FC001FC7E,03FJ01F807FM03FI07FI0FEK03F00FCI0FC7E,07FJ01F803FM03FI07FI07EK03F00FCI0FE7E,07FJ01FC03FM03FI03F8007EK07F00FCI07E7E,07EJ01FC03F8L03FI03FC007FK07E00FCI07F7E,07EK0FC03F8L03FI01FC007FK0FE00FCI03F7E,0FEK0FC01FCL03FJ0FE003F8J0FE00FCI03FFE,0FEK0FE01FCL03FJ0FE003FCI01FC00FCI01FFE,0FCK07E00FEL03FJ07F001FCI03FC00FCI01FFE,1FCK07E00FF8K03FJ07F801FFI07F800FCJ0FFE,1FCK07F007FCK03FJ03F800FFC01FF800FCJ0FFE,1F8K07F003KFE03FJ01FC007LFI0FCJ07FE,1F8K03F001KFE03FJ01FC003KFEI0FCJ07FE,3F8K03FI0KFE03FK0FE001KFCI0FCJ03FE,3F8K03F8007JFE03FK0FFI07JFJ0FCJ03FE,3FL01F8001JFE03FK07FI01IFCJ0FCJ01FE,T01FFCU01FC,,:::::::::::::^FS";

        int modelTotalNum = 30;
        int[] modelsNumber = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3};

        int alan = 520;  //750 - 230
        int fontSize1 = 27;  //Koyu1
        int fontSize2 = 30;  //Normal1
        int fontSize3 = 22;  //Narmal2

        //Sıfırlanmamalı
        public string customMessageBoxTitle;
        int adminTimerCounter = 0;
        public int yetki;
        string printerName;

        //Sıfırlanmamalı
        string companyNo; //Barkoddan Karşılatırılan
        string SAPNo;  //Barkoddan Karşılatırılan
        string productionDate;  //Barkoddan Alınan
        string indexNo; //Barkoddan Alınan
        string productionNo; //Barkoddan Alınan
        string cardNo;  //Barkoddan Karşılatırılan
        string gerberVer;  //Sabit
        string BOMVer;  //Sabit
        string ICTRev;  //Sabit
        string FCTRev;  //Sabit
        string softwareVer;  //Sabit
        string softwareRev;  //Sabit
        string specialCode;  //Sabit
     
        string urun_id = "";
        string urun_barkod = "";
        string son_istasyon_id = "";
        string giris_zamani = "";
        string son_istasyon_zamani = "";

        //Sıfırlanmamalı
        string[] SAPStrings;
        string[] GerberStrings;
        string modelString = "";
        string gerberString = "";
        //Sıfırlanmalı
        int cardCounter = 0;
        string[] cardStatus = new string[49];
        string koli_no = "";
        string newProductionNo = "";
        string vardiyaString = "";

        //Sıfırlanmamalı
        int txt_Row;
        int txt_Column;
        int txt_Kalan;
        int matrisCounter = 0;
        Button[,] Dizi;
        public int number1 = 0;
 
        //Sıfırlanmamalı
        int aVardiyaNum = 0;
        int bVardiyaNum = 0;
        int cVardiyaNum = 0;
        
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

        public FormMain()
        {
            this.ProgAyarFrm = new ProgAyarForm();
            this.ProgAyarFrm.MainFrm = this;
            this.SifreFrm = new Sifre();
            this.SifreFrm.MainFrm = this;
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern byte ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string ClassName, string WindowName);

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            operatorSave();
            if (Convert.ToString(SQLConnection.State) == "Open")
            {
                SQLConnection.Close();
            }
        }

        private void operatorSave()
        {
            if (Prog_Ayarlar.Default.iniDosyaYolu != "")
            {
                try
                {
                    INIKaydet ini = new INIKaydet(Prog_Ayarlar.Default.iniDosyaYolu);  // @"\Ayarlar.ini"
                    ini.Yaz("operatorName1", "Metin Kutusu", Convert.ToString(oparatorName1.Text));
                    ini.Yaz("operatorName2", "Metin Kutusu", Convert.ToString(oparatorName2.Text));
                    ini.Yaz("modelName", "Metin Kutusu", Convert.ToString(modelName.Text));
                    ini.Yaz("packetNumber", "Metin Kutusu", Convert.ToString(packetNumber.Text));

                    ini.Yaz("aVardiyaNum", "Metin Kutusu", Convert.ToString(aVardiyaNum));
                    ini.Yaz("bVardiyaNum", "Metin Kutusu", Convert.ToString(bVardiyaNum));
                    ini.Yaz("cVardiyaNum", "Metin Kutusu", Convert.ToString(cVardiyaNum));

                    modelsNumber[modelName.SelectedIndex] = Convert.ToInt32(packetNumber.Text);
                    for (int i = 0; i < modelTotalNum; i++)
                    {
                        ini.Yaz("modelsNumber" + Convert.ToString(i), "Metin Kutusu", Convert.ToString(modelsNumber[i]));
                    }

                    otherConsoleAppendLine("Operatör İsmi Başarıyla Kaydedildi.", Color.Green);
                }
                catch (Exception hata)
                {
                    otherConsoleAppendLine("Operatör İsmi Kaydedilemedi.", Color.Red);
                }
            }
            else
            {
                otherConsoleAppendLine("Dosya Yolu Boş Kalamaz.", Color.Red);
            }
        }

        string deneme = "0167000186-MIND 180-180-F/145-210-G06-B06";
        private void FormMain_Load(object sender, EventArgs e)  //FORM LOAD
        {
            inisqlCommonConnection();
            if (Convert.ToString(SQLConnection.State) == "Open")
            {
                formMainInit();
                operatorRead();
                modelStringParse();
                gerberStringParse();
                matrisAdd();
                tbBarcodeCurrent.TabIndex = 1;
                tbBarcodeCurrent.Focus();
            }
        }

        private void mp3ActionFunction()  //MP3 Çalıştırma
        {
            try
            {
                mediaPlayer.URL = "C:\\Users\\IT\\Desktop\\Soft_Documents\\hatali.mp3";
                otherConsoleAppendLine("Ses Aç", Color.Red);
                mediaPlayer.Ctlcontrols.play();
               // otherConsoleAppendLine("Ses Kapa", Color.Red);
               // mediaPlayer.Ctlcontrols.stop();
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("mp3ActionFunction: " + ex.Message, Color.Red);
            }
        }

        private void formMainInit()     //FORM INIT
        {
            this.ShellHwnd = FormMain.FindWindow("Shell TrayWnd", (string)null);
            IntPtr shellHwnd = this.ShellHwnd;
            int num1 = (int)FormMain.ShowWindow(this.ShellHwnd, 0);

            this.customMessageBoxTitle = Prog_Ayarlar.Default.projectName;
            this.projectNameTxt.Text = customMessageBoxTitle;
            this.Text = customMessageBoxTitle;

            this.timerAdmin.Interval = Prog_Ayarlar.Default.timerAdmin;
            this.printerName = Prog_Ayarlar.Default.printerName;

            this.yetki = 0;
            this.yetkidegistir();
            for (int i = 0; i < 48; i++)
            {
                cardStatus[i] = i.ToString();
            }

            if (Prog_Ayarlar.Default.partiNo == true)
            {
                partiNo.Enabled = false;
            }
            else
            {
                partiNo.Enabled = true;
            }
        }

        private void operatorRead()
        {
            if (Prog_Ayarlar.Default.iniDosyaYolu != "")
            {
                try
                {
                    string[] lineOfContents1 = File.ReadAllLines(Prog_Ayarlar.Default.gDosyaYolu);
                    foreach (var line in lineOfContents1)
                    {
                        string[] tokens = line.Split(',');
                        oparatorName1.Items.Add(tokens[0]);
                    }
                    string[] lineOfContents2 = File.ReadAllLines(Prog_Ayarlar.Default.tDosyaYolu);
                    foreach (var line in lineOfContents2)
                    {
                        string[] tokens = line.Split(',');
                        oparatorName2.Items.Add(tokens[0]);
                    }

                    if (File.Exists(Prog_Ayarlar.Default.iniDosyaYolu))
                    {
                        INIKaydet ini = new INIKaydet(Prog_Ayarlar.Default.iniDosyaYolu);
                        oparatorName1.Text = ini.Oku("operatorName1", "Metin Kutusu");
                        oparatorName2.Text = ini.Oku("operatorName2", "Metin Kutusu");
                        modelName.Text = ini.Oku("modelName", "Metin Kutusu");
                        packetNumber.Text = ini.Oku("packetNumber", "Metin Kutusu");

                        aVardiyaNum = Convert.ToInt32(ini.Oku("aVardiyaNum", "Metin Kutusu"));
                        bVardiyaNum = Convert.ToInt32(ini.Oku("bVardiyaNum", "Metin Kutusu"));
                        cVardiyaNum = Convert.ToInt32(ini.Oku("cVardiyaNum", "Metin Kutusu"));

                        for (int i = 0; i < modelTotalNum; i++)
                        {
                            modelsNumber[i] = Convert.ToInt32(ini.Oku("modelsNumber" + Convert.ToString(i), "Metin Kutusu"));
                        }
                        otherConsoleAppendLine("Operatör İsmi Başarıyla Okundu.", Color.Green);
                    }
                }
                catch (Exception hata)
                {
                    otherConsoleAppendLine("Operatör İsmi Okunamadı.", Color.Red);
                }
            }
            else
            {
                otherConsoleAppendLine("Dosya Yolu Boş Kalamaz.", Color.Red);
            }
        }

        /****************************************** SQL *************************************************/
        public void inisqlCommonConnection()
        {
            try
            {
                string connetionString = @"Data Source=192.168.0.8\MEYER;Initial Catalog=Alpplas_Uretim_Takip;User ID=Alpplas_user;Password=Alp-User-21*";
                SQLConnection = new SqlConnection(connetionString);
                SQLConnection.Open();
                otherConsoleAppendLine("SQL Baglantısı Açıldı", Color.Green);
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("sqlCommonConnection Error: " + ex.Message, Color.Red);
            }
        }

        public void sqlCommonConnection()
        {
            try
            {
                if (Convert.ToString(SQLConnection.State) != "Open")
                {
                    string connetionString = @"Data Source=192.168.0.8\MEYER;Initial Catalog=Alpplas_Uretim_Takip;User ID=Alpplas_user;Password=Alp-User-21*";
                    SQLConnection = new SqlConnection(connetionString);
                    SQLConnection.Open();
                    otherConsoleAppendLine("SQL Baglantısı Açıldı", Color.Green);
                }
                else
                {
                    otherConsoleAppendLine("SQL Baglantısı Zaten Açık", Color.Green);
                }
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("sqlCommonConnection Error: " + ex.Message, Color.Red);
            }
        }

        public void sqlWriteError()
        {
            otherConsoleAppendLine("sqlWriteError()", Color.Red);
        }

        private void tbBarcodeCurrent_TextChanged(object sender, EventArgs e)
        {
            int maxLenght = 50;

            string barcode = tbBarcodeCurrent.Text;
            if (Convert.ToInt32(barcode.Length) >= maxLenght)
            {
                sqlAction();
            }
        }

        private void sqlAction()
        {
            otherConsoleClean();
            bool result = tableRead(tbBarcodeCurrent.Text);

            string barcode = tbBarcodeCurrent.Text;
            SAPNo = barcode.Substring(3, 9);
            productionDate = barcode.Substring(12, 4);
            indexNo = barcode.Substring(16, 6);
            productionNo = barcode.Substring(22, 14);

            if (result)
            {
                if (SAPStrings[0] == SAPNo)
                {
                    bool errorIndexNo = false;
                    for (int i = 1; i <= cardCounter; i++)
                    {
                        if(cardStatus[i] == indexNo)
                        {
                            errorIndexNo = true;
                            break;
                        }
                    }
                    if (!errorIndexNo)
                    {
                        sqlTestInsert();
                        tableUpdate();
                        cardCounter++;
                        cardStatus[cardCounter] = indexNo;
                        lblCardCounter.Text = Convert.ToString(cardCounter);
                        matrisAdd();
                        sonucCard.ForeColor = Color.Black;
                        sonucCard.BackColor = Color.Green;
                        sonucCard.Text = "Kart Pakete Eklendi";
                        if (cardCounter == Convert.ToInt32(packetNumber.Text))
                        {
                            packetEnd();
                        }
                    }
                    else
                    {
                        mp3ActionFunction();
                        otherConsoleAppendLine("AYNI INDEX NUMARASI !", Color.Red);
                        sonucCard.ForeColor = Color.Black;
                        sonucCard.BackColor = Color.Red;
                        sonucCard.Text = "Kart Pakete Eklenemedi";
                    }
                }
                else
                {
                    mp3ActionFunction();
                    otherConsoleAppendLine("YANLIŞ MODEL NUMARASI !", Color.Red);
                    sonucCard.ForeColor = Color.Black;
                    sonucCard.BackColor = Color.Red;
                    sonucCard.Text = "Kart Pakete Eklenemedi";
                }
            }
            else
            {
                mp3ActionFunction();
                otherConsoleAppendLine("YANLIŞ BARKOD YA DA ÜRÜN SİSTEM'DE KAYITLI DEĞİL !", Color.Red);
                sonucCard.ForeColor = Color.Black;
                sonucCard.BackColor = Color.Red;
                sonucCard.Text = "Kart Pakete Eklenemedi";
            }


            tbBarcodeLast.Invoke(new Action(delegate () { tbBarcodeLast.Text = tbBarcodeCurrent.Text; }));

            tbBarcodeCurrent.Invoke(new Action(delegate ()
            {
                tbBarcodeCurrent.Text = "";
                tbBarcodeCurrent.Focus();
                tbBarcodeCurrent.SelectionStart = 0;
                tbBarcodeCurrent.SelectionLength = tbBarcodeCurrent.Text.Length;
            }));
        }

        public bool tableRead(string barcode)
        {
            sqlCommonConnection();
            try
            {
                string sql = "SELECT URUN_ID, URUN_BARKOD, SON_ISTASYON_ID, GIRIS_ZAMANI, SON_ISTASYON_ZAMANI, URUN_DURUM_NO, ARIZA_KODU, TAMIR_EDILDI, SON_ISLEM_TAMAMLANDI, FIRMA_NO, URUN_KODU, PANACIM_KODU, PARTI_NO, ALAN_5, ALAN_6, ALAN_7, PCB_BARKOD FROM URUNLER WHERE URUN_BARKOD='" + barcode + "'";
                SqlCommand command = new SqlCommand(sql, SQLConnection);
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);

                bool findState = false;
                dataReader.Read();
                findState = dataReader.HasRows;
                if (findState)
                {
                    urun_id = Convert.ToString(dataReader.GetValue(0));
                    urun_barkod = Convert.ToString(dataReader.GetValue(1));
                    son_istasyon_id = Convert.ToString(dataReader.GetValue(2));
                    giris_zamani = Convert.ToString(dataReader.GetValue(3));
                    son_istasyon_zamani = Convert.ToString(dataReader.GetValue(4));
                    otherConsoleAppendLine("Ürün Id: " + urun_id, Color.Black);
                    otherConsoleAppendLine("Son İstasyon Id: " + son_istasyon_id, Color.Black);
                    otherConsoleAppendLine("İlk Giriş Zamanı: " + giris_zamani, Color.Black);
                    otherConsoleAppendLine("Son İstasyon Zamanı: " + son_istasyon_zamani, Color.Black);
                    otherConsoleNewLine();

                    dataReader.Close();
                }
                else
                {
                    dataReader.Close();
                    otherConsoleNewLine();
                    otherConsoleNewLine();
                    otherConsoleAppendLine("YANLIŞ BARKOD YA DA ÜRÜN SİSTEM'DE KAYITLI DEĞİL !", Color.Red);
                    otherConsoleAppendLine("LÜTFEN KARTI POTADAN GEÇİRİN !", Color.Red);
                    return false;
                }

                otherConsoleNewLine();
                otherConsoleNewLine();
                if (son_istasyon_id == POTA_ALPLAS_ISTANBUL || son_istasyon_id == POTA_ALPLAS_BOLU || son_istasyon_id == POTA_BRC_ISTANBUL || son_istasyon_id == POTA_BRC_BOLU || son_istasyon_id == POTA_VEKTOR_ALPPLAS_ISTANBUL)
                {
                    otherConsoleAppendLine("KART POTADAN GEÇMİŞ BU İSTASYONA GİREMEZ", Color.Red);
                    return false;
                }
                else if (son_istasyon_id == ICT_BRC_ISTANBUL || son_istasyon_id == ICT_BRC_BOLU_1 || son_istasyon_id == ICT_BRC_BOLU_2 || son_istasyon_id == ICT_BRC_BOLU_3)
                {
                    if (Prog_Ayarlar.Default.ictStation == true)
                    {
                        otherConsoleAppendLine("KART ICT İSTASYONUNDAN GEÇMİŞ BU İSTASYONA ÖZEL OLARAK GİREBİLİR", Color.Green);
                        return true;
                    }
                    else
                    {
                        otherConsoleAppendLine("KART ICT İSTASYONUNDAN GEÇMİŞ BU İSTASYONA GİREMEZ", Color.Red);
                        return false;
                    }
                }
                else if (son_istasyon_id == FCT_MIND_BRC_BOLU || son_istasyon_id == FCT_MIND_IBER_BOLU || son_istasyon_id == FCT_MIND_ALPPLAS_BOLU_1 || son_istasyon_id == FCT_MIND_ALPPLAS_BOLU_2 || son_istasyon_id == FCT_MIND_ALPPLAS_BOLU_3 ||
                    son_istasyon_id == FCT_ARTOUCH_ALPPLAS_BOLU || son_istasyon_id == FCT_VEKTOR_ALPPLAS_ISTANBUL || son_istasyon_id == FCT_ROBINMB_ALPPLAS_ISTANBUL || son_istasyon_id == FCT_ROBINTB_ALPPLAS_ISTANBUL || son_istasyon_id == ALPPLAS_STATION_FRODO_G03)
                {
                    otherConsoleAppendLine("KART FCT İSTASYONUNDAN GEÇMİŞ. BU İSTASYONA GİREBİLİR", Color.Green);
                    return true;
                }
                else if (son_istasyon_id == PAKETLEME_BRC_ISTANBUL || son_istasyon_id == PAKETLEME_BRC_BOLU || son_istasyon_id == PAKETLEME_VEKTOR_ALPPLAS_ISTANBUL || son_istasyon_id == PAKETLEME_ALPPLAS_BOLU)
                {
                    otherConsoleAppendLine("KART PAKETLEMEDEN GEÇMİŞ TEKRAR BU İSTASYONA GİREBİLİR", Color.Green);
                    return true;
                }
                else
                {
                    otherConsoleAppendLine("LÜTFEN KARTI POTADAN GEÇİRİN !", Color.Red);
                    return false;
                }
            }
            catch (Exception ex)
            {
                sqlWriteError();  //ALL READ
                otherConsoleAppendLine("tableRead Error: " + ex.Message, Color.Red);
                return false;
            }
        }

        private bool sqlTestInsert()
        {
            sqlCommonConnection();
            try
            {
                DateTime dt = DateTime.Now;
                string nowYear = Convert.ToString(dt.Year);
                string nowMonth = Convert.ToString(dt.Month);
                string nowDay = Convert.ToString(dt.Day);
                string nowHour = Convert.ToString(dt.Hour);
                string nowMinute = Convert.ToString(dt.Minute);
                string nowSecond = Convert.ToString(dt.Second);
                string mnowSecond = Convert.ToString(dt.Millisecond);
                string firstTime = nowYear + "-" + nowMonth + "-" + nowDay + " " + nowHour + ":" + nowMinute + ":" + nowSecond + "." + mnowSecond;
                string sqlQuery = "INSERT INTO URUN_TESTLER (URUN_ID,MAKINA_NO,TEST_BASLANGIC_ZAMANI,TEST_BITIS_ZAMANI) VALUES('"
                    + urun_id + "'," + "'" + PAKETLEME_ALPPLAS_BOLU + "'," + "'" + firstTime + "'," + "NULL" + ")";
                SqlCommand command = new SqlCommand(sqlQuery, SQLConnection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        otherConsoleAppendLine("SQL Success 1", Color.Green);
                    }
                    else
                    {
                        otherConsoleAppendLine("SQL Success 2", Color.Green);
                    }
                }
                otherConsoleAppendLine("SQL Firt Insert", Color.Green);
                dr.Close();
                return true;
            }
            catch (Exception ex)
            {
                sqlWriteError();  //INSERT
                otherConsoleAppendLine("sqlTestInsert Error: " + ex.Message, Color.Red);
                return false;
            }
        }

        private bool paketInsert()
        {
            sqlCommonConnection();
            try
            {
                string sqlBarcode = modelName.Text + "-" + productionNo;
                for (int i = 1; i <= cardCounter; i++)
                {
                    sqlBarcode = sqlBarcode + "-" + cardStatus[i];
                }
                DateTime dt = DateTime.Now;
                string nowYear = Convert.ToString(dt.Year);
                string nowMonth = Convert.ToString(dt.Month);
                string nowDay = Convert.ToString(dt.Day);
                string nowHour = Convert.ToString(dt.Hour);
                string nowMinute = Convert.ToString(dt.Minute);
                string nowSecond = Convert.ToString(dt.Second);
                string mnowSecond = Convert.ToString(dt.Millisecond);
                string firstTime = nowYear + "-" + nowMonth + "-" + nowDay + " " + nowHour + ":" + nowMinute + ":" + nowSecond + "." + mnowSecond;
                string sqlQuery = "INSERT INTO PAKET (PAKETLEME_ZAMANI,URUN_ADEDI,MAKINA_NO,PAKET_BARKODLARI,ACIKLAMA) VALUES('"
                    + firstTime + "'," + "'" + cardCounter + "'," + "'" + PAKETLEME_ALPPLAS_BOLU + "'," + "'" + sqlBarcode + "'," + "'" + koli_no + "'" + ")";
                SqlCommand command = new SqlCommand(sqlQuery, SQLConnection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        otherConsoleAppendLine("SQL Success 1", Color.Green);
                    }
                    else
                    {
                        otherConsoleAppendLine("SQL Success 2", Color.Green);
                    }
                }
                otherConsoleAppendLine("SQL Firt Insert", Color.Green);
                dr.Close();
                return true;
            }
            catch (Exception ex)
            {
                sqlWriteError();  //INSERT
                otherConsoleAppendLine("sqlTestInsert Error: " + ex.Message, Color.Red);
                return false;
            }
        }

        private bool tableUpdate()
        {
            sqlCommonConnection();
            try
            {
                DateTime dt = DateTime.Now;
                string nowYear = Convert.ToString(dt.Year);
                string nowMonth = Convert.ToString(dt.Month);
                string nowDay = Convert.ToString(dt.Day);
                string nowHour = Convert.ToString(dt.Hour);
                string nowMinute = Convert.ToString(dt.Minute);
                string nowSecond = Convert.ToString(dt.Second);
                string mnowSecond = Convert.ToString(dt.Millisecond);
                string lastTime = nowYear + "-" + nowMonth + "-" + nowDay + " " + nowHour + ":" + nowMinute + ":" + nowSecond + "." + mnowSecond;

                string sqlQuery = "UPDATE URUNLER SET SON_ISTASYON_ID='" + PAKETLEME_ALPPLAS_BOLU + "'" + ",SON_ISTASYON_ZAMANI='" + lastTime + "'" + ",URUN_DURUM_NO='" + URUN_DURUM_HAZIR + "'" + ",ARIZA_KODU='" + "0" + "'" + ",SON_ISLEM_TAMAMLANDI='" + "1" + "'" + "WHERE URUN_ID='" + urun_id + "'";
                //string sqlQuery = "UPDATE URUNLER SET SON_ISTASYON_ID='" + PAKETLEME_ALPPLAS_BOLU + "'" + ",URUN_DURUM_NO='" + URUN_DURUM_HAZIR + "'" + ",ARIZA_KODU='" + "0" + "'" + ",SON_ISLEM_TAMAMLANDI='" + "1" + "'" + "WHERE URUN_ID='" + urun_id + "'";
                SqlCommand command = new SqlCommand(sqlQuery, SQLConnection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        otherConsoleAppendLine("SQL Success 1", Color.Green);
                    }
                    else
                    {
                        otherConsoleAppendLine("SQL Success 2", Color.Green);
                    }
                }
                otherConsoleAppendLine("Kart Veritabanında Güncellendi", Color.Green);
                dr.Close();
                return true;
            }
            catch (Exception ex)
            {
                sqlWriteError();
                otherConsoleAppendLine("sqlUpdate Error: " + ex.Message, Color.Red);
                return false;
            }
        }

        #region Events

        /****************************************** Son İstasyon *************************************************/
        private void btnPacketEnd_Click(object sender, EventArgs e)
        {
            packetEnd();
        }

        private void packetEnd()
        {
            vardiyaCounter();
            printerFunction();
            paketInsert();
            resetAll();
            matrisAdd();
            sonucCard.ForeColor = Color.Black;
            sonucCard.BackColor = Color.Green;
            sonucCard.Text = "Paket Tamamlandı";
            Thread.Sleep(1500);
            sonucCard.ForeColor = Color.Black;
            sonucCard.BackColor = Color.Transparent;
            sonucCard.Text = "Paketlemeye Tekrardan Başlayabilirsiniz";
        }

        private void vardiyaCounter()  //VARDIYA AKSİYON
        {
            try
            {
                DateTime dt = DateTime.Now;
                string nowYear = Convert.ToString(dt.Year);
                string nowMonth = Convert.ToString(dt.Month);
                string nowDay = Convert.ToString(dt.Day);
                string nowHour = Convert.ToString(dt.Hour);
                string nowMinute = Convert.ToString(dt.Minute);

                int hour = Convert.ToInt32(nowHour);
                if (hour >= 0 && hour < 8)
                {
                    aVardiyaNum++;
                    bVardiyaNum = 0;
                    cVardiyaNum = 0;
                    vardiyaString = "A" + "-" + Convert.ToString(aVardiyaNum);
                }
                else if (hour >= 8 && hour < 16)
                {
                    bVardiyaNum++;
                    aVardiyaNum = 0;
                    cVardiyaNum = 0;
                    vardiyaString = "B" + "-" + Convert.ToString(bVardiyaNum);
                }
                else if (hour >= 16 && hour <= 23)
                {
                    cVardiyaNum++;
                    bVardiyaNum = 0;
                    aVardiyaNum = 0;
                    vardiyaString = "C" + "-" + Convert.ToString(cVardiyaNum);
                }
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("vardiyaCounter: " + ex.Message, Color.Red);
            }
        }

       private void printerFunction()  //PRINTER AKSİYON
        {
            try
            {
                DateTime dt = DateTime.Now;
                string nowYear = Convert.ToString(dt.Year);
                string nowMonth = Convert.ToString(dt.Month);
                string nowDay = Convert.ToString(dt.Day);
                string nowHour = Convert.ToString(dt.Hour);
                string nowMinute = Convert.ToString(dt.Minute);

                //string productPrintDate = nowDay + "." + nowMonth + "." + nowYear;

                if (nowMonth.Length < 2)
                {
                    nowMonth = "0" + nowMonth;
                }
                if (nowDay.Length < 2)
                {
                    nowDay = "0" + nowDay;
                }
                if (nowHour.Length < 2)
                {
                    nowHour = "0" + nowHour;
                }
                if (nowMinute.Length < 2)
                {
                    nowMinute = "0" + nowMinute; 
                }
                string dateNew = nowDay + "." + nowMonth + "." + nowYear;

                int code = dt.Month * 60 * 24 * 30 + dt.Day * 60 * 24 + dt.Hour * 60 + dt.Minute;
                koli_no = "S" + Convert.ToString(code);

                if (Prog_Ayarlar.Default.partiNo == true)
                {
                    for (int i = 0; i < productionNo.Length; i++)
                    {
                        if (productionNo.Substring(i, 1) != "0")
                        {
                            newProductionNo = newProductionNo + productionNo.Substring(i, productionNo.Length - i);
                            break;
                        }
                    }
                }
                else
                {
                    if (partiNo.Text.Length == 8)
                    {
                        newProductionNo = partiNo.Text;
                    }
                    else
                    {
                        while (number1.ToString().Length != 8)
                        {
                            FormMessageTxt formMessageTxt = new FormMessageTxt(this);
                            formMessageTxt.ShowDialog();
                        }
                        newProductionNo = number1.ToString();
                    }
                }

                string test = "";
                string qr1 = "";
                for (int i = 1; i <= cardCounter; i++)
                {
                    qr1 = qr1 + "-" + cardStatus[i];
                }
                string start1 = "^XA";
                string png = "^FO30,30^GFA," + pngString;   //Acron Logo
                string start2 = "^LH" + Prog_Ayarlar.Default.printerPos;
                string line1 = "^FO5,5^GB3,540,2^FS" + "^FO220,180^GB3,365,2^FS" + "^FO780,5^GB3,540,2^FS" + "^FO5,3^GB778,3,2^FS" + "^FO8,180^GB775,3,2^FS" + "^FO5,545^GB778,3,2^FS"; //Çizgiler
                string line2 = "^FO600,400^GB180,3,2^FS" + "^FO600,400^GB3,145,2^FS" ; //Çizgiler
                string qr = "^FO610,5^" + "^BQN,4,4" + "^FDQA," + koli_no + ",M" + SAPStrings[0] + ",PMD-" + newProductionNo + ",U" + dateNew + ",Q" + cardCounter + "^FS";  //QR
                string veri0 = "^FO635,155" + "^A0,25,25" + "^FD" + koli_no + "^FS";
                string kalite = "^FO645,435" + "^A0,35,35" + "^FD" + "Kalite" + "^FS";
                string kontrol = "^FO640,490" + "^A0,35,35" + "^FD" + "Kontrol" + "^FS";
                string veri1 = "^FO20,190" + "^A0,40,40" + "^FD" + "PARCA NO" + "^FS";
                string veri11 = "^FO230,190" +"^A0,40,40" + "^FD" + SAPStrings[0] + "^FS";
                string veri2 = "^FO20,260" + "^A0,40,40" + "^FD" + "PARCA ADI" + "^FS";
                string veri22 = "^CFA,25" + "^FO235,245" + "^FD" + modelString + "^FS";
                string veri222 = "^CFA,25" + "^FO235,280" + "^FD" + gerberString + "^FS";
                string veri3 = "^FO20,325" + "^A0,40,40" + "^FD" + "U.TARIHI" + "^FS";
                string veri33 = "^CFA,35" + "^FO235,325" + "^FD" + dateNew + "^FS";
                string veri4 = "^FO20,370" + "^A0,40,40" + "^FD" + "U.ADETI" + "^FS";
                string veri44 = "^CFA,35" + "^FO235,370" + "^FD" + cardCounter + "^FS";
                string veri5 = "^FO20,415" + "^A0,40,40" + "^FD" + "VARDIYA" + "^FS";
                string veri55 = "^CFA,35" + "^FO235,415" + "^FD" + vardiyaString + "^FS";
                string veri6 = "^FO20,460" + "^A0,40,40" + "^FD" + "PARTI NO" + "^FS";
                string veri66 = "^CFA,35" + "^FO235,460" + "^FD" + newProductionNo + "^FS";
                string veri7 = "^FO20,505" + "^A0,40,40" + "^FD" + "G/T. ADI" + "^FS";
                string veri77 = "^CFA,35" + "^FO235,505" + "^FD" + oparatorName1.Text + "/" + oparatorName2.Text + "^FS";
                string end = "^XZ";
                test = start1 + png + start2 + line1 + line2 + qr + kalite + kontrol + veri0 + veri1 + veri11 + veri2 + veri22 + veri222 + veri3 + veri33 + veri4 + veri44 + veri5 + veri55 + veri6 + veri66 + veri7 + veri77 + end;

                //Get local print server
                var server = new LocalPrintServer();

                //Load queue for correct printer
                PrintQueue pq = server.GetPrintQueue(printerName, new string[0] { });
                PrintJobInfoCollection jobs = pq.GetPrintJobInfoCollection();
                foreach (PrintSystemJobInfo job in jobs)
                {
                    job.Cancel();
                }

                if (!RawPrinterHelper.SendStringToPrinter(printerName, test))
                {
                    otherConsoleAppendLine("Printer Error1: ", Color.Red);
                }
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("Printer Error2: " + ex.Message, Color.Red);
            }
        }

        /*
        private void printerFunction2(string barcode, string eps, string product_date, string expiration_date, string package_date, string cabine_out_date, string cabine_expiration_date, string msl, string life_time, string quantity)  //PRINTER AKSİYON
        {
            try
            {
                string start1 = "^XA";
                string start2 = "^LH" + Prog_Ayarlar.Default.printerPos + "^FX";
                string font1 = "^CF0,20";
                string veri0 = "^FO130,10" + "^FD" + "NEM DOLABI TAKIP ETIKETI" + "^FS";
                string line1 = "^FO5,40^GB300,1,1^FS" + "^FO5,160^GB300,1,1^FS" + "^FO5,40^GB1,120,1^FS" + "^FO305,40^GB1,121,1^FS";
                string font2 = "CF0,15";
                string veri1 = "^FO20,50" + "^FD" + eps + "^FS";
                string veri2 = "^FO20,80" + "^FDURETIM TARIHI: " + product_date + "^FS";
                string veri3 = "^FO20,110" + "^FDSON KULLANMA TARIHI: " + expiration_date + "^FS";
                string veri4 = "^FO20,140" + "^FDPAKET ACILMA TARIHI: " + package_date + "^FS";
                //font1 tekrar
                string line2 = "^FO5,180^GB300,2,1^FS" + "^FO5,240^GB300,2,1^FS" + "^FO5,180^GB2,60,1^FS" + "^FO305,180^GB2,61,1^FS";
                string veri5 = "^FO40,190" + "^FDDOLAPTAN CIKIS TARIHI" + "^FS";
                string veri6 = "^FO100,215" + "^FD" + cabine_out_date + "^FS";
                string line3 = "^FO5,250^GB300,2,1^FS" + "^FO5,310^GB300,2,1^FS" + "^FO5,250^GB2,60,1^FS" + "^FO305,250^GB2,61,1^FS";
                string veri7 = "^FO12,260" + "^FDDOLAP DISI SON KULLANIM TARIHI" + "^FS";
                string veri8 = "^FO100,285" + "^FD" + cabine_expiration_date + "^FS";

                string line4 = "^FO312,40^GB160,1,1^FS" + "^FO312,160^GB160,1,1^FS" + "^FO312,40^GB1,120,1^FS" + "^FO472,40^GB1,121,1^FS";
                string veri9 = "^FO317,50" + "^FDMSL:" + msl + "^FS";
                string veri10 = "^FO317,90" + "^FDKALAN SURE:" + life_time + "^FS";
                string veri11 = "^FO317,130" + "^FDADET:" + quantity + "^FS";

                string qr = "^FO330,170" + "^BQN,3,3" + "^FDQA," + barcode + "^FS";  //QR
                string end = "^XZ";
                string test = start1 + start2 + font1 + veri0 + line1 + font2 + veri1 + veri2 + veri3 + veri4 + font1 + line2 + veri5 + veri6 + line3 + veri7 + veri8 + line4 + veri9 + veri10 + veri11 + qr + end;

                //Get local print server
                var server = new LocalPrintServer();

                //Load queue for correct printer
                PrintQueue pq = server.GetPrintQueue(printerName, new string[0] { });
                PrintJobInfoCollection jobs = pq.GetPrintJobInfoCollection();
                foreach (PrintSystemJobInfo job in jobs)
                {
                    job.Cancel();
                }

                if (!RawPrinterHelper.SendStringToPrinter(printerName, test))
                {
                    otherConsoleAppendLine("Printer Error1: ", Color.Red);
                }
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("Printer Error2: " + ex.Message, Color.Red);
            }
        }
        */

        private int characterScaleConvert(int alan, int fontSize, int length)
        {
            double modelStringCharacterSize = (double)((double)alan / (double)(fontSize * 2));
            double modelStringScale = (double)length * modelStringCharacterSize;    //230-750 = 520/30 = 17.33/2 = 8.7
            int initPoint = 490 + Convert.ToInt32(modelStringCharacterSize);    //alan / 2 = 260 + min = 490
            return initPoint - Convert.ToInt32(modelStringScale);
        }


        //string[] SAPStrings;
        //string modelString = "";
        private void resetAll()
        {
            cardCounter = 0;
            for (int i = 0; i < 48; i++)
            {
                cardStatus[i] = i.ToString();
            }
            newProductionNo = "";
            koli_no = "";
            vardiyaString = "";
        }

        /************************************* MATRIS ******************************************************/
        private void packetNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(packetNumber.Text) <= 48)
                {
                    matrisAdd();
                }
                else
                {
                    CustomMessageBox.ShowMessage("Koli Adet Sayısı 48'den Büyük Olamaz", Prog_Ayarlar.Default.projectName, MessageBoxButtons.OK, CustomMessageBoxIcon.Error, Color.Red);
                    packetNumber.Text = "";
                }
            }
            catch (Exception ex)
            {
                //otherConsoleAppendLine("Printer Error2: " + ex.Message, Color.Red);
            }
        }

        private void matrisAdd()
        {
            try
            {
                panel1.Controls.Clear();                //Paneli temizle
                int max_size_w = panel1.Width;                              //Panelin Maksimum genişliği
                int max_size_h = panel1.Height;                             //Panelin Maksimum yüksekliği

                matrisCounter = 0;                              //Sayacı sıfırla
                int packetNumberStatic = Convert.ToInt16(packetNumber.Text);

                if (packetNumberStatic <= 36)
                {
                    txt_Row = packetNumberStatic / 6;  //Aldığımız Satır bilgisi.
                    txt_Column = 6;              //Aldığımız Sutün bilgisi
                    txt_Kalan = packetNumberStatic - (txt_Row * 6);
                    if (txt_Kalan > 0)
                        txt_Row = txt_Row + 1;
                }
                else if (packetNumberStatic > 36 && packetNumberStatic <= 42)
                {
                    txt_Row = packetNumberStatic / 7;  //Aldığımız Satır bilgisi.
                    txt_Column = 7;              //Aldığımız Sutün bilgisi
                    txt_Kalan = packetNumberStatic - (txt_Row * 7);
                    if (txt_Kalan > 0)
                        txt_Row = txt_Row + 1;
                }
                else if (packetNumberStatic > 42 && packetNumberStatic <= 48)
                {
                    txt_Row = packetNumberStatic / 8;  //Aldığımız Satır bilgisi.
                    txt_Column = 8;              //Aldığımız Sutün bilgisi
                    txt_Kalan = packetNumberStatic - (txt_Row * 8);
                    if (txt_Kalan > 0)
                        txt_Row = txt_Row + 1;
                }


                int btn_size_w = max_size_w / txt_Column;         //Maksimum genişliğe sutun sayısını girerek butonun boyutu belirlenir.
                int btn_size_h = max_size_h / txt_Row;             //Maksimum yüksekliğe satır sayısını girerek butonun boyutu belirlenir.

                int loc_x;
                int loc_y;

                Dizi = new Button[txt_Row, txt_Column];                                  //Dizi tanımlaması.
                if (packetNumberStatic <= 50)
                {
                    for (int row_index = 0; row_index < txt_Row; row_index++)
                    {
                        for (int coloumn_index = 0; coloumn_index < txt_Column; coloumn_index++)
                        {
                            matrisCounter++;
                            if (matrisCounter > packetNumberStatic)
                                break;
                            Button btn = new Button();
                            //btn.Text = matrisCounter.ToString();                        //Buton text ismi
                            btn.Text = cardStatus[matrisCounter];                        //Buton Design name
                            btn.Name = matrisCounter.ToString();                        //Buton Design name

                            btn.Enabled = false;                                //Butona tıklanmaması için.
                            btn.Size = new Size(btn_size_w, btn_size_h);        //Buton boyutu
                            btn.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));

                            loc_x = coloumn_index * btn_size_w;                 //Butonun X eksenindeki yeri
                            loc_y = row_index * btn_size_h;                     //Butonun Y eksenindeki yeri
                            btn.Location = new Point(loc_x, loc_y);

                            // panel1.Controls.Add(btn);                           //Panele ekle.
                            try
                            {
                                this.Invoke((MethodInvoker)delegate ()
                                {
                                    panel1.Controls.Add(btn);                           //Panele ekle.
                                    Dizi[row_index, coloumn_index] = btn;               //Diziye doldur.
                                });
                            }
                            catch (Exception ex)
                            {
                                otherConsoleAppendLine("Dizi Hatası: " + ex.Message, Color.Red);
                            }
                        }
                    }
                }
                else
                {
                    CustomMessageBox.ShowMessage("Koli Adeti 42'den Büyük Olamaz.!", customMessageBoxTitle, MessageBoxButtons.OK, CustomMessageBoxIcon.Error, Color.Red);
                }
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("matrisAdd: " + ex.Message, Color.Red);
            }
            //Dizi[i, j].BackColor = Color.Red;
        }

        /********************************************** Ortak Tüm Ana İşlemlerin Yönlendirilmesi************************************************/
        public void yetkidegistir()
        {
            if (this.yetki == 0)
            {
                this.btnAyar.Enabled = false;
                btnAyar.BackColor = Color.Gray;
            }
            if (this.yetki == 1)
            {
                this.btnAyar.Enabled = true;
                btnAyar.BackColor = Color.Red;
                timerAdmin.Start();
            }
            if (this.yetki == 2)
            {
                this.btnAyar.Enabled = true;
                btnAyar.BackColor = Color.Red;
                timerAdmin.Start();
            }
        }

        private void btnAyar_Click(object sender, EventArgs e)
        {
            int num = (int)this.ProgAyarFrm.ShowDialog();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData != Keys.L)
                return false;
            if (this.yetki != 0)
            {
                timerAdmin.Stop();
                this.yetki = 0;
                this.yetkidegistir();
            }
            else
            {
                try { int num = (int)this.SifreFrm.ShowDialog(); }
                catch (Exception) { }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void timerAdmin_Tick(object sender, EventArgs e)
        {
            adminTimerCounter++;
            if (adminTimerCounter == 1)
            {
                adminTimerCounter = 0;
                timerAdmin.Stop();
                this.yetki = 0;
                this.yetkidegistir();
            }
        }

        private void rtbConsole_TextChanged(object sender, EventArgs e)
        {
            RichTextBox rtb1 = sender as RichTextBox;
            rtb1.SelectionStart = rtb1.Text.Length;
            rtb1.ScrollToCaret();
        }

        /********************************************** Diğer Konsol ************************************************/
        private void rtbConsoleOther_TextChanged(object sender, EventArgs e)
        {
            RichTextBox rtb2 = sender as RichTextBox;
            rtb2.SelectionStart = rtb2.Text.Length;
            rtb2.ScrollToCaret();
        }

        /*Kullanıcı Arayüzüne Temizlenir*/
        public void otherConsoleClean()
        {
            if (rtbConsoleOther.InvokeRequired)
            {
                rtbConsoleOther.Invoke(new Action(delegate ()
                {
                    rtbConsoleOther.Text = "";
                    rtbConsoleOther.Select(rtbConsoleOther.TextLength, 0);
                    rtbConsoleOther.SelectionColor = Color.White;
                }));
            }
            else
            {
                rtbConsoleOther.Text = "";
                rtbConsoleOther.Select(rtbConsoleOther.TextLength, 0);
                rtbConsoleOther.SelectionColor = Color.White;
            }
        }

        /*Kullanıcı Arayüzüne Yazı Yazılır*/
        public void otherConsoleAppendLine(string text, Color color)
        {
            if (rtbConsoleOther.InvokeRequired)
            {
                rtbConsoleOther.Invoke(new Action(delegate ()
                {
                    rtbConsoleOther.Select(rtbConsoleOther.TextLength, 0);
                    rtbConsoleOther.SelectionColor = color;
                    rtbConsoleOther.AppendText(text + Environment.NewLine);
                    rtbConsoleOther.Select(rtbConsoleOther.TextLength, 0);
                    rtbConsoleOther.SelectionColor = Color.White;
                }));
            }
            else
            {
                rtbConsoleOther.Select(rtbConsoleOther.TextLength, 0);
                rtbConsoleOther.SelectionColor = color;
                rtbConsoleOther.AppendText(text + Environment.NewLine);
                rtbConsoleOther.Select(rtbConsoleOther.TextLength, 0);
                rtbConsoleOther.SelectionColor = Color.White;
            }
        }

        /*Kullanıcı Arayüzünde Bir Satır Boşluk Bırakılır*/
        public void otherConsoleNewLine()
        {
            if (rtbConsoleOther.InvokeRequired)
            {
                rtbConsoleOther.Invoke(new Action(delegate () { rtbConsoleOther.AppendText(Environment.NewLine); }));
            }
            else
            {
                rtbConsoleOther.AppendText(Environment.NewLine);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            packetNumber.Text = Convert.ToString(modelsNumber[modelName.SelectedIndex]);
            modelStringParse();
            gerberStringParse();
        }

        private void modelStringParse()
        {
            try
            {
                modelString = "";
                SAPStrings = modelName.Text.Split('-');
                for (int i = 1; i < SAPStrings.Length - 2; i++)
                {
                    if (i == SAPStrings.Length - 3)
                        modelString = modelString + SAPStrings[i];
                    else
                        modelString = modelString + SAPStrings[i] + "-";
                }
                SAPStrings[0] = Convert.ToString(SAPStrings[0]).Substring(1, 9);
                otherConsoleAppendLine(SAPStrings[0], Color.Blue);
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("modelStringParse: " + ex.Message, Color.Red);
            }
        }

        private void gerberStringParse()
        {
            try
            {
                gerberString = "";
                GerberStrings = modelName.Text.Split('G');
                gerberString = "G" + GerberStrings[1];
            }
            catch (Exception ex)
            {
                otherConsoleAppendLine("gerberStringParse: " + ex.Message, Color.Red);
            }
        }

    }
}
#endregion
