using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    public interface IConfiguratioPuellaeOssis {
        NihilAut<Transform> RigRoot { get; }

        string RootPath { get; }
        string HipsPath { get; }
        string RightUpperLegPath { get; }
        string RightLowerLegPath { get; }
        string RightFootPath { get; }
        string RightToePath { get; }
        string LeftUpperLegPath { get; }
        string LeftLowerLegPath { get; }
        string LeftFootPath { get; }
        string LeftToePath { get; }
        string RightX150pinPath { get; }
        string RightY90pinPath { get; }
        string LeftX150pinPath { get; }
        string LeftY90pinPath { get; }
    }
}
