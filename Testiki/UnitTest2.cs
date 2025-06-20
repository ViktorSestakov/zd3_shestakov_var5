using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testiki
{
    [TestFixture]
    public class PremiumOperatorTests
    {
        [Test]
        public void CalculateQuality_WithConnectionFee_ReturnsCorrectValue()
        {
            PremiumOperator premiumOp = new PremiumOperator("PremiumOperator", 10.0m, 100.0, 1000, false, true, 50.0m);
            decimal quality = premiumOp.CalculateQuality();
            Assert.AreEqual(700.0m, quality);
        }

        [Test]
        public void CalculateQuality_WithoutConnectionFee_ReturnsCorrectValue()
        {
            PremiumOperator premiumOp = new PremiumOperator("PremiumOperator", 10.0m, 100.0, 1000, false, false, 50.0m);
            decimal quality = premiumOp.CalculateQuality();
            Assert.AreEqual(1500.0m, quality);
        }

        [Test]
        public void GetInfo_ReturnsCorrectString()
        {
            PremiumOperator premiumOp = new PremiumOperator("PremiumOperator", 10.0m, 100.0, 1000, false, true, 50.0m);
            string info = premiumOp.GetInfo();
            StringAssert.Contains("Оператор: PremiumOperator", info);
            StringAssert.Contains("Стоимость минуты: 10.00 руб.", info);
            StringAssert.Contains("Площадь покрытия: 100 кв.км", info);
            StringAssert.Contains("Количество абонентов: 1000", info);
            StringAssert.Contains("Международные звонки: Нет", info);
            StringAssert.Contains("Плата за соединение: Да", info);
            StringAssert.Contains("Ежемесячная плата: 50.00 руб.", info);
            StringAssert.Contains("Качество премиум (Qp): 700.00", info);
        }
    }
}
