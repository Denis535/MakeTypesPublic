namespace MakeTypesPublic.Tests {
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using Lib;

    public class Tests {


        [Test]
        public void Test_00_PublicClass() {
            TestContext.WriteLine( typeof( PublicClass ) );
            TestContext.WriteLine( typeof( PublicClass.Static_NestedClass ) );
            TestContext.WriteLine( typeof( PublicClass.Instantiable_NestedClass ) );

            TestContext.WriteLine( nameof( PublicClass.Static_Field ) );
            TestContext.WriteLine( nameof( PublicClass.Static_Property ) );
            //TestContext.WriteLine( nameof( PublicClass.Static_Event ) );
            TestContext.WriteLine( nameof( PublicClass.Static_Method ) );
        }
        [Test]
        public void Test_00_PublicClass_Instance() {
            TestContext.WriteLine( new PublicClass() );
            TestContext.WriteLine( new PublicClass().Instance_Field );
            TestContext.WriteLine( new PublicClass().Instance_Property );
            //TestContext.WriteLine( new PublicClass().Instance_Event );
            TestContext.WriteLine( new PublicClass().Instance_Method() );
        }

        [Test]
        public void Test_01_InternalClass() {
            TestContext.WriteLine( typeof( InternalClass ) );
            TestContext.WriteLine( typeof( InternalClass.Static_NestedClass ) );
            TestContext.WriteLine( typeof( InternalClass.Instantiable_NestedClass ) );

            TestContext.WriteLine( nameof( InternalClass.Static_Field ) );
            TestContext.WriteLine( nameof( InternalClass.Static_Property ) );
            //TestContext.WriteLine( nameof( InternalClass.Static_Event ) );
            TestContext.WriteLine( nameof( InternalClass.Static_Method ) );
        }
        [Test]
        public void Test_01_InternalClass_Instance() {
            TestContext.WriteLine( new InternalClass() );
            TestContext.WriteLine( new InternalClass().Instance_Field );
            TestContext.WriteLine( new InternalClass().Instance_Property );
            //TestContext.WriteLine( new InternalClass().Instance_Event );
            TestContext.WriteLine( new InternalClass().Instance_Method() );
        }


    }
}