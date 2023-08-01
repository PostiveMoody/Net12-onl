using System.Reflection;

namespace ConsoleApplication
{
    public class Runner
    {
        static void Main()
        {
            var calculator = LoadFrom("MyLibrary.dll", "MyLibrary.Calculator");
            var methodInfo = calculator.GetMethod("Add");
            double result = (double)methodInfo.Invoke(null, new object[] { 3,4 }) ;

            Console.WriteLine(result);
        }

        static Type LoadFrom(string assemblyFile, string fullNameType)
        {
            if(string.IsNullOrWhiteSpace(assemblyFile))
                throw new ArgumentNullException(nameof(assemblyFile));
            if(string.IsNullOrWhiteSpace(fullNameType))
                throw new ArgumentNullException(nameof(fullNameType));

            Assembly assembly =  Assembly.LoadFrom(assemblyFile);

            if(assembly is null)
                throw new ArgumentNullException(nameof(assembly));

            //If the type is not found throw exception
            Type type = assembly.GetType(fullNameType, false);

            return type;
        }
    }
}