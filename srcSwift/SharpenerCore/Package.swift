// swift-tools-version: 5.9
import PackageDescription

let package = Package(
    name: "SharpenerCore",
    platforms: [
        .macOS(.v13),
        .iOS(.v16),
    ],
    products: [
        .library(
            name: "SharpenerCore",
            targets: ["SharpenerCore"]
        ),
    ],
    targets: [
        .target(
            name: "SharpenerCore",
            path: "Sources/SharpenerCore"
        ),
        .testTarget(
            name: "SharpenerCoreTests",
            dependencies: ["SharpenerCore"],
            path: "Tests/SharpenerCoreTests"
        ),
    ]
)
