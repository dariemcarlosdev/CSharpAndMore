using DatingApp.API.Controllers;
using DatingApp.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DatingApp.API.UnitTests
{
    public class ValueControllerUnitTest
    {
        private readonly ITestOutputHelper output;

        public ValueControllerUnitTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        //xUnitTest get all Values
        [Fact]
        public async Task TestGetValuesAsync()
        {
            /*
             The AAA (Arrange, Act, Assert) pattern is a common way of writing unit tests for a method under test.

             The Arrange section of a unit test method initializes objects and sets the value of the data that is passed to the method under test.

             The Act section invokes the method under test with the arranged parameters.

             The Assert section verifies that the action of the method under test behaves as expected.
             */


            //Arange
            var dbContext = ContextMocker.GetContext();
            var controller = new ValuesController(dbContext);

            //Act
            var response = await controller.GetValuesAsync();
            var value = response.Value;

            
            //Assert

            foreach (var item in value)
            {
                output.WriteLine($"{item.Id} {item.Name}");
            }

        }

        //xUnitTest get all Values by given id
        [Fact]
        public async Task TestGetValueAsync()
        {
          
            //Arange
            var dbContext = ContextMocker.GetContext();
            var controller = new ValuesController(dbContext);
            int id = 3;

            //Act
            var response = await controller.GetValueAsync(id);
            var value = response.Value;
            dbContext.Dispose();
            //Assert

            Assert.True(value!=null);

        }

        //xUnitTest put value
        [Fact]
        public async Task TestPutValueAsync()
        {
            //Arrange
            var dbContext = ContextMocker.GetContext();
            var controller = new ValuesController(dbContext);
            int id = 4;
            var request =  new Value { Id = 4, Name = "New Item" };

            //Act
            var response =  await controller.PutValueAsync(id, request);

            //var typeExpected = new NoContentResult();
            var v = (NoContentResult)response;
           
                       
            //Assert
            //return status code 402. Respond from server was successfull and no action as result.
           Assert.Equal(StatusCodes.Status204NoContent, v.StatusCode);
             
        }
    }
}
