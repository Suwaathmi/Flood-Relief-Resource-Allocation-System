# Flood Relief Resource Allocation System

A C#/.NET console application that demonstrates collecting flood-relief victim details, organizing them with different data structures, and prioritizing/ordering results using multiple sorting algorithms.

## Project Overview
This project helps simulate resource allocation for flood relief by:
- collecting victim details (name, priority category, requested items, distance)
- storing victims using a selectable data structure
- sorting victims by distance and by priority using different algorithms
- displaying timing information for sorting runs

## Features
- **Victim intake**: captures victim name, priority (Emergency/Medical/Elderly/Children), food/medicine/clothing needs, and distance from the relief center.
- **Selectable data structure**: choose one of **Queue**, **Linked List**, **Tree**, **Graph**, or **Stack** for storing and displaying victims.
- **Sorting algorithms**: **Bubble Sort**, **Merge Sort**, and **Quick Sort**.
- **Time analysis**: measures elapsed time (ms) for each sorting operation.
- **Interactive CLI**: prompts guide you through data entry and analysis.

## Tech Stack
- **C#**
- **.NET 8** (TargetFramework: `net8.0`)

## Repository Structure
- `Flood Relief Resource Allocation System/Flood Relief Management System.sln` — Visual Studio solution file.
- `Flood Relief Resource Allocation System/Flood Relief Management System/` — main console app source.
  - `Program.cs` — entry point and interactive CLI flow.
  - `*Sort.cs` — sorting implementations (Bubble, Merge, Quick).
  - `Victim*.cs` — victim models and data structure helpers.

## Prerequisites
- Install the **.NET 8 SDK**.
  - Verify: `dotnet --version`

## Build
From the repository root:

```bash
dotnet build "Flood Relief Resource Allocation System/Flood Relief Management System.sln"
```

## Run
You can run the console application directly via the project file:

```bash
dotnet run --project "Flood Relief Resource Allocation System/Flood Relief Management System/Flood Relief Management System.csproj"
```

## Usage (CLI Walkthrough)
1. Enter the number of victims.
2. For each victim, provide:
   - Name
   - Priority category
   - Food items (count + names)
   - Medicine items (count + names)
   - Clothing items (count + names)
   - Distance from the relief center (km)
3. Select a data structure (1–5).
4. Pick a sorting algorithm (1–3).
5. Review:
   - victims sorted by **distance**
   - victims sorted by **priority**
   - time taken for each sorting operation
6. Optionally try a different sorting algorithm.

## Contributing
Contributions are welcome. If you’d like to improve the application (validation, persistence, UI, tests, etc.), feel free to open a pull request.

## License
Add a license file (e.g., MIT) if you plan to distribute this project.