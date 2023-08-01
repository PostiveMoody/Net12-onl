using System.Reflection;

namespace ConsoleApplication
{
    public class Runner
    {
        static void Main()
        {
            var pathToLibrary = "C:\\Users\\Alice White\\source\\repos\\Net12-onl\\MyLibrary\\MyLibrary\\bin\\Debug\\net6.0\\MyLibrary.dll";
            var calculator = LoadFrom(pathToLibrary, "MyLibrary.Calculator");
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