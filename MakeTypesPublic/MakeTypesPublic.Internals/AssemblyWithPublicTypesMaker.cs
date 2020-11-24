﻿namespace MakeTypesPublic {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Build.Utilities;
    using Mono.Cecil;
    using Mono.Cecil.Rocks;

    internal static class AssemblyWithPublicTypesMaker {


        public static void MakeTypesPublic(AssemblyDefinition assembly, TaskLoggingHelper log) {
            //log.LogMessage( MessageImportance.High, "[MakeTypesPublic] Assembly: {0}", assembly.FullName );
            foreach (var module in assembly.Modules) {
                foreach (var type in module.GetAllTypes().Where( CanBePublic )) {
                    //log.LogMessage( MessageImportance.High, "[MakeTypesPublic] Type: {0}", type.FullName );
                    MakePublic( type );

                    foreach (var item in type.Fields.Where( CanBePublic )) {
                        //log.LogMessage( MessageImportance.High, "[MakeTypesPublic]  Field: {0}", item.Name );
                        MakePublic( item );
                    }
                    foreach (var item in type.Properties.Where( CanBePublic )) {
                        //log.LogMessage( MessageImportance.High, "[MakeTypesPublic]  Property: {0}", item.Name );
                        MakePublic( item );
                    }
                    foreach (var item in type.Events.Where( CanBePublic )) {
                        //log.LogMessage( MessageImportance.High, "[MakeTypesPublic]  Event: {0}", item.Name );
                        MakePublic( item );
                    }
                    foreach (var item in type.Methods.Where( CanBePublic )) {
                        //log.LogMessage( MessageImportance.High, "[MakeTypesPublic]  Method: {0}", item.Name );
                        MakePublic( item );
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
