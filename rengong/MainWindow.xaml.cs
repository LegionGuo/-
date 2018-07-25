using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
namespace rengong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 控制速度
        /// </summary>
        static int speed;
        static char[] exec = new char[9];
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置数字位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            init(exec);
            int check1 = check(exec);
            if (check1 == 1)
            {
                var tread = new Thread(() =>
                {
                    show(exec);
                    first(exec);
                });
                tread.Start();
            }
            else MessageBox.Show("输入的九宫格不符合1-8和空格");

        }

        #region Logic
        void init(char[] exec)
        {
            speed = 500;
            int i;
            for (i = 0; i < 9; i++)
            {
                exec[i] = ' ';
            }
            if (text0.Text != "") exec[0] = Convert.ToChar(text0.Text); else exec[0] = ' ';
            if (text1.Text != "") exec[1] = Convert.ToChar(text1.Text); else exec[1] = ' ';
            if (text2.Text != "") exec[2] = Convert.ToChar(text2.Text); else exec[2] = ' ';
            if (text3.Text != "") exec[3] = Convert.ToChar(text3.Text); else exec[3] = ' ';
            if (text4.Text != "") exec[4] = Convert.ToChar(text4.Text); else exec[4] = ' ';
            if (text5.Text != "") exec[5] = Convert.ToChar(text5.Text); else exec[5] = ' ';
            if (text6.Text != "") exec[6] = Convert.ToChar(text6.Text); else exec[6] = ' ';
            if (text7.Text != "") exec[7] = Convert.ToChar(text7.Text); else exec[7] = ' ';
            if (text8.Text != "") exec[8] = Convert.ToChar(text8.Text); else exec[8] = ' ';
        }
        void exchange(ref char a, ref char b)
        {
            char c;
            c = b;
            b = a;
            a = c;
        }
        /// <summary>
        /// 将绑定数据展示
        /// </summary>
        /// <param name="exec"></param>
        void show(char[] exec)
        {
            b0.Dispatcher.BeginInvoke(new Action(() =>
            {
                b0.Content = exec[0]; if (exec[0] == ' ') b0.Visibility = System.Windows.Visibility.Hidden; else b0.Visibility = System.Windows.Visibility.Visible;
                b1.Content = exec[1]; if (exec[1] == ' ') b1.Visibility = System.Windows.Visibility.Hidden; else b1.Visibility = System.Windows.Visibility.Visible;
                b2.Content = exec[2]; if (exec[2] == ' ') b2.Visibility = System.Windows.Visibility.Hidden; else b2.Visibility = System.Windows.Visibility.Visible;
                b3.Content = exec[3]; if (exec[3] == ' ') b3.Visibility = System.Windows.Visibility.Hidden; else b3.Visibility = System.Windows.Visibility.Visible;
                b4.Content = exec[4]; if (exec[4] == ' ') b4.Visibility = System.Windows.Visibility.Hidden; else b4.Visibility = System.Windows.Visibility.Visible;
                b5.Content = exec[5]; if (exec[5] == ' ') b5.Visibility = System.Windows.Visibility.Hidden; else b5.Visibility = System.Windows.Visibility.Visible;
                b6.Content = exec[6]; if (exec[6] == ' ') b6.Visibility = System.Windows.Visibility.Hidden; else b6.Visibility = System.Windows.Visibility.Visible;
                b7.Content = exec[7]; if (exec[7] == ' ') b7.Visibility = System.Windows.Visibility.Hidden; else b7.Visibility = System.Windows.Visibility.Visible;
                b8.Content = exec[8]; if (exec[8] == ' ') b8.Visibility = System.Windows.Visibility.Hidden; else b8.Visibility = System.Windows.Visibility.Visible;
            }));
            System.Threading.Thread.Sleep(speed);

        }
        int check(char[] exec)
        {
            int n = 0, n1 = 0, n2 = 0, n3 = 0, n4 = 0, n5 = 0, n6 = 0, n7 = 0, n8 = 0, i;
            for (i = 0; i < 9; i++)
            {
                if (exec[i] == ' ') n++;
                if (exec[i] == '1') n1++;
                if (exec[i] == '2') n2++;
                if (exec[i] == '3') n3++;
                if (exec[i] == '4') n4++;
                if (exec[i] == '5') n5++;
                if (exec[i] == '6') n6++;
                if (exec[i] == '7') n7++;
                if (exec[i] == '8') n8++;
            }
            if (n == 1 && n1 == 1 && n2 == 1 && n3 == 1 && n4 == 1 && n5 == 1 && n6 == 1 && n7 == 1 && n8 == 1) return 1;
            else return 0;

        }
        #endregion

        #region Steps
        void first(char[] exec)
        {
            int i;
            int n = 0;
            label1.Dispatcher.BeginInvoke(new Action(() =>
            {
                label1.Content = "操作1";
            }));
            for (i = 0; i < 9; i++)
            {
                if (exec[i] == ' ') n = i;
            }
            if (n == 6) { exchange(ref exec[6], ref exec[3]); show(exec); }
            if (n == 3) { exchange(ref exec[3], ref exec[4]); show(exec); }
            if (n == 4) { exchange(ref exec[4], ref exec[1]); show(exec); }
            if (n == 7) { exchange(ref exec[7], ref exec[8]); show(exec); }
            if (n == 0) { exchange(ref exec[0], ref exec[1]); show(exec); }
            if (n == 8) { exchange(ref exec[8], ref exec[5]); show(exec); }
            if (exec[2] == '1')
            {
                if (exec[5] == ' ') { exchange(ref exec[2], ref exec[5]); show(exec); }
                else if (exec[1] == ' ') { exchange(ref exec[2], ref exec[1]); show(exec); }

            }
            if (exec[2] == ' ')
            {
                if (exec[5] != '1') { exchange(ref exec[2], ref exec[5]); show(exec); }
                else { exchange(ref exec[2], ref exec[1]); show(exec); }
            }
            //printf("第1步：\n");
            second(exec);
        }

        void second(char[] exec)
        {
            int i, n = 0;
            label1.Dispatcher.BeginInvoke(new Action(() =>
            {
                label1.Content = "操作2";
            }));
            for (i = 0; i < 9; i++)
            {
                if (exec[i] == ' ') n = i;
            }

            while (exec[0] != '1')
            {
                switch (n)
                {
                    case 0: { exchange(ref exec[0], ref exec[3]); n = 3; show(exec); break; }
                    case 1: { exchange(ref exec[1], ref exec[0]); n = 0; show(exec); break; }
                    case 3: { exchange(ref exec[3], ref exec[6]); n = 6; show(exec); break; }
                    case 4: { exchange(ref exec[4], ref exec[1]); n = 1; show(exec); break; }
                    case 5: { exchange(ref exec[5], ref exec[4]); n = 4; show(exec); break; }
                    case 6: { exchange(ref exec[6], ref exec[7]); n = 7; show(exec); break; }
                    case 7: { exchange(ref exec[7], ref exec[8]); n = 8; show(exec); break; }
                    case 8: { exchange(ref exec[8], ref exec[5]); n = 5; show(exec); break; }

                }

            }
            third(exec);
        }

        void third(char[] exec)
        {
            int i, n = 0;
            label1.Dispatcher.BeginInvoke(new Action(() =>
            {
                label1.Content = "操作3";
            }));
            for (i = 0; i < 9; i++)
            {
                if (exec[i] == ' ') n = i;
            }

            while (exec[1] != '2')
            {
                switch (n)
                {
                    case 1: { exchange(ref exec[1], ref exec[4]); n = 4; show(exec); break; }
                    case 2: { exchange(ref exec[2], ref exec[1]); n = 1; show(exec); break; }
                    case 3: { exchange(ref exec[3], ref exec[6]); n = 6; show(exec); break; }
                    case 4: { exchange(ref exec[4], ref exec[3]); n = 3; show(exec); break; }
                    case 5: { exchange(ref exec[5], ref exec[2]); n = 2; show(exec); break; }
                    case 6: { exchange(ref exec[6], ref exec[7]); n = 7; show(exec); break; }
                    case 7: { exchange(ref exec[7], ref exec[8]); n = 8; show(exec); break; }
                    case 8: { exchange(ref exec[8], ref exec[5]); n = 5; show(exec); break; }

                }
            }
            if (exec[2] == '3') sixth(exec);
            else fourth(exec);
        }

        void fourth(char[] exec)
        {
            int i, n = 0;
            label1.Dispatcher.BeginInvoke(new Action(() =>
            {
                label1.Content = "操作4";
            }));
            for (i = 0; i < 9; i++)
            {
                if (exec[i] == ' ') n = i;
            }

            while (exec[4] != '3')
            {
                switch (n)
                {
                    case 3: { exchange(ref exec[3], ref exec[6]); n = 6; show(exec); break; }
                    case 4: { exchange(ref exec[4], ref exec[3]); n = 3; show(exec); break; }
                    case 5: { exchange(ref exec[5], ref exec[4]); n = 4; show(exec); break; }
                    case 6: { exchange(ref exec[6], ref exec[7]); n = 7; show(exec); break; }
                    case 7: { exchange(ref exec[7], ref exec[8]); n = 8; show(exec); break; }
                    case 8: { exchange(ref exec[8], ref exec[5]); n = 5; show(exec); break; }
                }

            }
            fifth(exec);
        }

        void fifth(char[] exec)
        {
            label1.Dispatcher.BeginInvoke(new Action(() =>
            {
                label1.Content = "操作5";
            }));
            if (exec[3] == ' ')
            {
                exchange(ref exec[3], ref exec[0]); show(exec);
                exchange(ref exec[0], ref exec[1]); show(exec);
                exchange(ref exec[1], ref exec[4]); show(exec);
                exchange(ref exec[4], ref exec[5]); show(exec);
                exchange(ref exec[5], ref exec[2]); show(exec);
                exchange(ref exec[2], ref exec[1]); show(exec);
                exchange(ref exec[1], ref exec[0]); show(exec);
                exchange(ref exec[0], ref exec[3]); show(exec);
            }

            sixth(exec);
        }

        void sixth(char[] exec)
        {
            int i, n = 0;
            label1.Dispatcher.BeginInvoke(new Action(() =>
            {
                label1.Content = "操作6";
            }));
            for (i = 0; i < 9; i++)
            {
                if (exec[i] == ' ') n = i;
            }

            while (exec[5] != '4')
            {
                switch (n)
                {
                    case 3: { exchange(ref exec[3], ref exec[6]); n = 6; show(exec); break; }
                    case 4: { exchange(ref exec[4], ref exec[3]); n = 3; show(exec); break; }
                    case 5: { exchange(ref exec[5], ref exec[4]); n = 4; show(exec); break; }
                    case 6: { exchange(ref exec[6], ref exec[7]); n = 7; show(exec); break; }
                    case 7: { exchange(ref exec[7], ref exec[8]); n = 8; show(exec); break; }
                    case 8: { exchange(ref exec[8], ref exec[5]); n = 5; show(exec); break; }
                }

            }

            if (exec[8] == '5') ninth(exec);
            else seventh(exec);
        }

        void seventh(char[] exec)
        {
            int i, n = 0;
            label1.Dispatcher.BeginInvoke(new Action(() =>
            {
                label1.Content = "操作7";
            }));
            for (i = 0; i < 9; i++)
            {
                if (exec[i] == ' ') n = i;
            }

            while (exec[4] != '5')
            {
                switch (n)
                {
                    case 3: { exchange(ref exec[3], ref exec[6]); n = 6; show(exec); break; }
                    case 4: { exchange(ref exec[4], ref exec[3]); n = 3; show(exec); break; }
                    case 6: { exchange(ref exec[6], ref exec[7]); n = 7; show(exec); break; }
                    case 7: { exchange(ref exec[7], ref exec[4]); n = 4; show(exec); break; }
                }
            }

            eighth(exec);
        }

        void eighth(char[] exec)
        {
            label1.Dispatcher.BeginInvoke(new Action(() =>
            {
                label1.Content = "操作8";
            }));
            if (exec[3] == ' ')
            {
                exchange(ref exec[3], ref exec[0]); show(exec);
                exchange(ref exec[0], ref exec[1]); show(exec);
                exchange(ref exec[1], ref exec[2]); show(exec);
                exchange(ref exec[2], ref exec[5]); show(exec);
                exchange(ref exec[5], ref exec[4]); show(exec);
                exchange(ref exec[4], ref exec[7]); show(exec);
                exchange(ref exec[7], ref exec[8]); show(exec);
                exchange(ref exec[8], ref exec[5]); show(exec);
                exchange(ref exec[5], ref exec[2]); show(exec);
                exchange(ref exec[2], ref exec[1]); show(exec);
                exchange(ref exec[1], ref exec[0]); show(exec);
                exchange(ref exec[0], ref exec[3]); show(exec);
            }
            ninth(exec);
        }

        void ninth(char[] exec)
        {
            int i, n = 0;
            label1.Dispatcher.BeginInvoke(new Action(() =>
            {
                label1.Content = "操作9";
            }));
            for (i = 0; i < 9; i++)
            {
                if (exec[i] == ' ') n = i;
            }


            while (exec[7] != '6' || exec[4] != ' ')
            {
                switch (n)
                {
                    case 4: { exchange(ref exec[4], ref exec[3]); n = 3; show(exec); break; }
                    case 3: { exchange(ref exec[3], ref exec[6]); n = 6; show(exec); break; }
                    case 6: { exchange(ref exec[6], ref exec[7]); n = 7; show(exec); break; }
                    case 7: { exchange(ref exec[7], ref exec[4]); n = 4; show(exec); break; }
                }
            }
            if (exec[6] == '7' && exec[3] == '8') MessageBox.Show("\n成功");
            else MessageBox.Show("达不到目标状态\n");
            show(exec);
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            speed += 100;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (speed > 100) speed -= 100;
        }
    }
}
