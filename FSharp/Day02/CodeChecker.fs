module CodeChecker

let getRanges (code: string) =
    code.Split ','
    |> Array.map (fun range ->
        let parts = range.Split '-'
        int64 parts[0], int64 parts[1])

let isInvalidSplit (code: string) =
    let length = code.Length

    match length % 2 = 0 with
    | true ->
        let mid = length / 2
        let first = code[.. mid - 1]
        let second = code[mid..]
        first = second
    | false -> false

let invalidCodeSplit (code: string) =
    let ranges = getRanges code |> List.ofArray

    let rec loop ranges invalidSum =
        match ranges with
        | [] -> invalidSum
        | (start, finish) :: tail ->
            let mutable currentSum = 0L

            for current in start..finish do
                if isInvalidSplit (string current) then
                    currentSum <- currentSum + current

            loop tail (invalidSum + currentSum)

    loop ranges 0L
