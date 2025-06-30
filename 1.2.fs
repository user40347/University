open System


let rec sumDigits n =
    if n = 0 then 0
    else (n % 10) + sumDigits (n / 10)  

let rec readNatural prompt =
    printf "%s" prompt
    match Console.ReadLine() with
    | null | "" ->
        printfn "Ошибка: введите натуральное число."
        readNatural prompt
    | s ->
        match System.Int32.TryParse(s) with
        | (true, v) when v > 0 -> v   
        | _ ->
            printfn "Ошибка: введите натуральное число больше нуля."
            readNatural prompt

// Основная логика
let number = readNatural "Введите натуральное число: "
let result = sumDigits number
printfn "Сумма цифр числа %d = %d" number result
