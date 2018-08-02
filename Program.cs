using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class NumeroFeliz
    {        
        public string VerificarNumero(int numero)
        {
            string resultado = "";

            bool numeroFeliz = false;
            List<int> listaDigitos = new List<int>();
            listaDigitos = DividirDigitos(numero);
            for (int i = 0; i < 20 && !numeroFeliz; i++)
            {
                int soma = CalcularQuadrados(listaDigitos);
                if (soma != 1)
                    listaDigitos = DividirDigitos(soma);
                else numeroFeliz = true;
            }

            if (numeroFeliz)
            {
                resultado = " Feliz";
            }
            else
            {
                resultado = " Não Feliz";
            }
            
            return resultado;
        }

        public static List<int> DividirDigitos(int digito)
        {
            List<int> listaDigitos = new List<int>();
            while (digito != 0)
            {
                listaDigitos.Add(digito % 10);
                digito = digito / 10;
            }
            return listaDigitos;
        }

        public static int CalcularQuadrados(List<int> listaDigitos)
        {
            int resultado = 0;
            foreach (int digito in listaDigitos) resultado += digito * digito;
            return resultado;
        }
    }

    public class NumeroSortudo
    {
        public string RetornarNumeroSortudo(int range)
        {
            return ImprimirResultado(EncontrarNumeroSortudo(range));
        }

        public string RetornarsortudoPrimoNumeros(int range)
        {
            bool[] numeros = EncontrarNumeroSortudo(range);

            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i]) continue;
                numeros[i] = !NumeroPrimo(i + 1);
            }

            return ImprimirResultado(numeros);
        }

        public bool[] EncontrarNumeroSortudo(int range)
        {
            if (range < 1) range = 0;
            bool[] numeros = new bool[range];
            int sortudoContar = 2;

            while (sortudoContar < numeros.Length)
            {
                sortudoContar = NumeroFora(numeros, sortudoContar);
            }

            return numeros;
        }

        private int NumeroFora(bool[] numeros, int sortudoContar)
        {
            int contador = 0;

            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i]) continue;
                contador++;

                if (contador == sortudoContar)
                {
                    numeros[i] = true;
                    contador = 0;
                }
            }

            return RetornarsortudoContar(numeros, sortudoContar);
        }

        private int RetornarsortudoContar(bool[] numeros, int pular)
        {
            if (pular >= numeros.Length) return numeros.Length;

            for (int i = pular; i < numeros.Length; i++)
            {
                if (!numeros[i]) return i + 1;
            }

            return numeros.Length;
        }

        private static bool NumeroPrimo(int numero)
        {
            if (numero == 1) return false;

            for (short i = 3; i <= Math.Sqrt(numero); i += 2)
            {
                if (numero % i == 0) return false;
            }

            return true;
        }

        private static string ImprimirResultado(bool[] numeros)
        {
            string resultado = string.Empty;

            for (int i = 0; i < numeros.Length; i++)
            {
                if (!numeros[i]) resultado = resultado + (i + 1) + ",";
            }

            if (!string.IsNullOrEmpty(resultado)) resultado = resultado.Substring(0, resultado.Length - 1);

            return resultado;
        }

        public string VerificaNumero(int numero)
        {
            IDictionary<int, string> CasoTeste = new Dictionary<int, string>();
            for (int i = 0; i < 100; i++)
            {
                CasoTeste.Add(i, Convert.ToString(i));
            }

            string resultado = "";
            NumeroSortudo sortudo = new NumeroSortudo();

            foreach (var testCase in CasoTeste)
            {
                resultado = sortudo.RetornarNumeroSortudo(testCase.Key);
                                
            }

            string[] array = resultado.Split(',');
                        
            bool numeroSortudo = false;

            foreach (var item in array)
            {
                if (numero.ToString() == item)
                {
                    numeroSortudo = true;
                }
            }

            if (numeroSortudo)
            {                
                resultado = " sortudo";
            }
            else
            {                
                resultado = "não sortudo";
            }

            return resultado;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite um número");
            int meuNumero = Convert.ToInt32(Console.ReadLine());
            string resultadoFinal = "";

            NumeroSortudo sortudo = new NumeroSortudo();

            resultadoFinal = sortudo.VerificaNumero(meuNumero);

            NumeroFeliz feliz = new NumeroFeliz();

            resultadoFinal += " e " + feliz.VerificarNumero(meuNumero);

            Console.WriteLine("Número " + meuNumero + " " + resultadoFinal);
            
            Console.ReadKey();

        }
        
    }
}
