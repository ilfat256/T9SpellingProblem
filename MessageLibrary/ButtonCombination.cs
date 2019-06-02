using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLibrary
{
    public class ButtonCombination
    {
        private string combination;
        public ButtonCombination(char[] buttons)
        {
            Buttons = buttons;
            combination = new string(buttons);
        }

        public char[] Buttons { get; }

        public override string ToString()
        {
            return combination;
        }

        public static ButtonCombination CreateFromDigits(params int[] digits)
        {
            int offset = (int)'0';
            char[] chars = new char[digits.Length];
            for (int i = 0; i < digits.Length; i++)
            {
                chars[i] = (char)(digits[i] + offset);
            }
            return new ButtonCombination(chars);
        }
    }
}
