﻿using System;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.Playables;

namespace HalfBlind.Timeline {
    [Serializable]
    public class TweenMoveMixerBehaviour : TweenMixerBehaviour<TweenMoveBehaviour, Vector3> {
        private Vector3? _initialValue;

        public override void OnGraphStop(Playable playable) {
            base.OnGraphStop(playable);
            if (_targetTransform && _initialValue.HasValue) {
                _targetTransform.position = _initialValue.Value;
            }
        }

        public override void SetValue(Vector3 lastKnown) {
            _targetTransform.position = lastKnown;
        }

        public override Vector3 GetInitialValue() {
            if (_initialValue == null) {
                _initialValue = _targetTransform.position;
            }
            
            return _initialValue.Value;
        }

        public override Vector3 Evaluate(TweenMoveBehaviour tweenScaleBehaviour, Vector3 initial, float time, float duration) {
            var t = EasingUtils.Evaluate(tweenScaleBehaviour.Easing, tweenScaleBehaviour.CustomCurve, time, duration);
            var target = tweenScaleBehaviour.TargetValue;
            if (tweenScaleBehaviour.IsFrom) {
                target = initial;
                initial = tweenScaleBehaviour.TargetValue;
            }
            return initial * (1 - t) + target * t;
        }
    }
}
