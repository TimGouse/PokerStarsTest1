using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStarsTest1
{
    //public class PlayerBets
    //{
    //    public string PlayerName { get; set; }
    //    public decimal CurrentBet { get; set; }
    //    public decimal TotalBets { get; set; } // Общая сумма ставок игрока в руке

    //    public PlayerBets(string playerName)
    //    {
    //        PlayerName = playerName;
    //        CurrentBet = 0;
    //        TotalBets = 0;
    //    }

    //    public void Bet(decimal amount)
    //    {
    //        CurrentBet = amount;
    //        TotalBets += amount;
    //    }

    //    public void RaiseTo(decimal amount)
    //    {
    //        // 'amount' - это общая ставка, на которую игрок повышает. Нам нужно вычесть его текущую ставку, чтобы узнать, сколько он действительно "повышает".
    //        decimal raiseAmount = amount - CurrentBet;
    //        CurrentBet = amount; // новая текущая ставка
    //        TotalBets += raiseAmount; // добавляем только сумму увеличения
    //    }

    //    public void Call(decimal amount)
    //    {
    //        CurrentBet = amount; // "call" соответствует текущей высшей ставке
    //        TotalBets += amount;
    //    }

    //    public void ResetForNewHand()
    //    {
    //        CurrentBet = 0;
    //    }
    //}
}
