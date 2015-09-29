﻿using Microsoft.Azure.Devices.Applications.RemoteMonitoring.Simulator.WorkerRole.SimulatorCore.Devices;
using Microsoft.Azure.Devices.Applications.RemoteMonitoring.Simulator.WorkerRole.SimulatorCore.Logging;
using Microsoft.Azure.Devices.Applications.RemoteMonitoring.Simulator.WorkerRole.SimulatorCore.Telemetry.Factory;

namespace Microsoft.Azure.Devices.Applications.RemoteMonitoring.Simulator.WorkerRole.Cooler.Telemetry.Factory
{
    public class CoolerTelemetryFactory : ITelemetryFactory
    {
        private readonly ILogger _logger;


        public CoolerTelemetryFactory(ILogger logger)
        {
            _logger = logger;
        }

        public object PopulateDeviceWithTelemetryEvents(IDevice device)
        {
            var startupTelemetry = new StartupTelemetry(_logger, device);
            device.TelemetryEvents.Add(startupTelemetry);

            var monitorTelemetry = new RemoteMonitorTelemetry(_logger, device.DeviceID);
            device.TelemetryEvents.Add(monitorTelemetry);

            return monitorTelemetry;
        }
    }
}
