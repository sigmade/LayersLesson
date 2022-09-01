using DataLayer.Models;
using System.Reflection;
using System.Text.Json;

namespace StubGenerator
{
    public class CreatorStubFile
    {
        private static Assembly Assembly;

        public static void Init()
        {
            Assembly = Assembly.GetAssembly(typeof(StubGenAttribute));

            var types = Assembly.GetTypes();
            var typesWithAtr = types.Where(t => t.IsDefined(typeof(StubGenAttribute)));

            foreach (var type in typesWithAtr)
            {
                var inst = NewInstance(type);
                if (inst != null)
                {
                    WriteToFile(new object[] { inst, inst }, type.Name);
                }
            }
        }

        public static object NewInstance(Type type)
        {
            var props = type.GetProperties();

            if (props.Count() < 1)
            {
                return null;
            }

            var instance = Activator.CreateInstance(type);

            foreach (var prop in props)
            {
                switch (prop.PropertyType.Name)
                {
                    case "String":
                        prop.SetValue(instance, "SomeString");
                        break;
                    case "Int32":
                        prop.SetValue(instance, 152);
                        break;
                    case "Decimal":
                        prop.SetValue(instance, 150M);
                        break;
                    case "Boolean":
                        prop.SetValue(instance, true);
                        break;
                    default:
                        prop.SetValue(instance, null);
                        break;
                }

                if (prop.IsDefined(typeof(InnerStubGenAttribute)))
                {
                    var innerInst = NewInstance(prop.PropertyType);
                    prop.SetValue(instance, innerInst);
                }
            }
            return instance;
        }

        public static void WriteToFile(object[] list, string fileName)
        {
            var filePath = $"./MockModels/{fileName}.json";

            // Serialize
            var jsonString = JsonSerializer.Serialize(list);

            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(jsonString);
            }
        }
    }
}
