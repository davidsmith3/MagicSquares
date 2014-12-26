using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicSquares.Domain;

namespace MagicSquares.Test {
    [TestClass]
    public class TestSquare {
        private int[,] goodSquareBDRU = new int[,] {
            {4, 9, 2},
            {3, 5, 7},
            {8, 1, 6}
        };

        private int[,] goodSquareBDLU = new int[,] {
            {2, 9, 4},
            {7, 5, 3},
            {6, 1, 8}
        };

        private int[,] goodSquareRRUL = new int[,] {
            {2, 7, 6},
            {9, 5, 1},
            {4, 3, 8}
        };

        private int[,] goodSquareRRDL = new int[,] {
            {4, 3, 8},
            {9, 5, 1},
            {2, 7, 6}
        };

        private int[,] goodSquareLLUR = new int[,] {
            {6, 7, 2},
            {1, 5, 9},
            {8, 3, 4}
        };

        private int[,] goodSquareLLDR = new int[,] {
            {8, 3, 4},
            {1, 5, 9},
            {6, 7, 2}
        };

        private int[,] goodSquareTURD = new int[,] {
            {8, 1, 6},
            {3, 5, 7},
            {4, 9, 2}
        };

        private int[,] goodSquareTULD = new int[,] {
            {6, 1, 8},
            {7, 5, 3},
            {2, 9, 4}
        };

        private int[,] badSquare = new int[,] {
            {4, 9, 2},
            {3, 5, 7},
            {8, 6, 1}
        };

        private int[,] badNotUnique = new int[,] {
            {5, 5, 5},
            {5, 5, 5},
            {5, 5, 5}
        };

        [TestMethod]
        public void TestIsValidKnownGood() {
            MagicSquare sq = new MagicSquare(goodSquareBDRU);

            Assert.IsTrue(sq.IsValid());
        }

        [TestMethod]
        public void TestIsValidKnownBad() {
            MagicSquare sq = new MagicSquare(badSquare);

            Assert.IsFalse(sq.IsValid());
        }

        [TestMethod]
        public void TestIsValidKnownBadNotUnique() {
            MagicSquare sq = new MagicSquare(badNotUnique);

            Assert.IsFalse(sq.IsValid());
        }

        [TestMethod]
        public void TestGeneratesKnownGoodTULD() {
            MagicSquare kg = new MagicSquare(goodSquareTULD);
            MagicSquare sq = new MagicSquare(3, "tuld");

            Assert.IsTrue(sq.IsValid());
            Assert.AreEqual(kg.ToString(), sq.ToString());
        }

        [TestMethod]
        public void TestGeneratesKnownGoodTURD() {
            MagicSquare kg = new MagicSquare(goodSquareTURD);
            MagicSquare sq = new MagicSquare(3, "turd");

            Assert.IsTrue(sq.IsValid());
            Assert.AreEqual(kg.ToString(), sq.ToString());
        }

        [TestMethod]
        public void TestGeneratesKnownGoodLLUR() {
            MagicSquare kg = new MagicSquare(goodSquareLLUR);
            MagicSquare sq = new MagicSquare(3, "llur");

            Assert.IsTrue(sq.IsValid());
            Assert.AreEqual(kg.ToString(), sq.ToString());
        }

        [TestMethod]
        public void TestGeneratesKnownGoodLLDR() {
            MagicSquare kg = new MagicSquare(goodSquareLLDR);
            MagicSquare sq = new MagicSquare(3, "lldr");

            Assert.IsTrue(sq.IsValid());
            Assert.AreEqual(kg.ToString(), sq.ToString());
        }

        [TestMethod]
        public void TestGeneratesKnownGoodRRUL() {
            MagicSquare kg = new MagicSquare(goodSquareRRUL);
            MagicSquare sq = new MagicSquare(3, "rrul");

            Assert.IsTrue(sq.IsValid());
            Assert.AreEqual(kg.ToString(), sq.ToString());
        }

        [TestMethod]
        public void TestGeneratesKnownGoodRRDL() {
            MagicSquare kg = new MagicSquare(goodSquareRRDL);
            MagicSquare sq = new MagicSquare(3, "rrdl");

            Assert.IsTrue(sq.IsValid());
            Assert.AreEqual(kg.ToString(), sq.ToString());
        }

        [TestMethod]
        public void TestGeneratesKnownGoodBDLU() {
            MagicSquare kg = new MagicSquare(goodSquareBDLU);
            MagicSquare sq = new MagicSquare(3, "bdlu");

            Assert.IsTrue(sq.IsValid());
            Assert.AreEqual(kg.ToString(), sq.ToString());
        }

        [TestMethod]
        public void TestGeneratesKnownGoodBDRU() {
            MagicSquare kg = new MagicSquare(goodSquareBDRU);
            MagicSquare sq = new MagicSquare(3, "bdru");

            Assert.IsTrue(sq.IsValid());
            Assert.AreEqual(kg.ToString(), sq.ToString());
        }

        [TestMethod]
        public void TestGeneratesLargeValid() {
            MagicSquare sq = new MagicSquare(9999, "bdru");

            Assert.IsTrue(sq.IsValid());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEvenN() {
            MagicSquare sq = new MagicSquare(2, "bdru");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNegativeN() {
            MagicSquare sq = new MagicSquare(-1, "bdru");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidType() {
            MagicSquare sq = new MagicSquare(3, "foo");
        }
    }
}
