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
            maxIdentifierLength = 0;
            maxUsageLength = 0;
            maxDescriptionLength = 0;
            actions = new List<Action>();
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
            maxIdentifierLength = Math.Max(maxIdentifierLength, action.Identifier.Length);
            maxDescriptionLength = Math.Max(maxDescriptionLength, action.Description.Length);
            maxUsageLength = Math.Max(maxUsageLength, action.Usage.Length);
        }
        public override bool HandleCommandWithArgs(string input)
        {
            int firstSpace = input.IndexOf(" ");
            string identifier = input.Substring(0, firstSpace);
            foreach (var currAction in actions)
            {
                if (identifier == currAction.Identifier)
                {
                    if (input.Length == identifier.Length)
                    {
                        return currAction.HandleCommandWithoutArgs();
                    }
                    else
                    {
                        return currAction.HandleCommandWithArgs(input.Substring(firstSpace + 1));
                    }
                }
            }
            if (input == "help")
            {
                foreach (var action in actions)
                {
                    WriteTextWithFixedSize(maxIdentifierLength, action.Identifier);
                    WriteTextWithFixedSize(maxUsageLength, action.Usage);
                    WriteTextWithFixedSize(maxDescriptionLength, action.Description);
                }
                return true;
            }
            throw new ArgumentException("Unknown Identifier");
        }

        public override bool HandleCommandWithoutArgs()
        {
            return true;
        }

        private void WriteTextWithFixedSize(int size, string text)
        {
            Console.Write(text);
            for(int i = text.Length; i< size; i++)
            {
                Console.Write(" ");
            }
        }

        private List<Action> actions;
        private int maxIdentifierLength;
        private int maxUsageLength;
        private int maxDescriptionLength;
    }
}
