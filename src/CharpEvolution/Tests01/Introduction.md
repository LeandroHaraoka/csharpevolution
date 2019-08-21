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