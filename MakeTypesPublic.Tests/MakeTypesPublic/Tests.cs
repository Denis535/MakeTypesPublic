namespace MakeTypesPublic {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using Lib;

    public class Tests {


        [Test]
        public void Test_00() {
            _ = new Example();
            _ = new Example.NestedClass();

            Assert.That( Example.Field, Is.EqualTo( "Value" ) );
            Assert.That( Example.Property, Is.EqualTo( "Value" ) );
            Assert.That( Example.Method( "Value" ), Is.EqualTo( "Value" ) );

            Assert.That( Example.GetValue(), Is.EqualTo( "Value" ) );
            Assert.That( Example.GetValueAsync().Result, Is.EqualTo( "Value" ) );

            Assert.That( Example.GetValues().Single(), Is.EqualTo( "Value" ) );
            Assert.That( Example.GetValuesAsync().SingleAsync().Result, Is.EqualTo( "Value" ) );
        }


    }
}