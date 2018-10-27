Public Class PreguntaFormat

    Public Pregunta As String = ""
    Public PreguntaTXT As String = ""
    Public Opcion1 As String = ""
    Public Opcion2 As String = ""
    Public Opcion3 As String = ""
    Public Opcion4 As String = ""
    Public OpcionCorrecta As Integer = 1

    Public Overrides Function ToString() As String
        Return PreguntaTXT
    End Function
End Class
