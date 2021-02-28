using Domain.Warehouse;
using Domain.Warehouse.Rules;
using Domain.Warehouse.ValueObjects;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testing.UnitTest.Warehouse
{
    public class BussinessWarehouseTest
    {

        private Mock<ICodeNameCheckerUniqueness> _iCodeNameCheckerUniqueness;

        public BussinessWarehouseTest()
        {
            _iCodeNameCheckerUniqueness = new Mock<ICodeNameCheckerUniqueness>();
        }
        [Fact]
        public void Cannot_Create_Warehouse_When_CodeName_Exist()
        {
            //Arrange
            var customerUniquenessChecker = new Mock<ICodeNameCheckerUniqueness>();
            CodeName codeName = new CodeName("aaa-111");
            customerUniquenessChecker.Setup(icCodeNameCheckerUniqueness => icCodeNameCheckerUniqueness.IsUnique(codeName)).Returns(false);

            //Act
            var codeNameMustBeUnique = new CodeNameMustBeUnique(customerUniquenessChecker.Object, codeName);

            //Assert
            Assert.True(codeNameMustBeUnique.IsBroken());
        }

        [Fact]
        public void Can_Create_Warehouse_When_Not_Exist()
        {
            //Arrange
            var customerUniquenessChecker = new Mock<ICodeNameCheckerUniqueness>();
            CodeName codeName = new CodeName("aaa-111");
            customerUniquenessChecker.Setup(icCodeNameCheckerUniqueness => icCodeNameCheckerUniqueness.IsUnique(codeName)).Returns(true);


            //Act
            var codeNameMustBeUnique = new CodeNameMustBeUnique(customerUniquenessChecker.Object , codeName);
      
            //Assert
            Assert.False( codeNameMustBeUnique.IsBroken());
        }
    }
}
