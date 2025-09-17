#version 330 core
out vec4 fragColor;
uniform float iTime;
uniform vec2 iResolution;
uniform vec2 iMouse;
in vec2 TexCoord;


void main()
{
    //vec2 uv = gl_FragCoord.xy/iResolution.xy;
    vec2 uv = TexCoord;
    
    if(uv.x < 0.30){
    fragColor = vec4(0.0, 0.318, 1.0, 1.0);
    }
    
    else if(uv.x > 0.7)
    {
        fragColor = vec4 (1.0, 0.0, 0.0, 0.0);
    }
    else
    {
        fragColor = vec4 (1.0, 1.0, 1.0, 1.0);
    }

}