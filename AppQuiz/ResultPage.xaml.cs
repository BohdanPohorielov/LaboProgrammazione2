using Microsoft.Maui.Graphics.Text;

namespace AppQuiz;

public partial class ResultPage : ContentPage
{

	public ResultPage(int score, int totalScore, string nome)
	{
		int _score = score;
		string _nome = nome;
		int _totalScore = totalScore;
		InitializeComponent();
		BestScoreAssignment(_nome);
		LblComplete.Text = "QUIZ COMPLETATO DA " + nome + "!";

		ScoreAssignment(_score, _totalScore);
	}
	public int ScoreAssignment(int score, int totalScore)
	{
		LblScore.Text = "Score: " + score.ToString() + "/" + totalScore;
		return score;
	}

	public void BestScoreAssignment(string nome) {
		List<string> tentativi = new();
		foreach (string riga in File.ReadAllLines("C:\\Users\\vun297\\Labo-Programmazione-2\\Labo2\\AppQuiz\\Files\\MigliorPunteggio.txt")) {
			if (riga.Contains($",{nome},")) {
				tentativi.Add(riga);
			}
		}
		List<string> splitted = new();
		foreach (string riga in tentativi) {
			foreach (string number in riga.Split(",")){
				splitted.Add(number);
			}
		}
		int bestscore = 0;
		for (int i = 2; i < splitted.Count; i += 3) {
			if (Int16.Parse(splitted[i]) > bestscore) {
				bestscore = Int16.Parse(splitted[i]);
			}
		}
		LblBestScore.Text = "Your best score is: " + bestscore.ToString();
    }
}