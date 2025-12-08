open AdventUtilities
open BatteryBank

let example = InputData().ReadAllLines 3 "example1"
let input = InputData().ReadAllLines 3 "input"

let part1 = checkJoltage input
let part2 = checkJoltageSequence input

printfn "Part 1: %i" part1
printfn "Part 2: %d" part2
