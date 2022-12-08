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
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        Choices cmdOptions = new Choices(new string[] {"hello","Hello","how about you","what is the current time","open chrome"
            ,"close"});
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
                case "Hello":
                    ss.SpeakAsync("Hi, how are you?");
                    break;
                case "hello":
                    ss.SpeakAsync("Hi, how are you?");
                    break;
                case "how about you":
                    ss.SpeakAsync("I am doing great Alex");
                    break;
                case "what is the current time":
                    ss.SpeakAsync("current time is " + DateTime.Now.ToLongTimeString());
                    break;
                case "open chrome":
                    Process.Start("chrome", "https://www.google.com/");
                    break;
                case "routes me":
                    Process.Start("https://www.google.com/", "https://www.google.com/maps/search/google+maps/@42.5040261,-83.0301713,13z/data=!3m1!4b1");
                    break;
                case "close":
                    Application.Exit();
                    break;
            }
            textBox1.Text += e.Result.Text.ToString() + Environment.NewLine;
            count++;
            if (count == 12)
            {
                textBox1.Clear();
                count = 0;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            sre.RecognizeAsyncStop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
    }
}
