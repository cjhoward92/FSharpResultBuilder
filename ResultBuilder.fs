module ResultBuilder 

  let private bind fn res =
    match res with
    | Ok(value) -> fn value
    | Error(msg) -> Error(msg)
  
  let private returnFrom x =
    match x with
    | Ok(value) -> Ok(value)
    | Error(msg) -> Error(msg)
  
  let private _return x = Ok(x)

  let private zero = Ok(())

  type ResultBuilder() =
    member this.Bind(m, f) = bind f m
    member this.Return(x) = _return x
    member this.ReturnFrom(x) = returnFrom x
    member this.Zero() = zero
  
  let result = new ResultBuilder()