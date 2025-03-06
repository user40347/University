open System
printf"Введите первый символ:"
let c1:char = Console.ReadKey().KeyChar
printf"\nВведите второй символ:"
let c2:char = Console.ReadKey().KeyChar
printf"\nВведите количество повторов:"
let n = Console.ReadLine()


let testInt (str:string) = 
    for i in 0..str.Length-1 do
        match str[i] with
        | '+' | '-' when i = 0 -> ()
        | '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9' -> ()
        | _ ->
            printf"Это не целое число. Программа завершена."
            Environment.Exit(0)
    int(str)
        

let res = 
    [for i in 1..(testInt n) do
        yield c1
        yield c2
    ]

printfn "Полученный список: %A" res
