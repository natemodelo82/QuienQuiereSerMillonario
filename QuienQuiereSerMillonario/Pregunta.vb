Imports System.Media
Public Class Pregunta


    Public varArchivoPreguntas As String = ""
    Private dsPreguntas As New DataSet
    Private varIndiceActual As Integer = 0
    Private varBoton As Object = Nothing
    Private comodin5050Disponible As Boolean = True
    Private comodinPublicoDisponible As Boolean = True
    Private comodinProfeDisponible As Boolean = True
    Public HabilitarSonido As Boolean = True
    Public ComodinesInfinitos As Boolean = False

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub fnCargarPregunta()

        Try


            btn5050.Enabled = comodin5050Disponible
            btnPregunteGrupo.Enabled = comodinPublicoDisponible
            btnExplicacion.Enabled = comodinProfeDisponible
            btnOpcion1.BackColor = Color.Transparent
            btnOpcion2.BackColor = Color.Transparent
            btnOpcion3.BackColor = Color.Transparent
            btnOpcion4.BackColor = Color.Transparent
            btnOpcion1.Visible = True
            btnOpcion2.Visible = True
            btnOpcion3.Visible = True
            btnOpcion4.Visible = True
            txtPregunta.ForeColor = Color.White
            txtPregunta.Rtf = dsPreguntas.Tables(0).Rows(varIndiceActual)(1)
            btnOpcion1.Text = "A- " + dsPreguntas.Tables(1).Rows(0 + (varIndiceActual * 4))(1)
            btnOpcion2.Text = "B- " + dsPreguntas.Tables(1).Rows(1 + (varIndiceActual * 4))(1)
            btnOpcion3.Text = "C- " + dsPreguntas.Tables(1).Rows(2 + (varIndiceActual * 4))(1)
            btnOpcion4.Text = "D- " + dsPreguntas.Tables(1).Rows(3 + (varIndiceActual * 4))(1)
            btnOpcion1.Tag = dsPreguntas.Tables(1).Rows(0 + (varIndiceActual * 4))(0)
            btnOpcion2.Tag = dsPreguntas.Tables(1).Rows(1 + (varIndiceActual * 4))(0)
            btnOpcion3.Tag = dsPreguntas.Tables(1).Rows(2 + (varIndiceActual * 4))(0)
            btnOpcion4.Tag = dsPreguntas.Tables(1).Rows(3 + (varIndiceActual * 4))(0)
            ToolTip1.SetToolTip(btnOpcion1, btnOpcion1.Text)
            ToolTip1.SetToolTip(btnOpcion2, btnOpcion2.Text)
            ToolTip1.SetToolTip(btnOpcion3, btnOpcion3.Text)
            ToolTip1.SetToolTip(btnOpcion4, btnOpcion4.Text)
            If HabilitarSonido Then
                My.Computer.Audio.Play(My.Resources.Resource1.leerpregunta, AudioPlayMode.BackgroundLoop)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Close()
        End Try
    End Sub

    Private Sub btnSig_Click(sender As Object, e As EventArgs) Handles btnSig.Click
        If varIndiceActual >= dsPreguntas.Tables(0).Rows.Count - 1 Then
            MessageBox.Show("Felicidades, haz ganado!!!")
            Return
        End If
        varIndiceActual += 1
        fnCargarPregunta()


    End Sub

    Private Sub Pregunta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dsPreguntas = New DataSet()
        'Xml varXML = New System.
        Dim myXMLfile As String = varArchivoPreguntas

        ' Create new FileStream with which to read the schema.
        Dim fsReadXml As New System.IO.FileStream(myXMLfile, System.IO.FileMode.Open)
        Try
            dsPreguntas.ReadXml(fsReadXml)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            Close()
        Finally
            fsReadXml.Close()

        End Try
        comodin5050Disponible = True
        comodinPublicoDisponible = True
        comodinProfeDisponible = True

        fnCargarPregunta()
    End Sub

    Private Sub fnRevisaPregunta(sender As Object)
        Dim btnAux As Button = CType(sender, Button)
        If btnAux.Tag.Equals("true") Then
            If HabilitarSonido Then
                My.Computer.Audio.Play(My.Resources.Resource1.correcta, AudioPlayMode.Background)
            End If
            btnAux.BackColor = Color.DarkGreen

        Else
            If HabilitarSonido Then
                My.Computer.Audio.Play(My.Resources.Resource1.incorrecta, AudioPlayMode.Background)
            End If

            btnAux.BackColor = Color.DarkRed
        End If


    End Sub
    Private Sub fnMarcarRespuesta(sender As Object)
        If HabilitarSonido Then
            My.Computer.Audio.Play(My.Resources.Resource1.marcar, AudioPlayMode.Background)
        End If
        Dim btnAux As Button = CType(sender, Button)
        varBoton = btnAux
        btnOpcion1.BackColor = Color.Transparent
        btnOpcion2.BackColor = Color.Transparent
        btnOpcion3.BackColor = Color.Transparent
        btnOpcion4.BackColor = Color.Transparent

        btnAux.BackColor = Color.MidnightBlue


    End Sub

    Private Sub btnOpcion1_Click(sender As Object, e As EventArgs) Handles btnOpcion1.Click
        fnMarcarRespuesta(sender)

    End Sub

    Private Sub btnOpcion3_Click(sender As Object, e As EventArgs) Handles btnOpcion3.Click
        fnMarcarRespuesta(sender)
    End Sub

    Private Sub btnOpcion2_Click(sender As Object, e As EventArgs) Handles btnOpcion2.Click
        fnMarcarRespuesta(sender)
    End Sub

    Private Sub btnOpcion4_Click(sender As Object, e As EventArgs) Handles btnOpcion4.Click
        fnMarcarRespuesta(sender)

    End Sub

    Private Sub btn5050_Click(sender As Object, e As EventArgs) Handles btn5050.Click
        If HabilitarSonido Then
            My.Computer.Audio.Play(My.Resources.Resource1.comodin, AudioPlayMode.Background)
        End If
        Dim comodin5050 As Integer = 2
        If btnOpcion1.Tag.Equals("false") Then
            btnOpcion1.Visible = False
            comodin5050 -= 1
        End If
        If btnOpcion2.Tag.Equals("false") Then
            btnOpcion2.Visible = False
            comodin5050 -= 1
        End If
        If btnOpcion3.Tag.Equals("false") And comodin5050 > 0 Then
            btnOpcion3.Visible = False
            comodin5050 -= 1
        End If
        If btnOpcion4.Tag.Equals("false") And comodin5050 > 0 Then
            btnOpcion4.Visible = False
            comodin5050 -= 1
        End If
        If Not ComodinesInfinitos Then
            comodin5050Disponible = False
        End If


        btn5050.Enabled = False
    End Sub

    Private Sub btnRevisar_Click(sender As Object, e As EventArgs) Handles btnRevisar.Click
        If varBoton IsNot Nothing Then
            fnRevisaPregunta(varBoton)
        Else

            MessageBox.Show("Debe marcar una respuesta")
        End If


    End Sub

    Private Sub btnPregunteGrupo_Click(sender As Object, e As EventArgs) Handles btnPregunteGrupo.Click
        If HabilitarSonido Then
            My.Computer.Audio.Play(My.Resources.Resource1.comodin, AudioPlayMode.Background)
        End If
        If Not ComodinesInfinitos Then
            comodinPublicoDisponible = False
        End If

        btnPregunteGrupo.Enabled = False

    End Sub

    Private Sub btnExplicacion_Click(sender As Object, e As EventArgs) Handles btnExplicacion.Click
        If HabilitarSonido Then
            My.Computer.Audio.Play(My.Resources.Resource1.comodin, AudioPlayMode.Background)
        End If
        If Not ComodinesInfinitos Then
            comodinProfeDisponible = False
        End If

        btnExplicacion.Enabled = False
    End Sub

    Private Sub btnAnt_Click(sender As Object, e As EventArgs) Handles btnAnt.Click
        If varIndiceActual > 0 Then
            varIndiceActual -= 1
            fnCargarPregunta()
        End If

    End Sub
End Class