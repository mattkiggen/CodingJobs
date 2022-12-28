using AutoMapper;
using CodingJobs.Application.Commands.Company;
using CodingJobs.Application.Handlers.Company;
using CodingJobs.Application.Validators;
using CodingJobs.Contracts.Requests.Company;
using CodingJobs.Contracts.Responses.Company;
using CodingJobs.Domain.Models;
using CodingJobs.Infrastructure.Database;
using FluentAssertions;
using FluentValidation;
using NSubstitute;

namespace CodingJobs.Application.Tests.Unit.Handlers;

public class AddCompanyHandlerTests
{
    private readonly AddCompanyHandler _sut;
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
    
    public AddCompanyHandlerTests()
    {
        var validator = new AddCompanyRequestValidator();
        var configuration = new MapperConfiguration(
            cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies())
        );
        var mapper = new Mapper(configuration);
        
        _sut = new AddCompanyHandler(validator, mapper, _unitOfWork);
    }
    
    [Fact]
    public async Task Handler_ShouldThrowValidationException_WhenABadRequestIsGiven()
    {
        // Arrange
        var request = new AddCompanyRequest();
        var command = new AddCompanyCommand(request);
        
        // Act
        var action = async () => await _sut.Handle(command, CancellationToken.None);
        
        // Assert
        await action.Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task Handler_ShouldReturnCompanyResponse_WhenValidRequestIsGiven()
    {
        // Arrange
        var request = new AddCompanyRequest
        {
            Name = "Company",
            About = "About",
            Slug = "company",
            Location = "Location"
        };
        
        var command = new AddCompanyCommand(request);

        _unitOfWork.CompanyRepository.AddAsync(Arg.Any<Company>()).Returns(new Company
        {
            Name = "Company",
            About = "About",
            Slug = "company",
            Location = "Location"
        });

        // Act
        var response = await _sut.Handle(command, CancellationToken.None);
        
        //Assert
        response.Should().BeOfType<CompanyResponse>();
        response.Should().Match<CompanyResponse>(x => x.Name == "Company");
    }
}