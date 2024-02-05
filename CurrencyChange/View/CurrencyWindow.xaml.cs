using System;
using System.Collections;
using System.Collections.Generic;
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

namespace CurrencyChange
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            var ComboBox = new ComboBox();
            ComboBox.Height = 54;
            ComboBox.Width = 100;
            ComboBox.HorizontalAlignment = HorizontalAlignment.Left;

            var Label = new Label();
            Label.Height = 50;
            Label.Width = 150;
            Label.HorizontalContentAlignment = HorizontalAlignment.Center;
            Label.VerticalContentAlignment = VerticalAlignment.Center;
            Label.Margin = new Thickness(50,0,0,0);
            Label.FontSize = 25;
            Label.Background = new SolidColorBrush(Color.FromRgb(191, 196, 167));

            var Button = new Button();
            Button.Content = "X";
            Button.Height = 54;
            Button.Width = 50;
            Button.HorizontalAlignment = HorizontalAlignment.Right;
            Button.BorderBrush = new SolidColorBrush(Color.FromRgb(191, 196, 167));
            Button.Background = new SolidColorBrush(Color.FromRgb(191, 196, 167));
            Button.FontSize = 25;
            Button.Click += Delete;



            var DockPanel = new DockPanel();
            DockPanel.Background = new SolidColorBrush(Color.FromRgb(191, 196, 167));
            DockPanel.Height = 54.1;
            DockPanel.Width = 418;
            DockPanel.HorizontalAlignment = HorizontalAlignment.Center;
            DockPanel.Margin = new Thickness(0, 20, 0, 0);
            DockPanel.Children.Add(ComboBox);
            DockPanel.Children.Add(Label);
            DockPanel.Children.Add(Button);


            int index = Content.Children.Count - 1;
            Content.Children.Insert(index, DockPanel);

            
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            this.Content.Children.Remove((UIElement)((Button)sender).Parent);
        }

  
    }
}
