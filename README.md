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


## 📁 Project Structure

- `Assets/Scripts/`: LSL logic, UI controllers.
- `Assets/Scenes/`: Test/demo scenes.
- `Assets/Prefabs/`: Reusable UI and 3D assets.
- `Assets/Samples/`: LSL4Unity sample integration.


## 📜 Code Snippet Explanation: LSL Buffer Allocation

Below is an excerpt from the coroutine responsible for resolving the LSL stream and preparing memory buffers to receive data:

```csharp
IEnumerator ResolveExpectedStream()
{
    var results = resolver.results();
    while (results.Length == 0)
    {
        yield return new WaitForSeconds(.1f);
        results = resolver.results();
    }

    inlet = new StreamInlet(results[0]);

    // Prepare pull_chunk buffer
    int buf_samples = (int)Mathf.Ceil((float)(inlet.info().nominal_srate() * max_chunk_duration));
    Debug.Log("Allocating buffers to receive " + buf_samples + " samples.");
    int n_channels = inlet.info().channel_count();
    data_buffer = new float[buf_samples, n_channels];
    timestamp_buffer = new double[buf_samples];
}

### 🧠 What This Code Does

This snippet calculates the appropriate size for memory buffers that will be used to receive incoming LSL data. It first queries the stream for its declared sampling rate (`nominal_srate()`), which tells us how many samples per second the device is expected to send — for example, 250 Hz.

A configurable variable, `max_chunk_duration`, defines the maximum duration (in seconds) that a chunk of data may cover — typically something like 0.1 seconds (100 milliseconds). By multiplying the sampling rate by this duration, we estimate the maximum number of samples we may receive at once. We use `Mathf.Ceil` to round this number up, ensuring the buffer is always large enough.

Two buffers are then allocated:

- `data_buffer`: a two-dimensional float array sized `[samples, channels]`, used to store the actual signal values coming from the LSL stream.
- `timestamp_buffer`: a one-dimensional array used to store the time associated with each received sample.

These buffers are essential for retrieving data efficiently using `inlet.pull_chunk()`, which allows multiple samples to be received at once — improving performance compared to pulling one sample at a time. This structure ensures the system remains responsive and reliable, especially in real-time BCI applications such as VR or neurofeedback training.


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

