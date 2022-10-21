using Desafio1;

string path = @"resultado.txt";
List<Pessoa> listaPessoas = new List<Pessoa>();
List<Aluno> listaAlunos = new List<Aluno>();

void cadastrarPessoa()
{
    Console.WriteLine("Informe o nome da pessoa: "); 
    string nome = Console.ReadLine();
    Console.WriteLine("Informe o telefone da pessoa: ");
    string telefone = Console.ReadLine();
    Console.WriteLine("Informe a cidade da pessoa: ");
    string cidade = Console.ReadLine();
    Console.WriteLine("Informe o RG da pessoa: ");
    string rg = Console.ReadLine();
    Console.WriteLine("Informe o CPF da pessoa: ");
    string cpf = Console.ReadLine();
    Pessoa pessoa = new Pessoa(nome, telefone, cidade, rg, cpf);
    Utils.gravarPessoaArquivo(pessoa, path);
    listaPessoas.Add(pessoa);
    Console.WriteLine(nome+" cadastrado(a) com sucesso!");
}

void cadastrarAluno()
{
    Console.WriteLine("Informe o nome do aluno: "); 
    string nome = Console.ReadLine();
    Console.WriteLine("Informe o telefone do aluno: ");
    string telefone = Console.ReadLine();
    Console.WriteLine("Informe a cidade do aluno: ");
    string cidade = Console.ReadLine();
    Console.WriteLine("Informe o RG do aluno: ");
    string rg = Console.ReadLine();
    Console.WriteLine("Informe o CPF do aluno: ");
    string cpf = Console.ReadLine();
    Console.WriteLine("Informe a matrícula do aluno: ");
    string matricula = Console.ReadLine();
    Console.WriteLine("Informe o código curso do aluno: ");
    string codigoCurso = Console.ReadLine();
    Console.WriteLine("Informe o nome do curso do aluno: ");
    string nomeCurso = Console.ReadLine();
    Aluno aluno = new Aluno(nome, telefone, cidade, rg, cpf, matricula, codigoCurso, nomeCurso);
    Utils.gravarAlunoArquivo(aluno, path);
    listaAlunos.Add(aluno);
    Console.WriteLine(nome+" cadastrado(a) com sucesso!");
}


Utils.cabecalho(path, "Desafio 1");
Utils.popularArquivoNaListaPessoa(listaPessoas, path);
Utils.popularArquivoNaListaAluno(listaAlunos, path);

string opcao;

do {
    Console.WriteLine("1 - Cadastrar Pessoa");
    Console.WriteLine("2 - Cadastrar Aluno");
    Console.WriteLine("3 - Listar todas as Pessoas cadastradas");
    Console.WriteLine("4 - Listar todos os Alunos cadastrados");
    Console.WriteLine("5 - Sair");
    Console.Write("Opção: ");
    opcao = Console.ReadLine();

    switch (opcao) {
        case "1":
            cadastrarPessoa();
            break;
        case "2":
            cadastrarAluno();
            break;
        case "3":
            Utils.mostrarListaPessoas(listaPessoas);
            break;
        case "4":
            Utils.mostrarListaAlunos(listaAlunos);
            break;
        case "5":
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }

} while (opcao != "5");


