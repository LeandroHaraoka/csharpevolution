# Delegates
A proposta de um delegate é encapsular um trecho de código que pode ser repassado e executado quando necessário, de uma forma type-safe em relação aos seus parâmetros e tipos de retorno.

Existem três maneiras de instanciar um delegate.

## Method group conversions
Methods groups são conjuntos de métodos que possuem o mesmo nome. Suponha as definições de um delegate e de um método conforme abaixo.

    public delegate void PrintDelegate<T>(T value);
    public void PrintMethod<string>(string value)

Perceba que a assinatura do método é compatível com a definição do delegate, mesmos parâmetros e mesmo tipo de retorno.

Na versão C# 1, instanciava-se um delegate da seguinte forma:

    PrintDelegate printDelegate = new PrintDelegate(PrintMethod);

Já no C# 2, introduziu-se o conceito de method group conversion, que permite a conversão implícita de um method group para qualquer delegate que possua assinatura compatível com umas das overloads.
No caso acima, a inicialização do delegate passaria a ocorrer da seguinte forma:	

      PrintDelegate printDelegate = PrintMethod;

## Anonymous methods

Outra forma de inicializar um delegate é por meio de métodos anônimos. 

    void Print(string message)
    {
	    Console.WriteLine("Inicializing delegate.")
	    result = delegate
	    {
			Console.WriteLine(message);
	    }
    }

No exemplo, atribui-se à variável result uma função que simplesmente executa um print quando result for executado. Note que o parâmetro *message* é acessível de dentro do corpo do delegate.

Apesar de ser uma das maneiras de inicializar um delegate, esta caiu em desuso com a chegada das lambas expressions na versão C#3 .

## Delegate Compatibility

O conceito de compatibilidade de delegates permite que um novo delegate seja criado a partir de um existente, desde que este possua uma assinatura compatível.

    public delegate string Printer(string message);
    
    public string PrintAnything(string obj)
    {
	    Console.WriteLine(obj);
    }

    public delegate object GeneralPrinter(object obj);

    Printer printer = new Printer(generalPrinter);

Note que um delegate Printer recebe e retorna valores do tipo string, assim como a função PrintAnything. Suponha então que inicializamos um delegate Printer.

A partir de Printer, podemos inicializar um novo delegate, GenericPrinter, pois os tipos diferentes de delegates possuem assinaturas compatíveis.