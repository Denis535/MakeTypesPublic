namespace MakeTypesPublic.Tasks {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using Mono.Cecil;

    public class MakeAssemblyTask : Task {

        [Required]
        public string Reference { get; set; }
        [Required]
        public string DirectoryToSave { get; set; }

        [Output]
        public string OldReference { get; set; }
        [Output]
        public string NewReference { get; set; }


        public override bool Execute() {
            var assembly = AssemblyDefinition.ReadAssembly( Reference );
            AssemblyWithPublicTypesMaker.MakeTypesPublic( assembly, Log );

            var path = Path.Combine( DirectoryToSave, Path.GetFileName( Reference ) );
            OldReference = Reference;
            NewReference = path;
            Save( path, assembly, Log );
            return true;
        }


        // Helpers
        private static void Save(string path, AssemblyDefinition assembly, TaskLoggingHelper log) {
            Directory.CreateDirectory( Path.GetDirectoryName( path ) );
            assembly.Write( path );
            log.LogMessage( MessageImportance.High, "[MakeTypesPublic] Output: {0}", path );
        }


    }
}
