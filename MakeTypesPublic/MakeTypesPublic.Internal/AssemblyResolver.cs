//namespace MakeTypesPublic {
//    using System;
//    using System.Collections.Generic;
//    using System.Diagnostics;
//    using System.IO;
//    using System.Linq;
//    using System.Text;
//    using Mono.Cecil;

//    internal class AssemblyResolver : IAssemblyResolver {

//        private string[] Directories { get; }


//        public AssemblyResolver(params string[] directories) {
//            Trace.WriteLine( "AssemblyResolver: " + string.Join( ", ", directories ) );
//            this.Directories = directories;
//        }
//        public void Dispose() {
//        }


//        public AssemblyDefinition Resolve(AssemblyNameReference name) {
//            Trace.WriteLine( "AssemblyResolver: " + name );
//            var parameters = new ReaderParameters() { AssemblyResolver = this };
//            return GetFiles( Directories, name ).Where( File.Exists ).Select( i => AssemblyDefinition.ReadAssembly( i, parameters ) ).FirstOrDefault() ?? throw new AssemblyResolutionException( name );
//        }
//        public AssemblyDefinition Resolve(AssemblyNameReference name, ReaderParameters parameters) {
//            Trace.WriteLine( "AssemblyResolver: " + name );
//            parameters.AssemblyResolver = parameters.AssemblyResolver ?? this;
//            return GetFiles( Directories, name ).Where( File.Exists ).Select( i => AssemblyDefinition.ReadAssembly( i, parameters ) ).FirstOrDefault() ?? throw new AssemblyResolutionException( name );
//        }


//        // Helpers
//        private static IEnumerable<string> GetFiles(IEnumerable<string> directories, AssemblyNameReference name) {
//            foreach (var item in directories) {
//                if (name.IsWindowsRuntime) {
//                    yield return Path.Combine( item, name.Name + ".winmd" );
//                    yield return Path.Combine( item, name.Name + ".dll" );
//                } else {
//                    yield return Path.Combine( item, name.Name + ".exe" );
//                    yield return Path.Combine( item, name.Name + ".dll" );
//                }
//            }
//        }


//    }
//}
