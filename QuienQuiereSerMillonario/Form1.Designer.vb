<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnIniciar = New System.Windows.Forms.Button()
        Me.btnCargarArchivoPreguntas = New System.Windows.Forms.Button()
        Me.ofdArchivoPreguntas = New System.Windows.Forms.OpenFileDialog()
        Me.btnCrearArchivo = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSonido = New System.Windows.Forms.Button()
        Me.chkComodines = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btnIniciar
        '
        Me.btnIniciar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIniciar.BackColor = System.Drawing.Color.Transparent
        Me.btnIniciar.FlatAppearance.BorderSize = 0
        Me.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIniciar.Image = Global.QuienQuiereSerMillonario.My.Resources.Resources.next1
        Me.btnIniciar.Location = New System.Drawing.Point(695, 450)
        Me.btnIniciar.Name = "btnIniciar"
        Me.btnIniciar.Size = New System.Drawing.Size(60, 57)
        Me.btnIniciar.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnIniciar, "Iniciar Cuestionario")
        Me.btnIniciar.UseVisualStyleBackColor = False
        '
        'btnCargarArchivoPreguntas
        '
        Me.btnCargarArchivoPreguntas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCargarArchivoPreguntas.BackColor = System.Drawing.Color.Transparent
        Me.btnCargarArchivoPreguntas.FlatAppearance.BorderSize = 0
        Me.btnCargarArchivoPreguntas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCargarArchivoPreguntas.Image = Global.QuienQuiereSerMillonario.My.Resources.Resources.upload
        Me.btnCargarArchivoPreguntas.Location = New System.Drawing.Point(12, 450)
        Me.btnCargarArchivoPreguntas.Name = "btnCargarArchivoPreguntas"
        Me.btnCargarArchivoPreguntas.Size = New System.Drawing.Size(60, 60)
        Me.btnCargarArchivoPreguntas.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.btnCargarArchivoPreguntas, "Elegir Cuestionario")
        Me.btnCargarArchivoPreguntas.UseVisualStyleBackColor = False
        '
        'btnCrearArchivo
        '
        Me.btnCrearArchivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCrearArchivo.BackColor = System.Drawing.Color.Transparent
        Me.btnCrearArchivo.FlatAppearance.BorderSize = 0
        Me.btnCrearArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCrearArchivo.Image = Global.QuienQuiereSerMillonario.My.Resources.Resources.crearPreguntas
        Me.btnCrearArchivo.Location = New System.Drawing.Point(12, 384)
        Me.btnCrearArchivo.Name = "btnCrearArchivo"
        Me.btnCrearArchivo.Size = New System.Drawing.Size(60, 60)
        Me.btnCrearArchivo.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btnCrearArchivo, "Crear Cuestionario")
        Me.btnCrearArchivo.UseVisualStyleBackColor = False
        '
        'btnSonido
        '
        Me.btnSonido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSonido.BackColor = System.Drawing.Color.Transparent
        Me.btnSonido.BackgroundImage = Global.QuienQuiereSerMillonario.My.Resources.Resources.Sound___On3
        Me.btnSonido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSonido.FlatAppearance.BorderSize = 0
        Me.btnSonido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSonido.Location = New System.Drawing.Point(695, 0)
        Me.btnSonido.Name = "btnSonido"
        Me.btnSonido.Size = New System.Drawing.Size(60, 60)
        Me.btnSonido.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.btnSonido, "Sin sonido")
        Me.btnSonido.UseVisualStyleBackColor = False
        '
        'chkComodines
        '
        Me.chkComodines.AutoSize = True
        Me.chkComodines.Location = New System.Drawing.Point(572, 471)
        Me.chkComodines.Name = "chkComodines"
        Me.chkComodines.Size = New System.Drawing.Size(117, 17)
        Me.chkComodines.TabIndex = 4
        Me.chkComodines.Text = "Comodines Infinitos"
        Me.chkComodines.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.QuienQuiereSerMillonario.My.Resources.Resources.millonario
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(758, 511)
        Me.Controls.Add(Me.chkComodines)
        Me.Controls.Add(Me.btnSonido)
        Me.Controls.Add(Me.btnCrearArchivo)
        Me.Controls.Add(Me.btnCargarArchivoPreguntas)
        Me.Controls.Add(Me.btnIniciar)
        Me.Name = "Form1"
        Me.Text = "HWTM"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnIniciar As System.Windows.Forms.Button
    Friend WithEvents btnCargarArchivoPreguntas As System.Windows.Forms.Button
    Friend WithEvents ofdArchivoPreguntas As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnCrearArchivo As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnSonido As System.Windows.Forms.Button
    Friend WithEvents chkComodines As System.Windows.Forms.CheckBox

End Class
