# SharpenerCalculator – Swift / SwiftUI Port

Portierung des C#/.NET-WinForms-Projekts als native Swift-App für **macOS** und **iOS**.  
Die gesamte Geschäftslogik lebt in einem gemeinsamen Swift Package (`SharpenerCore`).

---

## Projektstruktur

```
SharpenerCalculatorSwift/
│
├── SharpenerCore/                  ← Swift Package (shared Model + Views)
│   ├── Package.swift
│   └── Sources/SharpenerCore/
│       ├── MachineParameters.swift ← Klasse MachineParameters (aus C# portiert)
│       ├── Calculator.swift        ← Klasse Calculator (aus C# portiert)
│       ├── CalculatorViewModel.swift ← ObservableObject, verbindet Model und UI
│       └── CalculatorView.swift    ← Gemeinsame SwiftUI-View (macOS + iOS)
│   └── Tests/SharpenerCoreTests/
│       └── CalculatorTests.swift
│
├── SharpenerMac/                   ← Xcode-Target: macOS App
│   └── SharpenerMac/
│       ├── SharpenerMacApp.swift   ← @main, Menüleiste, NSOpenPanel/NSSavePanel
│       └── Info.plist
│
└── SharpenerIOS/                   ← Xcode-Target: iOS App
    └── SharpenerIOS/
        ├── SharpenerIOSApp.swift   ← @main, fileImporter/fileExporter
        └── Info.plist
```

---

## Xcode-Projekt anlegen – Schritt für Schritt

### 1. Gemeinsames Xcode-Workspace erstellen

```
File → New → Workspace…
Name: SharpenerCalculator
Speicherort: SharpenerCalculatorSwift/
```

### 2. Swift Package einbinden

```
File → Add Package Dependencies…
→ "Add Local…"
→ SharpenerCalculatorSwift/SharpenerCore auswählen
```

Das Package erscheint nun im Workspace.

---

### 3. macOS-App-Target erstellen

```
File → New → Project…
Platform: macOS
Template:  App
Product Name:        SharpenerCalculator
Bundle Identifier:   com.cmbtea.SharpenerCalculator.mac
Interface:           SwiftUI
Language:            Swift
Minimum Deployment:  macOS 13.0
```

- Vorhandene `ContentView.swift` löschen  
- Dateien aus `SharpenerMac/SharpenerMac/` in das Target kopieren  
- **SharpenerCore** als Framework-Dependency hinzufügen:  
  `Target → General → Frameworks, Libraries → + → SharpenerCore`

---

### 4. iOS-App-Target erstellen

```
File → New → Target…  (im selben Workspace)
Platform: iOS
Template:  App
Product Name:        SharpenerCalculator
Bundle Identifier:   com.cmbtea.SharpenerCalculator.ios
Interface:           SwiftUI
Language:            Swift
Minimum Deployment:  iOS 16.0
```

- Vorhandene `ContentView.swift` löschen  
- Dateien aus `SharpenerIOS/SharpenerIOS/` in das Target kopieren  
- **SharpenerCore** als Framework-Dependency hinzufügen:  
  `Target → General → Frameworks, Libraries → + → SharpenerCore`

---

### 5. Signing & Capabilities

Für beide Targets unter `Signing & Capabilities`:
- Team auswählen (Apple Developer Account)
- Bundle Identifier anpassen falls nötig

---

## Klassen-Mapping: C# → Swift

| C# Klasse / Member                         | Swift Entsprechung                                      |
|--------------------------------------------|----------------------------------------------------------|
| `MachineParameters` (class)                | `MachineParameters` (class, Codable, ObservableObject)  |
| `MachineParameters.Name/USBdx/USBdy/...`  | `name`, `usbDx`, `usbDy`, `usbDiameter` (@Published)   |
| `BuildDefaultMachineList()`                | `buildDefaultMachineList()` (static)                    |
| `WriteMachineParametersToFile()`           | `writeMachineParameters(_:to:)` (static, throws)        |
| `ReadMachineParametersFromFile()`          | `readMachineParameters(from:)` (static, throws)         |
| `JsonConvert.SerializeObject()`            | `JSONEncoder` (Foundation, kein Newtonsoft nötig)       |
| `Calculator` (class)                       | `Calculator` (class)                                    |
| `Calculator.USBHeight()`                   | `Calculator.usbHeight(machine:wheelDiameter:...)` static|
| `Calculator.USB2Wheel()`                   | `Calculator.usb2Wheel(machine:wheelDiameter:...)` static|
| `fMain` (WinForms)                         | `CalculatorView` (SwiftUI)                              |
| `fNewMachineName` (Dialog)                 | Sheet in `CalculatorView.addMachineSheet`               |
| `Properties.Settings.Default`             | `UserDefaults` (kann in ViewModel ergänzt werden)       |
| `Environment.SpecialFolder.LocalApplicationData` | `FileManager.urls(for: .applicationSupportDirectory)` |

---

## Persistenz-Dateipfad

Die Maschinendatenbank liegt – analog zum C#-Original – im Application Support:

```
~/Library/Application Support/cmbTea/MachineParameters.machinedb
```

Das JSON-Format ist **identisch** zum C#-Original (gleiche Schlüsselnamen: `Name`, `USBdx`, `USBdy`, `USBdiameter`), sodass bestehende `.machinedb`-Dateien direkt übernommen werden können.

---

## Tests ausführen

```
Xcode → Product → Test  (⌘U)
```

Oder per Kommandozeile im `SharpenerCore`-Verzeichnis:

```bash
swift test
```

---

## Abhängigkeiten

| C# Original            | Swift Port              |
|------------------------|-------------------------|
| Newtonsoft.Json 13.x   | Foundation (JSONEncoder/Decoder) – keine externe Abhängigkeit |
| .NET WinForms          | SwiftUI (Apple Framework) |
| .NET 4.x               | Swift 5.9, macOS 13+, iOS 16+ |
