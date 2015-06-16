<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeEpicSpiesAssignment.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            
            height: 190px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <img alt="Epic Spies company logo" class="auto-style1" src="epic-spies-logo.jpg" /><br />
        <br />
        Spy New Assignment Form<br />
        <br />
        Spy Code Name:
        <asp:TextBox ID="codeNameTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        New Assignment Name:
        <asp:TextBox ID="assignmentNameTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        End Date of previous assignment:<br />
        <asp:Calendar ID="prevEndDateCalendar" runat="server"></asp:Calendar>
        <br />
        Start Date of New Assignment:<br />
        <asp:Calendar ID="startDateCalendar" runat="server"></asp:Calendar>
        <br />
        Projected End Date of New Assignment:<br />
        <asp:Calendar ID="endDateCalendar" runat="server"></asp:Calendar>
        <br />
        <asp:Button ID="assignSpyButton" runat="server" OnClick="assignSpyButton_Click" Text="Assign Spy" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
        <br />
        </div>
    </form>
</body>
</html>
