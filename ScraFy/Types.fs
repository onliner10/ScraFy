namespace ScraFy
open FSharpPlus.Data

module Types =
    type Url = string
    type ScrapedPayload = string

    type ScraperInstruction<'next> =
        | Fetch of (Url * (ScrapedPayload -> 'next))
        with
            static member map f (x : ScraperInstruction<'next>) =
                match x with
                | Fetch (url, continuation) -> Fetch (url, continuation >> f)
                
            static member Map (x: ScraperInstruction<_>, f) =
                ScraperInstruction.map f x
                
    type scraper<'a> = Free<ScraperInstruction<'a>, 'a>