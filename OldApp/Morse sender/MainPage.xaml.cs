﻿using System;
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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Threading;
using System.Windows.Controls.Primitives;
using Coding4Fun.Toolkit.Controls;
using Morse_sender.Langs;

namespace Morse_sender
{
  public partial class MainPage : PhoneApplicationPage
  {
    SoundEffect dot, dash, shortp;

    string tmpMorse;

    bool isPlaying = false;
    bool loaded;
    bool toMorse;
    // Constructor
    public MainPage()
    {
      InitializeComponent();
      loaded = false;
      
    }

    private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
      if (!loaded)
      {
        if (!App.HasBeenStarted)
        {
          MessageBox.Show(Langs.AppResources.MsgBoxStart);
          App.HasBeenStarted = true;
        }
        toMorse = true;
        radioT2m.IsChecked = true;
        txtToMorsefy_TextChanged(null, null);

        dot = SoundEffect.FromStream(TitleContainer.OpenStream("Sound/dot.wav"));
        dash = SoundEffect.FromStream(TitleContainer.OpenStream("Sound/dash.wav"));
        shortp = SoundEffect.FromStream(TitleContainer.OpenStream("Sound/smpause.wav"));
        FrameworkDispatcher.Update();

        loaded = true;
      }
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
      toMorse = radioT2m.IsChecked == true ? true : false;
      txtToMorsefy_TextChanged(null, null);
    }
    
    private void aboBtn_Click(object sender, EventArgs e)
    {
      NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
    }

    private void playBtn_Click(object sender, EventArgs e)
    {
      if (radioT2m.IsChecked == true)
      {
        if (!isPlaying)
        {
          isPlaying = true;
          tmpMorse = lblMorsed.Text;
          Thread t = new Thread(StartPlaying);
          t.Start();
        }
      }
      else
        MessageBox.Show(AppResources.PlayErrTxt, AppResources.PlayErrTit, MessageBoxButton.OK);
    }

    private void StartPlaying()
    {   
        foreach (char ch in tmpMorse)
          riproduci(ch);              
        isPlaying = false;
    }

    public void PlaySound(SoundEffect effect)
    {
      effect.Play();
      Thread.Sleep(effect.Duration);      
    }

    private void riproduci(char ch)
    {
      switch (ch)
      {
        case '.': PlaySound(dot); break;
        case '-': PlaySound(dash); break;
        case ' ': PlaySound(shortp); break;
        default: break;
      }
    }

    private void shareBtn_Click(object sender, EventArgs e)
    {
      MessagePrompt mp = new MessagePrompt();
      mp.ActionPopUpButtons.Clear();
      mp.Body = new ShareControl(lblMorsed.Text);
      mp.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
      mp.Show();
    }

  }
}
