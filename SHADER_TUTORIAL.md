# ?? Tutorial de Shader - Sistema de Pintura

## ?? O que este shader faz?

Este shader simula um **programa de pintura simples** onde voc� pode:
- Clicar e arrastar o mouse para desenhar c�rculos coloridos
- Os c�rculos ficam "marcados" na tela (persistem entre frames)
- Usar buffers para lembrar do que foi pintado antes

## ?? Como funciona?

### Conceitos b�sicos:

1. **Coordenadas UV** (0 a 1):
   ```glsl
   vec2 uv = gl_FragCoord.xy / iResolution.xy;
   ```
   - Converte pixels da tela para coordenadas normalizadas
   - (0,0) = canto inferior esquerdo
   - (1,1) = canto superior direito

2. **Detec��o do Mouse Clicado**:
   ```glsl
   uniform int iMouseClick;  // 1 = clicado, 0 = n�o clicado
   if (iMouseClick == 1) // Mouse pressionado
   ```
   - `iMouse.xy` = posi��o do mouse
   - `iMouseClick` = estado do bot�o (0 ou 1) - mais claro que iMouse.z

3. **Fun��o distance()**:
   ```glsl
   float dist = distance(coordenadas, posicaoMouse);
   ```
   - Calcula dist�ncia entre dois pontos
   - Usado para criar c�rculos

4. **Fun��o smoothstep()**:
   ```glsl
   float circulo = 1.0 - smoothstep(tamanho - borda, tamanho, distancia);
   ```
   - Cria transi��es suaves (anti-aliasing)
   - Evita bordas "serrilhadas"

5. **Buffers (iChannel0)**:
   ```glsl
   vec3 anterior = texture(iChannel0, uv).rgb;
   ```
   - L� o que foi pintado no frame anterior
   - Permite persist�ncia da pintura

## ?? **iMouseClick vs iMouse.z**

### **Vantagens do iMouseClick:**
- ? **Mais claro**: `iMouseClick == 1` � mais leg�vel que `iMouse.z > 0.5`
- ? **Sem�ntica**: Nome espec�fico para a fun��o
- ? **Tipo correto**: `int` em vez de `float`
- ? **Pedag�gico**: Mais f�cil para iniciantes entenderem

### **Compara��o:**
```glsl
// M�todo antigo (funciona, mas menos claro)
if (iMouse.z > 0.5) { /* pintar */ }

// M�todo novo (mais claro e did�tico)
if (iMouseClick == 1) { /* pintar */ }
```

## ?? Exerc�cios para Praticar:

### N�vel Iniciante:
1. **Mudar cor do pincel**: Altere `vec3(0.9, 0.4, 0.7)` para outras cores
2. **Tamanho do c�rculo**: Modifique `0.08` para fazer c�rculos maiores/menores
3. **Cor de fundo**: Adicione uma cor de fundo fixa

### N�vel Intermedi�rio:
4. **Cores animadas**: Use `sin(iTime)` para animar as cores
5. **M�ltiplos pinc�is**: Diferentes cores baseadas na posi��o do mouse
6. **Fade gradual**: Descomente a linha do fade para pintura tempor�ria

### N�vel Avan�ado:
7. **Pinc�is diferentes**: Quadrados, tri�ngulos, estrelas
8. **Texturas**: Use outros iChannels para texturas de pincel
9. **Blend modes**: Experimente diferentes modos de mistura

## ?? Dicas importantes:

- **Sempre ative buffers**: Pressione 'B' no programa para ativar iChannels
- **Coordenadas**: GLSL usa (0,0) no canto inferior esquerdo
- **Performance**: Evite loops complexos em shaders de pixel
- **Debugging**: Use cores simples (vermelho, verde, azul) para testar
- **iMouseClick**: Mais intuitivo que iMouse.z para detec��o de cliques

## ?? Pr�ximos passos:

1. Entenda este shader completamente
2. Experimente modifica��es simples
3. Crie suas pr�prias fun��es de desenho
4. Explore outros shaders do projeto para aprender mais t�cnicas

---
**Lembre-se**: Shader programming � como aprender uma nova linguagem. 
Pratique muito e n�o tenha medo de experimentar! ??