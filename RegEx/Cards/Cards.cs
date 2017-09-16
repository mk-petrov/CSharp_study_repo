
namespace Cards
{
    using System;
    using System.Text.RegularExpressions;

    public class Cards
    {
        public static void Main()
        {
            var validCards = "[2345678910JQKA][SHDC]";
            var regex = new Regex(validCards);

            var line = Console.ReadLine();

            var cards = regex.Matches(line);

            var cardsAsArray = new string[cards.Count];

            for (int i = 0; i < cards.Count; i++)
            {
                var currentCard = cards[i].ToString();
                cardsAsArray[i] = currentCard;
            }

            Console.WriteLine(string.Join(", ", cardsAsArray));
        }
    }
}
