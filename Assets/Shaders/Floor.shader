// Shader created with Shader Forge Beta 0.34 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.34;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,blpr:0,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32247,y:32737|diff-4-OUT,lwrap-26-OUT;n:type:ShaderForge.SFN_Color,id:3,x:33099,y:32481,ptlb:Color1,ptin:_Color1,glob:False,c1:0.2313726,c2:0.3137255,c3:0.3960784,c4:1;n:type:ShaderForge.SFN_Lerp,id:4,x:32778,y:32675|A-3-RGB,B-6-RGB,T-23-OUT;n:type:ShaderForge.SFN_Color,id:6,x:33123,y:32647,ptlb:Color2,ptin:_Color2,glob:False,c1:0.1470588,c2:0.1470588,c3:0.1470588,c4:1;n:type:ShaderForge.SFN_TexCoord,id:8,x:33299,y:32787,uv:0;n:type:ShaderForge.SFN_Length,id:20,x:32973,y:32787|IN-21-OUT;n:type:ShaderForge.SFN_RemapRange,id:21,x:33142,y:32787,frmn:0,frmx:1,tomn:-1,tomx:1|IN-8-UVOUT;n:type:ShaderForge.SFN_Multiply,id:23,x:32720,y:32941|A-20-OUT,B-24-OUT;n:type:ShaderForge.SFN_Slider,id:24,x:32973,y:32996,ptlb:MultiplyValue,ptin:_MultiplyValue,min:0,cur:0.9849634,max:1;n:type:ShaderForge.SFN_LightAttenuation,id:25,x:32876,y:33119;n:type:ShaderForge.SFN_Multiply,id:26,x:32572,y:33084|A-25-OUT,B-27-OUT;n:type:ShaderForge.SFN_ValueProperty,id:27,x:32881,y:33304,ptlb:LightAtte,ptin:_LightAtte,glob:False,v1:0;proporder:3-6-24-27;pass:END;sub:END;*/

Shader "Custom/Floor" {
    Properties {
        _Color1 ("Color1", Color) = (0.2313726,0.3137255,0.3960784,1)
        _Color2 ("Color2", Color) = (0.1470588,0.1470588,0.1470588,1)
        _MultiplyValue ("MultiplyValue", Range(0, 1)) = 0.9849634
        _LightAtte ("LightAtte", Float ) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color1;
            uniform float4 _Color2;
            uniform float _MultiplyValue;
            uniform float _LightAtte;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Normals:
                float3 normalDirection =  i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float node_26 = (attenuation*_LightAtte);
                float3 w = float3(node_26,node_26,node_26)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 diffuse = forwardLight * attenColor + UNITY_LIGHTMODEL_AMBIENT.rgb;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * lerp(_Color1.rgb,_Color2.rgb,(length((i.uv0.rg*2.0+-1.0))*_MultiplyValue));
/// Final Color:
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color1;
            uniform float4 _Color2;
            uniform float _MultiplyValue;
            uniform float _LightAtte;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Normals:
                float3 normalDirection =  i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float node_26 = (attenuation*_LightAtte);
                float3 w = float3(node_26,node_26,node_26)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 diffuse = forwardLight * attenColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * lerp(_Color1.rgb,_Color2.rgb,(length((i.uv0.rg*2.0+-1.0))*_MultiplyValue));
/// Final Color:
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
