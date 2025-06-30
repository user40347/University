difference([], _, []).
difference([H|T], B, [H|DiffTail]) :-
    \+ member(H, B),
    difference(T, B, DiffTail).
difference([H|T], B, DiffTail) :-
    member(H, B),
    difference(T, B, DiffTail).

symmetric_difference(A, B, SymDiff) :-
    difference(A, B, D1),
    difference(B, A, D2),
    append(D1, D2, SymDiff).

ivan_ok(R) :-
    ( member(spartak-1, R) -> T1 = true ; T1 = false ),
    ( member(cska-4,    R) -> T2 = true ; T2 = false ),
    T1 \= T2.

sergey_ok(R) :-
    ( member(spartak-P, R), P >= 3 -> T1 = true ; T1 = false ),
    ( member(cska-2,     R) -> T2 = true ; T2 = false ),
    T1 \= T2.

petr_ok(R) :-
    ( member(dinamo-1, R) -> T1 = true ; T1 = false ),
    ( member(cska-P,     R), P =< 3 -> T2 = true ; T2 = false ),
    T1 \= T2.

aleksey_ok(R) :-
    ( member(dinamo-2, R) -> T1 = true ; T1 = false ),
    ( member(rotor-4,    R) -> T2 = true ; T2 = false ),
    T1 \= T2.

valid_ranking(R) :-
    ivan_ok(R),
    sergey_ok(R),
    petr_ok(R),
    aleksey_ok(R).

% Генерация всех возможных расстановок
permutation_places(Teams, Ranking) :-
    Places = [1,2,3,4],
    permutation(Places, PermPlaces),
    pair_teams_places(Teams, PermPlaces, Ranking).

pair_teams_places([], [], []).
pair_teams_places([Team|Teams], [Place|Places], [Team-Place|Rest]) :-
    pair_teams_places(Teams, Places, Rest).

all_rankings(Rankings) :-
    Teams = [spartak, cska, dinamo, rotor],
    findall(R, permutation_places(Teams, R), Rankings).

% Основная логика решения
solve_and_show :-
    writeln('Решение логической задачи о футбольном турнире:'),
    writeln(''),
    all_rankings(All),
    member(R, All),
    valid_ranking(R),
    writeln('Найденное решение:'),
    show_result(R),
    writeln(''),
    writeln('Программа завершена. ').
% Красивый вывод результата
show_result(Ranking) :-
    sort(2, @=<, Ranking, Sorted),
    show_places(Sorted, 1).

show_places([], _).
show_places([Team-Place|Rest], Place) :-
    format('~w место - ~w~n', [Place, Team]),
    NextPlace is Place + 1,
    show_places(Rest, NextPlace).

% Предикат для ожидания ввода пользователя
wait_for_user :-
    get_char(_).

% Основной предикат с обработкой ошибок
main :-
    catch(
        (solve_and_show, wait_for_user),
        Error,
        (writeln('Произошла ошибка:'), writeln(Error))
    ).

:- initialization(main).
