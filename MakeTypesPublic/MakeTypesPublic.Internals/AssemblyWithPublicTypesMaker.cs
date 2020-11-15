namespace MakeTypesPublic {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Build.Utilities;
    using Mono.Cecil;
    using Mono.Cecil.Rocks;

    internal static class AssemblyWithPublicTypesMaker {


        public static void MakeTypesPublic(AssemblyDefinition assembly, TaskLoggingHelper log) {
            //log.LogMessage( MessageImportance.High, "[MakeTypesPublic] Assembly: {0}", assembly.FullName );

            foreach (var module in assembly.Modules) {
                foreach (var type in module.GetAllTypes()) {
                    //log.LogMessage( MessageImportance.High, "[MakeTypesPublic] Type: {0}", type.FullName );

                    if (!type.IsNested) {
                        type.IsPublic = true;
                    } else {
                        type.IsNestedPublic = true;
                    }

                    foreach (var item in type.Fields) {
                        item.IsPublic = true;
                    }
                    foreach (var item in type.Properties) {
                        if (item.GetMethod != null) item.GetMethod.IsPublic = true;
                        if (item.SetMethod != null) item.SetMethod.IsPublic = true;
                    }
                    foreach (var item in type.Events) {
                        if (item.AddMethod != null) item.AddMethod.IsPublic = true;
                        if (item.RemoveMethod != null) item.RemoveMethod.IsPublic = true;
                    }
                    foreach (var item in type.Methods) {
                        item.IsPublic = true;
                    }

                }
            }
        }


    }
}
