namespace MakeTypesPublic.Weaver {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Build.Utilities;
    using Mono.Cecil;
    using Mono.Cecil.Rocks;

    internal static class AssemblyWeaver {


        public static void Weav(AssemblyDefinition assembly, TaskLoggingHelper log) {
            //log.LogMessage( MessageImportance.High, "[MakeTypesPublic] Assembly: {0}", assembly.FullName );
            foreach (var module in assembly.Modules) {
                foreach (var type in module.GetAllTypes().Where( CanBePublic )) {
                    MakePublic( type );

                    foreach (var field in type.Fields.Where( CanBePublic )) {
                        MakePublic( field );
                    }
                    foreach (var property in type.Properties.Where( CanBePublic )) {
                        MakePublic( property );
                    }
                    foreach (var @event in type.Events.Where( CanBePublic )) {
                        MakePublic( @event );
                    }
                    foreach (var method in type.Methods.Where( CanBePublic )) {
                        MakePublic( method );
                    }
                }
            }
        }


        // Helpers/CanBePublic
        private static bool CanBePublic(TypeDefinition type) {
            return !type.CustomAttributes.Any( i => i.AttributeType.FullName == "System.Runtime.CompilerServices.CompilerGeneratedAttribute" );
        }
        private static bool CanBePublic(FieldDefinition field) {
            return !field.CustomAttributes.Any( i => i.AttributeType.FullName == "System.Runtime.CompilerServices.CompilerGeneratedAttribute" );
        }
        private static bool CanBePublic(PropertyDefinition property) {
            return !property.CustomAttributes.Any( i => i.AttributeType.FullName == "System.Runtime.CompilerServices.CompilerGeneratedAttribute" );
        }
        private static bool CanBePublic(EventDefinition @event) {
            return !@event.CustomAttributes.Any( i => i.AttributeType.FullName == "System.Runtime.CompilerServices.CompilerGeneratedAttribute" );
        }
        private static bool CanBePublic(MethodDefinition method) {
            return !method.CustomAttributes.Any( i => i.AttributeType.FullName == "System.Runtime.CompilerServices.CompilerGeneratedAttribute" );
        }
        // Helpers/MakePublic
        private static void MakePublic(TypeDefinition type) {
            if (!type.IsNested) {
                type.IsPublic = true;
            } else {
                type.IsNestedPublic = true;
            }
        }
        private static void MakePublic(FieldDefinition field) {
            field.IsPublic = true;
        }
        private static void MakePublic(PropertyDefinition property) {
            if (property.GetMethod != null) property.GetMethod.IsPublic = true;
            if (property.SetMethod != null) property.SetMethod.IsPublic = true;
        }
        private static void MakePublic(EventDefinition @event) {
            if (@event.AddMethod != null) @event.AddMethod.IsPublic = true;
            if (@event.RemoveMethod != null) @event.RemoveMethod.IsPublic = true;
        }
        private static void MakePublic(MethodDefinition method) {
            method.IsPublic = true;
        }


    }
}
