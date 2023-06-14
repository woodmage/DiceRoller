using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DiceRoller
{
    internal class Dice
    {
        private static readonly Random random = new();
        public static int RollDie(int sides)
        {
            return random.Next(1, sides + 1);
        }
        public static string RollToHit(int plus)
        {
            string retstr = "To Hit: ";
            int nr = RollDie(20);
            int r1 = nr + plus;
            retstr += string.Format("{0,2}", r1);
            if (nr == 20) retstr += " CRIT HIT!";
            if (nr == 1) retstr += " CRIT FAIL!";
            retstr += ", ";
            nr = RollDie(20);
            int r2 = nr + plus;
            retstr += string.Format("{0,2}", r2);
            if (nr == 20) retstr += " CRIT HIT!";
            if (nr == 1) retstr += " CRIT FAIL!";
            retstr += " Adv: ";
            if (r1 > r2) retstr += r1 + ", Disadv: " + r2;
            else retstr += r2 + ", Disadv: " + r1;
            return retstr;
        }
        public static string RollDice(int number, int sides, int keep, int add, int greaterthan)
        {
            string retstr = "Rolling " + number + "d" + sides + " and keeping the top " + keep + " rolls";
            if (greaterthan != 0) retstr += ", ignoring rolls not greater than " + greaterthan;
            if (add > 0) retstr += ", then adding " + add;
            if (add < 0) retstr += ", then subtracting " + Math.Abs(add);
            retstr += ": ";
            List<int> rolls = new();
            rolls.Clear();
            if (number == 1) retstr += "("; else retstr += "{";
            for (int i = 0; i < number; i++)
            {
                int r = greaterthan;
                while (r <= greaterthan)
                {
                    r = RollDie(sides);
                }
                rolls.Add(r);
                retstr += string.Format("{0,2}", r);
                //r.ToString("D").ToString("S2");
                if (i + 1 < number) retstr += ", ";
            }
            if (rolls.Count - keep > 0) retstr += " removing ";
            while (keep < rolls.Count)
            {
                int i = rolls.Min();
                rolls.Remove(i);
                retstr += i;
                if (keep < rolls.Count) retstr += ",";
            }
            if (number == 1) retstr += ")"; else retstr += "}";
            int total = rolls.Sum() + add;
            retstr += " = " + total;
            return retstr;
        }
        public static string RollDice(int number, int sides, int add, int greaterthan)
        {
            string retstr = "Rolling " + number + "d" + sides;
            if (greaterthan != 0) retstr += ", ignoring rolls not greater than " + greaterthan;
            if (add > 0) retstr += ", then adding " + add;
            if (add < 0) retstr += ", then subtracting " + Math.Abs(add);
            retstr += ": ";
            List<int> rolls = new();
            rolls.Clear();
            if (number == 1) retstr += "("; else retstr += "{";
            for (int i = 0; i < number; i++)
            {
                int r = greaterthan;
                while (r <= greaterthan)
                {
                    r = RollDie(sides);
                }
                rolls.Add(r);
                retstr += string.Format("{0,2}", r);
                if (i + 1 < number) retstr += ", ";
            }
            if (number == 1) retstr += ")"; else retstr += "}";
            int total = rolls.Sum() + add;
            retstr += " = " + total;
            return retstr;
        }
        public static string RollDice(int number, int sides)
        {
            return RollDice(number, sides, 0);
        }
        public static string RollDice(int number, int sides, int add)
        {
            string retstr = "Rolling " + number + "d" + sides;
            if (add > 0) retstr += ", then adding " + add;
            if (add < 0) retstr += ", then subtracting " + Math.Abs(add);
            retstr += ": ";
            int total = 0;
            if (number == 1) retstr += "("; else retstr += "{";
            for (int i = 0; i < number; i++)
            {
                int r = RollDie(sides);
                retstr += string.Format("{0,2}", r);
                if (i + 1 < number) retstr += ", ";
                total += r;
            }
            if (number == 1) retstr += ")"; else retstr += "}";
            total += add;
            retstr += " = " + total;
            return retstr;
        }
    }
}
