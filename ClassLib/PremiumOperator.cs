using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class PremiumOperator : Operator
    {
        // Дополнительное поле P из задания
        public bool HasConnectionFee { get; set; }

        // Дополнительное свойство (по заданию)
        public decimal MonthlyFee { get; set; }

        public PremiumOperator(string name, decimal cost, double coverage, int subscribers, bool hasInternational, bool hasFee, decimal monthlyFee) : base(name, cost, coverage, subscribers, hasInternational)
        {
            HasConnectionFee = hasFee;
            MonthlyFee = monthlyFee;
        }

        // Переопределенный метод расчета качества
        public override decimal CalculateQuality()
        {
            decimal baseQ = base.CalculateQuality();
            return HasConnectionFee ? 0.7m * baseQ : 1.5m * baseQ;
        }

        // Переопределенный вывод информации
        public override string GetInfo()
        {
            return base.GetInfo() + $"\nПлата за соединение: {(HasConnectionFee ? "Да" : "Нет")}\n" +
                   $"Ежемесячная плата: {MonthlyFee} руб.\n" +
                   $"Качество премиум (Qp): {CalculateQuality():F2}";
        }
    }
}
