open System

type Tree<'T> =
    | Empty
    | Node of value:'T * left:Tree<'T> * right:Tree<'T>

module Tree =
    let rec insert tree value =
        match tree with
        | Empty -> Node(value, Empty, Empty)
        | Node(v, left, right) ->
            if value <= v then
                Node(v, insert left value, right)
            else
                Node(v, left, insert right value)

    let rec printIndented indent tree =
        match tree with
        | Empty -> ()
        | Node(v, left, right) ->
            printIndented (indent + 4) right
            printfn "%s%O" (String.replicate indent " ") v
            printIndented (indent + 4) left

let rec readIntegers () =
    printf "Введите целое число (или 'q' для завершения): "
    match Console.ReadLine() with
    | null | "" -> readIntegers()
    | "q"     -> []
    | s ->
        match Int32.TryParse s with
        | true, n -> n :: readIntegers()
        | _       ->
            printfn "Неверный ввод, попробуйте снова."
            readIntegers()

let run () =
    printfn "Программа: отрисовка исходного дерева и дерева только с чётными элементами."

    let values = readIntegers()
    if List.isEmpty values then
        printfn "Не введено ни одного числа, выход."
    else
        let originalTree = List.fold Tree.insert Empty values
        let evensTree =
            values
            |> List.fold (fun acc v ->
                if v % 2 = 0 then Tree.insert acc v
                else acc
            ) Empty

        printfn "\nИсходное дерево:"
        Tree.printIndented 0 originalTree

        printfn "\nНовое дерево (только чётные элементы):"
        Tree.printIndented 0 evensTree

run ()
