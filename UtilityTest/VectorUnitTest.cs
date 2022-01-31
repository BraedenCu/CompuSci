using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utility;

namespace UtilityTest
{
    [TestClass]
    public class VectorUnitTest
    {

        /// <summary>
        /// Test addition and subtraction with vectors using three distinct tests
        /// </summary>
        [TestMethod]
        public void TestAddSubtract()
        {
            int numValidations = 3;
            double precision = 6;
            var v1 = new Vector(1, -4, 6.7);
            Vector[] v2 = { new Vector(1, 5, 20.7), new Vector(0, -10, 5), new Vector(-0.1, 0, 10)};
            Vector[] solAdd = { new Vector(2, 1, 27.4), new Vector(1, -14, 11.7), new Vector(0.9, -4, 16.7)};
            Vector[] solSub = { new Vector(0, -9, -14), new Vector(1, 6, 1.7), new Vector(1.1, -4, -3.3)};

            for (int i = 0; i < numValidations; i++)
            {
                var s = v1 + v2[i];
                Assert.AreEqual(solAdd[i].RoundVector(solAdd[i], precision), s.RoundVector(s, precision));
                s = v1 - v2[i];
                Assert.AreEqual(solSub[i].RoundVector(solSub[i], precision), s.RoundVector(s, precision));
            }
        }

        /// <summary>
        /// Test multiplication and division with vectors using three distinct tests
        /// </summary>
        [TestMethod]
        public void TestMultDiv()
        {
            double precision = 6;
            var v1 = new Vector(1, -4, 6.7);
            double[] scal = {0, 10, -0.01 };
            Vector[] solDiv = { new Vector(1, 5, 20.7), new Vector(0.1, (-2/5), 0.67), new Vector(-100, 400, -670)};
            Vector[] solMult = { new Vector(double.NaN, double.NaN, double.NaN), new Vector(10, -40, 67), new Vector(-0.01, 0.04, -0.067)}; //my vector utility class returns NaN values when division by zero occours :)
        
            for(int i = 0; i < scal.Length; i++)
            {
                var s = v1 / scal[i];
                Assert.AreEqual(solDiv[i].RoundVector(solDiv[i], precision), s.RoundVector(s, precision));
                s = v1 * scal[i];
                Assert.AreEqual(solMult[i].RoundVector(solMult[i], precision), s.RoundVector(s, precision));
            }
        }

        /// <summary>
        /// Test magnitude calculation with vectors using three distinct tests
        /// </summary>
        [TestMethod]
        public void TestMagnitude()
        {
            int precision = 5;
            Vector[] v = {new Vector(1, 5, 20.7), new Vector(-1, 0, -0.11), new Vector(1000, 40.7, -1)};
            double[] solMag = { 21.31877, 1.00603, 1000.82840 };

            for (int i = 0; i < solMag.Length; i++)
            {
                var s = Math.Round(v[i].Magnitude(), precision);
                Assert.AreEqual(Math.Round(solMag[i], precision), s); //need to round both numbers to the "precision" defined decimal place to ensure that innacuracies are accounted for
            }
        }

        /// <summary>
        /// Test cross product calculation with vectors using three distinct tests
        /// </summary>
        [TestMethod]
        public void TestCross()
        {
            int numValidations = 3;
            double precision = 6;
            var v1 = new Vector(1, -4, 6.7);
            Vector[] v2 = { new Vector(1, 5, 20.7), new Vector(0, -10, 5), new Vector(-0.1, 0, 10) };
            Vector[] solCross = { new Vector(-116.3, -14, 9), new Vector(47, -5, -10), new Vector(-40, -10.67, -0.4) };

            for (int i = 0; i < numValidations; i++)
            {
                var s = v1.CrossProduct(v1, v2[i]);
                Assert.AreEqual(solCross[i].RoundVector(solCross[i], precision), s.RoundVector(s, precision));
            }
        }

        /// <summary>
        /// Test unit vector calculation with vectors using three distinct tests
        /// </summary>
        [TestMethod]
        public void TestUnit()
        {
            int numValidations = 3;
            double precision = 6;
            Vector v = new Vector(0, 0, 0);
            Vector[] v1 = { new Vector(1, 5, 20.7), new Vector(0, -10, 5), new Vector(-0.1, 0, 10) };
            Vector[] solUnit = { new Vector(0.04690, 0.23453, 0.97097), new Vector(0, -0.894427, 0.4472135), new Vector(-0.00999, 0, 0.99995) };

            for (int i = 0; i < numValidations; i++)
            {
                var s = v.UnitVector(v1[i]);
                Assert.AreEqual(solUnit[i].RoundVector(solUnit[i], precision), s.RoundVector(s, precision));
            }
        }

        /// <summary>
        /// Test equality operations with vectors using four distinct tests
        /// </summary>
        [TestMethod]
        public void TestEquality()
        {
            int numValidations = 4;
            var v = new Vector(0, 0, 0);
            Vector[] v1 = { new Vector(1, 5, 20.7), new Vector(0, -10, 5), new Vector(-0.1, 0, 1), new Vector(-0.1, 100, 10) };
            Vector[] v2 = { new Vector(1, 5, 20.7), new Vector(1, 10, 3), new Vector(-0.1, 0, 10), new Vector(-0.1, 100, 10) };
            bool[] solEqual = { true, false, false, true }; 
            bool[] solDiff = { false, true, true, false }; 

            for (int i = 0; i < numValidations; i++)
            {
                Assert.IsTrue((v1[i] == v2[i]) == solEqual[i]);
                Assert.IsTrue((v1[i] != v2[i]) == solDiff[i]);
            }
        }
    }
}