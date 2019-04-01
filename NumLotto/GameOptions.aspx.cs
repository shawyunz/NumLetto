using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NumLotto
{
    public partial class GameOptions : System.Web.UI.Page
    {
        int min = 1;
        int max;
        int level;
        int gameOver;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
        }

        protected void StartGame(object sender, EventArgs e)
        {
            gameOver = 0;
            Session["attempts"] = 0;
            Session["answer"] = 0;
            Session["gameOver"] = 0;
            Session["level"] = level;
            Session["answer"] = GenerateAnswer();

            Response.Redirect(string.Format("GameProper.aspx?min={0}&max={1}&level={2}", min, max, level));
        }

        private int GenerateAnswer()
        {
            Random random = new Random();
            int randomNumber = random.Next(min, max);
            System.Diagnostics.Debug.WriteLine("random generated number: " + randomNumber);
            return randomNumber;
        }

        protected void radioButtonOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            max = min;
            if (radioButtonOptions.SelectedIndex == 0)
            {
                max = 10;
                level = 1;
            }
            else if (radioButtonOptions.SelectedIndex == 1)
            {
                max = 20;
                level = 2;
            }
            else
            {
                max = 50;
                level = 3;
            }
        }
    }
}