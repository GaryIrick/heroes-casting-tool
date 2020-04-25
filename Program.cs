// Decompiled with JetBrains decompiler
// Type: TeamNames.Program
// Assembly: TeamNames, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8FFB8F9-B510-4DB5-9B72-32ABE923C476
// Assembly location: C:\Users\Gary\Documents\Casting\NGS Overlay Controller S7.exe

using System;
using System.Windows.Forms;

namespace TeamNames
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new WholeForm());
    }
  }
}
