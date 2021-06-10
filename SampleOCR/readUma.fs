module ReadUma

(* Here, unlike in ReadSingleNumber,
    we would like to read consecutive characters off a single image. *)


let readSingleLineJPN (path: string) : unit =
    let engine = new Tesseract.TesseractEngine ("tessdata-4.1.0", "jpn") in
    path
    |> Tesseract.Pix.LoadFromFile
    |> (fun img -> engine.Process (img, Tesseract.PageSegMode.SingleLine))
    |> (fun result -> result.GetText ())
    |> printfn "OCR result: %s"


let readAllPortionsFromScreenShot () =
    List.iter readSingleLineJPN [ "resources/img/dialogue-1.png" // first dialogue option
                                 ; "resources/img/dialogue-2.png" // second dialogue option
                                 ; "resources/img/up-title-1.png" // Umamusume info title bar 1
                                 ; "resources/img/up-title-2.png" // Umamusume info title bar 2
                                ]
