using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace zadanie5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String line;
        public string login;
        public string password;

        public string loginReg;
        public string passwordReg;
        public string confirmPasswordReg;
        public string lastNameReg;
        public string firstNameReg;
        public string otchReg;

        public MainWindow()
        {
            InitializeComponent();
            login = textBoxLogin.Text;
            password = passwordTextBox.Text;

            loginReg = textBoxLoginReg.Text;
            passwordReg = textBoxPasswordReg.Text;
            confirmPasswordReg = textBoxConfirmPasswordReg.Text;
            lastNameReg = textBoxLastName.Text;
            firstNameReg = textBoxFirstName.Text;
            otchReg = textBoxOtch.Text;
        }
        private void InitializeMyControl()
        {

        }
        private void btnVhod_Click(object sender, RoutedEventArgs e)
        {//стримридер
         //код входа
            String allowChar = " ";
            allowChar = "A,B,C,D,E,F,G,H,I,G,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowChar += "a,b,c,d,e,f,g,h,i,g,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            allowChar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };

            String[] ar = allowChar.Split(a);
            String pwd = "";
            string temp = "";
            Random r = new Random();
            if (File.Exists("userData.txt"))
            {
                try
                {

                StreamReader streamReader = new StreamReader("C:\\Users\\User\\Downloads\\zadanie5\\zadanie5\\UserData\\userData.txt");
                string loginData = streamReader.ReadLine();
                string [] logPass = loginData.Split(' ');
                To_Do_List toDoList = new To_Do_List();
                
                

                if (logPass[0] == textBoxLogin.Text && logPass[1] == passwordBox.Password)
                {
                    if(textBoxCapcha.Visibility == Visibility.Visible)
                    {
                            if (textBoxCapcha.Text == (string)capchaLabel.Content)
                            {
                                MessageBox.Show("Вы успешно вошли!");
                                toDoList.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Неверный ввод капчи!");
                            }
                    }
                    else
                    {
                            MessageBox.Show("Вы успешно вошли!");
                            toDoList.Show();
                            this.Close();
                    }
                }
                else
                {

                    int kol = 6;

                    for(int i = 0; i < kol; i++)
                    {
                        temp = ar[(r.Next(0,ar.Length))];
                        pwd += temp;
                    }

                    wrongPasswordLabel.Content = "Неверный логин или пароль!";
                    capchaLabel.Content = pwd;
                    textBoxCapcha.Visibility = Visibility.Visible;
                    
                }
                streamReader.Close();
                }
                catch { MessageBox.Show("Ошибка! Возможно вы не поменяли в коде путь к текстовому файлу и запустили программу!"); }
            }
            
            else
            {
                MessageBox.Show("Ошибка! ");
            }
        }

        private void showPassword_Click(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Text = passwordBox.Password;
            passwordTextBox.Visibility = Visibility.Visible;
            passwordBox.Visibility = Visibility.Hidden;
            showPassword.Visibility = Visibility.Hidden;
            showbtn2.Visibility = Visibility.Visible;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedItem = tabRegister;
        }
        public static bool PasswordMatches(string password)
        {
            bool isValidLength = password.Length >= 8;
            bool hasLetter = password.Any(char.IsLetter);
            bool hasSymbol = password.Any(c => !char.IsLetterOrDigit(c));

            if (isValidLength && hasLetter && hasSymbol)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private void btnRegisterReg_Click(object sender, RoutedEventArgs e)
        {
            string[] passwords = new string[2] { textBoxPasswordReg.Text, textBoxConfirmPasswordReg.Text };
            try
            {
                if(textBoxLoginReg.Text != string.Empty && textBoxPasswordReg.Text != string.Empty &&
                    textBoxConfirmPasswordReg.Text != string.Empty && textBoxLastName.Text != string.Empty &&
                    textBoxFirstName.Text != string.Empty && textBoxOtch.Text != string.Empty)
                {

                    if ((textBoxPasswordReg.Text == textBoxConfirmPasswordReg.Text) && PasswordMatches(textBoxPasswordReg.Text))
                    {
                        //код записи в текстовый документ
                        StreamWriter streamWriter = new StreamWriter("C:\\Users\\User\\Downloads\\zadanie5\\zadanie5\\UserData\\userData.txt", false);
                        string userLoginPass = textBoxLoginReg.Text + " " + textBoxPasswordReg.Text;
                        streamWriter.Write(userLoginPass);
                        streamWriter.Close();
                        
                        MessageBox.Show("Вы успешно зарегистрированы!");
                    }
                    else { MessageBox.Show("Пароль не совпадает, либо слишком слабый"); }
                    
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                }

            }
            catch 
            {
                Console.WriteLine("Ошибка!");
            }
        }

        private void btnClearReg_Click(object sender, RoutedEventArgs e)
        {
            textBoxLoginReg.Text = "";
            textBoxPasswordReg.Text = "";
            textBoxConfirmPasswordReg.Text = "";
            textBoxLastName.Text = "";
            textBoxFirstName.Text = "";
            textBoxOtch.Text = "";
        }

        private void showbtn2_Click(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Visibility = Visibility.Hidden;
            passwordBox.Visibility = Visibility.Visible;
            showPassword.Visibility = Visibility.Visible;
            showbtn2.Visibility = Visibility.Hidden;
        }
    }
}
