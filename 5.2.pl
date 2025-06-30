:- initialization(main).

main :-
    loop_count_min.

loop_count_min :-
    repeat,
      write('Введите непустой список чисел [1,2,3,...]. или q. для выхода: '), flush_output,
      read(Input),
      ( Input == q ->
          writeln('Выход из программы.'), !
      ; ( is_list(Input), Input \= [] ->
            min_list(Input, Min),
            count_occurrences(Input, Min, Count),
            format('Минимальный элемент ~w встречается ~w раз.~n', [Min, Count])
        ; format('Ошибка: введите непустой список или q.~n', [])
        ),
        fail
      ).

count_occurrences([], _, 0).
count_occurrences([H|T], E, C) :-
    H =:= E, !,
    count_occurrences(T, E, C1),
    C is C1 + 1.
count_occurrences([_|T], E, C) :-
    count_occurrences(T, E, C).
