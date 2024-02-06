using GYM.BL.Services;
using GYM.DL.Interfaces;
using GYM.DL.Repositories;
using GYM.Models.Models;
using GYM.Models.Requests;

using Moq;

namespace Gyms.Tests
{
    public class CustomeServiceTests
    {
        public static List<Instructor> InstructorData = new List<Instructor>()
            {
                new Instructor()
                {
                    Id = 1,
                    Name = "Instructor 1",
                    BirthDay = DateTime.Now
                },
                new Instructor()
                {
                    Id = 2,
                    Name = "Instructor 2",
                    BirthDay = DateTime.Now
                },
                new Instructor()
                {
                    Id = 3,
                    Name = "Instructor 3",
                    BirthDay = DateTime.Now
                }
            };
        private IEnumerable<object> GymsData;

        public void GetAllGymssCountOK()
{
    //setup
    var input = 10;
    var instructorId = 1;
    var expectedCount = 12;

    var mockedGymsRepository =
        new Mock<GymsRepository>();
    var mockedInstructorRepository =
        new Mock<IInstructorRepository>();

    mockedGymsRepository.Setup(
        x =>
            x.GetAllGymssByInstructor(instructorId))
        .Returns(GymsData.Where(b =>
            b.InstructorID == instructorId).ToList());

    //inject
    var GymsService =
        new GymsService(mockedGymsRepository.Object);
    var InstructorService =
        new InstructorService(mockedInstructorRepository.Object);
    var CustomerService =
        new CustomerService(GymsService, InstructorService);

    //act
    var result =
        CustomerService.GetAllGymssCount(input, instructorId);

    //Assert
    Assert.Equal(expectedCount, result);
}

[Fact]
public void GetAllGymssCount_WrongIntructorId()
{
    //setup
    var input = 10;
    var instructorId = 111;
    var expectedCount = 10;

    var mockedGymsRepository =
        new Mock<GymsRepository>();
    var mockedInstructorRepository =
        new Mock<IInstructorRepository>();

    mockedGymsRepository.Setup(
            x =>
                x.GetAllGymssByInstructor(instructorId))
        .Returns(GymsData.Where(b =>
            b.InstructorID == instructorId).ToList());

    //inject
    var GymsService =
        new GymsService(mockedGymsRepository.Object);
    var InstructorService =
        new InstructorService(mockedInstructorRepository.Object);
    var CustomerService =
        new CustomerService(GymsService, InstructorService);

    //act
    var result =
        GymsService.GetAllGymssCount(input, instructorId);

    //Assert
    Assert.Equal(expectedCount, result);
}

[Fact]
public void GetAllGymssCount_NegativeInput()
{
    //setup
    var input = -10;
    var authorId = 111;
    var expectedCount = 0;

    var mockedGymsRepository =
        new Mock<GymsRepository>();
    var mockedAuthorRepository =
        new Mock<IInstructorRepository>();

    mockedGymsRepository.Setup(
            x =>
                x.GetAllGymssByInstructor(InstructorId))
        .Returns(GymsData.Where(b =>
            b.InstructorID == instructorId).ToList());

    //inject
    var GumsService =
        new GymsService(mockedGymsRepository.Object);
    var InstructorService =
        new InstructorService(mockedInstructorRepository.Object);
    var CustomerService =
        new CustomerService(GymsService, InstructorService);

    //act
    var result =
        GymsService.GetAllGymssCount(input, InstructorId);

    //Assert
    Assert.Equal(expectedCount, result);
}

[Fact]
public void GetAllGymssByInstructorAfterDate_OK()
{
    //setup
    var request = new GetAllGymssByInstructorRequest
    {
        InstructorId = 1,
        AfterDate = new DateTime(2000, 1, 1)
    };
    var expectedCount = 2;

    var mockedGymsRepository =
        new Mock<IGymsRepository>();
    var mockedInstructorRepository =
        new Mock<IInstructorRepository>();

    mockedGymsRepository.Setup(
            x =>
                x.GetAllGymssByInstructor(request.InstructorId))
        .Returns(GymsData
            .Where(b => b.InstructorID == request.instructorId)
            .ToList());

    mockedInstructorRepository.Setup(
            x =>
                x.GetById(request.InstructorId))
        .Returns(InstructorData!
            .FirstOrDefault(a =>
                a.Id == request.InstructorId)!);

    //inject
    var GymsService =
        new GymsService(mockedGymsRepository.Object);
    var InstructorService =
        new InstructorService(mockedInstructorRepository.Object);
    var service = new CustomerService(GymsService, InstructorService);

    //Act
    var result =
        service.GetAllGymssByInstructorAfterDate(request);

    //Assert
    Assert.NotNull(result);
    Assert.Equal(expectedCount, result!.Gymss.Count);
    Assert.Equal(request.InstructorId, result.Instructor.Id);
}

    }
}
