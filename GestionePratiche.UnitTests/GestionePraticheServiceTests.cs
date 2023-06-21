using AutoMapper;
using FluentAssertions;
using GestionePratiche.Dto.Pratiche;
using GestionePratiche.Persistence.Model;
using GestionePratiche.Persistence.Repositories;
using GestionePratiche.Services.Mapping;
using GestionePratiche.Services.Services;
using GestionePratiche.Services.Validations;
using Moq;

namespace GestionePratiche.UnitTests;

public class GestionePraticheServiceTests
{
    private readonly IPraticaService _sut;
    private readonly IMapper _mapper;
    private readonly Mock<IRepository<Pratica>> _praticaRepositoryMock;

    public GestionePraticheServiceTests()
    {
        _praticaRepositoryMock = new(MockBehavior.Strict);
        MapperConfiguration config = new(x => x.AddProfile(new Profiles()));
        _mapper = config.CreateMapper();
        var praticaValidator = new CreaPraticaRequestValidator();
        _sut = new PraticaService(_mapper, praticaValidator, _praticaRepositoryMock.Object);
    }

    [Fact]
    public async Task CreatePratica__ShouldReturnGuid_WhenRequestIsCorrect()
    {
        //Arrange
        CreaPraticaResponse expectedResult = new()
        {
            IdPratica = Guid.NewGuid()
        };

        _praticaRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Pratica>(), CancellationToken.None)).ReturnsAsync(expectedResult.IdPratica);
        CreaPraticaRequest request = new()
        {
            Nome = "00",
            Cognome = "00",
            CodiceFiscale = "TRSSVT99A29D643R",
            DataDiNascita = new DateTime(2000, 1, 1),
        };
        //Act

        CreaPraticaResponse result = await _sut.CreatePraticaAsync(request, CancellationToken.None);

        //Assert
        result.Should().BeEquivalentTo(expectedResult);
        _praticaRepositoryMock.Verify(x => x.CreateAsync(It.IsAny<Pratica>(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task CreatePratica__ShouldThrowValidationException_WhenFiscalCodeIsWrong()
    {
        //Arrange
        CreaPraticaResponse expectedResult = new()
        {
            IdPratica = Guid.NewGuid()
        };

        _praticaRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Pratica>(), CancellationToken.None)).ReturnsAsync(expectedResult.IdPratica);
        CreaPraticaRequest request = new()
        {
            Nome = "00",
            Cognome = "00",
            CodiceFiscale = "AAAAAAAAAAAAA",
            DataDiNascita = new DateTime(2000, 1, 1),
        };
        //Act
        Func<Task> func = async () =>
        {
            await _sut.CreatePraticaAsync(request, CancellationToken.None);
        };

        //Assert
        var exc = await func.Should().ThrowAsync<FluentValidation.ValidationException>();
        var errors = exc.Which.Errors;
        errors.Count().Should().Be(1);
        errors.Count(x => x.ErrorMessage == ValidationMessages.FiscalCodeNotValid).Should().Be(1);
    }
}