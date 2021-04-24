namespace ScraFy

open ScraFy.Types
open FSharpPlus.Data
open System.Threading.Tasks
open System

[<RequireQualifiedAccess>]
module Scraper =
    let rec toAsyncContinuation<'a> (x: scraper<'a>) =
        match Free.run x with 
        | Pure value -> async { return value }
        | Roll (Fetch (url, next)) ->
            async {
                do! Task.Delay(2000) |> Async.AwaitTask

                let randomString = Guid.NewGuid().ToString()
                let! nextResult = randomString |> next |> toAsyncContinuation

                return nextResult
            } 

    let run<'a> (scraper: scraper<'a>) =
        let result = toAsyncContinuation scraper |> Async.RunSynchronously

        printfn $"Result: {result}"
        