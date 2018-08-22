// Learn more about F# at http://fsharp.org

open System
open ResultBuilder

let numResult n = if n > 100 then Ok(n) else Error("Must be greater than 100")
let strResult s =
    match s with
    | "hello" -> Ok("world")
    | "world" -> Ok("hello")
    | _ -> Error("String is not hello or world")

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"

    result {
        let! x = numResult 101
        let! y = strResult "hello"
        return (x, y)
    } |> printfn "%A\n"

    0 // return an integer exit code
