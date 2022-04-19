Public Class Chess

    Public pb(7, 7) As PictureBox

    Public w_king As king
    Public w_queen As queen
    Public w_bishop(1) As bishop
    Public w_knight(1) As knight
    Public w_rook(1) As rook
    Public w_pawn(7) As pawn
    Public b_king As king
    Public b_queen As queen
    Public b_bishop(1) As bishop
    Public b_knight(1) As knight
    Public b_rook(1) As rook
    Public b_pawn(7) As pawn

    Public ga As game

    Public x, y, sel_x, sel_y As Integer
    Public selected As Boolean = False      '' this is to check if a piece is selected by player or not
    Public sel_piece As String = Nothing

    Private Sub NewGameWhite_Click(sender As Object, e As EventArgs) Handles NewGameWhite.Click
        pb = New PictureBox(7, 7) {{Me.PictureBox1, Me.PictureBox2, Me.PictureBox3, Me.PictureBox4, Me.PictureBox5, Me.PictureBox6, Me.PictureBox7, Me.PictureBox8},
                                {Me.PictureBox9, Me.PictureBox10, Me.PictureBox11, Me.PictureBox12, Me.PictureBox13, Me.PictureBox14, Me.PictureBox15, Me.PictureBox16},
                                {Me.PictureBox17, Me.PictureBox18, Me.PictureBox19, Me.PictureBox20, Me.PictureBox21, Me.PictureBox22, Me.PictureBox23, Me.PictureBox24},
                                {Me.PictureBox25, Me.PictureBox26, Me.PictureBox27, Me.PictureBox28, Me.PictureBox29, Me.PictureBox30, Me.PictureBox31, Me.PictureBox32},
                                {Me.PictureBox33, Me.PictureBox34, Me.PictureBox35, Me.PictureBox36, Me.PictureBox37, Me.PictureBox38, Me.PictureBox39, Me.PictureBox40},
                                {Me.PictureBox41, Me.PictureBox42, Me.PictureBox43, Me.PictureBox44, Me.PictureBox45, Me.PictureBox46, Me.PictureBox47, Me.PictureBox48},
                                {Me.PictureBox49, Me.PictureBox50, Me.PictureBox51, Me.PictureBox52, Me.PictureBox53, Me.PictureBox54, Me.PictureBox55, Me.PictureBox56},
                                {Me.PictureBox57, Me.PictureBox58, Me.PictureBox59, Me.PictureBox60, Me.PictureBox61, Me.PictureBox62, Me.PictureBox63, Me.PictureBox64}}

        all_objects()
        ga.re_can_move()
        ga.displayPieces()
        ga.re_back()
        ga.fill_chk_for_black()
        ga.fill_chk_for_white()
        ga.player = 1
        ga.wking_move_count = 0
        ga.bking_move_count = 0
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ga.re_back()
        y = 0
        x = 0
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        ga.re_back()
        y = 1
        x = 0
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        ga.re_back()
        y = 2
        x = 0
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        ga.re_back()
        y = 3
        x = 0
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        ga.re_back()
        y = 4
        x = 0
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        ga.re_back()
        y = 5
        x = 0
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        ga.re_back()
        y = 6
        x = 0
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        ga.re_back()
        y = 7
        x = 0
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        ga.re_back()
        y = 0
        x = 1
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        ga.re_back()
        y = 1
        x = 1
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        ga.re_back()
        y = 2
        x = 1
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click
        ga.re_back()
        y = 3
        x = 1
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox13_Click(sender As Object, e As EventArgs) Handles PictureBox13.Click
        ga.re_back()
        y = 4
        x = 1
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox14_Click(sender As Object, e As EventArgs) Handles PictureBox14.Click
        ga.re_back()
        y = 5
        x = 1
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox15_Click(sender As Object, e As EventArgs) Handles PictureBox15.Click
        ga.re_back()
        y = 6
        x = 1
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox16_Click(sender As Object, e As EventArgs) Handles PictureBox16.Click
        ga.re_back()
        y = 7
        x = 1
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox17_Click(sender As Object, e As EventArgs) Handles PictureBox17.Click
        ga.re_back()
        y = 0
        x = 2
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox18_Click(sender As Object, e As EventArgs) Handles PictureBox18.Click
        ga.re_back()
        y = 1
        x = 2
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox19_Click(sender As Object, e As EventArgs) Handles PictureBox19.Click
        ga.re_back()
        y = 2
        x = 2
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox20_Click(sender As Object, e As EventArgs) Handles PictureBox20.Click
        ga.re_back()
        y = 3
        x = 2
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox21_Click(sender As Object, e As EventArgs) Handles PictureBox21.Click
        ga.re_back()
        y = 4
        x = 2
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox22_Click(sender As Object, e As EventArgs) Handles PictureBox22.Click
        ga.re_back()
        y = 5
        x = 2
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox23_Click(sender As Object, e As EventArgs) Handles PictureBox23.Click
        ga.re_back()
        y = 6
        x = 2
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox24_Click(sender As Object, e As EventArgs) Handles PictureBox24.Click
        ga.re_back()
        y = 7
        x = 2
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox25_Click(sender As Object, e As EventArgs) Handles PictureBox25.Click
        ga.re_back()
        y = 0
        x = 3
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox26_Click(sender As Object, e As EventArgs) Handles PictureBox26.Click
        ga.re_back()
        y = 1
        x = 3
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox27_Click(sender As Object, e As EventArgs) Handles PictureBox27.Click
        ga.re_back()
        y = 2
        x = 3
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox28_Click(sender As Object, e As EventArgs) Handles PictureBox28.Click
        ga.re_back()
        y = 3
        x = 3
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox29_Click(sender As Object, e As EventArgs) Handles PictureBox29.Click
        ga.re_back()
        y = 4
        x = 3
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox30_Click(sender As Object, e As EventArgs) Handles PictureBox30.Click
        ga.re_back()
        y = 5
        x = 3
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox31_Click(sender As Object, e As EventArgs) Handles PictureBox31.Click
        ga.re_back()
        y = 6
        x = 3
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox32_Click(sender As Object, e As EventArgs) Handles PictureBox32.Click
        ga.re_back()
        y = 7
        x = 3
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox33_Click(sender As Object, e As EventArgs) Handles PictureBox33.Click
        ga.re_back()
        y = 0
        x = 4
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox34_Click(sender As Object, e As EventArgs) Handles PictureBox34.Click
        ga.re_back()
        y = 1
        x = 4
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox35_Click(sender As Object, e As EventArgs) Handles PictureBox35.Click
        ga.re_back()
        y = 2
        x = 4
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox36_Click(sender As Object, e As EventArgs) Handles PictureBox36.Click
        ga.re_back()
        y = 3
        x = 4
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox37_Click(sender As Object, e As EventArgs) Handles PictureBox37.Click
        ga.re_back()
        y = 4
        x = 4
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox38_Click(sender As Object, e As EventArgs) Handles PictureBox38.Click
        ga.re_back()
        y = 5
        x = 4
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox39_Click(sender As Object, e As EventArgs) Handles PictureBox39.Click
        ga.re_back()
        y = 6
        x = 4
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox40_Click(sender As Object, e As EventArgs) Handles PictureBox40.Click
        ga.re_back()
        y = 7
        x = 4
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox41_Click(sender As Object, e As EventArgs) Handles PictureBox41.Click
        ga.re_back()
        y = 0
        x = 5
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox42_Click(sender As Object, e As EventArgs) Handles PictureBox42.Click
        ga.re_back()
        y = 1
        x = 5
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox43_Click(sender As Object, e As EventArgs) Handles PictureBox43.Click
        ga.re_back()
        y = 2
        x = 5
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox44_Click(sender As Object, e As EventArgs) Handles PictureBox44.Click
        ga.re_back()
        y = 3
        x = 5
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox45_Click(sender As Object, e As EventArgs) Handles PictureBox45.Click
        ga.re_back()
        y = 4
        x = 5
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox46_Click(sender As Object, e As EventArgs) Handles PictureBox46.Click
        ga.re_back()
        y = 5
        x = 5
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox47_Click(sender As Object, e As EventArgs) Handles PictureBox47.Click
        ga.re_back()
        y = 6
        x = 5
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox48_Click(sender As Object, e As EventArgs) Handles PictureBox48.Click
        ga.re_back()
        y = 7
        x = 5
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox49_Click(sender As Object, e As EventArgs) Handles PictureBox49.Click
        ga.re_back()
        y = 0
        x = 6
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox50_Click(sender As Object, e As EventArgs) Handles PictureBox50.Click
        ga.re_back()
        y = 1
        x = 6
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox51_Click(sender As Object, e As EventArgs) Handles PictureBox51.Click
        ga.re_back()
        y = 2
        x = 6
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox52_Click(sender As Object, e As EventArgs) Handles PictureBox52.Click
        ga.re_back()
        y = 3
        x = 6
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox53_Click(sender As Object, e As EventArgs) Handles PictureBox53.Click
        ga.re_back()
        y = 4
        x = 6
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox54_Click(sender As Object, e As EventArgs) Handles PictureBox54.Click
        ga.re_back()
        y = 5
        x = 6
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox55_Click(sender As Object, e As EventArgs) Handles PictureBox55.Click
        ga.re_back()
        y = 6
        x = 6
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox56_Click(sender As Object, e As EventArgs) Handles PictureBox56.Click
        ga.re_back()
        y = 7
        x = 6
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox57_Click(sender As Object, e As EventArgs) Handles PictureBox57.Click
        ga.re_back()
        y = 0
        x = 7
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox58_Click(sender As Object, e As EventArgs) Handles PictureBox58.Click
        ga.re_back()
        y = 1
        x = 7
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox59_Click(sender As Object, e As EventArgs) Handles PictureBox59.Click
        ga.re_back()
        y = 2
        x = 7
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub
    Private Sub PictureBox60_Click(sender As Object, e As EventArgs) Handles PictureBox60.Click
        ga.re_back()
        y = 3
        x = 7
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox61_Click(sender As Object, e As EventArgs) Handles PictureBox61.Click
        ga.re_back()
        y = 4
        x = 7
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox62_Click(sender As Object, e As EventArgs) Handles PictureBox62.Click
        ga.re_back()
        y = 5
        x = 7
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox63_Click(sender As Object, e As EventArgs) Handles PictureBox63.Click
        ga.re_back()
        y = 6
        x = 7
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub

    Private Sub PictureBox64_Click(sender As Object, e As EventArgs) Handles PictureBox64.Click
        ga.re_back()
        y = 7
        x = 7
        If selected <> True Then
            ga.re_can_move()
            sel_piece = ga.selection(x, y)
            sel_x = x
            sel_y = y
            selected = True
        Else
            If ga.can_move(x, y) = True Then
                ga.mov(sel_piece, x, y, sel_x, sel_y)
            End If
            selected = False
            ga.displayPieces()
        End If
    End Sub



    Public Sub all_objects()

        w_king = New king(0, 4, 1)
        w_queen = New queen(0, 3, 2)
        w_bishop(0) = New bishop(0, 2, 3)
        w_bishop(1) = New bishop(0, 5, 3)
        w_knight(0) = New knight(0, 1, 4)
        w_knight(1) = New knight(0, 6, 4)
        w_rook(0) = New rook(0, 0, 5)
        w_rook(1) = New rook(0, 7, 5)
        w_pawn(0) = New pawn(1, 0, 6)
        w_pawn(1) = New pawn(1, 1, 6)
        w_pawn(2) = New pawn(1, 2, 6)
        w_pawn(3) = New pawn(1, 3, 6)
        w_pawn(4) = New pawn(1, 4, 6)
        w_pawn(5) = New pawn(1, 5, 6)
        w_pawn(6) = New pawn(1, 6, 6)
        w_pawn(7) = New pawn(1, 7, 6)

        b_king = New king(7, 4, -1)
        b_queen = New queen(7, 3, -2)
        b_bishop(0) = New bishop(7, 2, -3)
        b_bishop(1) = New bishop(7, 5, -3)
        b_knight(0) = New knight(7, 1, -4)
        b_knight(1) = New knight(7, 6, -4)
        b_rook(0) = New rook(7, 0, -5)
        b_rook(1) = New rook(7, 7, -5)
        b_pawn(0) = New pawn(6, 0, -6)
        b_pawn(1) = New pawn(6, 1, -6)
        b_pawn(2) = New pawn(6, 2, -6)
        b_pawn(3) = New pawn(6, 3, -6)
        b_pawn(4) = New pawn(6, 4, -6)
        b_pawn(5) = New pawn(6, 5, -6)
        b_pawn(6) = New pawn(6, 6, -6)
        b_pawn(7) = New pawn(6, 7, -6)


        ga = New game()
    End Sub



End Class