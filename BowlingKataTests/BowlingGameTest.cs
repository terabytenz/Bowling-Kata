using BowlingKata;
using NUnit.Framework;

namespace BowlingKataTests
{
	[TestFixture]
	public class BowlingGameTest
	{

		[SetUp]
		public void SetUp()
		{
			_game = new Game();
		}		private Game _game;

		[Test]
		public void TestGutterGame()
		{
			RollMany(0, 20);

			int score = _game.Score();
			Assert.That(score, Is.EqualTo(0));
		}

		[Test]
		public void TestAllOnes()
		{
			RollMany(1, 20);

			int score = _game.Score();
			Assert.That(score, Is.EqualTo(20));
		}

		[Test]
		public void TestRollOneSpare()
		{
			RollSpare();
			_game.Roll(3);
			RollMany(0, rollCount: 17);

			Assert.That(_game.Score(), Is.EqualTo(16));
		}

		[Test]
		public void TestRollStrike()
		{
			RollStrike();
			_game.Roll(3);
			_game.Roll(4);
			RollMany(0, rollCount:16);

			Assert.That(_game.Score(), Is.EqualTo(24));
		}

		[Test]
		public void PerfectGame()
		{
			RollMany(10, rollCount:12);
			Assert.That(_game.Score(), Is.EqualTo(300));
		}

		[Test,ExpectedException(ExpectedException = typeof(System.InvalidOperationException))]
		public void NoMoreThan21Rolls()
		{
			RollMany(0, 22);
		}

		private void RollStrike()
		{
			_game.Roll(10);
		}

		private void RollSpare()
		{
			_game.Roll(3);
			_game.Roll(7);
		}

		private void RollMany(int numPins, int rollCount)
		{
			for (int i = 0; i < rollCount; i++)
				_game.Roll(numPins);
		}
	}
}