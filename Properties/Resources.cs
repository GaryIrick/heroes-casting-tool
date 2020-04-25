// Decompiled with JetBrains decompiler
// Type: TeamNames.Properties.Resources
// Assembly: TeamNames, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8FFB8F9-B510-4DB5-9B72-32ABE923C476
// Assembly location: C:\Users\Gary\Documents\Casting\NGS Overlay Controller S7.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace TeamNames.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (TeamNames.Properties.Resources.resourceMan == null)
          TeamNames.Properties.Resources.resourceMan = new ResourceManager("TeamNames.Properties.Resources", typeof (TeamNames.Properties.Resources).Assembly);
        return TeamNames.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return TeamNames.Properties.Resources.resourceCulture;
      }
      set
      {
        TeamNames.Properties.Resources.resourceCulture = value;
      }
    }
  }
}
