open System
printf"Введите число: "
let s = Console.ReadLine()


let testInt (str:string) = [
    for i in 0..str.Length-1 do
        match str[i] with
        | '+' | '-' when i = 0 -> ()
        | '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9' -> yield int((s[i]).ToString())
        | _ ->
            printf"Это не натуральное число. Программа завершена"
            Environment.Exit(0)
        ]
        
 
let sumList list =
    let rec loop acc = function
        | [] -> acc
        | head :: tail -> loop (acc + head) tail
    loop 0 list

printf "Послед %A" (sumList (testInt s))

