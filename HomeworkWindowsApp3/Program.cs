using System.Reflection;
using MultiThreads3_Homework.Objects;
namespace MultiThreads3_Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task 1 
            Console.WriteLine("Enter path to .dll file");

            string path = Console.ReadLine();
            Assembly asm = Assembly.LoadFrom(path);


            foreach (var type in asm.GetTypes())
            {
                Console.WriteLine(type.FullName);
            }
            //Task 2

            ClassTask2 obj = new ClassTask2();
            Type type = obj.GetType();

            foreach (FieldInfo f in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
                Console.WriteLine("Field: " + f.Name);

            foreach (MethodInfo m in type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance))
                Console.WriteLine("Method: " + m.Name);

            FieldInfo field = type.GetField("number", BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(obj, 99);

            MethodInfo method = type.GetMethod("Show", BindingFlags.NonPublic | BindingFlags.Instance);
            method.Invoke(obj, null);

            //Task 3

            Console.WriteLine("Enter path to .dll file");

            string path = Console.ReadLine();
            Assembly asm = Assembly.LoadFrom(path);

            Type moduleType = asm.GetTypes().FirstOrDefault(t => typeof(IModule).IsAssignableFrom(t) && !t.IsInterface);

            if (moduleType != null)
            {
                object instance = Activator.CreateInstance(moduleType);
                MethodInfo method = moduleType.GetMethod("Execute");
                method.Invoke(instance, null);
            }
            else
            {
                Console.WriteLine("No IModule implementation found");
            }

            //Task 4
            Console.WriteLine("Enter path to .dll file");

            string path = Console.ReadLine();
            Assembly asm = Assembly.LoadFrom(path);

            Console.WriteLine("Assembly: " + asm.GetName().Name);
            Console.WriteLine("Version: " + asm.GetName().Version);

            var types = asm.GetTypes().GroupBy(t => t.Namespace);

            foreach(var group in types)
            {
                Console.WriteLine($"Namespace: {group.Key}");
                Console.WriteLine($"Types count: {group.Count()}");
            }
        }
    }
}
