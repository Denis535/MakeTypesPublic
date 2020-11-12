namespace Lib {
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class InternalClass {

        private static class NestedClass_Static {
        }
        private class NestedClass_Instantiable {
        }

        // Static
        private static object Field_Static = "Value";
        private static object Property_Static { get; set; } = "Value";
        private static event Action Event_Static;
        // Instance
        private object Field_Instance = "Value";
        private object Property_Instance { get; set; } = "Value";
        private event Action Event_Instance;


        // Constructor
        static InternalClass() {
        }
        private InternalClass() {
        }


        // Method
        private static string Method_Static() {
            return "Value";
        }
        private string Method_Instance() {
            return "Value";
        }


    }
}
