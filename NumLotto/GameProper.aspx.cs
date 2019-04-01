using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NumLotto
{
    public partial class GameProper : System.Web.UI.Page
    {
        int min;
        int max;
        int level;
        int attempts;
        int gameOver;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("min") == null || Request.QueryString.Get("max") == null || Request.QueryString.Get("level") == null)
            {
                Response.Redirect("GameOptions.aspx");
            }
            min = int.Parse(Request.QueryString.Get("min"));
            max = int.Parse(Request.QueryString.Get("max"));
            level = int.Parse(Request.QueryString.Get("level"));

            gameOver = int.Parse(Session["gameOver"].ToString());
            attempts = int.Parse(Session["attempts"].ToString());
        }

        protected void GuessNumber(object sender, EventArgs e)
        {
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
                Session["attempts"] = ++attempts;
                CheckResult(int.Parse(txtNumber.Text));
            }

            void ShowMessage(string message)
            {
                lblMessage.Visible = true;
                lblMessage.Text = message;
            }

            void CheckResult(int number)
            {
                int intAnswer = (int)Session["Answer"];
                
                if (number == intAnswer)
                {
                    Session["gameOver"] = 1;
                    ShowMessage("You WON!!");
                    GetPrize();
                }
                else if (number > intAnswer)
                {
                    ShowMessage("Your number is bigger!");
                }
                else
                {
                    ShowMessage("Your number is smaller!");
                }
            }

            void GetPrize()
            {
                string price = "";
                if (level == 1)
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
                else if (level == 2)
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
                else if (level == 3)
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
                ShowMessage("You won " + price + "!");
            }
        }
    }
}