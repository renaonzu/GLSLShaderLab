# ?? Troubleshooting - Shader Lab

## ? Problema: Tela Preta no PaintTutorial

### ?? **Solu��es:**

#### **1. Ativar Sistema de Buffers**
- **Pressione a tecla 'B'** para ativar buffers
- Verifique se o t�tulo da janela mostra **"[Buffers ON]"**
- O PaintTutorial precisa dos buffers para funcionar corretamente

#### **2. Usar SimplePaint (sem buffers)**
- Selecione o shader **"SimplePaint"** na lista
- Funciona sem precisar ativar buffers
- Ideal para demonstra��es r�pidas

#### **3. Verificar Console de Erros**
- Olhe o console do Visual Studio para erros de shader
- Erros comuns:
  ```
  Fragment Shader Log: ERROR: uniform 'iMouseClick' not found
  ```

### ?? **Como Testar se Est� Funcionando:**

1. **Execute o programa**
2. **Selecione "PaintTutorial"** ou **"SimplePaint"**
3. **Para PaintTutorial**: Pressione **'B'** para ativar buffers
4. **Mova o mouse** - deve ver um pontinho amarelo
5. **Clique e arraste** - deve pintar c�rculos coloridos

### ?? **Problemas Comuns:**

#### **Tela Completamente Preta:**
- ? Buffers n�o ativados no PaintTutorial
- ? Erro de compila��o do shader
- ? Uniform n�o encontrado

#### **Mouse n�o Detectado:**
- ? `iMouseClick` n�o implementado
- ? Coordenadas do mouse invertidas
- ? `iMouse` n�o sendo enviado

#### **C�rculos n�o Aparecem:**
- ? `iMouseClick` sempre 0
- ? Tamanho do c�rculo muito pequeno
- ? Cor do pincel igual ao fundo

### ?? **Debug Steps:**

#### **1. Teste Shader B�sico:**
```glsl
void main() {
    vec2 uv = gl_FragCoord.xy / iResolution.xy;
    FragColor = vec4(uv, 0.5, 1.0); // Gradiente simples
}
```

#### **2. Teste Mouse:**
```glsl
void main() {
    vec2 uv = gl_FragCoord.xy / iResolution.xy;
    vec2 mouse = iMouse.xy / iResolution.xy;
    float dist = distance(uv, mouse);
    float circle = 1.0 - smoothstep(0.05, 0.1, dist);
    FragColor = vec4(vec3(circle), 1.0);
}
```

#### **3. Teste Click:**
```glsl
void main() {
    vec3 color = iMouseClick == 1 ? vec3(1.0, 0.0, 0.0) : vec3(0.0, 0.0, 1.0);
    FragColor = vec4(color, 1.0);
}
```

### ?? **Shaders Recomendados por N�vel:**

#### **Iniciante (sem buffers):**
- ? **SimplePaint** - Funciona imediatamente
- ? **shader** - Gradiente b�sico
- ? **Japao** - Padr�es simples

#### **Intermedi�rio (com buffers):**
- ? **PaintTutorial** - Sistema de pintura
- ? **Functions** - Feedback loops
- ? **waves** - Anima��es

#### **Avan�ado:**
- ? **BufferDemo** - Efeitos complexos
- ? **Clouds** - Noise procedural
- ? **AnimatedFlag** - Simula��o f�sica

### ?? **Checklist de Verifica��o:**

- [ ] Shader compila sem erros
- [ ] Console n�o mostra erros
- [ ] Buffers ativados (se necess�rio)
- [ ] Mouse move e clica
- [ ] Uniforms sendo enviados
- [ ] Coordenadas corretas (0-1)

### ?? **Dicas para Professores:**

1. **Sempre comece com SimplePaint** para demonstra��es
2. **Explique o conceito de buffers** antes de usar PaintTutorial
3. **Mostre o console** para debug em tempo real
4. **Use cores contrastantes** para facilitar visualiza��o
5. **Teste em diferentes resolu��es** de tela

---
**Lembre-se**: Se um shader n�o funciona, sempre verifique primeiro se os buffers est�o ativados (tecla 'B')! ??

## ? Problema: Desenho N�o Permanece no PaintTutorial

### ?? **Causa Principal:**
O **PaintTutorial** precisa do **sistema de buffers ativado** para que a pintura fique permanente na tela. Sem buffers, o desenho desaparece a cada frame.

### ? **Solu��es:**

#### **1. Auto-Ativa��o (Autom�tica)**
- O sistema agora **ativa buffers automaticamente** para PaintTutorial
- Mensagem no console: `"Buffer system AUTO-ENABLED"`
- ? **Recomendado**: Deixe o sistema ativar automaticamente

#### **2. Ativa��o Manual**
- **Pressione a tecla 'B'** para ativar buffers manualmente
- Verifique se o t�tulo mostra **"[Buffers ON]"**
- T�tulo da janela deve mostrar status dos buffers

#### **3. Indicadores Visuais**
- **Ponto amarelo** = posi��o do mouse (sempre vis�vel)
- **C�rculo rosa** = pintura normal (com buffers)
- **Borda vermelha piscante** = aviso que n�o est� permanente

### ?? **Como Testar se Est� Funcionando:**

#### **? COM Buffers (funcionando):**
1. Execute o programa
2. Selecione **"PaintTutorial"**
3. Buffers ativam automaticamente
4. Clique e arraste - **pintura fica permanente**
5. **SEM borda vermelha piscante**

#### **? SEM Buffers (tempor�rio):**
1. Execute o programa
2. Selecione **"PaintTutorial"**
3. Desative buffers (tecla 'B')
4. Clique e arraste - **pintura desaparece**
5. **COM borda vermelha piscante** (aviso)

### ?? **Compara��o de Comportamento:**

| Situa��o | T�tulo da Janela | Pintura | Indicador |
|----------|------------------|---------|-----------|
| **Buffers ON** | `[Buffers ON]` | ? Permanente | ?? Ponto amarelo |
| **Buffers OFF** | `[Buffers OFF]` | ? Tempor�ria | ?? Borda piscante |

### ?? **Shaders por Categoria:**

#### **?? Auto-Ativam Buffers:**
- ? **PaintTutorial** - Sistema de pintura persistente
- ? **BufferDemo** - Efeitos avan�ados com feedback
- ? **Functions** - Circles com trails

#### **?? Opcionais (funcionam sem):**
- ? **SimplePaint** - Pintura tempor�ria
- ? **waves** - Anima��es simples
- ? **Clouds** - Padr�es procedurais

#### **?? N�o Precisam:**
- ? **shader** - Gradiente b�sico
- ? **Japao** - Bandeira est�tica
- ? **Grece** - Padr�es fixos

### ?? **Problemas Comuns e Solu��es:**

#### **"Tela Azul, Mas Desenho N�o Fica"**
- **Causa**: Buffers desativados
- **Solu��o**: Recarregue o shader (auto-ativa) ou pressione 'B'

#### **"Borda Vermelha Piscando"**
- **Causa**: Aviso visual de que n�o h� persist�ncia
- **Solu��o**: Ative buffers (tecla 'B')

#### **"N�o Vejo o Mouse"**
- **Causa**: Indicador muito pequeno
- **Solu��o**: Move o mouse - deve ver ponto amarelo brilhante

#### **"Auto-Ativa��o N�o Funcionou"**
- **Causa**: Nome do shader mudou
- **Solu��o**: Ative manualmente com 'B'

### ?? **Dicas para Professores:**

1. **Explique a diferen�a** entre tempor�rio vs permanente
2. **Mostre os indicadores visuais** (amarelo vs vermelho)
3. **Use SimplePaint primeiro** para demonstra��o r�pida
4. **PaintTutorial depois** para explicar persist�ncia
5. **Sempre mencione** que buffers s�o para "mem�ria" entre frames

### ?? **Checklist de Verifica��o R�pida:**

- [ ] Shader � PaintTutorial?
- [ ] T�tulo mostra "[Buffers ON]"?
- [ ] V� ponto amarelo do mouse?
- [ ] Pintura fica ap�s soltar mouse?
- [ ] N�O h� borda vermelha piscante?

Se todos ? = **Funcionando perfeitamente!** ??

### ?? **Para Entender Melhor:**

**Buffers** = "Mem�ria visual" que guarda o que foi pintado
**iChannel0** = "Foto" do frame anterior
**Sem buffers** = Shader "esquece" o que pintou
**Com buffers** = Shader "lembra" e mant�m a pintura

---
**Lembre-se**: PaintTutorial = Buffers Obrigat�rios! O sistema agora ativa automaticamente! ??