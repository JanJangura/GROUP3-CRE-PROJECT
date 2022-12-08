using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.Diagnostics;

namespace GROUP3_CRE_PROJECT
{
    public partial class Form1 : Form
    {
        // Form Declarations...
        SpeechSynthesizer ss = new SpeechSynthesizer();
        PromptBuilder pb = new PromptBuilder(); 
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        Grammar gr = new DictationGrammar();
        Choices clist;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Start (Button_Click)
            btnStart.Enabled = false;
            btnStop.Enabled = true;            

            try
            {
                sre.RequestRecognizerUpdate();
                sre.SetInputToDefaultAudioDevice();
                sre.LoadGrammar(gr);
                sre.SpeechRecognized += sre_SpeechRecognized;               
                sre.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "hello":
                {
                   ss.SpeakAsync("Hello Alex");
                   break;
                }
                case "how are you":
                {
                   ss.SpeakAsync("I am doing great Alex, how about you");
                   break;
                }
                case "what is the current time":
                {
                        ss.SpeakAsync("current time is " + DateTime.Now.ToLongTimeString());
                        break;
                }
                case "open chrome":
                {
                        Process.Start("chrome", "https://www.google.com/");
                        break;
                }
                case "close":
                {
                    Application.Exit();
                    break;
                }
                //case "activate":
                //{
                //        ss.SpeakAsync("Enter city");

                //        enterLocation(sender, e);
                //        break;
                //}
                default:
                {
                        enterLocation(sender, e);
                        break;
                }
            }
            textBox1.Text += e.Result.Text.ToString() + Environment.NewLine;
        }


        private void enterLocation(object sender, SpeechRecognizedEventArgs e)
        {
            string city = e.Result.Text.ToString();


            StringBuilder queryAddress = new StringBuilder();
            queryAddress.Append("http://www.google.com/maps?q=");

            if(city != string.Empty)
            {
                queryAddress.Append(city + "," + "+");
            }

            Map.Navigate(queryAddress.ToString());
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            sre.RecognizeAsyncStop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void Map_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
