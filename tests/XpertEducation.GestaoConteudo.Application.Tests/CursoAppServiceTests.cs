using MediatR;
using Moq;
using Moq.AutoMock;
using XpertEducation.GestaoConteudo.Application.AppServices;
using XpertEducation.GestaoConteudo.Application.Extensions;
using XpertEducation.GestaoConteudo.Application.ViewModels;
using XpertEducation.GestaoConteudo.Domain;
using XpertEducation.GestaoConteudo.Domain.Repositories;

namespace XpertEducation.GestaoConteudo.Application.Tests
{
    [Collection(nameof(CursoCollection))]
    public class CursoAppServiceTests
    {
        readonly CursoTestsFixture _cursoTestsBogus;

        public CursoAppServiceTests(CursoTestsFixture cursoTestsFixture)
        {
            _cursoTestsBogus = cursoTestsFixture;
        }

        [Fact(DisplayName = "Obter Todos Cursos")]
        [Trait("Categoria", "Gestão de Conteúdos - Curso ObterTodos")]
        public async Task CursoAppService_ObterTodos_DeveRetornarCursos()
        {
            // Arrange
            var mocker = new AutoMocker();
            var cursoAppService = mocker.CreateInstance<CursoAppService>();

            mocker.GetMock<ICursoRepository>().Setup(c => c.ObterTodos())
                .Returns(_cursoTestsBogus.ObterCursosVariados());

            // Act
            var cursos = await cursoAppService.ObterTodos();

            // Assert
            mocker.GetMock<ICursoRepository>().Verify(r => r.ObterTodos(), Times.Once);
            Assert.True(cursos.Any());
        }

        [Fact(DisplayName = "Adicionar Curso com Sucesso")]
        [Trait("Categoria", "Curso Service AutoMock Tests")]
        public async Task CursoService_Adicionar_DeveExecutarComSucesso()
        {
            // Arrange
            var curso = _cursoTestsBogus.GerarCursoValido();
            var mocker = new AutoMocker();
            var cursoAppService = mocker.CreateInstance<CursoAppService>();

            mocker.GetMock<ICursoRepository>().Setup(c => c.UnitOfWork.Commit()).Returns(Task.FromResult(true));

            // Act
            await cursoAppService.Adicionar(new CursoViewModel
            {
                Id = curso.Id,
                Nome = curso.Nome,
                ConteudoProgramatico = curso.ConteudoProgramatico.ToViewModel(),
                Valor = curso.Valor
            });

            // Assert
            mocker.GetMock<ICursoRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
            mocker.GetMock<ICursoRepository>().Verify(r => r.Adicionar(It.IsAny<Curso>()), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Aula com Sucesso")]
        [Trait("Categoria", "Curso Service AutoMock Tests")]
        public async Task CursoService_AdicionarAula_DeveExecutarComSucesso()
        {
            // Arrange
            var curso = _cursoTestsBogus.GerarCursoValido();
            var mocker = new AutoMocker();
            var cursoAppService = mocker.CreateInstance<CursoAppService>();

            mocker.GetMock<ICursoRepository>().Setup(c => c.UnitOfWork.Commit()).Returns(Task.FromResult(true));
            await cursoAppService.Adicionar(new CursoViewModel
            {
                Id = curso.Id,
                Nome = curso.Nome,
                ConteudoProgramatico = curso.ConteudoProgramatico.ToViewModel(),
                Valor = curso.Valor
            });
            var aula = new Aula(curso.Id, "titulo teste", "conteudo teste");

            // Act
            await cursoAppService.AdicionarAula(new AulaViewModel { CursoId = aula.CursoId, Titulo = aula.Titulo, ConteudoAula = aula.ConteudoAula });

            // Assert
            mocker.GetMock<ICursoRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Exactly(2));
            mocker.GetMock<ICursoRepository>().Verify(r => r.AdicionarAula(It.IsAny<Aula>()), Times.Once);
        }
    }
}
