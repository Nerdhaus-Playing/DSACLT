using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSACLT.Parser
{
    class Parser : Action
    {
        public Parser()
        {

        }
        public void addCommandAction(Action action)
        {
            foreach (var currAction in actions)
            {
                if (action.Identifier == currAction.Identifier)
                {
                    throw new ArgumentException("Identifier already in use");
                }
            }
            actions.Add(action);
        }
        public override bool HandleCommandWithArgs(string input)
        {
            int firstSpace = input.IndexOf(" ");
            string identifier = input.Substring(0, firstSpace);
            foreach (var currAction in actions)
            {
                if (identifier == currAction.Identifier)
                {
                    if(input.Length == identifier.Length)
                    {
                        return currAction.HandleCommandWithoutArgs();
                    }
                    else
                    {
                        return currAction.HandleCommandWithArgs(input.Substring(firstSpace + 1));
                    }
                }
            }
            throw new ArgumentException("Unknown Identifier");
        }

        public override bool HandleCommandWithoutArgs()
        {
            return true;
        }

        private List<Action> actions;
    }
}
