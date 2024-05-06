Shader "Custom/StartShader"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,0,1) // Yellow color by default
        _MainTex ("Base (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert 

        struct Input
        {
            float2 uv_MainTex;
            float3 worldNormal;
        };

        sampler2D _MainTex;
        fixed4 _Color;

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;

            float lightIntensity = dot(normalize(IN.worldNormal), float3(0, 0, -1));

            if (lightIntensity > 0.8) 
                o.Albedo = fixed3(1, 1, 0); 
            else if (lightIntensity > 0.4) 
                o.Albedo = fixed3(0.8, 0.8, 0); 
            else 
                o.Albedo = fixed3(0.6, 0.6, 0); 
            
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
