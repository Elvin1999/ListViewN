using ListView.Models;
using System;
using System.Collections.Generic;
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

namespace ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Book> Books { get; set; } = new List<Book>
        {
            new Book
            {
                Id=1,
                Author="Fyodor Dostoyevskiy",
                Genre="Criminal",
                Pages=750,
                Publisher="BAKU INC",
                Title="Crime and Punishment",
                ImagePath="Images/image1.jpg"
            },
            new Book
            {
                Id=2,
                Author="Napolion Hill",
                Genre="Self Improvement",
                Pages=620,
                Publisher="BAKU INC",
                Title="Think and Grow Rich",
                ImagePath="Images/image2.jpg"
            },
            new Book
            {
                Id=3,
                Author="Robert Kiyosoki",
                Genre="Self Improvement",
                Pages=300,
                Publisher="BAKU INC",
                Title="Rich Dad , Poor Dad",
                ImagePath="Images/image3.jpg"
            },
        };
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
            // this.listView.ItemsSource = Books;
            DirSearch(@"C:\Users\User\source\repos\ListView\ListView");
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // var book = listView.SelectedItem as Book;
           // MessageBox.Show(book.Title);
        }
        public void DirSearch(string sDir)
        {
            try
            {

                foreach (var directory in Directory.GetDirectories(sDir))
                {
                    var treeViewItem = new TreeViewItem();
                    treeViewItem.Header = Directory.GetParent(directory).Name;
                    foreach (var filename in Directory.GetFiles(directory))
                    {

                        treeViewItem.Items.Add(new TreeViewItem
                        {
                            Header = filename,
                        });

                    }

                    DirSearch(directory);
                    //mytree.Items.Add(treeViewItem);
                }
            }
            catch
            {

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var book = bookListBox.SelectedItem as Book;
            var btn = sender as Button;
            var grid = btn.Parent as Grid;
            var title = ((grid.Children[1] as StackPanel).Children[0] as TextBlock).Text;
            MessageBox.Show($"{title} kitab ugurla alindi");
        }
    }
}
