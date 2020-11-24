namespace Lib {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Lib2;

    internal class ExampleClass : IDisposable, IAsyncDisposable {


        public ExampleClass() {
        }
        public void Dispose() {
        }
        ValueTask IAsyncDisposable.DisposeAsync() {
            return default;
        }


        // Sync
        private static string Example_GetValue() {
            return "Value";
        }
        private static IEnumerable<string> Example_GetValues() {
            yield return "Value";
        }


        // Async
        private static async Task<string> Example_GetValueAsync() {
            await Task.Yield();
            return "Value";
        }
        private static async IAsyncEnumerable<string> Example_GetValuesAsync() {
            await Task.Yield();
            yield return "Value";
        }


        // Misc
        private static void Example_Declaration_Arguments(HelloWorldClass arg) {
        }
        private static HelloWorldClass Example_Declaration_Result() {
            return new HelloWorldClass();
        }
        private static void Example_Body_LocalVariables() {
            var a = 1;
            var b = 2;
            var c = 3;
        }
        private static void Example_Body_HandleException() {
            try {
                throw new Exception( "Hello World !!!" );
            } catch (Exception ex) {
            }
        }


    }
}
