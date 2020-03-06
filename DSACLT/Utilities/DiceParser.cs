using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSACLT.Utilities
{
    class DiceParser
    {
        static int ParseDie(string input)
        {
            int result = 0;
            input.Replace(" ", "");
            var components = input.Split('+');
            foreach (var component in components)
            {
                if (component.Contains("W"))
                {
                    int diceCount = 1;
                    var WIndex = component.IndexOf("W");
                    if (WIndex != 0)
                    {
                        diceCount = Convert.ToInt32(component.Substring(0, WIndex));
                    }
                    int eyes = Convert.ToInt32(component.Substring(WIndex + 1));
                    var die = new Die(eyes);
                    for(int i = 0; i<diceCount;i++)
                    {
                        result += die.roll();
                    }
                }
                else
                {
                    result += Convert.ToInt32(component);
                }
            }
            return result;
        }
    }
}
