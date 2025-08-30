using System;
using System.IO;
using System.Windows.Forms;


namespace DiablerieLoot
{
    public partial class Main : Form
    {
        private bool _verbose = false;
        private bool _manuel = false;

        public Main()
        {
            InitializeComponent();
            dropdownType.Items.AddRange(new object[] { "Container", "Monster", "Item", "Trap", "Healing Potion", "Gold" });
            dropdownType.Text = "Container";
            _verbose = checkVerbose.Checked;
            _manuel = checkVerbose.Checked;

            FormClosing += Main_FormClosing;

            CreateToolTips();
        }

        private void CreateToolTips()
        {
            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 0;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(numRepeat, "How many Roll attempts that should be performed");
            toolTip1.SetToolTip(numChallengeRating, "Challegne Rating value for monster (or random monster in area if you opening a container)");
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Exit application", "Are you sure you want to exit?", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {            
                Close();
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            var cr = Convert.ToInt32(numChallengeRating.Value);
            var repeat = Convert.ToInt32(numRepeat.Value);

            ItemRoller.Start(this, _manuel, _verbose, cr, dropdownType.Text, repeat);
        }

        private void checkVerbose_CheckedChanged(object sender, EventArgs e)
        {
            _verbose = checkVerbose.Checked;
        }

        private void checkManuel_CheckedChanged(object sender, EventArgs e)
        {
            _manuel = checkManuel.Checked;
        }

        public void WriteToLog(object textObject, bool newLine = true)
        {
            textLog.AppendText(textObject.ToString());
            if (newLine)
                textLog.AppendText(Environment.NewLine);

            textLog.SelectionStart = textLog.Text.Length;
            textLog.ScrollToCaret();
        }

        private void btnCopyContent_Click(object sender, EventArgs e)
        {
            if (LogContainsText())
            {
                textLog.SelectAll();
                Clipboard.SetText(textLog.SelectedText);
                textLog.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (LogContainsText() && MessageBox.Show("Clear log", "Are you sure you want to clear the log?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                textLog.Clear();
        }

        private bool LogContainsText()
        {
            return !String.IsNullOrWhiteSpace(textLog.Text);
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            if (LogContainsText())
            {
                Stream myStream;
                var saveFileDialog1 = new SaveFileDialog
                {
                    Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        foreach (var item in textLog.Text)
                        {
                            myStream.WriteByte(Convert.ToByte(item));
                        }
                        myStream.Close();
                    }
                }
            }
        }
    }
}
