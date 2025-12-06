open System
open AdventUtilities
open CodeChecker

let example = InputData().ReadAllText 2 "example1"
let input = InputData().ReadAllText 2 "input"

let part1 = invalidCode isInvalidSplit input
let part2 = invalidCode isInvalidChunked input

printfn "Part 1: %i" part1
printfn "Part 2: %i" part2
