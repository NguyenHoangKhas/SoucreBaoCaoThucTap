using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Application.UserCases.HRM.Employee;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.DTOs.HRM;
using Moq;
using System.Linq.Expressions;
using HrmEntities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.Tests.HRM.Employee
{
    public class GetAllEmployeeTest
    {
        private readonly Mock<IEmployeeSqlRepository> mockEmployeeSqlRepository;
        private readonly GetAllEmployeeHandler handler;

        public GetAllEmployeeTest()
        {
            mockEmployeeSqlRepository = new Mock<IEmployeeSqlRepository>();
            handler = new GetAllEmployeeHandler(mockEmployeeSqlRepository.Object, new Mock<IFileService>().Object);
        }
        [Fact]
        public async Task Handle_Should_ReturnEmptyList_When_NoEmployee()
        {
            // Arrange
            var query = new GetAllEmployeeRequest();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            var data = (result.Data as IQueryable).Cast<EmployeeDetailDTOs>();
            Assert.True(result.IsSuccess);
            Assert.Empty(data);
        }

        [Fact]
        public async Task Handle_Should_ReturnAllEmployee_AsQueryable()
        {
            // Arrange
            mockEmployeeSqlRepository.Setup(repository => repository.FindAll(It.IsAny<Expression<Func<HrmEntities.Employee, bool>>>(), false)).Returns(EmployeeCatalogTestData.GetSample().AsQueryable());
            var query = new GetAllEmployeeRequest();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            var data = (result.Data as IQueryable).Cast<EmployeeDetailDTOs>();
            Assert.True(result.IsSuccess);
            Assert.Equal(2, data.Count());
        }

        [Fact]
        public async Task Handle_Should_ReturnAllEmployee_PagedList()
        {
            // Arrange
            mockEmployeeSqlRepository.Setup(repository => repository.FindAll(It.IsAny<Expression<Func<HrmEntities.Employee, bool>>>(), false)).Returns(EmployeeCatalogTestData.GetSample().AsQueryable());
            var query = new GetAllEmployeeRequest { PageNumber = 1 };

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            var data = (PagedList<EmployeeDetailDTOs>)result.Data;
            Assert.True(result.IsSuccess);
            Assert.Equal(2, data.TotalItems);
        }

    }
}
