// ReSharper disable All

namespace Captain.Common.Native {
  public static partial class DwmApi {
    public struct DWMCOLORIZATIONPARAMS {
      public uint ColorizationColor,
        ColorizationAfterglow,
        ColorizationColorBalance,
        ColorizationAfterglowBalance,
        ColorizationBlurBalance,
        ColorizationGlassReflectionIntensity,
        ColorizationOpaqueBlend;
    }
  }
}