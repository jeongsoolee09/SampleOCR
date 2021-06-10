[<EntryPoint>]
let main argv: int =
    printfn "============ Test Drive: OCR'ing from 1 to 9 ============"
    ReadSingleNumber.readFrom1To9 ()
    printfn "============ Now, Read all JPN chars from screenshot ============"
    ReadUma.readAllPortionsFromScreenShot ()
    0
