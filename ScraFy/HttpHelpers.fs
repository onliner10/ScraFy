namespace ScraFy

open ScraFy.Types
open FSharpPlus.Data

module HttpHelpers =
    let httpFetch url: scraper<ScrapedPayload> =
        Fetch (url, id) |> Free.liftF