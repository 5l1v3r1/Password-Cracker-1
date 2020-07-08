using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Password_Cracker_V1._0
{
    public partial class Form2 : Form
    {

        string[] şifreli_mesaj = {
            "63a9f0ea7bb98050796b649e85481845",
            "21232f297a57a5a743894a0e4a801fc3",
            "098f6bcd4621d373cade4e832627b4f6",
            "71144850f4fb4cc55fc0ee6935badddf",
            "21b72c0b7adc5c7b4a50ffcb90d92dd6",
            "e10adc3949ba59abbe56e057f20f883e",
            "25f9e794323b453885f5181f1b624d0b",
            "5f4dcc3b5aa765d61d8327deb882cf99",
            "d8578edf8458ce06fbc5bb76a58c5ca4",
            "e99a18c428cb38d5f260853678922e03",
            "7c6a180b36896a0a8c02787eeafb0e4c",
            "f25a2fc72690b780b2a14e140ef6a9e0",
            "6eea9b7ef19179a06954edd0f6c05ceb",
            "d0763edaa9d9bd2a9516280e9044d885",
            "8352269ae368edfeacfa7c1213c35015",
            "200820e3227815ed1756a6b531e7e0d2",
            "3fc0a7acf087f549ac2b266baf94b8b1",
            "02c75fb22c75b23dc963c7eb91a062cc",
            "5edc3bed517dbf9865fb815552c1eb21",
            "f1576406b382b7d1c8c2607f7c563d4f",
            "0acf4539a14b3aa27deeb4cbdf6e989f",
            "f6bca54ae53b1e1d57a20a6cebd7a99e",
            "ab4f63f9ac65152575886860dde480a1",
            "a152e841783914146e4bcd4f39100686",
            "fe546279a62683de8ca334b673420696",
            "3bf1114a986ba87ed28fc1b5884fc2f8",
            "8ddcff3a80f4189ca1c9d4d902c3c909",
            "fae0b27c451c728867a567e8c1bb4e53",
            "0724ae89a2ce31a86adbfa8d294ba194",
            "e5141d70d2c645228e797053bf66b3df",
            "8621ffdbc5698829397d97767ac13db3",
            "9f84ffbdc1319543b91df8eb21d5de3b"

        };
        string[] mesajlar =
        {
            "root",
            "admin",
            "test",
            "ghost",
            "matrix",
            "123456",
            "123456789",
            "password",
            "qwerty",
            "abc123",
            "password1",
            "iloveyou",
            "qwertyuiop",
            "monkey",
            "myspace1",
            "qwe123",
            "qwerty123",
            "zxcvbnm",
            "fuckyou1",
            "linkedin",
            "michael",
            "football1",
            "azerty",
            "asdfgh",
            "samsung",
            "shadow",
            "88888888",
            "666",
            "1g2w3e4r",
            "tinkle",
            "dragon",
            "target123"

        };

        public Form2()
        {
            InitializeComponent();
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            string sifre = "";
            sifre = textBox1.Text;
            if (sezar.Checked == true)
            {
                char[] karakterler2 = sifre.ToCharArray();
                foreach (char eleman2 in karakterler2)
                {
                    textBox2.Text += Convert.ToChar(eleman2 - 3).ToString();
                }
            }
            else if (md5.Checked == true)
            {

                string mesaj = textBox1.Text;
                for (int i = 0; i < 5; i++)
                {
                    if (mesaj == şifreli_mesaj[i])
                    {
                        textBox2.Text = mesajlar[i];
                        break;
                    }
                }

                if (textBox2.Text == "")
                {
                    MessageBox.Show("Şifre Çözülemedi");
                }
            }
            else if (base64.Checked == true)
            {
                string metincoz = textBox1.Text;
                byte[] veridizimcozulen = Convert.FromBase64String(metincoz);
                string anametin2 = ASCIIEncoding.ASCII.GetString(veridizimcozulen);
                textBox2.Text = anametin2;
            }
            else if (ozel.Checked == true)
            {
                char[] karakterler3 = sifre.ToCharArray();
                foreach (char eleman2 in karakterler3)
                {
                    textBox2.Text += Convert.ToChar(eleman2 - 6).ToString();
                }
            }
            else
            {
                MessageBox.Show("Please select the encryption type!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://turklojen.com");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://turklojen.com/iletisim.html");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string veri = "";
            veri = textBox1.Text;


            if (sezar.Checked == true)
            {
                char[] karakterler = veri.ToCharArray();
                foreach (char eleman in karakterler)
                {
                    textBox2.Text += Convert.ToChar(eleman + 3).ToString();
                }
            }
            else if (md5.Checked == true)
            {
                textBox2.Text = MD5Hash(textBox1.Text);
            }
            else if (base64.Checked == true)
            {
                string anametin = textBox1.Text;
                byte[] veridizim = ASCIIEncoding.ASCII.GetBytes(anametin);
                string sifrelimetin = Convert.ToBase64String(veridizim);
                textBox2.Text = sifrelimetin;
            }
            else if (ozel.Checked == true)
            {
                char[] karakterler4 = veri.ToCharArray();
                foreach (char eleman in karakterler4)
                {
                    textBox2.Text += Convert.ToChar(eleman + 6).ToString();
                }
            }
            else
            {
                MessageBox.Show("Please select the encryption type!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
