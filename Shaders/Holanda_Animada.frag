#version 330 core

out vec4 FragColor;

uniform float iTime;
uniform vec2 iResolution;

void main()
{
    vec2 uv = gl_FragCoord.xy / iResolution.xy;
    
    // Frequência e amplitude da onda
    float wave = cos((iTime * 2.0 + uv.x * 2.0) ) * 0.08;

    // Ajusta as linhas horizontais da bandeira com onda
    float topLine = 2.0/3.0 + wave;   // limite entre preto e vermelho
    float midLine = 1.0/3.0 + wave;   // limite entre vermelho e amarelo

    if (uv.y > topLine) {
        // Preto
        FragColor = vec4(0.0, 0.318, 1.0, 1.0);
    } 
    else if (uv.y > midLine) {
        // Vermelho
        FragColor = vec4(1.0, 1.0, 1.0, 1.0);
    }
    else {
        // Amarelo ouro
        FragColor = vec4(1.0, 0.0, 0.0, 0.0);
    }
}
 