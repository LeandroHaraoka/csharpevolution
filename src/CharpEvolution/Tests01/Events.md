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
	
	public void DoWork(int number)
	{
		OnWorkDone(number);
	}
}
```
## Handling events

### Instanciando eventos
Dada a última configuração apresentada, podemos instanciar um evento da seguinte maneira

    var worker = new Worker();
    worker.WorkDone = += new EventHandler<WorkDoneEventArgs>(WorkDone1); // Aqui estamos atrelando um evento a um event handler
    worker.DoWork(99

);
Que pode ser simplificado para 

    var worker = new Worker();
    worker.WorkDone = += WorkDone1; // O compilador irá inferir pela assinatura do método
    worker.DoWork(99);

### Anonymous method (deprecated by lambdas)

    var worker = new Worker();
    worker.WorkDone += 
	    delegate(object sender, WorkPerformedEventArgs e)
	    {
		    Console.WriteLine(e.Number);
	    }
    worker.DoWork(99);

## Lambdas, Action<T> and Func<T,TResult>

Lambdas expressions podem ser definidas para qualquer delegate.
A instanciação de eventos apresentada no último tópico pode ser realizada da seguinte maneira usando lambas.

    var  worker = new  worker();
    worker.WorkDone += (sender, e) => 
	    {
	    	Console.WriteLine(e.Number);
	    }
    worker.DoWork(99);

### Lambdas with CustomDelegates

Abaixo apresentamos um exemplo do lambdas e delegates. Possuímos um método anêmico que realiza operações matemáticas, mas não conhece nenhuma regra de cálculo. Na assinatura do método, recebe-se os números e um delegate, que representa indicará a regra que deverá ser utilizada.

Na classe que consome o método, instanciamos dois delegates, cada um a partir de uma lambda expression que contém as instruções para o cálculo.
```
public  delegate  int  CustomDelegate(int  x, int  y);

class Program
{
    public static void Main(string[] args)
    {
        CustomDelegate addDelegate = (x, y) => x + y;         
        CustomDelegate multiplyDelegate = (x, y) => x * y;         

        var calculate = new Calculate();
        var addResult = calculate.Execute(1, 2, addDelegate);
        var multiplicationresult = calculate.Execute(1, 2, multiplyDelegate);
    }
}
```
```
class Calculate
{
    public int Execute(int x, int y, CustomDelegate customDelegate)
    {
        return customDelegate(x, y);
    }
}
```
### Action

O C# possui alguns delegates predefinidos que ajudam a poupar tempo do desenvolvedor com a criação das assinaturas mais comuns no dia a dia. O Action<T> representa um delegate cuja assinatura não retorna nenhum objeto e recebe apenas um único parâmetro. Existem diversas assinaturas para o Action, mas resumidamente a Action é um delegate que recebe n parâmetros e não retorna nenhum valor.

    public delegate void Action<T>(T obj);
    public delegate void Action<T1,T2>(T1 obj1,T2 obj2);
    public delegate void Action<T1,T2,T3>(T1 obj1,T2 obj2,T3 obj3);

### Function

A Function<T, TResult> representa um delegate cuja assinatura retorna um único objeto e recebe n parâmetros.

    public delegate TResult Function<T,TResult>(T obj);
    public delegate TResult Function<T1,T2,TResult>(T1 obj1,T2 obj2);
    public delegate TResult Function<T1,T2,T3,TResult>(T1 obj1,T2 obj2,T3 obj3);


## Resumo

Criação de um evento:
```
public event EventHandler<JobChangedEventARgs> JobChanged;
```

Lançamento de um evento:
```
public void OnJobChanged(object sender, Job job)
{
	var jobChangeDelegate = JobChanged as EventHandler<JobChangedEventARgs>(); 
	if (jobChangeDelegate != null)
	{
		jobChangeDelegate(sender, new JobChangedEventARgs {Job = job});
	}
}
```

No ponto do código que queremos lançar o evento, basta invocar OnJobChanged();

Para inscrever um cara no evento, basta fazer 
```
JobChanged += (s, e) =>  { Metodo(e.Job)}
```

TODO: Juntar tópico de delegates com events