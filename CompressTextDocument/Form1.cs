using CompressTextDocument.Archiver;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CompressTextDocument
{
    public partial class Form1 : Form
    {
        IArhiver _archiver;
        bool _isCompressing;
        public Form1(IArhiver archiver)
        {
            InitializeComponent();
            _archiver = archiver;
            _archiver.OnProgressChanged += _archiver_OnProgressChanged;
        }

        private void _archiver_OnProgressChanged(object o, ProgressEventArgs progress)
        {
            CompressionProgress.Value = progress.Progress;
            if (CompressionProgress.Value == 100 && OpenAfterCompressionCheckBox.Checked)
            {
                Process.Start(@"C:\Windows\explorer.exe", DestinationTextBox.Text);
            }
        }

        public Form1() : this(new Arhiver())
        {

        }

        private void CompressBtn_Click(object sender, EventArgs e)
        {
            string message = "";
            int dictSize, maxWords;
            if (string.IsNullOrEmpty(OpenTextBox.Text) || !File.Exists(OpenTextBox.Text))
            {
                message += "Wrong Input file parameter\n";
            }
            if (string.IsNullOrEmpty(DestinationTextBox.Text) || !Directory.Exists(DestinationTextBox.Text))
            {
                message += "Wrong Destination parameter\n";
            }

            if (!int.TryParse(DictSizeTextBox.Text, out dictSize))
            {
                message += "Wrong DictionarySize parameter\n";
            }
            if (!int.TryParse(MaxLengthTextBox.Text, out maxWords))
            {
                message += "Wrong Max word length parameter\n";
            }
            if (string.IsNullOrEmpty(message))
            {
                if (_isCompressing)
                {
                    var options = new ArhiverInputOptions
                    {
                        File = OpenTextBox.Text,
                        Destination = DestinationTextBox.Text,
                        DictionarySize = dictSize,
                        MaxWordSize = maxWords,
                        CompressRepeating = checkBox2.Checked,
                        FromMinToMax = checkBox1.Checked,
                        DebugMode = checkBox3.Checked
                    };
                    _archiver.Compress(options);
                }
                else
                {
                    var options = new ArhiverOutputOptions
                    {
                        File = OpenTextBox.Text,
                        Destination = DestinationTextBox.Text,

                    };
                    _archiver.UnCompress(options);
                }
            }
            else
            {
                MessageBox.Show(message);
            }
        }



        private void OpenBtn_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|tarc files (*.tarc)|*.tarc";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenTextBox.Text = openFileDialog.FileName;
                _isCompressing = openFileDialog.FilterIndex == 1;

            }

        }


        private void DestinationBtn_Click(object sender, EventArgs e)

        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                DestinationTextBox.Text = fbd.SelectedPath;
            }

        }

        private void MaxLengthTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DictSizeTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
