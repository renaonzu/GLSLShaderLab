#version 330 core
out vec4 FragColor;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
<<<<<<< HEAD

uniform vec2  iResolution;
uniform vec2  iMouse;
uniform int   iMouseClick;
uniform sampler2D iChannel0; 


const float SCALE   = 1.010; 
const float DAMPING = 0.996; 

float softCircle(vec2 uv, vec2 c, float r) {
    float d = distance(uv, c);
    return smoothstep(r, r*0.6, r - d);
}

void main() {
    vec2 uv = gl_FragCoord.xy / iResolution;

    
    vec4 prev = texture(iChannel0, uv);
    vec3 colorPrev = prev.rgb;
    vec2 centerPrev = prev.ba; 


    if (centerPrev == vec2(0.0)) centerPrev = vec2(0.5);


    vec2 mouse = iMouse / iResolution;
    vec2 center = (iMouseClick == 1) ? mouse : centerPrev;

   
    vec2 scaledUV = center + (uv - center) * SCALE;
    scaledUV = clamp(scaledUV, 0.0, 1.0);

    
    vec3 color = texture(iChannel0, scaledUV).rgb;

   
    color *= DAMPING;

    
    if (iMouseClick == 1) {
        float a = softCircle(uv, mouse, 0.05);
        vec3 paint = vec3(1.0, 0.5, 0.0);
        color = mix(color, paint, a);
    }

    
    FragColor = vec4(color.rg, center.x, center.y);
}
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
uniform float iTime;
uniform vec2 iResolution;
uniform vec2 iMouse;
uniform int iMouseClick;
 
// Buffer test - simple feedback system
uniform sampler2D iChannel0;
 
void Circle(vec2 uv, vec2 center, float radius, vec3 input,  out vec3 output)
{
        float dist = distance(uv, center);
        float circle = 1.0 - smoothstep(0.02, radius, dist);
        vec3 paintColor = vec3(1.0, 0.5, 0.0); // orange
        output = mix(input, paintColor, circle);
 
}
 
 
void main()
{
    vec2 uv = gl_FragCoord.xy / iResolution.xy;
    vec2 mouse = iMouse.xy / iResolution.xy;
   
    // Read previous frame
    vec3 previous = texture(iChannel0, uv).rgb;
   
    // Start with previous frame (for persistence)
    vec3 color = previous;
   
    // Fade slightly over time (optional)
    color *= 0.99;
   
    // Add new content when clicking
    if (iMouseClick == 1) {
       Circle(uv, mouse, 0.05, color, color);
    }
   
    // Always show mouse position
    float mouseDist = distance(uv, mouse);
    float mouseIndicator = 1.0 - smoothstep(0.002, 0.005, mouseDist);
    color = mix(color, vec3(0.0, 1.0, 1.0), mouseIndicator * 0.8);
   
    FragColor = vec4(color, 1.0);
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
}
=======
}
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
>>>>>>> Stashed changes
=======
}
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
>>>>>>> Stashed changes
=======
}
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
>>>>>>> Stashed changes
