using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ICSharpCode.AvalonEdit;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using System.Web.UI;
using System.Threading;

namespace WPFSomeThing
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Fonter.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            FontSizer.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        }

        private void Sound()
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"C:\Users\Gigabyte\source\repos\WPFSomeThing\WPFSomeThing\Sounds\MouseClick.mp3"));
            mediaPlayer.Play();
        }


        private void Load1_Click(object sender, RoutedEventArgs e)
        {
            Sound();

            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Json files (*.json)|*.json|All files (*.*)|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                Vsyakoe.Load(dlg.FileName);
                FIleNameLabel.Content = dlg.SafeFileName;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Sound();

            SaveFileDialog dlg = new SaveFileDialog
            {
                Filter = "Json files (*.json)|*.json|All files (*.*)|*.*",
                RestoreDirectory = true

        };
            if (dlg.ShowDialog() == true)
            {
                Vsyakoe.Save(File.Create(dlg.FileName));
            }
        }

        private void Fonter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Vsyakoe.FontFamily = (FontFamily)Fonter.SelectedItem;
        }

        private void FontSizer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Vsyakoe.FontSize = Convert.ToDouble(FontSizer.SelectedItem);
        }

        private void CollapseButton_Click(object sender, RoutedEventArgs e)
        {
            Sound();

            this.WindowState = WindowState.Minimized;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Sound();

            Thread.Sleep(400);

            Close();
        }
    }
}
