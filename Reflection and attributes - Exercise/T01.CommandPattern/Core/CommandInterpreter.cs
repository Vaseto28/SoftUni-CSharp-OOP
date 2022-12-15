namespace CommandPattern.Core
{
    using System.Reflection;
    using System.Linq;
    using Contracts;
    using System;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] info = args.Split();
            string cmdName = info[0];
            string[] cmdArgs = info.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type cmdType = assembly?
                .GetTypes()
                .FirstOrDefault(x => x.Name == $"{cmdName}Command"
                    && x.GetInterfaces().Any(x => x == typeof(ICommand)));

            if (cmdType == null)
            {
                throw new NullReferenceException();
            }

            object cmdInstance = Activator.CreateInstance(cmdType);
            MethodInfo methodInfo = cmdType.GetMethods().First(m => m.Name == "Execute");

            string result = (string)methodInfo.Invoke(cmdInstance, new object[] { cmdArgs });

            return result;
        }
    }
}

