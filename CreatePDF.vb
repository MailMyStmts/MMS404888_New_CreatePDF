Imports System.IO
Imports ComponentPro.Net
Imports PDFTRON
Imports PDFTRON.PDF
Imports Aspose.Pdf
Imports System.Data.SqlClient

Public Class CreatePDF
    Inherits PFHOutputCommon10_3.db
    Dim bFoundError As Boolean
    Private ar As New StatementOS
    Private al As New Letters
    Private FileID As String = ""
    Private StatementID As String = ""
    Private JobID As String = ""
    Private NumArgs As Integer
    Private sClientID As String = "0"
    Private sOrigFileName As String = ""
    Private CombinedFileName As String = ""
    Private sql_db As New MainSQLClass
    Private iWatermark As String = ""
    Dim iTotalStatements, iRowStart, iRowEnd, iCount_Statements, iCurrentWave, iNumWaves As Integer
    Dim tmpFolder As String = "c:\temp\" & Guid.NewGuid.ToString

    Sub New()
        MyBase.New()
    End Sub

    Public Sub cPDF(ByVal cmdArgs() As String)

        NumArgs = cmdArgs.Length


        If NumArgs = 3 And Int(cmdArgs(0)) <> 0 Then          ' View All / North Processing
            ' Create the view all and set page counts.
            FileID = Int(cmdArgs(0))

            ' Create the individual / combined file
            CreateCombinedFile(cmdArgs, True)
            If Not GetTest() Then SplitRenamePost()

        ElseIf NumArgs = 4 And Int(cmdArgs(0)) > 0 Then      ' Exporting
            ' Create the view all and dump to job directory
            FileID = Int(cmdArgs(0))
            JobID = Int(cmdArgs(3))

            ' Create the individual / combined file
            CreateCombinedFile(cmdArgs)
            'stamp the statement ID with the current date and time in the PrintJobStatements table
            'SetRunDateFile(FileID)

            'Split the file into the job directory
            'SplitCombinedFile(cmdArgs)
            Dim Directory As New IO.DirectoryInfo(tmpFolder)
            Dim allFiles As IO.FileInfo() = Directory.GetFiles("*.pdf")
            Dim singleFile As IO.FileInfo
            Dim sPrintJobPath As String = "C:\PayForHealth\PrintService\PDF\" + JobID.ToString + "\"

            For Each singleFile In allFiles
                Console.WriteLine(singleFile.FullName)

                If File.Exists(singleFile.FullName) Then
                    SplitCombinedFile(singleFile.FullName, sPrintJobPath)
                End If
            Next

            Threading.Thread.Sleep(30000)

        Else
            ' Create the individual / combined file
            CreateCombinedFile(cmdArgs)
            'if we didn't get 3 or 4 arguments exit with the message below
            'Console.WriteLine("No arguments or wrong number of arguments...createpdf statementfileid watermark statementid")
        End If

    End Sub
    Private Function GetTest()
        Using sqlcon As New SqlConnection("Data Source=ECLIPSESQL;Initial Catalog=Statement;user id=tbjs2;password=2828tbjs2;Trusted_Connection=FALSE;")
            Dim cmd As New SqlCommand("SELECT bTest FROM STATEMENTFILE WHERE iStatementFileID =" & FileID, sqlcon)
            cmd.CommandType = CommandType.Text
            sqlcon.Open()
            Return Convert.ToBoolean(cmd.ExecuteScalar())
        End Using
    End Function
    Sub CreateCombinedFile(ByVal cmdArgs() As String, Optional ByVal bPrintAll As Boolean = False)
        Console.WriteLine("Start: " & Now())

        iStatementFileID = Int(cmdArgs(0))
        iWatermark = Int(cmdArgs(1))
        iStatementID = Int(cmdArgs(2))

        If iStatementFileID > 0 Then
            ' Create temp directory to hold the pdf files..
            tmpFolder += "_" & iStatementFileID & "\"
            If Directory.Exists(tmpFolder) Then
                Try
                    Directory.Delete(tmpFolder, True)
                Catch ex As Exception
                    Console.WriteLine("Couldn't delete: " & tmpFolder)
                End Try
            End If

            Try
                Directory.CreateDirectory(tmpFolder)
            Catch ex As Exception
                Console.WriteLine("Couldn't create: " & tmpFolder)
                Exit Sub
            End Try

            'Dim iStmtsPerWave As Integer = 10
            OpenDB()
            If bPrintAll Then
                iTotalStatements = GetStatementCount_ALL(iStatementFileID)
            Else
                iTotalStatements = GetStatementCount(iStatementFileID)          ' Find out how many statements there are
            End If
            Console.WriteLine("Statements: " & iTotalStatements)
            'iStatementsPerWave = My.Settings.StatementsPerWave '10          ' How many statements per wave (pulled from PFH OUTPUT COMMON now)
            iNumWaves = Math.Ceiling(iTotalStatements / iStatementsPerWave)      ' Determine how many waves
            'iNumWaves = Math.Ceiling(iTotalStatements / iStmtsPerWave)
            For iCurrentWave = 1 To iNumWaves
                Console.WriteLine("RUNNING WAVE: " & iCurrentWave & " / " & iNumWaves & " (" & iStatementsPerWave & ") " & Now())
                'Console.WriteLine("RUNNING WAVE: " & iCurrentWave & " / " & iNumWaves & " (" & iStmtsPerWave & ") " & Now())
                iRowStart = iRowEnd + 1
                iRowEnd = iRowStart + iStatementsPerWave - 1
                'iRowEnd = iRowStart + iStmtsPerWave - 1
                CreateDoc(bPrintAll)
            Next



            'Set page counts
            If NumArgs = 3 And Int(iStatementFileID) > 0 Then
                Console.WriteLine("")
                Console.WriteLine("Setting Page Count " & Now())
                Console.WriteLine("Num Pages: " & iPageCount)
                Console.WriteLine("Num Statements: " & iTotalStatements)
                OpenDB()
                SetPageCount()
                CloseDB()
            End If


        Else
            CreateDoc()
        End If

            If CheckConnection() Then
                CloseDB()
            End If

            Console.WriteLine("End: " & Now())

    End Sub
    Public Sub Log(ByVal Message As String)
        Try
            Dim file As System.IO.StreamWriter
            Dim path As String = "c:\PayForHealth\Processing\Maps\MMS404888\UploadLog_" + Now().ToShortDateString.Replace("/", "-") + ".txt"
            file = My.Computer.FileSystem.OpenTextFileWriter(path, True)
            file.WriteLine(Message)
            file.Close()
        Catch
        End Try
    End Sub
    Public Function GetStatementCount_ALL(ByVal TheFileID As Integer)
        ' Returns all statements for a given statementfileid
        'OpenDB()
        cmd.CommandType = CommandType.Text

        cmd.CommandText = "SELECT COUNT(*) FROM statement WHERE iStatementFileID=" + TheFileID.ToString

        Return cmd.ExecuteScalar()

    End Function
    Sub SplitCombinedFile(ByVal input_file As String, ByVal output_path As String)
        Using op As New Process
            op.StartInfo.FileName = "C:\PayForHealth\Processing\Maps\MMS972792\CreatePDF\PDF_Splitter\PDF_Splitter.exe"
            op.StartInfo.Arguments = input_file + " " + output_path
            op.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            op.Start()

            op.WaitForExit(3600)
        End Using
    End Sub
    Private Sub No_Mail(ByVal File_ID As Integer)

        Dim sSQL As String = "SPU_SetToNOMAIL 5.00," + File_ID.ToString
        sql_db.SQLQryString = sSQL
        sql_db.ExecuteQry()

    End Sub
    Private Sub Apply_Business_Rules(ByVal File_ID As Integer)

        Console.WriteLine("Applying Business Rules")
        Dim sSQL As String = "SP_BusinessRules_MMS404888 " + File_ID.ToString
        sql_db.SQLQryString = sSQL
        sql_db.ExecuteQry()

    End Sub
    Private Sub CreateDoc(Optional ByVal bPrintAll As Boolean = False)
        'open a connection to the database
        If OpenDB() = True Then

            Dim dt As New DataTable
            If NumArgs = 3 And iStatementID > 0 Then
                dt = PrintStatement()
            Else
                dt = PrintStatement_Range(iRowStart, iRowEnd)
            End If

            'Dim dt As New DataTable
            Dim letterString As String = dt.Rows(0).Item("ccustom7").ToString
            'WELCOME LETTER
            If letterString = "WL" Or letterString = "WL1" Then
                Dim newDOC = New Letters()
                If iWatermark = 1 Then
                    bWaterMark = True
                    newDOC.g_watermark = True
                    newDOC.WatermarkPath = cWatermarkPath
                End If

                SetTopLocations()

                ''Brand LOGOS
                'al.ClarkLogo.Visible = False
                'al.OrkinLogo.Visible = False
                'al.HomeLogo.Visible = False
                'al.ClarkLogo.Visible = False
                'al.BugLogo.Visible = False
                'al.PermLogo.Visible = False
                'al.WestLogo.Visible = False
                'al.WaltLogo.Visible = False
                'al.TruLogo.Visible = False
                'al.RollinsLogo.Visible = False
                'al.OpcLogo.Visible = False
                'al.CritLogo.Visible = False
                'al.McCallLogo.Visible = False

                'Dim brand As String = dt.Rows(0).Item("ccustom10").ToString
                'If brand = "ORK" Then
                '    al.OrkinLogo.Visible = True
                'End If
                'If brand = "BUG" Then
                '    al.BugLogo.Visible = True
                'End If
                'If brand = "WALT" Then
                '    al.WaltLogo.Visible = True
                'End If
                'If brand = "PERM" Then
                '    al.PermLogo.Visible = True
                'End If
                'If brand = "HOME" Then
                '    al.HomeLogo.Visible = True
                'End If
                'If brand = "OPC" Then
                '    al.OpcLogo.Visible = True
                'End If
                'If brand = "CRITT" Then
                '    al.CritLogo.Visible = True
                'End If
                'If brand = "WEST" Then
                '    al.WestLogo.Visible = True
                'End If
                'If brand = "MCCALL" Then
                '    al.McCallLogo.Visible = True
                'End If
                'If brand = "TRU" Then
                '    al.TruLogo.Visible = True
                'End If
                'If brand = "NWEST" Then
                '    al.NwestLogo.Visible = True
                'End If



                If iStatementFileID > 0 Then
                    'No_Mail(iStatementFileID)
                    Apply_Business_Rules(iStatementFileID)
                End If

                'set the return envelope value
                newDOC.g_Bre = GetReturnEnvelope(iStatementFileID)

                'set the statementcount property
                If iStatementID = 0 Then
                    iStatementCount = GetStatementCount()
                Else
                    iStatementCount = 1
                End If

                ''Dim dt As New DataTable
                'If NumArgs = 3 And iStatementID > 0 Then
                '    dt = PrintStatement()
                'Else
                '    If bPrintAll Then
                '        dt = PrintStatement_All(iRowStart, iRowEnd)
                '    Else
                '        dt = PrintStatement_Range(iRowStart, iRowEnd)
                '    End If
                'End If


                If NumArgs = 3 And iStatementFileID > 0 Then
                    newDOC.bPrint = False
                ElseIf NumArgs = 4 Then
                    newDOC.bPrint = True
                Else
                    newDOC.bPrint = False
                End If

                'if the statementfileid is zero grab it from the printstatement datatable
                If iStatementFileID = 0 Then
                    Try
                        iStatementFileID = dt.Rows(0).Item("iStatementFileID")
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End If

                'Console.WriteLine("Creating Statements " & Now())

                'get the credit card bits to set the visible property on images and checkboxes for credit cards
                SetCCProperties()

                'set the datasource for the document
                newDOC.DataSource = dt

                Try
                    newDOC.Run()
                Catch ex As Exception
                    Console.WriteLine("Failure on ar.run method " + ControlChars.NewLine + ex.Message)
                End Try

                'set the filename, call the export method and pass the ar doc, filename and type (single statement or batch)
                Dim filename As String = ""
                Dim newDocFileName As String = ""
                If iStatementID > 0 Then
                    'filename = iStatementID.ToString + ".pdf"
                    newDocFileName = iStatementID.ToString + ".pdf"
                    Console.WriteLine("Exporting file " + ex.cExportPath(PFHOutputCommon10_3.Export.ExportTypes.SingleStatement) + newDocFileName & " " & Now())
                    ex.ExportToPDF(newDOC, newDocFileName, PFHOutputCommon10_3.Export.ExportTypes.SingleStatement)
                Else
                    GC.Collect()
                    'System.Threading.Thread.Sleep(10000)
                    newDocFileName = iStatementFileID.ToString + "_" & iCurrentWave & ".pdf"
                    CombinedFileName = tmpFolder + newDocFileName
                    ex.ExportToPDF(newDOC, CombinedFileName)
                End If

                'if this is a batch set the pagecount column in the statementfile table
                iPageCount += newDOC.Document.Pages.Count

                newDOC.Document.Dispose()
                newDOC.Dispose()
                newDOC = Nothing
                GC.Collect()

                newDOC = New StatementOS

                'INVOICE
            ElseIf letterString = "INV1" Then
                Dim newDOC = New Invoice()
                If iWatermark = 1 Then
                    bWaterMark = True
                    newDOC.g_watermark = True
                    newDOC.WatermarkPath = cWatermarkPath
                End If

                SetTopLocations()

                If iStatementFileID > 0 Then
                    'No_Mail(iStatementFileID)
                    Apply_Business_Rules(iStatementFileID)
                End If

                'set the return envelope value
                newDOC.g_Bre = GetReturnEnvelope(iStatementFileID)

                'set the statementcount property
                If iStatementID = 0 Then
                    iStatementCount = GetStatementCount()
                Else
                    iStatementCount = 1
                End If

                ''Dim dt As New DataTable
                'If NumArgs = 3 And iStatementID > 0 Then
                '    dt = PrintStatement()
                'Else
                '    If bPrintAll Then
                '        dt = PrintStatement_All(iRowStart, iRowEnd)
                '    Else
                '        dt = PrintStatement_Range(iRowStart, iRowEnd)
                '    End If
                'End If

                If NumArgs = 3 And iStatementFileID > 0 Then
                    newDOC.bPrint = False
                ElseIf NumArgs = 4 Then
                    newDOC.bPrint = True
                Else
                    newDOC.bPrint = False
                End If

                'if the statementfileid is zero grab it from the printstatement datatable
                If iStatementFileID = 0 Then
                    Try
                        iStatementFileID = dt.Rows(0).Item("iStatementFileID")
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End If

                'Console.WriteLine("Creating Statements " & Now())

                'get the credit card bits to set the visible property on images and checkboxes for credit cards
                SetCCProperties()

                'set the datasource for the document
                newDOC.DataSource = dt

                Try
                    newDOC.Run()
                Catch ex As Exception
                    Console.WriteLine("Failure on ar.run method " + ControlChars.NewLine + ex.Message)
                End Try

                'set the filename, call the export method and pass the ar doc, filename and type (single statement or batch)
                Dim filename As String = ""
                Dim newDocFileName As String = ""
                If iStatementID > 0 Then
                    'filename = iStatementID.ToString + ".pdf"
                    newDocFileName = iStatementID.ToString + ".pdf"
                    Console.WriteLine("Exporting file " + ex.cExportPath(PFHOutputCommon10_3.Export.ExportTypes.SingleStatement) + newDocFileName & " " & Now())
                    ex.ExportToPDF(newDOC, newDocFileName, PFHOutputCommon10_3.Export.ExportTypes.SingleStatement)
                Else
                    GC.Collect()
                    'System.Threading.Thread.Sleep(10000)
                    newDocFileName = iStatementFileID.ToString + "_" & iCurrentWave & ".pdf"
                    CombinedFileName = tmpFolder + newDocFileName
                    ex.ExportToPDF(newDOC, CombinedFileName)
                End If

                'if this is a batch set the pagecount column in the statementfile table
                iPageCount += newDOC.Document.Pages.Count

                newDOC.Document.Dispose()
                newDOC.Dispose()
                newDOC = Nothing
                GC.Collect()

                newDOC = New StatementOS

                'PAST DUE
            ElseIf letterString = "PD" Or letterString = "PD1" Or letterString = "PD2" Or letterString = "PD3" Or letterString = "PD4" Or letterString = "PD5" Then
                Dim newDOC = New PastDue()
                If iWatermark = 1 Then
                    bWaterMark = True
                    newDOC.g_watermark = True
                    newDOC.WatermarkPath = cWatermarkPath
                End If

                SetTopLocations()

                If iStatementFileID > 0 Then
                    'No_Mail(iStatementFileID)
                    Apply_Business_Rules(iStatementFileID)
                End If

                'set the return envelope value
                newDOC.g_Bre = GetReturnEnvelope(iStatementFileID)

                'set the statementcount property
                If iStatementID = 0 Then
                    iStatementCount = GetStatementCount()
                Else
                    iStatementCount = 1
                End If

                ''Dim dt As New DataTable
                'If NumArgs = 3 And iStatementID > 0 Then
                '    dt = PrintStatement()
                'Else
                '    If bPrintAll Then
                '        dt = PrintStatement_All(iRowStart, iRowEnd)
                '    Else
                '        dt = PrintStatement_Range(iRowStart, iRowEnd)
                '    End If
                'End If

                If NumArgs = 3 And iStatementFileID > 0 Then
                    newDOC.bPrint = False
                ElseIf NumArgs = 4 Then
                    newDOC.bPrint = True
                Else
                    newDOC.bPrint = False
                End If

                'if the statementfileid is zero grab it from the printstatement datatable
                If iStatementFileID = 0 Then
                    Try
                        iStatementFileID = dt.Rows(0).Item("iStatementFileID")
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End If

                'Console.WriteLine("Creating Statements " & Now())

                'get the credit card bits to set the visible property on images and checkboxes for credit cards
                SetCCProperties()

                'set the datasource for the document
                newDOC.DataSource = dt

                Try
                    newDOC.Run()
                Catch ex As Exception
                    Console.WriteLine("Failure on ar.run method " + ControlChars.NewLine + ex.Message)
                End Try

                'set the filename, call the export method and pass the ar doc, filename and type (single statement or batch)
                Dim filename As String = ""
                Dim newDocFileName As String = ""
                If iStatementID > 0 Then
                    'filename = iStatementID.ToString + ".pdf"
                    newDocFileName = iStatementID.ToString + ".pdf"
                    Console.WriteLine("Exporting file " + ex.cExportPath(PFHOutputCommon10_3.Export.ExportTypes.SingleStatement) + newDocFileName & " " & Now())
                    ex.ExportToPDF(newDOC, newDocFileName, PFHOutputCommon10_3.Export.ExportTypes.SingleStatement)
                Else
                    GC.Collect()
                    'System.Threading.Thread.Sleep(10000)
                    newDocFileName = iStatementFileID.ToString + "_" & iCurrentWave & ".pdf"
                    CombinedFileName = tmpFolder + newDocFileName
                    ex.ExportToPDF(newDOC, CombinedFileName)
                End If

                'if this is a batch set the pagecount column in the statementfile table
                iPageCount += newDOC.Document.Pages.Count

                newDOC.Document.Dispose()
                newDOC.Dispose()
                newDOC = Nothing
                GC.Collect()

                newDOC = New StatementOS
            End If
        Else
            Console.WriteLine("Failed to open DB")
        End If
    End Sub
    Function PrintStatement_All()
        Using sqlcon As New SqlConnection("Data Source=ECLIPSESQL;Initial Catalog=Statement;user id=tbjs2;password=2828tbjs2;Trusted_Connection=FALSE;")
            Dim cmd As New SqlCommand("SP_PrintStatement_All", sqlcon)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("statementfileid", FileID)
            sqlcon.Open()
            Dim dt As New DataTable
            dt.Load(cmd.ExecuteReader)
            PrintStatement_All = dt
        End Using
    End Function
    Function PrintStatement_All(ByVal iRowStart As Integer, ByVal iRowEnd As Integer)
        Using sqlcon As New SqlConnection("Data Source=ECLIPSESQL;Initial Catalog=Statement;user id=tbjs2;password=2828tbjs2;Trusted_Connection=FALSE;")
            Dim cmd As New SqlCommand("SP_PrintStatement_All_Range", sqlcon)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("statementfileid", FileID)
            cmd.Parameters.AddWithValue("RowStart", iRowStart)
            cmd.Parameters.AddWithValue("RowEnd", iRowEnd)
            sqlcon.Open()
            Dim dt As New DataTable
            dt.Load(cmd.ExecuteReader)
            PrintStatement_All = dt
        End Using
    End Function
    Sub SplitRenamePost()

        Dim dt As New DataTable
        dt = PrintStatement_All()

        Dim sGUID As String
        sGUID = System.Guid.NewGuid.ToString()
        'sGUID = "boogers"
        Dim sDumpLocation As String = "C:\temp\" & sGUID & "\"

        If Directory.Exists(sDumpLocation) = False Then
            Console.WriteLine("1) Creating Directory... " & sDumpLocation)
            Directory.CreateDirectory(sDumpLocation)
        Else
            Dim myFile As String
            Dim mydir As String = sDumpLocation '"C:\temp\boogers\"
            For Each myFile In Directory.GetFiles(mydir, "*.pdf")
                File.Delete(myFile)
            Next
            For Each myFile In Directory.GetFiles(mydir, "*.zip")
                File.Delete(myFile)
            Next
        End If

        Dim fileArray2 As String()
        Dim sfile As String
        fileArray2 = Directory.GetFiles(tmpFolder, "*.pdf")
        Try
            For Each sfile In fileArray2
                If File.Exists(sfile) Then
                    Dim oprocess As New Process
                    Dim sArguments As String = " " & sfile & " " & sDumpLocation
                    Console.WriteLine("File to Split... " & sfile)
                    Console.WriteLine("2) Splitting Combined File... " & sArguments)
                    oprocess.StartInfo.FileName = "C:\payforhealth\processing\maps\mms972792\createpdf\pdf_splitter\pdf_splitter.exe" 'cPDFSplitterExe
                    oprocess.StartInfo.Arguments = sArguments.ToString
                    oprocess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden

                    oprocess.Start()

                    'wait up to 1 hour to process
                    If oprocess.WaitForExit(3600000) Then
                        If oprocess.HasExited Then
                            'all is well
                        Else
                            Throw New Exception("PDF Splitter timed out")
                        End If
                    Else
                        Throw New Exception("PDF Splitter timed out")
                    End If

                    oprocess.Dispose()

                    Try
                        File.Delete(sfile)
                    Catch ex As Exception
                        ' Some kind of error.. *shrug*
                    End Try
                Else
                    ' no combined file.. 
                    Throw New Exception("Combined file was not created")
                End If
            Next
        Catch ex As Exception
            Console.WriteLine("PDF Splitter Error... " & ex.ToString)
        End Try


        sOrigFileName = ""
        fileArray2 = Directory.GetFiles(sDumpLocation, "*.pdf")
        For Each sfile In fileArray2
            Dim sFields As String() = sfile.Split("\")
            Dim sFileName As String = sFields(sFields.Length - 1).ToString.ToLower
            sFileName = sFileName.Replace(".pdf", "")
            'sFileName is now the StatementID
            Console.WriteLine("3) Renaming File... " & sFileName)

            Dim dv As New DataView(dt, "istatementid = " & sFileName, "istatementid", DataViewRowState.OriginalRows)
            Dim sNewFileName As String = ""
            For Each rowView As DataRowView In dv
                Dim row As DataRow = rowView.Row
                sNewFileName = row("caccountno") & "-" & row("cstmtdate").ToString.Replace("/", "-")
                Console.WriteLine("4) New File Name... " & sNewFileName)
                If sOrigFileName = "" Then
                    sOrigFileName = row("corigfilename").ToString
                End If
                If sClientID = "0" Then
                    sClientID = row("itbjscustomerid").ToString
                End If
            Next
            File.Copy(sfile, sfile.Replace(sFileName, sNewFileName), True)
            Threading.Thread.Sleep(10)
            File.Delete(sfile)
        Next

        'Dim sWhat As String() = sOrigFileName.Split(".")
        'sOrigFileName = sWhat(0).Trim
        'Console.WriteLine("5) Orig File Name... " & sOrigFileName)

        'Dim sZipFileName As String = sOrigFileName & ".zip"
        'sZipFileName = sZipFileName.Replace(" ", "_")
        ''ZIP THE ENTIRE DIRECTORY
        'Console.WriteLine("6) Zip File Name... " & sZipFileName)

        'Dim oprocessX As New Process
        'Dim sArgumentsX As String = " a -tzip " & sDumpLocation & sZipFileName & " " & sDumpLocation & "*.pdf"
        'Console.WriteLine("Zipping TIFF files... " & sArgumentsX)
        'oprocessX.StartInfo.FileName = "c:\7-zip\7z.exe"
        'oprocessX.StartInfo.Arguments = sArgumentsX.ToString
        'Console.WriteLine("7) Zipping File... " & sZipFileName)
        'oprocessX.Start()

        ''wait up to 1 hour to process
        'If oprocessX.WaitForExit(3600000) Then
        '    If oprocessX.HasExited Then
        '        'all is well
        '    Else
        '        Throw New Exception("7-Zip timed out")
        '    End If
        'Else
        '    Throw New Exception("7-Zip timed out")
        'End If

        'oprocessX.Dispose()

        'POST TO FTP SITE.....
        Dim sPostMe As String = sDumpLocation ' & sZipFileName
        Dim sFTPUserName As String = ""
        Dim sFTPPassword As String = "rZ39TEuAgKESpzXH"

        If sClientID = "16167" Then
            sFTPUserName = "MMS404888"
        End If

        New_Upload(sPostMe, sFTPUserName, sFTPPassword)

        'DELETE LOCAL FILE AND LOCAL DIRECTORY
        Console.WriteLine("Sleeping for 15 seconds...")
        Threading.Thread.Sleep(15000)
        If Directory.Exists(sDumpLocation) Then
            Console.WriteLine("Deleting temp directory...")
            Directory.Delete(sDumpLocation, True)
        End If

    End Sub
    Public Sub New_Upload(ByVal _FolderName As String, ByVal _FTPUser As String, ByVal _FTPPass As String)
        Console.WriteLine("Preparing FTP object... " & Now())
        Log("Preparing to Upload " & Now())

        Console.WriteLine("Transferring ZIP... " & Now())
        Try
            Using client As New Sftp
                Console.WriteLine("Opening SFTP...")
                client.Connect("172.31.1.108")
                client.Authenticate(_FTPUser, _FTPPass)
                Console.WriteLine("Sending files... " + DateTime.Now.ToShortTimeString())
                For Each f As String In Directory.GetFiles(_FolderName)
                    client.UploadFile(f, "/pick/")
                    Console.WriteLine("Success: " + f + Environment.NewLine)
                    Log(f)
                Next
            End Using
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
        Console.WriteLine("Transfer done... " & Now())
    End Sub
    Public Sub SetCCProperties()
        CustomizeStatement(ar)
    End Sub

    Private Sub SetTopLocations()
        'this will lower the top location of the addresses so they show through the envelope windows as the inserters
        'folding configuration may change this will prevent from changing each createpdf to match
        'ar.txtcsendto1.Top = a.cSendto1Top
        'ar.txtcsendto2.Top = ar.txtcsendto1.Top + ar.txtcsendto1.Height
        'ar.txtcsendto3.Top = ar.txtcsendto2.Top + ar.txtcsendto2.Height
        'ar.txtcsendto4.Top = ar.txtcsendto3.Top + ar.txtcsendto3.Height

        'ar.txtcfrom1.Top = a.cfrom1top
        'ar.txtcfrom2.Top = ar.txtcfrom1.Top + ar.txtcfrom1.Height
        'ar.txtcfrom3.Top = ar.txtcfrom2.Top + ar.txtcfrom2.Height
        'ar.txtcfrom4.Top = ar.txtcfrom3.Top + ar.txtcfrom3.Height

        'ar.txtPhoneNum.Top = ar.txtcfrom3.Top + ar.txtcfrom3.Height + 0.05

        'ar.txtcremitto1.Top = a.cremitto1Top
        'ar.txtcremitto2.Top = ar.txtcremitto1.Top + ar.txtcremitto1.Height
        'ar.txtcremitto3.Top = ar.txtcremitto2.Top + ar.txtcremitto2.Height
        'ar.txtcremitto4.Top = ar.txtcremitto3.Top + ar.txtcremitto3.Height


        'this will set the left locations of all of the addresses
        'ar.txtcsendto1.Left = a.csendtoLeft
        'ar.txtcsendto2.Left = a.csendtoLeft
        'ar.txtcsendto3.Left = a.csendtoLeft
        'ar.txtcsendto4.Left = a.csendtoLeft

        'ar.txtcfrom1.Left = a.cfromLeft
        'ar.txtcfrom2.Left = a.cfromLeft
        'ar.txtcfrom3.Left = a.cfromLeft
        'ar.txtcfrom4.Left = a.cfromLeft

        'ar.txtPhoneNum.Left = a.cfromLeft

        'ar.txtcremitto1.Left = a.cremittoLeft
        'ar.txtcremitto2.Left = a.cremittoLeft
        'ar.txtcremitto3.Left = a.cremittoLeft
        'ar.txtcremitto4.Left = a.cremittoLeft

    End Sub
End Class