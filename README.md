# WhyIUseAwait
A simple demo of how to use await with Winforms and the .NET Framework 4.8.

# How to install
* Clone/Download this repository.
* Load the solution in Visual Studio 2019.
* Run "Restore Nuget Packages" (right-click on the main solution).
The project should be ready to run now.

# How to use
This application demo offers two buttons.
The first button runs the "calculation" using a standard method.
The second button calls the exact same method, but wrapped in a Task.Run().

Run the application, press either button, and try to drag the window.
See the different results?

The left button blocks the UI when running the calculation.
The right button does not block the UI (by running the calculation in a Task).

Examine the code, and you'll see how it works.
