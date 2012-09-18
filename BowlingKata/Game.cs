using System;
using System.Linq;
using System.Threading;

namespace BowlingKata
{
	public class Game
	{
		private int[] _rolls = new int[21];
		private int _currentRoll = 0;

		public void Roll(int numPins)
		{
			if (_currentRoll > 20)
				throw new InvalidOperationException("This game is already complete");

			_rolls[_currentRoll] = numPins;
			_currentRoll++;
		}

		public int Score()
		{
			int score = 0;
			int frameIndex = 0;
			for (var frame =0; frame < 10; frame++ )
			{
				int frameScore;
				if ( IsStrike(frameIndex) )
				{
					frameScore = 10 + StrikeBonus(frameIndex);
					frameIndex++;
				}
				else
				{

					frameScore = SumOfFrame(frameIndex);
					if (IsSpare(frame))
					{
						frameScore += SpareBonus(frameIndex);
					}

					frameIndex += 2;
				}

				score += frameScore;
			}

			return score;
		}

		private int SumOfFrame(int frameIndex)
		{
			return _rolls[frameIndex] + _rolls[frameIndex + 1];
		}

		private int SpareBonus(int frameIndex)
		{
			int spareBonus = _rolls[frameIndex + 2];
			return spareBonus;
		}

		private int StrikeBonus(int frameIndex)
		{
			var strikeBonus = _rolls[frameIndex + 1]
			                  + _rolls[frameIndex + 2];
			return strikeBonus;
		}

		private bool IsStrike(int frameIndex)
		{
			return _rolls[frameIndex] == 10;
		}

		private bool IsSpare(int frame)
		{
			return _rolls[frame] + _rolls[frame + 1] == 10;
		}
	}
}