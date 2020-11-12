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
        public ITaskItem[] References { get; set; }
        [Required]
        public string DirectoryToSave { get; set; }

        [Output]
        public ITaskItem Output { get; set; }


        public override bool Execute() {
            var content = GetAssemblyInfoContent( References.Select( i => i.ItemSpec ).Select( Path.GetFileNameWithoutExtension ) );
            Output = new TaskItem( Path.Combine( DirectoryToSave, "AssemblyInfo.cs" ) );
            Save( Output.ItemSpec, content, Log );
            return true;
        }


        // Helpers
        private static string GetAssemblyInfoContent(IEnumerable<string> assemblies) {
            var builder = new StringBuilder();
            foreach (var item in assemblies) {
                builder.AppendFormat( Usage_IgnoresAccessChecksToAttribute, item ).AppendLine();
            }
            builder.AppendLine();
            builder.AppendLine( Declaration_IgnoresAccessChecksToAttribute );
            return builder.ToString();
        }
        private static void Save(string path, string content, TaskLoggingHelper log) {
            Directory.CreateDirectory( Path.GetDirectoryName( path ) );
            File.WriteAllText( path, content );
#if DEBUG
            log.LogMessage( MessageImportance.High, "[MakeTypesPublic] New source code: {0}", path );
#endif
        }


    }
}
