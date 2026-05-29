import SwiftUI
import SharpenerCore

@main
struct SharpenerIOSApp: App {

    @StateObject private var vm = CalculatorViewModel()

    var body: some Scene {
        WindowGroup {
            NavigationStack {
                CalculatorView(vm: vm)
                    .toolbar {
                        ToolbarItem(placement: .topBarTrailing) {
                            Menu {
                                Button("Restore Defaults") {
                                    vm.restoreDefaultMachineList()
                                }
                                // File import/export via ShareSheet on iOS
                                Button("Export Machine List") {
                                    exportMachines()
                                }
                            } label: {
                                Image(systemName: "ellipsis.circle")
                            }
                        }
                    }
            }
            .onDisappear {
                if vm.machinesChanged {
                    vm.saveMachinesToDisk()
                }
            }
            .fileImporter(
                isPresented: $showImporter,
                allowedContentTypes: [.init(filenameExtension: "machinedb")!]
            ) { result in
                if case .success(let url) = result {
                    _ = url.startAccessingSecurityScopedResource()
                    vm.loadMachines(from: url)
                    url.stopAccessingSecurityScopedResource()
                }
            }
            .fileExporter(
                isPresented: $showExporter,
                document: MachineDBDocument(vm: vm),
                contentType: .init(filenameExtension: "machinedb")!,
                defaultFilename: "MachineParameters"
            ) { _ in }
        }
    }

    // MARK: - File handling

    @State private var showImporter = false
    @State private var showExporter = false

    private func exportMachines() {
        showExporter = true
    }
}

// MARK: - FileDocument wrapper for export

import UniformTypeIdentifiers

struct MachineDBDocument: FileDocument {
    static var readableContentTypes: [UTType] { [.init(filenameExtension: "machinedb")!] }

    var vm: CalculatorViewModel

    init(vm: CalculatorViewModel) {
        self.vm = vm
    }

    init(configuration: ReadConfiguration) throws {
        vm = CalculatorViewModel()
    }

    func fileWrapper(configuration: WriteConfiguration) throws -> FileWrapper {
        let toSave = vm.machines.filter { $0.name != "Custom" }
        let encoder = JSONEncoder()
        encoder.outputFormatting = .prettyPrinted
        let data = try encoder.encode(toSave)
        return FileWrapper(regularFileWithContents: data)
    }
}
