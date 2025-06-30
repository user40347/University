open System


let rec readFloat prompt =
    printf "%s" prompt
    match Console.ReadLine() with
    | null | "" ->
        printfn "Ошибка: введите число."
        readFloat prompt
    | s ->
        match Double.TryParse(s) with
        | (true, v) -> v
        | _ ->
            printfn "Ошибка: некорректный формат числа."
            readFloat prompt


let rec readInt prompt =
    printf "%s" prompt
    match Console.ReadLine() with
    | null | "" ->
        printfn "Ошибка: введите целое число."
        readInt prompt
    | s ->
        match Int32.TryParse(s) with
        | (true, v) -> v
        | _ ->
            printfn "Ошибка: некорректный формат целого числа."
            readInt prompt

/// Тип для представления комплексного числа
type ComplexNumber = { Real: float; Imaginary: float }

/// Создание комплексного числа
let createComplex real imag = { Real = real; Imaginary = imag }


let add z1 z2 = 
    { Real = z1.Real + z2.Real; Imaginary = z1.Imaginary + z2.Imaginary }


let subtract z1 z2 = 
    { Real = z1.Real - z2.Real; Imaginary = z1.Imaginary - z2.Imaginary }


let multiply z1 z2 =
    { Real = z1.Real * z2.Real - z1.Imaginary * z2.Imaginary
      Imaginary = z1.Real * z2.Imaginary + z1.Imaginary * z2.Real }


let divide z1 z2 =
    let denom = z2.Real * z2.Real + z2.Imaginary * z2.Imaginary
    if denom = 0.0 then failwith "Деление на ноль"
    { Real = (z1.Real * z2.Real + z1.Imaginary * z2.Imaginary) / denom
      Imaginary = (z1.Imaginary * z2.Real - z1.Real * z2.Imaginary) / denom }

/// Модуль
let modulus z =
    sqrt (z.Real * z.Real + z.Imaginary * z.Imaginary)

/// Аргумент
let argument z =
    atan2 z.Imaginary z.Real

/// Возведение в степень по Муавру
let moivre z n =
    if modulus z = 0.0 then { Real = 0.0; Imaginary = 0.0 }
    else
        let r = modulus z
        let theta = argument z
        let rN = r ** float n
        let tN = float n * theta
        { Real = rN * cos tN; Imaginary = rN * sin tN }


let sign z = { z with Imaginary = -z.Imaginary }


let toString z =
    match z.Real, z.Imaginary with
    | r, 0.0 -> sprintf "%.2f" r
    | 0.0, i when i = 1.0 -> "i"
    | 0.0, i when i = -1.0 -> "-i"
    | 0.0, i -> sprintf "%.2fi" i
    | r, i when i > 0.0 -> sprintf "%.2f + %.2fi" r i
    | r, i -> sprintf "%.2f - %.2fi" r (abs i)


let real1 = readFloat "Введите действительную часть z1: "
let imag1 = readFloat "Введите мнимую часть z1: "
let real2 = readFloat "Введите действительную часть z2: "
let imag2 = readFloat "Введите мнимую часть z2: "
let powN  = readInt   "Введите целую степень для z1: "

let z1 = createComplex real1 imag1
let z2 = createComplex real2 imag2

printfn "\nРезультаты операций над комплексными числами:"
printfn "z1 = %s" (toString z1)
printfn "z2 = %s" (toString z2)
printfn "z1 + z2 = %s" (toString (add z1 z2))
printfn "z1 - z2 = %s" (toString (subtract z1 z2))
printfn "z1 * z2 = %s" (toString (multiply z1 z2))
printfn "z1 / z2 = %s" (toString (divide z1 z2))
printfn "z1^%d = %s" powN (toString (moivre z1 powN))
printfn "Модуль z1 = %.2f" (modulus z1)
printfn "Аргумент z1 = %.2f рад" (argument z1)
printfn "Сопряжённое z1 = %s" (toString (sign z1))
