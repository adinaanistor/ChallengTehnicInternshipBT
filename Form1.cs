using System;
using System.Windows.Forms;
using System.Windows.Threading;


namespace RandomPassword
{
    public partial class Form1 : Form
    {
        DispatcherTimer timer = new DispatcherTimer();
        const string lower_case = "abcdefghijklmnopqursuvwxyz";
        const string upper_case = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string numbers = "1234567890";
        const string special_characters = "`~!@#$%^&*()_+=-{[}]?/<>";

        public Form1()
        {
            InitializeComponent();
            this.timer.Tick += new EventHandler(MessageShown);
            this.timer.Tick += new EventHandler(Form1_Load);
        }

        public string GeneratePassword(int length) ///method to generate a random password
        {
            char[] password = new char[length];
            System.Random random = new Random();
            string charSet = lower_case + upper_case + numbers + special_characters;
            for (int i = 0; i < length; i++)
                password[i] = charSet[random.Next(charSet.Length - 1)];
            return string.Join(null, password);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            label4.Show();
            string name = textBox1.Text;
            label4.Text = "Hello " + name; //when we click the button 'Connect', will be displayed a label
            timer.Stop();
        }

        void MessageShown(object source, EventArgs e)
        {
            MessageBox.Show("30 seconds passed! The password will be reset!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            label4.Hide();
            timer.Interval = new TimeSpan(0, 0, 30); //we need a timer of 30 seconds in order to reset the password
            timer.Start();
            textBox2.Text = DateTime.Now.ToString("dd-MM-yyyy h:mm:ss tt");
            textBox3.Text = GeneratePassword(8); //the method will generate a password of 8 characters
        }
    }
}
