using DiablerieLoot.Forms;
using System;


namespace DiablerieLoot
{
    public static class DiceRoller
    {
        public static bool ManuelRoll = false;
        private static readonly Random Random = new Random();

        public static int RandNumber(int start, int stop, string rollName, bool verbose = false)
        {
            int roll;

            if (ManuelRoll)
            {
                if (start != 1)
                    stop -= start;

                var inp = new DiceInputDialog(stop, rollName);
                inp.ShowDialog();
                roll = inp.DiceResult;

                if (start != 1)
                    roll += start;
            }
            else
                roll = Random.Next(start, stop + 1);

            if (verbose)
                ItemRoller.Owner.WriteToLog(roll);

            return roll;
        }

        public static int RandNumber20SidedDice(string rollName)
        {
            int roll;

            if (ManuelRoll)
            {
                var inp = new DiceInputDialog(20, rollName);
                inp.ShowDialog();
                roll = inp.DiceResult;
            }
            else
                roll = Random.Next(0, 20);

            return roll;
        }
    }
}
