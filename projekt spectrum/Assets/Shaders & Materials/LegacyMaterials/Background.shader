Shader "Unlit/Background" { // path to the shader
    Properties { // input data
        _ColorA ("Color A", Color ) = (1,1,1,1)
        _ColorB ("Color B", Color ) = (1,1,1,1)
        _ColorStart ("Color Start", Range(0,1) ) = 0
        _ColorEnd ("Color End", Range(0,1) ) = 1
    }
    SubShader { 
        // subshader tags, which is configurations for how we want this subshader to act
        Tags { "RenderType"="Opaque" } 
        Pass { 
        // pass tags (where we define our shader code)

            CGPROGRAM // shader code, same as hlsl code. Everything outside of this scope is shaderlab, which is Unitys wrapper langueage
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            #define TAU 6.28318530718

            // properties defined as valuables, so we can acces them
            float4 _ColorA;
            float4 _ColorB;
            float _ColorStart;
            float _ColorEnd;

            // automatically filled out by Unity
            struct MeshData { // per-vertex mesh data 
                float4 vertex : POSITION; // local space vertex position 
                //float3 normals : Normal; // local space normal direction 
                // float4 tangent : TANGENT; // tangent direction (xyz) tangent sign (w) 
                // float4 color : COLOR; // vertex colors
                float2 uv0 : TEXCOORD0; // uv0 diffuse/normal map textures
                // float4 uv1 : TEXCOORD1; // uv1 coordinates lightmap coordinates
                // float4 uv2 : TEXCOORD2; // uv2 coordinates lightmap coordinates
                // float4 uv3 : TEXCOORD3; // uv3 coordinates lightmap coordinates
            };

            // data passed from the vertex shader to the fragment shader 
            // this data will interpolate/blend across the triangle 
            struct Interpolators {
                float4 vertex : SV_POSITION; // clip space position (only one that is needed)
                //float3 normal : TEXCOORD0; 
                float2 uv : TEXCOORD1;
                // float2 tangent : TEXCOORD2; 
                // float2 justSomeValues : TEXCOORD3; // channels to store some value (not to be confused with TEXCOORD in MeshData) 
             
            };

            Interpolators vert( MeshData v ) {
                Interpolators o;
                o.vertex = UnityObjectToClipPos( v.vertex ); // local space to clip space
                //o.normal = UnityObjectToWorldNormal( v.normals );
                o.uv = v.uv0; // (v.uv0 + _Offset) * _Scale; // passthrough 
                return o;
            }

            float InverseLerp( float a, float b, float v ) {
                return (v-a)/(b-a); 
            }

             float4 InverseLerp( float4 a, float4 b, float4 v ) {
                return (v-a)/(b-a); 
            }

            fixed4 frag( Interpolators i ) : SV_Target {
                float2 uvsCentered = i.uv * 2 - 1;
                float radialDistance = length( uvsCentered ); 

                float t = saturate( InverseLerp( _ColorStart, _ColorEnd, radialDistance ) );
                float4 outColor = lerp( _ColorA, _ColorB, t );        
               
                return outColor;      
                               
            }

            ENDCG
        }
    }
}
