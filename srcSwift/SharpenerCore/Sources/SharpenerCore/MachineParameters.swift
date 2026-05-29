import Foundation

/// Represents the physical parameters of a sharpening machine.
/// Ported from C# class `MachineParameters`.
public class MachineParameters: Identifiable, Codable, ObservableObject {

    public var id = UUID()

    /// Display name of the machine configuration
    @Published public var name: String

    /// Horizontal distance from the USB top to the wheel axis (mm)
    @Published public var usbDx: Double

    /// Vertical distance from the USB top to the wheel axis (mm)
    @Published public var usbDy: Double

    /// Diameter of the Universal Support Bar (mm)
    @Published public var usbDiameter: Double

    public init(name: String, usbDx: Double, usbDy: Double, usbDiameter: Double) {
        self.name = name
        self.usbDx = usbDx
        self.usbDy = usbDy
        self.usbDiameter = usbDiameter
    }

    // MARK: - Codable

    enum CodingKeys: String, CodingKey {
        case name = "Name"
        case usbDx = "USBdx"
        case usbDy = "USBdy"
        case usbDiameter = "USBdiameter"
    }

    public required init(from decoder: Decoder) throws {
        let container = try decoder.container(keyedBy: CodingKeys.self)
        name       = try container.decode(String.self, forKey: .name)
        usbDx      = try container.decode(Double.self, forKey: .usbDx)
        usbDy      = try container.decode(Double.self, forKey: .usbDy)
        usbDiameter = try container.decode(Double.self, forKey: .usbDiameter)
    }

    public func encode(to encoder: Encoder) throws {
        var container = encoder.container(keyedBy: CodingKeys.self)
        try container.encode(name,        forKey: .name)
        try container.encode(usbDx,       forKey: .usbDx)
        try container.encode(usbDy,       forKey: .usbDy)
        try container.encode(usbDiameter, forKey: .usbDiameter)
    }

    // MARK: - Default machine list (mirrors C# BuildDefaultMachineList)

    public static func buildDefaultMachineList() -> [MachineParameters] {
        [
            MachineParameters(name: "Toremek T8 USB used on top",      usbDx: 50,  usbDy: 29, usbDiameter: 12),
            MachineParameters(name: "Toremek T8 USB used on the side", usbDx: 145, usbDy: 49, usbDiameter: 12),
            MachineParameters(name: "Toremek T4 USB used on top",      usbDx: 50,  usbDy: 20, usbDiameter: 12),
            MachineParameters(name: "Toremek T4 USB used on the side", usbDx: 120, usbDy: 40, usbDiameter: 12),
        ]
    }

    // MARK: - Persistence (mirrors C# WriteMachineParametersToFile / ReadMachineParametersFromFile)

    public static func writeMachineParameters(_ machines: [MachineParameters], to url: URL) throws {
        guard !machines.isEmpty else { return }
        let encoder = JSONEncoder()
        encoder.outputFormatting = .prettyPrinted
        let data = try encoder.encode(machines)
        try data.write(to: url)
    }

    public static func readMachineParameters(from url: URL) throws -> [MachineParameters]? {
        guard FileManager.default.fileExists(atPath: url.path) else { return nil }
        let data = try Data(contentsOf: url)
        let decoder = JSONDecoder()
        return try decoder.decode([MachineParameters].self, from: data)
    }

    /// Returns the URL for the default machine database file (mirrors C# LocalApplicationData path).
    public static func defaultDatabaseURL() -> URL {
        let appSupport = FileManager.default.urls(for: .applicationSupportDirectory, in: .userDomainMask).first!
        let dir = appSupport.appendingPathComponent("cmbTea", isDirectory: true)
        try? FileManager.default.createDirectory(at: dir, withIntermediateDirectories: true)
        return dir.appendingPathComponent("MachineParameters.machinedb")
    }
}
