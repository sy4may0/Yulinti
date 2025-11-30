using System.Linq;
using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeAnimationis : IConfiguratioPuellaeAnimationis {
        [SerializeField] private ConfiguratioPuellaeAnimationisFundamenti[] _fundamentum;
        [SerializeField] private ConfiguratioPuellaeAnimationisFundamentiLM[] _fundamentumLM;
        [SerializeField] private ConfiguratioPuellaeAnimationisCorporis[] _corpus;
        [SerializeField] private ConfiguratioPuellaeAnimationisCorporisLM[] _corpusLM;
        [SerializeField] private ConfiguratioPuellaeAnimationisPartis[] _pars;
        [SerializeField] private ConfiguratioPuellaeAnimationisPartisLM[] _parsLM;

        private IConfiguratioPuellaeAnimationisFundamenti[] _cacheFundamentum;
        private IConfiguratioPuellaeAnimationisCorporis[] _cacheCorpus;
        private IConfiguratioPuellaeAnimationisPartis[] _cachePars;

        public IConfiguratioPuellaeAnimationisFundamenti[] Fundamentum => 
            _cacheFundamentum ??= _fundamentum.Cast<IConfiguratioPuellaeAnimationisFundamenti>()
                .Concat(_fundamentumLM.Cast<IConfiguratioPuellaeAnimationisFundamenti>())
                .ToArray();

        public IConfiguratioPuellaeAnimationisCorporis[] Corpus => 
            _cacheCorpus ??= _corpus.Cast<IConfiguratioPuellaeAnimationisCorporis>()
                .Concat(_corpusLM.Cast<IConfiguratioPuellaeAnimationisCorporis>())
                .ToArray();

        public IConfiguratioPuellaeAnimationisPartis[] Pars => 
            _cachePars ??= _pars.Cast<IConfiguratioPuellaeAnimationisPartis>()
                .Concat(_parsLM.Cast<IConfiguratioPuellaeAnimationisPartis>())
                .ToArray();
    }
}
