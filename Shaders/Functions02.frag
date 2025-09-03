#version 330 core
out vec4 fragColor;

uniform float iTime;
uniform vec2 iResolution;
uniform vec2 iMouse;

float isPointInTriangle(vec2 p, vec2 a, vec2 b, vec2 c)
{
    vec2 v0 = c - a;
    vec2 v1 = b - a;
    vec2 v2 = p - a;

    float dot00 = dot(v0, v0);
    float dot01 = dot(v0, v1);
    float dot02 = dot(v0, v2);
    float dot11 = dot(v1, v1);
    float dot12 = dot(v1, v2);

    float invDenom = 1.0 / (dot00 * dot11 - dot01 * dot01);
    float u = (dot11 * dot02 - dot01 * dot12) * invDenom;
    float v = (dot00 * dot12 - dot01 * dot02) * invDenom;

    return (u >= 0.0) && (v >= 0.0) && (u + v <= 1.0) ? 1.0 : 0.0;
}

void main()
{
    vec2 uv = gl_FragCoord.xy / iResolution.xy;

    
    vec2 mouse = iMouse / iResolution;

    
    float size = 0.1;

    
    vec2 p0 = mouse + vec2(0.0, size);
    vec2 p1 = mouse + vec2(-size * 0.866, -size * 0.5);
    vec2 p2 = mouse + vec2(size * 0.866, -size * 0.5);

    
    float inside = isPointInTriangle(uv, p0, p1, p2);

    vec3 triangleColor = vec3(1.0, 0.0, 0.0);
    vec3 bgColor = 0.5 + 0.5 * cos(iTime + uv.xyx + vec3(0, 2, 4)); 

    vec3 finalColor = mix(bgColor, triangleColor, inside);

    fragColor = vec4(finalColor, 1.0);
}
