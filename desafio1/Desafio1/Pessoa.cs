namespace Desafio1;

public class Pessoa
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Cidade { get; set; }
    public string RG { get; set; }
    public string CPF { get; set; }
    
    public Pessoa(string nome, string telefone, string cidade, string rg, string cpf)
    {
        Nome = nome;
        Telefone = telefone;
        Cidade = cidade;
        RG = rg;
        CPF = cpf;
    }

    public void Imprimir()
    {
        Console.WriteLine("Z-"+Nome+"-"+Telefone+"-"+Cidade+"-"+RG+"-"+CPF);
    }
}