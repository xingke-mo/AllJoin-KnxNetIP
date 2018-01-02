﻿using System;
using System.Collections.Generic;
using BridgeRT;
using SparkAlljoyn;
using System.Threading.Tasks;
using RoombaAdapter.Roomba;

namespace RoombaAdapter
{
    //
    // AdapterDevice.
    // Description:
    // The class that implements IAdapterDevice from BridgeRT.
    //
    class RoombaDevice : BridgeAdapterDevice<RoombaAdapter>
    {
        private RoombaConnection _conn;

        internal RoombaDevice(RoombaAdapter adapter, RoombaConnection conn, string Name, string VendorName, string Model, string Version, string SerialNumber, string Description)
            : base(adapter, Name, VendorName, Model, Version, SerialNumber, Description)
        {
            _conn = conn;
        }

        override protected void CreateProperties()
        {
            this.Properties.Clear();

            var statusProp = new BridgeAdapterProperty<RoombaDevice>(this, "IrTrans", "com.allseen.SmartHome.IrTrans");
            statusProp.Attributes.Add(new BridgeAdapterAttribute("EnergyTotal", 0.0, E_ACCESS_TYPE.ACCESS_READ) { COVBehavior = SignalBehavior.Always });
            statusProp.Attributes.Add(new BridgeAdapterAttribute("EnergyHi", 0.0, E_ACCESS_TYPE.ACCESS_READ) { COVBehavior = SignalBehavior.Always });
            statusProp.Attributes.Add(new BridgeAdapterAttribute("EnergyLo", 0.0, E_ACCESS_TYPE.ACCESS_READ) { COVBehavior = SignalBehavior.Always });

            this.Properties.Add(statusProp);
            this.AddChangeOfValueSignal(statusProp);
        }

        virtual internal async Task<bool> AquireCurrentState()
        {
            return true;
        }

        virtual public void CallMethod(IAdapterMethod methodn)
        {

        }

        virtual public void SendPropertyValue(IAdapterProperty Property, IAdapterValue Value)
        {

        }
    }
}
