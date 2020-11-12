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
            TestContext.WriteLine( typeof( PublicClass.NestedClass_Static ) );
            TestContext.WriteLine( typeof( PublicClass.NestedClass_Instantiable ) );
        }
        [Test]
        public void Test_00_PublicClass_Static() {
            Assert.That( PublicClass.Field_Static, Is.EqualTo( "Value" ) );
            Assert.That( PublicClass.Property_Static, Is.EqualTo( "Value" ) );
            //Assert.That( PublicClass.Event_Static, Is.Null );
            Assert.That( PublicClass.Method_Static(), Is.EqualTo( "Value" ) );
        }
        [Test]
        public void Test_00_PublicClass_Instance() {
            Assert.That( new PublicClass().Field_Instance, Is.EqualTo( "Value" ) );
            Assert.That( new PublicClass().Property_Instance, Is.EqualTo( "Value" ) );
            //Assert.That( new PublicClass().Event_Instance, Is.Null );
            Assert.That( new PublicClass().Method_Instance(), Is.EqualTo( "Value" ) );
        }


        // InternalClass
        [Test]
        public void Test_01_InternalClass() {
            TestContext.WriteLine( typeof( InternalClass ) );
            TestContext.WriteLine( typeof( InternalClass.NestedClass_Static ) );
            TestContext.WriteLine( typeof( InternalClass.NestedClass_Instantiable ) );
        }
        [Test]
        public void Test_01_InternalClass_Static() {
            Assert.That( InternalClass.Field_Static, Is.EqualTo( "Value" ) );
            Assert.That( InternalClass.Property_Static, Is.EqualTo( "Value" ) );
            //Assert.That( InternalClass.Event_Static, Is.Null );
            Assert.That( InternalClass.Method_Static(), Is.EqualTo( "Value" ) );
        }
        [Test]
        public void Test_01_InternalClass_Instance() {
            Assert.That( new InternalClass().Field_Instance, Is.EqualTo( "Value" ) );
            Assert.That( new InternalClass().Property_Instance, Is.EqualTo( "Value" ) );
            //Assert.That( new InternalClass().Event_Instance, Is.Null );
            Assert.That( new InternalClass().Method_Instance(), Is.EqualTo( "Value" ) );
        }


    }
}