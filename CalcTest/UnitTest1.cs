using System.ComponentModel;
using Calc.Services;

namespace calctest;

public class CalcTest
{
    private Calculadora _calc;
    private string data = "02/02/2020";

    public CalcTest()
    {
        _calc = new Calculadora(data);
    }



    [Theory]
    [InlineData (1, 2, 3)]
    [InlineData (4, 5, 9)]
    public void VerificarSomaNumeros(int num1, int num2, int resultEsperado)
    {
        int result = _calc.Somar(num1, num2);

        Assert.Equal(resultEsperado, result);
    }

    [Theory]
    [InlineData (6, 2, 4)]
    [InlineData (5, 5, 0)]
    public void VerificarSubtracaoNumeros(int num1, int num2, int resultEsperado)
    {
        int result = _calc.Subtrair(num1, num2);

        Assert.Equal(resultEsperado, result);
    }

    [Theory]
    [InlineData (1, 2, 2)]
    [InlineData (4, 5, 20)]
    public void VerificarMultiplicacaoNumeros(int num1, int num2, int resultEsperado)
    {
        int result = _calc.Multiplicar(num1, num2);

        Assert.Equal(resultEsperado, result);
    }

    [Theory]
    [InlineData (6, 2, 3)]
    [InlineData (5, 5, 1)]
    public void VerificarDivisaoNumeros(int num1, int num2, int resultEsperado)
    {
        int result = _calc.Dividir(num1, num2);

        Assert.Equal(resultEsperado, result);
    }

    [Fact]
    public void TestarDivisaoPorZero()
    {
        Assert.Throws<DivideByZeroException>(
            () => _calc.Dividir(3,0)
        );
    }

    [Fact]
    public void TestarHistorico()
    {
        _calc.Somar(1, 2);
        _calc.Somar(2, 8);
        _calc.Somar(5, 4);
        _calc.Somar(8, 7);

        var lista = _calc.Historico();

        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count);
    }
}