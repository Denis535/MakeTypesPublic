namespace MakeTypesPublic.Tasks {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;

    public class MakeAssemblyInfoTask : Task {

        private const string Usage_IgnoresAccessChecksToAttribute =
"[assembly: System.Runtime.CompilerServices.IgnoresAccessChecksTo( \"{0}\" )]";

        private const string Declaration_IgnoresAccessChecksToAttribute =
@"namespace System.Runtime.CompilerServices {
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    internal sealed class IgnoresAccessChecksToAttribute : Attribute {
        public IgnoresAccessChecksToAttribute(string assembly) {
        }
    }
}";

        [Required]
        public string[] References { get; set; }
        [Required]
        public string DirectoryToSave { get; set; }

        [Output]
        public string Output { get; set; }


        public override bool Execute() {
            var builder = new StringBuilder();
            foreach (var item in References.Select( Path.GetFileNameWithoutExtension )) {
                builder.AppendFormat( Usage_IgnoresAccessChecksToAttribute, item ).AppendLine();
            }
            builder.AppendLine();
            builder.AppendLine( Declaration_IgnoresAccessChecksToAttribute );

            Output = Path.Combine( DirectoryToSave, "AssemblyInfo.cs" );
            Save( Output, builder.ToString(), Log );
            return true;
        }


        // Helpers
        private static void Save(string path, string content, TaskLoggingHelper log) {
            Directory.CreateDirectory( Path.GetDirectoryName( path ) );
            File.WriteAllText( path, content );
            log.LogMessage( MessageImportance.High, "[MakeTypesPublic] New source code: {0}", path );
        }


    }
}
