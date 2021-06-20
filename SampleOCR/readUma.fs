module ReadUma

open System.Text

(* Here, unlike in ReadSingleNumber,
    we would like to read consecutive characters off a single image. *)


let toUTF8 (source: string) : string =
    let utf8 = UTF8Encoding () in
    let byteArray = utf8.GetBytes source in
    utf8.GetString byteArray


let readSingleLineJPN (path: string) : unit =
    let engine = new Tesseract.TesseractEngine ("tessdata-4.1.0", "jpn") in
    path
    |> Tesseract.Pix.LoadFromFile
    |> (fun img -> engine.Process (img, Tesseract.PageSegMode.SingleLine))
    |> (fun result -> result.GetText ())
    |> toUTF8
    |> printfn "OCR result: %s"


let readAllPortionsFromScreenShot () =
    List.iter readSingleLineJPN [ "resources/img/dialogue-1.png" // first dialogue option
                                 ; "resources/img/dialogue-2.png" // second dialogue option
                                 ; "resources/img/up-title-1.png" // Umamusume info title bar 1
                                 ; "resources/img/up-title-2.png" // Umamusume info title bar 2
                                ]

