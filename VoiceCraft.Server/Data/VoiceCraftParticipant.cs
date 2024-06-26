﻿using System.Numerics;
using VoiceCraft.Core;

namespace VoiceCraft.Server.Data
{
    public class VoiceCraftParticipant : Participant
    {
        public short Key { get; set; }
        public bool Binded { get; set; }
        public bool ClientSided { get; set; }
        public bool ServerMuted { get; set; }
        public Channel? Channel { get; set; }

        //Minecraft Data
        public Vector3 Position { get; set; }
        public float Rotation { get; set; }
        public float CaveDensity { get; set; }
        public bool Dead { get; set; }
        public bool InWater { get; set; }
        public string EnvironmentId { get; set; } = string.Empty;
        public string MinecraftId { get; set; } = string.Empty;

        public VoiceCraftParticipant(string name) : base(name)
        {
        }

        public static short GenerateKey()
        {
            return (short)Random.Shared.Next(short.MinValue + 1, short.MaxValue); //short.MinValue is used to specify no Key.
        }
    }
}
