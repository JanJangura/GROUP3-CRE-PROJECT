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
            ,"close","input","michigan","south","field"});

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
            if (count == 1)
            {
                textBox1.Clear();
                count = 0;
            }
            switch (e.Result.Text.ToString())
            {
                case "Hello":
                    ss.SpeakAsync("Hi, how are you?");
                    break;
                case "hello":
                    ss.SpeakAsync("Hi, how are you?");
                    break;
                case "how about you":
                    ss.SpeakAsync("I am doing great");
                    break;
                case "what time is it":
                    ss.SpeakAsync("current time is " + DateTime.Now.ToLongTimeString());
                    break;
                case "open chrome":
                    Process.Start("chrome", "https://www.google.com/");
                    break;
                case "routes me":
                    Process.Start("chrome", "https://www.google.com/maps/search/google+maps/@42.5040261,-83.0301713,13z/data=!3m1!4b1");
                    break;
                case "route me":
                    Process.Start("chrome", "https://www.google.com/maps/search/google+maps/@42.5040261,-83.0301713,13z/data=!3m1!4b1");
                    break;
                case "Route me":
                    Process.Start("chrome", "https://www.google.com/maps/search/google+maps/@42.5040261,-83.0301713,13z/data=!3m1!4b1");
                    break;
                case "Routes me":
                    Process.Start("chrome", "https://www.google.com/maps/search/google+maps/@42.5040261,-83.0301713,13z/data=!3m1!4b1");
                    break;
                case "Close":
                    Application.Exit();
                    break;
                case "close":
                    Application.Exit();
                    break;
                case "clear":
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    break;
                case "inputs":
                    ss.SpeakAsync("Enter your City");
                    break;
                case "input":
                    ss.SpeakAsync("Enter your City");
                    break;
                case "Inputs":
                    ss.SpeakAsync("Enter your City");
                    break;
                case "Southfield":
                    textBox1.Clear();
                    textBox2.Text = "Southfield";
                    ss.SpeakAsync("Enter your State");
                    break;      
                case "Michigan":
                    textBox1.Clear();
                    textBox3.Text = "Michigan";
                    break;
                case "Stop":
                    btnStop_Click(sender,e);
                    break;
                case "stop":
                    btnStop_Click(sender, e);
                    break;
            }
            textBox1.Text += e.Result.Text.ToString() + Environment.NewLine;
          
            count++;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            sre.RecognizeAsyncStop();
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
