# System.Threading

Threads (linhas de execução) são tarefas que um programa pode executar de forma concorrente. Uma thread possui início, uma sequência de comandos e fim, que são executados de forma isolada dentro do programa. Um programa multi-threaded permite que tarefas distintas sejam executadas ao mesmo tempo, cenário que costuma ser chamado de paralelismo. 

Uma thread pode ser instanciada da seguinte maneira, onde NewThread é um método com o novo fluxo de execução.

    Thread t = new Thread(NewThread);

Apesar do exemplo atribuir a referência da nova thread à variável t, isso não é necessário para que a thread continue sendo executada. Tal atribuição, porém, permite acessar propriedades pertinentes à ela.

Por exemplo, o código abaixo define sua prioridade como segundo plano e inicia o fluxo.

    t.IsBackground = true;
    t.Start();
Caso a referência de uma nova thread não seja atribuída à uma variável, pode-se recuperar a referência da atual thread em execução da seguinte maneira.

    var t = Thread.CurrentThread;

Cada thread possui sua própria cultura, que representa o conjunto de configurações de formatação, comparação, sistema de escrita e o calendário usado pela thread.

    var culture = t.CurrentCulture;

A cultura de uma nova thread é definida com base nas configurações do sistema operacional e não com base na cultura da thread a partir da qual ela foi gerada.

Porém, caso uma thread execute operações assíncronas, uma nova thread herdará sua cultura.

Existem duas formas de se definir a cultura de uma thread. 

 - Passando a CultureInfo no construtor da nova thread
 - Definindo, em tempo de execução, a propriedade CurrentCulture da CurrentThread, conforme abaixo.

```
Thread.CurrentThread.CurrentUICulture = new CultureInfo("he-IL");
```