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
    }
}
