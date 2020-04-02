# IDisposable
A interface IDisposable possui funcionalidades que garantem "clean up" de recursos da memória que não são mais utilizados pela aplicação.

O garbage collector já realiza o clean up citado, porém não se pode prever quando será executado. Além disso, existem recursos que não são gerenciados por ele, como arquivos abertos e streams.

Existem o Dispose Pattern que é um padrão para a implementação da interface IDisposable em recursos que permitem heranças (não são sealed).

Para base classes: 
 - A base class deve conter um método público não virtual Dispose() e um método protected virtal Dispose(bool disposing).
 - O método Dispose() deve invocar o Dispose(bool disposing) e executar *GC.SuppressFinalize(this)*.

Para derived classes: 
 - O método Dispose(bool disposing) deve ser sobreescrito e invocar o base.Dispose(bool disposing).
 
```
public class BaseClass : IDisposable
{
	~BaseClass()
	{
		Dispose(false);
	}

   bool disposed = false;
   // SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true); Usar isso caso o destrutor da classe não chame Dispose(false), para garantir que as instruções do Dispose serão executadas quando o GC executar.
   
   public void Dispose()
   { 
      Dispose(true);
      GC.SuppressFinalize(this);           
   }
   
	protected virtual void Dispose(bool disposing)
	{
		if (disposed)
			return; 
		if (disposing) 
		{
		     // handle.Dispose(); Usar isso caso o destrutor da classe não chame Dispose(false), para garantir que as instruções do Dispose serão executadas quando o GC executar.
		     // Instruções para a limpeza dos recursos
		}
  
		disposed = true;
	}
}
```
```
class DerivedClass : BaseClass
{
	~DerivedClass()
	{
		Dispose(false);
	}

	bool disposed = false;

	protected override void Dispose(bool disposing)
	{
		if (disposed)
			return; 
      
		if (disposing) 
		{
			// Instruções para a limpeza dos recursos
		}

		disposed = true;

		base.Dispose(disposing);
	}
}
```

Para utilizar um recurso que implementa IDisposable existem duas maneiras:

**Try-finally pattern**
Invoca-se o método Dispose() do recurso dentro do bloco finally, garantindo a limpeza do recurso após a execução das intruções contidas no bloco try.

```
try 
{ 
	sr = new StreamReader(filename); 
	txt = sr.ReadToEnd(); 
} 

finally 
{ 
	if (sr != null) 
		sr.Dispose(); 
}
```
**Using Statement**

O using statement nada mais é do que uma conveniência para simplificar a sintaxe do try-finally pattern. O compilador traduzirá o statement para o try-finally pattern.
```
using (StreamReader sr = new StreamReader(filename)) 
{ 
	txt = sr.ReadToEnd(); 
}
```

