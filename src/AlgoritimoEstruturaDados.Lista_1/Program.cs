//using static System.Runtime.InteropServices.JavaScript.JSType;

//1) Criar um programa que carregue uma matriz 12 x 4 com os valores (em reais) das vendas de uma loja de
//carros, em que cada linha represente um mês do ano, e cada coluna, uma semana do mês. Para fins de
//simplificação considere que cada mês possui somente 4 semanas. Calcule e imprima:
//-Total vendido em cada mês do ano;
//-Total vendido no ano;
//-Considerando todas as vendas do ano, informe qual é a melhor semana para vender carros (1ª, 2ª, 3ª ou 4ª)

using AlgoritimoEstruturaDados.Lista_1.Model;

Vendas vendas = new Vendas();

var totalVendidoMes = vendas.TotalDeVendasDoMes();

var totalVendidoAno = vendas.TotalDeVendasDoAno();

var semanaComMaisVendas = vendas.SemanaMaisVendasAnos();


foreach (var totalMes in totalVendidoMes)
Console.WriteLine("Total vendido no mês é: {0}", totalMes);

Console.WriteLine("Semana com mais venda do ano: {0}", semanaComMaisVendas);

Console.WriteLine("Total vendido no ano é: {0}", totalVendidoAno);
Console.ReadKey();