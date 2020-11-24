namespace Lib {
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class InternalClass {

        internal static class NestedClass_Static {
        }
        internal class NestedClass_Instantiable {
        }

        // Static
        internal static object Field_Static = "Value";
        internal static object Property_Static { get; set; } = "Value";
        internal static event Action Event_Static;
        // Instance
        internal object Field_Instance = "Value";
        internal object Property_Instance { get; set; } = "Value";
        internal event Action Event_Instance;


        // Constructors
        static InternalClass() {
        }
        internal InternalClass() {
        }


        // Methods
        internal static string Method_Static() {
            return "Value";
        }
        internal string Method_Instance() {
            return "Value";
        }


    }
}
