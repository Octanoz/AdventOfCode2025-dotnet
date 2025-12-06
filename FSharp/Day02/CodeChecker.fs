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

let isInvalidChunked (code: string) =
    let maxChunk = code.Length / 2

    let rec loop chunkSize =
        match chunkSize with
        | size when size > maxChunk -> false
        | size ->
            let chunk = code[.. size - 1]
            let repetitions = code.Length / size
            let repeatedString = String.init repetitions (fun _ -> chunk)

            if repeatedString = code then true else loop (size + 1)

    loop 1

let invalidCode invalidCheck code =
    getRanges code
    |> Array.sumBy (fun (start, finish) ->
        [ start..finish ]
        |> Seq.sumBy (fun current -> if invalidCheck (string current) then current else 0L))
