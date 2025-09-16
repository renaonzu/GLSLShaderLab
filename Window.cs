using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.IO;
 
namespace GLSLShaderLab
{
    public class Window : GameWindow
    {
        private int _vao;
        private Shader _shader;
        private Shader _copyShader;
        private float _time;
        private ShaderSelector.ShaderInfo _selectedShader;
        private List<ShaderSelector.ShaderInfo> _availableShaders;
        private int _currentShaderIndex;
        private bool _showHelp;
        private BufferManager _bufferManager;
        private bool _useBuffers = false;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
 
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
<<<<<<< HEAD

=======
 
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        public Window(int width, int height, string title, ShaderSelector.ShaderInfo selectedShader)
            : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = new Vector2i(width, height), Title = $"{title} - {selectedShader.Name}" })
        {
            _selectedShader = selectedShader;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
           
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
<<<<<<< HEAD
            
=======
           
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            // Carregar lista de shaders dispon�veis
            var selector = new ShaderSelector();
            _availableShaders = selector.GetAvailableShaders();
            _currentShaderIndex = _availableShaders.FindIndex(s => s.Name == selectedShader.Name);
            if (_currentShaderIndex == -1) _currentShaderIndex = 0;
        }
 
        protected override void OnLoad()
        {
            base.OnLoad();
 
            float[] vertices = {
                -1f, -1f, 0f,
                 1f, -1f, 0f,
                 1f,  1f, 0f,
                -1f,  1f, 0f,
            };
 
            uint[] indices = {
                0, 1, 2,
                2, 3, 0
            };
 
            _vao = GL.GenVertexArray();
            int vbo = GL.GenBuffer();
            int ebo = GL.GenBuffer();
 
            GL.BindVertexArray(_vao);
 
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
 
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);
 
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
<<<<<<< HEAD

            // Initialize buffer manager
            _bufferManager = new BufferManager(Size.X, Size.Y);

=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
 
            // Initialize buffer manager
            _bufferManager = new BufferManager(Size.X, Size.Y);
 
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
>>>>>>> Stashed changes
=======
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
>>>>>>> Stashed changes
=======
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
>>>>>>> Stashed changes
            // Load copy shader
            try
            {
                _copyShader = new Shader("Shaders/copy.vert", "Shaders/copy.frag");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading copy shader: {ex.Message}");
            }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
 
            LoadShader(_selectedShader);
           
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
<<<<<<< HEAD

            LoadShader(_selectedShader);
            
=======
 
            LoadShader(_selectedShader);
           
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            Console.WriteLine("Controls:");
            Console.WriteLine("  Arrows: Switch between shaders");
            Console.WriteLine("  B     : Toggle buffer system (iChannels)");
            Console.WriteLine("  H     : Show/hide help");
            Console.WriteLine("  ESC   : Exit");
            Console.WriteLine();
            Console.WriteLine("Buffer system: " + (_useBuffers ? "ENABLED" : "DISABLED"));
        }
 
        private void LoadShader(ShaderSelector.ShaderInfo shaderInfo)
        {
            try
            {
                _shader?.Dispose();
                _shader = new Shader(shaderInfo.VertexPath, shaderInfo.FragmentPath);
                _shader.Use();
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
<<<<<<< HEAD
                
                // Auto-activate buffers for shaders that need them
                if (shaderInfo.Name.Contains("PaintTutorial") || 
                    shaderInfo.Name.Contains("BufferDemo") || 
                    shaderInfo.Name.Contains("BufferTest") ||
                    shaderInfo.Name.Contains("SimplePaint") ||
                    shaderInfo.Name.Contains("Functions")
                    )
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
               
                // Auto-activate buffers for shaders that need them
                if (shaderInfo.Name.Contains("PaintTutorial") ||
                    shaderInfo.Name.Contains("BufferDemo") ||
                    shaderInfo.Name.Contains("BufferTest") ||
                    shaderInfo.Name.Contains("SimplePaint") ||
                    shaderInfo.Name.Contains("Functions"))
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
>>>>>>> Stashed changes
=======
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
>>>>>>> Stashed changes
=======
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
>>>>>>> Stashed changes
                {
                    if (!_useBuffers)
                    {
                        _useBuffers = true;
                        Console.WriteLine($"Buffer system AUTO-ENABLED for {shaderInfo.Name}");
                        Console.WriteLine("This shader requires buffers for persistence effects.");
                    }
                }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
               
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
<<<<<<< HEAD
                
=======
               
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
                Title = $"GLSL Shader Lab - {shaderInfo.Name}" + (_useBuffers ? " [Buffers ON]" : " [Buffers OFF]");
                Console.WriteLine($"Shader loaded: {shaderInfo.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading shader {shaderInfo.Name}: {ex.Message}");
            }
        }
 
        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);
 
            switch (e.Key)
            {
                case Keys.Escape:
                    Close();
                    break;
                   
                case Keys.Left:
                    if (_availableShaders.Count > 1)
                    {
                        _currentShaderIndex = (_currentShaderIndex - 1 + _availableShaders.Count) % _availableShaders.Count;
                        LoadShader(_availableShaders[_currentShaderIndex]);
                    }
                    break;
                   
                case Keys.Right:
                    if (_availableShaders.Count > 1)
                    {
                        _currentShaderIndex = (_currentShaderIndex + 1) % _availableShaders.Count;
                        LoadShader(_availableShaders[_currentShaderIndex]);
                    }
                    break;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
                   
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
<<<<<<< HEAD
                    
=======
                   
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
                case Keys.B:
                    _useBuffers = !_useBuffers;
                    Console.WriteLine("Buffer system: " + (_useBuffers ? "ENABLED" : "DISABLED"));
                    LoadShader(_availableShaders[_currentShaderIndex]); // Update title
                    break;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
                   
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
<<<<<<< HEAD
                    
=======
                   
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
                case Keys.H:
                    _showHelp = !_showHelp;
                    break;
            }
        }
 
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            _time += (float)args.Time;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
 
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
<<<<<<< HEAD

=======
 
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            if (_useBuffers)
            {
                RenderWithBuffers();
            }
            else
            {
                RenderDirect();
            }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
 
            SwapBuffers();
        }
 
        private void RenderWithBuffers()
        {
            // Render to the current buffer using previous buffer as input
            _bufferManager.BindCurrentBufferForWriting();
           
            _shader?.Use();
            _shader?.SetFloat("iTime", _time);
            _shader?.SetVector2("iResolution", new Vector2(Size.X, Size.Y));
            _shader?.SetVector2("iMouse", new Vector2(MouseState.X, Size.Y - MouseState.Y));
            _shader?.SetInt("iMouseClick", MouseState.IsButtonDown(MouseButton.Left) ? 1 : 0);
 
            // Bind previous frame as input
            _bufferManager.BindBuffersForReading(_shader);
 
            GL.BindVertexArray(_vao);
            GL.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, 0);
 
            // Copy current buffer to screen
            _bufferManager.UnbindBuffers();
            GL.Viewport(0, 0, Size.X, Size.Y);
 
            if (_copyShader != null)
            {
                _copyShader.Use();
                _copyShader.SetVector2("iResolution", new Vector2(Size.X, Size.Y));
               
                var currentBuffer = _bufferManager.GetCurrentBuffer();
                currentBuffer.BindForReading(TextureUnit.Texture0);
                _copyShader.SetTexture("inputTexture", 0);
               
                GL.BindVertexArray(_vao);
                GL.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, 0);
            }
           
            // Swap for next frame
            _bufferManager.SwapBuffers();
        }
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
<<<<<<< HEAD

            SwapBuffers();
        }

=======
 
            SwapBuffers();
        }
 
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
        private void RenderWithBuffers()
        {
            // Render to the current buffer using previous buffer as input
            _bufferManager.BindCurrentBufferForWriting();
<<<<<<< HEAD
            
            _shader?.Use();
            _shader?.SetFloat("iTime", _time);
            _shader?.SetVector2("iResolution", new Vector2(Size.X, Size.Y));
            _shader?.SetVector2("iMouse", new Vector2(MouseState.X, Size.Y - MouseState.Y));
            _shader?.SetInt("iMouseClick", MouseState.IsButtonDown(MouseButton.Left) ? 1 : 0);

            // Bind previous frame as input
            _bufferManager.BindBuffersForReading(_shader);

            GL.BindVertexArray(_vao);
            GL.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, 0);

            // Copy current buffer to screen
            _bufferManager.UnbindBuffers();
            GL.Viewport(0, 0, Size.X, Size.Y);

            if (_copyShader != null)
            {
                _copyShader.Use();
                _copyShader.SetVector2("iResolution", new Vector2(Size.X, Size.Y));
                
                var currentBuffer = _bufferManager.GetCurrentBuffer();
                currentBuffer.BindForReading(TextureUnit.Texture0);
                _copyShader.SetTexture("inputTexture", 0);
                
                GL.BindVertexArray(_vao);
                GL.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, 0);
            }
            
            // Swap for next frame
            _bufferManager.SwapBuffers();
        }

        private void RenderDirect()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

=======
           
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
            _shader?.Use();
            _shader?.SetFloat("iTime", _time);
            _shader?.SetVector2("iResolution", new Vector2(Size.X, Size.Y));
            _shader?.SetVector2("iMouse", new Vector2(MouseState.X, Size.Y - MouseState.Y));
            _shader?.SetInt("iMouseClick", MouseState.IsButtonDown(MouseButton.Left) ? 1 : 0);
<<<<<<< HEAD

            GL.BindVertexArray(_vao);
            GL.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, 0);
=======
 
            // Bind previous frame as input
            _bufferManager.BindBuffersForReading(_shader);
 
            GL.BindVertexArray(_vao);
            GL.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, 0);
 
            // Copy current buffer to screen
            _bufferManager.UnbindBuffers();
            GL.Viewport(0, 0, Size.X, Size.Y);
 
            if (_copyShader != null)
            {
                _copyShader.Use();
                _copyShader.SetVector2("iResolution", new Vector2(Size.X, Size.Y));
               
                var currentBuffer = _bufferManager.GetCurrentBuffer();
                currentBuffer.BindForReading(TextureUnit.Texture0);
                _copyShader.SetTexture("inputTexture", 0);
               
                GL.BindVertexArray(_vao);
                GL.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, 0);
            }
           
            // Swap for next frame
            _bufferManager.SwapBuffers();
>>>>>>> 20357b7d61c8dffdfcb5b3a4feaaf8556c509f94
        }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
 
        private void RenderDirect()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
 
            _shader?.Use();
            _shader?.SetFloat("iTime", _time);
            _shader?.SetVector2("iResolution", new Vector2(Size.X, Size.Y));
            _shader?.SetVector2("iMouse", new Vector2(MouseState.X, Size.Y - MouseState.Y));
            _shader?.SetInt("iMouseClick", MouseState.IsButtonDown(MouseButton.Left) ? 1 : 0);
 
            GL.BindVertexArray(_vao);
            GL.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, 0);
        }
 
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);
            _bufferManager?.Resize(e.Width, e.Height);
        }
 
        protected override void OnUnload()
        {
            _shader?.Dispose();
            _copyShader?.Dispose();
            _bufferManager?.Dispose();
            GL.DeleteVertexArray(_vao);
            base.OnUnload();
        }
    }
}