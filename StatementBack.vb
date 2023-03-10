Imports GrapeCity.ActiveReports
Imports System.Drawing
Imports System.IO

Public Class StatementBack
    Inherits SectionReport
    Dim g_totalpages As Integer
    Dim g_addpages As New ArrayList
    Dim g_page As Integer = 1
    Public iStatementTotalPages As Integer = 2

    Dim iLICount As Integer = 0
    Public iTotalLICount As Integer
    Public g_watermark As Boolean = False

    Public g_Bre As String

    Public bTexas As Boolean = False

    Dim iDetailCount As Integer = 0
    Dim TheStatementID As String = ""
    Private WithEvents GroupHeader1 As SectionReportModel.GroupHeader
    Private WithEvents GroupFooter1 As SectionReportModel.GroupFooter
    Private WithEvents txtPageNumber As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Shape1 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape2 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Shape3 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Label2 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape4 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Shape5 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Line1 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line2 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line3 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line4 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line5 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line6 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line7 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line8 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line9 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line10 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Label4 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label5 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label6 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label7 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label8 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label9 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label10 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label11 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label12 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label13 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label14 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label15 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label16 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label17 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label18 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape6 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Shape7 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Shape8 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Shape9 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Shape10 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Label19 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label20 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label21 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label22 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label23 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label24 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label25 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label26 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label27 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label28 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label29 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label30 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label31 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label32 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label33 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label34 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label35 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label36 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label37 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label38 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label39 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label40 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label41 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Line11 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents TextBox1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtBillQuestions As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtCallUs As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPhoneNum As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents shpChargesSummary As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents txtChargesSummary As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents shpliheader As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblLI1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblLI2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblli5 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblli4 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lblli3 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtccol1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtccol2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtccol5 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtccol4 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtccol3 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Public iStatementCount As Integer = 0

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub



#Region "ActiveReports Designer generated code"


























    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(StatementBack))
        Dim SqlDBDataSource1 As GrapeCity.ActiveReports.Data.SqlDBDataSource = New GrapeCity.ActiveReports.Data.SqlDBDataSource()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.txtFooterStatementID = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPageNumber = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.InserterHeader = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.txtboxBCD = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPgNum = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPgCount = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.InserterBarcode = New GrapeCity.ActiveReports.SectionReportModel.Barcode()
        Me.InserterFooter = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.GroupHeader1 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.shpChargesSummary = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.txtChargesSummary = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtBillQuestions = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtCallUs = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPhoneNum = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupFooter1 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.Shape1 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Shape2 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Shape3 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label2 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Shape4 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Shape5 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Line1 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line2 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line3 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line4 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line5 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line6 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line7 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line8 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line9 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line10 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Label4 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label5 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label6 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label7 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label8 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label9 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label10 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label11 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label12 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label13 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label14 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label15 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label16 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label17 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label18 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Shape6 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Shape7 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Shape8 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Shape9 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Shape10 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Label19 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label20 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label21 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label22 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label23 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label24 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label25 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label26 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label27 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label28 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label29 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label30 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label31 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label32 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label33 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label34 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label35 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label36 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label37 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label38 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label39 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label40 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label41 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Line11 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.shpliheader = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblLI1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.lblLI2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.lblli5 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.lblli4 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.lblli3 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtccol1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtccol2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtccol5 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtccol4 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtccol3 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        CType(Me.txtFooterStatementID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPageNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtboxBCD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPgNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPgCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChargesSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBillQuestions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCallUs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhoneNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblLI1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblLI2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblli5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblli4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblli3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtccol1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtccol2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtccol5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtccol4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtccol3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.CanShrink = True
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtccol1, Me.txtccol2, Me.txtccol5, Me.txtccol4, Me.txtccol3})
        Me.Detail.Height = 0.201!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        Me.Detail.Visible = False
        '
        'PageHeader
        '
        Me.PageHeader.Height = 0.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtFooterStatementID, Me.txtPageNumber})
        Me.PageFooter.Name = "PageFooter"
        '
        'txtFooterStatementID
        '
        Me.txtFooterStatementID.DataField = "istatementid"
        Me.txtFooterStatementID.Height = 0.1!
        Me.txtFooterStatementID.Left = 0.313!
        Me.txtFooterStatementID.Name = "txtFooterStatementID"
        Me.txtFooterStatementID.Style = "color: Black; font-family: Courier New; font-size: 6pt; ddo-char-set: 1"
        Me.txtFooterStatementID.Text = "istatementid"
        Me.txtFooterStatementID.Top = 0.0!
        Me.txtFooterStatementID.Width = 2.0!
        '
        'txtPageNumber
        '
        Me.txtPageNumber.Height = 0.2!
        Me.txtPageNumber.Left = 7.002!
        Me.txtPageNumber.Name = "txtPageNumber"
        Me.txtPageNumber.Style = "color: Gray; font-family: Arial; font-size: 8pt; font-weight: bold; vertical-alig" & _
    "n: middle; ddo-char-set: 1"
        Me.txtPageNumber.Text = "Page 1 of 2"
        Me.txtPageNumber.Top = 0.0!
        Me.txtPageNumber.Width = 1.039001!
        '
        'InserterHeader
        '
        Me.InserterHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txtboxBCD, Me.txtPgNum, Me.txtPgCount, Me.InserterBarcode})
        Me.InserterHeader.Height = 4.0!
        Me.InserterHeader.Name = "InserterHeader"
        Me.InserterHeader.RepeatStyle = GrapeCity.ActiveReports.SectionReportModel.RepeatStyle.OnPageIncludeNoDetail
        Me.InserterHeader.UnderlayNext = True
        Me.InserterHeader.Visible = False
        '
        'txtboxBCD
        '
        Me.txtboxBCD.Height = 0.1875!
        Me.txtboxBCD.Left = 6.125!
        Me.txtboxBCD.Name = "txtboxBCD"
        Me.txtboxBCD.Text = "Barcodedata"
        Me.txtboxBCD.Top = 3.75!
        Me.txtboxBCD.Visible = False
        Me.txtboxBCD.Width = 2.120001!
        '
        'txtPgNum
        '
        Me.txtPgNum.Height = 0.2!
        Me.txtPgNum.Left = 7.0!
        Me.txtPgNum.Name = "txtPgNum"
        Me.txtPgNum.SummaryGroup = "GroupHeader1"
        Me.txtPgNum.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.txtPgNum.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.txtPgNum.Text = "txtPgNum"
        Me.txtPgNum.Top = 2.375!
        Me.txtPgNum.Visible = False
        Me.txtPgNum.Width = 1.0!
        '
        'txtPgCount
        '
        Me.txtPgCount.Height = 0.2!
        Me.txtPgCount.Left = 7.0!
        Me.txtPgCount.Name = "txtPgCount"
        Me.txtPgCount.SummaryGroup = "GroupHeader1"
        Me.txtPgCount.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.txtPgCount.Text = "txtPgCount"
        Me.txtPgCount.Top = 2.6875!
        Me.txtPgCount.Visible = False
        Me.txtPgCount.Width = 1.0!
        '
        'InserterBarcode
        '
        Me.InserterBarcode.Font = New System.Drawing.Font("Courier New", 8.0!)
        Me.InserterBarcode.Height = 1.5!
        Me.InserterBarcode.Left = 8.313!
        Me.InserterBarcode.Name = "InserterBarcode"
        Me.InserterBarcode.NarrowBarWidth = 1.0!
        Me.InserterBarcode.QuietZoneBottom = 0.0!
        Me.InserterBarcode.QuietZoneLeft = 0.0!
        Me.InserterBarcode.QuietZoneRight = 0.0!
        Me.InserterBarcode.QuietZoneTop = 0.0!
        Me.InserterBarcode.Rotation = GrapeCity.ActiveReports.SectionReportModel.Rotation.Rotate90Degrees
        Me.InserterBarcode.Style = GrapeCity.ActiveReports.SectionReportModel.BarCodeStyle.Code25intlv
        Me.InserterBarcode.Text = "InserterBarcode"
        Me.InserterBarcode.Top = 2.25!
        Me.InserterBarcode.Width = 0.1!
        '
        'InserterFooter
        '
        Me.InserterFooter.Height = 0.0!
        Me.InserterFooter.Name = "InserterFooter"
        Me.InserterFooter.Visible = False
        '
        'GroupHeader1
        '
        Me.GroupHeader1.CanShrink = True
        Me.GroupHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.shpChargesSummary, Me.txtChargesSummary, Me.TextBox1, Me.txtBillQuestions, Me.txtCallUs, Me.txtPhoneNum, Me.shpliheader, Me.lblLI1, Me.lblLI2, Me.lblli5, Me.lblli4, Me.lblli3})
        Me.GroupHeader1.DataField = "istatementid"
        Me.GroupHeader1.Height = 1.537001!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'shpChargesSummary
        '
        Me.shpChargesSummary.BackColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.shpChargesSummary.Height = 0.25!
        Me.shpChargesSummary.Left = 0.22!
        Me.shpChargesSummary.LineColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.shpChargesSummary.Name = "shpChargesSummary"
        Me.shpChargesSummary.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.shpChargesSummary.Top = 0.923!
        Me.shpChargesSummary.Visible = False
        Me.shpChargesSummary.Width = 1.25!
        '
        'txtChargesSummary
        '
        Me.txtChargesSummary.Height = 0.25!
        Me.txtChargesSummary.Left = 0.22!
        Me.txtChargesSummary.Name = "txtChargesSummary"
        Me.txtChargesSummary.Style = "color: White; font-family: Arial; font-size: 8pt; font-weight: bold; text-align: " & _
    "center; vertical-align: middle; ddo-char-set: 1"
        Me.txtChargesSummary.Text = "CHARGES SUMMARY"
        Me.txtChargesSummary.Top = 0.923!
        Me.txtChargesSummary.Visible = False
        Me.txtChargesSummary.Width = 1.25!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 0.1470001!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "color: #22B736; font-family: Arial; font-size: 12pt; font-weight: bold; ddo-char-" & _
    "set: 1"
        Me.TextBox1.Text = "THIS IS A MEDICAL BILL"
        Me.TextBox1.Top = 0.251!
        Me.TextBox1.Visible = False
        Me.TextBox1.Width = 2.115!
        '
        'txtBillQuestions
        '
        Me.txtBillQuestions.Height = 0.2!
        Me.txtBillQuestions.Left = 0.1440001!
        Me.txtBillQuestions.Name = "txtBillQuestions"
        Me.txtBillQuestions.Style = "color: Gray; font-family: Arial; font-size: 11pt; font-weight: normal; ddo-char-s" & _
    "et: 1"
        Me.txtBillQuestions.Text = "Have questions about your bill?"
        Me.txtBillQuestions.Top = 0.451!
        Me.txtBillQuestions.Visible = False
        Me.txtBillQuestions.Width = 2.511!
        '
        'txtCallUs
        '
        Me.txtCallUs.Height = 0.2!
        Me.txtCallUs.Left = 0.1440001!
        Me.txtCallUs.Name = "txtCallUs"
        Me.txtCallUs.Style = "color: Gray; font-family: Arial; font-size: 11pt; font-weight: normal; ddo-char-s" & _
    "et: 1"
        Me.txtCallUs.Text = "Call us:"
        Me.txtCallUs.Top = 0.6509999!
        Me.txtCallUs.Visible = False
        Me.txtCallUs.Width = 0.541!
        '
        'txtPhoneNum
        '
        Me.txtPhoneNum.DataField = "ccustom1"
        Me.txtPhoneNum.Height = 0.2!
        Me.txtPhoneNum.Left = 0.6850002!
        Me.txtPhoneNum.Name = "txtPhoneNum"
        Me.txtPhoneNum.Style = "color: Black; font-family: Arial; font-size: 11pt; font-weight: normal; ddo-char-" & _
    "set: 1"
        Me.txtPhoneNum.Text = "248-644-8060"
        Me.txtPhoneNum.Top = 0.6509999!
        Me.txtPhoneNum.Visible = False
        Me.txtPhoneNum.Width = 1.574!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape1, Me.Label1, Me.Shape2, Me.Shape3, Me.Label2, Me.Label3, Me.Shape4, Me.Shape5, Me.Line1, Me.Line2, Me.Line3, Me.Line4, Me.Line5, Me.Line6, Me.Line7, Me.Line8, Me.Line9, Me.Line10, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.Label14, Me.Label15, Me.Label16, Me.Label17, Me.Label18, Me.Shape6, Me.Shape7, Me.Shape8, Me.Shape9, Me.Shape10, Me.Label19, Me.Label20, Me.Label21, Me.Label22, Me.Label23, Me.Label24, Me.Label25, Me.Label26, Me.Label27, Me.Label28, Me.Label29, Me.Label30, Me.Label31, Me.Label32, Me.Label33, Me.Label34, Me.Label35, Me.Label36, Me.Label37, Me.Label38, Me.Label39, Me.Label40, Me.Label41, Me.Line11})
        Me.GroupFooter1.Height = 3.521!
        Me.GroupFooter1.KeepTogether = True
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.After
        Me.GroupFooter1.PrintAtBottom = True
        '
        'Shape1
        '
        Me.Shape1.Height = 0.2!
        Me.Shape1.Left = 0.5!
        Me.Shape1.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(30.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape1.Top = 0.0!
        Me.Shape1.Width = 7.5!
        '
        'Label1
        '
        Me.Label1.Height = 0.1875!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.813!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: Gray; text-align: center"
        Me.Label1.Text = "IF ANY OF THE FOLLOWING HAS CHANGED SINCE YOUR LAST STATEMENT, PLEASE INDICATE..." & _
    ""
        Me.Label1.Top = 0.01750004!
        Me.Label1.Width = 6.875!
        '
        'Shape2
        '
        Me.Shape2.Height = 0.2!
        Me.Shape2.Left = 0.3125!
        Me.Shape2.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(30.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape2.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape2.Top = 0.2291669!
        Me.Shape2.Width = 1.3125!
        '
        'Shape3
        '
        Me.Shape3.Height = 0.2!
        Me.Shape3.Left = 4.0625!
        Me.Shape3.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Shape3.Name = "Shape3"
        Me.Shape3.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(30.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape3.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape3.Top = 0.2291669!
        Me.Shape3.Width = 2.483333!
        '
        'Label2
        '
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.375!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "color: Gray; text-align: center"
        Me.Label2.Text = "ABOUT YOU:"
        Me.Label2.Top = 0.2358334!
        Me.Label2.Width = 1.1875!
        '
        'Label3
        '
        Me.Label3.Height = 0.1875!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 4.125!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "color: Gray; text-align: center"
        Me.Label3.Text = "ABOUT YOUR INSURANCE:"
        Me.Label3.Top = 0.2358334!
        Me.Label3.Width = 2.375!
        '
        'Shape4
        '
        Me.Shape4.Height = 2.625!
        Me.Shape4.Left = 0.3125!
        Me.Shape4.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Shape4.Name = "Shape4"
        Me.Shape4.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(5.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape4.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape4.Top = 0.4583335!
        Me.Shape4.Width = 3.5625!
        '
        'Shape5
        '
        Me.Shape5.Height = 3.0625!
        Me.Shape5.Left = 4.0625!
        Me.Shape5.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Shape5.Name = "Shape5"
        Me.Shape5.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(5.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape5.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect
        Me.Shape5.Top = 0.4583335!
        Me.Shape5.Width = 4.125!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.3125!
        Me.Line1.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.8958328!
        Me.Line1.Width = 3.5625!
        Me.Line1.X1 = 0.3125!
        Me.Line1.X2 = 3.875!
        Me.Line1.Y1 = 0.8958328!
        Me.Line1.Y2 = 0.8958328!
        '
        'Line2
        '
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 0.3125!
        Me.Line2.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 1.333333!
        Me.Line2.Width = 3.5625!
        Me.Line2.X1 = 0.3125!
        Me.Line2.X2 = 3.875!
        Me.Line2.Y1 = 1.333333!
        Me.Line2.Y2 = 1.333333!
        '
        'Line3
        '
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 0.3125!
        Me.Line3.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 1.770834!
        Me.Line3.Width = 3.5625!
        Me.Line3.X1 = 0.3125!
        Me.Line3.X2 = 3.875!
        Me.Line3.Y1 = 1.770834!
        Me.Line3.Y2 = 1.770834!
        '
        'Line4
        '
        Me.Line4.Height = 0.0!
        Me.Line4.Left = 0.3125!
        Me.Line4.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 2.208333!
        Me.Line4.Width = 3.5625!
        Me.Line4.X1 = 0.3125!
        Me.Line4.X2 = 3.875!
        Me.Line4.Y1 = 2.208333!
        Me.Line4.Y2 = 2.208333!
        '
        'Line5
        '
        Me.Line5.Height = 0.0!
        Me.Line5.Left = 0.3125!
        Me.Line5.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 2.645833!
        Me.Line5.Width = 3.5625!
        Me.Line5.X1 = 0.3125!
        Me.Line5.X2 = 3.875!
        Me.Line5.Y1 = 2.645833!
        Me.Line5.Y2 = 2.645833!
        '
        'Line6
        '
        Me.Line6.Height = 0.0!
        Me.Line6.Left = 4.0625!
        Me.Line6.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 2.645833!
        Me.Line6.Width = 4.125!
        Me.Line6.X1 = 4.0625!
        Me.Line6.X2 = 8.1875!
        Me.Line6.Y1 = 2.645833!
        Me.Line6.Y2 = 2.645833!
        '
        'Line7
        '
        Me.Line7.Height = 0.0!
        Me.Line7.Left = 4.0625!
        Me.Line7.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line7.LineWeight = 1.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 2.208333!
        Me.Line7.Width = 4.125!
        Me.Line7.X1 = 4.0625!
        Me.Line7.X2 = 8.1875!
        Me.Line7.Y1 = 2.208333!
        Me.Line7.Y2 = 2.208333!
        '
        'Line8
        '
        Me.Line8.Height = 0.0!
        Me.Line8.Left = 4.0625!
        Me.Line8.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 1.770834!
        Me.Line8.Width = 4.125!
        Me.Line8.X1 = 4.0625!
        Me.Line8.X2 = 8.1875!
        Me.Line8.Y1 = 1.770834!
        Me.Line8.Y2 = 1.770834!
        '
        'Line9
        '
        Me.Line9.Height = 0.0!
        Me.Line9.Left = 4.0625!
        Me.Line9.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 1.333333!
        Me.Line9.Width = 4.125!
        Me.Line9.X1 = 4.0625!
        Me.Line9.X2 = 8.1875!
        Me.Line9.Y1 = 1.333333!
        Me.Line9.Y2 = 1.333333!
        '
        'Line10
        '
        Me.Line10.Height = 0.0!
        Me.Line10.Left = 4.0625!
        Me.Line10.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 0.8958328!
        Me.Line10.Width = 4.125!
        Me.Line10.X1 = 4.0625!
        Me.Line10.X2 = 8.1875!
        Me.Line10.Y1 = 0.8958328!
        Me.Line10.Y2 = 0.8958328!
        '
        'Label4
        '
        Me.Label4.Height = 0.15!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.375!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "color: Gray; font-size: 7pt"
        Me.Label4.Text = "YOUR NAME (Last, First, Middle Initial)"
        Me.Label4.Top = 0.4583335!
        Me.Label4.Width = 2.438!
        '
        'Label5
        '
        Me.Label5.Height = 0.15!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.375!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "color: Gray; font-size: 7pt"
        Me.Label5.Text = "ADDRESS"
        Me.Label5.Top = 0.8958328!
        Me.Label5.Width = 0.8880014!
        '
        'Label6
        '
        Me.Label6.Height = 0.125!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.375!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "color: Gray; font-size: 7pt"
        Me.Label6.Text = "CITY"
        Me.Label6.Top = 1.333333!
        Me.Label6.Width = 0.375!
        '
        'Label7
        '
        Me.Label7.Height = 0.125!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 2.1875!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "color: Gray; font-size: 7pt"
        Me.Label7.Text = "MARITAL STATUS"
        Me.Label7.Top = 1.770834!
        Me.Label7.Width = 0.875!
        '
        'Label8
        '
        Me.Label8.Height = 0.125!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.375!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "color: Gray; font-size: 7pt"
        Me.Label8.Text = "EMPLOYER'S NAME"
        Me.Label8.Top = 2.208333!
        Me.Label8.Width = 1.0625!
        '
        'Label9
        '
        Me.Label9.Height = 0.125!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.375!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "color: Gray; font-size: 7pt"
        Me.Label9.Text = "EMPLOYER'S ADDRESS"
        Me.Label9.Top = 2.645833!
        Me.Label9.Width = 1.375!
        '
        'Label10
        '
        Me.Label10.Height = 0.125!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 2.0!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "color: Gray; font-size: 7pt"
        Me.Label10.Text = "CITY"
        Me.Label10.Top = 2.645833!
        Me.Label10.Width = 0.375!
        '
        'Label11
        '
        Me.Label11.Height = 0.125!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 2.75!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "color: Gray; font-size: 7pt"
        Me.Label11.Text = "STATE"
        Me.Label11.Top = 2.645833!
        Me.Label11.Width = 0.375!
        '
        'Label12
        '
        Me.Label12.Height = 0.125!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 3.3125!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "color: Gray; font-size: 7pt"
        Me.Label12.Text = "ZIP"
        Me.Label12.Top = 2.645833!
        Me.Label12.Width = 0.25!
        '
        'Label13
        '
        Me.Label13.Height = 0.125!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 2.875!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "color: Gray; font-size: 7pt"
        Me.Label13.Text = "TELEPHONE"
        Me.Label13.Top = 2.208333!
        Me.Label13.Width = 0.6875!
        '
        'Label14
        '
        Me.Label14.Height = 0.1875!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 2.375!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "color: Gray; font-size: 10pt"
        Me.Label14.Text = "(        )"
        Me.Label14.Top = 2.458333!
        Me.Label14.Width = 0.75!
        '
        'Label15
        '
        Me.Label15.Height = 0.1875!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 0.375!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "color: Gray; font-size: 10pt"
        Me.Label15.Text = "(        )"
        Me.Label15.Top = 2.020833!
        Me.Label15.Width = 0.75!
        '
        'Label16
        '
        Me.Label16.Height = 0.125!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 0.375!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "color: Gray; font-size: 7pt"
        Me.Label16.Text = "TELEPHONE"
        Me.Label16.Top = 1.770834!
        Me.Label16.Width = 0.6875!
        '
        'Label17
        '
        Me.Label17.Height = 0.125!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 3.1875!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "color: Gray; font-size: 7pt"
        Me.Label17.Text = "ZIP"
        Me.Label17.Top = 1.333333!
        Me.Label17.Width = 0.25!
        '
        'Label18
        '
        Me.Label18.Height = 0.125!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 2.5625!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "color: Gray; font-size: 7pt"
        Me.Label18.Text = "STATE"
        Me.Label18.Top = 1.333333!
        Me.Label18.Width = 0.375!
        '
        'Shape6
        '
        Me.Shape6.Height = 0.06!
        Me.Shape6.Left = 2.25!
        Me.Shape6.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Shape6.Name = "Shape6"
        Me.Shape6.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(9.999999!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape6.Top = 1.958334!
        Me.Shape6.Width = 0.06!
        '
        'Shape7
        '
        Me.Shape7.Height = 0.06!
        Me.Shape7.Left = 2.25!
        Me.Shape7.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Shape7.Name = "Shape7"
        Me.Shape7.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(9.999999!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape7.Top = 2.083333!
        Me.Shape7.Width = 0.06!
        '
        'Shape8
        '
        Me.Shape8.Height = 0.06!
        Me.Shape8.Left = 3.1875!
        Me.Shape8.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Shape8.Name = "Shape8"
        Me.Shape8.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(9.999999!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape8.Top = 1.833335!
        Me.Shape8.Width = 0.06!
        '
        'Shape9
        '
        Me.Shape9.Height = 0.06!
        Me.Shape9.Left = 3.1875!
        Me.Shape9.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Shape9.Name = "Shape9"
        Me.Shape9.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(9.999999!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape9.Top = 1.958334!
        Me.Shape9.Width = 0.06!
        '
        'Shape10
        '
        Me.Shape10.Height = 0.06!
        Me.Shape10.Left = 3.1875!
        Me.Shape10.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Shape10.Name = "Shape10"
        Me.Shape10.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(9.999999!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape10.Top = 2.083333!
        Me.Shape10.Width = 0.06!
        '
        'Label19
        '
        Me.Label19.Height = 0.125!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 2.375!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "color: Gray; font-size: 6pt"
        Me.Label19.Text = "Single"
        Me.Label19.Top = 1.933334!
        Me.Label19.Width = 0.5!
        '
        'Label20
        '
        Me.Label20.Height = 0.125!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 2.375!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "color: Gray; font-size: 6pt"
        Me.Label20.Text = "Married"
        Me.Label20.Top = 2.066666!
        Me.Label20.Width = 0.5!
        '
        'Label21
        '
        Me.Label21.Height = 0.125!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 3.3125!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "color: Gray; font-size: 6pt"
        Me.Label21.Text = "Separated"
        Me.Label21.Top = 1.800002!
        Me.Label21.Width = 0.5!
        '
        'Label22
        '
        Me.Label22.Height = 0.125!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 3.3125!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "color: Gray; font-size: 6pt"
        Me.Label22.Text = "Divorced"
        Me.Label22.Top = 1.933334!
        Me.Label22.Width = 0.5!
        '
        'Label23
        '
        Me.Label23.Height = 0.125!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 3.3125!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "color: Gray; font-size: 6pt"
        Me.Label23.Text = "Widowed"
        Me.Label23.Top = 2.066666!
        Me.Label23.Width = 0.5!
        '
        'Label24
        '
        Me.Label24.Height = 0.15!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 4.125!
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "color: Gray; font-size: 7pt"
        Me.Label24.Text = "YOUR PRIMARY INSURANCE COMPANY'S NAME"
        Me.Label24.Top = 0.4583335!
        Me.Label24.Width = 2.438!
        '
        'Label25
        '
        Me.Label25.Height = 0.15!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 4.125!
        Me.Label25.Name = "Label25"
        Me.Label25.Style = "color: Gray; font-size: 7pt"
        Me.Label25.Text = "PRIMARY INSURANCE COMPANY'S ADDRESS"
        Me.Label25.Top = 0.8958328!
        Me.Label25.Width = 2.438!
        '
        'Label26
        '
        Me.Label26.Height = 0.125!
        Me.Label26.HyperLink = Nothing
        Me.Label26.Left = 6.6875!
        Me.Label26.Name = "Label26"
        Me.Label26.Style = "color: Gray; font-size: 7pt"
        Me.Label26.Text = "GROUP PLAN NUMBER"
        Me.Label26.Top = 1.770834!
        Me.Label26.Width = 1.375!
        '
        'Label27
        '
        Me.Label27.Height = 0.15!
        Me.Label27.HyperLink = Nothing
        Me.Label27.Left = 4.125!
        Me.Label27.Name = "Label27"
        Me.Label27.Style = "color: Gray; font-size: 7pt"
        Me.Label27.Text = "POLICYHOLDER'S ID NUMBER"
        Me.Label27.Top = 1.770834!
        Me.Label27.Width = 2.438!
        '
        'Label28
        '
        Me.Label28.Height = 0.125!
        Me.Label28.HyperLink = Nothing
        Me.Label28.Left = 4.125!
        Me.Label28.Name = "Label28"
        Me.Label28.Style = "color: Gray; font-size: 7pt"
        Me.Label28.Text = "YOUR SECONDARY INSURANCE COMPANY'S NAME"
        Me.Label28.Top = 2.208333!
        Me.Label28.Width = 2.75!
        '
        'Label29
        '
        Me.Label29.Height = 0.125!
        Me.Label29.HyperLink = Nothing
        Me.Label29.Left = 7.1875!
        Me.Label29.Name = "Label29"
        Me.Label29.Style = "color: Gray; font-size: 7pt"
        Me.Label29.Text = "TELEPHONE"
        Me.Label29.Top = 0.8958328!
        Me.Label29.Width = 0.6875!
        '
        'Label30
        '
        Me.Label30.Height = 0.125!
        Me.Label30.HyperLink = Nothing
        Me.Label30.Left = 7.0625!
        Me.Label30.Name = "Label30"
        Me.Label30.Style = "color: Gray; font-size: 7pt"
        Me.Label30.Text = "EFFECTIVE DATE"
        Me.Label30.Top = 0.4583335!
        Me.Label30.Width = 0.9375!
        '
        'Label31
        '
        Me.Label31.Height = 0.125!
        Me.Label31.HyperLink = Nothing
        Me.Label31.Left = 7.4375!
        Me.Label31.Name = "Label31"
        Me.Label31.Style = "color: Gray; font-size: 7pt"
        Me.Label31.Text = "ZIP"
        Me.Label31.Top = 1.333333!
        Me.Label31.Width = 0.25!
        '
        'Label32
        '
        Me.Label32.Height = 0.125!
        Me.Label32.HyperLink = Nothing
        Me.Label32.Left = 6.5625!
        Me.Label32.Name = "Label32"
        Me.Label32.Style = "color: Gray; font-size: 7pt"
        Me.Label32.Text = "STATE"
        Me.Label32.Top = 1.333333!
        Me.Label32.Width = 0.375!
        '
        'Label33
        '
        Me.Label33.Height = 0.125!
        Me.Label33.HyperLink = Nothing
        Me.Label33.Left = 4.125!
        Me.Label33.Name = "Label33"
        Me.Label33.Style = "color: Gray; font-size: 7pt"
        Me.Label33.Text = "CITY"
        Me.Label33.Top = 1.333333!
        Me.Label33.Width = 0.375!
        '
        'Label34
        '
        Me.Label34.Height = 0.125!
        Me.Label34.HyperLink = Nothing
        Me.Label34.Left = 7.1875!
        Me.Label34.Name = "Label34"
        Me.Label34.Style = "color: Gray; font-size: 7pt"
        Me.Label34.Text = "TELEPHONE"
        Me.Label34.Top = 2.208333!
        Me.Label34.Width = 0.6875!
        '
        'Label35
        '
        Me.Label35.Height = 0.1875!
        Me.Label35.HyperLink = Nothing
        Me.Label35.Left = 6.8125!
        Me.Label35.Name = "Label35"
        Me.Label35.Style = "color: Gray; font-size: 10pt"
        Me.Label35.Text = "(        )"
        Me.Label35.Top = 1.083333!
        Me.Label35.Width = 0.5!
        '
        'Label36
        '
        Me.Label36.Height = 0.1875!
        Me.Label36.HyperLink = Nothing
        Me.Label36.Left = 6.8125!
        Me.Label36.Name = "Label36"
        Me.Label36.Style = "color: Gray; font-size: 10pt"
        Me.Label36.Text = "(        )"
        Me.Label36.Top = 2.395833!
        Me.Label36.Width = 0.5!
        '
        'Label37
        '
        Me.Label37.Height = 0.125!
        Me.Label37.HyperLink = Nothing
        Me.Label37.Left = 7.4375!
        Me.Label37.Name = "Label37"
        Me.Label37.Style = "color: Gray; font-size: 7pt"
        Me.Label37.Text = "ZIP"
        Me.Label37.Top = 2.645833!
        Me.Label37.Width = 0.25!
        '
        'Label38
        '
        Me.Label38.Height = 0.125!
        Me.Label38.HyperLink = Nothing
        Me.Label38.Left = 6.5!
        Me.Label38.Name = "Label38"
        Me.Label38.Style = "color: Gray; font-size: 7pt"
        Me.Label38.Text = "STATE"
        Me.Label38.Top = 2.645833!
        Me.Label38.Width = 0.375!
        '
        'Label39
        '
        Me.Label39.Height = 0.125!
        Me.Label39.HyperLink = Nothing
        Me.Label39.Left = 4.125!
        Me.Label39.Name = "Label39"
        Me.Label39.Style = "color: Gray; font-size: 7pt"
        Me.Label39.Text = "CITY"
        Me.Label39.Top = 2.645833!
        Me.Label39.Width = 0.375!
        '
        'Label40
        '
        Me.Label40.Height = 0.125!
        Me.Label40.HyperLink = Nothing
        Me.Label40.Left = 6.625!
        Me.Label40.Name = "Label40"
        Me.Label40.Style = "color: Gray; font-size: 7pt"
        Me.Label40.Text = "GROUP PLAN NUMBER"
        Me.Label40.Top = 3.083333!
        Me.Label40.Width = 1.375!
        '
        'Label41
        '
        Me.Label41.Height = 0.15!
        Me.Label41.HyperLink = Nothing
        Me.Label41.Left = 4.125!
        Me.Label41.Name = "Label41"
        Me.Label41.Style = "color: Gray; font-size: 7pt"
        Me.Label41.Text = "POLICYHOLDER'S ID NUMBER"
        Me.Label41.Top = 3.083333!
        Me.Label41.Width = 2.438!
        '
        'Line11
        '
        Me.Line11.Height = 0.0!
        Me.Line11.Left = 4.0625!
        Me.Line11.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line11.LineWeight = 1.0!
        Me.Line11.Name = "Line11"
        Me.Line11.Top = 3.083333!
        Me.Line11.Width = 4.125!
        Me.Line11.X1 = 4.0625!
        Me.Line11.X2 = 8.1875!
        Me.Line11.Y1 = 3.083333!
        Me.Line11.Y2 = 3.083333!
        '
        'shpliheader
        '
        Me.shpliheader.BackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.shpliheader.Height = 0.3959993!
        Me.shpliheader.Left = 0.22!
        Me.shpliheader.LineColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.shpliheader.Name = "shpliheader"
        Me.shpliheader.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.shpliheader.Top = 1.189!
        Me.shpliheader.Visible = False
        Me.shpliheader.Width = 8.06!
        '
        'lblLI1
        '
        Me.lblLI1.Height = 0.3159997!
        Me.lblLI1.Left = 0.32!
        Me.lblLI1.Name = "lblLI1"
        Me.lblLI1.Style = "color: Black; font-family: Arial; font-size: 8pt; font-weight: bold; text-align: " & _
    "left; vertical-align: middle; ddo-char-set: 1"
        Me.lblLI1.Text = "SERVICE DATE"
        Me.lblLI1.Top = 1.220999!
        Me.lblLI1.Visible = False
        Me.lblLI1.Width = 0.822!
        '
        'lblLI2
        '
        Me.lblLI2.Height = 0.3159997!
        Me.lblLI2.Left = 1.142!
        Me.lblLI2.Name = "lblLI2"
        Me.lblLI2.Style = "color: Black; font-family: Arial; font-size: 8pt; font-weight: bold; text-align: " & _
    "justify; vertical-align: middle; ddo-char-set: 1"
        Me.lblLI2.Text = "DESCRIPTION"
        Me.lblLI2.Top = 1.220999!
        Me.lblLI2.Visible = False
        Me.lblLI2.Width = 1.044!
        '
        'lblli5
        '
        Me.lblli5.Height = 0.316!
        Me.lblli5.Left = 7.437!
        Me.lblli5.Name = "lblli5"
        Me.lblli5.Style = "color: Black; font-family: Arial; font-size: 8pt; font-weight: bold; text-align: " & _
    "right; vertical-align: middle; ddo-char-set: 1"
        Me.lblli5.Text = "BALANCE"
        Me.lblli5.Top = 1.220999!
        Me.lblli5.Visible = False
        Me.lblli5.Width = 0.7760007!
        '
        'lblli4
        '
        Me.lblli4.Height = 0.316!
        Me.lblli4.Left = 6.294!
        Me.lblli4.Name = "lblli4"
        Me.lblli4.Style = "color: Black; font-family: Arial; font-size: 8pt; font-weight: bold; text-align: " & _
    "right; vertical-align: middle; ddo-char-set: 1"
        Me.lblli4.Text = "ADJUSTMENTS"
        Me.lblli4.Top = 1.220999!
        Me.lblli4.Visible = False
        Me.lblli4.Width = 0.983!
        '
        'lblli3
        '
        Me.lblli3.Height = 0.316!
        Me.lblli3.Left = 5.517001!
        Me.lblli3.Name = "lblli3"
        Me.lblli3.Style = "color: Black; font-family: Arial; font-size: 8pt; font-weight: bold; text-align: " & _
    "right; vertical-align: middle; ddo-char-set: 1"
        Me.lblli3.Text = "CHARGE"
        Me.lblli3.Top = 1.220999!
        Me.lblli3.Visible = False
        Me.lblli3.Width = 0.6499999!
        '
        'txtccol1
        '
        Me.txtccol1.DataField = "ccol1"
        Me.txtccol1.Height = 0.2009998!
        Me.txtccol1.Left = 0.3224988!
        Me.txtccol1.Name = "txtccol1"
        Me.txtccol1.OutputFormat = resources.GetString("txtccol1.OutputFormat")
        Me.txtccol1.Style = "color: Black; font-family: Arial; font-size: 8pt; font-weight: normal; text-align" & _
    ": left; vertical-align: middle; ddo-char-set: 1"
        Me.txtccol1.Text = "ccol1"
        Me.txtccol1.Top = 0.0000002384186!
        Me.txtccol1.Width = 0.785!
        '
        'txtccol2
        '
        Me.txtccol2.CanGrow = False
        Me.txtccol2.DataField = "ccol2"
        Me.txtccol2.Height = 0.2009998!
        Me.txtccol2.Left = 1.107499!
        Me.txtccol2.Name = "txtccol2"
        Me.txtccol2.Style = "color: Black; font-family: Arial; font-size: 8pt; font-weight: normal; text-align" & _
    ": left; vertical-align: middle; ddo-char-set: 1; ddo-shrink-to-fit: none"
        Me.txtccol2.Text = "ccol2"
        Me.txtccol2.Top = 0.0!
        Me.txtccol2.Width = 4.284!
        '
        'txtccol5
        '
        Me.txtccol5.CurrencyCulture = New System.Globalization.CultureInfo("en-US")
        Me.txtccol5.DataField = "ccol5"
        Me.txtccol5.Height = 0.2009998!
        Me.txtccol5.Left = 7.485499!
        Me.txtccol5.Name = "txtccol5"
        Me.txtccol5.OutputFormat = resources.GetString("txtccol5.OutputFormat")
        Me.txtccol5.Style = "color: Black; font-family: Arial; font-size: 8pt; font-weight: normal; text-align" & _
    ": right; vertical-align: middle; ddo-char-set: 1"
        Me.txtccol5.Text = "ccol5"
        Me.txtccol5.Top = 0.0!
        Me.txtccol5.Width = 0.6920018!
        '
        'txtccol4
        '
        Me.txtccol4.CurrencyCulture = New System.Globalization.CultureInfo("en-US")
        Me.txtccol4.DataField = "ccol4"
        Me.txtccol4.Height = 0.2009998!
        Me.txtccol4.Left = 6.574499!
        Me.txtccol4.Name = "txtccol4"
        Me.txtccol4.OutputFormat = resources.GetString("txtccol4.OutputFormat")
        Me.txtccol4.Style = "color: Black; font-family: Arial; font-size: 8pt; font-weight: normal; text-align" & _
    ": right; vertical-align: middle; ddo-char-set: 1"
        Me.txtccol4.Text = "ccol4"
        Me.txtccol4.Top = 0.0!
        Me.txtccol4.Width = 0.6680012!
        '
        'txtccol3
        '
        Me.txtccol3.CurrencyCulture = New System.Globalization.CultureInfo("en-US")
        Me.txtccol3.DataField = "ccol3"
        Me.txtccol3.Height = 0.2009998!
        Me.txtccol3.Left = 5.464499!
        Me.txtccol3.Name = "txtccol3"
        Me.txtccol3.OutputFormat = resources.GetString("txtccol3.OutputFormat")
        Me.txtccol3.Style = "color: Black; font-family: Arial; font-size: 8pt; font-weight: normal; text-align" & _
    ": right; vertical-align: middle; ddo-char-set: 1"
        Me.txtccol3.Text = "ccol3"
        Me.txtccol3.Top = 0.0!
        Me.txtccol3.Width = 0.6680012!
        '
        'StatementBack
        '
        Me.MasterReport = False
        SqlDBDataSource1.ConnectionString = "data source=TIM;initial catalog=Statement;integrated security=SSPI;persist securi" & _
    "ty info=False"
        SqlDBDataSource1.SQL = "Select * from statement s join lineitem l on s.istatementid=l.istatementid where " & _
    "s.istatementfileid=1160 order by s.istatementid,l.ilineitemid"
        Me.DataSource = SqlDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.0!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.0!
        Me.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 8.5!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.InserterHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.InserterFooter)
        Me.Sections.Add(Me.PageFooter)
        Me.ShowParameterUI = False
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
            "l; font-size: 10pt; color: Black", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.txtFooterStatementID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPageNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtboxBCD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPgNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPgCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChargesSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBillQuestions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCallUs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhoneNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblLI1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblLI2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblli5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblli4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblli3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtccol1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtccol2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtccol5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtccol4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtccol3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region



#Region "Fields and properties"

    Dim Print As Boolean = False
    Public Property bPrint() As Boolean
        Get
            Return Print
        End Get
        Set(ByVal value As Boolean)
            Print = value
            If value = True Then
                InserterHeader.Visible = True
            ElseIf value = False Then
                InserterHeader.Visible = False
            End If
        End Set
    End Property


    Public ReadOnly Property bDuplex() As Boolean
        Get
            Return True
        End Get
    End Property

    Dim PageCount As Integer = 1 'used to hide barcodes on even numbered pages on duplex jobs only
    Dim BarcodePageCount As Integer = 1  'used to set the pagenumber in the barcode on duplex jobs only
    Public WatermarkPath As String = ""

#End Region

    Private Sub AdditionalPage_PageStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PageStart
        txtPageNumber.Text = "Page 2 of " & iStatementTotalPages
        If iStatementCount > 0 And iStatementCount Mod 100 = 0 Then
            Console.Write(".")
            GC.Collect()
            If iStatementCount Mod 1000 = 0 Then
                Console.WriteLine("")
                GC.Collect()
            End If
        End If

        g_page += 1
        g_totalpages += 1
    End Sub

    Private Sub AdditionalPage_PageEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PageEnd
        PageCount += 1
    End Sub

    Private Sub GroupFooter1_AfterPrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.AfterPrint
        g_page = 1
        BarcodePageCount = 1
        PageCount = 0
    End Sub

    Private Sub PageFooter_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageFooter.Format
        ' Fix for view-all where the statementid at the bottom of the page was incorrect.  Now sets it correctly.
        'txtFooterStatementID.Text = TheStatementID
    End Sub

    Public WithEvents txtFooterStatementID As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Friend WithEvents InserterHeader As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Friend WithEvents txtboxBCD As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Friend WithEvents txtPgNum As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Friend WithEvents txtPgCount As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Friend WithEvents InserterBarcode As GrapeCity.ActiveReports.SectionReportModel.Barcode
    Friend WithEvents InserterFooter As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents PageHeader As GrapeCity.ActiveReports.SectionReportModel.PageHeader
    Private WithEvents Detail As GrapeCity.ActiveReports.SectionReportModel.Detail
    Private WithEvents PageFooter As GrapeCity.ActiveReports.SectionReportModel.PageFooter
    Public ds As GrapeCity.ActiveReports.Data.SqlDBDataSource


    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        If iLICount <= 10 Then
            Detail.Visible = False
        Else
            Detail.Visible = True
        End If

        iLICount += 1
    End Sub

    Private Sub GroupHeader1_Format(sender As Object, e As EventArgs) Handles GroupHeader1.Format
        If iTotalLICount > 10 Then
            shpliheader.Visible = True
            shpChargesSummary.Visible = True
            txtChargesSummary.Visible = True
            lblLI1.Visible = True
            lblLI2.Visible = True
            lblli4.Visible = True
            lblLI5.Visible = True
        End If
    End Sub
End Class
