using System.Data;
using Sprache;
using Sprache.Calc;

namespace Ariph
{
    public class Calculator
    {
        public static string Evaluate(string input)
        {
            try
            {
                var translatedExpression = "";
                var number = "";

                for (var i = 0; i < input.Length; i++)
                {
                    if (char.IsLetter(input[i]))
                    {
                        number += char.ToUpper(input[i]);

                        if (i == input.Length - 1)
                        {
                            translatedExpression += Convert.TranslationInArabicNumber(number);
                            number = "";
                        }

                        continue;
                    }

                    if (!string.IsNullOrEmpty(number))
                    {
                        translatedExpression += Convert.TranslationInArabicNumber(number);
                        number = "";
                    }

                    translatedExpression += input[i];
                }

                var calc = new SimpleCalculator();
                var func = calc.ParseExpression(translatedExpression).Compile();

                return "DataTable.Compute: " + new DataTable().Compute(translatedExpression, null) + ", Sprache.Calc: " + func();
            }
            catch (SyntaxErrorException)
            {
                return "Возникла синтаксическая ошибка, проверьте выражение.";
            }
            catch (KeyNotFoundException)
            {
                return "Введено некорректное римское число.";
            }
            catch (ParseException)
            {
                return "Возникла синтаксическая ошибка, проверьте выражение.";
            }
        }
    }
}