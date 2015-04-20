using System;
using ObjCRuntime;

[assembly: LinkWith ("libbuffer.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64 | LinkTarget.Simulator64 | LinkTarget.Simulator, SmartLink = true, ForceLoad = true)]
