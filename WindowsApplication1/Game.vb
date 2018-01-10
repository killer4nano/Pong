Imports System.Threading
Imports System.Net.Sockets
Imports System.Net

Public Class Game
    Public isHost As Boolean
    Dim bw As IO.BinaryWriter
    Dim br As IO.BinaryReader
    Dim ipAddress As IPAddress
    Dim host As String = System.Net.Dns.GetHostName()

    Dim connection As TcpClient
    Dim LocalHostaddress As String

    Private Sub Game_Closwe(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        HomeScreen.Show()
    End Sub

    Private Sub Game_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim hostIp As String
        LocalHostaddress = System.Net.Dns.GetHostEntry(host).AddressList(0).ToString()

        If isHost Then
            lblIP.Text = "Give this Ip to your friend " + LocalHostaddress

        Else
            hostIp = InputBox("What is the host IP?", "Connection", "")
            lblIP.Text = "Host IP : " + hostIp
            ipAddress = Dns.GetHostEntry(hostIp).AddressList(0)
        End If

        If isHost Then
            'Start the server listening port

        Else
            'Connect to the server
            connection = New TcpClient
            connection.Connect(ipAddress.ToString, 49552)


        End If
        

    End Sub
    Private Sub Game_Loaded(sender As Object, e As EventArgs) Handles MyBase.Validated
        If isHost Then
            getConnection()
        End If
        bw = New IO.BinaryWriter(connection.GetStream())
        br = New IO.BinaryReader(connection.GetStream())
    End Sub

    Private Sub getConnection()
        IPAddress = Dns.GetHostEntry(LocalHostaddress).AddressList(0)
        Dim listener As New TcpListener(IPAddress, 49552)
        listener.Start()
        connection = listener.AcceptTcpClient()
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
                objPlayer1.SetBounds(objPlayer2.Left, objPlayer2.Top + 15, 25, 130)
                bw.Write("D")
            ElseIf e.KeyCode = Keys.Up Then
                objPlayer1.SetBounds(objPlayer2.Left, objPlayer2.Top - 15, 25, 130)
                bw.Write("U")
            End If
        End If
    End Sub
End Class