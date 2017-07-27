
Public Class SearchStudent

    Public Function EvaluateInput(ByVal StudentNumber As String) As Boolean
        Dim Decision As Boolean = False
        If IsNumeric(StudentNumber) And StudentNumber.Length = 9 Then
            Decision = True
        End If
        Return Decision
    End Function

End Class

