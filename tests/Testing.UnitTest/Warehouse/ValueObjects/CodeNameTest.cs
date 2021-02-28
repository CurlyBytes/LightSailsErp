using AutoFixture;
using Domain.Warehouse.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testing.UnitTest.Warehouse.ValueObjects
{
    public class CodeNameTest
    {
        public static IEnumerable<object[]> WrongData =>
        new List<object[]>
        {
                new object[] { "ss???" },
                new object[] { "C-!" },
                new object[] { "22222222C-!cccccccccc" }
        };
        public static IEnumerable<object[]> CorrectData =>
        new List<object[]>
        {
                        new object[] { "AAA-123" },
                        new object[] { "123-BBB" }
        };


        [Theory]
        [MemberData(nameof(CorrectData))]
        public void CodeName_Entries_IsValid(string codeName)
        {
            //Arrange
            CodeName methodUnderTest = new CodeName(codeName);

            //Assert
            Assert.Equal(codeName, methodUnderTest.ToString());
        }


        [Theory]
        [MemberData(nameof(WrongData))]
        public void CodeName_Is_InValid(string codeName)
        {

            // Act
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                new CodeName(codeName);
            });

            //Assert
            Assert.Contains("Input code was not in required format", exception.Message);
        }

        [Fact]
        public void CodeName_Null_Is_Invalid()
        {
            //Arrange 
            string codeName = null;

            // Act
            Exception exception = Assert.Throws<ArgumentNullException>(() =>
            {
                new CodeName(codeName);
            });

            //Assert
            Assert.Contains("Value cannot be null.", exception.Message);
        }


    }
}
