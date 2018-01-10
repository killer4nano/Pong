Imports System.Threading
Imports System.Net.Sockets
Imports System.Net

Public Class Game
    Public isHost As Boolean
    Private Sub Game_Closwe(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        HomeScreen.Show()
    End Sub

    Private Sub Game_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim host As String = System.Net.Dns.GetHostName()
        Dim ipAddress As IPAddress
        Dim LocalHostaddress As String = System.Net.Dns.GetHostEntry(host).AddressList(0).ToString()
        Dim hostIp As String
        Dim connection As TcpClient
        Dim bw As IO.BinaryWriter
        Dim br As IO.BinaryReader

        If isHost Then
            lblIP.Text = "Give this Ip to your friend " + LocalHostaddress
        Else
            hostIp = InputBox("What is the host IP?", "Connection", "")
            lblIP.Text = "Host IP : " + hostIp
            ipAddress = Dns.GetHostEntry(hostIp).AddressList(0)
        End If

        If isHost Then
            'Start the server listening port
            ipAddress = Dns.GetHostEntry(LocalHostaddress).AddressList(0)
            Dim listener As New TcpListener(ipAddress, 4000)
            listener.Start()
            connection = listener.AcceptTcpClient()

                bw = New IO.BinaryWriter(connection.GetStream())
            br = New IO.BinaryReader(connection.GetStream())
                

        Else
            'Connect to the server
            connection = New TcpClient
            connection.Connect(ipAddress.ToString, 4000)


        End If
    End Sub
End Class