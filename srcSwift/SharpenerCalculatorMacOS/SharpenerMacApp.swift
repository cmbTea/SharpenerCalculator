import SwiftUI
import SharpenerCore
internal import UniformTypeIdentifiers

@main
struct SharpenerMacApp: App {

    @StateObject private var vm = CalculatorViewModel()

    var body: some Scene {
        WindowGroup {
            NavigationStack {
                CalculatorView(vm: vm)
            }
            .frame(minWidth: 480, minHeight: 620)
            .onDisappear {
                if vm.machinesChanged {
                    vm.saveMachinesToDisk()
                }
            }
        }
        .commands {
            CommandGroup(replacing: .newItem) {}
            CommandMenu("Machines") {
                Button("Restore Default Machine List") {
                    vm.restoreDefaultMachineList()
                }
                Divider()
                Button("Load Machine List…") {
                    openMachineFile()
                }
                Button("Save Machine List…") {
                    saveMachineFile()
                }
            }
        }
    }

    // MARK: - File dialogs (macOS only)

    private func openMachineFile() {
        let panel = NSOpenPanel()
        panel.allowedContentTypes = [.init(filenameExtension: "machinedb")!]
        panel.allowsMultipleSelection = false
        if panel.runModal() == .OK, let url = panel.url {
            vm.loadMachines(from: url)
        }
    }

    private func saveMachineFile() {
        let panel = NSSavePanel()
        panel.allowedContentTypes = [.init(filenameExtension: "machinedb")!]
        panel.nameFieldStringValue = "MachineParameters.machinedb"
        if panel.runModal() == .OK, let url = panel.url {
            vm.saveMachines(to: url)
        }
    }
}
