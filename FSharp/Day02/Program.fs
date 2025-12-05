open System
open AdventUtilities
open CodeChecker

let example = InputData().ReadAllText 2 "example1"
let input = InputData().ReadAllText 2 "input"

let part1 = invalidCodeSplit input
printfn "Part 1: %i" part1
