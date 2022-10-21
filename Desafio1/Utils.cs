using System.Text;

namespace Desafio1;

public class Utils
{
    public static void cabecalho(string nomeArquivo, string texto)
    {
        StreamWriter sw = new StreamWriter(nomeArquivo);
        sw.WriteLine("X-"+texto);
        sw.Flush();
        sw.Close();
    }
    public static void gravarPessoaArquivo(Pessoa pessoa, string nomeArquivo)
    {
        StreamWriter sw = new StreamWriter(nomeArquivo, true);
        sw.WriteLine("Z-"+pessoa.Nome+"-"+pessoa.Telefone+"-"+pessoa.Cidade+"-"+pessoa.RG+"-"+pessoa.CPF);
        sw.Flush();
        sw.Close();
    }

    public static void gravarAlunoArquivo(Aluno aluno, string nomeArquivo)
    {
        StreamWriter sw = new StreamWriter(nomeArquivo, true);
        sw.WriteLine("Z-"+aluno.Nome+"-"+aluno.Telefone+"-"+aluno.Cidade+"-"+aluno.RG+"-"+aluno.CPF);
        sw.WriteLine("Y-"+aluno.Matricula+"-"+aluno.CodigoCurso+"-"+aluno.Curso);
        sw.Flush();
        sw.Close();
    }
    
    public static void popularArquivoNaListaPessoa(List<Pessoa> listaPessoas, string nomeArquivo) {
        StreamReader leitor = new StreamReader(nomeArquivo, Encoding.UTF8);
        try {
            string linha;
            string[] dadosLinha;
            Pessoa pessoa;
            do {
                dadosLinha = leitor.ReadLine().Split("-");
                if(dadosLinha[0] == "Z") {
                    pessoa = new Pessoa(dadosLinha[1], dadosLinha[2], dadosLinha[3], dadosLinha[4], dadosLinha[5]);
                    listaPessoas.Add(pessoa);
                }
            } while (!leitor.EndOfStream);
        } catch(Exception ex) {
            Console.WriteLine("Erro ao popular a lista de pessoas.");
        }        
        leitor.Close();
    }
    
    public static void popularArquivoNaListaAluno(List<Aluno> listaAlunos, string nomeArquivo) {
        StreamReader leitor = new StreamReader(nomeArquivo, Encoding.UTF8);
        try {
            string linha;
            string[] dadosLinha;
            Aluno aluno;
            do
            {
                linha = leitor.ReadLine();
                dadosLinha = linha.Split("-");
                if (dadosLinha[0] == "Z")
                {
                    string[] dadosLinha2 = leitor.ReadLine().Split("-");
                    if(dadosLinha2[0] == "Y") {
                        aluno = new Aluno(dadosLinha[1], dadosLinha[2], dadosLinha[3], dadosLinha[4], dadosLinha[5], dadosLinha2[1], dadosLinha2[2], dadosLinha2[3]);
                        listaAlunos.Add(aluno);
                    }
                }
            } while (!leitor.EndOfStream);
        } catch(Exception ex) {
            Console.WriteLine("Erro ao popular a lista de alunos.");
        }        
        leitor.Close();
    }
    
    public static void mostrarListaPessoas(List<Pessoa> listaPessoas)
    {
        int qtdPessoas = 0;
        Console.WriteLine("Lista de Pessoas");
        Console.WriteLine("------------------------");
        foreach (var pessoa in listaPessoas)
        {
            qtdPessoas++;
            pessoa.Imprimir();
            Console.WriteLine("------------------------");
        }
        Console.WriteLine("Quantidade de Pessoas: "+qtdPessoas);
    }
    
    public static void mostrarListaAlunos(List<Aluno> listaAlunos) {
        int qtdAlunos = 0;
        Console.WriteLine("Lista de Alunos");
        Console.WriteLine("------------------------");
        foreach (var aluno in listaAlunos) {
            qtdAlunos++;
            aluno.Imprimir();
            Console.WriteLine("------------------------");
        }
        Console.WriteLine("Quantidade de alunos: "+qtdAlunos);
    }
}