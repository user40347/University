:- use_module(library(readutil)).
:- initialization(main).

main :-
    loop_digits.

loop_digits :-
    repeat,
    write('Введите натуральное число N или q для выхода: '), flush_output,
    read_line_to_string(user_input, S),
    ( S == "q" ->
        writeln('Выход из программы.'), !
    ; ( number_string(N, S), integer(N), N >= 0 ->
          number_codes(N, Codes),
          maplist(code_digit, Codes, Digits),
          format('Список цифр: ~w~n', [Digits])
      ; format('Ошибка: «~w» не является натуральным числом.~n', [S])
      ),
      fail
    ).

code_digit(Code, Digit) :-
    Digit is Code - 0'0.
