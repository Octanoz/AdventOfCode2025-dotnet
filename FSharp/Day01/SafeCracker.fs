module SafeCracker

let parseLine (line: string) = line[0], int line[1..]

let moveDial current direction distance =
    let remainder = distance % 100

    match direction with
    | 'L' -> (current - remainder + 100) % 100
    | 'R' -> (current + remainder) % 100
    | _ -> failwith $"Invalid direction: {direction}"

let stoppedAtZero current direction distance = if current = 0 then 1 else 0

let zeroesDuringRotation current direction distance =
    let zeroes = distance / 100
    let remainder = distance % 100

    let crossesZero =
        match direction with
        | 'L' -> current <> 0 && remainder >= current
        | 'R' -> remainder >= 100 - current
        | _ -> failwith $"Invalid direction: {direction}"

    if crossesZero then zeroes + 1 else zeroes

let timesZero zeroCounter input =
    input
    |> Seq.fold
        (fun (dial, zeroes) line ->
            let direction, distance = parseLine line
            let newDial = moveDial dial direction distance
            let newZeroes = zeroes + zeroCounter dial direction distance
            newDial, newZeroes)
        (50, 0)
    |> snd
