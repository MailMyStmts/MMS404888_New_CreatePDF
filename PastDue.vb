Imports GrapeCity.ActiveReports
Imports System.Drawing
Imports System.Data.SqlClient
'PASTDUE NOTICES 1-4 and PAYMENT REMINDER
Public Class PastDue
    Inherits SectionReport
    Dim g_totalpages As Integer
    Dim g_addpages As New ArrayList
    Dim g_page As Integer = 1

    Dim bRTBDeclared As Boolean = False

    Public g_watermark As Boolean = False

    Public g_Bre As String



    Dim TheStatementID As String = ""
    Private WithEvents txtccol1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtccol2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtccol6 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtPageNumber As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtccol5 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtccol4 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txtccol3 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line4 As SectionReportModel.Line
    Private WithEvents Line5 As SectionReportModel.Line
    Private WithEvents Shape6 As SectionReportModel.Shape
    Private WithEvents PD3 As SectionReportModel.TextBox
    Private WithEvents Shape8 As SectionReportModel.Shape
    Private WithEvents txtcsendto1 As SectionReportModel.TextBox
    Private WithEvents txtcsendto2 As SectionReportModel.TextBox
    Private WithEvents txtcsendto3 As SectionReportModel.TextBox
    Private WithEvents txtcsendto4 As SectionReportModel.TextBox
    Private WithEvents txtcremitto1 As SectionReportModel.TextBox
    Private WithEvents txtcremitto2 As SectionReportModel.TextBox
    Private WithEvents txtcremitto3 As SectionReportModel.TextBox
    Private WithEvents txtcremitto4 As SectionReportModel.TextBox
    Private WithEvents txtcfrom1 As SectionReportModel.TextBox
    Private WithEvents txtcfrom2 As SectionReportModel.TextBox
    Private WithEvents txtcfrom3 As SectionReportModel.TextBox
    Private WithEvents txtcfrom4 As SectionReportModel.TextBox
    Private WithEvents TextBox32 As SectionReportModel.TextBox
    Private WithEvents Label7 As SectionReportModel.Label
    Private WithEvents TextBox24 As SectionReportModel.TextBox
    Private WithEvents Label6 As SectionReportModel.Label
    Private WithEvents TextBox25 As SectionReportModel.TextBox
    Private WithEvents txtcstmtdate As SectionReportModel.TextBox
    Private WithEvents TextBox34 As SectionReportModel.TextBox
    Private WithEvents Line3 As SectionReportModel.Line
    Private WithEvents Label13 As SectionReportModel.Label
    Private WithEvents Label16 As SectionReportModel.Label
    Private WithEvents Label17 As SectionReportModel.Label
    Private WithEvents Line15 As SectionReportModel.Line
    Private WithEvents Line17 As SectionReportModel.Line
    Private WithEvents txtOCR As SectionReportModel.TextBox
    Private WithEvents Label1 As SectionReportModel.Label
    Private WithEvents TextBox2 As SectionReportModel.TextBox
    Private WithEvents TextBox3 As SectionReportModel.TextBox
    Private WithEvents TextBox4 As SectionReportModel.TextBox
    Private WithEvents TextBox5 As SectionReportModel.TextBox
    Private WithEvents TextBox6 As SectionReportModel.TextBox
    Private WithEvents Line1 As SectionReportModel.Line
    Private WithEvents Shape1 As SectionReportModel.Shape
    Private WithEvents Shape2 As SectionReportModel.Shape
    Private WithEvents Shape3 As SectionReportModel.Shape
    Private WithEvents Shape4 As SectionReportModel.Shape
    Private WithEvents TextBox1 As SectionReportModel.TextBox
    Private WithEvents TextBox7 As SectionReportModel.TextBox
    Private WithEvents TextBox8 As SectionReportModel.TextBox
    Private WithEvents TextBox9 As SectionReportModel.TextBox
    Private WithEvents TextBox10 As SectionReportModel.TextBox
    Private WithEvents TextBox11 As SectionReportModel.TextBox
    Private WithEvents TextBox12 As SectionReportModel.TextBox
    Private WithEvents TextBox13 As SectionReportModel.TextBox
    Private WithEvents TextBox14 As SectionReportModel.TextBox
    Private WithEvents TextBox15 As SectionReportModel.TextBox
    Private WithEvents TextBox16 As SectionReportModel.TextBox
    Private WithEvents TextBox17 As SectionReportModel.TextBox
    Private WithEvents TextBox18 As SectionReportModel.TextBox
    Private WithEvents TextBox19 As SectionReportModel.TextBox
    Private WithEvents TextBox20 As SectionReportModel.TextBox
    Private WithEvents TextBox21 As SectionReportModel.TextBox
    Private WithEvents txtmamountdue As SectionReportModel.TextBox
    Private WithEvents TextBox22 As SectionReportModel.TextBox
    Private WithEvents TextBox23 As SectionReportModel.TextBox
    Private WithEvents Line2 As SectionReportModel.Line
    Private WithEvents Picture3 As SectionReportModel.Picture
    Private WithEvents Picture4 As SectionReportModel.Picture
    Private WithEvents TextBox26 As SectionReportModel.TextBox
    Private WithEvents TextBox27 As SectionReportModel.TextBox
    Private WithEvents TextBox28 As SectionReportModel.TextBox
    Private WithEvents TextBox29 As SectionReportModel.TextBox
    Private WithEvents TextBox30 As SectionReportModel.TextBox
    Private WithEvents TextBox31 As SectionReportModel.TextBox
    Private WithEvents PD2 As SectionReportModel.TextBox
    Private WithEvents RollinsLogo As SectionReportModel.Picture
    Private WithEvents McCallLogo As SectionReportModel.Picture
    Private WithEvents NwestLogo As SectionReportModel.Picture
    Private WithEvents TruLogo As SectionReportModel.Picture
    Private WithEvents PermLogo As SectionReportModel.Picture
    Private WithEvents HomeLogo As SectionReportModel.Picture
    Private WithEvents CritLogo As SectionReportModel.Picture
    Private WithEvents OrkinLogo As SectionReportModel.Picture
    Private WithEvents OpcLogo As SectionReportModel.Picture
    Private WithEvents WestLogo As SectionReportModel.Picture
    Private WithEvents WaltLogo As SectionReportModel.Picture
    Private WithEvents BugLogo As SectionReportModel.Picture
    Private WithEvents ClarkLogo As SectionReportModel.Picture
    Private WithEvents Picture2 As SectionReportModel.Picture
    Private WithEvents Label2 As SectionReportModel.Label
    Private WithEvents Picture5 As SectionReportModel.Picture
    Private WithEvents Label3 As SectionReportModel.Label
    Private WithEvents PD1 As SectionReportModel.TextBox
    Private WithEvents PD4 As SectionReportModel.TextBox
    Private WithEvents PD5 As SectionReportModel.TextBox
    Private WithEvents PD6 As SectionReportModel.TextBox
    Private WithEvents TextBox36 As SectionReportModel.TextBox
    Public iStatementCount As Integer = 0

    Public Sub New()
        MyBase.New()
        InitializeComponent()

    End Sub



#Region "ActiveReports Designer generated code"



    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PastDue))
        Dim SqlDBDataSource1 As GrapeCity.ActiveReports.Data.SqlDBDataSource = New GrapeCity.ActiveReports.Data.SqlDBDataSource()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.txtFooterStatementID = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPageNumber = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupHeader1 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.Label3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Shape6 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.PD3 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox3 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox4 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox5 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox6 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Shape2 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.Shape3 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.TextBox9 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox10 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox11 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox12 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox13 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox14 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox15 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox16 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox17 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox18 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox19 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox20 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox21 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtmamountdue = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox22 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox23 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Picture3 = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.Picture4 = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.TextBox26 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox27 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox28 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox29 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox30 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox31 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Shape4 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.TextBox7 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox8 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PD2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.RollinsLogo = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.McCallLogo = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.NwestLogo = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.TruLogo = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.PermLogo = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.HomeLogo = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.CritLogo = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.OrkinLogo = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.OpcLogo = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.WestLogo = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.WaltLogo = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.BugLogo = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.ClarkLogo = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.Picture2 = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.Picture5 = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.Shape1 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.PD1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PD4 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PD5 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PD6 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupFooter1 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.Shape8 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
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
        Me.txtOCR = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Line1 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line2 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Label2 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox36 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.InserterHeader = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.txtboxBCD = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPgNum = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txtPgCount = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.InserterBarcode = New GrapeCity.ActiveReports.SectionReportModel.Barcode()
        Me.InserterFooter = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        CType(Me.txtFooterStatementID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPageNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PD3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtmamountdue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PD2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RollinsLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.McCallLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NwestLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TruLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PermLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HomeLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CritLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrkinLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OpcLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WestLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WaltLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BugLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClarkLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PD1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PD4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PD5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PD6, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcstmtdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOCR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtboxBCD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPgNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPgCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.CanShrink = True
        Me.Detail.Height = 0!
        Me.Detail.KeepTogether = True
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
        Me.txtPageNumber.Text = "Page 1 of 1"
        Me.txtPageNumber.Top = 0!
        Me.txtPageNumber.Width = 1.039001!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.CanGrow = False
        Me.GroupHeader1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label3, Me.Shape6, Me.PD3, Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.Shape2, Me.Shape3, Me.TextBox9, Me.TextBox10, Me.TextBox11, Me.TextBox12, Me.TextBox13, Me.TextBox14, Me.TextBox15, Me.TextBox16, Me.TextBox17, Me.TextBox18, Me.TextBox19, Me.TextBox20, Me.TextBox21, Me.txtmamountdue, Me.TextBox22, Me.TextBox23, Me.Picture3, Me.Picture4, Me.TextBox26, Me.TextBox27, Me.TextBox28, Me.TextBox29, Me.TextBox30, Me.TextBox31, Me.Shape4, Me.TextBox7, Me.TextBox8, Me.TextBox1, Me.PD2, Me.RollinsLogo, Me.McCallLogo, Me.NwestLogo, Me.TruLogo, Me.PermLogo, Me.HomeLogo, Me.CritLogo, Me.OrkinLogo, Me.OpcLogo, Me.WestLogo, Me.WaltLogo, Me.BugLogo, Me.ClarkLogo, Me.Picture2, Me.Picture5, Me.PD1, Me.PD4, Me.PD5, Me.PD6, Me.Shape1})
        Me.GroupHeader1.DataField = "istatementid"
        Me.GroupHeader1.Height = 6.811917!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Label3
        '
        Me.Label3.Height = 0.3189998!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.2810001!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "color: #D30D2B; font-size: 20pt; font-weight: bold; text-align: center; ddo-char-" &
    "set: 1"
        Me.Label3.Text = "PAST DUE NOTICE"
        Me.Label3.Top = 1.867!
        Me.Label3.Width = 7.964001!
        '
        'Shape6
        '
        Me.Shape6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Shape6.Height = 1.265!
        Me.Shape6.Left = 0.231!
        Me.Shape6.LineColor = System.Drawing.Color.WhiteSmoke
        Me.Shape6.LineWeight = 0!
        Me.Shape6.Name = "Shape6"
        Me.Shape6.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape6.Top = 2.276!
        Me.Shape6.Width = 8.014!
        '
        'PD3
        '
        Me.PD3.DataField = ""
        Me.PD3.DistinctField = ""
        Me.PD3.Height = 1.156!
        Me.PD3.Left = 0.281!
        Me.PD3.Name = "PD3"
        Me.PD3.Style = "color: Black; font-family: Arial; font-size: 10pt; font-weight: normal; text-alig" &
    "n: center; vertical-align: top; ddo-char-set: 1"
        Me.PD3.SummaryGroup = ""
        Me.PD3.Text = resources.GetString("PD3.Text")
        Me.PD3.Top = 2.276!
        Me.PD3.Visible = False
        Me.PD3.Width = 7.854001!
        '
        'TextBox2
        '
        Me.TextBox2.Height = 0.1375!
        Me.TextBox2.Left = 6.552001!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "font-size: 8.25pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox2.Text = "Questions about Service?"
        Me.TextBox2.Top = 0.3!
        Me.TextBox2.Width = 1.708416!
        '
        'TextBox3
        '
        Me.TextBox3.Height = 0.1375!
        Me.TextBox3.Left = 6.555!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "font-size: 8.25pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox3.Text = "Questions about Billing?"
        Me.TextBox3.Top = 0.7119999!
        Me.TextBox3.Width = 1.708417!
        '
        'TextBox4
        '
        Me.TextBox4.DataField = "ccustom1"
        Me.TextBox4.Height = 0.1375!
        Me.TextBox4.Left = 6.555!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "font-size: 9pt; font-weight: normal; text-align: right; ddo-char-set: 1"
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.493!
        Me.TextBox4.Width = 1.708417!
        '
        'TextBox5
        '
        Me.TextBox5.Height = 0.1375!
        Me.TextBox5.Left = 6.555!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "font-size: 9pt; font-weight: normal; text-align: right; ddo-char-set: 1"
        Me.TextBox5.Text = "1-800-437-5641"
        Me.TextBox5.Top = 0.909!
        Me.TextBox5.Width = 1.708417!
        '
        'TextBox6
        '
        Me.TextBox6.Height = 0.193!
        Me.TextBox6.Left = 0.231!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Style = "font-size: 10pt; font-weight: bold; text-align: left; ddo-char-set: 1"
        Me.TextBox6.Text = "ROLLINS ACCEPTANCE COMPANY"
        Me.TextBox6.Top = 0.3!
        Me.TextBox6.Width = 2.509!
        '
        'Shape2
        '
        Me.Shape2.Height = 0.6875!
        Me.Shape2.Left = 0.281!
        Me.Shape2.LineColor = System.Drawing.Color.Gray
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape2.Top = 5.01!
        Me.Shape2.Width = 4.645833!
        '
        'Shape3
        '
        Me.Shape3.Height = 0.6875!
        Me.Shape3.Left = 0.281!
        Me.Shape3.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Shape3.Name = "Shape3"
        Me.Shape3.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape3.Top = 5.864!
        Me.Shape3.Width = 4.645833!
        '
        'TextBox9
        '
        Me.TextBox9.Height = 0.3030001!
        Me.TextBox9.Left = 0.3169999!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Style = "color: Black; font-family: Impact; font-size: 16pt; font-weight: bold; ddo-char-s" &
    "et: 1"
        Me.TextBox9.Text = "OPTION 2"
        Me.TextBox9.Top = 5.077!
        Me.TextBox9.Width = 1.0!
        '
        'TextBox10
        '
        Me.TextBox10.Height = 0.3030001!
        Me.TextBox10.Left = 0.317!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Style = "color: Black; font-family: Impact; font-size: 16pt; font-weight: bold; ddo-char-s" &
    "et: 1"
        Me.TextBox10.Text = "OPTION 3"
        Me.TextBox10.Top = 5.913!
        Me.TextBox10.Width = 1.0!
        '
        'TextBox11
        '
        Me.TextBox11.Height = 0.193!
        Me.TextBox11.Left = 0.2309999!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Style = "font-size: 10pt; font-weight: normal; text-align: left; ddo-char-set: 1"
        Me.TextBox11.Text = "Invoice Date: "
        Me.TextBox11.Top = 0.5190001!
        Me.TextBox11.Width = 0.8890001!
        '
        'TextBox12
        '
        Me.TextBox12.DataField = "cstmtdate"
        Me.TextBox12.Height = 0.193!
        Me.TextBox12.Left = 1.116!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Style = "font-size: 10pt; font-weight: normal; text-align: left; ddo-char-set: 1"
        Me.TextBox12.Text = Nothing
        Me.TextBox12.Top = 0.5190001!
        Me.TextBox12.Width = 1.256!
        '
        'TextBox13
        '
        Me.TextBox13.Height = 0.1979167!
        Me.TextBox13.Left = 0.3169999!
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Style = "color: Black; font-size: 12pt; font-weight: bold; ddo-char-set: 1"
        Me.TextBox13.Text = "Pay by Phone"
        Me.TextBox13.Top = 5.442!
        Me.TextBox13.Width = 1.204!
        '
        'TextBox14
        '
        Me.TextBox14.Height = 0.1979167!
        Me.TextBox14.Left = 0.3169999!
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Style = "color: Black; font-size: 12pt; font-weight: bold; ddo-char-set: 1"
        Me.TextBox14.Text = "Pay by Mail"
        Me.TextBox14.Top = 6.297!
        Me.TextBox14.Width = 1.09!
        '
        'TextBox15
        '
        Me.TextBox15.Height = 0.1979167!
        Me.TextBox15.Left = 2.656!
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Style = "color: #D30D2B; font-size: 11pt; font-weight: normal; ddo-char-set: 1"
        Me.TextBox15.Text = "Scan QR Code or Visit: https://"
        Me.TextBox15.Top = 4.267!
        Me.TextBox15.Width = 2.208!
        '
        'TextBox16
        '
        Me.TextBox16.Height = 0.1979167!
        Me.TextBox16.Left = 2.656!
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Style = "color: #D30D2B; font-size: 11pt; font-weight: normal; ddo-char-set: 1"
        Me.TextBox16.Text = "racpayments.loanpro.software/" & Global.Microsoft.VisualBasic.ChrW(13)
        Me.TextBox16.Top = 4.465!
        Me.TextBox16.Width = 2.208!
        '
        'TextBox17
        '
        Me.TextBox17.Height = 0.2720005!
        Me.TextBox17.Left = 5.715!
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Style = "color: Black; font-size: 14pt; font-weight: bold; text-align: center; ddo-char-se" &
    "t: 1"
        Me.TextBox17.Text = "Bill Summary"
        Me.TextBox17.Top = 4.125!
        Me.TextBox17.Width = 1.972!
        '
        'TextBox18
        '
        Me.TextBox18.Height = 0.2720005!
        Me.TextBox18.Left = 5.181!
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Style = "color: Black; font-size: 11pt; font-weight: normal; text-align: center; ddo-char-" &
    "set: 1"
        Me.TextBox18.Text = "Loan Payoff Amount:"
        Me.TextBox18.Top = 4.465!
        Me.TextBox18.Width = 1.972!
        '
        'TextBox19
        '
        Me.TextBox19.Height = 0.2720005!
        Me.TextBox19.Left = 5.181!
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Style = "color: Black; font-size: 11pt; font-weight: normal; text-align: center; ddo-char-" &
    "set: 1"
        Me.TextBox19.Text = "Current Monthly Due:"
        Me.TextBox19.Top = 4.738!
        Me.TextBox19.Width = 1.972!
        '
        'TextBox20
        '
        Me.TextBox20.Height = 0.2720005!
        Me.TextBox20.Left = 5.181!
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Style = "color: Black; font-size: 11pt; font-weight: normal; text-align: center; ddo-char-" &
    "set: 1"
        Me.TextBox20.Text = "Past Due and Fees:"
        Me.TextBox20.Top = 5.01!
        Me.TextBox20.Width = 1.972!
        '
        'TextBox21
        '
        Me.TextBox21.Height = 0.2720005!
        Me.TextBox21.Left = 5.715!
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Style = "color: Black; font-size: 16pt; font-weight: normal; text-align: center; ddo-char-" &
    "set: 1"
        Me.TextBox21.Text = "PAYMENT DUE"
        Me.TextBox21.Top = 5.282!
        Me.TextBox21.Width = 1.972!
        '
        'txtmamountdue
        '
        Me.txtmamountdue.CurrencyCulture = New System.Globalization.CultureInfo("en-US")
        Me.txtmamountdue.DataField = "ccustom6"
        Me.txtmamountdue.Height = 0.4870002!
        Me.txtmamountdue.Left = 5.715!
        Me.txtmamountdue.Name = "txtmamountdue"
        Me.txtmamountdue.OutputFormat = resources.GetString("txtmamountdue.OutputFormat")
        Me.txtmamountdue.Style = "color: Black; font-family: arial; font-size: 24pt; font-weight: bold; text-align:" &
    " center; vertical-align: middle; ddo-char-set: 1"
        Me.txtmamountdue.Text = Nothing
        Me.txtmamountdue.Top = 5.554!
        Me.txtmamountdue.Width = 1.972!
        '
        'TextBox22
        '
        Me.TextBox22.Height = 0.2720005!
        Me.TextBox22.Left = 5.715!
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Style = "color: Black; font-size: 16pt; font-weight: normal; text-align: center; ddo-char-" &
    "set: 1"
        Me.TextBox22.Text = "Due Date"
        Me.TextBox22.Top = 6.041!
        Me.TextBox22.Width = 1.972!
        '
        'TextBox23
        '
        Me.TextBox23.CurrencyCulture = New System.Globalization.CultureInfo("en-US")
        Me.TextBox23.DataField = "ccustom3"
        Me.TextBox23.Height = 0.4870002!
        Me.TextBox23.Left = 5.715!
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Style = "color: Black; font-family: arial; font-size: 24pt; font-weight: bold; text-align:" &
    " center; vertical-align: middle; ddo-char-set: 1"
        Me.TextBox23.Text = Nothing
        Me.TextBox23.Top = 6.297!
        Me.TextBox23.Width = 1.972!
        '
        'Picture3
        '
        Me.Picture3.Height = 0.6041667!
        Me.Picture3.ImageData = Nothing
        Me.Picture3.Left = 1.521!
        Me.Picture3.Name = "Picture3"
        Me.Picture3.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.Picture3.Top = 5.036!
        Me.Picture3.Width = 0.6144999!
        '
        'Picture4
        '
        Me.Picture4.Height = 0.4761664!
        Me.Picture4.HyperLink = Nothing
        Me.Picture4.ImageData = Nothing
        Me.Picture4.Left = 1.407!
        Me.Picture4.Name = "Picture4"
        Me.Picture4.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.Picture4.Top = 5.965!
        Me.Picture4.Width = 0.7284999!
        '
        'TextBox26
        '
        Me.TextBox26.CurrencyCulture = New System.Globalization.CultureInfo("en-US")
        Me.TextBox26.DataField = "mamountdue"
        Me.TextBox26.Height = 0.2720005!
        Me.TextBox26.Left = 7.0!
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.OutputFormat = resources.GetString("TextBox26.OutputFormat")
        Me.TextBox26.Style = "color: Black; font-size: 11pt; font-weight: normal; text-align: center; ddo-char-" &
    "set: 1"
        Me.TextBox26.Text = Nothing
        Me.TextBox26.Top = 4.466!
        Me.TextBox26.Width = 1.26!
        '
        'TextBox27
        '
        Me.TextBox27.CurrencyCulture = New System.Globalization.CultureInfo("en-US")
        Me.TextBox27.DataField = "ccustom9"
        Me.TextBox27.Height = 0.2720005!
        Me.TextBox27.Left = 7.0!
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.OutputFormat = resources.GetString("TextBox27.OutputFormat")
        Me.TextBox27.Style = "color: Black; font-size: 11pt; font-weight: normal; text-align: center; ddo-char-" &
    "set: 1"
        Me.TextBox27.Text = Nothing
        Me.TextBox27.Top = 4.738!
        Me.TextBox27.Width = 1.26!
        '
        'TextBox28
        '
        Me.TextBox28.CurrencyCulture = New System.Globalization.CultureInfo("en-US")
        Me.TextBox28.DataField = "ccustom8"
        Me.TextBox28.Height = 0.2720005!
        Me.TextBox28.Left = 6.912!
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.OutputFormat = resources.GetString("TextBox28.OutputFormat")
        Me.TextBox28.Style = "color: Black; font-size: 11pt; font-weight: normal; text-align: center; ddo-char-" &
    "set: 1"
        Me.TextBox28.Text = Nothing
        Me.TextBox28.Top = 5.01!
        Me.TextBox28.Width = 1.348!
        '
        'TextBox29
        '
        Me.TextBox29.Height = 0.4760005!
        Me.TextBox29.Left = 2.656!
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.Style = "color: Black; font-size: 12pt; font-weight: normal; ddo-char-set: 1"
        Me.TextBox29.Text = "Detach payment slip below" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and submit with a check"
        Me.TextBox29.Top = 5.965!
        Me.TextBox29.Width = 2.208!
        '
        'TextBox30
        '
        Me.TextBox30.Height = 0.2160002!
        Me.TextBox30.Left = 2.656!
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Style = "color: Black; font-size: 12pt; font-weight: normal; ddo-char-set: 1"
        Me.TextBox30.Text = "Call Customer Service " & Global.Microsoft.VisualBasic.ChrW(13)
        Me.TextBox30.Top = 5.164!
        Me.TextBox30.Width = 2.208!
        '
        'TextBox31
        '
        Me.TextBox31.Height = 0.1979167!
        Me.TextBox31.Left = 2.656!
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.Style = "color: Black; font-size: 14pt; font-weight: bold; ddo-char-set: 1"
        Me.TextBox31.Text = "800-437-5641"
        Me.TextBox31.Top = 5.38!
        Me.TextBox31.Width = 2.208!
        '
        'Shape4
        '
        Me.Shape4.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(13, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.Shape4.Height = 0.875!
        Me.Shape4.Left = 0.281!
        Me.Shape4.LineColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(13, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.Shape4.Name = "Shape4"
        Me.Shape4.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape4.Top = 4.031!
        Me.Shape4.Width = 2.033167!
        '
        'TextBox7
        '
        Me.TextBox7.Height = 0.1979167!
        Me.TextBox7.Left = 0.317!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Style = "color: White; font-size: 12pt; font-weight: bold; ddo-char-set: 1"
        Me.TextBox7.Text = "Pay Online"
        Me.TextBox7.Top = 4.465001!
        Me.TextBox7.Width = 1.0!
        '
        'TextBox8
        '
        Me.TextBox8.Height = 0.1460001!
        Me.TextBox8.Left = 0.317!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "color: White; font-size: 7pt; font-weight: bold; ddo-char-set: 1"
        Me.TextBox8.Text = "(Recommended)"
        Me.TextBox8.Top = 4.718001!
        Me.TextBox8.Width = 1.0!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.3030002!
        Me.TextBox1.Left = 0.317!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "color: White; font-family: Impact; font-size: 16pt; font-weight: bold; ddo-char-s" &
    "et: 1"
        Me.TextBox1.Text = "OPTION 1"
        Me.TextBox1.Top = 4.094!
        Me.TextBox1.Width = 1.0!
        '
        'PD2
        '
        Me.PD2.DataField = ""
        Me.PD2.DistinctField = ""
        Me.PD2.Height = 1.156!
        Me.PD2.Left = 0.281!
        Me.PD2.Name = "PD2"
        Me.PD2.Style = "color: Black; font-family: Arial; font-size: 10pt; font-weight: normal; text-alig" &
    "n: center; vertical-align: top; ddo-char-set: 1"
        Me.PD2.SummaryGroup = ""
        Me.PD2.Text = resources.GetString("PD2.Text")
        Me.PD2.Top = 2.276!
        Me.PD2.Visible = False
        Me.PD2.Width = 7.854001!
        '
        'RollinsLogo
        '
        Me.RollinsLogo.Height = 1.153!
        Me.RollinsLogo.HyperLink = Nothing
        Me.RollinsLogo.ImageData = CType(resources.GetObject("RollinsLogo.ImageData"), System.IO.Stream)
        Me.RollinsLogo.Left = 3.062!
        Me.RollinsLogo.Name = "RollinsLogo"
        Me.RollinsLogo.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom
        Me.RollinsLogo.Top = 0.3!
        Me.RollinsLogo.Visible = False
        Me.RollinsLogo.Width = 2.642001!
        '
        'McCallLogo
        '
        Me.McCallLogo.Height = 1.153!
        Me.McCallLogo.HyperLink = Nothing
        Me.McCallLogo.ImageData = CType(resources.GetObject("McCallLogo.ImageData"), System.IO.Stream)
        Me.McCallLogo.Left = 3.073!
        Me.McCallLogo.Name = "McCallLogo"
        Me.McCallLogo.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom
        Me.McCallLogo.Top = 0.3!
        Me.McCallLogo.Visible = False
        Me.McCallLogo.Width = 2.642001!
        '
        'NwestLogo
        '
        Me.NwestLogo.Height = 1.153!
        Me.NwestLogo.HyperLink = Nothing
        Me.NwestLogo.ImageData = CType(resources.GetObject("NwestLogo.ImageData"), System.IO.Stream)
        Me.NwestLogo.Left = 3.073!
        Me.NwestLogo.Name = "NwestLogo"
        Me.NwestLogo.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom
        Me.NwestLogo.Top = 0.3!
        Me.NwestLogo.Visible = False
        Me.NwestLogo.Width = 2.642001!
        '
        'TruLogo
        '
        Me.TruLogo.Height = 1.153!
        Me.TruLogo.HyperLink = Nothing
        Me.TruLogo.ImageData = CType(resources.GetObject("TruLogo.ImageData"), System.IO.Stream)
        Me.TruLogo.Left = 3.073!
        Me.TruLogo.Name = "TruLogo"
        Me.TruLogo.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom
        Me.TruLogo.Top = 0.3!
        Me.TruLogo.Visible = False
        Me.TruLogo.Width = 2.642001!
        '
        'PermLogo
        '
        Me.PermLogo.Height = 1.153!
        Me.PermLogo.HyperLink = Nothing
        Me.PermLogo.ImageData = CType(resources.GetObject("PermLogo.ImageData"), System.IO.Stream)
        Me.PermLogo.Left = 3.062!
        Me.PermLogo.Name = "PermLogo"
        Me.PermLogo.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom
        Me.PermLogo.Top = 0.3!
        Me.PermLogo.Visible = False
        Me.PermLogo.Width = 2.642001!
        '
        'HomeLogo
        '
        Me.HomeLogo.Height = 1.153!
        Me.HomeLogo.HyperLink = Nothing
        Me.HomeLogo.ImageData = CType(resources.GetObject("HomeLogo.ImageData"), System.IO.Stream)
        Me.HomeLogo.Left = 3.073!
        Me.HomeLogo.Name = "HomeLogo"
        Me.HomeLogo.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom
        Me.HomeLogo.Top = 0.3!
        Me.HomeLogo.Visible = False
        Me.HomeLogo.Width = 2.642001!
        '
        'CritLogo
        '
        Me.CritLogo.Height = 1.153!
        Me.CritLogo.HyperLink = Nothing
        Me.CritLogo.ImageData = CType(resources.GetObject("CritLogo.ImageData"), System.IO.Stream)
        Me.CritLogo.Left = 3.073!
        Me.CritLogo.Name = "CritLogo"
        Me.CritLogo.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom
        Me.CritLogo.Top = 0.3!
        Me.CritLogo.Visible = False
        Me.CritLogo.Width = 2.642001!
        '
        'OrkinLogo
        '
        Me.OrkinLogo.Height = 1.153!
        Me.OrkinLogo.HyperLink = Nothing
        Me.OrkinLogo.ImageData = CType(resources.GetObject("OrkinLogo.ImageData"), System.IO.Stream)
        Me.OrkinLogo.Left = 3.062!
        Me.OrkinLogo.Name = "OrkinLogo"
        Me.OrkinLogo.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom
        Me.OrkinLogo.Top = 0.3!
        Me.OrkinLogo.Visible = False
        Me.OrkinLogo.Width = 2.642001!
        '
        'OpcLogo
        '
        Me.OpcLogo.Height = 1.153!
        Me.OpcLogo.HyperLink = Nothing
        Me.OpcLogo.ImageData = CType(resources.GetObject("OpcLogo.ImageData"), System.IO.Stream)
        Me.OpcLogo.Left = 3.062!
        Me.OpcLogo.Name = "OpcLogo"
        Me.OpcLogo.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom
        Me.OpcLogo.Top = 0.3!
        Me.OpcLogo.Visible = False
        Me.OpcLogo.Width = 2.642001!
        '
        'WestLogo
        '
        Me.WestLogo.Height = 1.153!
        Me.WestLogo.HyperLink = Nothing
        Me.WestLogo.ImageData = CType(resources.GetObject("WestLogo.ImageData"), System.IO.Stream)
        Me.WestLogo.Left = 3.073!
        Me.WestLogo.Name = "WestLogo"
        Me.WestLogo.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom
        Me.WestLogo.Top = 0.3!
        Me.WestLogo.Visible = False
        Me.WestLogo.Width = 2.642001!
        '
        'WaltLogo
        '
        Me.WaltLogo.Height = 1.153!
        Me.WaltLogo.HyperLink = Nothing
        Me.WaltLogo.ImageData = CType(resources.GetObject("WaltLogo.ImageData"), System.IO.Stream)
        Me.WaltLogo.Left = 3.073!
        Me.WaltLogo.Name = "WaltLogo"
        Me.WaltLogo.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom
        Me.WaltLogo.Top = 0.3!
        Me.WaltLogo.Visible = False
        Me.WaltLogo.Width = 2.642001!
        '
        'BugLogo
        '
        Me.BugLogo.Height = 1.153!
        Me.BugLogo.HyperLink = Nothing
        Me.BugLogo.ImageData = CType(resources.GetObject("BugLogo.ImageData"), System.IO.Stream)
        Me.BugLogo.Left = 3.062!
        Me.BugLogo.Name = "BugLogo"
        Me.BugLogo.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom
        Me.BugLogo.Top = 0.3!
        Me.BugLogo.Visible = False
        Me.BugLogo.Width = 2.642001!
        '
        'ClarkLogo
        '
        Me.ClarkLogo.Height = 1.153!
        Me.ClarkLogo.HyperLink = Nothing
        Me.ClarkLogo.ImageData = CType(resources.GetObject("ClarkLogo.ImageData"), System.IO.Stream)
        Me.ClarkLogo.Left = 3.062!
        Me.ClarkLogo.Name = "ClarkLogo"
        Me.ClarkLogo.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom
        Me.ClarkLogo.Top = 0.3!
        Me.ClarkLogo.Visible = False
        Me.ClarkLogo.Width = 2.642001!
        '
        'Picture2
        '
        Me.Picture2.Height = 0.77!
        Me.Picture2.HyperLink = Nothing
        Me.Picture2.ImageData = CType(resources.GetObject("Picture2.ImageData"), System.IO.Stream)
        Me.Picture2.Left = 1.407!
        Me.Picture2.Name = "Picture2"
        Me.Picture2.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch
        Me.Picture2.Top = 4.094!
        Me.Picture2.Width = 0.802!
        '
        'Picture5
        '
        Me.Picture5.Height = 0.4154997!
        Me.Picture5.HyperLink = Nothing
        Me.Picture5.ImageData = CType(resources.GetObject("Picture5.ImageData"), System.IO.Stream)
        Me.Picture5.Left = 2.314!
        Me.Picture5.Name = "Picture5"
        Me.Picture5.PictureAlignment = GrapeCity.ActiveReports.SectionReportModel.PictureAlignment.TopLeft
        Me.Picture5.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom
        Me.Picture5.Top = 4.397!
        Me.Picture5.Width = 0.4589998!
        '
        'Shape1
        '
        Me.Shape1.Height = 0.6875!
        Me.Shape1.Left = 2.25!
        Me.Shape1.LineColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(13, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.Shape1.LineWeight = 3.0!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Top = 4.125!
        Me.Shape1.Width = 2.676834!
        '
        'PD1
        '
        Me.PD1.DataField = ""
        Me.PD1.DistinctField = ""
        Me.PD1.Height = 1.156!
        Me.PD1.Left = 0.281!
        Me.PD1.Name = "PD1"
        Me.PD1.Style = "color: Black; font-family: Arial; font-size: 10pt; font-weight: normal; text-alig" &
    "n: center; vertical-align: top; ddo-char-set: 1"
        Me.PD1.SummaryGroup = ""
        Me.PD1.Text = resources.GetString("PD1.Text")
        Me.PD1.Top = 2.276!
        Me.PD1.Visible = False
        Me.PD1.Width = 7.854!
        '
        'PD4
        '
        Me.PD4.DataField = ""
        Me.PD4.DistinctField = ""
        Me.PD4.Height = 1.156!
        Me.PD4.Left = 0.281!
        Me.PD4.Name = "PD4"
        Me.PD4.Style = "color: Black; font-family: Arial; font-size: 10pt; font-weight: normal; text-alig" &
    "n: center; vertical-align: top; ddo-char-set: 1"
        Me.PD4.SummaryGroup = ""
        Me.PD4.Text = resources.GetString("PD4.Text")
        Me.PD4.Top = 2.276!
        Me.PD4.Visible = False
        Me.PD4.Width = 7.854!
        '
        'PD5
        '
        Me.PD5.DataField = ""
        Me.PD5.DistinctField = ""
        Me.PD5.Height = 1.156!
        Me.PD5.Left = 0.281!
        Me.PD5.Name = "PD5"
        Me.PD5.Style = "color: Black; font-family: Arial; font-size: 10pt; font-weight: normal; text-alig" &
    "n: center; vertical-align: top; ddo-char-set: 1"
        Me.PD5.SummaryGroup = ""
        Me.PD5.Text = resources.GetString("PD5.Text")
        Me.PD5.Top = 2.276!
        Me.PD5.Visible = False
        Me.PD5.Width = 7.854!
        '
        'PD6
        '
        Me.PD6.DataField = ""
        Me.PD6.DistinctField = ""
        Me.PD6.Height = 1.156!
        Me.PD6.Left = 0.281!
        Me.PD6.Name = "PD6"
        Me.PD6.Style = "color: Black; font-family: Arial; font-size: 10pt; font-weight: normal; text-alig" &
    "n: center; vertical-align: top; ddo-char-set: 1"
        Me.PD6.SummaryGroup = ""
        Me.PD6.Text = resources.GetString("PD6.Text")
        Me.PD6.Top = 2.276!
        Me.PD6.Visible = False
        Me.PD6.Width = 7.854!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape8, Me.txtcsendto1, Me.txtcsendto2, Me.txtcsendto3, Me.txtcsendto4, Me.txtcremitto1, Me.txtcremitto2, Me.txtcremitto3, Me.txtcremitto4, Me.txtcfrom1, Me.txtcfrom2, Me.txtcfrom3, Me.txtcfrom4, Me.TextBox32, Me.Label7, Me.TextBox24, Me.Label6, Me.TextBox25, Me.txtcstmtdate, Me.TextBox34, Me.Line3, Me.Label13, Me.Label16, Me.Label17, Me.Line15, Me.Line17, Me.txtOCR, Me.Label1, Me.Line1, Me.Line2, Me.Label2, Me.TextBox36})
        Me.GroupFooter1.Height = 3.427083!
        Me.GroupFooter1.KeepTogether = True
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.After
        Me.GroupFooter1.PrintAtBottom = True
        '
        'Shape8
        '
        Me.Shape8.Height = 0.8404588!
        Me.Shape8.Left = 3.624!
        Me.Shape8.LineColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(13, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.Shape8.LineWeight = 3.0!
        Me.Shape8.Name = "Shape8"
        Me.Shape8.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(10.0!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape8.Top = 1.029541!
        Me.Shape8.Width = 4.749501!
        '
        'txtcsendto1
        '
        Me.txtcsendto1.DataField = "csendto1"
        Me.txtcsendto1.Height = 0.1875!
        Me.txtcsendto1.Left = 1.1195!
        Me.txtcsendto1.Name = "txtcsendto1"
        Me.txtcsendto1.ShrinkToFit = True
        Me.txtcsendto1.Style = "font-family: Arial; font-size: 10pt; ddo-char-set: 1; ddo-shrink-to-fit: true"
        Me.txtcsendto1.Text = Nothing
        Me.txtcsendto1.Top = 2.387542!
        Me.txtcsendto1.Width = 3.267!
        '
        'txtcsendto2
        '
        Me.txtcsendto2.DataField = "csendto2"
        Me.txtcsendto2.Height = 0.1875!
        Me.txtcsendto2.Left = 1.1195!
        Me.txtcsendto2.Name = "txtcsendto2"
        Me.txtcsendto2.ShrinkToFit = True
        Me.txtcsendto2.Style = "font-family: Arial; font-size: 10pt; ddo-char-set: 1; ddo-shrink-to-fit: true"
        Me.txtcsendto2.Text = Nothing
        Me.txtcsendto2.Top = 2.575542!
        Me.txtcsendto2.Width = 3.267!
        '
        'txtcsendto3
        '
        Me.txtcsendto3.DataField = "csendto3"
        Me.txtcsendto3.Height = 0.1875!
        Me.txtcsendto3.Left = 1.1195!
        Me.txtcsendto3.Name = "txtcsendto3"
        Me.txtcsendto3.ShrinkToFit = True
        Me.txtcsendto3.Style = "font-family: Arial; font-size: 10pt; ddo-char-set: 1; ddo-shrink-to-fit: true"
        Me.txtcsendto3.Text = Nothing
        Me.txtcsendto3.Top = 2.762542!
        Me.txtcsendto3.Width = 3.2665!
        '
        'txtcsendto4
        '
        Me.txtcsendto4.DataField = "csendto4"
        Me.txtcsendto4.Height = 0.1875!
        Me.txtcsendto4.Left = 1.1195!
        Me.txtcsendto4.Name = "txtcsendto4"
        Me.txtcsendto4.ShrinkToFit = True
        Me.txtcsendto4.Style = "font-family: Arial; font-size: 10pt; ddo-char-set: 1; ddo-shrink-to-fit: true"
        Me.txtcsendto4.Text = Nothing
        Me.txtcsendto4.Top = 2.949542!
        Me.txtcsendto4.Width = 3.267!
        '
        'txtcremitto1
        '
        Me.txtcremitto1.CanGrow = False
        Me.txtcremitto1.DataField = "cfrom1"
        Me.txtcremitto1.Height = 0.18!
        Me.txtcremitto1.Left = 5.1185!
        Me.txtcremitto1.MultiLine = False
        Me.txtcremitto1.Name = "txtcremitto1"
        Me.txtcremitto1.Style = "font-family: Arial; font-size: 9pt; white-space: nowrap; ddo-char-set: 1"
        Me.txtcremitto1.Text = Nothing
        Me.txtcremitto1.Top = 2.331542!
        Me.txtcremitto1.Width = 3.25!
        '
        'txtcremitto2
        '
        Me.txtcremitto2.CanGrow = False
        Me.txtcremitto2.DataField = "cfrom2"
        Me.txtcremitto2.Height = 0.18!
        Me.txtcremitto2.Left = 5.1185!
        Me.txtcremitto2.MultiLine = False
        Me.txtcremitto2.Name = "txtcremitto2"
        Me.txtcremitto2.Style = "font-family: Arial; font-size: 9pt; white-space: nowrap; ddo-char-set: 1"
        Me.txtcremitto2.Text = Nothing
        Me.txtcremitto2.Top = 2.519541!
        Me.txtcremitto2.Width = 3.25!
        '
        'txtcremitto3
        '
        Me.txtcremitto3.CanGrow = False
        Me.txtcremitto3.DataField = "cfrom3"
        Me.txtcremitto3.Height = 0.18!
        Me.txtcremitto3.Left = 5.1185!
        Me.txtcremitto3.MultiLine = False
        Me.txtcremitto3.Name = "txtcremitto3"
        Me.txtcremitto3.Style = "font-family: Arial; font-size: 9pt; white-space: nowrap; ddo-char-set: 1"
        Me.txtcremitto3.Text = Nothing
        Me.txtcremitto3.Top = 2.706542!
        Me.txtcremitto3.Width = 3.25!
        '
        'txtcremitto4
        '
        Me.txtcremitto4.CanGrow = False
        Me.txtcremitto4.DataField = "cfrom4"
        Me.txtcremitto4.Height = 0.18!
        Me.txtcremitto4.Left = 5.1185!
        Me.txtcremitto4.MultiLine = False
        Me.txtcremitto4.Name = "txtcremitto4"
        Me.txtcremitto4.Style = "font-family: Arial; font-size: 9pt; white-space: nowrap; ddo-char-set: 1"
        Me.txtcremitto4.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txtcremitto4.Top = 2.893542!
        Me.txtcremitto4.Width = 3.25!
        '
        'txtcfrom1
        '
        Me.txtcfrom1.CanGrow = False
        Me.txtcfrom1.DataField = "cfrom1"
        Me.txtcfrom1.Height = 0.18!
        Me.txtcfrom1.Left = 0.3595001!
        Me.txtcfrom1.MultiLine = False
        Me.txtcfrom1.Name = "txtcfrom1"
        Me.txtcfrom1.Style = "font-family: Arial; font-size: 9pt; white-space: nowrap; ddo-char-set: 1"
        Me.txtcfrom1.Text = Nothing
        Me.txtcfrom1.Top = 0.6135415!
        Me.txtcfrom1.Width = 3.25!
        '
        'txtcfrom2
        '
        Me.txtcfrom2.CanGrow = False
        Me.txtcfrom2.DataField = "cfrom2"
        Me.txtcfrom2.Height = 0.18!
        Me.txtcfrom2.Left = 0.3595001!
        Me.txtcfrom2.MultiLine = False
        Me.txtcfrom2.Name = "txtcfrom2"
        Me.txtcfrom2.Style = "font-family: Arial; font-size: 9pt; white-space: nowrap; ddo-char-set: 1"
        Me.txtcfrom2.Text = Nothing
        Me.txtcfrom2.Top = 0.7935415!
        Me.txtcfrom2.Width = 3.25!
        '
        'txtcfrom3
        '
        Me.txtcfrom3.CanGrow = False
        Me.txtcfrom3.DataField = "cfrom3"
        Me.txtcfrom3.Height = 0.18!
        Me.txtcfrom3.Left = 0.3595001!
        Me.txtcfrom3.MultiLine = False
        Me.txtcfrom3.Name = "txtcfrom3"
        Me.txtcfrom3.Style = "font-family: Arial; font-size: 9pt; white-space: nowrap; ddo-char-set: 1"
        Me.txtcfrom3.Text = Nothing
        Me.txtcfrom3.Top = 0.9735414!
        Me.txtcfrom3.Width = 3.25!
        '
        'txtcfrom4
        '
        Me.txtcfrom4.CanGrow = False
        Me.txtcfrom4.DataField = "cfrom4"
        Me.txtcfrom4.Height = 0.18!
        Me.txtcfrom4.Left = 0.3595001!
        Me.txtcfrom4.MultiLine = False
        Me.txtcfrom4.Name = "txtcfrom4"
        Me.txtcfrom4.Style = "font-family: Arial; font-size: 9pt; white-space: nowrap; ddo-char-set: 1"
        Me.txtcfrom4.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txtcfrom4.Top = 1.147541!
        Me.txtcfrom4.Width = 3.25!
        '
        'TextBox32
        '
        Me.TextBox32.Height = 0.2!
        Me.TextBox32.Left = 3.624!
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.Style = "color: Black; font-family: Arial; font-size: 10pt; font-weight: normal; vertical-" &
    "align: middle; ddo-char-set: 1"
        Me.TextBox32.Text = "Include your account number on checks payable to :"
        Me.TextBox32.Top = 1.936!
        Me.TextBox32.Width = 3.424001!
        '
        'Label7
        '
        Me.Label7.Height = 0.1529999!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 6.048!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "color: Black; font-size: 10pt; font-weight: bold; ddo-char-set: 1"
        Me.Label7.Text = "ACCOUNT NUMBER"
        Me.Label7.Top = 1.082!
        Me.Label7.Width = 1.639!
        '
        'TextBox24
        '
        Me.TextBox24.CanGrow = False
        Me.TextBox24.DataField = "caccountno"
        Me.TextBox24.Height = 0.1529999!
        Me.TextBox24.Left = 6.048!
        Me.TextBox24.MultiLine = False
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Style = "font-size: 9pt; text-align: left; vertical-align: top; white-space: nowrap; ddo-c" &
    "har-set: 1"
        Me.TextBox24.Text = "caccountno"
        Me.TextBox24.Top = 1.312!
        Me.TextBox24.Width = 1.639!
        '
        'Label6
        '
        Me.Label6.Height = 0.153!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 3.668!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "color: Black; font-size: 9.5pt; font-weight: bold; ddo-char-set: 1"
        Me.Label6.Text = "CUSTOMER:"
        Me.Label6.Top = 1.082!
        Me.Label6.Width = 0.9450004!
        '
        'TextBox25
        '
        Me.TextBox25.CanGrow = False
        Me.TextBox25.DataField = "csendto1"
        Me.TextBox25.Height = 0.153!
        Me.TextBox25.Left = 3.668!
        Me.TextBox25.MultiLine = False
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.ShrinkToFit = True
        Me.TextBox25.Style = "font-size: 8pt; text-align: left; vertical-align: top; white-space: nowrap; ddo-c" &
    "har-set: 1; ddo-shrink-to-fit: true"
        Me.TextBox25.Text = "csendto1"
        Me.TextBox25.Top = 1.301!
        Me.TextBox25.Width = 1.826!
        '
        'txtcstmtdate
        '
        Me.txtcstmtdate.DataField = "cstmtdate"
        Me.txtcstmtdate.Height = 0.169!
        Me.txtcstmtdate.Left = 4.697!
        Me.txtcstmtdate.Name = "txtcstmtdate"
        Me.txtcstmtdate.Style = "font-size: 8pt; text-align: center; vertical-align: middle; ddo-char-set: 0"
        Me.txtcstmtdate.Text = "cstmtdate"
        Me.txtcstmtdate.Top = 1.701!
        Me.txtcstmtdate.Width = 1.306083!
        '
        'TextBox34
        '
        Me.TextBox34.DataField = "ccustom3"
        Me.TextBox34.Height = 0.169!
        Me.TextBox34.Left = 6.003!
        Me.TextBox34.Name = "TextBox34"
        Me.TextBox34.Style = "font-size: 8pt; text-align: center; vertical-align: middle; ddo-char-set: 0"
        Me.TextBox34.Text = "ON RECEIPT"
        Me.TextBox34.Top = 1.701!
        Me.TextBox34.Width = 0.8890833!
        '
        'Line3
        '
        Me.Line3.Height = 0!
        Me.Line3.Left = 3.624!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 1.465!
        Me.Line3.Width = 4.744!
        Me.Line3.X1 = 3.624!
        Me.Line3.X2 = 8.368!
        Me.Line3.Y1 = 1.465!
        Me.Line3.Y2 = 1.465!
        '
        'Label13
        '
        Me.Label13.Height = 0.125!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 4.697!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "color: Black; font-size: 7pt; font-weight: bold; text-align: center; ddo-char-set" &
    ": 0"
        Me.Label13.Text = "STATEMENT DATE"
        Me.Label13.Top = 1.509!
        Me.Label13.Width = 1.292083!
        '
        'Label16
        '
        Me.Label16.Height = 0.125!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 6.003!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "color: Black; font-size: 7pt; font-weight: bold; text-align: center; ddo-char-set" &
    ": 0"
        Me.Label16.Text = "DUE DATE"
        Me.Label16.Top = 1.509!
        Me.Label16.Width = 0.9090833!
        '
        'Label17
        '
        Me.Label17.Height = 0.125!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 7.0!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "color: Black; font-size: 7pt; font-weight: bold; text-align: center; ddo-char-set" &
    ": 0"
        Me.Label17.Text = "AMOUNT ENCLOSED"
        Me.Label17.Top = 1.509!
        Me.Label17.Width = 1.373001!
        '
        'Line15
        '
        Me.Line15.Height = 0.84!
        Me.Line15.Left = 5.989!
        Me.Line15.LineWeight = 1.0!
        Me.Line15.Name = "Line15"
        Me.Line15.Top = 1.03!
        Me.Line15.Width = 0!
        Me.Line15.X1 = 5.989!
        Me.Line15.X2 = 5.989!
        Me.Line15.Y1 = 1.03!
        Me.Line15.Y2 = 1.87!
        '
        'Line17
        '
        Me.Line17.Height = 0.405!
        Me.Line17.Left = 4.697!
        Me.Line17.LineWeight = 1.0!
        Me.Line17.Name = "Line17"
        Me.Line17.Top = 1.465!
        Me.Line17.Width = 0!
        Me.Line17.X1 = 4.697!
        Me.Line17.X2 = 4.697!
        Me.Line17.Y1 = 1.465!
        Me.Line17.Y2 = 1.87!
        '
        'txtOCR
        '
        Me.txtOCR.Height = 0.18!
        Me.txtOCR.Left = 3.6095!
        Me.txtOCR.Name = "txtOCR"
        Me.txtOCR.Style = "font-family: OCR A Extended; font-size: 12pt; text-align: right; vertical-align: " &
    "top; ddo-char-set: 0"
        Me.txtOCR.Text = "TextBox44"
        Me.txtOCR.Top = 3.136542!
        Me.txtOCR.Visible = False
        Me.txtOCR.Width = 4.763999!
        '
        'Label1
        '
        Me.Label1.Height = 0.125!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 3.668!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: Black; font-size: 7pt; font-weight: bold; text-align: center; ddo-char-set" &
    ": 0"
        Me.Label1.Text = "PAYMENT DUE"
        Me.Label1.Top = 1.509!
        Me.Label1.Width = 0.9450002!
        '
        'Line1
        '
        Me.Line1.Height = 0!
        Me.Line1.Left = 0.02083333!
        Me.Line1.LineColor = System.Drawing.Color.Silver
        Me.Line1.LineStyle = GrapeCity.ActiveReports.SectionReportModel.LineStyle.Dash
        Me.Line1.LineWeight = 3.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.125!
        Me.Line1.Width = 8.479167!
        Me.Line1.X1 = 0.02083333!
        Me.Line1.X2 = 8.5!
        Me.Line1.Y1 = 0.125!
        Me.Line1.Y2 = 0.125!
        '
        'Line2
        '
        Me.Line2.Height = 0.405!
        Me.Line2.Left = 6.997!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 1.465!
        Me.Line2.Width = 0!
        Me.Line2.X1 = 6.997!
        Me.Line2.X2 = 6.997!
        Me.Line2.Y1 = 1.465!
        Me.Line2.Y2 = 1.87!
        '
        'Label2
        '
        Me.Label2.Height = 0.2049998!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 4.795!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "color: #D30D2B; font-size: 13pt; font-weight: bold; text-align: right; ddo-char-s" &
    "et: 1"
        Me.Label2.Text = "PAST DUE NOTICE"
        Me.Label2.Top = 0.7690001!
        Me.Label2.Width = 3.573!
        '
        'TextBox36
        '
        Me.TextBox36.CurrencyCulture = New System.Globalization.CultureInfo("en-US")
        Me.TextBox36.DataField = "ccustom6"
        Me.TextBox36.Height = 0.169!
        Me.TextBox36.Left = 3.668!
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.OutputFormat = resources.GetString("TextBox36.OutputFormat")
        Me.TextBox36.Style = "font-size: 8pt; text-align: center; vertical-align: middle; ddo-char-set: 0"
        Me.TextBox36.Text = Nothing
        Me.TextBox36.Top = 1.701!
        Me.TextBox36.Width = 1.029!
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
        Me.txtboxBCD.Top = 3.562!
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
        Me.InserterBarcode.Height = 2.15!
        Me.InserterBarcode.Left = 8.263!
        Me.InserterBarcode.Name = "InserterBarcode"
        Me.InserterBarcode.NarrowBarWidth = 1.0!
        Me.InserterBarcode.QuietZoneBottom = 0!
        Me.InserterBarcode.QuietZoneLeft = 0!
        Me.InserterBarcode.QuietZoneRight = 0!
        Me.InserterBarcode.QuietZoneTop = 0!
        Me.InserterBarcode.Rotation = GrapeCity.ActiveReports.SectionReportModel.Rotation.Rotate90Degrees
        Me.InserterBarcode.Style = GrapeCity.ActiveReports.SectionReportModel.BarCodeStyle.Code25intlv
        Me.InserterBarcode.Text = "InserterBarcode"
        Me.InserterBarcode.Top = 1.412!
        Me.InserterBarcode.Visible = False
        Me.InserterBarcode.Width = 0.2369995!
        '
        'InserterFooter
        '
        Me.InserterFooter.Height = 0!
        Me.InserterFooter.Name = "InserterFooter"
        Me.InserterFooter.Visible = False
        '
        'PastDue
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
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PD3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtmamountdue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PD2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RollinsLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.McCallLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NwestLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TruLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PermLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HomeLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CritLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrkinLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OpcLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WestLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WaltLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BugLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClarkLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PD1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PD4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PD5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PD6, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcstmtdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOCR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox36, System.ComponentModel.ISupportInitialize).EndInit()
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

            'If g_watermark Then
            '    Dim imgWater As System.Drawing.Image

            '    imgWater = System.Drawing.Image.FromFile(WatermarkPath)

            '    Me.CurrentPage.DrawImage(imgWater, 0, 0, 8.5, 11)
            'End If
            'ElseIf g_page = 2 Then
            '    If g_watermark Then
            '        Dim imgWater As System.Drawing.Image

            '        imgWater = System.Drawing.Image.FromFile(BackWatermarkPath)

            '        Me.CurrentPage.DrawImage(imgWater, 0, 0, 8.5, 11)
            '    End If

            BarcodePageCount = 1
            'PageStatementStart = g_totalpages
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
        'TheStatementID = txtistatementid.Text

        'g_addpages.Add(g_totalpages)

        'If Me.TextBox19.Text = "" Then
        '    Me.TextBox19.Text = Me.TextBox20.Text
        '    Me.TextBox20.Text = ""
        'End If

        ''Letter Type
        Dim lettertype As String = Me.DataLayer.Fields.Item("ccustom7").Value.ToString
        Select Case lettertype
            Case "PD" 'Payment Reminder
                PD1.Visible = True
                Label3.Text = "PAYMENT REMINDER"
            Case "PD1" 'Past Due
                PD2.Visible = True
            Case "PD2" 'Past Due - Second Reminder
                PD3.Visible = True
                Label3.Text = "PAST DUE 2ND NOTICE"
            Case "PD3" 'Past Due - 3rd Notice
                PD4.Visible = True
                Label3.Text = "PAST DUE 3RD NOTICE"
            Case "PD4" 'Past Due - 4th Notice
                PD5.Visible = True
                Label3.Text = "PAST DUE 4TH NOTICE"
            Case "PD5" 'Past Due - Final Notice
                PD6.Visible = True
                Label3.Text = "PAST DUE-FINAL NOTICE"
        End Select

        'Brand 
        Dim brand As String = Me.DataLayer.Fields.Item("ccustom10").Value.ToString
        Select Case brand
            Case "ORK"
                OrkinLogo.Visible = True
            Case "BUG"
                BugLogo.Visible = True
            Case "WALT"
                WaltLogo.Visible = True
            Case "PERM"
                PermLogo.Visible = True
            Case "HOME"
                HomeLogo.Visible = True
            Case "OPC"
                OpcLogo.Visible = True
            Case "CRITT"
                CritLogo.Visible = True
            Case "WEST"
                WestLogo.Visible = True
            Case "MCCALL"
                McCallLogo.Visible = True
            Case "CLA"
                ClarkLogo.Visible = True
            Case "TRU"
                TruLogo.Visible = True
            Case "NWEST"
                NwestLogo.Visible = True
        End Select

    End Sub

    Private Sub PageFooter_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageFooter.Format
        ' Fix for view-all where the statementid at the bottom of the page was incorrect.  Now sets it correctly.

        'picSignature.Top = rtbActive.Height + rtbActive.Top




        'Dim dt As New DataTable
        'Dim iCustID As String = Me.DataLayer.Fields.Item("itbjscustomerid").Value.ToString
        'Select Case iCustID
        '    Case 19750
        '        TextBox51.Text = "pay.balancecollect.com/m/sagedental"
        '        'GENERATE QR CODE
        '        Try
        '            Dim sURL As String = "pay.balancecollect.com/m/sagedental"
        '            Dim oBitMaap As System.Drawing.Bitmap = GenerateQRCode(sURL, Color.Black, Color.White)
        '            Picture1.Image = oBitMaap

        '        Catch ex As Exception
        '            Dim sError As String = ex.Message.ToString

        '        End Try

        'End Select




        txtFooterStatementID.Text = TheStatementID
    End Sub


    Private Sub GetAddressesFromDB()
        Using sqlcon As New SqlConnection("Data Source=ECLIPSESQL;Initial Catalog=Statement;user id=tbjs2;password=2828tbjs2;Trusted_Connection=FALSE;")
            Dim cmd As New SqlCommand("SPL_Get_DB_Addresses", sqlcon)
            cmd.CommandType = CommandType.StoredProcedure
            Dim iTBJScustID As Integer = Me.DataLayer.Fields("itbjscustomerid").Value
            cmd.Parameters.AddWithValue("itbjscustomerid", iTBJScustID)
            sqlcon.Open()
            Dim dt As New DataTable
            dt.Load(cmd.ExecuteReader())
            Try
                If dt.Rows(0)(8).ToString = "True" Then
                    If Not dt.Rows(0).IsNull(0) Then If dt.Rows(0)(0).ToString <> String.Empty Then txtcfrom1.Text = dt.Rows(0)(0).ToString.ToUpper
                    If Not dt.Rows(0).IsNull(1) Then If dt.Rows(0)(1).ToString <> String.Empty Then txtcfrom2.Text = dt.Rows(0)(1).ToString.ToUpper
                    If Not dt.Rows(0).IsNull(2) Then If dt.Rows(0)(2).ToString <> String.Empty Then txtcfrom3.Text = dt.Rows(0)(2).ToString.ToUpper
                    If Not dt.Rows(0).IsNull(3) Then If dt.Rows(0)(3).ToString <> String.Empty Then txtcfrom4.Text = dt.Rows(0)(3).ToString.ToUpper
                End If
                If dt.Rows(0)(9).ToString = "True" Then
                    If Not dt.Rows(0).IsNull(4) Then If dt.Rows(0)(4).ToString <> String.Empty Then txtcremitto1.Text = dt.Rows(0)(4).ToString.ToUpper
                    If Not dt.Rows(0).IsNull(5) Then If dt.Rows(0)(5).ToString <> String.Empty Then txtcremitto2.Text = dt.Rows(0)(5).ToString.ToUpper
                    If Not dt.Rows(0).IsNull(6) Then If dt.Rows(0)(6).ToString <> String.Empty Then txtcremitto3.Text = dt.Rows(0)(6).ToString.ToUpper
                    If Not dt.Rows(0).IsNull(7) Then If dt.Rows(0)(7).ToString <> String.Empty Then txtcremitto4.Text = dt.Rows(0)(7).ToString.ToUpper
                End If
            Catch
            End Try
        End Using
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

    Private Sub InserterHeader_Format(sender As Object, e As EventArgs) Handles InserterHeader.Format

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




        txtcfrom1.Text = txtcfrom1.Text.ToUpper
        txtcfrom2.Text = txtcfrom2.Text.ToUpper
        txtcfrom3.Text = txtcfrom3.Text.ToUpper
        txtcfrom4.Text = txtcfrom4.Text.ToUpper
        txtcremitto1.Text = txtcremitto1.Text.ToUpper
        txtcremitto2.Text = txtcremitto2.Text.ToUpper
        txtcremitto3.Text = txtcremitto3.Text.ToUpper
        txtcremitto4.Text = txtcremitto4.Text.ToUpper
        txtcsendto1.Text = txtcsendto1.Text.ToUpper
        txtcsendto2.Text = txtcsendto2.Text.ToUpper
        txtcsendto3.Text = txtcsendto3.Text.ToUpper
        txtcsendto4.Text = txtcsendto4.Text.ToUpper

        If txtcsendto3.Text = "" Then
            txtcsendto3.Text = txtcsendto4.Text
            txtcsendto4.Text = ""
        End If

    End Sub

    Private Sub PastDue_ReportStart(sender As Object, e As EventArgs) Handles MyBase.ReportStart

    End Sub

    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub
End Class
