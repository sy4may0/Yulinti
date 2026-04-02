using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Contractus {
    public interface IConfiguratioPuellaeFormaeFigurae {
        IDPuellaeFormae Forma { get; }
        IDRedittorPuellaeFigurae[] Scopus { get; }
        string NomenFigurae { get; }
    }
}