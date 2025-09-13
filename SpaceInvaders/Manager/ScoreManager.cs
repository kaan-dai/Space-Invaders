using System.Diagnostics;

namespace SE456
{
    public static class ScoreManager
    {
        public static void AddPoints(int points)
        {
            score += points;
            UpdateScoreDisplay();
        }
        public static int GetScore()
        {
            return score;
        }
        public static void Reset()
        {
            score = 0;
            UpdateScoreDisplay();
        }
        private static void UpdateScoreDisplay()
        {
            Font scoreFont = FontMan.Find(Font.Name.ScoreNum);
            if (scoreFont != null)
            {
                scoreFont.UpdateMessage(score.ToString());
            }
            else
            {
                Debug.WriteLine("Score font not found!");
            }
        }

        // ----------Data-----------

        public static int score = 0;
        public static int highScore = 0;

    }
}
