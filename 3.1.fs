open System

let items = Seq.empty<float>


let rec testInt () = 
    let str = Console.ReadLine()
    
    let isValid = 
        seq { 0 .. str.Length-1 }
        |> Seq.forall (fun i ->
            match str[i] with
            | '+' | '-' when i = 0 -> true
            | '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9' -> true
            | _ -> false
        )
   
    if isValid then
            int(str)
    else
        printfn "Это не целое число."
        Console.Write("Введите целое число: ")
        testInt()


let rec testFloat () = 
    let str = Console.ReadLine()
    
    let isValid = 
        seq { 0 .. str.Length-1 }
        |> Seq.forall (fun i ->
            match str[i] with
            | '+' | '-' when i = 0 -> true
            | '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9' | '.' -> true
            | _ -> false
        )
    
    if isValid then
            float(str)
    else
        printfn "Это не число."
        Console.Write("Введите вещественное число: ")
        testFloat()


let rec testPositiveInt () = 
    let str = Console.ReadLine()
    
    let isValid = 
        seq { 0 .. str.Length-1 }
        |> Seq.forall (fun i ->
            match str[i] with
            | '+' when i = 0 -> true
            | '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9' -> true
            | _ -> false
        )
    if isValid then
            int(str)
    else
        Console.WriteLine("Недопустимое значение")
        Console.Write("Введите положительное число: ")
        testPositiveInt()


let TryAddToSeq (sequment)= 
    Console.Write("Введите число: ")
    (items |> Seq.insertAt 0 (testFloat()))


printf"Введите количество чисел. \n"
let n = (testPositiveInt())


let rec SelectMethodTest() =
    printfn"Выберите способ заполнения \n1) С клавиатуры \n2) Путем заполнения случайными числами "
    let str = Console.ReadLine()
    if (str = "1" || str = "2") then
        str
    else
        printfn"Нет такого пункта!"
        SelectMethodTest()


let selectmethod = SelectMethodTest()

let rnd = Random()
let rec FillSeq sequment n =
    if n <= 0 then
        printfn "Текущий список: %A" sequment
        sequment 
    else
        if (selectmethod = "1") then
            Console.WriteLine("Введите число")
            (FillSeq ((sequment |> Seq.insertAt 0 (testFloat()))) (n - 1))
        else if (selectmethod = "2") then
            FillSeq (sequment |> Seq.insertAt 0 (float(rnd.Next(10,1000))/10.0)) (n - 1)
        else
            sequment
    
let rec takeFirst (x:float) =
    let x = abs (int(x))
    if x < 10 then 
        x 
    else 
        takeFirst (float(x / 10))

let resultSeq = Seq.map takeFirst (FillSeq items n);
   


printfn "Полученная последовательность: %A" resultSeq
