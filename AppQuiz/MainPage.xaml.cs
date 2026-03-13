using AppQuiz.Models;

namespace AppQuiz
{
    public partial class MainPage : ContentPage
    {
        private List<QuestionBase> _questions = new List<QuestionBase>();
        private int _currentIndex = 0;
        private int _score;
        private string bestScorePath = "C:\\Users\\vun297\\Labo-Programmazione-2\\Labo2\\AppQuiz\\Files\\MigliorPunteggio.txt";
        public MainPage()
        {
            InitializeComponent();
            _questions.Add(new TrueFalseQuestion("Il C# è un linguaggio a oggetti?", 10, "true", "!no"));
            _questions.Add(new TrueFalseQuestion("Python è un lingiaggio compilato?", 10, "false", "!si"));
            _questions.Add(new OpenQuestion("Quanti allievi ci sono nella classe I2BB?", 25, "12", "sqrt((9^2 + 3*3) * 2) - log2(16) + (cos(pi/3) * 18) / (3^(1/2))"));
            ShowQuestion();
        }

        private void OnAnswer_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            string userAnswer = "";
            int k = 0;
            if (_questions[_currentIndex] is TrueFalseQuestion)
            {
                userAnswer = btn.CommandParameter.ToString();
            }
            else if (_questions[_currentIndex] is OpenQuestion)
            {
                if (!string.IsNullOrWhiteSpace(DomandaEnt.Text))
                {
                    userAnswer = DomandaEnt.Text;

                }
                else
                {
                    k += 1;
                }
            }

            if (k == 0)
            {
                if (_currentIndex != _questions.Count)
                {
                    {
                        if (_questions[_currentIndex].ChechAnswer(userAnswer))
                        {
                            _score += _questions[_currentIndex].Points;
                        }
                        _currentIndex++;
                        ShowQuestion();
                    }
                }
            }
        }

        private void ShowQuestion()
        {
            if (_currentIndex >= _questions.Count)
            {
                ScoreLabel.Text = _score.ToString();
                QuestionTextLabel.Text = "Finito";
                DomandaLabel.Text = "";
                btnHint.IsVisible = false;
                LblHint.IsVisible = false;
                btnResult.IsVisible = true;
                TrueButton.IsVisible = false;
                FalseButton.IsVisible = false;
                return;
            }

            QuestionBase current = _questions[_currentIndex];

            QuestionTextLabel.Text = current.Text;
            LblHint.Text = current.Hint;
            ScoreLabel.Text = _score.ToString();
            btnHint.IsVisible = true;
            LblHint.IsVisible = false;
            if (current is OpenQuestion)
            {
                DomandaEnt.IsVisible = true;
                DomandaBtn.IsVisible = true;
                TrueButton.IsVisible = false;
                FalseButton.IsVisible = false;
            }
            else
            {
                DomandaEnt.IsVisible = false;
                DomandaBtn.IsVisible = false;
                TrueButton.IsVisible = true;
                FalseButton.IsVisible = true;
            }
        }
        private void btnResult_Clicked(object sender, EventArgs e)
        {
            OnQuizFinished();
        }

        private void Resetbtn_Clicked(object sender, EventArgs e)
        {
            _currentIndex = 0;
            _score = 0;
            DomandaEnt.Text = "";
            btnResult.SetValue(IsVisibleProperty, false);
            ShowQuestion();
        }

        private void btnHint_Clicked(object sender, EventArgs e)
        {
            LblHint.SetValue(IsVisibleProperty, true);
        }
        private async void OnQuizFinished()
        {
            LblHint.IsVisible = false;
            TrueButton.IsVisible = false;
            FalseButton.IsVisible = false;
            DomandaBtn.IsVisible = false;
            DomandaEnt.IsVisible = false;

            int _totalScore = 0;

            string _nome = await DisplayPromptAsync(
                "Title",
                "Inserisci nome",
                "OK",
                "Annulla"
            );

            foreach (QuestionBase question in _questions)
            {
                _totalScore += question.Points;
            }

            DateTime now = DateTime.Now;

            string newLine = $"{now},{_nome},{_score}\n";

            if (File.Exists(bestScorePath))
            {
                await File.AppendAllTextAsync(bestScorePath, newLine);
            }
            else
            {
                await File.WriteAllTextAsync(bestScorePath, newLine);
            }

            await Navigation.PushAsync(new ResultPage(_score, _totalScore, _nome));
            }
        }
    }