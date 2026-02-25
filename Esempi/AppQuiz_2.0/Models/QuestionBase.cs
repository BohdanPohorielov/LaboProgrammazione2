using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuiz.Models
{
    internal abstract class  QuestionBase
    {
		private string _text;
        private int _points;


		public string Text
		{
			get
			{ 
				return _text;
			}
			set
			{
				_text = value;
			}
		}

	
		public int Points
		{
			get { return _points; }
			set 
			{
				if (_points < 0) 
				{
						_points = 0;
				}
				else
				{
					_points = value;
				}
			}
		}

		private string _hint;

		public string Hint
		{
			get { return _hint; }
			set { _hint = value; }
		}

		public QuestionBase(string text, int points, string hint)
		{
			Text = text;
			Points = points;
            Hint = hint;
        }

        public abstract bool ChechAnswer(bool userAnswer);
	}
}
