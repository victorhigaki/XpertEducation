using Bogus;
using Moq.AutoMock;
using XpertEducation.GestaoConteudo.Application.AppServices;
using XpertEducation.GestaoConteudo.Domain;

namespace XpertEducation.GestaoConteudo.Application.Tests
{
    [CollectionDefinition(nameof(CursoCollection))]
    public class CursoCollection : ICollectionFixture<CursoTestsFixture>
    {
    }

    public class CursoTestsFixture : IDisposable
    {
        public CursoAppService CursoAppService;
        public AutoMocker Mocker;

        public IEnumerable<Curso> ObterCursosVariados()
        {
            var clientes = new List<Curso>();

            clientes.AddRange(GerarCursos(50).ToList());

            return clientes;
        }

        public IEnumerable<Curso> GerarCursos(int quantidade)
        {
            var clientes = new Faker<Curso>("pt_BR")
                .CustomInstantiator(f => new Curso(
                    f.Commerce.ProductName(),
                    new ConteudoProgramatico(
                        f.Lorem.Sentence(),
                        f.Lorem.Paragraph(),
                        f.Lorem.Paragraph(),
                        f.Lorem.Paragraph()
                    ),
                    f.Random.Decimal(1, 9999))
                );

            return clientes.Generate(quantidade);
        }

        public Curso GerarCursoValido()
        {
            return GerarCursos(1).FirstOrDefault();
        }

        public CursoAppService ObterCursoAppService()
        {
            Mocker = new AutoMocker();
            CursoAppService = Mocker.CreateInstance<CursoAppService>();
            return CursoAppService;
        }


        public void Dispose()
        {
        }
    }
}
