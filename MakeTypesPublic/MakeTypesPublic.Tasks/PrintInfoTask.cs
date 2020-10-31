namespace MakeTypesPublic.Tasks {
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;

    public class PrintInfoTask : Task {

        [Required]
        public string Directory { get; set; }

        private string Version => Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;


        public override bool Execute() {
            Log.LogMessage( MessageImportance.High, "[MakeTypesPublic] Directory: {0}", Directory );
            Log.LogMessage( MessageImportance.High, "[MakeTypesPublic] Version: {0}", Version );
            return true;
        }


    }
}
