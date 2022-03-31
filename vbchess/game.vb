Public Class game

    Public board(7, 7) As Integer
    Public can_move(7, 7) As Boolean
    Public check_for_white(7, 7) As Boolean
    Public check_for_black(7, 7) As Boolean
    Public player As Integer = 1
    Public game_flag As Boolean = True
    Public b_in_danger As Boolean = False
    Public w_in_danger As Boolean = False

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
                show_chk()
            Next
        Next
    End Sub

    Public Sub checkmate()
        If b_in_danger = True Then
            game_flag = False
            Chess.b_king.poss_mov()
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    If Chess.b_king.flags(i, j) = True Then
                        game_flag = True
                    End If
                Next
            Next
            If game_flag = False Then
                MsgBox("White Win")
            End If


        ElseIf w_in_danger = True Then
            game_flag = False
            Chess.w_king.poss_mov()
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    If Chess.w_king.flags(i, j) = True Then
                        game_flag = True
                    End If
                Next
            Next
            If game_flag = False Then
                MsgBox("Black Win")
            End If
        End If

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
                    End If
                Next
            Next
        Next

        Chess.w_queen.fill_chk_king()
        For j As Integer = 0 To 7
            For k As Integer = 0 To 7
                If Chess.w_queen.check_the_king(j, k) = True Then
                    check_for_black(j, k) = True
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
                    End If
                Next
            Next
        Next

        Chess.b_queen.fill_chk_king()
        For j As Integer = 0 To 7
            For k As Integer = 0 To 7
                If Chess.b_queen.check_the_king(j, k) = True Then
                    check_for_white(j, k) = True
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
                Chess.w_king.change_pos(x, y, pre_x, pre_y)
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
                player = 2
                checkmate()
            Case "w_queen"
                Chess.w_queen.change_pos(x, y, pre_x, pre_y)
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
                player = 2
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
                player = 2
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
                player = 2
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
                player = 2
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
                player = 2
                checkmate()
            Case "b_king"
                Chess.b_king.change_pos(x, y, pre_x, pre_y)
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
                player = 1
                checkmate()
            Case "b_queen"
                Chess.b_queen.change_pos(x, y, pre_x, pre_y)
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
                player = 1
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
                player = 1
                checkmate()
            Case "b_knight"
                For i As Integer = 0 To 1
                    If Chess.b_knight(i).ret_x = pre_x And Chess.b_knight(i).ret_y = pre_y Then
                        Chess.b_knight(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
                player = 1
                checkmate()
            Case "b_rook"
                For i As Integer = 0 To 1
                    If Chess.b_rook(i).ret_x = pre_x And Chess.b_rook(i).ret_y = pre_y Then
                        Chess.b_rook(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
                player = 1
                checkmate()
            Case "b_pawn"
                For i As Integer = 0 To 7
                    If Chess.b_pawn(i).ret_x = pre_x And Chess.b_pawn(i).ret_y = pre_y And board(x, y) >= 0 Then
                        Chess.b_pawn(i).change_pos(x, y, pre_x, pre_y)
                    End If
                Next
                re_chk_white()
                re_chk_black()
                fill_chk_for_white()
                fill_chk_for_black()
                show_chk()
                player = 1
                checkmate()
            Case Else
        End Select
    End Sub

End Class
