using Microsoft.VisualStudio.TestTools.UnitTesting;
using Esport;
using Esport.dal;
using Esport.entityLayer;
using Esport.business;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arange
            string phoneNumber = "11223344";
            DatabaseHandler databaseHandler = new DatabaseHandler();

            //Act
            foreach (var item in databaseHandler.GetPlayers())
            {
                //Assert
                if (item.PhoneNumber == phoneNumber)
                {
                    throw new AssertFailedException(
                    "An exception thrown"
                    );
                }
            }
        }


        [TestMethod]
        public void TestCreatePlayer()
        {            
            //Arange
            string alreadyExistingPhoneNumber = "343434";
            Business business = new Business();
            DatabaseHandler databaseHandler = new DatabaseHandler();

            //Act
            if (databaseHandler.DoesPlayerExists(alreadyExistingPhoneNumber) != true)
            {
                //Assert
                business.CreatePlayer("test", "user", 1, alreadyExistingPhoneNumber, 0);
                throw new AssertFailedException(
                    "A duplicate phonenumber got inserted into the database."
                    );
            }
            else
            {
                //pass
            }
            

        }

        [TestMethod]
        public void TestCreateStaff()
        {
            //Arange
            string alreadyExistingPhoneNumber = "232323";
            Business business = new Business();
            DatabaseHandler databaseHandler = new DatabaseHandler();

            //Act
            if (databaseHandler.DoesStaffExists(alreadyExistingPhoneNumber) != true)
            {
                //Assert
                business.CreateStaff(3, "user", Convert.ToInt32(alreadyExistingPhoneNumber), 0, "Judge");
                throw new AssertFailedException(
                    "A duplicate phonenumber got inserted into the database."
                    );
            }
            else
            {
                //pass
            }
        }

        [TestMethod]
        public void TestCreateSponser()
        {
            //Arange
            string alreadyExistingPhoneNumber = "343434";
            Business business = new Business();
            DatabaseHandler databaseHandler = new DatabaseHandler();

            //Act
            if (databaseHandler.DoesSponserExists(alreadyExistingPhoneNumber) != true)
            {
                //Assert
                business.CreateSponser("Jens INC", "jens", 400);
                throw new AssertFailedException(
                    "A duplicate phonenumber got inserted into the database."
                    );
            }
            else
            {
                //pass
            }


        }

    }
}
