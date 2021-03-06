﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModbusLibrary.Request
{
    public class ReadInputRegisterRequest : RequestBase
    {
        public override byte Command => 0x04;
        public ushort Address { get; set; }
        public ushort Length { get; set; }
        public override void Serialize(HLBinaryWriter stream)
        {
            if (Length > 0x7D)
                throw new ArgumentException();

            stream.Write(this.Address);
            stream.Write(this.Length);
        }
    }
    public class ReadInputRegisterResponse : ResponseBase
    {
        public HLBinaryReader Data { get; private set; }
        public override void Deserialize(RequestBase request, HLBinaryReader stream)
        {
            Data = stream.ReadBytesToBinaryReader(stream.ReadByte());
        }
    }
}
