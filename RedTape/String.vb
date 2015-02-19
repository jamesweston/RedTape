Namespace [String]
    Public Module Evaluate
        ReadOnly Property IsEmptyNullOrWhitespaceOnly(ByVal stringToCheck As String, ByVal ParamArray whitespaceChars() As Char) As Boolean
            Get
                Return IsWhitespaceOnly(stringToCheck, whitespaceChars)
            End Get
        End Property

        Public ReadOnly Property IsWhitespaceOnly(ByVal stringToCheck As String, ByVal ParamArray whitespaceChars() As Char) As Boolean
            Get
                Dim length As Int32 = stringToCheck.Length
                Dim middle As Int32 = length \ 2
                Dim first As Int32 = middle
                Dim second As Int32 = middle + 1
                Dim chr As Char

                If whitespaceChars Is Nothing OrElse whitespaceChars.Length = 0 Then
                    whitespaceChars = New Char() {" "c, ChrW(&H3000)}
                End If

                Dim whitespaceUbound As Int32 = whitespaceChars.Length - 1
                Dim hasNonWhitespace As Boolean = False

                For i As Int32 = 0 To middle

                    If first >= 0 Then
                        hasNonWhitespace = True
                        chr = stringToCheck.Chars(first)
                        For j As Int32 = 0 To whitespaceUbound
                            If chr = whitespaceChars(j) Then
                                hasNonWhitespace = False
                                Exit For
                            End If
                        Next
                        first -= 1
                    End If

                    If hasNonWhitespace Then Return False

                    If second < length Then
                        hasNonWhitespace = True
                        chr = stringToCheck.Chars(second)
                        For j As Int32 = 0 To whitespaceUbound
                            If chr = whitespaceChars(j) Then
                                hasNonWhitespace = False
                                Exit For
                            End If
                        Next
                        second += 1
                    End If

                    If hasNonWhitespace Then Return False

                Next

                Return Not hasNonWhitespace
            End Get
        End Property
    End Module
End Namespace

