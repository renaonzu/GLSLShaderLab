#version 330 core
out vec4 fragColor;
in vec2 TexCoord;
uniform float iTime;
uniform vec2 iResolution;

vec3 lightDir = normalize(vec3(0.75, -1.0, 0.0));
float ambient = 0.2;

void main()
{
    
    vec2 uv = TexCoord;
    uv -= 0.5;
    uv.x *= iResolution.x / iResolution.y;

    float thickness = 0.08;

    
    vec4 red = vec4(1.0, 0.0, 0.0, 1.0);
    vec4 white = vec4(1.0, 1.0, 1.0, 1.0);
    vec4 baseColor = white;

    
    if (abs(uv.y) < thickness * 0.75) {
        baseColor = red;
    }

    if (abs(uv.x) < thickness * 0.75) {
        baseColor = red;
    }

    
    vec3 Normal = vec3(0.0, 0.0, 1.0);
    float brightness = clamp(dot(Normal, -lightDir), 0.0, 1.0);

    
    fragColor = baseColor + (brightness + ambient);
}
