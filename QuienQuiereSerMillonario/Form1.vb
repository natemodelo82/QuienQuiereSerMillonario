Public Class Form1
    Private HabilitarSonido As Boolean = True

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        If String.IsNullOrEmpty(Pregunta.varArchivoPreguntas) Then
            MessageBox.Show("Seleccione un archivo de cuestionario ")
            Return
        End If
        If HabilitarSonido Then
            My.Computer.Audio.Play(My.Resources.Resource1.iniciarpartida, AudioPlayMode.WaitToComplete)
        End If
        Pregunta.HabilitarSonido = HabilitarSonido
        Pregunta.ComodinesInfinitos = chkComodines.Checked
        Pregunta.ShowDialog()
    End Sub

    Private Sub btnCargarArchivoPreguntas_Click(sender As Object, e As EventArgs) Handles btnCargarArchivoPreguntas.Click
        If (ofdArchivoPreguntas.ShowDialog() = DialogResult.OK) Then
            Pregunta.varArchivoPreguntas = ofdArchivoPreguntas.FileName
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.Resource1.intro, AudioPlayMode.BackgroundLoop)
    End Sub

    Private Sub btnCrearArchivo_Click(sender As Object, e As EventArgs) Handles btnCrearArchivo.Click
        Editor.ShowDialog()
    End Sub

    Private Sub btnSonido_Click(sender As Object, e As EventArgs) Handles btnSonido.Click
        HabilitarSonido = Not HabilitarSonido
        If HabilitarSonido Then
            btnSonido.BackgroundImage = My.Resources.Sound___On3
            My.Computer.Audio.Play(My.Resources.Resource1.intro, AudioPlayMode.BackgroundLoop)
        Else
            btnSonido.BackgroundImage = My.Resources.Sound___Mute
            My.Computer.Audio.Stop()
        End If

    End Sub
End Class
