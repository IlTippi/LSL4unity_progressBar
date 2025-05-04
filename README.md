# 🧠 VR BCI Progress Bar Demo

This Unity project demonstrates a simple user interface element (a progress bar) controlled via brain-computer interface (BCI) data streamed through [LabStreamingLayer (LSL)](https://github.com/sccn/labstreaminglayer), using the [LSL4Unity](https://github.com/labstreaminglayer/LSL4Unity) plugin.

It is intended to serve as a base or reference for more complex BCI-driven VR applications such as puzzles, fantasy games, or research experiments.

## 🎮 Features

- Unity progress bar updated in real-time using EEG/fNIRS or synthetic LSL data.
- Integration with LSL via LSL4Unity.
- Modular code architecture for easy extension.
- Designed for VR compatibility (world-space canvas).

## 🛠 Requirements

- Unity 2021.3+ (LTS recommended)
- LSL4Unity package imported
- Visual Studio with C# support (for autocompletion)
- LSL runtime installed
- Optional: EEG/fNIRS hardware like Unicorn Hybrid Black

## 🚀 Getting Started

1. Clone or download this repository.
2. Open it with Unity Hub.
3. Make sure LSL4Unity is properly imported (via Unity Package Manager or manually).
4. Plug in your device or run an LSL test stream.
5. Attach the `SimpleInletScaleObject.cs` (or your modified script) to a 3D object.
6. Play the scene and observe the scale/progress reacting to the stream.

## 📁 Project Structure

- `Assets/Scripts/`: LSL logic, UI controllers.
- `Assets/Scenes/`: Test/demo scenes.
- `Assets/Prefabs/`: Reusable UI and 3D assets.
- `Assets/Samples/`: LSL4Unity sample integration.

## 🤝 Contributing

We encourage collaboration! Please:

- Fork the project
- Work on your own feature branch
- Push and submit a Pull Request
- Follow GitHub Flow best practices

## 📌 To Do

This project is still in its early stages and there is a lot of work ahead. Below are some of the main improvements and next steps planned:

- 🔄 **Refactor and clean up the codebase** to improve readability and modularity.
- 🧪 **Add more error handling and fallback logic** for edge cases.
- ⚙️ **Optimize the performance**, especially in VR mode.
- 🎮 **Expand the gameplay mechanics**, including more binary choices and interaction feedback.
- 🎨 **Improve the UI/UX**, making it more intuitive and immersive in 3D/VR environments.
- 🔌 **Enhance data stream integration**, ensuring smoother LSL communication and support for additional signals.
- 🧠 **Implement more BCI features**, such as blink detection, attention metrics, or mental commands.

Contributions and suggestions are welcome — feel free to open issues or submit pull requests!

