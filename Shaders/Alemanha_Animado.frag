#version 330 core

out vec4 FragColor;

uniform float iTime;
uniform vec2 iResolution;

void main()
{
    vec2 uv = gl_FragCoord.xy / iResolution.xy;
    
    float wave = cos((iTime * 2.0 + uv.x * 2.0) ) * 0.05;

    float topLine = 2.0/3.0 + wave;   // limite entre preto e vermelho
    float midLine = 1.0/3.0 + wave;   // limite entre vermelho e amarelo

    if (uv.y > topLine) {
        FragColor = vec4(0.0, 0.0, 0.0, 1.0);
    } 
    else if (uv.y > midLine) {
        FragColor = vec4(1.0, 0.0, 0.0, 1.0);
    }
    else {
        FragColor = vec4(1.0, 0.843, 0.0, 1.0);
    }

    // Ajustar as bordas para acompanhar o movimento da onda
    // Agora as bordas se movem conforme o wave

    // borda inferior
    if(uv.y < 0.1 + wave){
        FragColor = vec4(1);
    }

    // borda superior
    if(uv.y > 0.9 + wave){
        FragColor = vec4(1);
    }

    // bordas laterais, também com movimento vertical da onda
    if(uv.x < 0.1 + wave){
        FragColor = vec4(1);
    }
    if(uv.x > 0.9 + wave){
        FragColor = vec4(1);
    }
}
