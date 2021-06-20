module ImageBinarization

(* Image binarization with varying thresholds *)

open OpenCvSharp


let binarize (src: IplImage)
             (threshType: ThresholdType)
             (threshold: float) : IplImage =
  let bin = new IplImage (src.Size, BitDepth.U8, 1)
  Cv.CvtColor (src, bin, ColorConversion.RgbToGray)  // convert to grayscale
  Cv.Threshold (bin, bin, threshold, 25., threshType) // apply thresh, overwriting original
  bin


(* Need to call this to avoid resource leakage *)
let freeImg (img: IplImage) : unit =
  if not <| isNull img then Cv.ReleaseImage img


let binarizeTest (src: IplImage): unit =
  let threshTypes = [ ThresholdType.Binary
                    ; ThresholdType.BinaryInv
                    ; ThresholdType.Otsu
                    ; ThresholdType.ToZero
                    ; ThresholdType.ToZeroInv
                    ; ThresholdType.Truncate ]
  let threshVals = [50.; 100.; 150.; 200.]
  let carPro = seq { for threshType in threshTypes do
                       for threshVal in threshVals ->
                         (threshType, threshVal) }
                         |> Seq.toList  // enumeration of all possible combinations
  List.iter (fun (threshType, threshVals) ->
      let binarizeResult = binarize src threshType threshVals in
      ignore <| binarizeResult.SaveImage "hello.jpg") // discard the return code
      carPro