using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSACLT.Parser
{
    abstract class Action
    {
        public string Identifier { get; set; }
        public string Description { get; set; }
        public string Usage { get; set; }
        abstract public bool HandleCommandWithArgs(string input);
        abstract public bool HandleCommandWithoutArgs();

    }
}
