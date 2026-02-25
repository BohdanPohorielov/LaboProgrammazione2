namespace AppQuiz;

public partial class ResultPage : ContentPage
{
	public ResultPage(int score)
	{
		int _score = score;
		InitializeComponent();
		ScoreAssignment(_score);
	}
	public int ScoreAssignment(int score) {
		LblScore.Text = "Score: "+ score.ToString() + "/20";
		return score;
	}
}