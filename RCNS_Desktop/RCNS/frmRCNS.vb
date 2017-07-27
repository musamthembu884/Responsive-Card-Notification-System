Public Class frmRCNS

    Private SNData As SNDatabase
    Private Const Home As String = "index2"
    Private Const RegisterCard As String = "index3"
    Private Const SearchCard As String = "index4"
    Private Const RetrieveCard As String = "index5"
    Private Const Stats As String = "index6"
    Private StudentNumber As String


    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim URL As New System.Uri(My.Application.Info.DirectoryPath & "\source\index.html")
        WebControl1.Source = URL
        WebControl1.Reload(True)
        If WebControl1.IsDocumentReady Then
            BWStats2.RunWorkerAsync()
        End If


        Timer1.Start()

        SNData = New SNDatabase
    End Sub

    Dim c As Integer

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If WebControl1.IsDocumentReady Then
            Dim btnGo As String = WebControl1.ExecuteJavascriptWithResult("document.getElementById('Clicked').innerHTML")
           

            If WebControl1.Title <> Stats Then
                c = 0
            End If

            If WebControl1.Title = Stats And c = 0 Then
                c += 1
                Try
                    BWStats2.RunWorkerAsync()
                Catch ex As Exception : End Try

            End If

            If btnGo = "Clicked" And WebControl1.Title = RegisterCard Then
                WebControl1.ExecuteJavascriptWithResult("document.getElementById('Clicked').innerHTML=""NULL""")

                StudentNumber = WebControl1.ExecuteJavascriptWithResult("document.getElementById('txtStudentNumber').value")

                BWRegisterCard.RunWorkerAsync()

            End If

            If btnGo = "Clicked" And WebControl1.Title = SearchCard Then
                WebControl1.ExecuteJavascriptWithResult("document.getElementById('Clicked').innerHTML=""NULL""")

                StudentNumber = WebControl1.ExecuteJavascriptWithResult("document.getElementById('txtStudentNumber').value")

                BWSearch.RunWorkerAsync()
            End If

            If btnGo = "Clicked" And WebControl1.Title = RetrieveCard Then
                WebControl1.ExecuteJavascriptWithResult("document.getElementById('Clicked').innerHTML=""NULL""")

                StudentNumber = WebControl1.ExecuteJavascriptWithResult("document.getElementById('txtStudentNumber').value")

                BWRetrieve.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub BWRegisterCard_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BWRegisterCard.DoWork
        SNData.AddSN(StudentNumber)

    End Sub

    Private Sub BWRegisterCard_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWRegisterCard.RunWorkerCompleted
        WebControl1.ExecuteJavascriptWithResult("document.getElementById('Go').style.backgroundImage = 'url(next.png)'")
        StudentNumber = WebControl1.ExecuteJavascriptWithResult("document.getElementById('txtStudentNumber').value = ' '")
        WebControl1.Reload(False)
    End Sub

    Private Sub BWSearch_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BWSearch.DoWork
        If SNData.SearchData(StudentNumber) Then
            MsgBox("Student Card Found", MsgBoxStyle.Information)
        Else
            MsgBox("Student Card Not Found", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BWSearch_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWSearch.RunWorkerCompleted
        WebControl1.ExecuteJavascriptWithResult("document.getElementById('Go').style.backgroundImage = 'url(next.png)'")
        StudentNumber = WebControl1.ExecuteJavascriptWithResult("document.getElementById('txtStudentNumber').value = ' '")
        WebControl1.Reload(False)
    End Sub

    Private Sub BWRetrieve_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BWRetrieve.DoWork
        If SNData.SearchData(StudentNumber) Then
            If SNData.RetrieveData(StudentNumber) Then
                MsgBox("Student Card Retrieved", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Student Card Not Found", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BWRetrieve_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWRetrieve.RunWorkerCompleted
        WebControl1.ExecuteJavascriptWithResult("document.getElementById('Go').style.backgroundImage = 'url(next.png)'")
        '  WebControl1.ExecuteJavascriptWithResult("document.getElementById('CHK').style.backgroundImage = 'none'")
        StudentNumber = WebControl1.ExecuteJavascriptWithResult("document.getElementById('txtStudentNumber').value = ' '")
        WebControl1.Reload(False)
    End Sub

    Public stats1 As Integer = -1
    Public stats2 As Integer = -1
    Private Sub BWStats_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BWStats.DoWork
        stats1 = SNData.StudentCardsCount()
    End Sub

    Private Sub BWStats_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWStats.RunWorkerCompleted
        WebControl1.ExecuteJavascriptWithResult("document.getElementById('LostCards').innerHTML = " & stats1 & "")
    End Sub

   
    Private Sub BWStats2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BWStats2.DoWork
        stats2 = SNData.CardsRetrieved()
    End Sub

  
    Private Sub BWStats2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWStats2.RunWorkerCompleted
        WebControl1.ExecuteJavascriptWithResult("document.getElementById('RecoveredCards').innerHTML = " & stats2 & "")

        Try
            BWStats.RunWorkerAsync()
        Catch ex As Exception : End Try

    End Sub

    Private Sub Awesomium_Windows_Forms_WebControl_ShowCreatedWebView(sender As Object, e As Awesomium.Core.ShowCreatedWebViewEventArgs) Handles WebControl1.ShowCreatedWebView

    End Sub
End Class
