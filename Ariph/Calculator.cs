using System.Data;

namespace Ariph
{
    public class Calculator
    {
        public static string? Evaluate(string input)
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

                return new DataTable().Compute(translatedExpression, null).ToString();
            }
            catch (SyntaxErrorException)
            {
                return "Возникла синтаксическая ошибка, проверьте выражение.";
            }

            catch (KeyNotFoundException)
            {
                return "Введено некорректное римское число.";
            }
        }
    }
}