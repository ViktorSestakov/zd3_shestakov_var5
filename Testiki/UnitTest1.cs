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