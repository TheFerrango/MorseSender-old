using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Morse_sender
{
  public class Locales
  {
    public Locales()
    {
    
    }

    private static Langs.AppResources localizedResources = new Langs.AppResources();

    public Langs.AppResources LocalizedResources { get { return localizedResources; } }
  }
}
