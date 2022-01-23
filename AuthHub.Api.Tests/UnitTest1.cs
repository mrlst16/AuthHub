using AuthHub.Models.Users;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xunit;

namespace AuthHub.Api.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            TestClass test = new();
            test.MethodA();

        }

    }

    public class TestClass
    {

        public void MethodA([CallerMemberName] string caller = "")
        {
            StackTrace stackTrace = new StackTrace();
            var callingClassName = stackTrace.GetFrame(0).GetMethod().DeclaringType.Name;
            MethodB();
            MethodD();
        }

        private void MethodB()
        {
            MethodC();
        }

        private void MethodC()
        {

        }

        private void MethodD()
        {

        }
    }
}
