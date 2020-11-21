namespace MakeTypesPublic.Tasks {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using Mono.Cecil;

    public class MTP_CreateFakeAssembliesTask : Task {

        [Required]
        public string[] SourceReferences { get; set; }
        [Required]
        public string[] NewReferences { get; set; }


        public override bool Execute() {
            if (SourceReferences.Length != NewReferences.Length) {
                Log.LogError( "Sizes of 'SourceReferences' and 'NewReferences' are not equal" );
                return false;
            }
            for (var i = 0; i < SourceReferences.Length; i++) {
                CreateFakeAssembly( SourceReferences[ i ], NewReferences[ i ], Log );
            }
            return true;
        }


        // Helpers
        private static void CreateFakeAssembly(string sourcePath, string targetPath, TaskLoggingHelper log) {
            //var resolver = new AssemblyResolver( Path.GetDirectoryName( sourcePath ) );
            //var parameters = new ReaderParameters { AssemblyResolver = resolver };
            var assembly = AssemblyDefinition.ReadAssembly( sourcePath );
            AssemblyWithPublicTypesMaker.MakeTypesPublic( assembly, log );
            Save( targetPath, assembly, log );
        }
        private static void Save(string path, AssemblyDefinition assembly, TaskLoggingHelper log) {
            Directory.CreateDirectory( Path.GetDirectoryName( path ) );
            assembly.Write( path );
#if DEBUG
            log.LogMessage( MessageImportance.High, "[MakeTypesPublic] Fake assembly: {0}", path );
#endif
        }


    }
}