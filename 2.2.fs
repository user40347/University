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

printfn"Выберите способ заполнения \n1) С клавиатуры \n2) Путем заполнения случайными числами "
let selectmethod = Console.ReadLine()

let rnd = Random()
let listf = [
    for i in 1..n do
        if(selectmethod[0] = '1')then
            printfn"Введите число: "
            yield (testFloat (Console.ReadLine()))
        else if(selectmethod[0] = '2')then
            yield (float(rnd.Next(10,100)))/10.0
        else
            printf"Значение вне списка. Программа завершена"
            Environment.Exit(0)
            
    ]

printfn "Текущий список: %A" listf
printf "Введите число для подсчета: "
let compnum = (testFloat (Console.ReadLine()))



let countOfMatches list target = 
    list |> List.fold (fun acc x -> if x = target then acc + 1 else acc) 0



printfn "Количество чисел %f в списке: %d" compnum (countOfMatches listf compnum)
