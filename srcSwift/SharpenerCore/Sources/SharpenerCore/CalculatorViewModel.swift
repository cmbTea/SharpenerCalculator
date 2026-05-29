import Foundation
import Combine

/// Shared ViewModel used by both the macOS and iOS apps.
/// Holds all state and drives the SwiftUI views.
public class CalculatorViewModel: ObservableObject {

    // MARK: - Machine list

    @Published public var machines: [MachineParameters] = []
    @Published public var selectedMachineIndex: Int = 0

    // MARK: - Input fields (stored as strings for text-field binding)

    @Published public var wheelDiameterText: String = "250.0"
    @Published public var jigProjectionLengthText: String = "80.0"
    @Published public var targetAngleText: String = "20.0"

    // MARK: - Results

    @Published public var usbToHousing: String = "-"
    @Published public var usbToWheel: String = "-"

    // MARK: - Edit state for Custom machine

    @Published public var customName: String = ""
    @Published public var customDx: String = ""
    @Published public var customDy: String = ""
    @Published public var customDiameter: String = ""

    // MARK: - Alerts & flags

    @Published public var alertMessage: String = ""
    @Published public var showAlert: Bool = false
    @Published public var machinesChanged: Bool = false

    private let dbURL = MachineParameters.defaultDatabaseURL()

    // MARK: - Init

    public init() {
        loadMachinesFromDisk()
    }

    // MARK: - Machine selection

    public var selectedMachine: MachineParameters {
        guard machines.indices.contains(selectedMachineIndex) else { return machines[0] }
        return machines[selectedMachineIndex]
    }

    public var isCustomSelected: Bool {
        selectedMachine.name == "Custom"
    }

    // MARK: - Calculation (mirrors C# Calculate())

    public func calculate() {
        guard
            let wheelDiameter      = Double(wheelDiameterText),
            let jigProjectionLength = Double(jigProjectionLengthText),
            let targetAngle        = Double(targetAngleText),
            wheelDiameter > 0,
            jigProjectionLength > 0,
            targetAngle > 0
        else {
            usbToHousing = "-"
            usbToWheel   = "-"
            return
        }

        do {
            let machine = selectedMachine
            let height = try Calculator.usbHeight(
                machine: machine,
                wheelDiameter: wheelDiameter,
                jigProjectionLength: jigProjectionLength,
                targetAngle: targetAngle
            )
            let dist = try Calculator.usb2Wheel(
                machine: machine,
                wheelDiameter: wheelDiameter,
                jigProjectionLength: jigProjectionLength,
                targetAngle: targetAngle
            )
            usbToHousing = String(format: "%.2f mm", height)
            usbToWheel   = String(format: "%.2f mm", dist)
        } catch {
            usbToHousing = "Error"
            usbToWheel   = "Error"
            showAlert(error.localizedDescription)
        }
    }

    // MARK: - Machine management (mirrors C# add/remove/restore logic)

    public func addCustomMachineAs(name: String) {
        guard !name.isEmpty, name.trimmingCharacters(in: .whitespaces) != "Custom" else {
            showAlert("Please provide a valid name. 'Custom' is a reserved name.")
            return
        }
        let newMachine = MachineParameters(
            name: name,
            usbDx: selectedMachine.usbDx,
            usbDy: selectedMachine.usbDy,
            usbDiameter: selectedMachine.usbDiameter
        )
        // Insert before the Custom entry
        if let customIdx = machines.firstIndex(where: { $0.name == "Custom" }) {
            machines.insert(newMachine, at: customIdx)
            selectedMachineIndex = customIdx
        } else {
            machines.append(newMachine)
            selectedMachineIndex = machines.count - 1
        }
        machinesChanged = true
    }

    public func removeSelectedMachine() {
        guard !isCustomSelected else { return }
        machines.remove(at: selectedMachineIndex)
        selectedMachineIndex = max(0, selectedMachineIndex - 1)
        machinesChanged = true
    }

    public func restoreDefaultMachineList() {
        machines = MachineParameters.buildDefaultMachineList()
        machines.append(MachineParameters(name: "Custom", usbDx: 50, usbDy: 29, usbDiameter: 12))
        selectedMachineIndex = 0
        machinesChanged = true
    }

    // MARK: - Persistence

    private func loadMachinesFromDisk() {
        let loaded = (try? MachineParameters.readMachineParameters(from: dbURL)) ?? nil
        machines = loaded ?? MachineParameters.buildDefaultMachineList()
        machines.append(MachineParameters(name: "Custom", usbDx: 50, usbDy: 29, usbDiameter: 12))

        if loaded == nil {
            saveMachinesToDisk()
        }
        selectedMachineIndex = 0
        calculate()
    }

    public func saveMachinesToDisk() {
        let toSave = machines.filter { $0.name != "Custom" }
        do {
            try MachineParameters.writeMachineParameters(toSave, to: dbURL)
        } catch {
            showAlert("Error saving settings: \(error.localizedDescription)")
        }
    }

    public func saveMachines(to url: URL) {
        let toSave = machines.filter { $0.name != "Custom" }
        do {
            try MachineParameters.writeMachineParameters(toSave, to: url)
        } catch {
            showAlert("Error saving machine database: \(error.localizedDescription)")
        }
    }

    public func loadMachines(from url: URL) {
        do {
            guard var loaded = try MachineParameters.readMachineParameters(from: url) else { return }
            loaded.append(MachineParameters(name: "Custom", usbDx: 50, usbDy: 29, usbDiameter: 12))
            machines = loaded
            selectedMachineIndex = 0
        } catch {
            showAlert("Error loading machine database: \(error.localizedDescription)")
        }
    }

    // MARK: - Helpers

    public func showAlert(_ message: String) {
        alertMessage = message
        showAlert = true
    }
}
