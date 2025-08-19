#version 330 core
out vec4 fragColor;
uniform float iTime;
uniform vec2 iResolution;

void main()
{
    // Coordenadas UV normalizadas (0 a 1)
    vec2 uv = gl_FragCoord.xy/iResolution.xy;

    // Corrigir proporção da tela para não deformar
    float aspect = iResolution.x / iResolution.y;
    vec2 centered = (uv - 0.5) * vec2(aspect, 1.0); // Agora temos (x, y) centralizado e corrigido

    // Cor padrão: verde
    vec3 color = vec3(0.0, 0.6, 0.2);

    // Desenhar o losango amarelo
    if (abs(centered.x) + abs(centered.y) < 0.7)
        color = vec3(1.0, 0.8, 0.0); // amarelo

    // Desenhar o círculo azul
    if (length(centered) < 0.3)
        color = vec3(0.0, 0.3, 0.7); // azul

    // Desenhar faixa branca curva
    float wave = 0.05 * sin(centered.x * 30.0); // curva senoidal
    if (length(centered) < 0.3 && abs(centered.y + wave) < 0.015)
        color = vec3(1.0); // branco

    fragColor = vec4(color, 1.0);
}
