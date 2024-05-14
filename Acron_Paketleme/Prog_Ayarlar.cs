// Decompiled with JetBrains decompiler
// Type: EsdTurnikesi.Ayarlar
// Assembly: EsdTurnikesi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C8099926-BBEB-495E-ADF6-36B4F5F75BE8
// Assembly location: C:\Users\serkan.baki\Desktop\esd-rar\ESD\Release\EsdTurnikesi.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO.Ports;
using System.Runtime.CompilerServices;

namespace Acron_Paketleme
{
    [CompilerGenerated]
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed class Prog_Ayarlar : ApplicationSettingsBase
    {
        private static Prog_Ayarlar defaultInstance = (Prog_Ayarlar)SettingsBase.Synchronized((SettingsBase)new Prog_Ayarlar());

        private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
        {
        }

        private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
        {
        }

        public static Prog_Ayarlar Default
        {
            get
            {
                return Prog_Ayarlar.defaultInstance;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Kitaplıklar\\Belgeler\\logpersonel.accdb")]
        public string gDosyaYolu
        {
            get
            {
                return (string)this[nameof(gDosyaYolu)];
            }
            set
            {
                this[nameof(gDosyaYolu)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Kitaplıklar\\Belgeler\\logpersonel.accdb")]
        public string tDosyaYolu
        {
            get
            {
                return (string)this[nameof(tDosyaYolu)];
            }
            set
            {
                this[nameof(tDosyaYolu)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("false")]
        public bool ictStation
        {
            get
            {
                return (bool)this[nameof(ictStation)];
            }
            set
            {
                this[nameof(ictStation)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("true")]
        public bool partiNo
        {
            get
            {
                return (bool)this[nameof(partiNo)];
            }
            set
            {
                this[nameof(partiNo)] = (object)value;
            }
        }


        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Kitaplıklar\\Belgeler\\logpersonel.accdb")]
        public string iniDosyaYolu
        {
            get
            {
                return (string)this[nameof(iniDosyaYolu)];
            }
            set
            {
                this[nameof(iniDosyaYolu)] = (object)value;
            }
        }


        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string printerName
        {
            get
            {
                return (string)this[nameof(printerName)];
            }
            set
            {
                this[nameof(printerName)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string printerPos
        {
            get
            {
                return (string)this[nameof(printerPos)];
            }
            set
            {
                this[nameof(printerPos)] = (object)value;
            }
        }


        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1903")]
        public string adminSifre
        {
            get
            {
                return (string)this[nameof(adminSifre)];
            }
            set
            {
                this[nameof(adminSifre)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1903")]
        public string kaliteSifre
        {
            get
            {
                return (string)this[nameof(kaliteSifre)];
            }
            set
            {
                this[nameof(kaliteSifre)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string projectName
        {
            get
            {
                return (string)this[nameof(projectName)];
            }
            set
            {
                this[nameof(projectName)] = (object)value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1000")]
        public int timerAdmin
        {
            get
            {
                return (int)this[nameof(timerAdmin)];
            }
            set
            {
                this[nameof(timerAdmin)] = (object)value;
            }
        }
    }
}
