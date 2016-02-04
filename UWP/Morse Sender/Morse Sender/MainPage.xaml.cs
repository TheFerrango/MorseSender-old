using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Il modello di elemento per la pagina vuota è documentato all'indirizzo http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x410

namespace Morse_Sender
{
    /// <summary>
    /// Pagina vuota che può essere utilizzata autonomamente oppure esplorata all'interno di un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
		AudioPlayer audioPlayer;
		string tmpMorse;
		bool isPlaying = false;
		bool loaded;
		bool toMorse;

		public MainPage()
        {
            this.InitializeComponent();
			audioPlayer = new AudioPlayer();
			loaded = false;
        }

		private void txtToMorsefy_TextChanged(object sender, TextChangedEventArgs e)
		{
			lblMorsed.Text = toMorse ? MorseConverters.ConvertToMorse(txtToMorsefy.Text) : MorseConverters.ConvertToText(txtToMorsefy.Text);
		}

		private async void Page_Loaded(object sender, RoutedEventArgs e)
		{
			if (!loaded)
			{
				//if (!App.HasBeenStarted)
				//{
				//	MessageBox.Show(Langs.AppResources.MsgBoxStart);
				//	App.HasBeenStarted = true;
				//}
				toMorse = true;
				radioT2m.IsChecked = true;
				txtToMorsefy_TextChanged(null, null);

				StorageFile wavHolder = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Sound/dot.wav"));
				await audioPlayer.LoadFileAsync(wavHolder);
				
				wavHolder = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Sound/dash.wav"));			
				await audioPlayer.LoadFileAsync(wavHolder);

				wavHolder = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Sound/smpause.wav"));
				await audioPlayer.LoadFileAsync(wavHolder);

				loaded = true;
			}
		}

		private void radioT2m_Checked(object sender, RoutedEventArgs e)
		{
			toMorse = radioT2m.IsChecked == true ? true : false;
			txtToMorsefy_TextChanged(null, null);
		}

		private void AppBarButtonShare_Tapped(object sender, TappedRoutedEventArgs e)
		{
			DataTransferManager dtm = DataTransferManager.GetForCurrentView();
			dtm.DataRequested += Dtm_DataRequested;
			DataTransferManager.ShowShareUI();
		}

		private void Dtm_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
		{
			var rqst = args.Request;
			rqst.Data.Properties.Title = "A Morse message";
			rqst.Data.SetText(lblMorsed.Text);
		}

		private async void AppBarButtonPlay_Tapped(object sender, TappedRoutedEventArgs e)
		{
			if (radioT2m.IsChecked == true)
			{
				if (!isPlaying)
				{
					isPlaying = true;
					tmpMorse = lblMorsed.Text;					
					foreach (char ch in tmpMorse)
						await Riproduci(ch);
					isPlaying = false;
				}
			}
		}

		private async Task Riproduci(char ch)
		{
			switch (ch)
			{
				case '.': await audioPlayer.Play("dot.wav", 0.5); break;
				case '-': await audioPlayer.Play("dash.wav", 0.5); break;
				case ' ': await audioPlayer.Play("smpause.wav", 0.5); break;
				default: break;
			}
		}
	}
}
