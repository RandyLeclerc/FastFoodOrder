using BLL.RestaurantService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.BTO;
using Shared.DataContracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Tests
{
    [TestClass]
    public class SearchUCTests
    {
        [TestMethod]
        public void FindRestaurantByCity_Should_Return_Proper_Collection()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            mock.Setup(x => x.FindByCity("Bruxelles")).Returns(new List<RestoDTO>()
            {
                new RestoDTO{ City = "Bruxelles", Id = 1, Name= "R1"},
                new RestoDTO{ City = "Bruxelles", Id = 2, Name= "R2"},

            });
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.FindRestaurantByCity("Bruxelles").ToList();

            //Assert
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[0].Name, "R1");

        }
        [TestMethod]
        public void FindRestaurantByCity_Should_Return_Empty_List_If__There_Is_No_City()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            mock.Setup(x => x.FindByCity("Bruxelles")).Returns(new List<RestoDTO>() {});
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.FindRestaurantByCity("Bruxelles").ToList();

            //Assert
            Assert.AreEqual(result.Count, 0);

        }
        [TestMethod]
        public void GetAllRestaurants_Should_Return_Proper_Collection()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            mock.Setup(x => x.GetAll()).Returns(new List<RestoDTO>()
            {
                new RestoDTO{ City = "Bruxelles", Id = 1, Name= "R1"},
                new RestoDTO{ City = "Bruxelles", Id = 2, Name= "R2"},
                new RestoDTO{ City = "Liege", Id = 3, Name= "R3"},

            });
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.GetAllRestaurants().ToList();

            //Assert
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[2].Name, "R3");

        }
        [TestMethod]
        public void GetRestaurantById_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            mock.Setup(x => x.GetById(1)).Returns(
                new RestoDTO{ City = "Bruxelles", Id = 1, Name= "R1"}
            );
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.GetRestaurantById(1);

            //Assert
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.City, "Bruxelles");
            Assert.AreEqual(result.Name, "R1");

        }
        [TestMethod]
        public void GetRestaurantById_Should_Return_Null_When_Not_Found()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            mock.Setup(x => x.GetById(25));
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.GetRestaurantById(25);

            //Assert
            Assert.AreEqual(null, result);
            Assert.IsNull(result);

        }

        [TestMethod]
        public void GetRestaurantsByRestaurantManager_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            mock.Setup(x => x.GetRestaurantsByRestaurantManager("1")).Returns(new List<RestoDTO>()
            {
                new RestoDTO { City = "Bruxelles", Id = 1, Name = "R1", UserManagerId = "1" },
                new RestoDTO { City = "Liege", Id = 2, Name = "R2", UserManagerId = "1" },
            }
            );
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.GetRestaurantsByRestaurantManager("1").ToList();

            //Assert
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[0].City, "Bruxelles");
            Assert.AreEqual(result[1].Name, "R2");
            Assert.AreEqual(result.Count, 2);
        }

        [TestMethod]
        public void GetRestaurantsByRestaurantManager_Should_Return_Empty_List_If_Param_Null()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            mock.Setup(x => x.GetRestaurantsByRestaurantManager("1")).Returns(new List<RestoDTO>()
            {
                new RestoDTO { City = "Bruxelles", Id = 1, Name = "R1", UserManagerId = "1" },
                new RestoDTO { City = "Liege", Id = 2, Name = "R2", UserManagerId = "1" },
            }
            );
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.GetRestaurantsByRestaurantManager("").ToList();

            //Assert
            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod]
        public void GetAllRestaurantsByCuisineId_Should_Return_Proper_Collection()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            mock.Setup(x => x.GetAllByCuisineId(1)).Returns(new List<RestoDTO>()
            {
                new RestoDTO{ City = "Bruxelles", Id = 1, Name= "R1"},
                new RestoDTO{ City = "Bruxelles", Id = 2, Name= "R2"},
                new RestoDTO{ City = "Liege", Id = 3, Name= "R3"},

            });
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.GetAllRestaurantsByCuisineId(1).ToList();

            //Assert
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[2].Name, "R3");

        }
        [TestMethod]
        public void GetAllRestaurantsByCuisineId_Should_Return_New_List_When_Nothing_In_Db()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            mock.Setup(x => x.GetAllByCuisineId(1));
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.GetAllRestaurantsByCuisineId(1).ToList();

            //Assert
            Assert.AreEqual(result.Count, 0);

        }
        [TestMethod]
        public void GetAllRestaurantsByCuisineId_Should_Return_New_List_When_Not_Found()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            mock.Setup(x => x.GetAllByCuisineId(1)).Returns(new List<RestoDTO>());
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.GetAllRestaurantsByCuisineId(1).ToList();

            //Assert
            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod]
        public void FindRestoMailByRestoId_Should_Return_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            mock.Setup(x => x.FindRestoMailByRestoId(1)).Returns("test@test.com");
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.FindRestoMailByRestoId(1);

            //Assert
            Assert.AreEqual("test@test.com" , result);

        }
        [TestMethod]
        public void FindRestoMailByRestoId_Should_Return_Null_When_Wrong_Id()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            mock.Setup(x => x.FindRestoMailByRestoId(1)).Returns("test@test.com");
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.FindRestoMailByRestoId(-1);

            //Assert
            Assert.IsNull(result);

        }
        [TestMethod]
        public void IsOpen_Should_Return_True_When_Valid_Data()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            var date = DateTime.Now;
            date = date.AddMonths(1);
            mock.Setup(x => x.RestaurantIsOpen(1, date)).Returns(true);
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.IsOpen(1, date);

            //Assert
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void IsOpen_Should_Return_False_When_ArrivalDate_Is_Before_Now()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            var date = DateTime.Now;
            date = date.AddMonths(-1);
            mock.Setup(x => x.RestaurantIsOpen(1, date)).Returns(true);
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.IsOpen(1, date);

            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void FindOpenRestaurantsByDate_Should_Return_Proper_Collection()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            var schedules = new List<ScheduleDTO>();
            var schedule = new ScheduleDTO
            {
                TimeOpen = DateTime.Now,
                TimeClosed = DateTime.Now.AddHours(3),
                DayOfWeek = (int)DateTime.Now.DayOfWeek
            };
            schedules.Add(schedule);
            mock.Setup(x => x.GetAll()).Returns(new List<RestoDTO>()
            {
                new RestoDTO{ City = "Bruxelles", Id = 1, Name= "R1", Schedules = schedules},
                new RestoDTO{ City = "Bruxelles", Id = 2, Name= "R2", Schedules = new List<ScheduleDTO>()},
                new RestoDTO{ City = "Liege", Id = 3, Name= "R3", Schedules = schedules},

            });
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.FindOpenRestaurantsByDate(schedule.TimeOpen).ToList();

            //Assert
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[1].Name, "R3");

        }
        [TestMethod]
        public void FindOpenRestaurantsByDate_Should_Return_New_List_When_Any_Resto_Is_Open()
        {
            //Arrange
            var mock = new Mock<IRestoRepository>();
            var schedules = new List<ScheduleDTO>();
            var schedule = new ScheduleDTO
            {
                TimeOpen = DateTime.Now,
                TimeClosed = DateTime.Now.AddHours(3),
                DayOfWeek = (int)DateTime.Now.DayOfWeek
            };
            schedules.Add(schedule);
            mock.Setup(x => x.GetAll()).Returns(new List<RestoDTO>()
            {
                new RestoDTO{ City = "Bruxelles", Id = 1, Name= "R1", Schedules = new List<ScheduleDTO>()},
                new RestoDTO{ City = "Bruxelles", Id = 2, Name= "R2", Schedules = new List<ScheduleDTO>()},
                new RestoDTO{ City = "Liege", Id = 3, Name= "R3", Schedules = new List<ScheduleDTO>()},
            });
            RestaurantUC target = new RestaurantUC(mock.Object);

            //Act
            var result = target.FindOpenRestaurantsByDate(schedule.TimeOpen).ToList();

            //Assert
            Assert.AreEqual(result.Count, 0);

        }
    }
}
