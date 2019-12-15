using System;
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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private 功能 w2;
        public string connectionstring = "server=localhost;user=root;database=company;port=3306;password=chengzhi0454?";
        public MySqlConnection Connection
        {
            set;
            get;
        }
        private void Button1_Click(Object obj, RoutedEventArgs e)
        {

            string name1 = TextBox1.Text.ToString();
            string password = TextBox2.Text.ToString();

            Connection = new MySqlConnection(connectionstring);
            while (Connection == null)
            {
                MessageBox.Show("登录失败", "出错", MessageBoxButton.OK);
                if (MessageBox.Show("是否重新连接", "出错", MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    //退出程序。
                    Close();
                }
                else
                {
                    Connection = new MySqlConnection(connectionstring);
                }
            }
            MessageBox.Show("连接成功", "连接数据库成功", MessageBoxButton.OK);
            Connection.Open();
            MySqlCommand cmd = new MySqlCommand("select password from normaluser where id='" + name1 + "';", Connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                if (rdr[0].ToString() == password)
                {
                    rdr.Close();
                    MessageBox.Show("登录成功", "登录成功", MessageBoxButton.OK);
                    w2 = new 功能(Connection, name1, password);
                    
                    w2.Show();
                    this.Owner = w2;
                    
                }
                else
                {
                    MessageBox.Show("用户或密码错误", "用户或密码错误", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("用户或密码错误", "用户或密码错误", MessageBoxButton.OK);
            }

        }//button
    }//class mainwindows
}
