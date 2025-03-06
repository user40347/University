open System

let testInt (str:string) = 
    for i in 0..str.Length-1 do
        match str[i] with
        | '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9'  -> ()
        | _ ->
            printf"Это не целое число. Программа завершена"
            Environment.Exit(0)
    int(str)

let testFloat (str:string) = 
    for i in 0..str.Length-1 do
        match str[i] with
        | '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9' | '.' -> ()
        | _ ->
            printf"Это не число. Программа завершена"
            Environment.Exit(0)
    float(str)
        
printf"Введите количество чисел: "
let n = (testInt (Console.ReadLine()))

let listf = [
    for i in 1..n do
        printf"Введите число: "
        yield (testFloat (Console.ReadLine()))
    ]


let takeFirst x = int(((x.ToString())[0]).ToString())

let resultList = List.map takeFirst listf;

printfn "Полученный список: %A" resultList
