using System;
using System.Windows.Forms;


namespace DiablerieLoot.Forms
{
    public partial class DiceInputDialog : Form
    {
        private int _diceSize;
        private Random _random;
        private bool _offByOne;

        public int DiceResult;

        public DiceInputDialog(int sizeOfDice, string rollName)
        {
            InitializeComponent();
            _random = new Random();
            
            _diceSize = sizeOfDice;
            if ((sizeOfDice + 1) % 10 == 0)
            {
                _diceSize += 1;
                _offByOne = true;
            }
            
            lblDice.Text = lblDice.Text.Replace("<X>", _diceSize.ToString());
            lblRollType.Text = rollName;
            numDiceRoll.Minimum = 1;
            numDiceRoll.Maximum = _diceSize;
        }

        private void btnRollForMe_Click(object sender, EventArgs e)
        {
            numDiceRoll.Value = _random.Next(1, _diceSize + 1);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DiceResult = Convert.ToInt32(numDiceRoll.Value);
            if (_offByOne)
                DiceResult -= 1;
            Close();
        }
    }
}
