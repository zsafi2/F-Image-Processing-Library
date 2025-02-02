### **F# Image Processing Library**
#### *A functional approach to image transformations in F#.*

---

## **Table of Contents**
- [Description](#description)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Functions](#functions)
- [Technologies Used](#technologies-used)
- [Future Improvements](#future-improvements)
- [Contributing](#contributing)
- [License](#license)

---

## **Description**
The F# Image Processing Library is a functional programming approach to modifying `.ppm` image files. It provides a console-based interface to apply transformations such as adjusting brightness, modifying intensity, flipping, rotating, and edge detection. The goal of this project is to demonstrate functional programming principles while efficiently manipulating images.

---

## **Features**
- Apply a **sepia filter** to an image.
- Increase or decrease the **intensity** of a specific color channel (Red, Green, or Blue).
- **Flip an image horizontally**.
- **Rotate an image 180 degrees**.
- **Detect edges** in an image using a threshold-based algorithm.

---

## **Installation**
### **Prerequisites**
Ensure you have the following installed on your system:
- **.NET SDK** (for F# development)
- **F# Compiler (fsharpc)**

### **Clone the Repository**
```bash
git clone https://github.com/yourusername/fsharp-image-library.git
cd fsharp-image-library
```

### **Compile the Code**
```bash
fsharpc -o ImageLibrary.exe Library.fs
```

---

## **Usage**
Run the compiled program with:
```bash
dotnet run
```
The console-based interface will prompt for the `.ppm` image filename and apply the requested transformations.

---

## **Functions**
| Function | Description |
|----------|------------|
| `Sepia` | Applies a sepia filter to an image using a weighted transformation of RGB values. |
| `IncreaseIntensity` | Adjusts the intensity of a specific color channel (R, G, or B). |
| `FlipHorizontal` | Reverses an image along the horizontal axis. |
| `Rotate180` | Rotates an image by 180 degrees using horizontal flipping. |
| `EdgeDetect` | Detects edges in an image using a threshold-based algorithm. |

---

## **Technologies Used**
- **F#**: Functional programming language.
- **.NET SDK**: Compilation and execution environment.
- **PPM Image Format**: Simple image format for easy pixel manipulation.

---

## **Future Improvements**
- Implement a **GUI interface** for easier user interaction.
- Add **more image filters**, such as grayscale, blur, and sharpening.
- Optimize performance for handling larger image files.
- Extend support for other image formats (e.g., PNG, JPEG).

---

## **Contributing**
Contributions are welcome! If you’d like to improve this project:
1. Fork the repository.
2. Create a feature branch (`git checkout -b feature-name`).
3. Commit your changes (`git commit -m "Add feature"`).
4. Push to the branch (`git push origin feature-name`).
5. Open a Pull Request.

---

## **License**
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

