using System.Numerics;

char[] colors = {'R','G','B','W'};
int[] values = {1,2,3,4,5,6,7,8,9,10};
int n = 0;
string[,] deal_cards = { { "" } };

string[] all_cards = new string[colors.Length * values.Length];

for (int i = 0; i < colors.Length; i++)
    for (int j = 0; j < values.Length; j++)
    {
        all_cards[n] = colors[i] + Convert.ToString(values[j]);
        n++;
    }

Random rnd = new Random();

while (true)
{
    string[] command = Console.ReadLine().Split(' ');
    switch(command[0])
    {
        case "start":
            int number_of_cards = int.Parse(command[1]);
            int number_of_players = int.Parse(command[2]);
            if (number_of_cards * number_of_players > all_cards.Length)
            {
                Console.WriteLine("Ошибка! Раздачу карт выполнить невозможно. Введенные числа слишком большие.");
                break;
            }
            else
            {
                deal_cards = DealCards(number_of_cards, number_of_players);
                break;
            }
       
        case "get-cards":
            int player_number = int.Parse(command[1]);
            if (player_number > deal_cards.GetUpperBound(1) + 1)
            {
                Console.WriteLine("Ошибка! Общее количесво игроков меньше, чем введенный номер игрока.");
                break;
            }
            else
            {
                GetPlayerCards(deal_cards, player_number);
                break;
            }
    }
}
string[,] DealCards(int cards, int players)
{
    string[,] deal_cards = new string[cards, players];
    var note = new List<int>();
    for (int i = 0; i < cards; i++)
        for (int j = 0; j < players; j++)
        {
            int n = rnd.Next(all_cards.Length);
            while (note.Contains(n)) n = rnd.Next(all_cards.Length);
            note.Add(n);
            deal_cards[i, j] = all_cards[n];
        }
    return deal_cards;
}

void GetPlayerCards(string[,] deal_cards, int player)
{
    Console.Write(player);
    for (int i = 0; i < deal_cards.GetUpperBound(0) + 1; i++)
        Console.Write(" " + deal_cards[i, player - 1]);
}
