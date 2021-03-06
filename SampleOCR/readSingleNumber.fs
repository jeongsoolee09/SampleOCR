module ReadSingleNumber

open Tesseract


let readSingleNumber (path: string) : unit =
    let engine = new TesseractEngine ("tessdata-4.1.0", "eng") in
    path
    |> Pix.LoadFromFile
    |> (fun img -> engine.Process (img, PageSegMode.SingleChar))
    |> (fun result -> result.GetText ())
    |> printfn "OCR result: %s"


let readFrom1To9 () =
    List.iter readSingleNumber [ "resources/img/1.png"
                                 ; "resources/img/2.png"
                                 ; "resources/img/3.png"
                                 ; "resources/img/4.png"
                                 ; "resources/img/5.png"
                                 ; "resources/img/6.png"
                                 ; "resources/img/7.png"
                                 ; "resources/img/8.png"
                                 ; "resources/img/9.png" ]
