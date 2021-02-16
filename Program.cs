using System;
using System.Linq;
namespace DIO_Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListaSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornoPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(indiceSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int item in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{item}.{Enum.GetName(typeof(Genero),item)}");
            }
            Console.Write("Digite o gênero entre as opcões acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo:entradaTitulo,
                                        ano:entradaAno,
                                        descricao:entradaDescricao
                                        );

            repositorio.Atualiza(indiceSerie,atualizaSerie);
        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir nova série");

            foreach (int item in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine($"{item}.{Enum.GetName(typeof(Genero),item)}");
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo:entradaTitulo,
                                        ano:entradaAno,
                                        descricao:entradaDescricao
                                        );

            repositorio.Insere(novaSerie);
        }

        private static void ListaSeries()
        {
            Console.WriteLine("Listar séries");
            Console.WriteLine();
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            Console.WriteLine("Series Disponiveis:");
            Console.WriteLine();
            foreach (var serie in lista.FindAll(serie => serie.retornaExcluido() == false))
            {
                System.Console.WriteLine($"ID {serie.retornaId()}: - {serie.retornaTitulo()}");
            }
            Console.WriteLine();
            Console.WriteLine("Series Indisponiveis");
            Console.WriteLine();
            foreach (var serie in lista.FindAll(serie => serie.retornaExcluido() == true))
            {
                System.Console.WriteLine($"ID {serie.retornaId()}: - {serie.retornaTitulo()}");
            }

            // foreach (var serie in lista)
            // {
            //     System.Console.WriteLine($"ID {serie.retornaId()}: - {serie.retornaTitulo()}");
            // }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu dispor!");
            System.Console.WriteLine("Informe a opção desejada: ");
            System.Console.WriteLine("1 - Listar séries");
            System.Console.WriteLine("2 - Inserir nova série");
            System.Console.WriteLine("3 - Atualizar série");
            System.Console.WriteLine("4 - Excluir série");
            System.Console.WriteLine("5 - Visualizar série");
            System.Console.WriteLine("C - Limpar Tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }

    }
}
