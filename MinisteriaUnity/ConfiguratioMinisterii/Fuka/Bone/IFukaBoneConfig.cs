using UnityEngine;

namespace Yulinti.UnityServices.ServiceConfig {
    public interface IFukaBoneConfig {
        Transform RigRoot { get; }

        string RootPath { get; }
        string HipsPath { get; }
        string RightUpperLegPath { get; }
        string RightLowerLegPath { get; }
        string RightFootPath { get; }
        string LeftUpperLegPath { get; }
        string LeftLowerLegPath { get; }
        string LeftFootPath { get; }
        string RightX150pinPath { get; }
        string RightY90pinPath { get; }
        string LeftX150pinPath { get; }
        string LeftY90pinPath { get; }
    }
}