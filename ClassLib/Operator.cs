using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Operator
    {
        // Поля из задания
        public string OperatorName { get; set; }
        public decimal CostPerMinute { get; set; }
        public double CoverageArea { get; set; }

        // Два дополнительных поля (по заданию)
        public int SubscriberCount { get; set; }
        public bool HasInternationalCalls { get; set; }

        // Конструктор
        public Operator(string name, decimal cost, double coverage, int subscribers, bool hasInternational)
        {
            OperatorName = name;
            CostPerMinute = cost;
            CoverageArea = coverage;
            SubscriberCount = subscribers;
            HasInternationalCalls = hasInternational;
        }

        // Метод расчета качества
        public virtual decimal CalculateQuality()
        {
            if (CostPerMinute == 0) return 0;
            return 100 * (decimal) CoverageArea / CostPerMinute;
        }

        // Вывод информации
        public virtual string GetInfo()
        {
            return $"Оператор: {OperatorName}\n" +
                   $"Стоимость минуты: {CostPerMinute} руб.\n" +
                   $"Площадь покрытия: {CoverageArea} кв.км\n" +
                   $"Количество абонентов: {SubscriberCount}\n" +
                   $"Международные звонки: {(HasInternationalCalls ? "Да" : "Нет")}\n" +
                   $"Качество (Q): {CalculateQuality():F2}";
        }

        // Методы для работы с коллекциями (две перегрузки)
        public static void AddOperator(List<Operator> operators, Operator newOperator)
        {
            operators.Add(newOperator);
        }

        public static bool RemoveOperator(List<Operator> operators, string operatorName)
        {
            var op = operators.Find(o => o.OperatorName.Equals(operatorName, StringComparison.OrdinalIgnoreCase));
            if (op != null)
            {
                operators.Remove(op);
                return true;
            }
            return false;
        }

        // Вторая перегрузка для удаления
        public static bool RemoveOperator(HashSet<Operator> operators, Operator operatorToRemove)
        {
            return operators.Remove(operatorToRemove);
        }
    }
}
