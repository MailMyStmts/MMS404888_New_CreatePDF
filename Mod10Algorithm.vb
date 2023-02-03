Imports System.Linq
Public Class Mod10Algorithm
    'http://en.wikipedia.org/wiki/Luhn_algorithm

    ''' <summary>
    ''' add check digit to a number
    ''' </summary>
    ''' <param name="theNum">the number</param>
    ''' <returns>the number concatenated with check digit</returns>
    ''' <remarks></remarks>
    Public Shared Function AddChkDigiToNum(theNum As String) As String
        Dim chkDigit As Integer = CreateList(theNum, True).Sum * 9 Mod 10
        Return theNum & chkDigit.ToString
    End Function

    ''' <summary>
    ''' verify number with check digit is valid
    ''' </summary>
    ''' <param name="theNum">the number to validate</param>
    ''' <returns>true if valid</returns>
    ''' <remarks></remarks>
    Public Shared Function ValidateNum(theNum As String) As Boolean
        Dim chk As Integer = CreateList(theNum, False).Sum Mod 10
        Return chk = 0
    End Function

    Private Shared Function CreateList(theNum As String, doubleStart As Boolean) As List(Of Integer)
        Dim dblIt As Boolean = doubleStart
        Dim sums As New List(Of Integer)
        For x As Integer = theNum.Length - 1 To 0 Step -1
            Dim s As String = theNum(x)
            'skip non-numerics
            If Integer.TryParse(s, Nothing) Then
                If dblIt Then
                    sums.Add(RetrunDouble(s))
                Else
                    sums.Add(Integer.Parse(s))
                End If
                dblIt = Not dblIt
            End If
        Next
        Return sums
    End Function

    Private Shared Function RetrunDouble(n As String) As Integer
        Dim i As Integer = 2 * Integer.Parse(n) 'double the number
        If i.ToString.Length > 1 Then 'if length is > 1 then 
            'sum the individual digits
            Dim s As String = i.ToString
            i = 0
            For x As Integer = 0 To s.Length - 1
                i += Integer.Parse(s(x))
            Next
        End If
        Return i
    End Function
End Class
