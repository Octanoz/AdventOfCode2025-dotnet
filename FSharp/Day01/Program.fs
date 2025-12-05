open AdventUtilities
open SafeCracker

let example = InputData().ReadAllLines 1 "example1" |> List.ofArray
let input = InputData().ReadAllLines 1 "input" |> List.ofArray

let part1 = timesZero stoppedAtZero input
let part2 = timesZero zeroesDuringRotation input

printfn "Part 1: %i" part1
printfn "Part 2: %i" part2
