using NUnit.Framework;
using System.IO;
using System;


namespace NinjaUnitTest.UnitTest
{
    //conversion for class name: Class name I going to test plus "Test"
    
    [TestFixture]
    public class ReservationTests
    {
        [SetUp]
        public void Setup()
        {
        }
        //conversion for test method name: MethodNameToTest_Scenario_ExpectedBehavior
        [Test]
        //First Scenario to test: User is Admin
        public void CanBeCancelledBy_AdminCancellingTheReservation_ReturnTrue()
        {
            //Every test method has 3 parts.(This convention is called "triple A")

            //Arrange: Where we initialze the object we wanna test.

            var user = new User() { isAdmin = true };
            var reservation = new Reservation();

            //Act: Is where we act on this object, basically means where we gonna call the method.

            var result = reservation.CanBeCancelledBy(user);

            //Assert: Here we verify that the result is correct.
            Assert.IsTrue(result);

            //another ways to write the same assertion is:
            Assert.That(result, Is.True);
            Assert.That(result==true);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancelllingTheReservation_ReturnTrue()
        {
            //Arrange
            var user = new User();
            var reservation = new Reservation() { MadeBy = user };

            //Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.IsTrue(result);
        
        }


        [Test]
        public void CanBeCancelledBy_AnotherUserCancelllingTheReservation_ReturnFalse()
        {
            //Arrange
            var user = new User();
            var reservation = new Reservation() { MadeBy = user };

            //Act : In this test method we want to deal with two different user objects, the user that made the reservation and another user

            var result = reservation.CanBeCancelledBy( new User());

            //Assert
            Assert.IsFalse(result);    

        }
    }
}