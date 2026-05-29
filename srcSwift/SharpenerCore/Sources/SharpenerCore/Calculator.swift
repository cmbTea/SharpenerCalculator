import Foundation

/// Pure calculation engine for grinding angle geometry.
/// Ported from C# class `Calculator`.
public class Calculator {

    public init() {}

    // MARK: - Public API (mirrors C# static methods)

    /// Calculates the USB height above the machine housing (mm).
    /// - Parameters:
    ///   - machine:             Machine parameters
    ///   - wheelDiameter:       Grinding wheel diameter (mm), must be > 0
    ///   - jigProjectionLength: Distance from jig to blade tip (mm), must be > 0
    ///   - targetAngle:         Desired grinding angle (degrees), must be > 0
    /// - Returns: Distance from USB top to machine housing (mm)
    public static func usbHeight(
        machine: MachineParameters,
        wheelDiameter: Double,
        jigProjectionLength: Double,
        targetAngle: Double
    ) throws -> Double {
        try validate(wheelDiameter: wheelDiameter, jigProjectionLength: jigProjectionLength, targetAngle: targetAngle)

        let r = wheelDiameter / 2.0
        let k = jigProjectionLength - machine.usbDiameter / 2
        let l = sqrt(k * k + machine.usbDiameter * machine.usbDiameter)
        let alpha = targetAngle - radianToDegree(12 / (jigProjectionLength - machine.usbDiameter / 2))
        let m = pow(r, 2) + pow(l, 2) - 2 * r * l * cos(degreeToRadian(alpha + 90))
        return sqrt(m - machine.usbDx * machine.usbDx) - machine.usbDy + machine.usbDiameter / 2
    }

    /// Calculates the distance from the USB top to the grinding wheel surface (mm).
    /// - Parameters:
    ///   - machine:             Machine parameters
    ///   - wheelDiameter:       Grinding wheel diameter (mm), must be > 0
    ///   - jigProjectionLength: Distance from jig to blade tip (mm), must be > 0
    ///   - targetAngle:         Desired grinding angle (degrees), must be > 0
    /// - Returns: Distance from USB top to wheel surface (mm)
    public static func usb2Wheel(
        machine: MachineParameters,
        wheelDiameter: Double,
        jigProjectionLength: Double,
        targetAngle: Double
    ) throws -> Double {
        try validate(wheelDiameter: wheelDiameter, jigProjectionLength: jigProjectionLength, targetAngle: targetAngle)

        let r = wheelDiameter / 2.0
        let alpha = targetAngle - radianToDegree(machine.usbDiameter / (jigProjectionLength - machine.usbDiameter / 2))
        let k = sqrt(pow(jigProjectionLength - machine.usbDiameter / 2, 2) + pow(machine.usbDiameter, 2))
        let m = sqrt(pow(r, 2) + pow(k, 2) - 2 * r * k * cos(degreeToRadian(alpha + 90)))
        return m - r + machine.usbDiameter / 2
    }

    // MARK: - Private helpers

    private static func validate(wheelDiameter: Double, jigProjectionLength: Double, targetAngle: Double) throws {
        if wheelDiameter <= 0        { throw CalculatorError.invalidInput("Wheel diameter must be greater than 0") }
        if jigProjectionLength <= 0  { throw CalculatorError.invalidInput("Jig projection length must be greater than 0") }
        if targetAngle <= 0          { throw CalculatorError.invalidInput("Target angle must be greater than 0") }
    }

    private static func degreeToRadian(_ degree: Double) -> Double {
        degree * .pi / 180.0
    }

    private static func radianToDegree(_ radian: Double) -> Double {
        radian * 180.0 / .pi
    }
}

// MARK: - Error type

public enum CalculatorError: LocalizedError {
    case invalidInput(String)

    public var errorDescription: String? {
        switch self {
        case .invalidInput(let msg): return msg
        }
    }
}
