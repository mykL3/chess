Public Class game

    Public board(7, 7) As Integer
    Public can_move(7, 7) As Boolean
    Public can_be_taken(7, 7) As Boolean
    Public check_for_white(7, 7) As Boolean
    Public check_for_black(7, 7) As Boolean
    Public player As Integer = 1
    Public game_flag As Boolean = True
    Public b_in_danger As Boolean = False
    Public w_in_danger As Boolean = False
    Public piece_checking As String = ""
    Public wking_move_count As Integer = 0
    Public bking_move_count As Integer = 0
    Public piece_protected(7, 7) As Boolean

    Public Sub New()

        board = {{5, 4, 3, 2, 1, 3, 4, 5},
                {6, 6, 6, 6, 6, 6, 6, 6},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {-6, -6, -6, -6, -6, -6, -6, -6},
                {-5, -4, -3, -2, -1, -3, -4, -5}}

        re_chk_black()
        re_chk_white()


    End Sub


    Public Sub displayPieces()

        For i As Integer = 0 To 7
            For j As Integer = 0 To 7

                Select Case board(i, j)
                    Case 1
                        Chess.pb(i, j).Image = My.Resources.wKing
                    Case 2
                        Chess.pb(i, j).Image = My.Resources.wQueen
                    Case 3
                        Chess.pb(i, j).Image = My.Resources.wBishop
                    Case 4
                        Chess.pb(i, j).Image = My.Resources.wKnight
                    Case 5
                        Chess.pb(i, j).Image = My.Resources.wRook
                    Case 6
                        Chess.pb(i, j).Image = My.Resources.wPawn
                    Case -1
                        Chess.pb(i, j).Image = My.Resources.bKing
                    Case -2
                        Chess.pb(i, j).Image = My.Resources.bQueen
                    Case -3
                        Chess.pb(i, j).Image = My.Resources.bBishop
                    Case -4
                        Chess.pb(i, j).Image = My.Resources.bKnight
                    Case -5
                        Chess.pb(i, j).Image = My.Resources.bRook
                    Case -6
                        Chess.pb(i, j).Image = My.Resources.bPawn
                    Case Else
                        Chess.pb(i, j).Image = Nothing
                End Select
            Next
        Next
    End Sub

    Public Sub checkmate()
        Dim original_position_x As Integer
        Dim original_position_y As Integer
        original_position_x = Chess.w_king.x_pos
        original_position_y = Chess.w_king.y_pos
        Chess.w_king.re_flags()
        Chess.w_king.poss_mov()
        Chess.w_queen.re_flags()
        Chess.w_queen.poss_mov()
        For i As Integer = 0 To 1
            Chess.w_bishop(i).re_flags()
            Chess.w_bishop(i).poss_mov()
        Next
        For i As Integer = 0 To 1
            Chess.w_knight(i).re_flags()
            Chess.w_knight(i).poss_mov()
        Next
        For i As Integer = 0 To 1
            Chess.w_rook(i).re_flags()
            Chess.w_rook(i).poss_mov()
        Next
        For i As Integer = 0 To 7
            Chess.w_pawn(i).re_flags()
            Chess.w_pawn(i).poss_mov()
        Next
        Chess.b_king.re_flags()
        Chess.b_king.poss_mov()
        Chess.b_queen.re_flags()
        Chess.b_queen.poss_mov()
        For i As Integer = 0 To 1
            Chess.b_bishop(i).re_flags()
            Chess.b_bishop(i).poss_mov()
        Next
        For i As Integer = 0 To 1
            Chess.b_knight(i).re_flags()
            Chess.b_knight(i).poss_mov()
        Next
        For i As Integer = 0 To 1
            Chess.b_rook(i).re_flags()
            Chess.b_rook(i).poss_mov()
        Next
        For i As Integer = 0 To 7
            Chess.b_pawn(i).re_flags()
            Chess.b_pawn(i).poss_mov()
        Next
        If w_in_danger Then
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    If Chess.w_king.flags(i, j) = True Then
                        Chess.w_king.change_pos(i, j, original_position_x, original_position_y)
                        re_chk_white()
                        re_chk_black()
                        fill_chk_for_white()
                        fill_chk_for_black()
                        If check_for_white(i, j) = True Then
                            Chess.w_king.change_pos(original_position_x, original_position_y, i, j)
                        Else
                            game_flag = True
                            Chess.w_king.change_pos(original_position_x, original_position_y, i, j)
                            Exit For
                        End If
                    End If
                Next
                If game_flag = True Then
                    Exit For
                End If
            Next
            original_position_x = Chess.w_queen.x_pos
            original_position_y = Chess.w_queen.y_pos
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    If Chess.w_queen.flags(i, j) = True Then
                        Chess.w_queen.change_pos(i, j, original_position_x, original_position_y)
                        re_chk_white()
                        re_chk_black()
                        fill_chk_for_white()
                        fill_chk_for_black()
                        If check_for_white(Chess.w_king.y_pos, Chess.w_king.x_pos) = True Then
                            Chess.w_queen.change_pos(original_position_x, original_position_y, i, j)
                        Else
                            game_flag = True
                            Chess.w_queen.change_pos(original_position_x, original_position_y, i, j)
                            Exit For
                        End If
                    End If
                Next
                If game_flag = True Then
                    Exit For
                End If
            Next
            For z As Integer = 0 To 1
                original_position_x = Chess.w_bishop(z).x_pos
                original_position_y = Chess.w_bishop(z).y_pos
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        If Chess.w_bishop(z).flags(i, j) = True Then
                            Chess.w_bishop(z).change_pos(i, j, original_position_x, original_position_y)
                            re_chk_white()
                            re_chk_black()
                            fill_chk_for_white()
                            fill_chk_for_black()
                            If check_for_white(Chess.w_king.y_pos, Chess.w_king.x_pos) = True Then
                                Chess.w_bishop(z).change_pos(original_position_x, original_position_y, i, j)
                            Else
                                game_flag = True
                                Chess.w_bishop(z).change_pos(original_position_x, original_position_y, i, j)
                                Exit For
                            End If
                        End If
                    Next
                    If game_flag = True Then
                        Exit For
                    End If
                Next
                If game_flag = True Then
                    Exit For
                End If
            Next
            For z As Integer = 0 To 1
                original_position_x = Chess.w_knight(z).x_pos
                original_position_y = Chess.w_knight(z).y_pos
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        If Chess.w_knight(z).flags(i, j) = True Then
                            Chess.w_knight(z).change_pos(i, j, original_position_x, original_position_y)
                            re_chk_white()
                            re_chk_black()
                            fill_chk_for_white()
                            fill_chk_for_black()
                            If check_for_white(Chess.w_king.y_pos, Chess.w_king.x_pos) = True Then
                                Chess.w_knight(z).change_pos(original_position_x, original_position_y, i, j)
                            Else
                                game_flag = True
                                Chess.w_knight(z).change_pos(original_position_x, original_position_y, i, j)
                                Exit For
                            End If
                        End If
                    Next
                    If game_flag = True Then
                        Exit For
                    End If
                Next
                If game_flag = True Then
                    Exit For
                End If
            Next
            For z As Integer = 0 To 1
                original_position_x = Chess.w_rook(z).x_pos
                original_position_y = Chess.w_rook(z).y_pos
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        If Chess.w_rook(z).flags(i, j) = True Then
                            Chess.w_rook(z).change_pos(i, j, original_position_x, original_position_y)
                            re_chk_white()
                            re_chk_black()
                            fill_chk_for_white()
                            fill_chk_for_black()
                            If check_for_white(Chess.w_king.y_pos, Chess.w_king.x_pos) = True Then
                                Chess.w_rook(z).change_pos(original_position_x, original_position_y, i, j)
                            Else
                                game_flag = True
                                Chess.w_rook(z).change_pos(original_position_x, original_position_y, i, j)
                                Exit For
                            End If
                        End If
                    Next
                    If game_flag = True Then
                        Exit For
                    End If
                Next
                If game_flag = True Then
                    Exit For
                End If
            Next
            For z As Integer = 0 To 7
                original_position_x = Chess.w_pawn(z).x_pos
                original_position_y = Chess.w_pawn(z).y_pos
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        If Chess.w_pawn(z).flags(i, j) = True Then
                            Chess.w_pawn(z).change_pos(i, j, original_position_x, original_position_y)
                            re_chk_white()
                            re_chk_black()
                            fill_chk_for_white()
                            fill_chk_for_black()
                            If check_for_white(Chess.w_king.y_pos, Chess.w_king.x_pos) = True Then
                                Chess.w_pawn(z).change_pos(original_position_x, original_position_y, i, j)
                            Else
                                game_flag = True
                                Chess.w_pawn(z).change_pos(original_position_x, original_position_y, i, j)
                                Exit For
                            End If
                        End If
                    Next
                    If game_flag = True Then
                        Exit For
                    End If
                Next
                If game_flag = True Then
                    Exit For
                End If
            Next
            If game_flag = False Then
                MsgBox("White Wins!")
            End If
        ElseIf b_in_danger Then
            original_position_x = Chess.b_king.x_pos
            original_position_y = Chess.b_king.y_pos
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    If Chess.b_king.flags(i, j) = True Then
                        Chess.b_king.change_pos(i, j, original_position_x, original_position_y)
                        re_chk_white()
                        re_chk_black()
                        fill_chk_for_white()
                        fill_chk_for_black()
                        If check_for_black(i, j) = True Then
                            Chess.b_king.change_pos(original_position_x, original_position_y, i, j)
                        Else
                            game_flag = True
                            Chess.b_king.change_pos(original_position_x, original_position_y, i, j)
                            Exit For
                        End If
                    End If
                Next
                If game_flag = True Then
                    Exit For
                End If
            Next
            original_position_x = Chess.b_queen.x_pos
            original_position_y = Chess.b_queen.y_pos
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    If Chess.b_queen.flags(i, j) = True Then
                        Chess.b_queen.change_pos(i, j, original_position_x, original_position_y)
                        re_chk_white()
                        re_chk_black()
                        fill_chk_for_white()
                        fill_chk_for_black()
                        If check_for_black(Chess.b_king.y_pos, Chess.b_king.x_pos) = True Then
                            Chess.b_queen.change_pos(original_position_x, original_position_y, i, j)
                        Else
                            game_flag = True
                            Chess.b_queen.change_pos(original_position_x, original_position_y, i, j)
                            Exit For
                        End If
                    End If
                Next
                If game_flag = True Then
                    Exit For
                End If
            Next
            For z As Integer = 0 To 1
                original_position_x = Chess.b_bishop(z).x_pos
                original_position_y = Chess.b_bishop(z).y_pos
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        If Chess.b_bishop(z).flags(i, j) = True Then
                            Chess.b_bishop(z).change_pos(i, j, original_position_x, original_position_y)
                            re_chk_white()
                            re_chk_black()
                            fill_chk_for_white()
                            fill_chk_for_black()
                            If check_for_black(Chess.b_king.y_pos, Chess.b_king.x_pos) = True Then
                                Chess.b_bishop(z).change_pos(original_position_x, original_position_y, i, j)
                            Else
                                game_flag = True
                                Chess.b_bishop(z).change_pos(original_position_x, original_position_y, i, j)
                                Exit For
                            End If
                        End If
                    Next
                    If game_flag = True Then
                        Exit For
                    End If
                Next
                If game_flag = True Then
                    Exit For
                End If
            Next
            For z As Integer = 0 To 1
                original_position_x = Chess.b_knight(z).x_pos
                original_position_y = Chess.b_knight(z).y_pos
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        If Chess.b_knight(z).flags(i, j) = True Then
                            Chess.b_knight(z).change_pos(i, j, original_position_x, original_position_y)
                            re_chk_white()
                            re_chk_black()
                            fill_chk_for_white()
                            fill_chk_for_black()
                            If check_for_black(Chess.b_king.y_pos, Chess.b_king.x_pos) = True Then
                                Chess.b_knight(z).change_pos(original_position_x, original_position_y, i, j)
                            Else
                                game_flag = True
                                Chess.b_knight(z).change_pos(original_position_x, original_position_y, i, j)
                                Exit For
                            End If
                        End If
                    Next
                    If game_flag = True Then
                        Exit For
                    End If
                Next
                If game_flag = True Then
                    Exit For
                End If
            Next
            For z As Integer = 0 To 1
                original_position_x = Chess.b_rook(z).x_pos
                original_position_y = Chess.b_rook(z).y_pos
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        If Chess.b_rook(z).flags(i, j) = True Then
                            Chess.b_rook(z).change_pos(i, j, original_position_x, original_position_y)
                            re_chk_white()
                            re_chk_black()
                            fill_chk_for_white()
                            fill_chk_for_black()
                            If check_for_black(Chess.b_king.y_pos, Chess.b_king.x_pos) = True Then
                                Chess.b_rook(z).change_pos(original_position_x, original_position_y, i, j)
                            Else
                                game_flag = True
                                Chess.b_rook(z).change_pos(original_position_x, original_position_y, i, j)
                                Exit For
                            End If
                        End If
                    Next
                    If game_flag = True Then
                        Exit For
                    End If
                Next
                If game_flag = True Then
                    Exit For
                End If
            Next
            For z As Integer = 0 To 7
                original_position_x = Chess.b_pawn(z).x_pos
                original_position_y = Chess.b_pawn(z).y_pos
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        If Chess.b_pawn(z).flags(i, j) = True Then
                            Chess.b_pawn(z).change_pos(i, j, original_position_x, original_position_y)
                            re_chk_white()
                            re_chk_black()
                            fill_chk_for_white()
                            fill_chk_for_black()
                            If check_for_black(Chess.b_king.y_pos, Chess.b_king.x_pos) = True Then
                                Chess.b_pawn(z).change_pos(original_position_x, original_position_y, i, j)
                            Else
                                game_flag = True
                                Chess.b_pawn(z).change_pos(original_position_x, original_position_y, i, j)
                                Exit For
                            End If
                        End If
                    Next
                    If game_flag = True Then
                        Exit For
                    End If
                Next
                If game_flag = True Then
                    Exit For
                End If
            Next
            If game_flag = False Then
                MsgBox("Black Wins!")
            End If
        Else
            game_flag = True
        End If
    End Sub

    'Public Sub checkmate()
    '    If b_in_danger = True Then
    '        game_flag = False
    '        Chess.b_king.poss_mov()
    '        For i As Integer = 0 To 7
    '            For j As Integer = 0 To 7
    '                If Chess.b_king.flags(i, j) = True Then
    '                    game_flag = True
    '                End If
    '            Next
    '        Next
    '        taken_verify()
    '        If piece_checking = "w_queen" Then
    '            If can_be_taken(Chess.w_queen.x_pos, Chess.w_queen.y_pos) Then
    '                game_flag = True
    '            End If
    '        ElseIf piece_checking = "w_rook" Then
    '            For i As Integer = 0 To 1
    '                If can_be_taken(Chess.w_rook(i).x_pos, Chess.w_rook(i).y_pos) Then
    '                    game_flag = True
    '                End If
    '            Next
    '        ElseIf piece_checking = "w_bishop" Then
    '            For i As Integer = 0 To 1
    '                If can_be_taken(Chess.w_bishop(i).x_pos, Chess.w_bishop(i).y_pos) Then
    '                    game_flag = True
    '                End If
    '            Next
    '        ElseIf piece_checking = "w_knight" Then
    '            For i As Integer = 0 To 1
    '                If can_be_taken(Chess.w_knight(i).x_pos, Chess.w_knight(i).y_pos) Then
    '                    game_flag = True
    '                End If
    '            Next
    '        ElseIf piece_checking = "w_pawn" Then
    '            For i As Integer = 0 To 7
    '                If can_be_taken(Chess.w_pawn(i).x_pos, Chess.w_pawn(i).y_pos) Then
    '                    game_flag = True
    '                End If
    '            Next
    '        End If

    '        If game_flag = False Then
    '            MsgBox("White Wins!")
    '        End If


    '    ElseIf w_in_danger = True Then
    '        game_flag = False
    '        Chess.w_king.poss_mov()
    '        For i As Integer = 0 To 7
    '            For j As Integer = 0 To 7
    '                If Chess.w_king.flags(i, j) = True Then
    '                    game_flag = True
    '                End If
    '            Next
    '        Next
    '        taken_verify()
    '        If piece_checking = "b_queen" Then
    '            If can_be_taken(Chess.b_queen.x_pos, Chess.b_queen.y_pos) Then
    '                game_flag = True
    '            End If
    '        ElseIf piece_checking = "b_rook" Then
    '            For i As Integer = 0 To 1
    '                If can_be_taken(Chess.b_rook(i).x_pos, Chess.b_rook(i).y_pos) Then
    '                    game_flag = True
    '                End If
    '            Next
    '        ElseIf piece_checking = "b_bishop" Then
    '            For i As Integer = 0 To 1
    '                If can_be_taken(Chess.b_bishop(i).x_pos, Chess.b_bishop(i).y_pos) Then
    '                    game_flag = True
    '                End If
    '            Next
    '        ElseIf piece_checking = "b_knight" Then
    '            For i As Integer = 0 To 1
    '                If can_be_taken(Chess.b_knight(i).x_pos, Chess.b_knight(i).y_pos) Then
    '                    game_flag = True
    '                End If
    '            Next
    '        ElseIf piece_checking = "b_pawn" Then
    '            For i As Integer = 0 To 7
    '                If can_be_taken(Chess.b_pawn(i).x_pos, Chess.b_pawn(i).y_pos) Then
    '                    game_flag = True
    '                End If
    '            Next
    '        End If

    '        If game_flag = False Then
    '            MsgBox("Black Wins!")
    '        End If

    '    End If

    'End Sub

    Public Sub protection()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If board(i, j) > 0 Then
                    If Chess.w_queen.flags(i, j) = True Then
                        piece_protected(i, j) = True
                    End If
                    For z As Integer = 0 To 1
                        If Chess.w_bishop(z).flags(i, j) = True Then
                            piece_protected(i, j) = True
                        End If
                    Next
                    For z As Integer = 0 To 1
                        If Chess.w_knight(z).flags(i, j) = True Then
                            piece_protected(i, j) = True
                        End If
                    Next
                    For z As Integer = 0 To 1
                        If Chess.w_rook(z).flags(i, j) = True Then
                            piece_protected(i, j) = True
                        End If
                    Next
                    For z As Integer = 0 To 7
                        If Chess.w_pawn(z).flags(i, j) = True Then
                            piece_protected(i, j) = True
                        End If
                    Next
                End If
                If board(i, j) < 0 Then
                    If Chess.b_queen.flags(i, j) = True Then
                        piece_protected(i, j) = True
                    End If
                    For z As Integer = 0 To 1
                        If Chess.b_bishop(z).flags(i, j) = True Then
                            piece_protected(i, j) = True
                        End If
                    Next
                    For z As Integer = 0 To 1
                        If Chess.b_knight(z).flags(i, j) = True Then
                            piece_protected(i, j) = True
                        End If
                    Next
                    For z As Integer = 0 To 1
                        If Chess.b_rook(z).flags(i, j) = True Then
                            piece_protected(i, j) = True
                        End If
                    Next
                    For z As Integer = 0 To 7
                        If Chess.b_pawn(z).flags(i, j) = True Then
                            piece_protected(i, j) = True
                        End If
                    Next
                End If
            Next
        Next
    End Sub
    Public Sub taken_verify()
        protection()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If board(i, j) < 0 Then
                    If Chess.w_king.flags(i, j) = True And piece_protected(i, j) = False Then
                        can_be_taken(i, j) = True
                    End If
                    If Chess.w_queen.flags(i, j) = True Then
                        can_be_taken(i, j) = True
                    End If
                    For z As Integer = 0 To 1
                        If Chess.w_bishop(z).flags(i, j) = True Then
                            can_be_taken(i, j) = True
                        End If
                    Next
                    For z As Integer = 0 To 1
                        If Chess.w_knight(z).flags(i, j) = True Then
                            can_be_taken(i, j) = True
                        End If
                    Next
                    For z As Integer = 0 To 1
                        If Chess.w_rook(z).flags(i, j) = True Then
                            can_be_taken(i, j) = True
                        End If
                    Next
                    For z As Integer = 0 To 7
                        If Chess.w_pawn(z).flags(i, j) = True Then
                            can_be_taken(i, j) = True
                        End If
                    Next
                End If
                If board(i, j) > 0 Then
                    If Chess.b_king.flags(i, j) = True And piece_protected(i, j) = False Then
                        can_be_taken(i, j) = True
                    End If
                    If Chess.b_queen.flags(i, j) = True Then
                        can_be_taken(i, j) = True
                    End If
                    For z As Integer = 0 To 1
                        If Chess.b_bishop(z).flags(i, j) = True Then
                            can_be_taken(i, j) = True
                        End If
                    Next
                    For z As Integer = 0 To 1
                        If Chess.b_knight(z).flags(i, j) = True Then
                            can_be_taken(i, j) = True
                        End If
                    Next
                    For z As Integer = 0 To 1
                        If Chess.b_rook(z).flags(i, j) = True Then
                            can_be_taken(i, j) = True
                        End If
                    Next
                    For z As Integer = 0 To 7
                        If Chess.b_pawn(z).flags(i, j) = True Then
                            can_be_taken(i, j) = True
                        End If
                    Next
                End If
            Next
        Next
    End Sub

    Public Sub re_back()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                Chess.pb(i, j).BackgroundImage = Nothing
            Next
        Next
    End Sub

    Public Sub re_can_move()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                can_move(i, j) = False
            Next
        Next
    End Sub

    Public Sub re_chk_white()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                check_for_white(i, j) = False
            Next
        Next
    End Sub

    Public Sub re_chk_black()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                check_for_black(i, j) = False
            Next
        Next
    End Sub

    Public Function selection(ByVal x As Integer, ByVal y As Integer)
        If game_flag = True Then
            If board(x, y) <> 0 Then
                Chess.pb(x, y).BackgroundImage = My.Resources.selection
            End If
            Select Case board(x, y)
                Case 1
                    If player = 1 Then
                        show_possible_move(Chess.w_king.poss_mov())
                        Return "w_king"
                    End If
                Case 2
                    If player = 1 Then
                        show_possible_move(Chess.w_queen.poss_mov())
                        Return "w_queen"
                    End If
                Case 3
                    If player = 1 Then
                        For i As Integer = 0 To 1
                            If Chess.w_bishop(i).ret_x = x And Chess.w_bishop(i).ret_y = y Then
                                show_possible_move(Chess.w_bishop(i).poss_mov())
                            End If
                        Next
                        Return "w_bishop"
                    End If
                Case 4
                    If player = 1 Then
                        For i As Integer = 0 To 1
                            If Chess.w_knight(i).ret_x = x And Chess.w_knight(i).ret_y = y Then
                                show_possible_move(Chess.w_knight(i).poss_mov())
                            End If
                        Next
                        Return "w_knight"
                    End If
                Case 5
                    If player = 1 Then
                        For i As Integer = 0 To 1
                            If Chess.w_rook(i).ret_x = x And Chess.w_rook(i).ret_y = y Then
                                show_possible_move(Chess.w_rook(i).poss_mov())
                            End If
                        Next
                        Return "w_rook"
                    End If
                Case 6
                    If player = 1 Then
                        For i As Integer = 0 To 7
                            If Chess.w_pawn(i).ret_x = x And Chess.w_pawn(i).ret_y = y Then
                                show_possible_move(Chess.w_pawn(i).poss_mov())
                            End If
                        Next
                        Return "w_pawn"
                    End If
                Case -1
                    If player = 2 Then
                        show_possible_move(Chess.b_king.poss_mov())
                        Return "b_king"
                    End If
                Case -2
                    If player = 2 Then
                        show_possible_move(Chess.b_queen.poss_mov())
                        Return "b_queen"
                    End If
                Case -3
                    If player = 2 Then
                        For i As Integer = 0 To 1
                            If Chess.b_bishop(i).ret_x = x And Chess.b_bishop(i).ret_y = y Then
                                show_possible_move(Chess.b_bishop(i).poss_mov())
                            End If
                        Next
                        Return "b_bishop"
                    End If
                Case -4
                    If player = 2 Then
                        For i As Integer = 0 To 1
                            If Chess.b_knight(i).ret_x = x And Chess.b_knight(i).ret_y = y Then
                                show_possible_move(Chess.b_knight(i).poss_mov())
                            End If
                        Next
                        Return "b_knight"
                    End If
                Case -5
                    If player = 2 Then
                        For i As Integer = 0 To 1
                            If Chess.b_rook(i).ret_x = x And Chess.b_rook(i).ret_y = y Then
                                show_possible_move(Chess.b_rook(i).poss_mov())
                            End If
                        Next
                        Return "b_rook"
                    End If
                Case -6
                    If player = 2 Then
                        For i As Integer = 0 To 7
                            If Chess.b_pawn(i).ret_x = x And Chess.b_pawn(i).ret_y = y Then
                                show_possible_move(Chess.b_pawn(i).poss_mov())
                            End If
                        Next
                        Return "b_pawn"
                    End If
                Case Else
                    Return Nothing
            End Select
        End If
    End Function

    Public Sub fill_chk_for_black()
        re_chk_black()
        For i As Integer = 0 To 7
            Chess.w_pawn(i).fill_chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If Chess.w_pawn(i).check_the_king(j, k) = True Then
                        check_for_black(j, k) = True
                        piece_checking = "w_pawn"
                    End If
                Next
            Next
        Next

        For i As Integer = 0 To 1
            Chess.w_rook(i).fill_chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If Chess.w_rook(i).check_the_king(j, k) = True Then
                        check_for_black(j, k) = True
                        piece_checking = "w_rook"
                    End If
                Next
            Next
        Next
        For i As Integer = 0 To 1
            Chess.w_bishop(i).fill_chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If Chess.w_bishop(i).check_the_king(j, k) = True Then
                        check_for_black(j, k) = True
                        piece_checking = "w_bishop"
                    End If
                Next
            Next
        Next

        For i As Integer = 0 To 1
            Chess.w_knight(i).fill_chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If Chess.w_knight(i).check_the_king(j, k) = True Then
                        check_for_black(j, k) = True
                        piece_checking = "w_knight"
                    End If
                Next
            Next
        Next

        Chess.w_queen.fill_chk_king()
        For j As Integer = 0 To 7
            For k As Integer = 0 To 7
                If Chess.w_queen.check_the_king(j, k) = True Then
                    check_for_black(j, k) = True
                    piece_checking = "w_queen"
                End If
            Next
        Next

    End Sub

    Public Sub fill_chk_for_white()
        re_chk_white()
        For i As Integer = 0 To 7
            Chess.b_pawn(i).fill_chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If Chess.b_pawn(i).check_the_king(j, k) = True Then
                        check_for_white(j, k) = True
                        piece_checking = "b_pawn"
                    End If
                Next
            Next
        Next

        For i As Integer = 0 To 1
            Chess.b_rook(i).fill_chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If Chess.b_rook(i).check_the_king(j, k) = True Then
                        check_for_white(j, k) = True
                        piece_checking = "b_rook"
                    End If
                Next
            Next
        Next
        For i As Integer = 0 To 1
            Chess.b_bishop(i).fill_chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If Chess.b_bishop(i).check_the_king(j, k) = True Then
                        check_for_white(j, k) = True
                        piece_checking = "b_bishop"
                    End If
                Next
            Next
        Next

        For i As Integer = 0 To 1
            Chess.b_knight(i).fill_chk_king()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If Chess.b_knight(i).check_the_king(j, k) = True Then
                        check_for_white(j, k) = True
                        piece_checking = "b_knight"
                    End If
                Next
            Next
        Next

        Chess.b_queen.fill_chk_king()
        For j As Integer = 0 To 7
            For k As Integer = 0 To 7
                If Chess.b_queen.check_the_king(j, k) = True Then
                    check_for_white(j, k) = True
                    piece_checking = "b_queen"
                End If
            Next
        Next

    End Sub

    Public Sub show_chk()
        w_in_danger = False
        b_in_danger = False

        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If check_for_black(i, j) = True And Chess.b_king.x_pos = i And Chess.b_king.y_pos = j Then
                    Chess.pb(i, j).BackgroundImage = My.Resources.check
                    b_in_danger = True
                End If
            Next
        Next


        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If check_for_white(i, j) = True And Chess.w_king.x_pos = i And Chess.w_king.y_pos = j Then
                    Chess.pb(i, j).BackgroundImage = My.Resources.check
                    w_in_danger = True
                End If
            Next
        Next

    End Sub

    Public Sub show_possible_move(ByVal b As Boolean(,))
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If b(i, j) = True Then
                    Chess.pb(i, j).BackgroundImage = My.Resources.possmov
                    can_move(i, j) = True
                End If
            Next
        Next
    End Sub

    Public Sub mov(ByVal selectedpiece, ByVal x, ByVal y, ByVal pre_x, ByVal pre_y)
        Select Case selectedpiece
            Case "w_king"
                If pre_y = 4 And pre_x = 0 And y = 2 And x = 0 Then
                    Chess.w_king.CastlingLeft = True
                ElseIf pre_y = 4 And pre_x = 0 And y = 6 And x = 0 Then
                    Chess.w_king.CastlingRight = True
                End If
                Chess.w_king.change_pos(x, y, pre_x, pre_y)
                If Chess.w_king.CastlingLeft Then
                    Chess.w_rook(0).change_pos(0, 3, 0, 0)
                End If
                If Chess.w_king.CastlingRight Then
                    Chess.w_rook(1).change_pos(0, 5, 0, 7)
                End If
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
                w_in_danger = False
                player = 2
                wking_move_count = 1
            Case "w_queen"
                Chess.w_queen.change_pos(x, y, pre_x, pre_y)
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
                player = 2
                re_chk_white()
                checkmate()
            Case "w_bishop"
                For i As Integer = 0 To 1
                    If Chess.w_bishop(i).ret_x = pre_x And Chess.w_bishop(i).ret_y = pre_y Then
                        Chess.w_bishop(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
                w_in_danger = False
                player = 2
                re_chk_white()
                checkmate()
            Case "w_knight"
                For i As Integer = 0 To 1
                    If Chess.w_knight(i).ret_x = pre_x And Chess.w_knight(i).ret_y = pre_y Then
                        Chess.w_knight(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
                w_in_danger = False
                player = 2
                re_chk_white()
                checkmate()
            Case "w_rook"
                For i As Integer = 0 To 1
                    If Chess.w_rook(i).ret_x = pre_x And Chess.w_rook(i).ret_y = pre_y Then
                        Chess.w_rook(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
                w_in_danger = False
                player = 2
                re_chk_white()
                checkmate()
            Case "w_pawn"
                For i As Integer = 0 To 7
                    If Chess.w_pawn(i).ret_x = pre_x And Chess.w_pawn(i).ret_y = pre_y And board(x, y) <= 0 Then
                        Chess.w_pawn(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
                w_in_danger = False
                player = 2
                re_chk_white()
                checkmate()
            Case "b_king"
                If pre_y = 4 And pre_x = 7 And y = 2 And x = 7 Then
                    Chess.b_king.CastlingLeft = True
                ElseIf pre_y = 4 And pre_x = 7 And y = 6 And x = 7 Then
                    Chess.b_king.CastlingRight = True
                End If
                Chess.b_king.change_pos(x, y, pre_x, pre_y)
                If Chess.b_king.CastlingLeft Then
                    Chess.b_rook(0).change_pos(7, 3, 7, 0)
                End If
                If Chess.b_king.CastlingRight Then
                    Chess.b_rook(1).change_pos(7, 5, 7, 7)
                End If
                re_chk_white()
                re_chk_black()
                fill_chk_for_black()
                fill_chk_for_white()
                show_chk()
                b_in_danger = False
                player = 1
                bking_move_count = 1
            Case "b_queen"
                Chess.b_queen.change_pos(x, y, pre_x, pre_y)

                re_chk_white()
                re_chk_black()
                fill_chk_for_black()
                fill_chk_for_white()
                show_chk()
                b_in_danger = False
                player = 1
                re_chk_black()
                checkmate()

            Case "b_bishop"
                For i As Integer = 0 To 1
                    If Chess.b_bishop(i).ret_x = pre_x And Chess.b_bishop(i).ret_y = pre_y Then
                        Chess.b_bishop(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
                b_in_danger = False
                player = 1
                re_chk_black()
                checkmate()
            Case "b_knight"
                For i As Integer = 0 To 1
                    If Chess.b_knight(i).ret_x = pre_x And Chess.b_knight(i).ret_y = pre_y Then
                        Chess.b_knight(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next

                re_chk_white()
                re_chk_black()
                fill_chk_for_black()
                fill_chk_for_white()
                show_chk()
                b_in_danger = False
                player = 1
                re_chk_black()
                checkmate()
            Case "b_rook"
                For i As Integer = 0 To 1
                    If Chess.b_rook(i).ret_x = pre_x And Chess.b_rook(i).ret_y = pre_y Then
                        Chess.b_rook(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next

                re_chk_white()
                re_chk_black()
                fill_chk_for_black()
                fill_chk_for_white()
                show_chk()
                b_in_danger = False
                player = 1
                re_chk_black()
                checkmate()
            Case "b_pawn"
                For i As Integer = 0 To 7
                    If Chess.b_pawn(i).ret_x = pre_x And Chess.b_pawn(i).ret_y = pre_y And board(x, y) >= 0 Then
                        Chess.b_pawn(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                fill_chk_for_black()
                fill_chk_for_white()
                show_chk()
                b_in_danger = False
                player = 1
                re_chk_black()
                checkmate()
            Case Else
        End Select
    End Sub

End Class
