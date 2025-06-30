:- initialization(main).

main :-
    loop_symdiff.

loop_symdiff :-
    repeat,
      write('Введите первое множество (список без повторов). или q. для выхода: '), flush_output,
      read(A),
      ( A == q ->
          writeln('Выход из программы.'), !
      ; write('Введите второе множество. или q. для выхода: '), flush_output,
        read(B),
        ( B == q ->
            writeln('Выход из программы.'), !
        ; ( is_list(A), is_list(B) ->
              difference(A, B, D1),
              difference(B, A, D2),
              append(D1, D2, SymDiff),
              format('Симметрическая разность: ~w~n', [SymDiff])
          ; format('Ошибка: введите два списка без повторов или q.~n', [])
          ),
          fail
        ),
        fail
      ).

difference([], _, []).
difference([H|T], B, [H|R]) :-
    \+ member(H, B), !,
    difference(T, B, R).
difference([_|T], B, R) :-
    difference(T, B, R).
