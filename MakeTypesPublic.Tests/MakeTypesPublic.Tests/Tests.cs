namespace MakeTypesPublic.Tests {
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using Lib;

    public class Tests {


        // PublicClass
        [Test]
        public void Test_00_PublicClass() {
            TestContext.WriteLine( typeof( PublicClass ) );
            TestContext.WriteLine( typeof( PublicClass.Static_NestedClass ) );
            TestContext.WriteLine( typeof( PublicClass.Instantiable_NestedClass ) );
        }
        [Test]
        public void Test_00_PublicClass_Static() {
            Assert.That( PublicClass.Static_Field, Is.EqualTo( "Value" ) );
            Assert.That( PublicClass.Static_Property, Is.EqualTo( "Value" ) );
            //Assert.That( PublicClass.Static_Event, Is.Null );
            Assert.That( PublicClass.Static_Method(), Is.EqualTo( "Value" ) );
        }
        [Test]
        public void Test_00_PublicClass_Instance() {
            Assert.That( new PublicClass().Instance_Field, Is.EqualTo( "Value" ) );
            Assert.That( new PublicClass().Instance_Property, Is.EqualTo( "Value" ) );
            //Assert.That( new PublicClass().Instance_Event, Is.Null );
            Assert.That( new PublicClass().Instance_Method(), Is.EqualTo( "Value" ) );
        }


        // InternalClass
        [Test]
        public void Test_01_InternalClass() {
            TestContext.WriteLine( typeof( InternalClass ) );
            TestContext.WriteLine( typeof( InternalClass.Static_NestedClass ) );
            TestContext.WriteLine( typeof( InternalClass.Instantiable_NestedClass ) );
        }
        [Test]
        public void Test_01_InternalClass_Static() {
            Assert.That( InternalClass.Static_Field, Is.EqualTo( "Value" ) );
            Assert.That( InternalClass.Static_Property, Is.EqualTo( "Value" ) );
            //Assert.That( InternalClass.Static_Event, Is.Null );
            Assert.That( InternalClass.Static_Method(), Is.EqualTo( "Value" ) );
        }
        [Test]
        public void Test_01_InternalClass_Instance() {
            Assert.That( new InternalClass().Instance_Field, Is.EqualTo( "Value" ) );
            Assert.That( new InternalClass().Instance_Property, Is.EqualTo( "Value" ) );
            //Assert.That( new InternalClass().Instance_Event, Is.Null );
            Assert.That( new InternalClass().Instance_Method(), Is.EqualTo( "Value" ) );
        }


    }
}