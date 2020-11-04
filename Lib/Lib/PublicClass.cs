namespace Lib {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using System.Threading.Tasks;
    using Lib2;

    public class PublicClass {

        public static class Static_NestedClass {
        }
        public class Instantiable_NestedClass {
        }

        // Static
        public static object Static_Field = "Value";
        public static object Static_Property { get; set; } = "Value";
        public static event Action Static_Event;
        // Instance
        public object Instance_Field = "Value";
        public object Instance_Property { get; set; } = "Value";
        public event Action Instance_Event;


        // Constructor
        static PublicClass() {
        }
        public PublicClass() {
        }


        // Method
        public static string Static_Method() {
            return "Value";
        }
        public string Instance_Method() {
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
