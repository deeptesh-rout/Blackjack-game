using System;

class Program
{
    static Random random = new Random();
    static int playerScore = 0;
    static int dealerScore = 0;

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Blackjack!");

        while (true)
        {
            playerScore = 0;
            dealerScore = 0;

            // Deal initial cards
            DealCard(true);
            DealCard(false);
            DealCard(true);
            DealCard(false);

            // Player's turn
            while (playerScore < 21)
            {
                Console.WriteLine($"Your score: {playerScore}");
                Console.Write("Do you want to hit or stand? (h/s): ");
                char choice = Console.ReadLine().ToLower()[0];
                if (choice == 'h')
                {
                    DealCard(true);
                }
                else if (choice == 's')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'h' to hit or 's' to stand.");
                }
            }

            if (playerScore > 21)
            {
                Console.WriteLine("Busted! Dealer wins.");
            }
            else
            {
                // Dealer's turn
                while (dealerScore < 17)
                {
                    DealCard(false);
                }

                Console.WriteLine($"Your score: {playerScore}");
                Console.WriteLine($"Dealer's score: {dealerScore}");

                if (dealerScore > 21 || playerScore > dealerScore)
                {
                    Console.WriteLine("You win!");
                }
                else if (playerScore < dealerScore)
                {
                    Console.WriteLine("Dealer wins.");
                }
                else
                {
                    Console.WriteLine("It's a tie.");
                }
            }

            Console.Write("Do you want to play again? (y/n): ");
            char playAgain = Console.ReadLine().ToLower()[0];
            if (playAgain != 'y')
            {
                break;
            }
        }

        Console.WriteLine("Thanks for playing!");
    }

    static void DealCard(bool isPlayer)
    {
        int cardValue = random.Next(1, 14); // 1-13 representing cards 2-10, J, Q, K, A
        if (cardValue > 10)
        {
            cardValue = 10; // J, Q, K are worth 10
        }
        else if (cardValue == 1)
        {
            cardValue = 11; // Ace is initially worth 11
        }

        if (isPlayer)
        {
            Console.WriteLine($"You draw: {CardName(cardValue)}");
            playerScore += cardValue;
            // Handle Ace as 1 if player's score exceeds 21
            if (playerScore > 21 && cardValue == 11)
            {
                playerScore -= 10;
            }
        }
        else
        {
            Console.WriteLine($"Dealer draws: {CardName(cardValue)}");
            dealerScore += cardValue;
            // Handle Ace as 1 if dealer's score exceeds 21
            if (dealerScore > 21 && cardValue == 11)
            {
                dealerScore -= 10;
            }
        }
    }

    static string CardName(int value)
    {
        if (value == 1)
        {
            return "Ace";
        }
        else if (value == 11)
        {
            return "Jack";
        }
        else if (value == 12)
        {
            return "Queen";
        }
        else if (value == 13)
        {
            return "King";
        }
        else
        {
            return value.ToString();
        }
    }
}
