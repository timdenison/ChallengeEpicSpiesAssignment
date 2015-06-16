using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssignment
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                prevEndDateCalendar.SelectedDate = DateTime.Now.Date;
                startDateCalendar.SelectedDate = DateTime.Now.Date.AddDays(14);
                endDateCalendar.SelectedDate = DateTime.Now.Date.AddDays(21);

            }
          
        }

        protected void assignSpyButton_Click(object sender, EventArgs e)
        {
            //handles for easier coding later
            string codeName = codeNameTextBox.Text;
            string assignmentName = assignmentNameTextBox.Text;

            DateTime availDate = prevEndDateCalendar.SelectedDate;
            DateTime startDate = startDateCalendar.SelectedDate;
            DateTime endDate = endDateCalendar.SelectedDate;

            //calculate time between assignments (restlength) and
            //length of assignment. Declare an earnings variable.
            int restLength = startDate.Subtract(availDate).Days;
            int assignmentLength = endDate.Subtract(startDate).Days;
            double earnings;

            //Spy needs at least two weeks off
            if (restLength < 14)
            {
                resultLabel.Text = "Error: Assignment start date must " +
                    "be at least 14 days from previous assignment end date.";

                //after click reset startDate Cal to 14 days after current
                //selected available date
                startDateCalendar.SelectedDate = availDate.AddDays(14);
                //redraw startDate Calendar to include selected date
                startDateCalendar.VisibleDate = startDateCalendar.SelectedDate;
                //reset endDate Cal selected date to be 7 days after new
                //startDate selection.
                endDateCalendar.SelectedDate = startDateCalendar.SelectedDate.AddDays(7);
                //redraw endDate calendar to view the new selection
                endDateCalendar.VisibleDate = endDateCalendar.SelectedDate;
            }
            //Must have a spy name and assignment name
            else if(codeName == "" || assignmentName == "")
            {
                resultLabel.Text = "Error: Please enter a Spy name and Assignment name.";
            }
            else
            {   
                // base rate is 500 dollars a day
                if (assignmentLength <= 21)
                {
                    earnings = 500 * assignmentLength;
                }
                // extra pay for long assignments
                else
                {
                    earnings = 500 * assignmentLength + 1000;
                }
                //print success message.
                resultLabel.Text = String.Format("Assignment of <i>{0}</i>" +
                    " to the <b>{1}</b> assignment is authorized. Budget" +
                    " total: {2:C}", codeName, assignmentName, earnings);
            }

            


        }
    }
}