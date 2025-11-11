namespace Yulinti.UnityServices.ServiceContracts {
    public struct FukaAnimationRequests {
        private FukaBaseLayerAnimationID _baseLayerRequest;
        private FukaActionLayerAnimationID _actionLayerRequest;
        private FukaEmoteLayerAnimationID _emoteLayerRequest;
        private FukaAdditivePoseLayerAnimationID _additivePoseLayerRequest;
        private FukaExtraLayerAnimationID _extraLayerRequest;

        public FukaAnimationRequests(
            FukaBaseLayerAnimationID baseLayerRequest = FukaBaseLayerAnimationID.None,
            FukaActionLayerAnimationID actionLayerRequest = FukaActionLayerAnimationID.None,
            FukaEmoteLayerAnimationID emoteLayerRequest = FukaEmoteLayerAnimationID.None,
            FukaAdditivePoseLayerAnimationID additivePoseLayerRequest = FukaAdditivePoseLayerAnimationID.None,
            FukaExtraLayerAnimationID extraLayerRequest = FukaExtraLayerAnimationID.None
        ) {
            _baseLayerRequest = baseLayerRequest;
            _actionLayerRequest = actionLayerRequest;
            _emoteLayerRequest = emoteLayerRequest;
            _additivePoseLayerRequest = additivePoseLayerRequest;
            _extraLayerRequest = extraLayerRequest;
        }

        public void SetBaseLayerRequest(FukaBaseLayerAnimationID baseLayerRequest) {
            _baseLayerRequest = baseLayerRequest;
        }
        public void SetActionLayerRequest(FukaActionLayerAnimationID actionLayerRequest) {
            _actionLayerRequest = actionLayerRequest;
        }
        public void SetEmoteLayerRequest(FukaEmoteLayerAnimationID emoteLayerRequest) {
            _emoteLayerRequest = emoteLayerRequest;
        }
        public void SetAdditivePoseLayerRequest(FukaAdditivePoseLayerAnimationID additivePoseLayerRequest) {
            _additivePoseLayerRequest = additivePoseLayerRequest;
        }
        public void SetExtraLayerRequest(FukaExtraLayerAnimationID extraLayerRequest) {
            _extraLayerRequest = extraLayerRequest;
        }

        public FukaBaseLayerAnimationID BaseLayerRequest => _baseLayerRequest;
        public FukaActionLayerAnimationID ActionLayerRequest => _actionLayerRequest;
        public FukaEmoteLayerAnimationID EmoteLayerRequest => _emoteLayerRequest;
        public FukaAdditivePoseLayerAnimationID AdditivePoseLayerRequest => _additivePoseLayerRequest;
        public FukaExtraLayerAnimationID ExtraLayerRequest => _extraLayerRequest;

    }
}