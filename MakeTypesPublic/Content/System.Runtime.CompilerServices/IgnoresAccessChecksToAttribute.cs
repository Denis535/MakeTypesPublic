namespace System.Runtime.CompilerServices {
    using System;
    using System.Collections.Generic;
    using System.Text;

    [AttributeUsage( AttributeTargets.Assembly, AllowMultiple = true )]
    internal sealed class IgnoresAccessChecksToAttribute : Attribute {
        public IgnoresAccessChecksToAttribute(string assembly) {
        }
    }
}
