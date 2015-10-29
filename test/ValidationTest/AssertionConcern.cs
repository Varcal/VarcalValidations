using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;

namespace ValidationTest
{
    [TestClass]
    public class AssertionConcernTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Validar_Tamanho_Minimo_Da_String()
        {
            string txt = "Tes";
            int length = 4;

            AssertionConcern.MinLength(txt, length);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Validar_Tamanho_Maximo_Da_String()
        {
            string txt = "Teste";
            int length = 4;

            AssertionConcern.MaxLength(txt, length);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Validar_Tamanho_Entre_Um_Minino_E_Um_Maximo_Da_String()
        {
            //Arrange

            string txtMin = "T";
            string txtMax = "Teste";
            int minLength = 2;
            int maxLength = 4;


            //Act

            AssertionConcern.BetweenLength(txtMin, minLength, maxLength);

            AssertionConcern.BetweenLength(txtMax, minLength, maxLength);


            //Assert

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Validar_Somente_Numeros()
        {
            //Arrange 
            var txt = "123A123";


            //Act

            AssertionConcern.OnlyNumber(txt);


            //Assert


        }


        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException))]
        public void Validar_Valor_Entre_Um_Valor_Minimo_E_Maximo()
        {
            //Arrange

            int num = 1;
            int minValue = 2;
            int maxValue = 4;

            //Act

            AssertionConcern.BetweenValue(num, minValue, maxValue);


            //Assert
        }


    }



    public sealed class AssertionConcern
    {
        /// <summary>
        /// Valida tamanho mínimo de uma string.
        /// </summary>
        /// <param name="txt">variável</param>
        /// <param name="length">define valor mínimo</param>
        /// <param name="msgError">>menssagem de erro(Opcional)</param>
        public static void MinLength(string txt, int length, [Optional] string msgError)
        {
            var msg = string.IsNullOrWhiteSpace(msgError) ? string.Format("O campo deve ter no míniimo {0} caracteres", length) : msgError;

            if (txt.Length < length)
            {
                throw new InvalidOperationException(msg);
            }
        }


        /// <summary>
        /// Valida tamanho máximo de uma string.
        /// </summary>
        /// <param name="txt">variável</param>
        /// <param name="length">define valor máximo</param>
        /// <param name="msgError">menssagem de erro(Opcional)</param>
        public static void MaxLength(string txt, int length, [Optional] string msgError)
        {
            var msg = string.IsNullOrWhiteSpace(msgError) ? String.Format("O campo deve ter no máximo {0} caracteres", length) : msgError;

            if (txt.Length > length)
            {
                throw new InvalidOperationException(String.Format(msg));
            }
        }


        /// <summary>
        /// Válida tamanho de string entre um valor mínimo e máximo
        /// </summary>
        /// <param name="txt">variável</param>
        /// <param name="minLenght">valor minimo</param>
        /// <param name="maxLength">valor maximo</param>
        /// <param name="msgError">menssagem de erro(Opcional)</param>
        public static void BetweenLength(string txt, int minLenght, int maxLength, [Optional] string msgError)
        {
            var msg = string.IsNullOrWhiteSpace(msgError) ? String.Format("O campo deve ter no minimo {0} e no máximo {1} caracteres", minLenght, maxLength) : msgError;

            if (txt.Length < minLenght || txt.Length > maxLength)
            {
                throw new InvalidOperationException(msg);
            }
        }


        /// <summary>
        /// Válida se string contém apenas números
        /// </summary>
        /// <param name="txt">váriavel</param>
        /// <param name="msgError">menssagem de erro(Opcional)</param>
        public static void OnlyNumber(string txt, [Optional] string msgError)
        {
            var msg = string.IsNullOrWhiteSpace(msgError) ? String.Format("O campo deve ter apenas numeros") : msgError;


            if (txt.Any(c => !char.IsNumber(c)))
            {
                throw new InvalidOperationException(msg);
            }
        }


        /// <summary>
        /// Válida se o valor esta entre um valor mínimo e máximo
        /// </summary>
        /// <param name="num"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="msgError"></param>
        public static void BetweenValue(int num, int minValue, int maxValue, [Optional] string msgError)
        {
            var msg = string.IsNullOrWhiteSpace(msgError) ? String.Format("O valor deve entre {0} e  {1}.", minValue, maxValue) : msgError;

            if (num<minValue || num>maxValue)
            {
                throw new InvalidOperationException(msg);
            }
        }
    }
   
}
