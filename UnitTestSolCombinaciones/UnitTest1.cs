using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SumatoriasMonto;
using System.Globalization;

namespace UnitTestSolCombinaciones
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MoneyParts objetoPrueba = new MoneyParts();
            decimal monto = Convert.ToDecimal("0.1", CultureInfo.CreateSpecificCulture("en-US"));            
            Console.WriteLine(objetoPrueba.build(monto));           
        }

        [TestMethod]
        public void TestMethod2()
        {
            MoneyParts objetoPrueba = new MoneyParts();
            decimal monto = Convert.ToDecimal("0.5", CultureInfo.CreateSpecificCulture("en-US"));
            Console.WriteLine(objetoPrueba.build(monto));
        }

        [TestMethod]
        public void TestMethod3()
        {
            MoneyParts objetoPrueba = new MoneyParts();
            decimal monto = Convert.ToDecimal("10.5", CultureInfo.CreateSpecificCulture("en-US"));
            Console.WriteLine(objetoPrueba.build(monto));
        }
    }
}
