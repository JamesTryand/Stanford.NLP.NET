﻿[<AutoOpen>]
module Stanford.NLP.Parser.Config

let [<Literal>] jarRoot = __SOURCE_DIRECTORY__ + @"..\..\..\src\temp\stanford-parser-full-2013-11-12\stanford-parser-3.3.0-models\"
let [<Literal>] modelsDirectry = jarRoot + @"edu\stanford\nlp\models\"
type Models = FSharp.Management.FileSystem<path=modelsDirectry>

let [<Literal>] dataFilesRoot  = __SOURCE_DIRECTORY__ + @"..\..\data"
type DataFiles = FSharp.Management.FileSystem<dataFilesRoot>

open java.lang
open java.util

let toSeq (iter:Iterable) =
    let rec loop (x:Iterator) = 
        seq { 
            if x.hasNext() then 
                yield x.next()  
                yield! (loop x)
            }
    iter.iterator() |> loop |> Array.ofSeq |> Seq.readonly