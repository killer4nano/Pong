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
    Private renderThread As Thread
    Dim connection As TcpClient


    Private Sub Game_Closwe(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        HomeScreen.Show()
    End Sub

    Private Sub Game_Load(sender As Object, e As EventArgs) Handles MyBase.Load, MyBase.KeyDown

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
            sMovedLeft = 12
            sMovedTop = 112
            rMovedTop = 112
            rMovedLeft = 531
        Else
            sMovedLeft = 531
            sMovedTop = 112
            rMovedTop = 112
        End If

        bw = New IO.BinaryWriter(connection.GetStream())
        br = New IO.BinaryReader(connection.GetStream())
        communicationThread = New Thread(AddressOf communicationStart)
        communicationThread.Start()
        renderThread = New Thread(AddressOf communicationStart)
        renderThread.Start()

    End Sub




    Private Sub Game_Load(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            If e.KeyCode = Keys.Down Then
            sMovedTop += 15
            MsgBox("test")
            ElseIf e.KeyCode = Keys.Up Then
                sMovedTop -= 15
            End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
            If isHost Then
                bw.Write(sMovedTop)
                bw.Flush()
                rMovedTop = br.ReadInt16
            Else
                rMovedTop = br.ReadInt16
                bw.Write(sMovedTop)
                bw.Flush()
            End If

            If isHost Then
                objPlayer2.SetBounds(rMovedLeft, rMovedTop, 25, 130)
                objPlayer1.SetBounds(sMovedLeft, sMovedTop, 25, 130)
            Else
                objPlayer1.SetBounds(rMovedLeft, rMovedTop, 25, 130)
                objPlayer2.SetBounds(sMovedLeft, sMovedTop, 25, 130)
            End If
    End Sub
End Class