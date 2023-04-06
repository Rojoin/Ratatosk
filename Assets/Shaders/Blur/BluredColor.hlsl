void BluredColor_float(float4 Seed, float Min, float Max, float BlurX, float BlurY, out float4 Out)
{
    float randomno = frac(sin(dot(Seed.xy, float2(12.9898, 78.233))) * 43758.5453);
    float noise = lerp(Min, Max, randomno);
    float x = float(sin(noise)) * BlurX;
    float y = float(cos(noise)) * BlurY;
    float4 uvpos = float4(Seed.x + x, Seed.y + y, Seed.zw);

    Out = uvpos;
}