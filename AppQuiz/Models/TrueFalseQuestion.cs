using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuiz.Models
{
    internal class TrueFalseQuestion : QuestionBase
    {
		private string _correctAnswer;

		public string CorrectAnswer
		{
			get { return _correctAnswer; }
			set { _correctAnswer = value; }
		}

		public TrueFalseQuestion(string text, int points, string correctAnswer, string hint) : base(text,points,hint) { 
			CorrectAnswer = correctAnswer;
		}

        public override bool ChechAnswer(string userAnswer)
        {
			return userAnswer == CorrectAnswer;
        }
    }
}
