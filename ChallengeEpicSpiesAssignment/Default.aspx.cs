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
                startDateCalendar.SelectedDate = prevEndDateCalendar
                    .SelectedDate.AddDays(14);
                endDateCalendar.SelectedDate = startDateCalendar
                    .SelectedDate.AddDays(7);
            }
          
        }

        protected void assignSpyButton_Click(object sender, EventArgs e)
        {
            string codeName = codeNameTextBox.Text;
            string assignmentName = assignmentNameTextBox.Text;

            DateTime availDate = prevEndDateCalendar.SelectedDate;
            DateTime startDate = startDateCalendar.SelectedDate;
            DateTime endDate = endDateCalendar.SelectedDate;

            int restLength = startDate.Subtract(availDate).Days;
            int assignmentLength = endDate.Subtract(startDate).Days;
            int earnings;

            if (restLength < 14)
            {
                resultLabel.Text = "Error: Assignment start date must " +
                    "be at least 14 days from previous assignment end date.";
                startDateCalendar.SelectedDate = availDate.AddDays(14);
                startDateCalendar.VisibleDate = startDateCalendar.SelectedDate;
                endDateCalendar.SelectedDate = startDateCalendar.SelectedDate.AddDays(7);
                endDateCalendar.VisibleDate = endDateCalendar.SelectedDate;
            }
            else if(codeName == "" || assignmentName == "")
            {
                resultLabel.Text = "Error: Please enter a Spy name and Assignment name.";
            }
            else
            {
                if (assignmentLength <= 21)
                {
                    earnings = 500 * assignmentLength;
                }
                else
                {
                    earnings = 500 * assignmentLength + 1000;
                }

                resultLabel.Text = String.Format("Assignment of <i>{0}</i>" +
                    " to the <b>{1}</b> assignment is authorized. Budget" +
                    " total: {2:C}", codeName, assignmentName, earnings);
            }

            


        }
    }
}