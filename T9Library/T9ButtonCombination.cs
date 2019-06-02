using MessageLibrary;
using System;

namespace T9Library
{
    public class T9ButtonCombination : ButtonCombination
    {
        private T9ButtonCombination(char[] chars) : base(chars) { }        
        public static T9ButtonCombination CreateFromDigits(params int[] digits)
        {
            int offset = (int)'0';
            char[] chars = new char[digits.Length];
            for (int i = 0; i < digits.Length; i++)
            {
                chars[i] = (char)(digits[i] + offset);
            }
            return new T9ButtonCombination(chars);
        }
        public bool ShouldWaitPause(T9ButtonCombination other)
        {
            return this.Buttons[0] == other.Buttons[0];
        }
    }
}
