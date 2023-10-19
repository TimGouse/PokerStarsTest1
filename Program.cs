using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace PokerStarsTest1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HandHistory");

            var summary = new PokerHandSummary();

            // Обработка каждого файла истории рук
            foreach (var filePath in Directory.GetFiles(directoryPath, "*.txt"))
            {
                ProcessFile(filePath, summary);
            }

            // Вычисление общего выигрыша
            summary.TotalWinnings = summary.PlayerWins.Values.Sum();

            // Сохранение результатов в JSON-файл
            string json = JsonConvert.SerializeObject(summary, Formatting.Indented);
            File.WriteAllText(@"summary_results.json", json);
        }
        static void ProcessFile(string filePath, PokerHandSummary summary)
        {
            string[] lines = File.ReadAllLines(filePath);
            //Dictionary<string, PlayerBets> playerBets = new Dictionary<string, PlayerBets>();
            //bool newHandStarted = false;

            foreach (var line in lines)
            {
                if (line.Contains("PokerStars Game"))
                {
                    summary.TotalHands++; // Подсчет рук
                }

                // Обработка выигрышей
                Match matchWin = Regex.Match(line, @"Seat \d: (.+?) \(.+\) collected \((\$\d+(\.\d+)?)\)");
                if (matchWin.Success)
                {
                    string player = matchWin.Groups[1].Value;
                    string winningsString = matchWin.Groups[2].Value.Replace("$", "");
                    decimal winnings = decimal.Parse(winningsString, System.Globalization.CultureInfo.InvariantCulture);

                    if (summary.PlayerWins.ContainsKey(player))
                    {
                        summary.PlayerWins[player] += winnings;
                    }
                    else
                    {
                        summary.PlayerWins[player] = winnings;
                    }
                }

                //// Обработка ставок и повышений
                //Match matchBetOrRaise = Regex.Match(line, @"(.+?): (bets|raises to|calls) (\$\d+(\.\d+)?)");
                //if (matchBetOrRaise.Success)
                //{
                //    string player = matchBetOrRaise.Groups[1].Value;
                //    string action = matchBetOrRaise.Groups[2].Value;
                //    string amountString = matchBetOrRaise.Groups[3].Value.Replace("$", "");
                //    decimal amount = decimal.Parse(amountString, System.Globalization.CultureInfo.InvariantCulture);

                //    if (!playerBets.ContainsKey(player))
                //    {
                //        playerBets[player] = new PlayerBets(player);
                //    }

                //    if (action == "bets" || action == "calls")
                //    {
                //        playerBets[player].Bet(amount);
                //    }
                //    else if (action == "raises to")
                //    {
                //        playerBets[player].RaiseTo(amount - playerBets[player].TotalBets); // Теперь учитываем только сумму повышения
                //    }
                //}

                //// Обработка возврата ставок
                //Match matchReturned = Regex.Match(line, @"Uncalled bet \((\$\d+(\.\d+)?)\) returned to (.+)");
                //if (matchReturned.Success)
                //{
                //    string player = matchReturned.Groups[3].Value;
                //    string returnedString = matchReturned.Groups[1].Value.Replace("$", "");
                //    decimal returned = decimal.Parse(returnedString, System.Globalization.CultureInfo.InvariantCulture);

                //    if (!playerBets.ContainsKey(player))
                //    {
                //        playerBets[player] = new PlayerBets(player);
                //        playerBets[player].TotalBets = -returned; // Если у игрока не было ставок, создаем запись с отрицательной потерей
                //    }
                //    else
                //    {
                //        playerBets[player].TotalBets -= returned; // Корректируем общую ставку, вычитая возвращенную сумму
                //    }
                //}

                //// На конце руки (подведение итогов)
                //if (line.StartsWith("*** SUMMARY ***") || newHandStarted)
                //{
                //    foreach (var playerBet in playerBets.Values)
                //    {
                //        if (summary.PlayerLosses.ContainsKey(playerBet.PlayerName))
                //        {
                //            summary.PlayerLosses[playerBet.PlayerName] += playerBet.TotalBets;
                //        }
                //        else
                //        {
                //            summary.PlayerLosses[playerBet.PlayerName] = playerBet.TotalBets;
                //        }

                //        playerBet.ResetForNewHand(); // сброс для новой руки
                //    }

                //    playerBets.Clear(); // Очищаем информацию о ставках перед следующей рукой
                //    newHandStarted = false; // Сброс флага для следующей руки
                //}
            }
        }
    }  
}