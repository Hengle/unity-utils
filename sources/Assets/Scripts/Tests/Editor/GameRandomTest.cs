﻿using System;
using Assets.Scripts.Utils;
using NUnit.Framework;

namespace Assets.Scripts.Tests.Editor
{
	[TestFixture]
	public class GameRandomTest
	{
        [Test]
        public void NextDiscreteTest1()
        {
            for (int attempt = 1; attempt <= 100; attempt++)
            {
                float randomValue = GameRandom.NextDiscrete(-100f, 100f, 25);
                Assert.IsTrue(randomValue >= -100 && randomValue <= 100);
            }
        }

        [Test]
        public void NextDiscreteTest2()
        {
            const float minValue = 55.5f;
            
            float randomValue = GameRandom.NextDiscrete(minValue, 155.4f, 1);
            Assert.AreEqual(minValue, randomValue);

            randomValue = GameRandom.NextDiscrete(minValue, 155.4f, 0);
            Assert.AreEqual(minValue, randomValue);

            randomValue = GameRandom.NextDiscrete(minValue, 155.4f, -1);
            Assert.AreEqual(minValue, randomValue);
        }

        [Test]
        public void NextDiscreteTest3()
        {
            const float min = 25.0f;
            const float max = 50.0f;
            for (int attempt = 1; attempt <= 100; attempt++)
            {
                float randomValue = GameRandom.NextDiscrete(min, max, 2);
                Assert.IsTrue(Math.Abs(randomValue - min) < 0.001 || Math.Abs(randomValue - max) < 0.001);
            }
        }

        [Test]
        public void NextDiscreteTest4()
        {
            const float min = 25.0f;
            const float max = 50.0f;
            for (int attempt = 1; attempt <= 100; attempt++)
            {
                float randomValue = GameRandom.NextDiscrete(min, max, 3);
				Assert.IsTrue(
					Math.Abs(randomValue - min) < 0.001 ||
					Math.Abs(randomValue - max) < 0.001 ||
					Math.Abs(randomValue - (min + max)/2) < 0.001);
            }
        }

	    [Test]
	    public void NextWeightedIndTest1()
	    {
	        int[] weights = {10, 0};
	        for (int attempt = 1; attempt <= 100; attempt++)
	        {
	            int ind = GameRandom.NextWeightedInd(weights);
	            Assert.AreEqual(0, ind);
	        }
	    }

        [Test]
        public void NextWeightedIndTest2()
        {
            int[] weights = { 0, 100 };
            for (int attempt = 1; attempt <= 100; attempt++)
            {
                int ind = GameRandom.NextWeightedInd(weights);
                Assert.AreEqual(1, ind);
            }
        }

        [Test]
        public void NextWeightedIndTest3()
        {
            int[] weights = {0, 100, 0, 0, 200};
            for (int attempt = 1; attempt <= 100; attempt++)
            {
                int ind = GameRandom.NextWeightedInd(weights);
                Assert.IsTrue(ind == 1 || ind == 4);
            }
        }

		[Test]
		public void NextBool()
		{
			int counter = 0;
			for(int i = 0; i < 1000; i++)
			{
				bool randomBool = GameRandom.NextBool();
				if(randomBool)
					counter++;
			}
			Console.WriteLine(counter);
		}
	}
}
