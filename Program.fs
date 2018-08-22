// Learn more about F# at http://fsharp.org

open System
open ResultBuilder

let numResult n = if n > 100 then Ok(n) else Error("Must be greater than 100")
let strResult s =
    match s with
    | "hello" -> Ok("world")
    | "world" -> Ok("hello")
    | _ -> Error("String is not hello or world")

type MatchResult<'a> = {
    Result: 'a;
};

let matcher res: Result<MatchResult<'a>, 'b> =
    match res with
    | Ok(value) -> Ok({ Result = value })
    | Error(msg) -> Error(msg)

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"

    // Can now use the comp expr to chain result calls
    // Makes them a whole lot cleaner
    result {
        let! x = numResult 101
        let! y = strResult "hello"
        let! z = matcher(y |> Ok)
        return (x, y, z)
    } |> printfn "%A\n"

    0 // return an integer exit code
