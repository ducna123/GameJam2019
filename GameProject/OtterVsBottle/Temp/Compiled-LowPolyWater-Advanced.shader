// Compiled shader for PC, Mac & Linux Standalone

//////////////////////////////////////////////////////////////////////////
// 
// NOTE: This is *not* a valid shader file, the contents are provided just
// for information and for debugging purposes only.
// 
//////////////////////////////////////////////////////////////////////////
// Skipping shader variants that would not be included into build of current scene.

Shader "LowPolyWater/Advanced" {
Properties {
 _Shadow ("Shadow Bias", Range(0.000000,1.000000)) = 0.700000
 _Color ("Color", Color) = (0.000000,0.500000,0.700000,1.000000)
 _Opacity ("Opacity", Range(0.000000,1.000000)) = 0.700000
 _Specular ("Specular", Range(1.000000,300.000000)) = 70.000000
 _SpecColor ("Sun Color", Color) = (0.703000,0.676000,0.438000,1.000000)
 _Diffuse ("Diffuse", Range(0.000000,1.000000)) = 0.500000
[Toggle]  _PointLights ("Enable Point Lights", Float) = 0.000000
[KeywordEnum(Flat, VertexLit, PixelLit)]  _Shading ("Shading", Float) = 0.000000
[NoScaleOffset]  _FresnelTex ("Fresnel (A) ", 2D) = "" { }
 _FresPower ("Fresnel Exponent", Range(0.000000,2.000000)) = 1.500000
 _FresColor ("Fresnel Color", Color) = (0.305000,0.371000,0.395000,1.000000)
 _Reflection ("Reflection", Range(0.000000,2.000000)) = 1.200000
 _Refraction ("Refractive Distortion", Float) = 2.000000
 _NormalOffset ("Normal Offset", Range(0.000000,5.000000)) = 1.000000
[Toggle]  _Distort ("Enable Distortion", Float) = 0.000000
 _Distortion ("Reflective Distortion", Float) = 1.000000
[NoScaleOffset]  _BumpTex ("Distortion Map", 2D) = "" { }
 _BumpScale ("Distortion Scale", Float) = 35.000000
 _BumpSpeed ("Distortion Speed", Float) = 0.200000
[KeywordEnum(Off, LowQuality, HighQuality)]  _Waves ("Enable Waves", Float) = 2.000000
 _Length ("Wave Length", Float) = 4.000000
 _Stretch ("Wave Stretch", Float) = 10.000000
 _Speed ("Wave Speed", Float) = 0.500000
 _Height ("Wave Height", Float) = 0.500000
 _Steepness ("Wave Steepness", Range(0.000000,1.000000)) = 0.200000
 _Direction ("Wave Direction", Range(0.000000,360.000000)) = 180.000000
 _RSpeed ("Ripple Speed", Float) = 1.000000
 _RHeight ("Ripple Height", Float) = 0.250000
[Toggle]  _EdgeBlend ("Enable Foam", Float) = 0.000000
 _ShoreColor ("Foam Color", Color) = (1.000000,1.000000,1.000000,1.000000)
 _ShoreIntensity ("Foam Intensity", Range(-1.000000,1.000000)) = 1.000000
 _ShoreDistance ("Foam Distance", Float) = 0.500000
[Toggle]  _HQFoam ("Enable HQ Foam", Float) = 0.000000
 _FoamScale ("Foam Scale", Float) = 20.000000
 _FoamSpeed ("Foam Speed", Float) = 0.300000
 _FoamSpread ("Foam Spread", Float) = 1.000000
[Toggle]  _LightAbs ("Enable Light Absorption", Float) = 0.000000
 _Absorption ("Depth Transparency", Float) = 5.000000
 _DeepColor ("Deep Water Color", Color) = (0.000000,0.100000,0.200000,1.000000)
 _Scale ("Global Scale", Float) = 1.000000
[NoScaleOffset]  _NoiseTex ("Noise Texture (A)", 2D) = "" { }
[Toggle]  _Cull ("Show Surface Underwater", Float) = 0.000000
[Toggle]  _ZWrite ("Write to Depth Buffer", Float) = 0.000000
[HideInInspector]  _TransformScale_ ("_TransformScale_", Float) = 1.000000
[HideInInspector]  _Scale_ ("_Scale_", Float) = 1.000000
[HideInInspector]  _BumpScale_ ("_BumpScale_", Float) = 1.000000
[HideInInspector]  _Cull_ ("_Cull_", Float) = 2.000000
[HideInInspector]  _Direction_ ("_Direction_", Vector) = (0.000000,0.000000,0.000000,0.000000)
[HideInInspector]  _RHeight_ ("_RHeight_", Float) = 0.200000
[HideInInspector]  _RSpeed_ ("_RSpeed_", Float) = 0.200000
[HideInInspector]  _TexSize_ ("_TexSize_", Float) = 64.000000
[HideInInspector]  _Speed_ ("_Speed_", Float) = 0.000000
[HideInInspector]  _Height_ ("_Height_", Float) = 0.000000
[HideInInspector]  _ReflectionTex ("_ReflectionTex", 2D) = "" { }
[HideInInspector]  _RefractionTex ("_RefractionTex", 2D) = "" { }
[HideInInspector]  _Time_ ("_Time_", Float) = 0.000000
[HideInInspector]  _EnableShadows ("_EnableShadows", Float) = 0.000000
[HideInInspector]  _Sun ("_Sun", Vector) = (0.000000,0.000000,0.000000,0.000000)
[HideInInspector]  _SunColor ("_SunColor", Color) = (1.000000,1.000000,1.000000,1.000000)
}
SubShader { 
 LOD 200
 Tags { "QUEUE"="AlphaTest+51" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "LIGHTMODE"="FORWARDBASE" "QUEUE"="AlphaTest+51" "IGNOREPROJECTOR"="true" "SHADOWSUPPORT"="true" "RenderType"="Transparent" }
  ZWrite [_ZWrite]
  Cull [_Cull_]
  Blend SrcAlpha OneMinusSrcAlpha
  //////////////////////////////////
  //                              //
  //      Compiled programs       //
  //                              //
  //////////////////////////////////
//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LIGHTPROBE_SH LPW_FOAM 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LIGHTPROBE_SH _WAVES_HIGHQUALITY 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LIGHTPROBE_SH LPW_FOAM WATER_REFLECTIVE _LIGHTABS_ON _WAVES_HIGHQUALITY 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LIGHTPROBE_SH 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LPW_FOAM SHADOWS_SCREEN 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL SHADOWS_SCREEN _WAVES_HIGHQUALITY 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LPW_FOAM SHADOWS_SCREEN WATER_REFLECTIVE _LIGHTABS_ON _WAVES_HIGHQUALITY 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL SHADOWS_SCREEN 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LIGHTPROBE_SH LPW_FOAM SHADOWS_SCREEN 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LIGHTPROBE_SH SHADOWS_SCREEN _WAVES_HIGHQUALITY 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LIGHTPROBE_SH LPW_FOAM SHADOWS_SCREEN WATER_REFLECTIVE _LIGHTABS_ON _WAVES_HIGHQUALITY 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LIGHTPROBE_SH SHADOWS_SCREEN 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LPW_FOAM 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL _WAVES_HIGHQUALITY 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LPW_FOAM WATER_REFLECTIVE _LIGHTABS_ON _WAVES_HIGHQUALITY 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

 }
 Pass {
  Tags { "LIGHTMODE"="Vertex" "QUEUE"="AlphaTest+51" "IGNOREPROJECTOR"="true" "SHADOWSUPPORT"="true" "RenderType"="Transparent" }
  ZWrite [_ZWrite]
  Cull [_Cull_]
  Blend SrcAlpha OneMinusSrcAlpha
  //////////////////////////////////
  //                              //
  //      Compiled programs       //
  //                              //
  //////////////////////////////////
//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LIGHTPROBE_SH LPW_FOAM 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LIGHTPROBE_SH _WAVES_HIGHQUALITY 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LIGHTPROBE_SH LPW_FOAM WATER_REFLECTIVE _LIGHTABS_ON _WAVES_HIGHQUALITY 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LIGHTPROBE_SH 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LPW_FOAM SHADOWS_SCREEN 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL SHADOWS_SCREEN _WAVES_HIGHQUALITY 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LPW_FOAM SHADOWS_SCREEN WATER_REFLECTIVE _LIGHTABS_ON _WAVES_HIGHQUALITY 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL SHADOWS_SCREEN 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LIGHTPROBE_SH LPW_FOAM SHADOWS_SCREEN 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LIGHTPROBE_SH SHADOWS_SCREEN _WAVES_HIGHQUALITY 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LIGHTPROBE_SH LPW_FOAM SHADOWS_SCREEN WATER_REFLECTIVE _LIGHTABS_ON _WAVES_HIGHQUALITY 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LIGHTPROBE_SH SHADOWS_SCREEN 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LPW_FOAM 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL _WAVES_HIGHQUALITY 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: DIRECTIONAL LPW_FOAM WATER_REFLECTIVE _LIGHTABS_ON _WAVES_HIGHQUALITY 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

 }
 Pass {
  Tags { "LIGHTMODE"="SHADOWCASTER" "QUEUE"="AlphaTest+51" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  ZWrite [_ZWrite]
  Cull [_Cull_]
  //////////////////////////////////
  //                              //
  //      Compiled programs       //
  //                              //
  //////////////////////////////////
//////////////////////////////////////////////////////
Global Keywords: <none>
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: _WAVES_HIGHQUALITY 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

 }
}
SubShader { 
 LOD 200
 Tags { "QUEUE"="AlphaTest+51" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "LIGHTMODE"="FORWARDBASE" "QUEUE"="AlphaTest+51" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  ZWrite [_ZWrite]
  Cull [_Cull_]
  Blend SrcAlpha OneMinusSrcAlpha
  //////////////////////////////////
  //                              //
  //      Compiled programs       //
  //                              //
  //////////////////////////////////
//////////////////////////////////////////////////////
Global Keywords: <none>
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: LPW_FOAM 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

 }
 Pass {
  Tags { "LIGHTMODE"="Vertex" "QUEUE"="AlphaTest+51" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  ZWrite [_ZWrite]
  Cull [_Cull_]
  Blend SrcAlpha OneMinusSrcAlpha
  //////////////////////////////////
  //                              //
  //      Compiled programs       //
  //                              //
  //////////////////////////////////
//////////////////////////////////////////////////////
Global Keywords: <none>
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

//////////////////////////////////////////////////////
Global Keywords: LPW_FOAM 
Local Keywords: <none>
-- Hardware tier variant: Tier 1
-- Vertex shader for "d3d11":
// Compile errors generating this shader.

-- Hardware tier variant: Tier 1
-- Fragment shader for "d3d11":
// Compile errors generating this shader.

 }
}
CustomEditor "LPWAsset.LPWShaderGUI"
Fallback "Mobile/VertexLit"
}