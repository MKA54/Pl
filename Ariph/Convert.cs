namespace Ariph
{
    internal static  class Convert
    {
        public static int TranslationInArabicNumber(string roman)
        {
            var result = 0;
            for (var i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && IsSubtractive(roman[i], roman[i + 1]))
                {
                    result -= RomanNumerals.RomanNumeralsMap[roman[i]];
                }
                else
                {
                    result += RomanNumerals.RomanNumeralsMap[roman[i]];
                }
            }
            return result;
        }

        private static bool IsSubtractive(char c1, char c2)
        {
            return RomanNumerals.RomanNumeralsMap[c1] < RomanNumerals.RomanNumeralsMap[c2];
        }
    }
}
