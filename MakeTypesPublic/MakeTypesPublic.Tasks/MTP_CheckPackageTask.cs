namespace MakeTypesPublic.Tasks {
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;

    public class MTP_CheckPackageTask : Task {

        [Required]
        public string MSBuildThisFileFullPath { get; set; } = default!;


        public override bool Execute() {
            // Note: Very often Visual Studio loads the assembly from old package. You should reload Visual Studio in this case.
            if (!MSBuildThisFileFullPath.Contains( "\\" + GetAssemblyVersion() + "\\" )) {
                Log.LogError( "Package 'MakeTypesPublic' is loaded incorrectly" );
                Log.LogMessage( MessageImportance.High, "[MakeTypesPublic] Error: Package 'MakeTypesPublic' is loaded incorrectly" );
                Log.LogMessage( MessageImportance.High, "[MakeTypesPublic] MSBuildThisFileFullPath: {0}", MSBuildThisFileFullPath );
                Log.LogMessage( MessageImportance.High, "[MakeTypesPublic] AssemblyVersion: {0}", GetAssemblyVersion() );
            }
            return true;
        }


        // Helpers
        private string GetAssemblyVersion() {
            return Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion!;
        }


    }
}