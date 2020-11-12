namespace Lib {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using System.Threading.Tasks;
    using Lib2;

    public class PublicClass {

        public static class NestedClass_Static {
        }
        public class NestedClass_Instantiable {
        }

        // Static
        public static object Field_Static = "Value";
        public static object Property_Static { get; set; } = "Value";
        public static event Action Event_Static;
        // Instance
        public object Field_Instance = "Value";
        public object Property_Instance { get; set; } = "Value";
        public event Action Event_Instance;


        // Constructor
        static PublicClass() {
        }
        public PublicClass() {
        }


        // Method
        public static string Method_Static() {
            return "Value";
        }
        public string Method_Instance() {
            return "Value";
        }


        // Examples
        internal static void Example() {
            try {
                //var message = "Hello World !!!";
                var message = new HelloWorldClass().ToString();
                Trace.WriteLine( message );
            } catch (Exception ex) {
                Trace.WriteLine( ex );
            }
        }
        internal static string Example_GetValue() {
            return "Value";
        }
        internal static async Task<string> Example_GetValueAsync() {
            await Task.Yield();
            return "Value";
        }
        internal static IEnumerable<string> Example_GetValues() {
            yield return "Value";
        }
        internal static async IAsyncEnumerable<string> Example_GetValuesAsync() {
            await Task.Yield();
            yield return "Value";
        }


    }
}
