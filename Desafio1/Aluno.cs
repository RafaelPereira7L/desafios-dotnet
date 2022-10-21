namespace Desafio1;

public class Aluno : Pessoa
{
    public string Matricula { get; set; }
    public string CodigoCurso { get; set; }
    public string Curso { get; set; }

    public Aluno(string nome, string telefone, string cidade, string rg, string cpf, string matricula, string codigoCurso, string curso) : base(nome, telefone, cidade, rg, cpf)
    {
        Matricula = matricula;
        CodigoCurso = codigoCurso;
        Curso = curso;
    }

    public void ImprimirMatricula()
    {
        Console.WriteLine("Y-"+Matricula+"-"+CodigoCurso+"-"+Curso);
    }
    public new void Imprimir()
    {
        Console.WriteLine("Z-"+Nome+"-"+Telefone+"-"+Cidade+"-"+RG+"-"+CPF);
        ImprimirMatricula();
    }
}