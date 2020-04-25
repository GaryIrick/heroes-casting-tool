// Decompiled with JetBrains decompiler
// Type: TeamNames.Properties.Settings
// Assembly: TeamNames, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8FFB8F9-B510-4DB5-9B72-32ABE923C476
// Assembly location: C:\Users\Gary\Documents\Casting\NGS Overlay Controller S7.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace TeamNames.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        Settings defaultInstance = Settings.defaultInstance;
        return defaultInstance;
      }
    }
  }
}
