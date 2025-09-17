#version 330 core
out vec4 fragColor;
uniform float iTime;
in vec2 TexCoord;
uniform vec2 iResolution;


void main()
{
    //vec2 uv = gl_FragCoord.xy/iResolution.xy;
    vec2 uv = TextCoord;
    
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