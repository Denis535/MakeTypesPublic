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
        public ITaskItem Reference { get; set; }
        [Required]
        public string DirectoryToSave { get; set; }

        [Output]
        public ITaskItem Output { get; set; }


        public override bool Execute() {
            //var resolver = new AssemblyResolver( Path.GetDirectoryName( Reference ) );
            //var parameters = new ReaderParameters { AssemblyResolver = resolver };
            var assembly = AssemblyDefinition.ReadAssembly( Reference.ItemSpec );

            AssemblyWithPublicTypesMaker.MakeTypesPublic( assembly, Log );

            Output = new TaskItem( Path.Combine( DirectoryToSave, Path.GetFileName( Reference.ItemSpec ) ), Reference.CloneCustomMetadata() );
            Save( Output.ItemSpec, assembly, Log );
            return true;
        }


        // Helpers
        private static void Save(string path, AssemblyDefinition assembly, TaskLoggingHelper log) {
            Directory.CreateDirectory( Path.GetDirectoryName( path ) );
            assembly.Write( path );
            log.LogMessage( MessageImportance.High, "[MakeTypesPublic] New assembly: {0}", path );
        }


    }
}