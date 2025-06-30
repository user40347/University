open System

type Tree<'a> = 
    | Node of value:'a * children: Tree<'a> list

module Tree =
    let rec map f (Node(v, children)) =
        Node(f v, List.map (map f) children)

    let rec readFromConsole () : Tree<string> =
        printf "Введите значение узла: "
        let value = Console.ReadLine()
        printf "Сколько потомков у этого узла? "
        let count =
            match Int32.TryParse(Console.ReadLine()) with
            | true, n when n >= 0 -> n
            | _ ->
                printfn "Ошибка ввода, считается 0 потомков."
                0
        let children =
            [ for _ in 1 .. count do
                yield readFromConsole () ]
        Node(value, children)

    let rec printRotated indent (Node(v, children)) =
        children
        |> List.rev
        |> List.iter (fun child -> printRotated (indent + 4) child)
        printfn "%s%s" (String.replicate indent " ") v

let run () =
    printfn "Построим исходное дерево."
    let tree = Tree.readFromConsole()
    printf "Введите символ, который нужно добавить в конец каждой строки: "
    let symbolLine = Console.ReadLine()
    let appendChar =
        if not (String.IsNullOrEmpty symbolLine) then symbolLine.[0]
        else
            printfn "Пустая строка — берём символ '*'."
            '*'
    let newTree =
        Tree.map (fun s -> s + string appendChar) tree
    printfn "\nИсходное дерево :"
    Tree.printRotated 0 tree
    printfn "\nНовое дерево (после добавления '%c'):" appendChar
    Tree.printRotated 0 newTree

run ()
