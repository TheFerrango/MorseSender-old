using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Morse_sender.Langs;

namespace Morse_sender
{
  public partial class ShareControl : UserControl
  {
    string MorseMsg;

    public ShareControl(string morseMsg)
    {
      InitializeComponent();
      MorseMsg = morseMsg;
    }

    private void shareMail_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      EmailComposeTask emc = new EmailComposeTask();
      emc.Body = MorseMsg + Environment.NewLine + AppResources.SentFrom;
      emc.Subject = AppResources.MailSub;
      emc.Show();
    }

    private void shareSms_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      SmsComposeTask smt = new SmsComposeTask();
      smt.Body = MorseMsg + Environment.NewLine + AppResources.SentFrom;
      smt.Show();
    }

    private void shareSoc_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      ShareStatusTask sst = new ShareStatusTask();
      sst.Status = MorseMsg + Environment.NewLine + AppResources.SentFrom;
      sst.Show();
    }
  }
}
