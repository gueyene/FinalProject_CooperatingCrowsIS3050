<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FinalProject_CooperatingCrowsIS3050.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Final Project Cooperating Crows</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
         <asp:Label ID="lblTitle" runat="server" Text="Welcome to the Cooperating Crows Final Project!"></asp:Label> <br />
         <asp:Label ID="lblparagraph1" runat="server"
            Text="Problem 4, Median of Two Arrays. Given two sorted arrays nums 1 and nums 2 of size m and n respectively, return the median of the two sorted arrays.">
        </asp:Label>
        <br /><br />

        <asp:Label ID="lblArray1" runat="server" Text="Enter Array 1 (comma-separated):"></asp:Label>
        <asp:TextBox ID="txtArray1" runat="server"></asp:TextBox><br /><br />

        <asp:Label ID="lblArray2" runat="server" Text="Enter Array 2 (comma-separated):"></asp:Label>
        <asp:TextBox ID="txtArray2" runat="server"></asp:TextBox><br /><br />

        <asp:Button ID="bnSolveMedianOfTwoArrays" runat="server" Text="Solve" OnClick="bnSolveMedianOfTwoArrays_Click" />
        <br /><br />

        <asp:Label ID="lblSolveMedianOfTwoArraysSolution" runat="server" Font-Bold="true" Text=""></asp:Label>
        </div>

        <asp:Label ID="lblBinaryMatrixFlipper" runat="server" Text="Given a m x n binary matrix mat. In one step, you can choose one cell and flip it and all the four neighbors of it if they exist (Flip is changing 1 to 0 and 0 to 1). A pair of cells are called neighbors if they share one edge. Return the minimum number of steps required to convert mat to a zero matrix or -1 if you cannot. A binary matrix is a matrix with all cells equal to 0 or 1 only. A zero matrix is a matrix with all cells equal to 0."></asp:Label>
        <br />
        <asp:Label ID="lblBinaryMatrixFlipperTestCase1" runat="server" Text="[0 0]"></asp:Label>
        <br />
        <asp:Label ID="lblBinaryMatrixFlipperTestCase2" runat="server" Text="[0 1]"></asp:Label>
        <br />
        <asp:Button ID="bnSolveBinaryMatrixFlipper" runat="server" Text="Solve" OnClick="bnSolveBinaryMatrixFlipper_Click"/>
        <asp:Label ID="lblBinaryMatrixFlipperSolution" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
