Imports System.Net.Mail
Imports OpenPop.Pop3
Imports OpenPop.Mime
Imports OpenPop.Common
Imports MySql.Data.MySqlClient

Public Class SNDatabase

    Private Search As New SearchStudent

 
    Public CheckValidity As Boolean = False
    Private Mysqlcon As MySqlConnection
    Private COMMAND As MySqlCommand
    'Mysqlcon.ConnectionString = "server=sql5.freesqldatabase.com;userid=sql590396;password=iC8!vQ3%;database=sql590396"

    ' Private StringConnection As String = "server=server39.000webhost.com;userid=grillluu_sql3113;password=FxcqrFngWB;database=grillluu_sql3113886"



    Public Function CheckIfGone(AdminEmail As String, Password As String) As Boolean

        Dim localCheck As Boolean = False
        Dim client As New Pop3Client()
        client.Connect("pop.gmail.com", 995, True)
        client.Authenticate(AdminEmail, Password)
        'get number of messages in inbox
        Dim counter As Integer = client.GetMessageCount()

        If (counter >= 1) Then
            client.DeleteAllMessages()
            localCheck = True
            client.Disconnect()
        End If


        Return localCheck
    End Function

    Public Sub SendEmail(Subject As String, Body As String, Send_To As String, AdminEmail As String, AdminPassword As String, ByRef sent As Boolean)


        Try


            Dim mail As New MailMessage()
            mail.From = New MailAddress(AdminEmail)
            mail.To.Add(Send_To)
            mail.Subject = Subject
            mail.Body = Body

            Dim smtpServer As New SmtpClient("smtp.gmail.com")
            smtpServer.UseDefaultCredentials = False
            smtpServer.Credentials = New Net.NetworkCredential(AdminEmail, AdminPassword)
            smtpServer.Port = 587
            smtpServer.EnableSsl = True
            smtpServer.Send(mail)

            CheckValidity = CheckIfGone(AdminEmail, AdminPassword)

            If CheckValidity = False Then
                sent = True
            End If
            If CheckValidity = True Then
                MsgBox("Please Recheck Student Number")
            End If
        Catch ex As Exception
            sent = False


        End Try


    End Sub

    Public Function SearchData(StudentNumber As String) As Boolean
        Mysqlcon = New MySqlConnection
        Mysqlcon.ConnectionString = "server= sql5.freesqldatabase.com;userid=sql5118801;password=ZFHhEzCPwF;database=sql5118801"

        Try
            Mysqlcon.Open()
            Dim MyAdapter As New MySqlDataAdapter
            Dim SqlQuary = "SELECT * From RCNS WHERE student_number='" & StudentNumber & "'"
            Dim Command As New MySqlCommand
            Command.Connection = Mysqlcon
            Command.CommandText = SqlQuary
            MyAdapter.SelectCommand = Command
            Dim Mydata As MySqlDataReader
            Mydata = Command.ExecuteReader
            If Mydata.HasRows = 0 Then
                Return False
            Else
                Return True

            End If


        Catch ex As MySqlException
            MsgBox(ex.Message)

        Finally
            Mysqlcon.Dispose()
        End Try
    End Function

    Public Function InsertData(StudentNumber As String) As Boolean
        Mysqlcon = New MySqlConnection
        ' Mysqlcon.ConnectionString = "server=sql3.freesqldatabase.com;userid=sql3113886;password=FxcqrFngWB;database=sql3113886"
        Mysqlcon.ConnectionString = "server= sql5.freesqldatabase.com;userid=sql5118801;password=ZFHhEzCPwF;database=sql5118801"
        Dim READER As MySqlDataReader

        Try
            Mysqlcon.Open()
            Dim Query As String = "insert into RCNS (student_number,Location) values ('" & StudentNumber & "','APB')"
            COMMAND = New MySqlCommand(Query, Mysqlcon)
            READER = COMMAND.ExecuteReader

            Return True
            Mysqlcon.Close()
        Catch ex As MySqlException
            Return False

        Finally
            Mysqlcon.Dispose()
        End Try

    End Function

    Public Function RetrieveData(StudentNumber As String) As Boolean
        Mysqlcon = New MySqlConnection
        ' Mysqlcon.ConnectionString = "server=sql3.freesqldatabase.com;userid=sql3113886;password=FxcqrFngWB;database=sql3113886"
        Mysqlcon.ConnectionString = "server= sql5.freesqldatabase.com;userid=sql5118801;password=ZFHhEzCPwF;database=sql5118801"
        Dim READER As MySqlDataReader

        Try
            Mysqlcon.Open()
            Dim Query As String = "Delete from RCNS where student_number='" & StudentNumber & "'"
            COMMAND = New MySqlCommand(Query, Mysqlcon)
            READER = COMMAND.ExecuteReader

            UpdateCardsRetrieved()

            Mysqlcon.Close()
            Return True




        Catch ex As MySqlException
            MsgBox(ex.Message)

        Finally
            Mysqlcon.Dispose()
        End Try
    End Function

    Public Function StudentCardsCount() As Integer
        Mysqlcon = New MySqlConnection
        ' Mysqlcon.ConnectionString = "server=sql3.freesqldatabase.com;userid=sql3113886;password=FxcqrFngWB;database=sql3113886"
        Mysqlcon.ConnectionString = "server= sql5.freesqldatabase.com;userid=sql5118801;password=ZFHhEzCPwF;database=sql5118801"
        Try
            Mysqlcon.Open()
            Dim MyAdapter As New MySqlDataAdapter
            Dim SqlQuary = "SELECT COUNT(*) FROM RCNS"
            Dim Command As New MySqlCommand
            Command.Connection = Mysqlcon
            Command.CommandText = SqlQuary

            Dim value As Integer = Command.ExecuteScalar()

            Command = Nothing
            Mysqlcon.Close()

            Return value
        Catch ex As Exception

        End Try
    End Function

    Public Sub UpdateCardsRetrieved()
        Mysqlcon = New MySqlConnection
        ' Mysqlcon.ConnectionString = "server=sql3.freesqldatabase.com;userid=sql3113886;password=FxcqrFngWB;database=sql3113886"
        Mysqlcon.ConnectionString = "server= sql5.freesqldatabase.com;userid=sql5118801;password=ZFHhEzCPwF;database=sql5118801"
        Dim READER As MySqlDataReader

        Try
            Mysqlcon.Open()
            Dim Query As String = "UPDATE Counting SET count = count + 1 where id = 1"
            COMMAND = New MySqlCommand(Query, Mysqlcon)
            READER = COMMAND.ExecuteReader



            Mysqlcon.Close()
        Catch ex As MySqlException


        Finally
            Mysqlcon.Dispose()
        End Try

    End Sub



    Public Function CardsRetrieved() As Integer
        Mysqlcon = New MySqlConnection
        'Mysqlcon.ConnectionString = "server=sql5.freesqldatabase.com;userid=sql590396;password=iC8!vQ3%;database=sql590396"
        Mysqlcon.ConnectionString = "server= sql5.freesqldatabase.com;userid=sql5118801;password=ZFHhEzCPwF;database=sql5118801"
        Dim READER As MySqlDataReader

        Try
            Mysqlcon.Open()
            Dim Query As String = "SELECT * FROM Counting where id = 1"
            Dim Command As New MySqlCommand
            Command = New MySqlCommand(Query, Mysqlcon)
            READER = Command.ExecuteReader
            READER.Read()

            Dim value As Integer = CInt(READER("count").ToString)
            Return value


            Mysqlcon.Close()
        Catch ex As MySqlException


        Finally
            Mysqlcon.Dispose()
        End Try
    End Function

    Public Sub AddSN(StudentNumber As String)

        Dim sent As Boolean

        If Search.EvaluateInput(StudentNumber) And SearchData(StudentNumber) = False Then

            Dim subject As String = "Collection Of Your Card From University of Johannesburg"
            Dim Body As String = "Greetings" & vbCrLf & vbCrLf & "Our Notification system at the University of Johannesburg has indicated to us that you have lost your student card." & vbCrLf & vbCrLf & StudentNumber & " " & " has been received and it may be collected at the Student Enrolment Center APK Campus for a fee of R10." & vbCrLf & vbCrLf & "Yours Sincerly Admin UJ  APK Campus "
            SendEmail(subject, Body, StudentNumber & "@student.uj.ac.za", "universityofjohannesburg.card@gmail.com", "streetwise", sent)

            If sent = True Then
                InsertData(StudentNumber)
                MsgBox("Successfully Added!!", MsgBoxStyle.Information)
            End If

        ElseIf Search.EvaluateInput(StudentNumber) = False Then
            MsgBox("Invalid Student Number", MsgBoxStyle.Exclamation)
        Else
            MsgBox("Student Card Already Registed", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Public Sub New()

    End Sub
End Class
