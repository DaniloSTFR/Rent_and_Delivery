using System.Text.RegularExpressions;

namespace RentAndDelivery.Domain.Util
{
    public class RemoveSpecialCharacters
    {
        public RemoveSpecialCharacters(){
        }

        public static string RemoveSpecialCharactersStr(string input)
        {
            // Define uma expressão regular para encontrar caracteres não alfanuméricos
            Regex regex = new Regex("[^a-zA-Z0-9]");
            // Remove os caracteres não alfanuméricos usando a expressão regular
            return regex.Replace(input, "");
        }
    }
}