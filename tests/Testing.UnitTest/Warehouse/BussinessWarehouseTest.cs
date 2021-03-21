
using Domain.WarehouseContext;
using Domain.WarehouseContext.Rules;
using Domain.WarehouseContext.ValueObjects;
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
        private CodeName CodeName;
        public BussinessWarehouseTest()
        {
            CodeName = new CodeName("aaa-111");
            _iCodeNameCheckerUniqueness = new Mock<ICodeNameCheckerUniqueness>();
        }

        [Fact]
        public void CodeName_Is_Duplicate()
        {
            //Arrange
        
         
            _iCodeNameCheckerUniqueness.Setup(icCodeNameCheckerUniqueness => icCodeNameCheckerUniqueness.IsUnique(CodeName)).Returns(false);

            //Act
            var codeNameMustBeUnique = new CodeNameMustBeUnique(_iCodeNameCheckerUniqueness.Object, CodeName);

            //Assert
            Assert.True(codeNameMustBeUnique.IsBroken());
        }

        [Fact]
        public void CodeName_Is_Unique()
        {
            //Arrange
          
     
            _iCodeNameCheckerUniqueness.Setup(icCodeNameCheckerUniqueness => icCodeNameCheckerUniqueness.IsUnique(CodeName)).Returns(true);


            //Act
            var codeNameMustBeUnique = new CodeNameMustBeUnique(_iCodeNameCheckerUniqueness.Object , CodeName);
      
            //Assert
            Assert.False( codeNameMustBeUnique.IsBroken());
        }





        [Fact]
        public void Create_NewWarehouse_Successfully()
        {
            //Arrange

          
            _iCodeNameCheckerUniqueness.Setup(icCodeNameCheckerUniqueness => icCodeNameCheckerUniqueness.IsUnique(CodeName)).Returns(true);
            string warehouseName = "Dummy Warehouse Name";

            //Act
            BussinessWarehouse bussinessWarehouse =  BussinessWarehouse.Create(warehouseName, CodeName, _iCodeNameCheckerUniqueness.Object);


            //Assert
            //var orderPlaced = AssertPublishedDomainEvent<OrderPlacedEvent>(customer);
            Assert.Equal(bussinessWarehouse.CodeName, CodeName);
            Assert.Equal(bussinessWarehouse.WarehouseName, warehouseName);
        }

        [Fact]
        public void Warehouse_Name_Is_Invalid()
        {
            //Arrange

     
            _iCodeNameCheckerUniqueness.Setup(icCodeNameCheckerUniqueness => icCodeNameCheckerUniqueness.IsUnique(CodeName)).Returns(true);
            string warehouseName = "!!444";

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                BussinessWarehouse.Create(warehouseName, CodeName, _iCodeNameCheckerUniqueness.Object); ;
            });

            //Assert
            Assert.Contains("Input warehouseName was not in required format", exception.Message);
        }
    }
}
