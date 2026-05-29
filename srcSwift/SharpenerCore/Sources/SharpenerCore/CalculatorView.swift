import SwiftUI
import SharpenerCore

/// Main calculator view – shared between macOS and iOS.
/// Layout adapts automatically via `#if os(macOS)` and size classes.
public struct CalculatorView: View {

    @ObservedObject var vm: CalculatorViewModel
    @State private var showAddMachineSheet = false
    @State private var newMachineName = ""

    public init(vm: CalculatorViewModel) {
        self.vm = vm
    }

    public var body: some View {
        ScrollView {
            VStack(spacing: 20) {
                machineSection
                inputSection
                resultSection
                machineParametersSection
            }
            .padding()
        }
        .navigationTitle("Sharpener Calculator")
        .alert("Error", isPresented: $vm.showAlert) {
            Button("OK", role: .cancel) {}
        } message: {
            Text(vm.alertMessage)
        }
        .sheet(isPresented: $showAddMachineSheet) {
            addMachineSheet
        }
    }

    // MARK: - Machine picker

    private var machineSection: some View {
        GroupBox(label: Label("Machine", systemImage: "gearshape")) {
            VStack(spacing: 10) {
                Picker("Machine", selection: $vm.selectedMachineIndex) {
                    ForEach(vm.machines.indices, id: \.self) { i in
                        Text(vm.machines[i].name).tag(i)
                    }
                }
                .pickerStyle(.menu)
                .onChange(of: vm.selectedMachineIndex) { _ in vm.calculate() }

                HStack {
                    // Add button – only for Custom
                    Button {
                        newMachineName = ""
                        showAddMachineSheet = true
                    } label: {
                        Label("Save as new machine", systemImage: "plus")
                    }
                    .disabled(!vm.isCustomSelected)

                    Spacer()

                    // Remove button – disabled for Custom
                    Button(role: .destructive) {
                        vm.removeSelectedMachine()
                    } label: {
                        Label("Remove", systemImage: "minus")
                    }
                    .disabled(vm.isCustomSelected)
                }
            }
            .padding(.vertical, 4)
        }
    }

    // MARK: - Numeric inputs

    private var inputSection: some View {
        GroupBox(label: Label("Input Parameters", systemImage: "slider.horizontal.3")) {
            VStack(spacing: 12) {
                NumericField(label: "Wheel Diameter (mm)",       text: $vm.wheelDiameterText,       onCommit: vm.calculate)
                NumericField(label: "Jig Projection Length (mm)", text: $vm.jigProjectionLengthText, onCommit: vm.calculate)
                NumericField(label: "Target Angle (°)",           text: $vm.targetAngleText,          onCommit: vm.calculate)

                Button(action: vm.calculate) {
                    Label("Calculate", systemImage: "function")
                        .frame(maxWidth: .infinity)
                }
                .buttonStyle(.borderedProminent)
            }
            .padding(.vertical, 4)
        }
    }

    // MARK: - Results

    private var resultSection: some View {
        GroupBox(label: Label("Results", systemImage: "ruler")) {
            VStack(spacing: 14) {
                ResultRow(label: "USB to Housing:", value: vm.usbToHousing)
                ResultRow(label: "USB to Wheel:",   value: vm.usbToWheel)
            }
            .padding(.vertical, 4)
        }
    }

    // MARK: - Machine parameters (editable only for Custom)

    private var machineParametersSection: some View {
        GroupBox(label: Label("Machine Parameters", systemImage: "info.circle")) {
            VStack(spacing: 10) {
                LabeledReadOnlyField(label: "Name",         value: vm.selectedMachine.name)
                LabeledReadOnlyField(label: "USB Diameter", value: String(format: "%.1f mm", vm.selectedMachine.usbDiameter))
                LabeledReadOnlyField(label: "USB dx",       value: String(format: "%.1f mm", vm.selectedMachine.usbDx))
                LabeledReadOnlyField(label: "USB dy",       value: String(format: "%.1f mm", vm.selectedMachine.usbDy))

                if vm.isCustomSelected {
                    Divider()
                    Text("Edit Custom Machine")
                        .font(.caption)
                        .foregroundStyle(.secondary)
                    NumericField(label: "USB Diameter", text: Binding(
                        get: { String(format: "%.1f", vm.selectedMachine.usbDiameter) },
                        set: { if let v = Double($0) { vm.selectedMachine.usbDiameter = v; vm.calculate() } }
                    ))
                    NumericField(label: "USB dx", text: Binding(
                        get: { String(format: "%.1f", vm.selectedMachine.usbDx) },
                        set: { if let v = Double($0) { vm.selectedMachine.usbDx = v; vm.calculate() } }
                    ))
                    NumericField(label: "USB dy", text: Binding(
                        get: { String(format: "%.1f", vm.selectedMachine.usbDy) },
                        set: { if let v = Double($0) { vm.selectedMachine.usbDy = v; vm.calculate() } }
                    ))
                }
            }
            .padding(.vertical, 4)
        }
    }

    // MARK: - Add machine sheet (mirrors C# fNewMachineName dialog)

    private var addMachineSheet: some View {
        NavigationStack {
            Form {
                Section("New Machine Name") {
                    TextField("Machine name", text: $newMachineName)
                }
            }
            .navigationTitle("Save Machine")
            #if os(iOS)
            .navigationBarTitleDisplayMode(.inline)
            #endif
            .toolbar {
                ToolbarItem(placement: .confirmationAction) {
                    Button("Save") {
                        vm.addCustomMachineAs(name: newMachineName)
                        showAddMachineSheet = false
                    }
                }
                ToolbarItem(placement: .cancellationAction) {
                    Button("Cancel") { showAddMachineSheet = false }
                }
            }
        }
        .presentationDetents([.medium])
    }
}

// MARK: - Helper sub-views

private struct NumericField: View {
    let label: String
    @Binding var text: String
    var onCommit: (() -> Void)? = nil

    var body: some View {
        HStack {
            Text(label)
                .frame(maxWidth: .infinity, alignment: .leading)
                .foregroundStyle(.secondary)
            TextField("0.0", text: $text)
                .multilineTextAlignment(.trailing)
                .frame(width: 100)
            #if os(iOS)
                .keyboardType(.decimalPad)
            #endif
                .onSubmit { onCommit?() }
        }
    }
}

private struct ResultRow: View {
    let label: String
    let value: String

    var body: some View {
        HStack {
            Text(label)
                .foregroundStyle(.secondary)
            Spacer()
            Text(value)
                .font(.title2.monospacedDigit().bold())
                .foregroundStyle(value == "-" ? .secondary : .primary)
        }
    }
}

private struct LabeledReadOnlyField: View {
    let label: String
    let value: String

    var body: some View {
        HStack {
            Text(label)
                .foregroundStyle(.secondary)
                .frame(maxWidth: .infinity, alignment: .leading)
            Text(value)
                .multilineTextAlignment(.trailing)
        }
    }
}
