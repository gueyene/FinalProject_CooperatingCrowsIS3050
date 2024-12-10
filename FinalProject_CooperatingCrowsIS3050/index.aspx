<!-- Name: CooperatingCrows
# email: gauthiaj@mail.uc.edu
# Assignment Title: Final Project
# Due Date:12/10/2024
# Course: IS 3050
# Semester/Year: Fall 2024
# Brief Description: This project creates a landing page that allows you to select a leet code problem to look at and see the solution and code relating to it 
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
            <asp:ListItem Text="Longest Valid Parentheses" Value="Parentheses" />
        </asp:DropDownList>

        <br /><br />

        <!-- Problem Details -->
        <asp:Label ID="lblProblemDescription" runat="server" Text=""></asp:Label><br /><br />

        <!-- Median Problem Inputs -->
        <asp:Panel ID="pnlMedianInputs" runat="server" Visible="false">
            <asp:Label ID="lblArray1" runat="server" Text="Enter Array 1 (comma-separated):"></asp:Label>
            <asp:TextBox ID="txtArray1" runat="server"></asp:TextBox><br /><br />

            <asp:Label ID="lblArray2" runat="server" Text="Enter Array 2 (comma-separated):"></asp:Label>
            <asp:TextBox ID="txtArray2" runat="server"></asp:TextBox><br /><br />
        </asp:Panel>

        <!-- Longest Valid Parentheses Inputs -->
        <asp:Panel ID="pnlSingleInput" runat="server" Visible="false">
            <asp:Label ID="lblInput" runat="server" Text="Enter a string of parentheses:"></asp:Label>
            <asp:TextBox ID="txtInput" runat="server"></asp:TextBox><br /><br />
        </asp:Panel>

        <!-- Solve Button -->
        <asp:Button ID="btnSolve" runat="server" Text="Solve" OnClick="btnSolve_Click" Visible="false" />
        <br /><br />

        <!-- Solution Output -->
       <asp:Label ID="lblSolution" runat="server" CssClass="output"></asp:Label><br />
       <asp:Label ID="lblCodeExecuted" runat="server" CssClass="codeOutput" TextMode="MultiLine" Style=" display: block; margin-top: 15px; padding: 10px; font-size: 16px; color: #444; background-color: #f4f4f4; border: 1px solid #ccc; white-space: pre-line;"></asp:Label>
            </div>
    </form>
</body>
</html>
