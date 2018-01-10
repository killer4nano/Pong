Public Class HomeScreen

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnJoin.Click
        Game.isHost = False
        Game.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        'another one
    End Sub

    Private Sub HomeScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Me.Hide()
        Game.isHost = True
        Game.Show()

    End Sub
End Class
