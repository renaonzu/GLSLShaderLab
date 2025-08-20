#version 330 core

out vec4 FragColor;

uniform float iTime;
uniform vec2 iResolution;

void main()
{
    vec2 uv = gl_FragCoord.xy / iResolution.xy;
    
    // Onda para as faixas da bandeira
    float wave = cos(iTime * 2.0 + uv.x * 2.0) * 0.08;

    float topLine = 2.0 / 3.0 + wave;
    float midLine = 1.0 / 3.0 + wave;

    if (uv.y > topLine) {
        FragColor = vec4(0.0, 0.318, 1.0, 1.0);  // Azul
    }
    else if (uv.y > midLine) {
        FragColor = vec4(1.0, 1.0, 1.0, 1.0);    // Branco
    }
    else {
        FragColor = vec4(1.0, 0.0, 0.0, 0.0);    // Vermelho transparente
    }

    // Ondas dedicadas para as bordas
    float borderWaveX = sin(iTime * 3.0 + uv.y * 20.0) * 0.03;
    float borderWaveY = cos(iTime * 2.5 + uv.x * 25.0) * 0.03;

    // Bordas inferiores e superiores com movimento fluido
    if (uv.y < 0.2 + borderWaveX) {
        FragColor = vec4(0, 0, 0, 1);  // borda preta (ou mudar cor se quiser)
    }
    if (uv.y > 0.9 + borderWaveX) {
        FragColor = vec4(0, 0, 0, 1);
    }

    // Bordas laterais com movimento fluido
    if (uv.x < 0.1 + borderWaveY) {
        FragColor = vec4(0, 0, 0, 1);
    }
    if (uv.x > 0.9 + borderWaveY) {
        FragColor = vec4(0, 0, 0, 1);
    }
}
