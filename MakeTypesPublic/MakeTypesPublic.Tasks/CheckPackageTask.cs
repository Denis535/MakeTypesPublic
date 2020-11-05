namespace MakeTypesPublic.Tasks {
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;

    public class CheckPackageTask : Task {

        [Required]
        public string MSBuildThisFileFullPath { get; set; }

        private string AssemblyVersion => Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;


        public override bool Execute() {
            if (!MSBuildThisFileFullPath.Contains( "\\" + AssemblyVersion + "\\" )) {
                Log.LogError( "Package 'MakeTypesPublic' is loaded incorrectly" );
                Log.LogMessage( MessageImportance.High, "[MakeTypesPublic] Error: Package is loaded incorrectly" );
                Log.LogMessage( MessageImportance.High, "[MakeTypesPublic] MSBuildThisFileFullPath: {0}", MSBuildThisFileFullPath );
                Log.LogMessage( MessageImportance.High, "[MakeTypesPublic] AssemblyVersion: {0}", AssemblyVersion );
            }
            return true;
        }


    }
}