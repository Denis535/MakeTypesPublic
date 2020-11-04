namespace Lib {
    using System;
    using System.Collections.Generic;
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


        // Constructor
        static InternalClass() {
        }
        private InternalClass() {
        }


        // Method
        private static string Static_Method() {
            return "Value";
        }
        private string Instance_Method() {
            return "Value";
        }


    }
}
