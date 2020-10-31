namespace MakeTypesPublic.Tasks {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using Mono.Cecil;

    public class MakeTypesPublicTask : Task {

        [Required]
        public ITaskItem SourceReference { get; set; }

        [Required]
        public ITaskItem TargetReference { get; set; }


        public override bool Execute() {
            var assembly = AssemblyDefinition.ReadAssembly( SourceReference.ItemSpec );
            AssemblyWithPublicTypesMaker.MakeTypesPublic( assembly, Log );
            Directory.CreateDirectory( Path.GetDirectoryName( TargetReference.ItemSpec ) );
            assembly.Write( TargetReference.ItemSpec );
            return true;
        }


    }
}
