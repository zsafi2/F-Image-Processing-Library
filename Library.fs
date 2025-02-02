//
// F# image processing functions.
//
// Description: This program uses a console based user interface to take input the filename of image which has the .ppm type
// and then using this image file it changes the brightness, intensity and rotation of this file in F#
//
// Name: Zaheer Safi 
// School: UIC 
// Date: 03/22/2024
//

namespace ImageLibrary

module Operations =
  
  //
  // Sepia:
  //
  // Applies a sepia filter onto the image and returns the 
  // resulting image as a list of lists. 
  // The sepia filter adjusts the RGB values of each pixel
  // according to the following formulas:
  //    newRed = 0.393*origRed + 0.769*origGreen + 0.189*origBlue
  //    newGreen = 0.349*origRed + 0.686*origGreen + 0.168*origBlue
  //    newBlue = 0.272*origRed + 0.534*origGreen + 0.131*origBlue
  // We will use truncation to cast from the floating point result 
  // to the integer value.
  // 
  // If any of these values exceed 255, then 255 should be used
  // instead for that value.
  //
  // Returns: updated image.

  //
  
  let Sepia (width: int) (height: int) (depth: int) (image: (int*int*int) list list) =
    
    // function to check if the new RGB values are larger the 255 then to ceil it to 255 and return the value as an int
    let select value = 
        if value > 255.0 then 255 else int value

    // function to Change the RGB values to the adjusted values given by the formula in the description and show below and reutrn the value
    let changePixels (origRed, origGreen, origBlue) = 
        let newRed = 0.393 * float origRed + 0.769 * float origGreen + 0.189 * float origBlue
        let newGreen = 0.349 * float origRed + 0.686 * float origGreen + 0.168 * float origBlue
        let newBlue = 0.272 * float origRed + 0.534 * float origGreen + 0.131 * float origBlue
        (select newRed, select newGreen, select newBlue)

    // go through each pixel in the image by iterating over the list of lists and use the changePixel function to 
    // change each pixel and return the new image
    let newImage = List.map (fun row -> List.map changePixels row) image
    newImage

    
  //
  // Increase Intensity
  //
  // Increase the intensity of a particular RGB channel
  // according to the values of the parameters.
  // The intensity is the scaling factor by which the
  // channel selected should be increased (or decreased 
  // if the value is less than 1).
  // The channel is one of 'r', 'g', or 'b' which 
  // correspond to red, green, and blue respectively.
  // If the channel is not one of those three values,
  // do not modify the image.
  // Remember that the maximum value for any pixel 
  // channel is 255, so be careful of overflow!
  //
  // Returns: updated image.
  //
  let rec IncreaseIntensity (width:int) (height:int) (depth:int) (image:(int*int*int) list list) (intensity:double) (channel:char) = 
    
    // this function takes care of the edge case where the RGB pixel value is greater then 255
    let select value = 
        if value > 255.0 then 255 else int value

    // this function looks at the channel character and make changes to the same RGB value by multiplying the intensity
    let changeIntensity (red, green, blue) =
        match channel with
        | 'r' -> (select (int (float red * intensity)), green, blue)
        | 'g' -> (red, select (int (float green * intensity)), blue)
        | 'b' -> (red, green, select (int (float blue * intensity)))
        | _   -> (red, green, blue)

    // go through each pixel in the image by iterating over the list of lists and use the changeIntesity function to 
    // change each pixel and return the new image
    let newImage = List.map (fun row -> List.map changeIntensity row) image
    newImage


  //
  // FlipHorizontal:
  //
  // Flips an image so that what’s on the left is now on 
  // the right, and what’s on the right is now on the left. 
  // That is, the pixel that is on the far left end of the
  // row ends up on the far right of the row, and the pixel
  // on the far right ends up on the far left. This is 
  // repeated as you move inwards toward the row's center.
  //
  // Returns: updated image.
  //
  let rec FlipHorizontal (width:int) (height:int) (depth:int) (image:(int*int*int) list list) = 
    
    // this goes through each row in the list of lists and use the List.rev to reverse the list and stores it in a new image
    let newImage = List.map (fun row -> List.rev row) image
    newImage

  //
  // Rotate180:
  //
  // Rotates the image 180 degrees.
  //
  // Returns: updated image.
  //
  let rec Rotate180 (width:int) (height:int) (depth:int) (image:(int*int*int) list list) = 
    
    // To rotate the image 180 degrees first I use the FlipHorizontal function
    let flippedImage = FlipHorizontal width height depth image
    
    // now reverse the the horizontaly rotated image to make it 180 degrees rotated
    List.rev flippedImage


  //
  // Edge Detection:
  //
  // Edge detection is an algorithm used in computer vision to help
  // distinguish different objects in a picture or to distinguish an
  // object in the foreground of the picture from the background.
  //
  // Edge Detection replaces each pixel in the original image with
  // a black pixel, (0, 0, 0), if the original pixel contains an 
  // "edge" in the original image.  If the original pixel does not
  // contain an edge, the pixel is replaced with a white pixel 
  // (255, 255, 255).
  //
  // An edge occurs when the color of pixel is "significantly different"
  // when compared to the color of two of its neighboring pixels. 
  // We only compare each pixel in the image with the 
  // pixel immediately to the right of it and with the pixel
  // immediately below it. If either pixel has a color difference
  // greater than a given threshold, then it is "significantly
  // different" and an edge occurs. Note that the right-most column
  // of pixels and the bottom-most column of pixels can not perform
  // this calculation so the final image contain one less column
  // and one less row than the original image.
  //
  // To calculate the "color difference" between two pixels, we
  // treat the each pixel as a point on a 3-dimensional grid and
  // we calculate the distance between the two points using the
  // 3-dimensional extension to the Pythagorean Theorem.
  // Distance between (x1, y1, z1) and (x2, y2, z2) is
  //  sqrt ( (x1-x2)^2 + (y1-y2)^2 + (z1-z2)^2 )
  //
  // The threshold amount will need to be given, which is an 
  // integer 0 < threshold < 255.  If the color distance between
  // the original pixel either of the two neighboring pixels 
  // is greater than the threshold amount, an edge occurs and 
  // a black pixel is put in the resulting image at the location
  // of the original pixel. 
  //
  // Returns: updated image.
  //
  let rec EdgeDetect (width:int) (height:int) (depth:int) (image:(int*int*int) list list) (threshold:int) = 
    
    // Function to calculate color distance between two pixels
    let colorDistance (r1, g1, b1) (r2, g2, b2) =
        let dr = float (r1 - r2)
        let dg = float (g1 - g2)
        let db = float (b1 - b2)
        sqrt (dr * dr + dg * dg + db * db)

    // Function to determine if a pixel is an edge by taking the parameter x and y of the pixel and for comparison the currentPixel
    // we use the x, y coordinates to compare the currentPixel with the next right and one below pixel
    let isEdge x y currentPixel =  
        if x < width - 1 && y < height - 1 then
            let rightPixel = List.item (x + 1) (List.item y image)
            let bottomPixel = List.item x (List.item (y + 1) image)
            colorDistance currentPixel rightPixel > float threshold || colorDistance currentPixel bottomPixel > float threshold
        else
            false

    // go through each pixel except the pixels in the edge and determine if it is a edge and replace with either pixel (0,0,0) or (255,255,255)
    let newImage = List.init (height - 1) (fun y ->
        List.init (width - 1) (fun x ->
            let currentPixel = List.item x (List.item y image)
            if isEdge x y currentPixel then 
                (0, 0, 0)
            else 
                (255, 255, 255)
        )
    )
    newImage