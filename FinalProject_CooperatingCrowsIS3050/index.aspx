<!-- Name: CooperatingCrows
# email:
# Assignment Title: Assignment nn
# Due Date:
# Course: IS 3050
# Semester/Year:
# Brief Description: This project ...
# Citations:
# Anything else that's relevant:
    -->



<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FinalProject_CooperatingCrowsIS3050.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <title>Cooporating Crows Final Project</title>
    <link href="index_style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header" style="font-weight: bold; text-align: center;">Welcome to the CooperatingCrows Final Project!</div>

        <asp:DropDownList ID="ddlProblems" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProblems_SelectedIndexChanged">
            <asp:ListItem Text="-- Select a Problem --" Value="" />
            <asp:ListItem Text="Median of Two Sorted Arrays" Value="Median" />
            <asp:ListItem Text="Binary Matrix Flipper" Value="Binary" />
        </asp:DropDownList>

        <br /><br />

        <!-- Problem Details -->
        <asp:Label ID="lblProblemDescription" runat="server" Text=""></asp:Label><br /><br />

        <!-- Input Fields -->
        <asp:Panel ID="pnlMedianInputs" runat="server" Visible="false">
            <asp:Label ID="lblArray1" runat="server" Text="Enter Array 1 (comma-separated):"></asp:Label>
            <asp:TextBox ID="txtArray1" runat="server"></asp:TextBox><br /><br />

            <asp:Label ID="lblArray2" runat="server" Text="Enter Array 2 (comma-separated):"></asp:Label>
            <asp:TextBox ID="txtArray2" runat="server"></asp:TextBox><br /><br />
        </asp:Panel>

        <asp:Button ID="btnSolve" runat="server" Text="Solve" OnClick="btnSolve_Click" Visible="false" />
        <br /><br />

        <asp:Label ID="lblSolution" runat="server" CssClass="output"></asp:Label>
        <br /><br />

        <asp:Label ID="lblCodeExecuted" runat="server" Text="" CssClass="codeOutput"></asp:Label>
            </div>
    </form>
</body>
</html>
