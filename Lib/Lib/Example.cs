#pragma warning disable IDE0051 // Remove unused private members
namespace Lib {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    internal class Example : IDisposable, IAsyncDisposable {

        // NestedClass
        private class NestedClass {
        }

        // Field
        private static readonly string Field = "Value";
        // Property
        private static string Property { get; set; } = "Value";
        // Event
        private static event Action? Event;


        // Constructor
        static Example() {
        }
        private Example() {
        }
        ~Example() {
        }
        void IDisposable.Dispose() {
        }
        ValueTask IAsyncDisposable.DisposeAsync() {
            return default;
        }


        // Method
        private static string Method(string arg) {
            return arg;
        }

        // GetValue
        private static string GetValue() {
            return "Value";
        }
        private static async Task<string> GetValueAsync() {
            await Task.Yield();
            return "Value";
        }

        // GetValues
        private static IEnumerable<string> GetValues() {
            yield return "Value";
        }
        private static async IAsyncEnumerable<string> GetValuesAsync() {
            await Task.Yield();
            yield return "Value";
        }


    }
}
