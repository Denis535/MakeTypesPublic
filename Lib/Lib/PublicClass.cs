namespace Lib {
    using System;
    using System.Collections.Generic;
    using System.Text;

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


        // Constructors
        static PublicClass() {
        }
        public PublicClass() {
        }


        // Methods
        public static string Method_Static() {
            return "Value";
        }
        public string Method_Instance() {
            return "Value";
        }


    }
}
