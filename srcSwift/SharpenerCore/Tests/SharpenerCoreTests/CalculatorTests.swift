import XCTest
@testable import SharpenerCore

final class CalculatorTests: XCTestCase {

    let tormekT8Top = MachineParameters(name: "Toremek T8 USB used on top",
                                        usbDx: 50, usbDy: 29, usbDiameter: 12)

    func testUSBHeight_validInput() throws {
        let result = try Calculator.usbHeight(
            machine: tormekT8Top,
            wheelDiameter: 250,
            jigProjectionLength: 80,
            targetAngle: 20
        )
        XCTAssertGreaterThan(result, 0, "USB height should be positive")
    }

    func testUSB2Wheel_validInput() throws {
        let result = try Calculator.usb2Wheel(
            machine: tormekT8Top,
            wheelDiameter: 250,
            jigProjectionLength: 80,
            targetAngle: 20
        )
        XCTAssertGreaterThan(result, 0, "USB to wheel distance should be positive")
    }

    func testInvalidWheelDiameter() {
        XCTAssertThrowsError(try Calculator.usbHeight(
            machine: tormekT8Top,
            wheelDiameter: 0,
            jigProjectionLength: 80,
            targetAngle: 20
        ))
    }

    func testInvalidAngle() {
        XCTAssertThrowsError(try Calculator.usb2Wheel(
            machine: tormekT8Top,
            wheelDiameter: 250,
            jigProjectionLength: 80,
            targetAngle: -5
        ))
    }

    func testMachineParametersPersistence() throws {
        let machines = MachineParameters.buildDefaultMachineList()
        let url = FileManager.default.temporaryDirectory.appendingPathComponent("test.machinedb")
        try MachineParameters.writeMachineParameters(machines, to: url)
        let loaded = try MachineParameters.readMachineParameters(from: url)
        XCTAssertEqual(loaded?.count, machines.count)
        XCTAssertEqual(loaded?.first?.name, machines.first?.name)
    }
}
