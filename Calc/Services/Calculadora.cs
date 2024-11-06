using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calc.Services
{
    public class Calculadora
    {
        private List<string> listaHistorico;
        private string _data;

        public Calculadora(string data)
        {
            listaHistorico = new List<string>();
            _data = data;
        }

        public void adicionarRegistro(int resultado)
        {
            listaHistorico.Insert(0, "Result: " + resultado + " - data" + _data);
        }

        public int Somar(int num1, int num2)
        {
            int result = num1 + num2;
            adicionarRegistro(result);
            
            return result;
        }

        public int Subtrair(int num1, int num2)
        {
            int result = num1 - num2;
            adicionarRegistro(result);

            return result;
        }

        public int Multiplicar(int num1, int num2)
        {
            int result = num1 * num2;
            adicionarRegistro(result);

            return result;
        }

        public int Dividir(int num1, int num2)
        {
            int result = num1 / num2;
            adicionarRegistro(result);

            return result;
        }

        public List<String> Historico()
        {
            listaHistorico.RemoveRange(3, listaHistorico.Count - 3);
            return listaHistorico;
        }
    }
}