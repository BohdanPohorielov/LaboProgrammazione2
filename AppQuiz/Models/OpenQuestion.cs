using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuiz.Models
{
    internal class OpenQuestion : QuestionBase
    {
        private string _correctAnswer;

        public string CorrectAnswer
        {
            get { return _correctAnswer; }
            set { _correctAnswer = value; }
        }

        public OpenQuestion(string text, int points, string correctAnswer, string hint) : base(text, points, hint)
        {
            CorrectAnswer = (correctAnswer).ToLower().Trim();
        }

        public override bool ChechAnswer(string userAnswer)
        {
            return userAnswer.Trim().ToLower() == CorrectAnswer.Trim().ToLower();
        }
    }
}
