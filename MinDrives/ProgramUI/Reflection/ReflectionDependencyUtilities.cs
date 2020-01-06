using BusinessLogic.Interface;
using Strategies.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ProgramUI.Reflection
{
    public static class ReflectionDependencyUtilities
    {       

        public static ICalculatorLogic GetCalculatorLogic()
        {
            try
            {
                string nameDllFile = System.Configuration.ConfigurationManager.AppSettings["ICalculatorLogic"];
                string pathGlobal = System.IO.Directory.GetCurrentDirectory() + "\\" + nameDllFile;                
                var dllFile = new FileInfo(pathGlobal);
                Assembly assembly = Assembly.LoadFrom(dllFile.FullName);
                IEnumerable<Type> implementations = GetTypesInAssembly<ICalculatorLogic>(assembly);
                ICalculatorLogic calculator = (ICalculatorLogic)Activator.CreateInstance(implementations.First(), new object[] { });
                return calculator;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new ReflectionException("There is a problem to find ICalculatorLogic dll",e);
            }            
        }

        internal static IStrategy GetStrategy()
        {
            try
            {
                string nameDllFile = System.Configuration.ConfigurationManager.AppSettings["IStrategy"];
                string pathGlobal = System.IO.Directory.GetCurrentDirectory() + "\\" + nameDllFile;
                Console.WriteLine(pathGlobal);
                var dllFile = new FileInfo(pathGlobal);
                Assembly assembly = Assembly.LoadFrom(dllFile.FullName);
                IEnumerable<Type> implementations = GetTypesInAssembly<IStrategy>(assembly);
                IStrategy strategy = (IStrategy)Activator.CreateInstance(implementations.First(), new object[] { });
                return strategy;
            }
            catch (Exception e)
            {                
                throw new ReflectionException("There is a problem to find IStrategy dll",e);
            }
        }

        private static IEnumerable<Type> GetTypesInAssembly<Interface>(Assembly assembly)
        {
            List<Type> types = new List<Type>();
            foreach (var type in assembly.GetTypes())
            {
                if (typeof(Interface).IsAssignableFrom(type))
                    types.Add(type);
            }
            return types;
        }
    }
}
