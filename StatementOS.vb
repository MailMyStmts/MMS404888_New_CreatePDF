Imports GrapeCity.ActiveReports
Imports System.Drawing
Imports System.IO
Imports System.Data.SqlClient

Public Class StatementOS
    Inherits SectionReport
    Dim g_totalpages As Integer
    Dim g_addpages As New ArrayList
    Dim g_AdditionalPages As New ArrayList
    Dim lAddPages As New List(Of StatementBack)
    Dim g_page As Integer = 1
    Dim addPage As StatementBack
    Dim prevStatementID As Integer
    Dim iStatementTotalPages As Integer
    Public detailCount As Integer = 0

    Public g_watermark As Boolean = False

    Public g_Bre As String

    Dim dAdjustmentTotal As Double
    Dim dChargeTotal As Double
    Dim dDates() As Date
    Dim iDetailCount As Integer = 0


    Dim TheStatementID As String = ""
    Private WithEvents txtistatementid As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtcsendto1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtcsendto2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtcsendto3 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtcsendto4 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtcremitto1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtcremitto2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtcremitto3 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtcremitto4 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtcfrom1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtcfrom2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtcfrom3 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtcfrom4 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox32 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox33 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents picLogoBottom As GrapeCity.ActiveReports.SectionReportModel.Picture
    Private WithEvents shpBillSummary As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents shpOnlineBox As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents shpOnlineWhiteCircle As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents shpPhoneBox As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents shpPhoneCircle As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents picPhone As GrapeCity.ActiveReports.SectionReportModel.Picture
    Private WithEvents Shape1 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents txtBillSummary As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtBillQuestions As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtCallUs As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPhoneNum As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lnBillSummary As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents txtmamountdue As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox3 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtDueDate As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtOnlinePayOnline As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPhoneLabel As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtOnlineRecommended As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents picOnlineComputer As GrapeCity.ActiveReports.SectionReportModel.Picture
    Private WithEvents txtPhoneCall As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPhoneNumMid As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtOnlineVisit As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPayAddress As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents picOnlineArrow As GrapeCity.ActiveReports.SectionReportModel.Picture
    Private WithEvents picPhoneArrow As GrapeCity.ActiveReports.SectionReportModel.Picture
    Private WithEvents TextBox4 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtAccountNumber As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents shpMailBox As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents shpMailCircle As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents picMail As GrapeCity.ActiveReports.SectionReportModel.Picture
    Private WithEvents txtMailLabel As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents picMailArrow As GrapeCity.ActiveReports.SectionReportModel.Picture
    Private WithEvents txtMail As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPageNumber As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents picLogo As GrapeCity.ActiveReports.SectionReportModel.Picture
    Private WithEvents Shape11 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents TextBox27 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Shape10 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents Label7 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox24 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label6 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox25 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtcstmtdate As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox34 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line3 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Label13 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label16 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label17 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Line15 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line17 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Shape8 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents TextBox10 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox11 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox14 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox15 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox16 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtTotalLoanBalance As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox17 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents rtb2 As GrapeCity.ActiveReports.SectionReportModel.RichTextBox
    Private WithEvents txtccustom7 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents rtb3 As GrapeCity.ActiveReports.SectionReportModel.RichTextBox
    Private WithEvents Line1 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents TextBox5 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox7 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPaymentDue As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox18 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox19 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox22 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox23 As SectionReportModel.TextBox
    Private WithEvents picMosquito As SectionReportModel.Picture
    Private WithEvents TextBox6 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox8 As SectionReportModel.TextBox
    Private WithEvents TextBox9 As SectionReportModel.TextBox
    Private WithEvents TextBox12 As SectionReportModel.TextBox
    Private WithEvents TextBox13 As SectionReportModel.TextBox
    Private WithEvents TextBox20 As SectionReportModel.TextBox
    Private WithEvents TextBox21 As SectionReportModel.TextBox
    Private WithEvents TextBox26 As SectionReportModel.TextBox
    Private WithEvents Picture1 As SectionReportModel.Picture
    Private WithEvents Shape2 As SectionReportModel.Shape
    Private WithEvents txtOCR As SectionReportModel.TextBox
    Public iStatementCount As Integer = 0

    Public Sub New()
        MyBase.New()
        InitializeComponent()

    End Sub



#Region "ActiveReports Designer generated code"


























    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StatementOS))
        Dim SqlDBDataSource1 As GrapeCity.ActiveReports.Data.SqlDBDataSource = New GrapeCity.ActiveReports.Data.SqlDBDataSource()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.txtFooterStatementID = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPageNumber = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupHeader1 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.rtb2 = New GrapeCity.ActiveReports.SectionReportModel.RichTextBox()
        Me.Picture1 = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.Shape2 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.rtb3 = New GrapeCity.ActiveReports.SectionReportModel.RichTextBox()
        Me.shpBillSummary = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.txtistatementid = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.shpOnlineBox = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.shpOnlineWhiteCircle = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.shpPhoneBox = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.shpPhoneCircle = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.picPhone = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.Shape1 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.txtBillSummary = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtBillQuestions = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtCallUs = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPhoneNum = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.lnBillSummary = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.txtPaymentDue = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtmamountdue = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox3 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtDueDate = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtOnlinePayOnline = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPhoneLabel = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtOnlineRecommended = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.picOnlineComputer = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.txtPhoneCall = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPhoneNumMid = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtOnlineVisit = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPayAddress = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.picOnlineArrow = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.picPhoneArrow = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.TextBox4 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtAccountNumber = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.shpMailBox = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.shpMailCircle = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.picMail = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.txtMailLabel = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.picMailArrow = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.txtMail = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.picLogo = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.TextBox10 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox11 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox14 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox15 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox16 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtTotalLoanBalance = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtccustom7 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line1 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.TextBox5 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox7 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox18 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox19 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox22 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox23 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.picMosquito = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.TextBox6 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox8 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox9 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox12 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox13 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox20 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox21 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox26 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupFooter1 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.Shape10 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.txtcsendto1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtcsendto2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtcsendto3 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtcsendto4 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtcremitto1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtcremitto2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtcremitto3 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtcremitto4 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtcfrom1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtcfrom2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtcfrom3 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtcfrom4 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox32 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox33 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.picLogoBottom = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.Shape11 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.TextBox27 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label7 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox24 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label6 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox25 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtcstmtdate = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox34 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line3 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Label13 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label16 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label17 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Line15 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line17 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.TextBox1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox17 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Shape8 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.txtOCR = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.InserterHeader = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.txtboxBCD = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPgNum = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPgCount = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.InserterBarcode = New GrapeCity.ActiveReports.SectionReportModel.Barcode()
        Me.InserterFooter = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        CType(Me.txtFooterStatementID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPageNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtistatementid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPhone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBillSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBillQuestions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCallUs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhoneNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPaymentDue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtmamountdue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOnlinePayOnline, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhoneLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOnlineRecommended, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picOnlineComputer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhoneCall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhoneNumMid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOnlineVisit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPayAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picOnlineArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPhoneArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccountNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMailLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMailArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalLoanBalance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtccustom7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMosquito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcsendto1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcsendto2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcsendto3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcsendto4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcremitto1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcremitto2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcremitto3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcremitto4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcfrom1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcfrom2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcfrom3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcfrom4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLogoBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcstmtdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOCR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtboxBCD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPgNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPgCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.CanGrow = False
        Me.Detail.CanShrink = True
        Me.Detail.Height = 0!
        Me.Detail.Name = "Detail"
        '
        'PageHeader
        '
        Me.PageHeader.Height = 0!
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
        Me.txtFooterStatementID.Left = 0.25!
        Me.txtFooterStatementID.Name = "txtFooterStatementID"
        Me.txtFooterStatementID.Style = "color: Black; font-family: Courier New; font-size: 6pt; ddo-char-set: 1"
        Me.txtFooterStatementID.Text = "istatementid"
        Me.txtFooterStatementID.Top = 0!
        Me.txtFooterStatementID.Width = 2.0!
        '
        'txtPageNumber
        '
        Me.txtPageNumber.Height = 0.2!
        Me.txtPageNumber.Left = 6.997!
        Me.txtPageNumber.Name = "txtPageNumber"
        Me.txtPageNumber.Style = "color: Gray; font-family: Arial; font-size: 8pt; font-weight: bold; vertical-alig" &
    "n: middle; ddo-char-set: 1"
        Me.txtPageNumber.Text = "Page 1 of 2"
        Me.txtPageNumber.Top = 0!
        Me.txtPageNumber.Visible = False
        Me.txtPageNumber.Width = 1.039001!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.CanGrow = False
        Me.GroupHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.rtb2, Me.Picture1, Me.Shape2, Me.rtb3, Me.shpBillSummary, Me.txtistatementid, Me.shpOnlineBox, Me.shpOnlineWhiteCircle, Me.shpPhoneBox, Me.shpPhoneCircle, Me.picPhone, Me.Shape1, Me.txtBillSummary, Me.txtBillQuestions, Me.txtCallUs, Me.txtPhoneNum, Me.lnBillSummary, Me.txtPaymentDue, Me.txtmamountdue, Me.TextBox3, Me.txtDueDate, Me.txtOnlinePayOnline, Me.txtPhoneLabel, Me.txtOnlineRecommended, Me.picOnlineComputer, Me.txtPhoneCall, Me.txtPhoneNumMid, Me.txtOnlineVisit, Me.txtPayAddress, Me.picOnlineArrow, Me.picPhoneArrow, Me.TextBox4, Me.txtAccountNumber, Me.shpMailBox, Me.shpMailCircle, Me.picMail, Me.txtMailLabel, Me.picMailArrow, Me.txtMail, Me.picLogo, Me.TextBox10, Me.TextBox11, Me.TextBox14, Me.TextBox15, Me.TextBox16, Me.txtTotalLoanBalance, Me.txtccustom7, Me.Line1, Me.TextBox5, Me.TextBox7, Me.TextBox2, Me.TextBox18, Me.TextBox19, Me.TextBox22, Me.TextBox23, Me.picMosquito, Me.TextBox6, Me.TextBox8, Me.TextBox9, Me.TextBox12, Me.TextBox13, Me.TextBox20, Me.TextBox21, Me.TextBox26})
        Me.GroupHeader1.DataField = "istatementid"
        Me.GroupHeader1.Height = 7.25!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'rtb2
        '
        Me.rtb2.AutoReplaceFields = True
        Me.rtb2.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.rtb2.Height = 2.45!
        Me.rtb2.Left = 0.247!
        Me.rtb2.Name = "rtb2"
        Me.rtb2.RTF = resources.GetString("rtb2.RTF")
        Me.rtb2.Top = 4.348!
        Me.rtb2.Visible = False
        Me.rtb2.Width = 8.063001!
        '
        'Picture1
        '
        Me.Picture1.Height = 0.4030001!
        Me.Picture1.HyperLink = Nothing
        Me.Picture1.ImageData = CType(resources.GetObject("Picture1.ImageData"), System.IO.Stream)
        Me.Picture1.Left = 4.953!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.Picture1.Top = 3.839!
        Me.Picture1.Width = 0.5310001!
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Shape2.Height = 0.4030001!
        Me.Shape2.Left = 2.958!
        Me.Shape2.LineColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape2.Top = 3.839!
        Me.Shape2.Width = 1.995!
        '
        'rtb3
        '
        Me.rtb3.AutoReplaceFields = True
        Me.rtb3.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.rtb3.Height = 2.524!
        Me.rtb3.Left = 0.25!
        Me.rtb3.Name = "rtb3"
        Me.rtb3.RTF = resources.GetString("rtb3.RTF")
        Me.rtb3.Top = 4.348!
        Me.rtb3.Visible = False
        Me.rtb3.Width = 8.063!
        '
        'shpBillSummary
        '
        Me.shpBillSummary.Height = 2.402!
        Me.shpBillSummary.Left = 0.247!
        Me.shpBillSummary.LineColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.shpBillSummary.LineWeight = 13.0!
        Me.shpBillSummary.Name = "shpBillSummary"
        Me.shpBillSummary.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.shpBillSummary.Top = 1.84!
        Me.shpBillSummary.Width = 2.5!
        '
        'txtistatementid
        '
        Me.txtistatementid.DataField = "istatementid"
        Me.txtistatementid.Height = 0.1!
        Me.txtistatementid.Left = 0.146!
        Me.txtistatementid.Name = "txtistatementid"
        Me.txtistatementid.Style = "color: White; font-family: Courier New; font-size: 4.2pt; ddo-char-set: 0"
        Me.txtistatementid.Text = "istatementid"
        Me.txtistatementid.Top = 4.41!
        Me.txtistatementid.Width = 2.0!
        '
        'shpOnlineBox
        '
        Me.shpOnlineBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.shpOnlineBox.Height = 0.517!
        Me.shpOnlineBox.Left = 2.956!
        Me.shpOnlineBox.LineColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.shpOnlineBox.Name = "shpOnlineBox"
        Me.shpOnlineBox.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.shpOnlineBox.Top = 2.076!
        Me.shpOnlineBox.Width = 1.995!
        '
        'shpOnlineWhiteCircle
        '
        Me.shpOnlineWhiteCircle.Height = 0.3500001!
        Me.shpOnlineWhiteCircle.Left = 3.14!
        Me.shpOnlineWhiteCircle.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.shpOnlineWhiteCircle.Name = "shpOnlineWhiteCircle"
        Me.shpOnlineWhiteCircle.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.shpOnlineWhiteCircle.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.Ellipse
        Me.shpOnlineWhiteCircle.Top = 2.159!
        Me.shpOnlineWhiteCircle.Width = 0.4!
        '
        'shpPhoneBox
        '
        Me.shpPhoneBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.shpPhoneBox.Height = 0.517!
        Me.shpPhoneBox.Left = 2.956!
        Me.shpPhoneBox.LineColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.shpPhoneBox.Name = "shpPhoneBox"
        Me.shpPhoneBox.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.shpPhoneBox.Top = 2.630001!
        Me.shpPhoneBox.Width = 1.995!
        '
        'shpPhoneCircle
        '
        Me.shpPhoneCircle.Height = 0.3500001!
        Me.shpPhoneCircle.Left = 3.138!
        Me.shpPhoneCircle.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.shpPhoneCircle.Name = "shpPhoneCircle"
        Me.shpPhoneCircle.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.shpPhoneCircle.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.Ellipse
        Me.shpPhoneCircle.Top = 2.732001!
        Me.shpPhoneCircle.Width = 0.4!
        '
        'picPhone
        '
        Me.picPhone.Height = 0.2500001!
        Me.picPhone.HyperLink = Nothing
        Me.picPhone.ImageData = CType(resources.GetObject("picPhone.ImageData"), System.IO.Stream)
        Me.picPhone.Left = 3.183!
        Me.picPhone.Name = "picPhone"
        Me.picPhone.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.picPhone.Top = 2.772001!
        Me.picPhone.Width = 0.3!
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Shape1.Height = 0.25!
        Me.Shape1.Left = 0.247!
        Me.Shape1.LineColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Top = 1.59!
        Me.Shape1.Width = 1.25!
        '
        'txtBillSummary
        '
        Me.txtBillSummary.Height = 0.25!
        Me.txtBillSummary.Left = 0.247!
        Me.txtBillSummary.Name = "txtBillSummary"
        Me.txtBillSummary.Style = "color: White; font-family: arial; font-size: 9pt; font-weight: bold; text-align: " &
    "center; vertical-align: middle; ddo-char-set: 1"
        Me.txtBillSummary.Text = "BILL SUMMARY"
        Me.txtBillSummary.Top = 1.59!
        Me.txtBillSummary.Width = 1.25!
        '
        'txtBillQuestions
        '
        Me.txtBillQuestions.Height = 0.2!
        Me.txtBillQuestions.Left = 0.247!
        Me.txtBillQuestions.Name = "txtBillQuestions"
        Me.txtBillQuestions.Style = "color: Gray; font-family: Arial; font-size: 11pt; font-weight: normal; ddo-char-s" &
    "et: 1"
        Me.txtBillQuestions.Text = "Have questions about your bill?"
        Me.txtBillQuestions.Top = 0.528!
        Me.txtBillQuestions.Width = 2.511!
        '
        'txtCallUs
        '
        Me.txtCallUs.Height = 0.2!
        Me.txtCallUs.Left = 0.247!
        Me.txtCallUs.Name = "txtCallUs"
        Me.txtCallUs.Style = "color: Gray; font-family: Arial; font-size: 11pt; font-weight: normal; ddo-char-s" &
    "et: 1"
        Me.txtCallUs.Text = "Call us:"
        Me.txtCallUs.Top = 0.7279999!
        Me.txtCallUs.Width = 0.541!
        '
        'txtPhoneNum
        '
        Me.txtPhoneNum.DataField = "ccustom1"
        Me.txtPhoneNum.Height = 0.2!
        Me.txtPhoneNum.Left = 0.788!
        Me.txtPhoneNum.Name = "txtPhoneNum"
        Me.txtPhoneNum.Style = "color: Black; font-family: Arial; font-size: 11pt; font-weight: normal; ddo-char-" &
    "set: 1"
        Me.txtPhoneNum.Text = "248-644-8060"
        Me.txtPhoneNum.Top = 0.7279999!
        Me.txtPhoneNum.Width = 0.9990001!
        '
        'lnBillSummary
        '
        Me.lnBillSummary.Height = 0!
        Me.lnBillSummary.Left = 0.247!
        Me.lnBillSummary.LineColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.lnBillSummary.LineWeight = 13.0!
        Me.lnBillSummary.Name = "lnBillSummary"
        Me.lnBillSummary.Top = 3.535!
        Me.lnBillSummary.Width = 2.5!
        Me.lnBillSummary.X1 = 0.247!
        Me.lnBillSummary.X2 = 2.747!
        Me.lnBillSummary.Y1 = 3.535!
        Me.lnBillSummary.Y2 = 3.535!
        '
        'txtPaymentDue
        '
        Me.txtPaymentDue.Height = 0.25!
        Me.txtPaymentDue.Left = 0.497!
        Me.txtPaymentDue.Name = "txtPaymentDue"
        Me.txtPaymentDue.Style = "color: SteelBlue; font-family: Arial; font-size: 18pt; font-weight: normal; text-" &
    "align: center; vertical-align: middle; ddo-char-set: 1"
        Me.txtPaymentDue.Text = "Payment Due"
        Me.txtPaymentDue.Top = 2.78!
        Me.txtPaymentDue.Width = 2.01!
        '
        'txtmamountdue
        '
        Me.txtmamountdue.CurrencyCulture = New System.Globalization.CultureInfo("en-US")
        Me.txtmamountdue.DataField = "ccustom6"
        Me.txtmamountdue.Height = 0.4870002!
        Me.txtmamountdue.Left = 0.487!
        Me.txtmamountdue.Name = "txtmamountdue"
        Me.txtmamountdue.OutputFormat = resources.GetString("txtmamountdue.OutputFormat")
        Me.txtmamountdue.Style = "color: Black; font-family: arial; font-size: 24pt; font-weight: bold; text-align:" &
    " center; vertical-align: middle; ddo-char-set: 1"
        Me.txtmamountdue.Text = "$25.09*"
        Me.txtmamountdue.Top = 3.045!
        Me.txtmamountdue.Width = 2.01!
        '
        'TextBox3
        '
        Me.TextBox3.Height = 0.25!
        Me.TextBox3.Left = 0.487!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "color: Gray; font-family: Arial; font-size: 14pt; font-style: italic; font-weight" &
    ": normal; text-align: center; vertical-align: middle; ddo-char-set: 1"
        Me.TextBox3.Text = "Due Date"
        Me.TextBox3.Top = 3.588999!
        Me.TextBox3.Width = 2.01!
        '
        'txtDueDate
        '
        Me.txtDueDate.DataField = "ccustom3"
        Me.txtDueDate.Height = 0.4!
        Me.txtDueDate.Left = 0.487!
        Me.txtDueDate.Name = "txtDueDate"
        Me.txtDueDate.OutputFormat = resources.GetString("txtDueDate.OutputFormat")
        Me.txtDueDate.Style = "color: Black; font-family: arial; font-size: 24pt; font-weight: bold; text-align:" &
    " center; vertical-align: middle; ddo-char-set: 1"
        Me.txtDueDate.Text = "On Receipt"
        Me.txtDueDate.Top = 3.794!
        Me.txtDueDate.Width = 2.01!
        '
        'txtOnlinePayOnline
        '
        Me.txtOnlinePayOnline.Height = 0.2!
        Me.txtOnlinePayOnline.Left = 3.621!
        Me.txtOnlinePayOnline.Name = "txtOnlinePayOnline"
        Me.txtOnlinePayOnline.Style = "color: White; font-family: Arial; font-size: 15pt; font-weight: normal; text-alig" &
    "n: left; vertical-align: middle; ddo-char-set: 1"
        Me.txtOnlinePayOnline.Text = "Pay Online"
        Me.txtOnlinePayOnline.Top = 2.126!
        Me.txtOnlinePayOnline.Width = 1.156!
        '
        'txtPhoneLabel
        '
        Me.txtPhoneLabel.Height = 0.2!
        Me.txtPhoneLabel.Left = 3.621!
        Me.txtPhoneLabel.Name = "txtPhoneLabel"
        Me.txtPhoneLabel.Style = "color: White; font-family: Arial; font-size: 15pt; font-weight: normal; text-alig" &
    "n: left; vertical-align: middle; ddo-char-set: 1"
        Me.txtPhoneLabel.Text = "Pay By Phone"
        Me.txtPhoneLabel.Top = 2.772001!
        Me.txtPhoneLabel.Width = 1.364!
        '
        'txtOnlineRecommended
        '
        Me.txtOnlineRecommended.Height = 0.1300001!
        Me.txtOnlineRecommended.Left = 3.621!
        Me.txtOnlineRecommended.Name = "txtOnlineRecommended"
        Me.txtOnlineRecommended.Style = "color: White; font-family: Arial; font-size: 9pt; font-style: italic; font-weight" &
    ": normal; text-align: left; vertical-align: middle; ddo-char-set: 1"
        Me.txtOnlineRecommended.Text = "(Recommended)"
        Me.txtOnlineRecommended.Top = 2.376!
        Me.txtOnlineRecommended.Width = 1.156!
        '
        'picOnlineComputer
        '
        Me.picOnlineComputer.Height = 0.45!
        Me.picOnlineComputer.HyperLink = Nothing
        Me.picOnlineComputer.ImageData = CType(resources.GetObject("picOnlineComputer.ImageData"), System.IO.Stream)
        Me.picOnlineComputer.Left = 3.088!
        Me.picOnlineComputer.Name = "picOnlineComputer"
        Me.picOnlineComputer.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.picOnlineComputer.Top = 2.088!
        Me.picOnlineComputer.Width = 0.5!
        '
        'txtPhoneCall
        '
        Me.txtPhoneCall.Height = 0.1500001!
        Me.txtPhoneCall.Left = 5.269!
        Me.txtPhoneCall.Name = "txtPhoneCall"
        Me.txtPhoneCall.Style = "color: Gray; font-family: Arial; font-size: 12pt; font-weight: normal; vertical-a" &
    "lign: middle; ddo-char-set: 1"
        Me.txtPhoneCall.Text = "Call customer service:"
        Me.txtPhoneCall.Top = 2.696001!
        Me.txtPhoneCall.Width = 1.751!
        '
        'txtPhoneNumMid
        '
        Me.txtPhoneNumMid.DataField = "ccustom1"
        Me.txtPhoneNumMid.Height = 0.1500001!
        Me.txtPhoneNumMid.Left = 5.268002!
        Me.txtPhoneNumMid.Name = "txtPhoneNumMid"
        Me.txtPhoneNumMid.Style = "color: Black; font-family: Arial; font-size: 12pt; font-weight: normal; vertical-" &
    "align: middle; ddo-char-set: 1"
        Me.txtPhoneNumMid.Text = "248-644-8060"
        Me.txtPhoneNumMid.Top = 2.899002!
        Me.txtPhoneNumMid.Width = 1.751!
        '
        'txtOnlineVisit
        '
        Me.txtOnlineVisit.Height = 0.2080001!
        Me.txtOnlineVisit.Left = 5.266!
        Me.txtOnlineVisit.Name = "txtOnlineVisit"
        Me.txtOnlineVisit.Style = "color: Gray; font-family: Arial; font-size: 12pt; font-weight: normal; vertical-a" &
    "lign: middle; ddo-char-set: 1"
        Me.txtOnlineVisit.Text = "Visit:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txtOnlineVisit.Top = 2.211!
        Me.txtOnlineVisit.Width = 0.439!
        '
        'txtPayAddress
        '
        Me.txtPayAddress.Height = 0.2080001!
        Me.txtPayAddress.Left = 5.695002!
        Me.txtPayAddress.Name = "txtPayAddress"
        Me.txtPayAddress.ShrinkToFit = True
        Me.txtPayAddress.Style = "color: SteelBlue; font-family: Arial; font-size: 12pt; font-weight: bold; vertica" &
    "l-align: middle; ddo-char-set: 1; ddo-shrink-to-fit: true"
        Me.txtPayAddress.Text = "RollinsPayment.com"
        Me.txtPayAddress.Top = 2.211!
        Me.txtPayAddress.Width = 2.24!
        '
        'picOnlineArrow
        '
        Me.picOnlineArrow.Height = 0.517!
        Me.picOnlineArrow.HyperLink = Nothing
        Me.picOnlineArrow.ImageData = CType(resources.GetObject("picOnlineArrow.ImageData"), System.IO.Stream)
        Me.picOnlineArrow.Left = 4.944!
        Me.picOnlineArrow.Name = "picOnlineArrow"
        Me.picOnlineArrow.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.picOnlineArrow.Top = 2.076!
        Me.picOnlineArrow.Width = 0.5310001!
        '
        'picPhoneArrow
        '
        Me.picPhoneArrow.Height = 0.517!
        Me.picPhoneArrow.HyperLink = Nothing
        Me.picPhoneArrow.ImageData = CType(resources.GetObject("picPhoneArrow.ImageData"), System.IO.Stream)
        Me.picPhoneArrow.Left = 4.944!
        Me.picPhoneArrow.Name = "picPhoneArrow"
        Me.picPhoneArrow.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.picPhoneArrow.Top = 2.630001!
        Me.picPhoneArrow.Width = 0.5310001!
        '
        'TextBox4
        '
        Me.TextBox4.Height = 0.2!
        Me.TextBox4.Left = 2.956!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "color: Gray; font-family: Arial; font-size: 10pt; font-weight: normal; ddo-char-s" &
    "et: 1"
        Me.TextBox4.Text = "Account:"
        Me.TextBox4.Top = 1.809!
        Me.TextBox4.Width = 0.5989999!
        '
        'txtAccountNumber
        '
        Me.txtAccountNumber.DataField = "caccountno"
        Me.txtAccountNumber.Height = 0.2!
        Me.txtAccountNumber.Left = 3.555!
        Me.txtAccountNumber.Name = "txtAccountNumber"
        Me.txtAccountNumber.Style = "color: DimGray; font-family: Arial; font-size: 10pt; font-weight: bold; ddo-char-" &
    "set: 1"
        Me.txtAccountNumber.Text = "123456789-123-010-1"
        Me.txtAccountNumber.Top = 1.809!
        Me.txtAccountNumber.Width = 1.882001!
        '
        'shpMailBox
        '
        Me.shpMailBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.shpMailBox.Height = 0.517!
        Me.shpMailBox.Left = 2.958!
        Me.shpMailBox.LineColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.shpMailBox.Name = "shpMailBox"
        Me.shpMailBox.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.shpMailBox.Top = 3.248001!
        Me.shpMailBox.Width = 1.995!
        '
        'shpMailCircle
        '
        Me.shpMailCircle.Height = 0.3500001!
        Me.shpMailCircle.Left = 3.139999!
        Me.shpMailCircle.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.shpMailCircle.Name = "shpMailCircle"
        Me.shpMailCircle.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.shpMailCircle.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.Ellipse
        Me.shpMailCircle.Top = 3.350001!
        Me.shpMailCircle.Width = 0.4!
        '
        'picMail
        '
        Me.picMail.Height = 0.3960002!
        Me.picMail.HyperLink = Nothing
        Me.picMail.ImageData = CType(resources.GetObject("picMail.ImageData"), System.IO.Stream)
        Me.picMail.Left = 3.129999!
        Me.picMail.Name = "picMail"
        Me.picMail.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.picMail.Top = 3.324001!
        Me.picMail.Width = 0.4249997!
        '
        'txtMailLabel
        '
        Me.txtMailLabel.Height = 0.2!
        Me.txtMailLabel.Left = 3.622999!
        Me.txtMailLabel.Name = "txtMailLabel"
        Me.txtMailLabel.Style = "color: White; font-family: Arial; font-size: 15pt; font-weight: normal; text-alig" &
    "n: left; vertical-align: middle; ddo-char-set: 1"
        Me.txtMailLabel.Text = "Pay By Mail"
        Me.txtMailLabel.Top = 3.390002!
        Me.txtMailLabel.Width = 1.364!
        '
        'picMailArrow
        '
        Me.picMailArrow.Height = 0.517!
        Me.picMailArrow.HyperLink = Nothing
        Me.picMailArrow.ImageData = CType(resources.GetObject("picMailArrow.ImageData"), System.IO.Stream)
        Me.picMailArrow.Left = 4.946001!
        Me.picMailArrow.Name = "picMailArrow"
        Me.picMailArrow.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.picMailArrow.Top = 3.248001!
        Me.picMailArrow.Width = 0.5310001!
        '
        'txtMail
        '
        Me.txtMail.Height = 0.3970001!
        Me.txtMail.Left = 5.268!
        Me.txtMail.Name = "txtMail"
        Me.txtMail.Style = "color: Gray; font-family: Arial; font-size: 12pt; font-weight: normal; vertical-a" &
    "lign: middle; ddo-char-set: 1"
        Me.txtMail.Text = "Detach payment coupon and submit with a check"
        Me.txtMail.Top = 3.319001!
        Me.txtMail.Width = 2.618001!
        '
        'picLogo
        '
        Me.picLogo.Height = 1.014!
        Me.picLogo.HyperLink = Nothing
        Me.picLogo.ImageData = CType(resources.GetObject("picLogo.ImageData"), System.IO.Stream)
        Me.picLogo.Left = 5.86!
        Me.picLogo.Name = "picLogo"
        Me.picLogo.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom
        Me.picLogo.Top = 0.045!
        Me.picLogo.Width = 2.548!
        '
        'TextBox10
        '
        Me.TextBox10.DataField = "csendto1"
        Me.TextBox10.Height = 0.1875!
        Me.TextBox10.Left = 2.956!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ShrinkToFit = True
        Me.TextBox10.Style = "font-family: Arial; font-size: 10pt; ddo-char-set: 1; ddo-shrink-to-fit: true"
        Me.TextBox10.Text = "ALDOFO BIOY CESARES"
        Me.TextBox10.Top = 1.059!
        Me.TextBox10.Width = 3.267!
        '
        'TextBox11
        '
        Me.TextBox11.DataField = "csendto2"
        Me.TextBox11.Height = 0.1875!
        Me.TextBox11.Left = 2.956!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ShrinkToFit = True
        Me.TextBox11.Style = "font-family: Arial; font-size: 10pt; ddo-char-set: 1; ddo-shrink-to-fit: true"
        Me.TextBox11.Text = "5301 S SUPERSTITION MOUNTAIN DR STE 104-475"
        Me.TextBox11.Top = 1.247!
        Me.TextBox11.Width = 3.267!
        '
        'TextBox14
        '
        Me.TextBox14.DataField = "csendto3"
        Me.TextBox14.Height = 0.1875!
        Me.TextBox14.Left = 2.956!
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.ShrinkToFit = True
        Me.TextBox14.Style = "font-family: Arial; font-size: 10pt; ddo-char-set: 1; ddo-shrink-to-fit: true"
        Me.TextBox14.Text = "ROOM 412-A /C/O-LIFE CARE CENTER-SOUTHMOUNTAIN"
        Me.TextBox14.Top = 1.434!
        Me.TextBox14.Width = 3.2665!
        '
        'TextBox15
        '
        Me.TextBox15.DataField = "csendto4"
        Me.TextBox15.Height = 0.1875!
        Me.TextBox15.Left = 2.956!
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.ShrinkToFit = True
        Me.TextBox15.Style = "font-family: Arial; font-size: 10pt; ddo-char-set: 1; ddo-shrink-to-fit: true"
        Me.TextBox15.Text = "PALOS VERDES PENINSULA, CA  90274-1401"
        Me.TextBox15.Top = 1.621!
        Me.TextBox15.Width = 3.267!
        '
        'TextBox16
        '
        Me.TextBox16.Height = 0.2329999!
        Me.TextBox16.Left = 0.365!
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Style = "color: DarkGray; font-family: Arial; font-size: 10pt; font-weight: bold; text-ali" &
    "gn: justify; vertical-align: middle; ddo-char-set: 1"
        Me.TextBox16.Text = "Loan Payoff Amount:"
        Me.TextBox16.Top = 1.99!
        Me.TextBox16.Width = 2.175!
        '
        'txtTotalLoanBalance
        '
        Me.txtTotalLoanBalance.CurrencyCulture = New System.Globalization.CultureInfo("en-US")
        Me.txtTotalLoanBalance.DataField = "mamountdue"
        Me.txtTotalLoanBalance.Height = 0.2340002!
        Me.txtTotalLoanBalance.Left = 0.932!
        Me.txtTotalLoanBalance.Name = "txtTotalLoanBalance"
        Me.txtTotalLoanBalance.OutputFormat = resources.GetString("txtTotalLoanBalance.OutputFormat")
        Me.txtTotalLoanBalance.Style = "color: DarkGray; font-family: arial; font-size: 12pt; font-weight: bold; text-ali" &
    "gn: right; vertical-align: middle; ddo-char-set: 1"
        Me.txtTotalLoanBalance.Text = "$25.09*"
        Me.txtTotalLoanBalance.Top = 2.009!
        Me.txtTotalLoanBalance.Width = 1.708!
        '
        'txtccustom7
        '
        Me.txtccustom7.DataField = "ccustom7"
        Me.txtccustom7.Height = 0.1500001!
        Me.txtccustom7.Left = 3.891!
        Me.txtccustom7.Name = "txtccustom7"
        Me.txtccustom7.Style = "color: Black; font-family: Arial; font-size: 12pt; font-weight: normal; vertical-" &
    "align: middle; ddo-char-set: 1"
        Me.txtccustom7.Text = "ccustom7"
        Me.txtccustom7.Top = 4.299997!
        Me.txtccustom7.Visible = False
        Me.txtccustom7.Width = 1.751!
        '
        'Line1
        '
        Me.Line1.Height = 0!
        Me.Line1.Left = 0.25!
        Me.Line1.LineStyle = GrapeCity.ActiveReports.SectionReportModel.LineStyle.Dash
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 7.196001!
        Me.Line1.Width = 8.06!
        Me.Line1.X1 = 0.25!
        Me.Line1.X2 = 8.31!
        Me.Line1.Y1 = 7.196001!
        Me.Line1.Y2 = 7.196001!
        '
        'TextBox5
        '
        Me.TextBox5.CanGrow = False
        Me.TextBox5.Height = 0.18!
        Me.TextBox5.Left = 0.247!
        Me.TextBox5.MultiLine = False
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "color: Black; font-family: Arial; font-size: 9pt; font-weight: bold; text-align: " &
    "center; white-space: nowrap; ddo-char-set: 1"
        Me.TextBox5.Text = "Our Mission is to Be the Best Service Company in the World. Thank you for your bu" &
    "siness."
        Me.TextBox5.Top = 6.93!
        Me.TextBox5.Width = 8.066001!
        '
        'TextBox7
        '
        Me.TextBox7.DataField = "cstmtdate"
        Me.TextBox7.Height = 0.2!
        Me.TextBox7.Left = 0.25!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
        Me.TextBox7.Style = "color: DimGray; font-family: Arial; font-size: 10pt; font-weight: bold; ddo-char-" &
    "set: 1"
        Me.TextBox7.Text = "123456789-123-010-1"
        Me.TextBox7.Top = 0.328!
        Me.TextBox7.Width = 1.882001!
        '
        'TextBox2
        '
        Me.TextBox2.Height = 0.2329999!
        Me.TextBox2.Left = 0.3620002!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "color: DarkGray; font-family: Arial; font-size: 10pt; font-weight: bold; text-ali" &
    "gn: justify; vertical-align: middle; ddo-char-set: 1"
        Me.TextBox2.Text = "Past Due and Fees:"
        Me.TextBox2.Top = 2.249!
        Me.TextBox2.Width = 2.175!
        '
        'TextBox18
        '
        Me.TextBox18.CurrencyCulture = New System.Globalization.CultureInfo("en-US")
        Me.TextBox18.DataField = "ccustom8"
        Me.TextBox18.Height = 0.2340001!
        Me.TextBox18.Left = 0.929!
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.OutputFormat = resources.GetString("TextBox18.OutputFormat")
        Me.TextBox18.Style = "color: DarkGray; font-family: arial; font-size: 12pt; font-weight: bold; text-ali" &
    "gn: right; vertical-align: middle; ddo-char-set: 1"
        Me.TextBox18.Text = "$25.09*"
        Me.TextBox18.Top = 2.268!
        Me.TextBox18.Width = 1.708!
        '
        'TextBox19
        '
        Me.TextBox19.Height = 0.2329999!
        Me.TextBox19.Left = 0.362!
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Style = "color: DarkGray; font-family: Arial; font-size: 10pt; font-weight: bold; text-ali" &
    "gn: justify; vertical-align: middle; ddo-char-set: 1"
        Me.TextBox19.Text = "Current Monthly Due:"
        Me.TextBox19.Top = 2.509!
        Me.TextBox19.Width = 2.175!
        '
        'TextBox22
        '
        Me.TextBox22.CurrencyCulture = New System.Globalization.CultureInfo("en-US")
        Me.TextBox22.DataField = "ccustom9"
        Me.TextBox22.Height = 0.2340001!
        Me.TextBox22.Left = 0.929!
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.OutputFormat = resources.GetString("TextBox22.OutputFormat")
        Me.TextBox22.Style = "color: DarkGray; font-family: arial; font-size: 12pt; font-weight: bold; text-ali" &
    "gn: right; vertical-align: middle; ddo-char-set: 1"
        Me.TextBox22.Text = "$25.09*"
        Me.TextBox22.Top = 2.528!
        Me.TextBox22.Width = 1.708!
        '
        'TextBox23
        '
        Me.TextBox23.Height = 0.2!
        Me.TextBox23.Left = 5.86!
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Style = "color: Gray; font-family: Arial; font-size: 11pt; font-weight: normal; text-align" &
    ": center; ddo-char-set: 1"
        Me.TextBox23.Text = "Rollins Acceptance Company"
        Me.TextBox23.Top = 1.246!
        Me.TextBox23.Width = 2.511!
        '
        'picMosquito
        '
        Me.picMosquito.DataField = ""
        Me.picMosquito.Height = 2.23!
        Me.picMosquito.ImageData = CType(resources.GetObject("picMosquito.ImageData"), System.IO.Stream)
        Me.picMosquito.Left = 1.497!
        Me.picMosquito.Name = "picMosquito"
        Me.picMosquito.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom
        Me.picMosquito.Top = 4.568!
        Me.picMosquito.Visible = False
        Me.picMosquito.Width = 5.193!
        '
        'TextBox6
        '
        Me.TextBox6.DataField = "cnote4"
        Me.TextBox6.Height = 0.3870001!
        Me.TextBox6.Left = 3.028!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ShrinkToFit = True
        Me.TextBox6.Style = "color: Red; font-family: Arial; font-size: 12pt; font-weight: normal; vertical-al" &
    "ign: middle; ddo-char-set: 1; ddo-shrink-to-fit: true"
        Me.TextBox6.Text = "cnote4"
        Me.TextBox6.Top = 3.907!
        Me.TextBox6.Width = 5.326!
        '
        'TextBox8
        '
        Me.TextBox8.Height = 0.2!
        Me.TextBox8.Left = 0.247!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "color: Gray; font-family: Arial; font-size: 11pt; font-weight: normal; ddo-char-s" &
    "et: 1"
        Me.TextBox8.Text = "Email us:"
        Me.TextBox8.Top = 1.11!
        Me.TextBox8.Visible = False
        Me.TextBox8.Width = 0.6820003!
        '
        'TextBox9
        '
        Me.TextBox9.Height = 0.2!
        Me.TextBox9.Left = 0.9200003!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Style = "color: Black; font-family: Arial; font-size: 11pt; font-weight: normal; ddo-char-" &
    "set: 1"
        Me.TextBox9.Text = "RACresearch@rolins.com"
        Me.TextBox9.Top = 1.11!
        Me.TextBox9.Visible = False
        Me.TextBox9.Width = 1.949!
        '
        'TextBox12
        '
        Me.TextBox12.Height = 0.24675!
        Me.TextBox12.Left = 3.03!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Style = "color: White; font-family: Arial; font-size: 15.75pt; font-weight: normal; ddo-ch" &
    "ar-set: 0"
        Me.TextBox12.Text = "Account Inquiries"
        Me.TextBox12.Top = 3.941!
        Me.TextBox12.Visible = False
        Me.TextBox12.Width = 1.962!
        '
        'TextBox13
        '
        Me.TextBox13.Height = 0.2910002!
        Me.TextBox13.Left = 5.341!
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Style = "color: Gray; font-family: Arial; font-size: 12pt; font-weight: normal; vertical-a" &
    "lign: middle; ddo-char-set: 1"
        Me.TextBox13.Text = "RACcustomerservice@rollins.com"
        Me.TextBox13.Top = 3.897!
        Me.TextBox13.Visible = False
        Me.TextBox13.Width = 2.618001!
        '
        'TextBox20
        '
        Me.TextBox20.Height = 0.2!
        Me.TextBox20.Left = 0.247!
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Style = "color: Gray; font-family: Arial; font-size: 11pt; font-weight: normal; ddo-char-s" &
    "et: 1"
        Me.TextBox20.Text = "OR"
        Me.TextBox20.Top = 0.928!
        Me.TextBox20.Visible = False
        Me.TextBox20.Width = 0.6820003!
        '
        'TextBox21
        '
        Me.TextBox21.Height = 0.2!
        Me.TextBox21.Left = 0.25!
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Style = "color: Black; font-family: Arial; font-size: 11pt; font-weight: normal; ddo-char-" &
    "set: 1"
        Me.TextBox21.Text = "RACcustomerservice@rollins.com"
        Me.TextBox21.Top = 1.285!
        Me.TextBox21.Visible = False
        Me.TextBox21.Width = 2.475!
        '
        'TextBox26
        '
        Me.TextBox26.Height = 0.2910002!
        Me.TextBox26.Left = 5.341!
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Style = "color: Gray; font-family: Arial; font-size: 12pt; font-weight: normal; vertical-a" &
    "lign: middle; ddo-char-set: 1"
        Me.TextBox26.Text = "RACcustomerservice@rollins.com"
        Me.TextBox26.Top = 3.897!
        Me.TextBox26.Visible = False
        Me.TextBox26.Width = 2.618001!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape10, Me.txtcsendto1, Me.txtcsendto2, Me.txtcsendto3, Me.txtcsendto4, Me.txtcremitto1, Me.txtcremitto2, Me.txtcremitto3, Me.txtcremitto4, Me.txtcfrom1, Me.txtcfrom2, Me.txtcfrom3, Me.txtcfrom4, Me.TextBox32, Me.TextBox33, Me.picLogoBottom, Me.Shape11, Me.TextBox27, Me.Label7, Me.TextBox24, Me.Label6, Me.TextBox25, Me.txtcstmtdate, Me.TextBox34, Me.Line3, Me.Label13, Me.Label16, Me.Label17, Me.Line15, Me.Line17, Me.TextBox1, Me.TextBox17, Me.Shape8, Me.txtOCR})
        Me.GroupFooter1.Height = 3.5!
        Me.GroupFooter1.KeepTogether = True
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.After
        Me.GroupFooter1.PrintAtBottom = True
        '
        'Shape10
        '
        Me.Shape10.Height = 0.6759999!
        Me.Shape10.Left = 4.176!
        Me.Shape10.Name = "Shape10"
        Me.Shape10.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(9.999999!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape10.Top = 1.204!
        Me.Shape10.Width = 4.030002!
        '
        'txtcsendto1
        '
        Me.txtcsendto1.DataField = "csendto1"
        Me.txtcsendto1.Height = 0.1875!
        Me.txtcsendto1.Left = 0.993!
        Me.txtcsendto1.Name = "txtcsendto1"
        Me.txtcsendto1.ShrinkToFit = True
        Me.txtcsendto1.Style = "font-family: Arial; font-size: 10pt; ddo-char-set: 1; ddo-shrink-to-fit: true"
        Me.txtcsendto1.Text = "ALDOFO BIOY CESARES"
        Me.txtcsendto1.Top = 2.51!
        Me.txtcsendto1.Width = 3.267!
        '
        'txtcsendto2
        '
        Me.txtcsendto2.DataField = "csendto2"
        Me.txtcsendto2.Height = 0.1875!
        Me.txtcsendto2.Left = 0.993!
        Me.txtcsendto2.Name = "txtcsendto2"
        Me.txtcsendto2.ShrinkToFit = True
        Me.txtcsendto2.Style = "font-family: Arial; font-size: 10pt; ddo-char-set: 1; ddo-shrink-to-fit: true"
        Me.txtcsendto2.Text = "5301 S SUPERSTITION MOUNTAIN DR STE 104-475"
        Me.txtcsendto2.Top = 2.698!
        Me.txtcsendto2.Width = 3.267!
        '
        'txtcsendto3
        '
        Me.txtcsendto3.DataField = "csendto3"
        Me.txtcsendto3.Height = 0.1875!
        Me.txtcsendto3.Left = 0.993!
        Me.txtcsendto3.Name = "txtcsendto3"
        Me.txtcsendto3.ShrinkToFit = True
        Me.txtcsendto3.Style = "font-family: Arial; font-size: 10pt; ddo-char-set: 1; ddo-shrink-to-fit: true"
        Me.txtcsendto3.Text = "ROOM 412-A /C/O-LIFE CARE CENTER-SOUTHMOUNTAIN"
        Me.txtcsendto3.Top = 2.885!
        Me.txtcsendto3.Width = 3.2665!
        '
        'txtcsendto4
        '
        Me.txtcsendto4.DataField = "csendto4"
        Me.txtcsendto4.Height = 0.1875!
        Me.txtcsendto4.Left = 0.993!
        Me.txtcsendto4.Name = "txtcsendto4"
        Me.txtcsendto4.ShrinkToFit = True
        Me.txtcsendto4.Style = "font-family: Arial; font-size: 10pt; ddo-char-set: 1; ddo-shrink-to-fit: true"
        Me.txtcsendto4.Text = "PALOS VERDES PENINSULA, CA  90274-1401"
        Me.txtcsendto4.Top = 3.072!
        Me.txtcsendto4.Width = 3.267!
        '
        'txtcremitto1
        '
        Me.txtcremitto1.CanGrow = False
        Me.txtcremitto1.DataField = "cfrom1"
        Me.txtcremitto1.Height = 0.18!
        Me.txtcremitto1.Left = 4.992!
        Me.txtcremitto1.MultiLine = False
        Me.txtcremitto1.Name = "txtcremitto1"
        Me.txtcremitto1.Style = "font-family: Arial; font-size: 9pt; white-space: nowrap; ddo-char-set: 1"
        Me.txtcremitto1.Text = "ABC Healthcare"
        Me.txtcremitto1.Top = 2.454!
        Me.txtcremitto1.Width = 3.25!
        '
        'txtcremitto2
        '
        Me.txtcremitto2.CanGrow = False
        Me.txtcremitto2.DataField = "cfrom2"
        Me.txtcremitto2.Height = 0.18!
        Me.txtcremitto2.Left = 4.992!
        Me.txtcremitto2.MultiLine = False
        Me.txtcremitto2.Name = "txtcremitto2"
        Me.txtcremitto2.Style = "font-family: Arial; font-size: 9pt; white-space: nowrap; ddo-char-set: 1"
        Me.txtcremitto2.Text = "165 Caprice Ct"
        Me.txtcremitto2.Top = 2.641999!
        Me.txtcremitto2.Width = 3.25!
        '
        'txtcremitto3
        '
        Me.txtcremitto3.CanGrow = False
        Me.txtcremitto3.DataField = "cfrom3"
        Me.txtcremitto3.Height = 0.18!
        Me.txtcremitto3.Left = 4.992!
        Me.txtcremitto3.MultiLine = False
        Me.txtcremitto3.Name = "txtcremitto3"
        Me.txtcremitto3.Style = "font-family: Arial; font-size: 9pt; white-space: nowrap; ddo-char-set: 1"
        Me.txtcremitto3.Text = "Castle Rock, CO 80109"
        Me.txtcremitto3.Top = 2.829!
        Me.txtcremitto3.Width = 3.25!
        '
        'txtcremitto4
        '
        Me.txtcremitto4.CanGrow = False
        Me.txtcremitto4.DataField = "cfrom4"
        Me.txtcremitto4.Height = 0.18!
        Me.txtcremitto4.Left = 4.992!
        Me.txtcremitto4.MultiLine = False
        Me.txtcremitto4.Name = "txtcremitto4"
        Me.txtcremitto4.Style = "font-family: Arial; font-size: 9pt; white-space: nowrap; ddo-char-set: 1"
        Me.txtcremitto4.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txtcremitto4.Top = 3.016!
        Me.txtcremitto4.Width = 3.25!
        '
        'txtcfrom1
        '
        Me.txtcfrom1.CanGrow = False
        Me.txtcfrom1.DataField = "cfrom1"
        Me.txtcfrom1.Height = 0.18!
        Me.txtcfrom1.Left = 0.233!
        Me.txtcfrom1.MultiLine = False
        Me.txtcfrom1.Name = "txtcfrom1"
        Me.txtcfrom1.Style = "font-family: Arial; font-size: 9pt; white-space: nowrap; ddo-char-set: 1"
        Me.txtcfrom1.Text = "Mail My Statements"
        Me.txtcfrom1.Top = 0.7359999!
        Me.txtcfrom1.Visible = False
        Me.txtcfrom1.Width = 3.25!
        '
        'txtcfrom2
        '
        Me.txtcfrom2.CanGrow = False
        Me.txtcfrom2.DataField = "cfrom2"
        Me.txtcfrom2.Height = 0.18!
        Me.txtcfrom2.Left = 0.233!
        Me.txtcfrom2.MultiLine = False
        Me.txtcfrom2.Name = "txtcfrom2"
        Me.txtcfrom2.Style = "font-family: Arial; font-size: 9pt; white-space: nowrap; ddo-char-set: 1"
        Me.txtcfrom2.Text = "165 Caprice Ct"
        Me.txtcfrom2.Top = 0.916!
        Me.txtcfrom2.Width = 3.25!
        '
        'txtcfrom3
        '
        Me.txtcfrom3.CanGrow = False
        Me.txtcfrom3.DataField = "cfrom3"
        Me.txtcfrom3.Height = 0.18!
        Me.txtcfrom3.Left = 0.233!
        Me.txtcfrom3.MultiLine = False
        Me.txtcfrom3.Name = "txtcfrom3"
        Me.txtcfrom3.Style = "font-family: Arial; font-size: 9pt; white-space: nowrap; ddo-char-set: 1"
        Me.txtcfrom3.Text = "Castle Rock, CO 80109"
        Me.txtcfrom3.Top = 1.096!
        Me.txtcfrom3.Width = 3.25!
        '
        'txtcfrom4
        '
        Me.txtcfrom4.CanGrow = False
        Me.txtcfrom4.DataField = "cfrom4"
        Me.txtcfrom4.Height = 0.18!
        Me.txtcfrom4.Left = 0.233!
        Me.txtcfrom4.MultiLine = False
        Me.txtcfrom4.Name = "txtcfrom4"
        Me.txtcfrom4.Style = "font-family: Arial; font-size: 9pt; white-space: nowrap; ddo-char-set: 1"
        Me.txtcfrom4.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txtcfrom4.Top = 1.27!
        Me.txtcfrom4.Width = 3.25!
        '
        'TextBox32
        '
        Me.TextBox32.Height = 0.2!
        Me.TextBox32.Left = 4.145!
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.Style = "color: Gray; font-family: Arial; font-size: 8pt; font-weight: bold; vertical-alig" &
    "n: middle; ddo-char-set: 1"
        Me.TextBox32.Text = "Include your account number on checks payable to :"
        Me.TextBox32.Top = 1.933!
        Me.TextBox32.Width = 3.299001!
        '
        'TextBox33
        '
        Me.TextBox33.CanGrow = False
        Me.TextBox33.DataField = "cfrom1"
        Me.TextBox33.Height = 0.18!
        Me.TextBox33.Left = 4.145!
        Me.TextBox33.MultiLine = False
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.Style = "color: Black; font-family: Arial; font-size: 8pt; font-weight: bold; white-space:" &
    " nowrap; ddo-char-set: 1"
        Me.TextBox33.Text = "Rollins Acceptance Company"
        Me.TextBox33.Top = 2.146!
        Me.TextBox33.Visible = False
        Me.TextBox33.Width = 3.143001!
        '
        'picLogoBottom
        '
        Me.picLogoBottom.Height = 0.654!
        Me.picLogoBottom.HyperLink = Nothing
        Me.picLogoBottom.ImageData = CType(resources.GetObject("picLogoBottom.ImageData"), System.IO.Stream)
        Me.picLogoBottom.Left = 0!
        Me.picLogoBottom.Name = "picLogoBottom"
        Me.picLogoBottom.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom
        Me.picLogoBottom.Top = 0.233!
        Me.picLogoBottom.Width = 1.787!
        '
        'Shape11
        '
        Me.Shape11.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Shape11.Height = 0.401!
        Me.Shape11.Left = 4.176!
        Me.Shape11.Name = "Shape11"
        Me.Shape11.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(9.999999!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape11.Top = 1.502!
        Me.Shape11.Width = 1.046333!
        '
        'TextBox27
        '
        Me.TextBox27.DataField = "ccustom6"
        Me.TextBox27.Height = 0.3640001!
        Me.TextBox27.Left = 4.186!
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.OutputFormat = resources.GetString("TextBox27.OutputFormat")
        Me.TextBox27.Style = "font-size: 10pt; font-weight: bold; text-align: center; vertical-align: middle; d" &
    "do-char-set: 0"
        Me.TextBox27.Text = "ccustom6"
        Me.TextBox27.Top = 1.513!
        Me.TextBox27.Width = 1.036084!
        '
        'Label7
        '
        Me.Label7.Height = 0.1529999!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 6.372001!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "color: Black; font-size: 7pt; font-weight: bold; ddo-char-set: 0"
        Me.Label7.Text = "Invoice Number:"
        Me.Label7.Top = 1.27!
        Me.Label7.Width = 0.9350833!
        '
        'TextBox24
        '
        Me.TextBox24.CanGrow = False
        Me.TextBox24.DataField = "caccountno"
        Me.TextBox24.Height = 0.1529999!
        Me.TextBox24.Left = 7.148!
        Me.TextBox24.MultiLine = False
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.OutputFormat = resources.GetString("TextBox24.OutputFormat")
        Me.TextBox24.Style = "font-size: 7pt; text-align: left; vertical-align: top; white-space: nowrap; ddo-c" &
    "har-set: 0"
        Me.TextBox24.Text = "caccountno"
        Me.TextBox24.Top = 1.27!
        Me.TextBox24.Width = 0.9010004!
        '
        'Label6
        '
        Me.Label6.Height = 0.153!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 4.301!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "color: Black; font-size: 7pt; font-weight: bold; ddo-char-set: 0"
        Me.Label6.Text = "Customer:"
        Me.Label6.Top = 1.27!
        Me.Label6.Width = 0.6120001!
        '
        'TextBox25
        '
        Me.TextBox25.CanGrow = False
        Me.TextBox25.DataField = "csendto1"
        Me.TextBox25.Height = 0.153!
        Me.TextBox25.Left = 4.913!
        Me.TextBox25.MultiLine = False
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.OutputFormat = resources.GetString("TextBox25.OutputFormat")
        Me.TextBox25.ShrinkToFit = True
        Me.TextBox25.Style = "font-size: 7pt; text-align: left; vertical-align: top; white-space: nowrap; ddo-c" &
    "har-set: 0; ddo-shrink-to-fit: true"
        Me.TextBox25.Text = "csendto1"
        Me.TextBox25.Top = 1.27!
        Me.TextBox25.Width = 1.424!
        '
        'txtcstmtdate
        '
        Me.txtcstmtdate.DataField = "cstmtdate"
        Me.txtcstmtdate.Height = 0.169!
        Me.txtcstmtdate.Left = 5.079!
        Me.txtcstmtdate.Name = "txtcstmtdate"
        Me.txtcstmtdate.OutputFormat = resources.GetString("txtcstmtdate.OutputFormat")
        Me.txtcstmtdate.Style = "font-size: 8pt; text-align: center; vertical-align: middle; ddo-char-set: 0"
        Me.txtcstmtdate.Text = "cstmtdate"
        Me.txtcstmtdate.Top = 1.681!
        Me.txtcstmtdate.Width = 1.306083!
        '
        'TextBox34
        '
        Me.TextBox34.DataField = "ccustom3"
        Me.TextBox34.Height = 0.169!
        Me.TextBox34.Left = 6.252!
        Me.TextBox34.Name = "TextBox34"
        Me.TextBox34.OutputFormat = resources.GetString("TextBox34.OutputFormat")
        Me.TextBox34.Style = "font-size: 8pt; text-align: center; vertical-align: middle; ddo-char-set: 0"
        Me.TextBox34.Text = "ON RECEIPT"
        Me.TextBox34.Top = 1.681!
        Me.TextBox34.Width = 0.8890833!
        '
        'Line3
        '
        Me.Line3.Height = 0!
        Me.Line3.Left = 4.186!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 1.502!
        Me.Line3.Width = 4.020999!
        Me.Line3.X1 = 4.186!
        Me.Line3.X2 = 8.206999!
        Me.Line3.Y1 = 1.502!
        Me.Line3.Y2 = 1.502!
        '
        'Label13
        '
        Me.Label13.Height = 0.125!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 5.089!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "color: Black; font-size: 7pt; font-weight: bold; text-align: center; ddo-char-set" &
    ": 0"
        Me.Label13.Text = "STATEMENT DATE"
        Me.Label13.Top = 1.513!
        Me.Label13.Width = 1.292083!
        '
        'Label16
        '
        Me.Label16.Height = 0.125!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 6.248001!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "color: Black; font-size: 7pt; font-weight: bold; text-align: center; ddo-char-set" &
    ": 0"
        Me.Label16.Text = "DUE DATE"
        Me.Label16.Top = 1.513!
        Me.Label16.Width = 0.9090833!
        '
        'Label17
        '
        Me.Label17.Height = 0.125!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 7.117001!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "color: Black; font-size: 7pt; font-weight: bold; text-align: center; ddo-char-set" &
    ": 0"
        Me.Label17.Text = "AMOUNT ENCLOSED"
        Me.Label17.Top = 1.513!
        Me.Label17.Width = 1.080081!
        '
        'Line15
        '
        Me.Line15.Height = 0.699!
        Me.Line15.Left = 6.262!
        Me.Line15.LineWeight = 1.0!
        Me.Line15.Name = "Line15"
        Me.Line15.Top = 1.204!
        Me.Line15.Width = 0!
        Me.Line15.X1 = 6.262!
        Me.Line15.X2 = 6.262!
        Me.Line15.Y1 = 1.204!
        Me.Line15.Y2 = 1.903!
        '
        'Line17
        '
        Me.Line17.Height = 0.367!
        Me.Line17.Left = 7.13!
        Me.Line17.LineWeight = 1.0!
        Me.Line17.Name = "Line17"
        Me.Line17.Top = 1.513!
        Me.Line17.Width = 0!
        Me.Line17.X1 = 7.13!
        Me.Line17.X2 = 7.13!
        Me.Line17.Y1 = 1.513!
        Me.Line17.Y2 = 1.88!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 4.122!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "color: Gray; font-family: Arial; font-size: 10pt; font-weight: normal; ddo-char-s" &
    "et: 1"
        Me.TextBox1.Text = "Account:"
        Me.TextBox1.Top = 0.8870001!
        Me.TextBox1.Width = 0.5989999!
        '
        'TextBox17
        '
        Me.TextBox17.DataField = "caccountno"
        Me.TextBox17.Height = 0.2!
        Me.TextBox17.Left = 4.721!
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Style = "color: DimGray; font-family: Arial; font-size: 10pt; font-weight: bold; ddo-char-" &
    "set: 1"
        Me.TextBox17.Text = "123456789-123-010-1"
        Me.TextBox17.Top = 0.8870001!
        Me.TextBox17.Width = 1.882001!
        '
        'Shape8
        '
        Me.Shape8.Height = 0.788!
        Me.Shape8.Left = 4.122!
        Me.Shape8.LineColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Shape8.LineWeight = 13.0!
        Me.Shape8.Name = "Shape8"
        Me.Shape8.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape8.Top = 1.152!
        Me.Shape8.Width = 4.125!
        '
        'txtOCR
        '
        Me.txtOCR.Height = 0.18!
        Me.txtOCR.Left = 3.483!
        Me.txtOCR.Name = "txtOCR"
        Me.txtOCR.Style = "font-family: OCR A Extended; font-size: 12pt; text-align: right; vertical-align: " &
    "top; ddo-char-set: 0"
        Me.txtOCR.Text = "TextBox44"
        Me.txtOCR.Top = 3.259!
        Me.txtOCR.Visible = False
        Me.txtOCR.Width = 4.763999!
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
        Me.InserterBarcode.Height = 2.108!
        Me.InserterBarcode.Left = 8.313!
        Me.InserterBarcode.Name = "InserterBarcode"
        Me.InserterBarcode.NarrowBarWidth = 1.0!
        Me.InserterBarcode.QuietZoneBottom = 0!
        Me.InserterBarcode.QuietZoneLeft = 0!
        Me.InserterBarcode.QuietZoneRight = 0!
        Me.InserterBarcode.QuietZoneTop = 0!
        Me.InserterBarcode.Rotation = GrapeCity.ActiveReports.SectionReportModel.Rotation.Rotate90Degrees
        Me.InserterBarcode.Style = GrapeCity.ActiveReports.SectionReportModel.BarCodeStyle.Code25intlv
        Me.InserterBarcode.Text = "InserterBarcode"
        Me.InserterBarcode.Top = 1.642!
        Me.InserterBarcode.Width = 0.1920004!
        '
        'InserterFooter
        '
        Me.InserterFooter.Height = 0!
        Me.InserterFooter.Name = "InserterFooter"
        Me.InserterFooter.Visible = False
        '
        'StatementOS
        '
        Me.MasterReport = False
        SqlDBDataSource1.ConnectionString = "data source=TIM;initial catalog=Statement;integrated security=SSPI;persist securi" &
    "ty info=False"
        SqlDBDataSource1.SQL = "Select * from statement s join lineitem l on s.istatementid=l.istatementid where " &
    "s.istatementfileid=1160 order by s.istatementid,l.ilineitemid"
        Me.DataSource = SqlDBDataSource1
        Me.PageSettings.Margins.Bottom = 0!
        Me.PageSettings.Margins.Left = 0!
        Me.PageSettings.Margins.Right = 0!
        Me.PageSettings.Margins.Top = 0!
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
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" &
            "l; font-size: 10pt; color: Black", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" &
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.txtFooterStatementID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPageNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtistatementid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPhone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBillSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBillQuestions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCallUs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhoneNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPaymentDue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtmamountdue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOnlinePayOnline, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhoneLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOnlineRecommended, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picOnlineComputer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhoneCall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhoneNumMid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOnlineVisit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPayAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picOnlineArrow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPhoneArrow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccountNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMailLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMailArrow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalLoanBalance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtccustom7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMosquito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcsendto1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcsendto2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcsendto3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcsendto4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcremitto1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcremitto2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcremitto3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcremitto4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcfrom1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcfrom2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcfrom3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcfrom4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLogoBottom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcstmtdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOCR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtboxBCD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPgNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPgCount, System.ComponentModel.ISupportInitialize).EndInit()
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

    Private Sub StatementOS_PageStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PageStart

        If g_page = 1 Then

            Me.PageHeader.Visible = False


            BarcodePageCount = 1
        Else
            Me.PageHeader.Visible = True
        End If

        'hide the inserter header containing the bar code on odd numbered pages if it's a duplex job and the first page is simplex
        If bPrint = True And bDuplex = True And PageCount > 2 Then
            Dim iRemainder As Integer = PageCount Mod 2

            If iRemainder = 0 Then
                InserterHeader.Visible = True
                'Console.WriteLine("SHOW: " & TheStatementID & " : " & PageCount)
            Else
                InserterHeader.Visible = False
                'Console.WriteLine("HIDE: " & TheStatementID & " : " & PageCount)
            End If
        ElseIf bPrint = False Then
            InserterHeader.Visible = False
        Else    ' Show header for page 1 and 2... This is for standard-type statements.
            InserterHeader.Visible = True
            'Console.WriteLine("NEITHER: " & TheStatementID & " : " & PageCount)
        End If


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

    Private Sub StatementOS_PageEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PageEnd
        PageCount += 1
    End Sub
    Private Sub GroupFooter1_AfterPrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.AfterPrint
        g_page = 1
        BarcodePageCount = 1
        PageCount = 0
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format

        txtOnlinePayOnline.Visible = True
        txtOnlineRecommended.Visible = True
        txtOnlineVisit.Visible = True
        shpOnlineBox.Visible = True
        shpOnlineWhiteCircle.Visible = True
        picOnlineArrow.Visible = True
        picOnlineComputer.Visible = True

        If txtccustom7.Text.Contains("2") Then
            'Welcome Letter
            picMosquito.Visible = False
            rtb2.Visible = True
            rtb3.Visible = False
            TextBox8.Visible = True
            TextBox21.Visible = True
            TextBox12.Visible = True
            TextBox26.Visible = True
            TextBox20.Visible = True
        ElseIf txtccustom7.Text.Contains("3") Then
            'Collection Notice
            picMosquito.Visible = False
            rtb2.Visible = False
            rtb3.Visible = True
            TextBox8.Visible = True
            TextBox9.Visible = True
            TextBox12.Visible = True
            TextBox13.Visible = True
            TextBox20.Visible = True
        ElseIf txtccustom7.Text.Contains("4") Then
            'Invoice letter type
            picMosquito.Visible = True
            rtb2.Visible = False
            rtb3.Visible = False
            TextBox8.Visible = True
            TextBox21.Visible = True
            TextBox12.Visible = True
            TextBox26.Visible = True
            TextBox20.Visible = True
        ElseIf txtccustom7.Text.Contains("5") Then
            '5th letter type
            picMosquito.Visible = True
            rtb2.Visible = False
            rtb3.Visible = False
            txtOnlinePayOnline.Visible = False
            txtOnlineRecommended.Visible = False
            txtOnlineVisit.Visible = False
            shpOnlineBox.Visible = False
            shpOnlineWhiteCircle.Visible = False
            picOnlineArrow.Visible = False
            picOnlineComputer.Visible = False

            txtPhoneCall.Top = txtPhoneCall.Top - 0.7
            txtPhoneLabel.Top = txtPhoneLabel.Top - 0.7
            txtPhoneNumMid.Top = txtPhoneNumMid.Top - 0.7
            shpPhoneBox.Top = shpPhoneBox.Top - 0.7
            shpPhoneCircle.Top = shpPhoneCircle.Top - 0.7
            picPhone.Top = picPhone.Top - 0.7
            picPhoneArrow.Top = picPhoneArrow.Top - 0.7

            txtMail.Top = txtMail.Top - 0.7
            txtMailLabel.Top = txtMailLabel.Top - 0.7
            shpMailBox.Top = shpMailBox.Top - 0.7
            shpMailCircle.Top = shpMailCircle.Top - 0.7
            picMail.Top = picMail.Top - 0.7
            picMailArrow.Top = picMailArrow.Top - 0.7
        Else
            picMosquito.Visible = False
            rtb2.Visible = False
            rtb3.Visible = False

        End If

        ' If line 3 is blank in an address line, move line4 up
        If Me.txtcsendto3.Text = String.Empty Then
            Me.txtcsendto4.Top = Me.txtcsendto3.Top
        End If
        If Me.txtcfrom3.Text = String.Empty Then
            Me.txtcfrom4.Top = Me.txtcfrom3.Top
        End If
        If Me.txtcremitto3.Text = String.Empty Then
            Me.txtcremitto4.Top = Me.txtcremitto3.Top
        End If

        ' Set the StatementID here as we know it is correct.. We will use this in the footer.
        TheStatementID = txtistatementid.Text


    End Sub
    Private Sub InserterHeader_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles InserterHeader.BeforePrint
        'use the barcodepagecounter on a duplex job so the bar code reads 1, 2, 3 instead of 1, 3, 5
        If bPrint = True Then
            If bDuplex = True Then
                Me.InserterBarcode.Text = BarcodePageCount.ToString.PadLeft(3, "0") 'sets the current page

                'get the total pages
                Dim PgCount As Int16 = Convert.ToInt16(Me.txtPgCount.Text)

                'the first page is simplex so we need to add 1 for the remaining duplexed pages
                PgCount += 1

                'UPDATE THE DATABASE WITH THE # OF PAGES

                'check to see if we have an even or odd number of total pages
                Dim iRemainder As Integer = PgCount Mod 2
                If iRemainder = 0 Then
                    PgCount = PgCount / 2
                Else
                    'if we have an odd number of pages subtract one to make it even divide by 2 and add 1 back to the total
                    PgCount = PgCount - 1
                    PgCount = PgCount / 2
                    PgCount += 1
                End If

                Me.InserterBarcode.Text += PgCount.ToString.PadLeft(3, "0") 'set the total pagecount for the barcode

                BarcodePageCount += 1
            Else
                Me.InserterBarcode.Text = Me.txtPgNum.Text.PadLeft(3, "0")
                Me.InserterBarcode.Text += Me.txtPgCount.Text.PadLeft(3, "0")
            End If

            Me.InserterBarcode.Text += TheStatementID.ToString.PadLeft(8, "0")
            Me.InserterBarcode.Text += g_Bre
            Me.InserterBarcode.Text += "0"

            txtboxBCD.Text = InserterBarcode.Text

            InserterHeader.Visible = True

        End If

    End Sub

    Private Sub PageFooter_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageFooter.Format
        ' Fix for view-all where the statementid at the bottom of the page was incorrect.  Now sets it correctly.
        txtFooterStatementID.Text = TheStatementID
        txtPageNumber.Text = "Page 1 of 1"
    End Sub


    Private Sub GroupFooter1_Format(sender As Object, e As EventArgs) Handles GroupFooter1.Format


        'OCR SCANLINE
        txtOCR.Left = 2.77
        Dim sAccNum As String = TextBox24.Text.ToString 'ACCT NUMBER
        sAccNum = sAccNum.Replace("Account #:", "")
        sAccNum = sAccNum.Trim
        sAccNum = sAccNum.PadLeft(15, "0")
        Dim dAmount As Decimal = TextBox27.Text.ToString.Replace("$", "") 'AMOUNT DUE
        Dim sAmountDue As String = dAmount.ToString("C")
        sAmountDue = sAmountDue.Replace(".", "")
        sAmountDue = sAmountDue.Replace("$", "")
        sAmountDue = sAmountDue.Replace(",", "")
        'REPLACE NEGATIVE AMOUNT DUES WITH AN X 
        sAmountDue = sAmountDue.Replace("(", "X")
        sAmountDue = sAmountDue.Replace(")", "")
        sAmountDue = sAmountDue.PadLeft(10, "0")
        Dim sFullOCR As String = sAccNum + sAmountDue
        txtOCR.Text = Mod10Algorithm.AddChkDigiToNum(sFullOCR)
        txtOCR.Visible = True




        If Me.txtcsendto3.Text = String.Empty Then
            Me.txtcsendto4.Top = Me.txtcsendto3.Top
        End If
        If Me.txtcremitto2.Text = String.Empty Then
            Me.txtcremitto4.Top = Me.txtcremitto3.Top
            Me.txtcremitto3.Top = Me.txtcremitto2.Top
        End If
        If Me.txtcremitto3.Text = String.Empty Then
            Me.txtcremitto4.Top = Me.txtcremitto3.Top
        End If
        If Me.txtcfrom2.Text = String.Empty Then
            Me.txtcfrom4.Top = Me.txtcfrom3.Top
            Me.txtcfrom3.Top = Me.txtcfrom2.Top
        End If
        If Me.txtcfrom3.Text = String.Empty Then
            Me.txtcfrom4.Top = Me.txtcfrom3.Top
        End If
    End Sub
    Private Function GenerateQRCode(URL As String, DarkColor As System.Drawing.Color, LightColor As System.Drawing.Color) As Bitmap
        Dim Encoder As New Gma.QrCodeNet.Encoding.QrEncoder(Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.L)
        Dim Code As Gma.QrCodeNet.Encoding.QrCode = Encoder.Encode(URL)
        Dim TempBMP As New Bitmap(Code.Matrix.Width, Code.Matrix.Height)
        For X As Integer = 0 To Code.Matrix.Width - 1
            For Y As Integer = 0 To Code.Matrix.Height - 1
                If Code.Matrix.InternalArray(X, Y) Then TempBMP.SetPixel(X, Y, DarkColor) Else TempBMP.SetPixel(X, Y, LightColor)
            Next
        Next
        Return TempBMP
    End Function
    Private WithEvents txtFooterStatementID As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Friend WithEvents InserterHeader As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Friend WithEvents txtboxBCD As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Friend WithEvents txtPgNum As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Friend WithEvents txtPgCount As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Friend WithEvents InserterBarcode As GrapeCity.ActiveReports.SectionReportModel.Barcode
    Friend WithEvents InserterFooter As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents PageHeader As GrapeCity.ActiveReports.SectionReportModel.PageHeader
    Private WithEvents GroupHeader1 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents Detail As GrapeCity.ActiveReports.SectionReportModel.Detail
    Private WithEvents GroupFooter1 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents PageFooter As GrapeCity.ActiveReports.SectionReportModel.PageFooter
    Public ds As GrapeCity.ActiveReports.Data.SqlDBDataSource

    Private Sub StatementOS_ReportStart(sender As Object, e As EventArgs) Handles MyBase.ReportStart

    End Sub
End Class
