using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Transactions;
using DiceRoller.Properties;

namespace DiceRoller
{
    public partial class Form1 : Form
    {
        private const string numeric = "0123456789";
        private const string tokens = "r#n,:+-d>";

        public Form1()
        {
            InitializeComponent();
        }
        private void Do_Custom()
        {
            //assume no need for attack roll, assume 1 repetition, assume no additive value, assume >0
            int numberreps = 1, plustohit = int.MaxValue /*will use as no need for to hit*/, additive = 0, greaterthan = 0;
            //assume 1 die, assume keeping all dice, make no assumption about die type
            int numberdice = 1, numberkeep = -1, dietype = 1;
            bool doneafterroll = false;
            string customtext = customroll.Text;
            resultsbox.Text += customtext + "\n";
            //get rid of white space
            while (customtext.Contains(' '))
                customtext = customtext.Remove(customtext.IndexOf(" "));
            while (customtext.Contains('\t'))
                customtext = customtext.Remove(customtext.IndexOf("\t"));
            //convert to lowercase
            customtext = customtext.ToLower();
            //check for stats and clear, run appropriate function if so
            if ((customtext == "stats") || (customtext == "scores") || (customtext.StartsWith("abil")))
            {
                Do_Stats();
                return;
            }
            if (customtext == "clear")
            {
                customroll.Text = "";
                return;
            }
            if ((customtext == "help") || (customtext == "?"))
            {
                resultsbox.Text = CustomHelp();
                return;
            }
            if ((customtext == "about") || (customtext == "copyright"))
            {
                resultsbox.Text = AboutText();
                return;
            }
            if ((customtext == "quit") || (customtext == "exit"))
            {
                Application.Exit();
                return;
            }
            //seperate into numbers, "r", "#", ",", ":", "+", "-", "d", and ">"
            List<string> custtext = ParseOut(customtext + ".");
            int index = 0;
            //if begins with "#" number, go into doing rest number times (continue parsing)
            if (CheckIt(custtext, 0, "#n"))//if (custtext[0] == "#")
            {
                if (CheckNum(custtext, 1))
                    _ = int.TryParse(custtext[1], out numberreps);
                if (custtext.Count > 2)
                {
                    if (CheckIt(custtext, 2, ":,"))
                        index = 3;
                }
                else
                    index = 2;
            }
            //if begins with "r", go into roll to attack, check for "," and if needed continue parsing
            if (CheckIt(custtext, index, "r"))
            {
                if (CheckIt(custtext, index + 1, "+-"))
                    index++; //add 1 to index as +/- is optional
                if (CheckNum(custtext, index + 1))
                {
                    _ = int.TryParse(custtext[index + 1], out plustohit);
                    if (CheckIt(custtext, index, "-")) //if + or - was used, this will be that, otherwise will be "r".
                        plustohit *= -1;
                }
                if (CheckIt(custtext, index + 2, ":,"))
                {
                    doneafterroll = false;
                    index += 3;
                }
                else
                {
                    doneafterroll = true;
                    index += 2;
                }
            }
            //if begins with number ":" number, go into rolling and keeping dice
            if (CheckIt(custtext, index + 1, ":,"))//if (custtext[index + 1] == ":")
            {
                if (CheckNum(custtext, index))
                {
                    _ = int.TryParse(custtext[index], out numberkeep);
                    index += 2;
                }
                else
                {
                    numberkeep = -1;
                    index += 1;
                }
            }
            //parse into number "d" number "+" number
            if (CheckIt(custtext, index + 1, "d"))
            {
                if (CheckNum(custtext, index))
                {
                    _ = int.TryParse(custtext[index], out numberdice);
                    if (CheckNum(custtext, index + 2))
                    {
                        _ = int.TryParse(custtext[index + 2], out dietype);
                        index += 3;
                    }
                    else index += 2;
                }
            }
            if (CheckIt(custtext, index, "+-"))
            {
                _ = int.TryParse(custtext[index + 1], out additive);
                if (CheckIt(custtext, index, "-")) additive *= -1;
                index += 2;
            }
            //if ends with ">" number, apply rules for ignoring lower rolls
            if (CheckIt(custtext, index, ">"))
            {
                _ = int.TryParse(custtext[index + 1], out greaterthan);
            }
            for (int nr = 0; nr < numberreps; nr++)
            {
                string s = "";
                if (numberreps > 1)
                    s += string.Format("#{0,2}: ", nr + 1); //"#" + (nr + 1) + ": ";
                if (plustohit != int.MaxValue)
                {
                    s += Dice.RollToHit(plustohit);
                    if (doneafterroll)
                        s += "\n";
                    else
                        s += ": ";
                    //resultsbox.Text += s;
                }
                if (!doneafterroll)
                {
                    if (numberkeep != -1)
                    {
                        s += Dice.RollDice(numberdice, dietype, numberkeep, additive, greaterthan) + "\n";
                    }
                    else
                        s += Dice.RollDice(numberdice, dietype, additive, greaterthan) + "\n";
                }
                resultsbox.Text += s;
            }
        }

        private static bool CheckIt(List<string> ct, int i, string cv) //returns true if any character in ct[i] equals any character in cv
        {
            if (i < ct.Count)
            {
                foreach (char ctc in ct[i])
                {
                    foreach (char c in cv)
                    {
                        if (ctc == c) return true;
                    }
                }
            }
            return false;
        }

        private static bool CheckNum(List<string> ct, int i)
        {
            return CheckIt(ct, i, numeric);
        }

        private static string CustomHelp()
        {
            string retstr = "Custom Rolls:\n\n";
            retstr += "help: get this help screen.\n";
            retstr += "about: get about information.\n";
            retstr += "stats: rolls 6 stats values (2:3d6+6>1).\n";
            retstr += "clear: clear the results area.\n";
            retstr += "quit: quit this program.\n\n";
            retstr += "#n:formula = does formula n times.\n";
            retstr += "r+n = roll with a +n to hit.  (Note the + could be a -.)\n";
            retstr += "r+n:formula = roll then use formula to calculate damage.\n";
            retstr += "k:ndt+a>g = roll n dice of t sides, ignoring rolls not greater than g, keeping k of the rolls, then adding a.\n";
            retstr += "k:ndt+a = roll n dice of t sides, keeping k of the rolls, then adding a.\n";
            retstr += "k:ndt = roll n dice of t sides, keeping k of the rolls.\n";
            retstr += "ndt+a = roll n dice of t sides then add a.\n";
            retstr += "ndt = roll n dice of t sides.\n\n";
            retstr += "(in all the above formulae, a '-' can be substituted for a '+' to indicate a negative number.)\n\n";
            return retstr;
        }

        private static List<string> ParseOut(string text)
        {
            int index = 0;
            List<string> strlist = new();
            strlist.Clear();
            while (index < text.Length)
            {
                if ((numeric.Contains(text[index])) || (tokens.Contains(text[index])))
                {
                    if (numeric.Contains(text[index]))
                    {
                        int l = 0;
                        while (numeric.Contains(text[index + l])) l++; //get length of numeric value
                        strlist.Add(text.Substring(index, l));
                        index += l;
                    }
                    else if (tokens.Contains(text[index]))
                    {
                        strlist.Add(text[index].ToString());
                        index++;
                    }
                }
                else
                {
                    index++;
                }
            }
            return strlist;
        }

        private void Do_Stats()
        {
            resultsbox.AppendText("Stats Values:\n");
            for (int i = 0; i < 6; i++)
            {
                string r = Dice.RollDice(3, 6, 2, 6, 1) + "\n";
                resultsbox.AppendText(r);
            }
        }

        private void DoDice(int sides)
        {
            int n = (int)numberdice.Value;
            int a = (int)plusamount.Value;
            string r = Dice.RollDice(n, sides, a) + "\n";
            resultsbox.AppendText(r);
        }

        private void DoStats(object sender, EventArgs e) => Do_Stats();
        private void Do_d4(object sender, EventArgs e) => DoDice(4);
        private void Do_d6(object sender, EventArgs e) => DoDice(6);
        private void Do_d8(object sender, EventArgs e) => DoDice(8);
        private void Do_d10(object sender, EventArgs e) => DoDice(10);
        private void Do_d12(object sender, EventArgs e) => DoDice(12);
        private void Do_d20(object sender, EventArgs e) => DoDice(20);
        private void Do_d100(object sender, EventArgs e) => DoDice(100);
        private void ShowCustomRollHelp(object sender, EventArgs e) => resultsbox.Text += CustomHelp();
        private void ClearResults(object sender, EventArgs e) => resultsbox.Text = "";
        private void AboutIt(object sender, EventArgs e) => resultsbox.Text = AboutText();

        private void CustomKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Do_Custom();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private static string AboutText()
        {
            string retstr = "About Dice Roller\n";
            retstr += "\tEnjoy!\nCopyright (c) 2023,\nby John Worthington\nAll rights reserved.\n\nwoodmage@gmail.com\n";
            return retstr;
        }

        private void HandleCustomBtn(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                resultsbox.Text += CustomHelp();
            }
            if (e.Button == MouseButtons.Right)
                tooltip.Active = !tooltip.Active;
        }
    }
}
