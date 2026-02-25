using AppQuiz.Models;

namespace AppQuiz
{
    public partial class MainPage : ContentPage
    {
        private List<QuestionBase> _questions = new List<QuestionBase>();
        private int _currentIndex = 0;
        private int _score;

        public MainPage()
        {
            InitializeComponent();
            _questions.Add(new TrueFalseQuestion("Il C# è un linguaggio a oggetti?", 10, true,"!no"));
            _questions.Add(new TrueFalseQuestion("Python è un lingiaggio compilato?", 10, false, "!si"));
            ShowQuestion();
        }

        private void OnAnswer_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            bool userAnswer = bool.Parse(btn.CommandParameter.ToString());

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

        private void ShowQuestion()
        {
            if (_currentIndex < _questions.Count)
            {
                QuestionBase current = _questions[_currentIndex];
                QuestionTextLabel.Text = current.Text;
                ScoreLabel.Text = _score.ToString();
            }
            else {
                ScoreLabel.Text = _score.ToString();
                QuestionTextLabel.Text = "Finito";
                DomandaLabel.Text = "";
                btnResult.SetValue(IsVisibleProperty, true);
            }
        }

        private void btnResult_Clicked(object sender, EventArgs e) {
            OnQuizFinished();
        }

        private void Resetbtn_Clicked(object sender, EventArgs e)
        {
            _currentIndex = 0;
            _score = 0;
            btnResult.SetValue(IsVisibleProperty, false);
            ShowQuestion();
        }

        private async void OnQuizFinished() {
            await Navigation.PushAsync(new ResultPage(_score));
        }
    }
}
