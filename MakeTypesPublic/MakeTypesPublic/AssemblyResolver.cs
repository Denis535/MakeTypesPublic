namespace MakeTypesPublic {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Mono.Cecil;

    public class AssemblyResolver : IAssemblyResolver {

        private readonly HashSet<string> directories;


        public AssemblyResolver(string[] directories) {
            this.directories = new HashSet<string>( directories, StringComparer.OrdinalIgnoreCase );
        }
        public void Dispose() {
        }


        public AssemblyDefinition Resolve(AssemblyNameReference name) {
            var parameters = new ReaderParameters() { AssemblyResolver = this };
            return GetFiles( directories, name ).Where( File.Exists ).Select( i => AssemblyDefinition.ReadAssembly( i, parameters ) ).FirstOrDefault() ?? throw new AssemblyResolutionException( name );
        }
        public AssemblyDefinition Resolve(AssemblyNameReference name, ReaderParameters parameters) {
            return GetFiles( directories, name ).Where( File.Exists ).Select( i => AssemblyDefinition.ReadAssembly( i, parameters ) ).FirstOrDefault() ?? throw new AssemblyResolutionException( name );
        }


        // Helpers
        private static IEnumerable<string> GetFiles(IEnumerable<string> directories, AssemblyNameReference name) {
            foreach (var item in directories) {
                if (name.IsWindowsRuntime) {
                    yield return Path.Combine( item, name.Name + ".winmd" );
                    yield return Path.Combine( item, name.Name + ".dll" );
                } else {
                    yield return Path.Combine( item, name.Name + ".exe" );
                    yield return Path.Combine( item, name.Name + ".dll" );
                }
            }
        }
        //private static AssemblyDefinition ReadAssembly(string file, ReaderParameters parameters) {
        //    try {
        //        return ModuleDefinition.ReadModule( file, parameters ).Assembly;
        //    } catch (BadImageFormatException) {
        //        return null;
        //    }
        //}


    }
}
