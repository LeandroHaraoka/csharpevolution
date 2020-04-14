# Events, Delegates and Lambdas

Sugestão: leia o tópico Delegates.

## Conceitos 

![Conceitos de eventos](EventDelegateHandler,jpg)

### Events

Evento é uma notificação gerada por um event raiser e escutada por múltiplos *subscribeds events handlers*, que carrega consigo uma informação (EventArgs).

### Delegates

Delegates são pipelines que permitem a emissão de um evento alcançar o events handlers que consumirão os EventArgs. São classes frequentemente chamadas de function pointers e são baseadas em uma base class MultiCastDelegate.

No escopo de eventos, um delegate é uma blueprint para o método do handler que processará o evento. A assinatura (exceto nome dos parâmetros) do delegate e do método do handler devem ser similares.

Quando definimos um delegate, o compilador na verdade cria uma classe que herda de MultiCastDelegate. No caso de existirem mais de um subscribed event handler, o multicast delegate invocará delegates em uma ordem sequencial definida por uma invocation list. 

### Event Handler

O EventHandler é um méto do que recebe e processa o dado recebido do delegate. Geralmente recebe dois parametros, sender e eventArgs. Sender é um objeto do tipo object que contém informações do emissor do evento. EventArgs é um objeto que encapsula os dados que devem ser recebidos e processados.

### Criando um delegate

Inicialmente definimos o delegate, chamado aqui de XptoHandler(int number). Para instanciarmos um delegate, passamos a função WorkDone1 e WorkDone2, que contém as instruções desejadas e concatenamos o resultado.

Ao invés de invocarmos diretamente o método do delegate, invocamos DoWork, passando o delegate, permitindo que o argumento number = 99 seja definido apenas no escopo de DoWork e, este último, desconheça as instruções que serão executadas. Assim, DoWork torna-se completamente dinâmico. 

A funcionalidade atingida torna-se similar à emissão de eventos. Uma função DoWork conhece os dados do evento, number = 99, e envia para todos os inscritos, que sequencialmente processam os dados, WorkDone1 e WorkDone2.

```
class Program
{
	static void WorkDone1(int number)
	{
		Console.WriteLine($"Executed 1 {number}");
	}

	static void WorkDone2(int number)
	{
		Console.WriteLine($"Executed 2 {number}");
	}
	
	static void Main(string[] args)
	{
		XptoHandler delegate1 = new XptoHandler(WorkDone1);
		XptoHandler delegate2 = new XptoHandler(WorkDone2);
		
		delegate1 += delegate2;

		// Ao invés de usar delegate1(99) e delegate2(99), usamos:
		DoWork(delegate1);
	}

	static void DoWork(XptoHandler delegate)
	{
		delegate(99);
	}
}
```

### Definindo um Evento

Um evento por si só não possui valor, sua definição depende de um delegate, a pipeline que transportará o evento para os subscribeds event handlers. No exemplo, o delegate atrelado ao evento é o WorkHandler e o nome do evento é WorkDone.

    public event WorkHandler WorkDone 

### Lançando eventos

O método OnWorkDone poderia conter apenas uma instrução WorkDone(number), ou seja, apenas invocar o evento, mas lançaria uma excessão caso não existam listeners. Assim, criamos o método OnWorkDone e invocamos ele quando desejamos lançar o evento. 
```
public delegate void XptoHandler(int number); // Define o delegate 

class Worker
{
	public event XptoHandler WorkDone; // Define o evento com o delegate desejado
		
	protected virtual void OnWorkDone(int number)
	{
		XptoHandler delegate = WorkDone as XptoHandler; // Inicializa o delegate atrelado ao evento
			
		if (delegate != null) // Verifica se existem listeners atrelados ao evento	
			delegate(number);
	}
}
```

Poderíamos ainda simplificar o método OnWorkDone para o exemplo abaixo.
```
protected virtual void OnWorkDone(int number)
{
	if (WorkDone!= null) 
		WorkDone(number);
}
```

### Criando EventArgs

Uma classe de EventArgs customizada é simplesmente uma classe que deriva de EventArgs e possui as propriedades que representam os dados do evento.
```
public class WorkDoneEventArgs : EventArgs
{
	public int Number { get; set; }

	public WorkDoneEventArgs(int number)
	{
		Number = number;
	}
}
```

Com esta classe criada, ganhamos algumas vantagens. Não somos mais obrigados a definir um delegate customizado. Podemos apenas utilizar um evento atrelado ao EventHandler<T> genérico onde T é tipado com a classe que criamos.

```
public class Worker
{
	public event EventHandler<WorkDoneEventArgs> WorkDone; // Define o evento com o delegate desejado
	
	protected virtual void OnWorkDone(int number)
	{
		XptoHandler delegate = WorkDone as EventHandler<WorkDoneEventArgs>; // Inicializa o delegate atrelado ao evento
		if (delegate != null)	
				delegate(this, new WorkDoneEventArgs(99));
	}
}
```