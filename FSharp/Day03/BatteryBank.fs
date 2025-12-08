module BatteryBank

open AdventUtilities
open AdventUtilities.Helpers.ListExt

let topPair (bank: string) length =
    let tens = bank |> Seq.take (length - 1) |> Seq.max
    let firstIndex = bank.IndexOf tens
    let ones = bank |> Seq.skip (firstIndex + 1) |> Seq.max
    int (tens - '0') * 10 + int (ones - '0')

let topSequence (bank: string) length =
    let rec loop index maxIndex acc =
        if acc |> List.length = 12 then
            acc |> List.rev |> String.concat "" |> int64
        else
            let maxNum = bank[index..maxIndex] |> Seq.max
            let startIndex = bank.IndexOf(maxNum, index) + 1
            loop startIndex (maxIndex + 1) (acc |> addItem (string maxNum))

    loop 0 (length - 12) []


let checkJoltage (banks: string array) =
    let bankLength = banks[0].Length

    banks |> Array.map (fun bank -> bankLength |> topPair bank) |> Array.sum

let checkJoltageSequence (banks: string array) =
    let bankLength = banks[0].Length

    banks |> Array.map (fun bank -> bankLength |> topSequence bank) |> Array.sum
