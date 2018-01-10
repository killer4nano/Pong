Imports System.Threading
Imports System.Net.Sockets
Imports System.Net

Public Class Game
    Public isHost As Boolean
    Dim bw As IO.BinaryWriter
    Dim br As IO.BinaryReader
    Dim ipAddress As IPAddress
    Dim sMovedLeft As Integer
    Dim sMovedTop As Integer
    Dim rMovedLeft As Integer
    Dim rMovedTop As Integer
    Private communicationThread As Thread
    Dim connection As TcpClient


    Private Sub Game_Closwe(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        HomeScreen.Show()
    End Sub

    Private Sub Game_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim hostIp As String
        Dim host As String = System.Net.Dns.GetHostName()
        Dim LocalHostaddress As String = System.Net.Dns.GetHostEntry(host).AddressList(0).ToString()
        Control.CheckForIllegalCrossThreadCalls = False

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

        If isHost Then
            sMovedLeft = objPlayer1.Left
            sMovedTop = objPlayer1.Top
        Else
            sMovedLeft = objPlayer2.Left
            sMovedTop = objPlayer2.Top
        End If

        bw = New IO.BinaryWriter(connection.GetStream())
        br = New IO.BinaryReader(connection.GetStream())
        communicationThread = New Thread(AddressOf communicationStart)
        communicationThread.Start()


    End Sub


    Private Sub communicationStart()
        Do While True

            Dim message As String
            message = br.ReadString
            If isHost Then
                bw.Write(sMovedLeft)
                bw.Write(sMovedTop)
                rMovedLeft = br.Read
                rMovedTop = br.Read
            Else
                rMovedLeft = br.Read
                rMovedTop = br.Read
                bw.Write(sMovedLeft)
                bw.Write(sMovedTop)
            End If
        Loop
    End Sub

    Private Sub render()
        Do While True
            If isHost Then
                objPlayer2.SetBounds(rMovedLeft, rMovedTop, 25, 130)
                objPlayer1.SetBounds(sMovedLeft, sMovedTop, 25, 130)
            Else
                objPlayer1.SetBounds(rMovedLeft, rMovedTop, 25, 130)
                objPlayer2.SetBounds(sMovedLeft, sMovedTop, 25, 130)
            End If
        Loop
    End Sub

    Private Sub Game_Load(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If isHost Then
            If e.KeyCode = Keys.Down Then
                objPlayer1.SetBounds(objPlayer1.Left, objPlayer1.Top + 15, 25, 130)
                sMovedTop += 15
            ElseIf e.KeyCode = Keys.Up Then
                objPlayer1.SetBounds(objPlayer1.Left, objPlayer1.Top - 15, 25, 130)
                sMovedTop -= 15
            End If

        Else
            If e.KeyCode = Keys.Down Then
                objPlayer2.SetBounds(objPlayer2.Left, objPlayer2.Top + 15, 25, 130)
                sMovedTop += 15
            ElseIf e.KeyCode = Keys.Up Then
                objPlayer2.SetBounds(objPlayer2.Left, objPlayer2.Top - 15, 25, 130)
                sMovedTop -= 15
            End If
        End If
    End Sub
End Class