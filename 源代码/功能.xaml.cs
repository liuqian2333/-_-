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
using WpfApp1;

namespace WpfApp1
{
    /// <summary>
    /// 功能.xaml 的交互逻辑
    /// </summary>
    public partial class 功能 : Window
    {
        public bool Hightpowver
        {
            set;
            get;
        }
        public void Settrue()
        {
            Hightpowver = true;
        }
        public void Setfalse()
        {
            Hightpowver = false;
        }
        public MySqlConnection Connection
        {
            set;
            get;
        }

        public string Password
        {
            set;
            get;
        }
        public string User
        {
            set;
            get;
        }
        
        public 功能(MySqlConnection connection, string user, string password)
        {
            Hightpowver = false;
            Password = password;
            Connection = connection;
            User = user;
            InitializeComponent();
            员工_data data1 = new 员工_data();
            data1.Init(Connection, 员工信息_grid1);
        }
        public void 员工信息_button1(Object sender, RoutedEventArgs e)
        {
            var list = new List<员工_data>();
            员工信息_grid1.DataContext = list;
            员工_data data1 = new 员工_data();
            data1.Init(Connection, 员工信息_grid1);

        }
        public void 管理奖惩情况_查询click(Object sender, RoutedEventArgs e)
        {
            
            员工奖惩_data data = new 员工奖惩_data();
            data.Publish(Connection, 管理奖惩情况_查询textbox.Text, 管理奖惩情况_查询grid1);
        }
        public void 管理奖惩情况_修改click(Object sender, RoutedEventArgs e)
        {
            员工奖惩_data data = new 员工奖惩_data();
            data.Modify_one(Connection, 管理奖惩情况_修改number.Text, 管理奖惩情况_修改员工id.Text, Convert.ToInt32(管理奖惩情况_修改奖惩.Text),
                管理奖惩情况_修改时间.Text, 管理奖惩情况_修改原因.Text);
        }
        public void 管理奖惩情况_新建click(Object sender, RoutedEventArgs e)
        {
            员工奖惩_data data = new 员工奖惩_data();
            data.Add_one(Connection,  管理奖惩情况_新建员工id.Text, Convert.ToInt32(管理奖惩情况_新建奖惩.Text),
                管理奖惩情况_新建时间.Text, 管理奖惩情况_新建原因.Text);
        }
        public void 管理奖惩情况_删除click(Object sender, RoutedEventArgs e)
        {
            员工奖惩_data data = new 员工奖惩_data();
            data.Delete_one(Connection, 管理奖惩情况_删除textbox.Text);
        }
        //新建员工
        public void 人事变动_新建click(Object sender, RoutedEventArgs e)
        {
            if (Hightpowver == true)
            {
                员工_data data = new 员工_data();
                data.Add_anemployee(Connection, "0", 人事变动_新建textbox姓名.Text, 人事变动_新建textbox性别.Text, 人事变动_新建textbox户口情况.Text, 人事变动_新建textbox政治面貌.Text, 
                     人事变动_新建textbox健康.Text, 人事变动_新建textbox合同.Text, Convert.ToInt32(人事变动_新建textbox工资.Text));
            }
            else
            {
                MessageBox.Show("权限不足", "你的权限不足，请获得更高的权限", MessageBoxButton.OK);
            }
        }
        //修改员工
        public void 人事变动_修改click(Object sender, RoutedEventArgs e)
        {
            if (Hightpowver == true)
            {
                员工_data data = new 员工_data();
                data.Change_anemployee(Connection, Convert.ToInt32(人事变动_修改textboxid.Text), 人事变动_修改textbox姓名.Text, 人事变动_修改textbox性别.Text, 人事变动_修改textbox户口.Text, 人事变动_修改textbox政治面貌.Text,
                     人事变动_修改textbox健康.Text, 人事变动_修改textbox合同状况.Text, Convert.ToInt32(人事变动_修改textbox工资.Text));
            }
            else
            {
                MessageBox.Show("权限不足", "你的权限不足，请获得更高的权限", MessageBoxButton.OK);
            }
        }
        public void 人事变动_获得权限click(Object sender, RoutedEventArgs e)
        {
            高级权限验证 w3 = new 高级权限验证(Connection, this);
            w3.Show();
            this.Owner = w3;
            
            Hightpowver_data data = new Hightpowver_data();
            data.Getpowver(Connection, w3.高级权限验证_textboxuser.Text, w3.高级权限验证_textboxpassword.Text, this);
        }
        public void 人事变动_退出权限click(Object sender, RoutedEventArgs e)
        {
            Hightpowver = false;
        }
        //删除员工
        public void 人事变动_删除click(Object sender, RoutedEventArgs e)
        {
            if (Hightpowver == true)
            {
                员工_data data = new 员工_data();
                data.Delete_anemployee(Connection, 人事变动_删除textbox删除.Text);
            }
            else
            {
                MessageBox.Show("权限不足", "你的权限不足，请获得更高的权限", MessageBoxButton.OK);
            }
        }
    }//class
    class 员工_data
    {
        public int Staffid
        {
            get;
            set;
        }
        public string Staffname
        {
            get;
            set;
        }
        public string Staffsex
        {
            get;
            set;
        }
        public string Staffhukou
        {
            get;
            set;
        }
        public string Staffzhengzhi
        {
            get;
            set;
        }
        public string Staffhealth
        {
            get;
            set;
        }
        public string Staffconstrace
        {
            get;
            set;
        }
        public int Staffpay
        {
            get;
            set;
        }
        

        //初始化员工信息
        //功能-员工信息
        public void Init(MySqlConnection Connection, Grid grid1)
        {
            var list = new List<员工_data>();

            string str1 = "select * from staff_data;";

            MySqlCommand cmd = new MySqlCommand(str1, Connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                员工_data data = new 员工_data();
                data.Staffid = Convert.ToInt32(rdr[0].ToString());
                data.Staffname = rdr[1].ToString();
                data.Staffsex = rdr[2].ToString();
                data.Staffhukou = rdr[3].ToString();
                data.Staffzhengzhi = rdr[4].ToString();
                data.Staffhealth = rdr[5].ToString();
                data.Staffconstrace = rdr[6].ToString();
                data.Staffpay = Convert.ToInt32(rdr[7]);
                list.Add(data);

            }
            grid1.DataContext = list;
            rdr.Close();
        }

        //增加员工

        public void Add_anemployee(MySqlConnection connection, string id, string name, string sex, string hukou, string zhengzhi, string health, string constrance, int pay)
        {
            string str0 = "select MAX(a.id) from staff_data a;";
            MySqlCommand cmd0 = new MySqlCommand(str0, connection);
            MySqlDataReader rdr0 = cmd0.ExecuteReader();
            rdr0.Read();

            int newnumber = Convert.ToInt32(rdr0[0]);
            rdr0.Close();
            

            string str1 = "insert into staffaward_data values(@id, @name, @sex, @hukou, @zhengzhi, " +
                "@health, @constrance, @pay)";

            MySqlCommand cmd = new MySqlCommand(str1, connection);
            cmd.Parameters.AddWithValue("@id", newnumber+1);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@sex", sex);
            cmd.Parameters.AddWithValue("@hukou", hukou);
            cmd.Parameters.AddWithValue("@zhengzhi", zhengzhi);
            cmd.Parameters.AddWithValue("@health", health);
            cmd.Parameters.AddWithValue("@constrance", constrance);
            cmd.Parameters.AddWithValue("@pay", pay);
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                MessageBox.Show("add_success", "插入成功", MessageBoxButton.OK);
            }
            else if (row == 0)
            {
                MessageBox.Show("add_fail", "要插入的数据已存在", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("error", "插入了多行，是不是有bug?", MessageBoxButton.OK);
            }
        }

        //删除员工---奖惩表中接连删除
        public void Delete_anemployee(MySqlConnection connection, string id)
        {
            string str1 = "delete from staffaward_data a where a.id=@id";
            MySqlCommand cmd = new MySqlCommand(str1, connection);
            cmd.Parameters.AddWithValue("@id", id);
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                MessageBox.Show("delete_success", "删除成功", MessageBoxButton.OK);
            }
            else if (row == 0)
            {
                MessageBox.Show("delete_fail", "删除成功", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("error", "删除了多行，是不是有bug?", MessageBoxButton.OK);
            }
        }

        //修改员工
        public void Change_anemployee(MySqlConnection connection, int id, string name, string sex, string hukou, string zhengzhi, string health, string constrance, int pay)
        {
            var list = new List<员工_data>();

            string str1 = "updata staffaward_data a set a.id=@id, a.name=@name, a.sex=@sex, a.hukou=@hukou," +
                " a.zhengzhi=@zhengzhi, a.health=@health, a.constrance=@constrance, a.pay=@pay where a.number=";

            MySqlCommand cmd = new MySqlCommand(str1, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@sex", sex);
            cmd.Parameters.AddWithValue("@hukou", hukou);
            cmd.Parameters.AddWithValue("@zhengzhi", zhengzhi);
            cmd.Parameters.AddWithValue("@health", health);
            cmd.Parameters.AddWithValue("@constrance", constrance);
            cmd.Parameters.AddWithValue("@pay", pay);
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                MessageBox.Show("update_success", "修改成功", MessageBoxButton.OK);
            }
            else if (row == 0)
            {
                MessageBox.Show("update_fail", "修改失败或者输入的数据已存在", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("error", "修改了多行，是不是有bug?", MessageBoxButton.OK);
            }
        }

        /*
        //显示已有的课程
        //功能_我的课程——grid
        public void Init(MySqlConnection Connection, string name1, Grid grid1)
        {

            var list = new List<我的课程_grid1_data>();
            //我的课程_grid1_data data = new 我的课程_grid1_data();
            string str1 = "select student_course_old.id, name, teacher, credit, preid, notation, time from student_course_old natural join student_course_selected where student_course_selected.student_id='";
            string str2 = "';";
            MySqlCommand cmd = new MySqlCommand(str1 + name1 + str2, Connection);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                我的课程_grid1_data data = new 我的课程_grid1_data();
                data.Courseid = rdr[0].ToString();
                data.Coursename = rdr[1].ToString();
                data.Courseteacher = rdr[2].ToString();
                data.Coursecredit = rdr[3].ToString();
                data.Coursepreid = rdr[4].ToString();
                data.Coursenotation = rdr[5].ToString();
                data.Coursetime = rdr[6].ToString();

                list.Add(data);

            }
            grid1.DataContext = list;
            rdr.Close();
        }

        //显示已临时选择的课程
        //功能-选课-grid2
        public void Init2(MySqlConnection Connection, string name1, Grid grid1)
        {

            var list = new List<我的课程_grid1_data>();
            //我的课程_grid1_data data = new 我的课程_grid1_data();
            string str1 = "select student_course.id, name, teacher, credit, preid, notation, time from student_course natural join student_course_selected_tempary where student_course_selected_tempary.student_id='";
            string str2 = "';";
            MySqlCommand cmd = new MySqlCommand(str1 + name1 + str2, Connection);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                我的课程_grid1_data data = new 我的课程_grid1_data();
                data.Courseid = rdr[0].ToString();
                data.Coursename = rdr[1].ToString();
                data.Courseteacher = rdr[2].ToString();
                data.Coursecredit = rdr[3].ToString();
                data.Coursepreid = rdr[4].ToString();
                data.Coursenotation = rdr[5].ToString();
                data.Coursetime = rdr[6].ToString();

                list.Add(data);

            }
            grid1.DataContext = list;
            rdr.Close();
        }
        */
    }//class 员工信息data
    class 员工奖惩_data
    {
        public string Staffid
        {
            set;
            get;
        }
        public int Staffaward
        {
            set;
            get;
        }
        public string Awardtime
        {
            set;
            get;
        }
        public string Awardreason
        {
            set;
            get;
        }
        
        //查询某个员工的奖惩情况
        public void Publish(MySqlConnection connection, string staffid, Grid grid1)
        {
            
            var list = new List<员工奖惩_data>();

            string str1 = "select * from staffaward_data where staffaward_data.id='";
            string str2 = "';";
            MySqlCommand cmd = new MySqlCommand(str1 + staffid + str2, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                员工奖惩_data data = new 员工奖惩_data();
                data.Staffid = rdr[0].ToString();
                data.Staffaward = Convert.ToInt32(rdr[1]);
                data.Awardtime = rdr[2].ToString();
                data.Awardreason = rdr[3].ToString();
                
                list.Add(data);

            }
            grid1.DataContext = list;
            rdr.Close();
        }
        //修改一条奖惩情况
        public void Modify_one(MySqlConnection connection, string number, string staffid, int award, string time, string reason)
        {
            string  str1= "update staffaward_data a set a.id=@staffid1, a.award=@award1," +
                " a.time=@time1, a.reason=@reason1 where a.number=@number1";

            MySqlCommand cmd = new MySqlCommand(str1, connection);
            cmd.Parameters.AddWithValue("@staffid1", staffid);
            cmd.Parameters.AddWithValue("@awadr1", award);
            cmd.Parameters.AddWithValue("@time1", time);
            cmd.Parameters.AddWithValue("@reason1", reason);
            cmd.Parameters.AddWithValue("@number1", number);
            int row = cmd.ExecuteNonQuery();
            if(row == 1)
            {
                MessageBox.Show("update_success", "修改成功", MessageBoxButton.OK);
            }
            else if(row == 0)
            {
                MessageBox.Show("update_fail", "要修改的数据不存在或输入的数据与原数据相同", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("error", "修改了多行，是不是有bug?", MessageBoxButton.OK);
            }
        }
        //增加一条奖惩情况
        public void Add_one(MySqlConnection connection, string staffid, int award, string time, string reason)
        {
            string str0 = "select MAX(a.number) from staffaward_data a;";
            MySqlCommand cmd0 = new MySqlCommand(str0, connection);
            MySqlDataReader rdr0 = cmd0.ExecuteReader();
            rdr0.Read();
            
            int newnumber = Convert.ToInt32(rdr0[0]);
            rdr0.Close();
            string str1 = "insert into staffaward_data a value(@number, @id, @award, @time, @reason)";


            MySqlCommand cmd = new MySqlCommand(str1, connection);
            cmd.Parameters.AddWithValue("@number", newnumber + 1);
            cmd.Parameters.AddWithValue("@id", staffid);
            cmd.Parameters.AddWithValue("@award", award);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.Parameters.AddWithValue("@reason", reason);
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                MessageBox.Show("new_insert_success", "新建成功", MessageBoxButton.OK);
            }
            else if (row == 0)
            {
                MessageBox.Show("new_insert_fail", "新建失败", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("error", "插入了多行，是不是有bug?", MessageBoxButton.OK);
            }
        }
        //删除一条奖惩情况
        public void Delete_one(MySqlConnection connection, string number)
        {
            //string str00 = 管理奖惩情况_新建员工id.Text;
            string str1 = "delete from staffaward_data a where a.number=@number1";

            MySqlCommand cmd = new MySqlCommand(str1, connection);
            
            cmd.Parameters.AddWithValue("@number1", number);
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                MessageBox.Show("delete_success", "删除成功", MessageBoxButton.OK);
            }
            else if (row == 0)
            {
                MessageBox.Show("delete_fail", "要删除的数据不存在", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("error", "删除了多行，是不是有bug?", MessageBoxButton.OK);
            }
        }
    }//class 奖惩data
}//namespace
