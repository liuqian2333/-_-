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
using System.Windows.Shapes;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WpfApp1
{
    /// <summary>
    /// 高级权限验证.xaml 的交互逻辑
    /// </summary>
    public partial class 高级权限验证 : Window
    {
        private 功能 W1
        {
            set;
            get;
        }
        public MySqlConnection Connection
        {
            set;
            get;
        }
        public 高级权限验证(MySqlConnection connection, 功能 w1)
        {
            Connection = connection;
            InitializeComponent();
        }
        public void 高级权限验证_验证click(Object sender, RoutedEventArgs e)
        {
            Hightpowver_data data = new Hightpowver_data();
            data.Getpowver(Connection, 高级权限验证_textboxuser.Text, 高级权限验证_textboxpassword.Text, W1);
        }
        public void 高级权限验证_取消click(Object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
    class Hightpowver_data
    {
        public string Hightid
        {
            set;
            get;
        }
        public string Hightpassword
        {
            set;
            get;
        }
        public void Getpowver(MySqlConnection connection, string hightid, string hightpassword, 功能 w1)
        {
            
            string str1 = "select a.password from hightpowver_data a where a.id=@hightid";
            MySqlCommand cmd = new MySqlCommand(str1, connection);
            cmd.Parameters.AddWithValue("@hightid", hightid);

            MySqlDataReader rdr0 = cmd.ExecuteReader();
            rdr0.Read();
            string password = rdr0[0].ToString();
            rdr0.Close();
            if (password == hightpassword)
            {
                w1.Settrue();
            }
            else
            {
                MessageBox.Show("错误", "用户名或密码错误", MessageBoxButton.OK);
            }
        }
    }

}
