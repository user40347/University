open System

let testInt (str:string) = 
    for i in 0..str.Length-1 do
        match str[i] with
        | '+' | '-' when i = 0 -> ()
        | '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9'  -> ()
        | _ ->
            printf"Это не целое число. Программа завершена"
            Environment.Exit(0)
    int(str)

let testFloat (str:string) = 
    for i in 0..str.Length-1 do
        match str[i] with
        | '+' | '-' when i = 0 -> ()
        | '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9' | '.' -> ()
        | _ ->
            printf"Это не число. Программа завершена"
            Environment.Exit(0)
    float(str)
        
printf"Введите количество чисел: "
let n = (testInt (Console.ReadLine()))
if n<0 then
    printf"Значение вне списка. Программа завершена"
    Environment.Exit(0)
printfn"Выберите способ заполнения \n1) С клавиатуры \n2) Путем заполнения случайными числами "
let selectmethod = Console.ReadLine()

let rnd = Random()
let listf = [
    for i in 1..n do
        if(selectmethod[0] = '1')then
            printfn"Введите число: "
            yield (testFloat (Console.ReadLine()))
        else if(selectmethod[0] = '2')then
            yield (float(rnd.Next(10,1000)))/10.0
        else
            printf"Значение вне списка. Программа завершена"
            Environment.Exit(0)
            ]
printfn "Текущий список: %A" listf


let rec takeFirst x =
    let x = abs x
    if x < 10.0 then 
      float(int(x))  
    else 
        takeFirst (x / 10.0)

let resultList = List.map takeFirst listf;

printfn "Полученный список: %A" resultList
