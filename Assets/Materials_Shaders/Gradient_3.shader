Shader "Custom/Gradient_3"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Slider("One_ajust", Range(0, 1)) = 0
    }
        SubShader
        {
            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                float _Slider;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                return float4(_Slider, i.uv.x, i.uv.y, 1); // RGB 1 - R, 2 - G, 3 - B, 4 - alpha
            }
            ENDCG
        }
    }
}
