using NUnit.Framework;
using ClassLib;
using System.Collections.Generic;

namespace Testiki
{
    [TestFixture]
    public class OperatorTests
    {
        [Test]
        public void CalculateQuality_ReturnsCorrectValue()
        {
            Operator op = new Operator("TestOperator", 10.0m, 100.0, 1000, false);
            decimal quality = op.CalculateQuality();
            Assert.AreEqual(1000.0m, quality);
        }

        [Test]
        public void GetInfo_ReturnsCorrectString()
        {
            Operator op = new Operator("TestOperator", 10.0m, 100.0, 1000, false);
            string info = op.GetInfo();
            StringAssert.Contains("Оператор: TestOperator", info);
            StringAssert.Contains("Стоимость минуты: 10.00 руб.", info);
            StringAssert.Contains("Площадь покрытия: 100 кв.км", info);
            StringAssert.Contains("Количество абонентов: 1000", info);
            StringAssert.Contains("Международные звонки: Нет", info);
            StringAssert.Contains("Качество (Q): 1000.00", info);
        }

        [Test]
        public void AddOperator_AddsToList()
        {
            List<Operator> operators = new List<Operator>();
            Operator newOperator = new Operator("NewOperator", 5.0m, 50.0, 500, true);
            Operator.AddOperator(operators, newOperator);
            Assert.Contains(newOperator, operators);
        }

        [Test]
        public void RemoveOperator_RemovesFromList()
        {
            List<Operator> operators = new List<Operator>();
            Operator operatorToRemove = new Operator("OperatorToRemove", 5.0m, 50.0, 500, true);
            operators.Add(operatorToRemove);
            bool removed = Operator.RemoveOperator(operators, "OperatorToRemove");
            Assert.IsTrue(removed);
            Assert.IsEmpty(operators);
        }

        [Test]
        public void RemoveOperator_NotFound_ReturnsFalse()
        {
            List<Operator> operators = new List<Operator>();
            bool removed = Operator.RemoveOperator(operators, "NonExistentOperator");
            Assert.IsFalse(removed);
        }

        [Test]
        public void RemoveOperator_HashSet_RemovesFromSet()
        {
            HashSet<Operator> operators = new HashSet<Operator>();
            Operator operatorToRemove = new Operator("OperatorToRemove", 5.0m, 50.0, 500, true);
            operators.Add(operatorToRemove);
            bool removed = Operator.RemoveOperator(operators, operatorToRemove);
            Assert.IsTrue(removed);
            Assert.IsEmpty(operators);
        }
    }
}