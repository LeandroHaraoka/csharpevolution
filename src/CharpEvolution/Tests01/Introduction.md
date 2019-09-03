# Introdução Relâmpago
  
## Sintaxe Básica 01
  
### Namespaces

Namespaces podem ser definidos como agrupamentos lógicos. Eles são utilizados como um sistema de **organização** **interna** para o projeto e como uma forma de **expor** seu conteúdo para aplicações **externas**.

Para **acessar** namespaces, utiliza-se a *diretiva **using***. 

Ao invés de explicitar o namespace do membro de forma **recorrente**:

    System.Console.WriteLine("Hello, World!");

pode-se **importar** no início do arquivo uma **única** vez:

    using System;
    
    Console.WriteLine("Hello, World!");

Também é possível o uso de ***aliases***. 
Para referenciar namespaces, usa-se dois-pontos (::).
Para referenciar tipos, usa-se ponto (.).

    using generics = System.Collections.Generic; 
    var dict = new generics::Dictionary<string, int>();
    
    using console = System.Console;
    console.WriteLine("Hi");

Namespaces podem ser utilizados para definir **escopos** dentro um projeto. No exemplo abaixo, uma classe de nome *"**letter**"* pode representar coisas totalmente **diferentes** dependendo do escopo no qual ela se encontra. Dentro no namespace ***characters*** ela representa uma **letra**, enquanto que no namespace ***mediaType*** representa uma **carta**.

    namespace characters  
    { 
	    public class letter 
        { 
	        //Esta classe representa uma letra
        } 
    }
  
    namespace mediaType  
    { 
	    public class letter 
        { 
            //Esta classe representa uma carta
        } 
    }
#### Aliases para conflitos de membros
Namespaces podem também evitar ambiguidade de classes com mesmo nome, conforme visto acima. Para evitar a ambiguidade em tempo de execução, pode-se adotar a seguinte abordagem:

    namespace  NamespaceXpto 
    { 
        using characters; 
        using mediaType; 
        using letra = characters.Letter; 
        using carta = mediaType.Letter; 
    }
Desta forma, quando quisermos acessar a classe **Letter** de characters, usamos o alias ***letra*** e para a classe Letter de mediaType usamos ***carta***. Os aliases evitam ambiguidade no acesso das classes Letter.

#### Extern alias
Extern alias são referências definidas fora do código-fonte para referenciar versões diferentes de um assembly em uma mesma aplicação. Por exemplo, pode-se definir no prompt de comando os seguintes extern aliases .

       /r:GridV1=grid.dll
       /r:GridV2=grid20.dll

Essas referências, poderão ser utilizadas no código da seguinte maneira:

    extern alias GridV1;
    extern alias GridV2;
    GridV1::Grid //referência para o grid control do grid.dll
    GridV2::Grid //referência para o grid control do grid20.dll

#### Referências:

 - [https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/language-specification/namespaces](https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/language-specification/namespaces)
 - [https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/namespaces/](https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/namespaces/)

TODO: diretiva using static
TODO: declarações de tipo (private, protected, internal, etc)

### Classes

Uma classe é um modelo para definir características e comportamentos de objetos. Ela pode modelar diversos objetos, ou seja, pode conter várias instâncias. 

Por exemplo, sendo João uma instância da classe Pessoa, esta classe é um tipo de referência que define quais caraterísticas e comportamentos o objeto João pode ter. Da mesma forma, Fernando, Maria e Lucas poderiam ser novas instâncias da classe Pessoa, que seguem a mesma modelagem definida para João.

Na criação de um objeto garante-se memória para alocação em *heap* e a variável carrega consigo apenas um endereço de localização (alocado em *stack*) do objeto. Em tempo de execução, conta-se com o *garbage collector*, que é uma ferramenta para gerenciamento que, neste contexto, tem o papel de limpar referências de objetos que não estão mais em uso.

### Structs

Diferente das classes, structs herdam diretamente de ValueTypes. Isso quer dizer que, ao criar um objeto, seu conteúdo é alocado em *stack*, e não há referências, como acontece nas classes. Portanto, quando copiamos o valor de uma instância para outra, os objetos são independentes e as alterações em um deles não influencia no outro.

### Types in C#

Existem duas categorias de tipos em C#. Reference e value types.

#### Reference Types
Nos Reference types, quando atrelamos uma variavel a um determinado objeto, estamos direcionando o ponteiro dela para o endereco onde esta instancia se encontra. Em outras palavras, registramos um endereco de memoria no qual o objeto se encontra. Sendo assim, varias variaveis podem apontar para o mesmo objeto. Quando realizamos operacoes em uma delas, estamos impactando todas as outras que referenciam o mesmo objeto. Alguns exemplos de reference types em C#: dynamics, string, object.

#### Value Types
Nos Value types, cada variavel carrega consigo as informacoes do objeto. Sendo assim, quando realizamos operacoes em uma variavel, nao ha impacto em nenhuma outra instancia, alteramos apenas o estado do seu proprio conteudo. Alguns exemplos de value types em C#: int, long, double, float, bool, decimal, char, enum, struct. Todos os value types derivam de System.ValueType.

https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/reference-types
https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/value-types

### Access Modifiers
Em C#, os tipos  e membros (subclasses e metodos) possuem modificadores de acesso. A ideia dessa ferramenta e configurar o nivel de exposicao dos tipos e membros. Em outras palavras, podemos usa-la para permitir ou nao o uso deles em outros trechos de codigo do projeto.
Os modificadores de acesso existentes sao:
|Modificador de acesso|  Descricao|
|--|--|
|public| Torna acessivel para qualquer codigo do mesmo assembly e de qualquer outro que referencie este.|
|internal| Torna acessivel apenas para codigo do mesmo assembly.|
|protected| Torna acessivel dentro da class na qual esta contido e dentro de todas as outras que herdam esta.|
|protected internal| Torna acessivel para codigo do mesmo assembly e codigo de outra classe herdeira contida em outro assembly.
|private| Torna acessivel dentro da class/struct na qual esta contido.|
|private protected| Torna acessivel dentro da class na qual esta contido e dentro das que herdam esta, desde que estejam no mesmo assembly.

## Sintaxe Básica 02

### Construtores
Um construtor é um tipo especial de método responsável por configurar a inicialização de objetos. É com base nessa configuração que as classes e structs são instanciadas. 

Caso um construtor não seja definido, o C# atribui os respectivos valores default para o tipo de classe/struct e para seus membros.

#### Construtores de instância

Além do comportamento descrito acima, um construtor de instância pode ser utilizado para chamar construtores de instância de base classes.

    class Circle : Shape 
    {
          public Circle(double radius) 
	          : base(radius, 0)
         {
         } 
    }
    
No exemplo acima, o construtor da classe Circle chama o construtor da base class Shape e inicia o objeto utilizando ambos os construtores. 

#### Construtores privados
Em classes onde todos os membros são estáticos costuma-se encontrar construtores privados. Estes construtores possuem a função de impedir a instanciação dessas classes. Uma classe que possui apenas construtores privados, não pode ser instanciada e nem herdade por nenhuma outra classe (exceto em classes aninhadas).

#### Construtores estáticos

Um construtor pode ser do tipo estático. Neste caso, utiliza-se o construtor para iniciar os valores dos membros estáticos de uma classe ou struct .Construtores estáticos são parameterless.

Durante toda a execução da aplicação, o método do construtor estático é invocado uma única vez, antes da criação da primeira instância da classe ou antes que um membro estático seja referenciado. 

### Destrutores
A destruição de uma instância de determinada classe é configurada pelo método definido no seu respectivo destrutor. Tal método é único e parameterless. 

O método do destrutor não pode ser chamado explicitamente. Sua execução ocorre de forma automática no momento em que uma instância se torna elegível para destruição. Isso ocorre quando a instância não pode ser mais utilizada em nenhum trecho do código da aplicação. 

O garbage collector procura instâncias elegíveis para destruição. Quando uma instância é destruída, executam-se os destrutores de todas as classes das quais a classe herdou. Por exemplo, na execução abaixo:

    class First
    { 
	    ~First() 
	    { 
	    Console.WriteLine("First's destructor"); 
	    } 
    } 
    
    class Second: First 
    { 
	    ~Second() 
	    { 
		    Console.WriteLine("Second's destructor"); 
	    } 
    } 
    
    class Third: Second 
    { 
	    ~Third() 
	    { 
		    Console.WriteLine("Third's destructor"); 
	    } 
    } 
    
    class  Test 
    { 
    static void Main() 
	    { 
	    var third = new Third(); 
	    third = null; 
	    GC.Collect(); 
	    GC.WaitForPendingFinalizers(); 
	    } 
    }
temos o seguinte resultado:

    Third's destructor
    Second's destructor 
    First's destructor
Quando chamamos um destrutor, implicitamente estamos executando o seguinte:

    protected override void Finalize() 
    { 
	    try 
	    { 
		    // ação do destrutor
	    } 
	    finally 
	    { 
		    base.Finalize(); 
	    } 
    }
Ou seja, executamos a ação do destrutor e invocamos recursivamente o método Finalize de todas as instâncias da cadeia de herança.