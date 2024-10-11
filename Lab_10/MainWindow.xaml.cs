using System.Windows;
using System.Windows.Controls;


namespace Lab_10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void AddString_Button_Click(object sender, RoutedEventArgs e)
        {
            if (String_TextBox.Text == "")
            {
                MessageBox.Show("Введите строку!");
                return;
            }

            TextBlock textBlock = new TextBlock()
            {
                Text = String_TextBox.Text
            };

            String_ListBox.Items.Add(textBlock);

            StringInfo_TextBlock.Text = FindString();
        }


        private void DeleteString_Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = (TextBlock)String_ListBox.SelectedItem;
            String_ListBox.Items.Remove(textBlock);

            StringInfo_TextBlock.Text = FindString();
        }


        private string FindString()
        {
            ItemCollection textBlocks = String_ListBox.Items;


            if (textBlocks.Count <= 0)
            {
                return "";
            }

            // Переменная для хранения самой короткой строки, по умолчанию она равняется первому элементу -textBlocks-
            TextBlock textBlock_temp = (TextBlock)textBlocks.GetItemAt(0);


            // Перебираем всю коллекцию с помощью цикла foreach :)
            foreach (TextBlock textBlock in textBlocks)
            {
                // Присваиваем временной переменной значение самой короткой строки
                if (textBlock.Text.Length < textBlock_temp.Text.Length)
                {
                    textBlock_temp = textBlock;
                }
            }

            return textBlock_temp.Text;
        }


        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            IniFile iniFile = new IniFile("Data.ini");

            ItemCollection textBlocks = String_ListBox.Items;

            iniFile.DeleteSection("Lab_10");    // Очищаем ini файл перед записью

            for (int i = 0; i < textBlocks.Count; i++)
            {
                TextBlock textBlock = (TextBlock)textBlocks[i];

                iniFile.Write("String_" + i, textBlock.Text);
            }

            MessageBox.Show("Данные успешно сохранены!");
        }

        private void FillListBox()
        {
            IniFile iniFile = new IniFile("Data.ini");

            bool is_readed = false;
            string templateStringName = "String_";

            for (int i = 0; !is_readed; i++)
            {
                string stringName = templateStringName + i;

                if (iniFile.KeyExists(stringName))
                {
                    TextBlock textBlock = new TextBlock()
                    {
                        Text = iniFile.Read(stringName)
                    };

                    String_ListBox.Items.Add(textBlock);
                }
                else
                {
                    is_readed = true;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillListBox();
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
