using System.Reflection;
using System.Text.Json;

namespace AutocompleteTypes
{
    public class AutoGen
    {
        private static Assembly Assembly;

        public static void Init()
        {
            Assembly = Assembly.GetAssembly(typeof(StubGenAttribute));

            var types = Assembly.GetTypes();
            var typesWithAtr = types.Where(t => t.IsDefined(typeof(StubGenAttribute)));

            foreach (var type in typesWithAtr)
            {
                var obj = GenObject(type.Name);
                if (obj != null)
                {
                    WriteToFile(new object[] { obj, obj }, type.Name);
                }
            }
        }

        public static object GenObject(string typeString)
        {
            var types = Assembly.GetTypes();
            var type = types.Where(t => t.Name == typeString).FirstOrDefault();

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
                    case "Single":
                        prop.SetValue(instance, 150f);
                        break;
                    case "Boolean":
                        prop.SetValue(instance, true);
                        break;
                    default:
                        break;
                }

                if (prop.IsDefined(typeof(InnerStubGenAttribute)))
                {
                    var inst = GenObject(prop.PropertyType.Name);
                    prop.SetValue(instance, inst);
                }
            }
            return instance;
        }

        public static void WriteToFile(object[] list, string fileName) 
        {
            var filePath = $"./MockModels/{fileName}.json";
            var jsonString = JsonSerializer.Serialize(list);
            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(jsonString);
            }
        }
    }
}
