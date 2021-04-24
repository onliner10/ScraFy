open FSharpPlus.Data
open FSharpPlus.Builders
open ScraFy.Types
open ScraFy.HttpHelpers
open ScraFy

[<EntryPoint>]
let main argv =
    let exampleScraper : scraper<string> = 
        monad {
            let! test = httpFetch "wp.pl"
            let! test2 = httpFetch "lol.pl"
        
            return $"result {test}, {test2}"
        }

    Scraper.run exampleScrper

    0 // return an integer exit code