using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NumLotto
{
    public partial class Default : System.Web.UI.Page
    {
        //three levels currently: 10 20 50
        public string level;

        public int price;   //money you win
        public int answer { get; set; }
        public int attempts;
        public int gameOver;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                LblMessage.Visible = false;
            }
            else
            {
                answer = int.Parse(GetSessionValue("answer"));
                attempts = int.Parse(GetSessionValue("attempts"));
                gameOver = int.Parse(GetSessionValue("gameOver"));
                level = GetSessionValue("level");
            }

        }

        protected void ClickStart(object sender, EventArgs e)
        {
            //init game parameters
            LblMessage.Visible = false;
            gameOver = 0;
            price = 0;
            Session["attempts"] = 0;
            Session["answer"] = 0;
            Session["level"] = 0;
            Session["gameOver"] = 0;

            level = RadioButtonList.SelectedValue;
            if ((level != null) && (level != ""))
            {
                Session["level"] = level;
                Session["answer"] = GenerateAnswer(int.Parse(level));
                ShowMessage("Game starts!" + Session["answer"]);
            }
            else
            {
                ShowMessage("Please select your level first!!");
            }
        }

        protected void ClickGuess(object sender, EventArgs e)
        {
            if (answer < 0)
            {
                ShowMessage("Please start the game first!");
                return;
            }

            if (gameOver == 1)
            {
                ShowMessage("Game over, please restart!");
            }
            else if (attempts == 3)
            {
                gameOver = 1;
                ShowMessage("Three times limited, please start again!");
            }
            else
            {
                attempts++;
                Session["attempts"] = attempts;
                CheckResult(int.Parse(TxtNumber.Text));
            }
        }

        private string GetSessionValue(string str)
        {
            if (Session[str] != null)
            {
                return Session[str].ToString();
            }
            else
            {
                return "-1";
            }
        }

        private int GenerateAnswer(int level)
        {
            return new Random().Next(level);
        }

        private void CheckResult(int number)
        {
            int intAnswer = (int)Session["Answer"];
            if (number == intAnswer)
            {
                Session["gameOver"] = 1;
                ShowMessage("WON!!");
                GetPrice();
            }
            else if (number > intAnswer)
            {
                ShowMessage("Your number is bigger!");
            }
            else
            {
                LblMessage.Text = "Your number is smaller!";
            }
        }

        private void GetPrice()
        {
            string price = "";
            if (level == "10")
            {
                if (attempts == 1)
                {
                    price = "10";
                }
                else if (attempts == 2)
                {
                    price = "5";
                }
                else
                {
                    price = "2";
                }
            }
            else if (level == "20")
            {
                if (attempts == 1)
                {
                    price = "50";
                }
                else if (attempts == 2)
                {
                    price = "20";
                }
                else
                {
                    price = "10";
                }
            }
            else if (level == "50")
            {
                if (attempts == 1)
                {
                    price = "100";
                }
                else if (attempts == 2)
                {
                    price = "50";
                }
                else
                {
                    price = "20";
                }
            }
            else
            {
                price = "x";
            }
            LblPrice.Text = "" + price;
        }

        private void ShowMessage(string message)
        {
            LblMessage.Visible = true;
            LblMessage.Text = message;
        }
    }
}
