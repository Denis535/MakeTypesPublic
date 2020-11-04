namespace MakeTypesPublic.Tasks {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using Mono.Cecil;

    public class MakeAssemblyWithPublicTypesTask : Task {

        [Required]
        public string Reference { get; set; }
        [Required]
        public string DirectoryToSave { get; set; }

        [Output]
        public string Output { get; set; }


        public override bool Execute() {
            //var resolver = new AssemblyResolver( Path.GetDirectoryName( Reference ) );
            //var parameters = new ReaderParameters { AssemblyResolver = resolver };
            var assembly = AssemblyDefinition.ReadAssembly( Reference );

            AssemblyWithPublicTypesMaker.MakeTypesPublic( assembly, Log );

            Output = Path.Combine( DirectoryToSave, Path.GetFileName( Reference ) );
            Save( Output, assembly, Log );
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
