Module Module1


    Dim cPDF As New CreatePDF()


    Sub Main(ByVal cmdArgs() As String)
        Try
            cPDF.cPDF(cmdArgs)

        Catch ex As Exception
            Console.WriteLine(ex.Message)

        End Try
    End Sub

End Module
