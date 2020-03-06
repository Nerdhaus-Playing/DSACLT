using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSACLT.Utilities
{
    class Die
    {
        public Die(int eyes)
        {
            Eyes = eyes;
            if (random == null)
            {
                random = new Random();
            }
        }

        public int roll()
        {
            return random.Next(1, Eyes);
        }

        public int Eyes { get; set; }
        static private Random random;
    }
}
