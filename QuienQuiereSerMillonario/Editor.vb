Public Class Editor
    Public HabilitarSonido As Boolean = True


    Private listaPreguntas As New List(Of PreguntaFormat)

    Private Sub Editor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listaPreguntas.Clear()
        cmbRespuestaCorrecta.SelectedIndex = 0
    End Sub

    Private Sub PasteToolStripButton_Click(sender As Object, e As EventArgs) Handles PasteToolStripButton.Click
        txtPregunta.Paste()
    End Sub

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        txtPregunta.Copy()
    End Sub

    Private Sub CutToolStripButton_Click(sender As Object, e As EventArgs) Handles CutToolStripButton.Click
        txtPregunta.Cut()
    End Sub

    Private txtSubIndice As Boolean = False
    Private Sub tsbSubindice_Click(sender As Object, e As EventArgs) Handles tsbSubindice.Click
        If Not txtSubIndice Then
            txtPregunta.SelectionCharOffset = -10
            txtPregunta.SelectionFont = New Font(txtPregunta.SelectionFont.FontFamily, txtPregunta.SelectionFont.SizeInPoints - 3)
            txtSubIndice = True
        End If

        
    End Sub

    Private Sub tsbSuperIndice_Click(sender As Object, e As EventArgs) Handles tsbSuperIndice.Click
        If Not txtSubIndice Then
            txtPregunta.SelectionCharOffset = 10
            txtPregunta.SelectionFont = New Font(txtPregunta.SelectionFont.FontFamily, txtPregunta.SelectionFont.SizeInPoints - 3)
            txtSubIndice = True
        End If

       
    End Sub

    Private Sub tsbNormalTxt_Click(sender As Object, e As EventArgs) Handles tsbNormalTxt.Click
        If txtSubIndice Then
            txtPregunta.SelectionCharOffset = 0
            txtPregunta.SelectionFont = New Font(txtPregunta.SelectionFont.FontFamily, txtPregunta.SelectionFont.SizeInPoints + 3)
            txtSubIndice = False
        End If


    End Sub

    Private Sub btnAgregarPregunta_Click(sender As Object, e As EventArgs) Handles btnAgregarPregunta.Click
        lbPreguntas.DataSource = Nothing
        Dim preguntaAux As PreguntaFormat = New PreguntaFormat()
        preguntaAux.Pregunta = txtPregunta.Rtf
        preguntaAux.PreguntaTXT = txtPregunta.Text
        preguntaAux.Opcion1 = txtOpcion1.Text
        preguntaAux.Opcion2 = txtOpcion2.Text
        preguntaAux.Opcion3 = txtOpcion3.Text
        preguntaAux.Opcion4 = txtOpcion4.Text
        preguntaAux.OpcionCorrecta = cmbRespuestaCorrecta.SelectedIndex + 1
        listaPreguntas.Add(preguntaAux)
        lbPreguntas.DataSource = listaPreguntas
        lbPreguntas.Refresh()
    End Sub

    Private Sub btnSubir_Click(sender As Object, e As EventArgs) Handles btnSubir.Click
        If lbPreguntas.SelectedIndex > 0 Then
            Dim index As Int16 = lbPreguntas.SelectedIndex
            Dim preguntaAux As PreguntaFormat = listaPreguntas(index)
            listaPreguntas.RemoveAt(index)
            listaPreguntas.Insert(index - 1, preguntaAux)
            lbPreguntas.DataSource = Nothing
            lbPreguntas.DataSource = listaPreguntas
            lbPreguntas.SelectedIndex = index - 1
            lbPreguntas.Refresh()
        End If


    End Sub

    Private Sub btnBajar_Click(sender As Object, e As EventArgs) Handles btnBajar.Click
        If lbPreguntas.SelectedIndex < lbPreguntas.Items.Count - 1 Then
            Dim index As Int16 = lbPreguntas.SelectedIndex
            Dim preguntaAux As PreguntaFormat = listaPreguntas(index)
            listaPreguntas.RemoveAt(index)
            listaPreguntas.Insert(index + 1, preguntaAux)
            lbPreguntas.DataSource = Nothing
            lbPreguntas.DataSource = listaPreguntas
            lbPreguntas.SelectedIndex = index + 1
            lbPreguntas.Refresh()
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If lbPreguntas.SelectedIndex > -1 Then
            Dim index As Int16 = lbPreguntas.SelectedIndex
            If MessageBox.Show("Borrar pregunta seleccionada?") = Windows.Forms.DialogResult.OK Then

                listaPreguntas.RemoveAt(index)

                lbPreguntas.DataSource = Nothing
                lbPreguntas.DataSource = listaPreguntas
                lbPreguntas.Refresh()
                

            End If

           
        End If
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click

        Dim sfdAux As SaveFileDialog = New SaveFileDialog()
        sfdAux.Filter = "XML files (*.xml)|*.xml"
        sfdAux.FileName = "Preguntas.xml"

        If sfdAux.ShowDialog() = Windows.Forms.DialogResult.OK Then



            Dim xmlDoc = New Xml.XmlDocument()
            Dim xmlJuego As Xml.XmlNode = xmlDoc.CreateNode(Xml.XmlNodeType.Element, "juego", "")
            xmlDoc.AppendChild(xmlJuego)

            For Each preguntaAux As PreguntaFormat In listaPreguntas

                Dim xmlPregunta As Xml.XmlNode = xmlDoc.CreateNode(Xml.XmlNodeType.Element, "pregunta", "")
                Dim xmlAtributoText As Xml.XmlAttribute = xmlDoc.CreateAttribute("text")
                xmlAtributoText.Value = preguntaAux.Pregunta
                xmlPregunta.Attributes.Append(xmlAtributoText)

                Dim xmlOpcion1 As Xml.XmlNode = xmlDoc.CreateNode(Xml.XmlNodeType.Element, "opcion", "")
                xmlOpcion1.InnerText = preguntaAux.Opcion1
                Dim xmlCorrectaText1 As Xml.XmlAttribute = xmlDoc.CreateAttribute("correcta")
                xmlCorrectaText1.Value = (preguntaAux.OpcionCorrecta = 1).ToString().ToLower()
                xmlOpcion1.Attributes.Append(xmlCorrectaText1)
                xmlPregunta.AppendChild(xmlOpcion1)

                Dim xmlOpcion2 As Xml.XmlNode = xmlDoc.CreateNode(Xml.XmlNodeType.Element, "opcion", "")
                xmlOpcion2.InnerText = preguntaAux.Opcion2
                Dim xmlCorrectaText2 As Xml.XmlAttribute = xmlDoc.CreateAttribute("correcta")
                xmlCorrectaText2.Value = (preguntaAux.OpcionCorrecta = 2).ToString().ToLower()
                xmlOpcion2.Attributes.Append(xmlCorrectaText2)
                xmlPregunta.AppendChild(xmlOpcion2)

                Dim xmlOpcion3 As Xml.XmlNode = xmlDoc.CreateNode(Xml.XmlNodeType.Element, "opcion", "")
                xmlOpcion3.InnerText = preguntaAux.Opcion3
                Dim xmlCorrectaText3 As Xml.XmlAttribute = xmlDoc.CreateAttribute("correcta")
                xmlCorrectaText3.Value = (preguntaAux.OpcionCorrecta = 3).ToString().ToLower()
                xmlOpcion3.Attributes.Append(xmlCorrectaText3)
                xmlPregunta.AppendChild(xmlOpcion3)

                Dim xmlOpcion4 As Xml.XmlNode = xmlDoc.CreateNode(Xml.XmlNodeType.Element, "opcion", "")
                xmlOpcion4.InnerText = preguntaAux.Opcion4
                Dim xmlCorrectaText4 As Xml.XmlAttribute = xmlDoc.CreateAttribute("correcta")
                xmlCorrectaText4.Value = (preguntaAux.OpcionCorrecta = 4).ToString().ToLower()
                xmlOpcion4.Attributes.Append(xmlCorrectaText4)
                xmlPregunta.AppendChild(xmlOpcion4)

                xmlJuego.AppendChild(xmlPregunta)
            Next

            xmlDoc.Save(sfdAux.FileName)
        End If
    End Sub

    Private Sub tsbInsertImage_Click(sender As Object, e As EventArgs) Handles tsbInsertImage.Click
        Dim ofdAux As OpenFileDialog = New OpenFileDialog()
        ofdAux.Filter = "JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|GIF files (*.gif)|*.gif"
        ofdAux.FileName = "image.jpg"

        If ofdAux.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim lstrFile As String = ofdAux.FileName
            Dim myBitmap As Bitmap = New Bitmap(lstrFile)
            Clipboard.SetDataObject(myBitmap)
            Dim myFormat As DataFormats.Format = DataFormats.GetFormat(DataFormats.Bitmap)
            If txtPregunta.CanPaste(myFormat) Then
                txtPregunta.Paste(myFormat)
            End If

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCargarArchivo.Click
        listaPreguntas.Clear()
        lbPreguntas.DataSource = Nothing
        lbPreguntas.Items.Clear()
        If (ofdArchivoPreguntas.ShowDialog() = DialogResult.OK) Then

            Dim varIndiceActual As Integer = 0
            Dim dsPreguntas As DataSet = New DataSet()
            Dim myXMLfile As String = ofdArchivoPreguntas.FileName

            ' Create new FileStream with which to read the schema.
            Dim fsReadXml As New System.IO.FileStream(myXMLfile, System.IO.FileMode.Open)
            Try
                dsPreguntas.ReadXml(fsReadXml)
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            Finally
                fsReadXml.Close()
            End Try
            Dim rtbAux As RichTextBox = New RichTextBox()
            While varIndiceActual <= dsPreguntas.Tables(0).Rows.Count - 1
                Dim preguntaAux As PreguntaFormat = New PreguntaFormat()

                preguntaAux.Pregunta = dsPreguntas.Tables(0).Rows(varIndiceActual)(1)
                ' rtbAux.Rtf = preguntaAux.Pregunta
                preguntaAux.PreguntaTXT = rtbAux.Text
                preguntaAux.Opcion1 = dsPreguntas.Tables(1).Rows(0 + (varIndiceActual * 4))(1)
                preguntaAux.Opcion2 = dsPreguntas.Tables(1).Rows(1 + (varIndiceActual * 4))(1)
                preguntaAux.Opcion3 = dsPreguntas.Tables(1).Rows(2 + (varIndiceActual * 4))(1)
                preguntaAux.Opcion4 = dsPreguntas.Tables(1).Rows(3 + (varIndiceActual * 4))(1)
                If dsPreguntas.Tables(1).Rows(0 + (varIndiceActual * 4))(0).ToString().ToLower().Equals("true") Then
                    preguntaAux.OpcionCorrecta = 1
                ElseIf dsPreguntas.Tables(1).Rows(1 + (varIndiceActual * 4))(0).ToString().ToLower().Equals("true") Then
                    preguntaAux.OpcionCorrecta = 2
                ElseIf dsPreguntas.Tables(1).Rows(2 + (varIndiceActual * 4))(0).ToString().ToLower().Equals("true") Then
                    preguntaAux.OpcionCorrecta = 3
                Else
                    preguntaAux.OpcionCorrecta = 4
                End If

                listaPreguntas.Add(preguntaAux)

                varIndiceActual += 1
            End While
            lbPreguntas.DataSource = listaPreguntas
            lbPreguntas.Refresh()
            
        End If



    End Sub

    Private Sub btnVaciarLista_Click(sender As Object, e As EventArgs) Handles btnVaciarLista.Click
        listaPreguntas.Clear()
        lbPreguntas.DataSource = Nothing
        lbPreguntas.Items.Clear()
    End Sub

    Private Sub lbPreguntas_Click(sender As Object, e As EventArgs) Handles lbPreguntas.Click

    End Sub

    Private Sub lbPreguntas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbPreguntas.SelectedIndexChanged
        If lbPreguntas.SelectedIndex > -1 Then
            Dim preguntaAux As PreguntaFormat = listaPreguntas(lbPreguntas.SelectedIndex)
            txtPregunta.Rtf = preguntaAux.Pregunta
            txtOpcion1.Text = preguntaAux.Opcion1
            txtOpcion2.Text = preguntaAux.Opcion2
            txtOpcion3.Text = preguntaAux.Opcion3
            txtOpcion4.Text = preguntaAux.Opcion4
            cmbRespuestaCorrecta.SelectedIndex = preguntaAux.OpcionCorrecta - 1
        End If

       

    End Sub
End Class