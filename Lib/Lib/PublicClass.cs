namespace Lib {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

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


        static PublicClass() {
        }
        public PublicClass() {
        }


        public static void Static_Method() {
        }
        public IEnumerable<object> Instance_Method() {
            int v0 = 0, v1 = 1, v2 = 2;
            try {
                Trace.WriteLine( "Hello World !!!" );
            } catch {
            }
            yield return v0;
            yield return v1;
            yield return v2;
        }


    }
}
