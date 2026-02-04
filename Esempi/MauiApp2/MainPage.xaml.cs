namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        double a, b, c;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!double.TryParse(CefA.Text, out a))
            {
                Result.Text = "Input del A è sbagliato";
                return;
            }
            if (!double.TryParse(CefB.Text, out b))
            {
                Result.Text = "Input del B è sbagliato";
                return;
            }
            if (!double.TryParse(CefC.Text, out c))
            {
                Result.Text = "Input del C è sbagliato";
                return;
            }

            double res = Math.Pow(b, 2) - 4 * a * c;
            Result.Text = res.ToString();
        }
    }
}