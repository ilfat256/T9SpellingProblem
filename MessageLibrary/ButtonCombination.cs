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
        protected char[] Buttons { get; }
        
        public ButtonCombination(char[] buttons)
        {
            Buttons = buttons;
            combination = new string(buttons);
        }

        public override string ToString()
        {
            return combination;
        }
    }
}
