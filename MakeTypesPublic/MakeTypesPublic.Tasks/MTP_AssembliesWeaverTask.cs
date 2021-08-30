namespace MakeTypesPublic.Tasks {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using MakeTypesPublic.Weaver;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using Mono.Cecil;
    
    public class MTP_AssembliesWeaverTask : Task {

        [Required]
        public string[] SourceReferences { get; set; } = default!;
        [Required]
        public string[] TargetReferences { get; set; } = default!;


        public override bool Execute() {
            for (var i = 0; i < SourceReferences.Length; i++) {
                Weav( SourceReferences[ i ], TargetReferences[ i ], Log );
            }
            return true;
        }


        // Helpers
        private static void Weav(string sourcePath, string targetPath, TaskLoggingHelper log) {
            //var resolver = new AssemblyResolver( Path.GetDirectoryName( sourcePath ) );
            //var parameters = new ReaderParameters { AssemblyResolver = resolver };
            var assembly = AssemblyDefinition.ReadAssembly( sourcePath );
            AssemblyWeaver.Weav( assembly, log );
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