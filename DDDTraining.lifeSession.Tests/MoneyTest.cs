using DDDTraining.lifeSession.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DDDTraining.lifeSession.Tests
{
   public class MoneyTest
    {
        [Fact]
        //Object_useCase_expectedResult 

        // initial 
        //method
        //assertion 
        public void Money_objects_with_the_same_amount_should_be_equal()
        {
            var firstAmount = new RecordMoney { Amount= 5 };
            var secondAmount = new RecordMoney { Amount = 5 };
            //secondAmount.Equals
            Assert.Equal(firstAmount, secondAmount);
        }
    }
}
