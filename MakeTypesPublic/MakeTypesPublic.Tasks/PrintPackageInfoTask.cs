namespace MakeTypesPublic.Tasks {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;

    public class PrintPackageInfoTask : Task {

        [Required]
        public string PackageDirectory { get; set; }

        private string AssemblyVersion => Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;


        public override bool Execute() {
            Log.LogMessage( MessageImportance.High, "[MakeTypesPublic] PackageDirectory: {0}", Path.GetFullPath( PackageDirectory ) );
            Log.LogMessage( MessageImportance.High, "[MakeTypesPublic] AssemblyVersion: {0}", AssemblyVersion );
            return true;
        }


    }
}
