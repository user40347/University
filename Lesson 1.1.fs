open System
printf"Введите первый символ:"
let c1:char = Console.ReadKey().KeyChar
printf"\nВведите второй символ:"
let c2:char = Console.ReadKey().KeyChar
printf"\nВведите количество повторов:"
let n = int(Console.ReadLine())


let res = 
    [for i in 0..n do
        yield c1
        yield c2
    ]

printfn "Полученный список: %A" res
