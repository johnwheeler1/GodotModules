using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GodotModules 
{
    public class CommandHelp : Command 
    {
        private readonly static List<string> CommandNames = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(Command).IsAssignableFrom(x) && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<Command>()
                .Select(x => x.GetType().Name.Replace("Command", "").ToLower()).ToList();
        
        public override void Run(string[] args)
        {
            Utils.Log($"Commands:\n{CommandNames.Print()}");
        }
    }
}