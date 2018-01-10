Imports System.Threading
Imports System.Net.Sockets
Imports System.Net

Public Class Game
    Public isHost As Boolean
    Dim bw As IO.BinaryWriter
    Dim br As IO.BinaryReader
    Dim ipAddress As IPAddress

    Private communicationThread As Thread
    Dim connection As TcpClient


    Private Sub Game_Closwe(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        HomeScreen.Show()
    End Sub

    Private Sub Game_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim hostIp As String
        Dim host As String = System.Net.Dns.GetHostName()
        Dim LocalHostaddress As String = System.Net.Dns.GetHostEntry(host).AddressList(0).ToString()

        If isHost Then
            lblIP.Text = "Give this Ip to your friend " + LocalHostaddress

        Else
            hostIp = InputBox("What is the host IP?", "Connection", "")
            lblIP.Text = "Host IP : " + hostIp

        End If

        If isHost Then
            'Start the server listening port
            ipAddress = Dns.GetHostEntry(LocalHostaddress).AddressList(0)
            Dim listener As New TcpListener(ipAddress, 49552)
            listener.Start()
            connection = listener.AcceptTcpClient()

        Else
            'Connect to the server
            connection = New TcpClient
            connection.Connect(hostIp, 49552)


        End If

        bw = New IO.BinaryWriter(connection.GetStream())
        br = New IO.BinaryReader(connection.GetStream())
        communicationThread = New Thread(AddressOf communicationStart)

    End Sub


    Private Sub communicationStart()

        Do While True

            Dim message As String
            message = br.ReadString
            MsgBox(message)
            If isHost Then

                If message = "U" Then
                    objPlayer2.SetBounds(objPlayer2.Left, objPlayer2.Top + 15, 25, 130)
                ElseIf message = "D" Then
                    objPlayer2.SetBounds(objPlayer2.Left, objPlayer2.Top + 15, 25, 130)
                End If
            Else
                If message = "U" Then
                    objPlayer1.SetBounds(objPlayer1.Left, objPlayer1.Top + 15, 25, 130)
                ElseIf message = "D" Then
                    objPlayer1.SetBounds(objPlayer1.Left, objPlayer1.Top + 15, 25, 130)
                End If
            End If
        Loop
    End Sub

    Private Sub Game_Load(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If isHost Then
            If e.KeyCode = Keys.Down Then
                objPlayer1.SetBounds(objPlayer1.Left, objPlayer1.Top + 15, 25, 130)
                bw.Write("D")
            ElseIf e.KeyCode = Keys.Up Then
                objPlayer1.SetBounds(objPlayer1.Left, objPlayer1.Top - 15, 25, 130)
                bw.Write("U")
            End If

        Else
            If e.KeyCode = Keys.Down Then
                objPlayer2.SetBounds(objPlayer2.Left, objPlayer2.Top + 15, 25, 130)
                bw.Write("D")
            ElseIf e.KeyCode = Keys.Up Then
                objPlayer2.SetBounds(objPlayer2.Left, objPlayer2.Top - 15, 25, 130)
                bw.Write("U")
            End If
        End If
    End Sub
End Class