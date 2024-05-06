Shader "Unlit/FirstUnlit"
{
    Properties
    {
        _DiffuseColor("DiffuseColor", Color) = (1,1,0,1)
        _LightDirection("LightDirection", Vector) = (1,-1,-1,0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
           
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f //vertex tp float
            {
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
            };

            float4 _DiffuseColor;
            float4 _LightDirection;

            v2f vert (appdata v) //vertex Shader
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = normalize(v.normal);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                //fixed4 col = float4(1.0f,1.0f,0.0,1.0f);
                float3 lightDir = normalize(_LightDirection);
                float4 lightIntensity = max(dot(i.normal,lightDir),0); //dot 내적, 빛의 방향과 법선 벡터의 내적을 0과 비교해서 큰 값만 사용

                float4 col = _DiffuseColor * lightIntensity;

                return col;
            }


            ENDCG
        }
    }
}
