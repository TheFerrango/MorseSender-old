using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace Morse_sender
{
  public partial class MainPage : PhoneApplicationPage
  {
    bool toMorse;
    // Constructor
    public MainPage()
    {
      InitializeComponent();
    }

    private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
      MessageBox.Show(Langs.AppResources.MsgBoxStart);
      toMorse = true;
      radioT2m.IsChecked = true;
      txtToMorsefy_TextChanged(null, null);
    } 

    private void txtToMorsefy_TextChanged(object sender, TextChangedEventArgs e)
    {
      lblMorsed.Text = toMorse ? MorseConverters.ConvertToMorse(txtToMorsefy.Text) : MorseConverters.ConvertToText(txtToMorsefy.Text);
    }

    private void sndSMS_Click(object sender, EventArgs e)
    {
      SmsComposeTask sct = new SmsComposeTask();
      sct.Body = lblMorsed.Text;
      sct.Show();
    }

    private void sndMail_Click(object sender, EventArgs e)
    {
      EmailComposeTask ect = new EmailComposeTask();
      ect.Body = lblMorsed.Text;
      ect.Show();
    }

    private void postShare_Click(object sender, EventArgs e)
    {
      ShareStatusTask sst = new ShareStatusTask();
      sst.Status = lblMorsed.Text;
      sst.Show();
    }

    private void saveClip_Click(object sender, EventArgs e)
    {
      Clipboard.SetText(lblMorsed.Text);
    }    

    private void StackPanel_GotFocus(object sender, RoutedEventArgs e)
    {
      txtToMorsefy.SelectAll();
    }

    private void radioT2m_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      toMorse = radioT2m.IsChecked == true? true : false;
      txtToMorsefy_TextChanged(null, null);
    }

      
  }
}