#version 330 core
out vec4 fragColor;
uniform float iTime;
uniform vec2 iResolution;


void main()
{
    vec2 uv = gl_FragCoord.xy / iResolution.xy;

    uv -= 0.5; 
    uv.x *= iResolution.x / iResolution.y; 

    float thickness = 0.08;
    
    vec4 red = vec4(1.0, 0.0, 0.0, 1.0);
    vec4 white = vec4(1.0, 1.0, 1.0, 1.0);
    
    fragColor = white; 
    

    if (abs(uv.y) < thickness * 0.75) {
        fragColor = red;
    }

  
    if (abs(uv.x) < thickness * 0.75) {
        fragColor = red;
    }
    
}