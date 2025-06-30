open System


let rec readChar prompt =
    printf "%s" prompt
    match Console.ReadLine() with
    | null | "" ->
        printfn "Ошибка: введите один символ."
        readChar prompt
    | s when s.Length = 1 -> s.[0]
    | _ ->
        printfn "Ошибка: введите ровно один символ."
        readChar prompt


let rec readPositiveInt prompt =
    printf "%s" prompt
    match Console.ReadLine() with
    | null | "" ->
        printfn "Ошибка: введите целое число."
        readPositiveInt prompt
    | s ->
        match Int32.TryParse(s) with
        | (true, v) when v > 0 -> v
        | _ ->
            printfn "Ошибка: введите число > 0."
            readPositiveInt prompt


let createAlternatingList char1 char2 count =
    List.init count (fun i -> if i % 2 = 0 then char1 else char2)


let c1 = readChar "Введите первый символ: "
let c2 = readChar "Введите второй символ: "
let n  = readPositiveInt "Введите количество элементов: "
let result = createAlternatingList c1 c2 n
printfn "Результат: %A" result
