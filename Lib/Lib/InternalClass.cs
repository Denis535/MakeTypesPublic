namespace Lib {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

    internal class InternalClass {

        private static class Static_NestedClass {
        }
        private class Instantiable_NestedClass {
        }

        // Static
        private static object Static_Field = "Value";
        private static object Static_Property { get; set; } = "Value";
        private static event Action Static_Event;
        // Instance
        private object Instance_Field = "Value";
        private object Instance_Property { get; set; } = "Value";
        private event Action Instance_Event;


        static InternalClass() {
        }
        private InternalClass() {
        }


        private static void Static_Method() {
        }
        private IEnumerable<object> Instance_Method() {
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
